using System;
using System.Collections;
using System.Threading;
using UnityEngine;


public struct Teste_development {

    public Program_mode program_mode;
    public Game_node node; // if game

}





unsafe public class CONTROLLER__development {

        //mark
        // ** WILL BE CALLED BY REFLECTION


        public static CONTROLLER__development instancia;
        public static CONTROLLER__development Pegar_instancia(){ return instancia; }
        
        public CONTROLLER__development(){ instancia = this; program = Program.instancia; }

    
        // --- FERRAMENTAS 

        public bool bloqueado_por_ferramenta = false;
        public Ferramenta_desenvolvimento ferramenta_atual = Ferramenta_desenvolvimento.nada;
        

        public NODE_DEVELOPEMENT_TOOLs[,] tools = new NODE_DEVELOPEMENT_TOOLs[ ( int ) Block_type.END, 10 ];

        public Program program;

        public GameObject tools_game_object;

        //  --- MODO TESTE ATUAL

        public Desenvolvimento_atual desenvolvimento_atual = Desenvolvimento_atual.interacao;

        public Teste_development teste_development_atual = new Teste_development(); // => nada
        public string chave_teste = "generico";


        public static Test_development current_test;


        public static void Apply_development_modifications_end(){ instancia._Apply_development_modifications_end(); }
        public static void Apply_development_modifications_start(){ instancia._Apply_development_modifications_start(); }
        public static Action<Control_flow> Get_update(){ return Update; }
        public static void Update( Control_flow _flow ){ if( current_test != null ){ current_test.Update( _flow ); }  instancia._Update( _flow ); }




        private void _Apply_development_modifications_start(){

                // ** USADO PARA MODIFICAR ARQUIVOS 
                // ** pode gerar conflito com streams se não fizer antes, nenhum constroller esta ativo

                if( Development_tests.reset_folders_persistent_data_path )
                    {
                        if( System.IO.Directory.Exists( Paths_system.persistent_data_path ) )
                            { 

                                System.IO.Directory.Delete( Paths_folders.program, true ); 
                                System.IO.Directory.Delete( Paths_folders.saves, true ); 
                            }
                            
                        System.IO.Directory.CreateDirectory( Paths_system.persistent_data_path );

                        TOOL__folders_constructor.Construct_new_persistent_data_path();
                    }


        }

        private void _Apply_development_modifications_end(){


                //mark
                // ** I can not delete if the data have the stream
                // ** stack.dat agora fica fora do folder program




                // ** vai ser chamado sempre no editor


                if( Development_tests.program_mode == Program_mode.test )
                    { 
                        //mark
                        // ** não é o caminho correto mas não vai dar problemas

                        Controllers_program.data.program_data->program_mode_lock = Program_mode.test;
                        Controllers_program.program_transition.Switch_program_mode( Development_tests.program_mode, new Transition_program_data() ); 
                        return; 
                    }


                if( Development_tests.use_generic )
                    {
                        current_test = new Generic_test();
                    }
                    else
                    {

                        // ** TESTS                
                        switch( Development_tests.program_mode ){
                            
                            case Program_mode.game: current_test = Tests_development__GAME.Get_test( Development_tests.block_type, Development_tests.game_test_key ); break;
                            case Program_mode.login: current_test = Tests_development__LOGIN.Get_test( Development_tests.login_test_key ); break;
                            case Program_mode.menu: current_test = Tests_development__MENU.Get_test( Development_tests.login_test_key ); break;
                            default: CONTROLLER__errors.Throw( $"Can not handle Program_mode: <Color=lightBlue>{ Development_tests.program_mode }</Color>" ); break;
                            
                        }

                    }


                if( current_test == null )
                    { CONTROLLER__errors.Throw( $"Tried to get the test for { Development_tests.program_mode } but return null" ); }


                Console.Log( "<Color=lightBlue>--Will start development test</Color>" );
                current_test.Set_program_environment();
                current_test.Create_state();
                current_test.Start();
                Console.Log( "<Color=lightBlue>-----------------</Color>" );


                
                

        }

          public void Iniciar_ferramentas(){

                    
                    // --- CRIA ESPACO
                    GameObject desenvolvimento_ferramentas = new GameObject( "desenvolvimento_ferramentas");
                    desenvolvimento_ferramentas.transform.SetParent( GameObject.Find( "Tela" ).transform , false );
                    // ** se tiver ferramentas especificas colocar aqui
                    return;


          }


            public bool Aplicar_teste(){


                //mark
                // ver depois
                return false;
                // if( teste_development_atual.bloco == ( int ) Block_type.nada )
                //     { return false; }

                // --- VAI TESTAR
                Program.Pegar_instancia().current_mode = Program_mode.test;

                // --- SETA TUDO COMO DEFAULT
                //mark
                // ** tem que criar uma funcao em especifico
                //Controlador.Pegar_instancia().jogo = Construtor_jogo.Construir();
                
                // --- DESENVOLVIMENTO UTILIDADES
                Colocar_estado_teste();
                Iniciar_ferramentas();
                
                Console.Log( "veio em iniciar jogo teste" );
                Console.Log( $"modo atual: <b><color=white>{ desenvolvimento_atual }</color></b>" );

                return true;


          }



          public void Colocar_estado_teste(){

                    // Inicia o save zerado
                    // Quando o jogo for iniciado na build ele na realidade vai ler o estado do save default 
                    // no editor ele vai começar em um local "0" sem nenhum contexto
                    // se um teste especifico precisar de contexto como "mover player para POSICAO" => iniciar VN => "mover player dependendo de VN" 


                    // --- COLOCA DADOS DEFAULT

          
          }


        

        
        public void _Update( Control_flow _flow ){

                // ** simulacoes

                // ** make slower
                Simulate_others_pcs();


                // quando mais suporte Desenvolvimento dar ao desenvolvimento (uou) melhor 
                // o jeito mais eficiente vai ser criar ferramentas que podem ser criadas aqui para manipular, testar e ver dados com mais precisao 
                // as ferramentas vao estar em cada Teste_bloco

                Controlador_ferramentas.Atualizar_ferramentas_desenvolvimento();


                return;
            
        }
        


        int acc = 0;
        private void Simulate_others_pcs(){

            #if UNITY_EDITOR

                int times = 0;

                switch( Development_tests.level_machine ){

                    case Level_machine.max: times = 0; break;
                    case Level_machine.ok: times = 500_000; break; // 1ms
                    case Level_machine.mid: times = 1_000_000; break; // 2ms
                    case Level_machine.bad: times = 2_000_000; break; // 4ms
                    case Level_machine.potato: times = 3_000_000; break; // 6ms

                }

                // ** 500mil /s -> 500k/ms
                for( int time_to_lose = 0; time_to_lose < times ;time_to_lose++ )
                    { acc += time_to_lose % 3; }

            #endif



        }




}