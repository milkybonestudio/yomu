using System;

public unsafe static class CONSTRUCTOR__controller_traders {


        public static CONTROLLER__traders Construct( Game_current_state* _game_current_state ){

                #if UNITY_EDITOR

                    return Construct_EDITOR();

                #endif



        }


        public static CONTROLLER__traders Construct_EDITOR(){

                CONTROLLER__traders construtor = new CONTROLLER__traders();
                CONTROLLER__traders.instance = construtor;


                    construtor.Put_data_managers( 
                                                    _container_entities: new CONTAINER__entities<Trader>( -1 ),  // ** ver depois,
                                                    _manager_save_data: new ENTITIES__manager_save_EDITOR_data(), 
                                                    _run_time_saver: new ENTITIES__run_time_saver_EDITOR(),
                                                    _loader: new ENTITIES__loader_EDITOR()
                                                );

                    throw new Exception( "aind anao pode vir aqui porque eu nao defini como pegar os dados do save ainda " );
                    
                return construtor;




        }




}