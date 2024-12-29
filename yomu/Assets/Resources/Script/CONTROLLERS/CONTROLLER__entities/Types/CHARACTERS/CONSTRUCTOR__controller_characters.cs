using System;

public unsafe static class CONSTRUCTOR__controller_characters {


        public static CONTROLLER__characters Construct( Character[] _characters, Dados_sistema_estado_atual _dados_sistema_estado_atual ){

                #if UNITY_EDITOR

                    return Construct_EDITOR();

                #endif



        }


        public static CONTROLLER__characters Construct_EDITOR(){

                CONTROLLER__characters construtor = new CONTROLLER__characters();
                CONTROLLER__characters.instance = construtor;


                    construtor.Put_data_managers( 
                                                    _container_entities: new CONTAINER__entities<Character>( -1 ),  // ** ver depois,
                                                    _manager_save_data: new ENTITIES__manager_save_EDITOR_data(), 
                                                    _run_time_saver: new ENTITIES__run_time_saver_EDITOR(),
                                                    _loader: new ENTITIES__loader_EDITOR()
                                                );

                    throw new Exception( "aind anao pode vir aqui porque eu nao defini como pegar os dados do save ainda " );
                    
                return construtor;




        }




}