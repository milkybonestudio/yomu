

using UnityEngine;

unsafe public partial class Test {

    public void Teste_transicao_program_mode(){

            // ** nucna vai ser assim, testes precisam ter um proposito

            if( Input.GetKeyDown( KeyCode.B ) )
                { 
                    
                    PROGRAM_DATA__login* login_data = Controllers_program.data.modes.Lock_data__LOGIN();
                            // ** use 
            
                    Controllers_program.program_transition.Switch_program_mode( Program_mode.login, new Transition_program_data() );
                }


            if( Input.GetKeyDown( KeyCode.N ) )
                { 
                    PROGRAM_DATA__menu* menu_data = Controllers_program.data.modes.Lock_data__MENU();
                    Controllers_program.program_transition.Switch_program_mode( Program_mode.menu, new Transition_program_data() ); 
                }


            if( Input.GetKeyDown( KeyCode.M ) )
                { 

                    PROGRAM_DATA__game* game_data = Controllers_program.data.modes.Lock_data__GAME();

                    Controllers_program.program_transition.Switch_program_mode( Program_mode.game, new Transition_program_data() ); 
                }

    }

}