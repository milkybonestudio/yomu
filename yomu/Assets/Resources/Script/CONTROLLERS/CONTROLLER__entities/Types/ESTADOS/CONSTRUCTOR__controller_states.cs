using System;

public unsafe static class CONSTRUCTOR__controller_states {


        public static CONTROLLER__states Construct( Game_current_state* _game_current_state ){

                #if UNITY_EDITOR

                    return Construct_EDITOR();

                #endif



        }


        public static CONTROLLER__states Construct_EDITOR(){

                CONTROLLER__states construtor = new CONTROLLER__states();
                CONTROLLER__states.instance = construtor;


                    construtor.Put_data_managers( 
                                                    _container_entities: new CONTAINER__entities<State>( -1 ),  // ** ver depois,
                                                    _manager_save_data: new ENTITIES__manager_save_EDITOR_data(), 
                                                    _run_time_saver: new ENTITIES__run_time_saver_EDITOR(),
                                                    _loader: new ENTITIES__loader_EDITOR()
                                                );

                    throw new Exception( "aind anao pode vir aqui porque eu nao defini como pegar os dados do save ainda " );
                    
                return construtor;




        }




}