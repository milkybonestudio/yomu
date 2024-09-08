using System;
using UnityEngine;






// public class Mouse_options {

//     public Modelo_mouse modelo_mouse;
//     public float tamanho_mouse_px = 50f; 
//     public float mouse_speed;



// }


public class MODULO__input_keyboard_AND_mouse : INTERFACE__input_device {


        public string nome_modulo = "MODULO__input_keyboard_AND_mouse";
        

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


        public void Update(){

                // ** ponteiro
            

        }

        private KeyCode Pegar_tecla_final( int _acao ){

            if( acoes_bloqueadas[ _acao ] )
                { return KeyCode.None; }

            return bind_actions_TO_key_atual[  _acao ];

        }


    


    public static string Pegar_teclas_presionadas(){

            string retorno = "";
            int index = 0;
            char[] retorno_char = new char[ 10 ];


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
            if( Input.GetKeyDown( KeyCode.RightCurlyBracket )  ){ retorno_char[ index ] += '}' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.LeftCurlyBracket )  ){ retorno_char[ index ] += '{' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Pipe )  ){ retorno_char[ index ] += '|' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.RightBracket )  ){ retorno_char[ index ] += ']' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.LeftBracket )  ){ retorno_char[ index ] += '[' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Backslash )  ){ retorno_char[ index ] += '\\' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Underscore )  ){ retorno_char[ index ] += '_' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.DoubleQuote )  ){ retorno_char[ index ] += '"' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.DoubleQuote )  ){ retorno_char[ index ] += '"' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Asterisk )  ){ retorno_char[ index ] += '"' ; index++ ; }

    
        
        
            return new string( retorno_char );
            
        

    }



    

}