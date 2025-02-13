using System;
using System.Runtime.CompilerServices;
using UnityEngine;



public enum Input_key_state {
    
        // ** manter: fica estranho no update mas issov ai ser usado fora do teclado, ou seja se for declarado como field precisa sinalizar que temq ue por um valor
        not_give,
        
        off,
        press, 
        hold, 
        release,

}


public class INPUT_DEVICE__keyboard_and_mouse : Input_device {

        public INPUT_DEVICE__keyboard_and_mouse(){
        
            nome_modulo = "MODULO__input_keyboard_AND_mouse";

        }
        
        public KeyCode[] bind_actions_TO_key_atual;
        public bool[] acoes_bloqueadas;


        public bool Get_action( int _acao ){ return Input.GetKey( Pegar_tecla_final( _acao ) ); }
        public bool Get_action_down( int _acao ){ return Input.GetKeyDown( Pegar_tecla_final( _acao ) ); }
        public bool Get_action_up( int _acao ){ return Input.GetKeyUp( Pegar_tecla_final( _acao ) ); }
        

        public float Get_value_axis( int _acao ){


                if( Input.GetKey( Pegar_tecla_final( _acao ) ) )
                    { return 1f; } 

                return 0f;
            
        }

        public Input_code[] keys = new Input_code[ ( int ) Input_code.END ];



        public static Input_key_state[] keys_states = new Input_key_state[ ( int ) Input_code.END ];

        public static void Put_defult(){

            for( int index = 0; index < keys_states.Length; index++ )
                { keys_states[ index ] = Input_key_state.off; }

        }


        public KeyCode[] letters = new KeyCode[ ( int ) Input_code.END ];

        public static KeyCode[] Get_dic(){

                KeyCode[] dic = new KeyCode[ ( int ) Input_code.END ];

                    // letters
                    dic[ ( int ) Input_code.a ] = KeyCode.A;
                    dic[ ( int ) Input_code.b ] = KeyCode.B;
                    dic[ ( int ) Input_code.c ] = KeyCode.C;
                    dic[ ( int ) Input_code.d ] = KeyCode.D;
                    dic[ ( int ) Input_code.e ] = KeyCode.E;
                    dic[ ( int ) Input_code.f ] = KeyCode.F;
                    dic[ ( int ) Input_code.g ] = KeyCode.G;
                    dic[ ( int ) Input_code.h ] = KeyCode.H;
                    dic[ ( int ) Input_code.i ] = KeyCode.I;
                    dic[ ( int ) Input_code.j ] = KeyCode.J;
                    dic[ ( int ) Input_code.k ] = KeyCode.K;
                    dic[ ( int ) Input_code.l ] = KeyCode.L;
                    dic[ ( int ) Input_code.m ] = KeyCode.M;
                    dic[ ( int ) Input_code.n ] = KeyCode.N;
                    dic[ ( int ) Input_code.o ] = KeyCode.O;
                    dic[ ( int ) Input_code.p ] = KeyCode.P;
                    dic[ ( int ) Input_code.q ] = KeyCode.Q;
                    dic[ ( int ) Input_code.r ] = KeyCode.R;
                    dic[ ( int ) Input_code.s ] = KeyCode.S;
                    dic[ ( int ) Input_code.t ] = KeyCode.T;
                    dic[ ( int ) Input_code.u ] = KeyCode.U;
                    dic[ ( int ) Input_code.v ] = KeyCode.V;
                    dic[ ( int ) Input_code.w ] = KeyCode.W;
                    dic[ ( int ) Input_code.x ] = KeyCode.X;
                    dic[ ( int ) Input_code.y ] = KeyCode.Y;
                    dic[ ( int ) Input_code.z ] = KeyCode.Z;

                return dic;

                


        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void  Change_input_state( KeyCode key, ref Input_key_state _current_state ){

                    // ** Input.GetKey não é confiavel, se um frame levar muito tempo pode ter diferença entre a parte logica e a parte mecanica
                    // ** o correto seria tecla pressiona -> tecla manter pressionada -> tecla solta
                    // ** um sistema bom nao usaria GetKey, mas nao é confiavel
                    // ** mas se o frame demorar muito fica tecla pressiona -> nada 
                    // ** mas se o frame demorar muito o getKeyUp pode nao vir
                    // ** com thread.Sleep( t )
                    // ** 1 seg -> erro
                    // ** 500ms -> erro
                    // ** 250ms -> erro
                    // ** 100ms -> erro

                    // ** talvez seja de logica?

                    // ** depois de testes: as 3 podem estar ativas ao mesmo tempo -> ficam todas falsas ao mesmo tempo

                    // ** final : GetKey é o unico confiavel
                    


                        if( _current_state == Input_key_state.off )
                        { 
                            if( Input.GetKey( key ) )
                                { _current_state = Input_key_state.press; }
                        }
                else if( _current_state == Input_key_state.press )
                        {
                            if( Input.GetKey( key ) )
                                { _current_state = Input_key_state.hold; }
                                else
                                { _current_state = Input_key_state.release; }
                        }
                else if( _current_state == Input_key_state.hold )
                        {
                            if( !!!( Input.GetKey( key ) ) )
                                { _current_state = Input_key_state.release; }
                        }
                else if( _current_state == Input_key_state.release )
                        {
                        
                            if( Input.GetKey( key ) )
                                { _current_state = Input_key_state.press; }
                                else
                                { _current_state = Input_key_state.off; }
                        }


        }



        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static void Change_input_state_2_keys( KeyCode key_1, KeyCode key_2, ref Input_key_state _current_state ){

                
                bool press = ( Input.GetKey( key_1 ) || Input.GetKey( key_2 ) );

                     if( _current_state == Input_key_state.off )
                        { 
                            if( press )
                                { _current_state = Input_key_state.press; }
                        }
                else if( _current_state == Input_key_state.press )
                        {
                            if( press )
                                { _current_state = Input_key_state.hold; }
                                else
                                { _current_state = Input_key_state.release; }
                        }
                else if( _current_state == Input_key_state.hold )
                        {
                            if( !!!( press ) )
                                { _current_state = Input_key_state.release; }
                        }
                else if( _current_state == Input_key_state.release )
                        {
                        
                            if( press )
                                { _current_state = Input_key_state.press; }
                                else
                                { _current_state = Input_key_state.off; }
                        }


        }



        public override void Update(){


                // KEYS
                int index_input = 0;
                int index = 0;

                index_input = ( int ) Input_code.START_LETTERS;
                index = ( int ) ( KeyCode.A - 1 );


                while( index_input != ( int ) ( Input_code.END_LETTERS - 1 ) ){

                    index++;
                    index_input++;

                    //performance
                    // ** talvez seja melhor copiar struct[] de field para stack(?) ficar fazendo ref field mesmo com struct pode ser mais lento
                    Change_input_state( ( KeyCode ) index, ref keys_states[ index_input ] );

                }


                // NUMBERS
                Change_input_state_2_keys( KeyCode.Alpha0, KeyCode.Keypad0, ref keys_states[ ( int ) Input_code.nun_0 ] );
                Change_input_state_2_keys( KeyCode.Alpha1, KeyCode.Keypad1, ref keys_states[ ( int ) Input_code.nun_1 ] );
                Change_input_state_2_keys( KeyCode.Alpha2, KeyCode.Keypad2, ref keys_states[ ( int ) Input_code.nun_2 ] );
                Change_input_state_2_keys( KeyCode.Alpha3, KeyCode.Keypad3, ref keys_states[ ( int ) Input_code.nun_3 ] );
                Change_input_state_2_keys( KeyCode.Alpha4, KeyCode.Keypad4, ref keys_states[ ( int ) Input_code.nun_4 ] );
                Change_input_state_2_keys( KeyCode.Alpha5, KeyCode.Keypad5, ref keys_states[ ( int ) Input_code.nun_5 ] );
                Change_input_state_2_keys( KeyCode.Alpha6, KeyCode.Keypad6, ref keys_states[ ( int ) Input_code.nun_6 ] );
                Change_input_state_2_keys( KeyCode.Alpha7, KeyCode.Keypad7, ref keys_states[ ( int ) Input_code.nun_7 ] );
                Change_input_state_2_keys( KeyCode.Alpha8, KeyCode.Keypad8, ref keys_states[ ( int ) Input_code.nun_8 ] );
                Change_input_state_2_keys( KeyCode.Alpha9, KeyCode.Keypad9, ref keys_states[ ( int ) Input_code.nun_9 ] );

                // FN

                for( index_input = ( int ) Input_code.START_FN, index = ( int ) ( KeyCode.F1 - 1 ) ; index_input < ( int ) ( Input_code.END_LETTERS - 1 ) ; index++, index_input++ )
                    { Change_input_state( ( KeyCode ) index, ref keys_states[ index_input ] );}



                // COMMANDS

                Change_input_state_2_keys( KeyCode.LeftControl ,KeyCode.RightControl, ref keys_states[ ( int ) Input_code.control ] );
                Change_input_state_2_keys( KeyCode.LeftAlt, KeyCode.RightAlt, ref keys_states[ ( int ) Input_code.alt ] );
                Change_input_state_2_keys( KeyCode.LeftShift, KeyCode.RightShift, ref keys_states[ ( int ) Input_code.shift ] );

                //mark 
                // ** quando for fazer a logica vai precisar levar em conta que nao tem como saber o atual estado da tecla
                Change_input_state( KeyCode.CapsLock, ref keys_states[ ( int ) Input_code.shift ] );


                Change_input_state( KeyCode.Space , ref keys_states[ ( int ) Input_code.space ] );
                Change_input_state( KeyCode.KeypadEnter , ref keys_states[ ( int ) Input_code.space ] );
                                                            //??????????????????????? 
                Change_input_state_2_keys( KeyCode.KeypadEnter, KeyCode.Return, ref keys_states[ ( int ) Input_code.enter ] );
                Change_input_state( KeyCode.Tab , ref keys_states[ ( int ) Input_code.tab ] );
                Change_input_state( KeyCode.Backspace , ref keys_states[ ( int ) Input_code.back_space ] );

                Change_input_state( KeyCode.PageUp , ref keys_states[ ( int ) Input_code.page_up ] );

                Change_input_state( KeyCode.PageDown , ref keys_states[ ( int ) Input_code.page_down ] );


                Change_input_state( KeyCode.Home , ref keys_states[ ( int ) Input_code.home ] );
                Change_input_state( KeyCode.End , ref keys_states[ ( int ) Input_code.end ] );

                Change_input_state( KeyCode.Delete , ref keys_states[ ( int ) Input_code.delete ] );
                Change_input_state( KeyCode.Insert , ref keys_states[ ( int ) Input_code.insert ] );

                //mark
                // ** print funciona diferente, ele ativa todos e depois desliga, faz sentido pela funcao
                // ** fica no prtSc
                Change_input_state( KeyCode.Print , ref keys_states[ ( int ) Input_code.print_screen ] );
                Change_input_state( KeyCode.Pause , ref keys_states[ ( int ) Input_code.pause ] );


        }



        private KeyCode Pegar_tecla_final( int _acao ){

            if( acoes_bloqueadas[ _acao ] )
                { return KeyCode.None; }

            return bind_actions_TO_key_atual[  _acao ];

        }



    

    // public static Key_board_read Filter_keyborad_keys( Input_code[] _){}



    public static Key_board_read Get_keys(){

            Key_board_read ret = new Key_board_read();

            string retorno = "";
            int index = 0;
            char[] retorno_char = new char[ 100 ];

            if( Input.GetKeyDown( KeyCode.RightShift ) || Input.GetKeyDown( KeyCode.LeftShift )  )
                {

                    if( Input.GetKeyDown( KeyCode.A ) ){ retorno_char[ index ] += 'A' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.B ) ){ retorno_char[ index ] += 'B' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.C ) ){ retorno_char[ index ] += 'C' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.D ) ){ retorno_char[ index ] += 'D' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.E ) ){ retorno_char[ index ] += 'E' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.F ) ){ retorno_char[ index ] += 'F' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.G ) ){ retorno_char[ index ] += 'G' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.H ) ){ retorno_char[ index ] += 'H' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.I ) ){ retorno_char[ index ] += 'I' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.J ) ){ retorno_char[ index ] += 'J' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.K ) ){ retorno_char[ index ] += 'K' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.L ) ){ retorno_char[ index ] += 'L' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.M ) ){ retorno_char[ index ] += 'M' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.N ) ){ retorno_char[ index ] += 'N' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.O ) ){ retorno_char[ index ] += 'O' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.P ) ){ retorno_char[ index ] += 'P' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Q ) ){ retorno_char[ index ] += 'Q' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.R ) ){ retorno_char[ index ] += 'R' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.S ) ){ retorno_char[ index ] += 'S' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.T ) ){ retorno_char[ index ] += 'T' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.U ) ){ retorno_char[ index ] += 'U' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.V ) ){ retorno_char[ index ] += 'V' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.W ) ){ retorno_char[ index ] += 'W' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.X ) ){ retorno_char[ index ] += 'X' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Y ) ){ retorno_char[ index ] += 'Y' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Z ) ){ retorno_char[ index ] += 'Z' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Alpha0 ) ){ retorno_char[ index ] += ')' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Alpha1 ) ){ retorno_char[ index ] += '!' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Alpha2 ) ){ retorno_char[ index ] += '@' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Alpha3 ) ){ retorno_char[ index ] += '#' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Alpha4 ) ){ retorno_char[ index ] += '$' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Alpha5 ) ){ retorno_char[ index ] += '%' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Alpha6 ) ){ retorno_char[ index ] += '¨' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Alpha7 ) ){ retorno_char[ index ] += '&' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Alpha8 ) ){ retorno_char[ index ] += '*' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Alpha9 ) ){ retorno_char[ index ] += '(' ; index++ ; }


                    if( Input.GetKeyDown( KeyCode.Minus )  ){ retorno_char[ index ] += '_' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Equals )  ){ retorno_char[ index ] += '+' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Comma ) ){ retorno_char[ index ] += '<' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Period ) ){ retorno_char[ index ] += '>' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Period ) ){ retorno_char[ index ] += ':' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Slash ) ){ retorno_char[ index ] += '?' ; index++ ; }



                    if( Input.GetKeyDown( KeyCode.RightBracket )  ){ retorno_char[ index ] += '}' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.LeftBracket )  ){ retorno_char[ index ] += '{' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Quote )  ){ retorno_char[ index ] += '\"' ; index++ ; }
                    if( Input.GetKeyDown( KeyCode.Backslash )  ){ retorno_char[ index ] += '|' ; index++ ; }



                }
                else
                {

                        if( Input.GetKeyDown( KeyCode.A ) ){ retorno_char[ index ] += 'a' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.B ) ){ retorno_char[ index ] += 'b' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.C ) ){ retorno_char[ index ] += 'c' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.D ) ){ retorno_char[ index ] += 'd' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.E ) ){ retorno_char[ index ] += 'e' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.F ) ){ retorno_char[ index ] += 'f' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.G ) ){ retorno_char[ index ] += 'g' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.H ) ){ retorno_char[ index ] += 'h' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.I ) ){ retorno_char[ index ] += 'i' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.J ) ){ retorno_char[ index ] += 'j' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.K ) ){ retorno_char[ index ] += 'k' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.L ) ){ retorno_char[ index ] += 'l' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.M ) ){ retorno_char[ index ] += 'm' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.N ) ){ retorno_char[ index ] += 'n' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.O ) ){ retorno_char[ index ] += 'o' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.P ) ){ retorno_char[ index ] += 'p' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Q ) ){ retorno_char[ index ] += 'q' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.R ) ){ retorno_char[ index ] += 'r' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.S ) ){ retorno_char[ index ] += 's' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.T ) ){ retorno_char[ index ] += 't' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.U ) ){ retorno_char[ index ] += 'u' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.V ) ){ retorno_char[ index ] += 'v' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.W ) ){ retorno_char[ index ] += 'w' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.X ) ){ retorno_char[ index ] += 'x' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Y ) ){ retorno_char[ index ] += 'y' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Z ) ){ retorno_char[ index ] += 'z' ; index++ ; }

                        if( Input.GetKeyDown( KeyCode.Alpha0 ) || Input.GetKeyDown( KeyCode.Keypad0 )  ){ retorno_char[ index ] += '0' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Alpha1 ) || Input.GetKeyDown( KeyCode.Keypad1 )  ){ retorno_char[ index ] += '1' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Alpha2 ) || Input.GetKeyDown( KeyCode.Keypad2 )  ){ retorno_char[ index ] += '2' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Alpha3 ) || Input.GetKeyDown( KeyCode.Keypad3 )  ){ retorno_char[ index ] += '3' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Alpha4 ) || Input.GetKeyDown( KeyCode.Keypad4 )  ){ retorno_char[ index ] += '4' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Alpha5 ) || Input.GetKeyDown( KeyCode.Keypad5 )  ){ retorno_char[ index ] += '5' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Alpha6 ) || Input.GetKeyDown( KeyCode.Keypad6 )  ){ retorno_char[ index ] += '6' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Alpha7 ) || Input.GetKeyDown( KeyCode.Keypad7 )  ){ retorno_char[ index ] += '7' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Alpha8 ) || Input.GetKeyDown( KeyCode.Keypad8 )  ){ retorno_char[ index ] += '8' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Alpha9 ) || Input.GetKeyDown( KeyCode.Keypad9 )  ){ retorno_char[ index ] += '9' ; index++ ; }

                        if( Input.GetKeyDown( KeyCode.Minus ) ||  Input.GetKeyDown( KeyCode.KeypadMinus ) ){ retorno_char[ index ] += '-' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.KeypadPlus )  ){ retorno_char[ index ] += '+' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.KeypadMultiply )  ){ retorno_char[ index ] += '*' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.KeypadDivide )  ){ retorno_char[ index ] += '/' ; index++ ; }
                        
                        if( Input.GetKeyDown( KeyCode.Equals ) || Input.GetKeyDown( KeyCode.KeypadEquals )  ){ retorno_char[ index ] += '=' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Comma ) ){ retorno_char[ index ] += ',' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Period ) || Input.GetKeyDown( KeyCode.KeypadPeriod ) ){ retorno_char[ index ] += '.' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Period ) ){ retorno_char[ index ] += ';' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Slash ) ){ retorno_char[ index ] += '/' ; index++ ; }



                        if( Input.GetKeyDown( KeyCode.RightBracket )  ){ retorno_char[ index ] += ']' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.LeftBracket )  ){ retorno_char[ index ] += '[' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Quote )  ){ retorno_char[ index ] += '\'' ; index++ ; }
                        if( Input.GetKeyDown( KeyCode.Backslash )  ){ retorno_char[ index ] += '\\' ; index++ ; }
                        


                }



                ret.keys = retorno_char;
                ret.length = index;


            return ret;
            
        

    }



    

}
