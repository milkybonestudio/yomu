using System;
using UnityEngine;



public class MODULO__input_GAME_PAD : Input_device {


        public string nome_modulo = "MODULO__input_game_pad";
        

        public KeyCode[] bind_atual;

        public bool[] acoes_bloqueadas;

        
        public float[] axis_values = new float[ 4 ];
        public State_key[] axis_state = new State_key[ 4 ];



        public bool Get_action( int _acao ){ 

            KeyCode key = Pegar_tecla_final( _acao ); 

            switch( key ){

                case KeyCode.UpArrow: return ( axis_state[ ( int ) Input_axis_indexes.right_analog_up ] == State_key.press );
                case KeyCode.DownArrow: return ( axis_state[ ( int ) Input_axis_indexes.right_analog_down ] == State_key.press );
                case KeyCode.LeftArrow: return ( axis_state[ ( int ) Input_axis_indexes.right_analog_left ] == State_key.press );
                case KeyCode.RightArrow: return ( axis_state[ ( int ) Input_axis_indexes.right_analog_right ] == State_key.press );
                
            }

            return Input.GetKey( key );
            
        }


        public void Ativar_leitura_teclado(){

            // ** criar teclado virtual e lock do game_pad

        }
        public void desativar_leitura_teclado(){

            // ** destruir teclado e deslockar

        }


        //** precisa ativar o teclado
        public char[] Pegar_teclas(){

                return null;

        }




        public override void Update(){


                // ** tem que garantir que os axis estejam
                float left_analog_horizontal = Input.GetAxis( "Left_analog Horizontal" );
                float right_analog_horizontal = Input.GetAxis( "Right_analog Horizontal" );

                
                float left_analog_vertical = Input.GetAxis( "Left_analog Vertical" );
                float right_analog_vertical = Input.GetAxis( "Right_analog Vertical" );

                // Controlador_configuracoes.Pegar valor sensibilidade

                float sensibilidade = 0.95f;

                // --- SETA RIGHT ANALOG
                axis_values[ ( int ) Input_axis_indexes.right_analog_up ] = Ajustar_axis_POSITIVO( right_analog_vertical );
                axis_values[ ( int ) Input_axis_indexes.right_analog_down ] = Ajustar_axis_NEGATIVO( right_analog_vertical ) ;
                axis_values[ ( int ) Input_axis_indexes.right_analog_right ] = Ajustar_axis_POSITIVO( right_analog_horizontal );
                axis_values[ ( int ) Input_axis_indexes.right_analog_left ] = Ajustar_axis_NEGATIVO( right_analog_horizontal ) ;

                // --- SETA LEFT ANALOG
                axis_values[ ( int ) Input_axis_indexes.left_analog_up ] = Ajustar_axis_POSITIVO( left_analog_vertical );
                axis_values[ ( int ) Input_axis_indexes.left_analog_down ] = Ajustar_axis_NEGATIVO( left_analog_vertical ) ;
                axis_values[ ( int ) Input_axis_indexes.left_analog_right ] = Ajustar_axis_POSITIVO( left_analog_horizontal );
                axis_values[ ( int ) Input_axis_indexes.left_analog_left ] = Ajustar_axis_NEGATIVO( left_analog_horizontal ) ;



                // --- MUDA STATE

                //** right
                axis_state[ ( int ) Input_axis_indexes.right_analog_up ] = Pegar_estado( axis_state[ ( int ) Input_axis_indexes.right_analog_up ], axis_values[ ( int ) Input_axis_indexes.right_analog_up ], sensibilidade );
                axis_state[ ( int ) Input_axis_indexes.right_analog_down ] = Pegar_estado( axis_state[ ( int ) Input_axis_indexes.right_analog_down ], axis_values[ ( int ) Input_axis_indexes.right_analog_down ], sensibilidade );
                axis_state[ ( int ) Input_axis_indexes.right_analog_right ] = Pegar_estado( axis_state[ ( int ) Input_axis_indexes.right_analog_right ], axis_values[ ( int ) Input_axis_indexes.right_analog_right ], sensibilidade );
                axis_state[ ( int ) Input_axis_indexes.right_analog_left ] = Pegar_estado( axis_state[ ( int ) Input_axis_indexes.right_analog_left ], axis_values[ ( int ) Input_axis_indexes.right_analog_left ], sensibilidade );


                //** left
                axis_state[ ( int ) Input_axis_indexes.left_analog_up ] = Pegar_estado( axis_state[ ( int ) Input_axis_indexes.left_analog_up ], axis_values[ ( int ) Input_axis_indexes.left_analog_up ], sensibilidade );
                axis_state[ ( int ) Input_axis_indexes.left_analog_down ] = Pegar_estado( axis_state[ ( int ) Input_axis_indexes.left_analog_down ], axis_values[ ( int ) Input_axis_indexes.left_analog_down ], sensibilidade );
                axis_state[ ( int ) Input_axis_indexes.left_analog_right ] = Pegar_estado( axis_state[ ( int ) Input_axis_indexes.left_analog_right ], axis_values[ ( int ) Input_axis_indexes.left_analog_right ], sensibilidade );
                axis_state[ ( int ) Input_axis_indexes.left_analog_left ] = Pegar_estado( axis_state[ ( int ) Input_axis_indexes.left_analog_left ], axis_values[ ( int ) Input_axis_indexes.left_analog_left ], sensibilidade );

                return;




        }

        private State_key Pegar_estado( State_key _estado_antigo, float _valor, float _sensibilidade ){

                switch( _estado_antigo ){

                        case State_key.up: return State_key.off;
                        case State_key.down: return State_key.press;
                        case State_key.press: if( _valor < _sensibilidade ){ return State_key.up; } return State_key.press;
                        case State_key.off : if( _valor > _sensibilidade ){ return State_key.down; } return State_key.off;
                        default : return State_key.off;

                }

        }


        private float Ajustar_axis_POSITIVO( float _valor ){

                if( _valor < 0f )
                    { return 0f; }
                    
                return _valor;

        }


        private float Ajustar_axis_NEGATIVO( float _valor ){

                if( _valor > 0f )
                    { return 0f; }

                return _valor * -1f;

        }



        private KeyCode Pegar_tecla_final( int _acao ){

            if( acoes_bloqueadas[ _acao ] )
                { return KeyCode.None; }

            return bind_atual[  _acao ];

        }
    



}