using System;
using System.Reflection;
using UnityEngine;


public class Dados_personagens_dinamicos {


        /*

            usando Assembly.LoadFrom() ele nao carrega a dll inteira, somente a classe/ function em uso. 

        
        */



        


        public static Dados_personagens_dinamicos instancia;
        public static Dados_personagens_dinamicos Pegar_instancia(){ return instancia; }



        public Dados_personagens_dinamicos(){ 

                

                #if UNITY_EDITOR

                        // o editor consegue pegar eles normalmente
                        asm_personagens = Assembly.Load( "Personagens_run_time" );

                #endif

                #if !UNITY_EDITOR

                        asm_personagens = Assembly.LoadFrom( Application.dataPath + "/Run_time_dados/Personagens_run_time.dll" );

                #endif

            
        }


        public Assembly asm_personagens;
        




        public int[] personagens_ids = new int[ 50 ];
        public Chave_cache[] chaves_personagens = new Chave_cache[ 50 ];
        public Task_req[] requisicoes_personagens = new Task_req[ 50 ];
        
        // public System.Object[] personagens = new System.Object[ 50 ];

        public int[] cidades_ids = new int[ 50 ];
        public Chave_cache[] chaves_cidades = new Chave_cache[ 50 ];
        // public System.Object[] cidades = new System.Object[ 50 ];




        public System.Object Pegar_personagem( int _personagem_id ){

                for( int index = 0 ; index < personagens_ids.Length ;  index++){
                        if( personagens_ids[ index ] == _personagem_id )
                                {
                                        Chave_cache chave = chaves_personagens[ index ];

                                        System.Object personagem_para_verificar =  Controlador_cache.Pegar_instancia().Pegar_dados( chave );
                                        if( personagem_para_verificar == null )
                                                {       
                                                        // nao nao conseguiu pegar na multithread

                                                        Task_req req = requisicoes_personagens[ index ];

                                                        req.pode_executar = false;
                                                        req.fn_iniciar( req );
                                                        req.fn_finalizar( req );
                                                        




                                                }
                                        
                                }


                }
                

        }





        public void Carregar_dados_personagem( int personagem_id ){

        
                

                // sempre assume que ele nao foi carregado 
                if ( _personagem.dados_personagem_run_time != null ){

                        for( int index_personagem_para_verificar = 0 ; index_personagem_para_verificar < personagens_ids.Length ; index_personagem_para_verificar++ ){

                                if( personagens_ids[ index_personagem_para_verificar ] == _personagens_id )
                                        {  return;  }

                        }

                }

                Chave_cache chave = Controlador_cache.Pegar_instancia().Pedir_slot();
                Adicionar_personagem(  personagem chave )

                Task_req task = new Task_req( chave , ( "pegar_personagem " + ( ( Personagem_nome ) personagem_id ).ToString() )  );


                task.fn_iniciar = ( Task_req _req ) => {


                        string personagem_metodo_nome =  _personagem.nome.ToString() + "_dados";
                        // a principio vai carregar tudo que pode ser necessario para o personagem 
                        System.Object personagem_objeto_generico =  asm_personagens.CreateInstance( personagem_metodo_nome );
                        _req.dados = personagem_objeto_generico;
                        return;

                };


                task.fn_finalizar = ( Task_req _req ) => {


                        if( _req.dados == null ){

                                Debug.LogError( $"nao foi achado persoangem { _personagem.nome.ToString() } nos dados run time" );
                                throw new Exception();

                        }

                };

                                                

                _personagem.dados_personagem_run_time = personagem_objeto_generico;

                MethodInfo metodo_info = asm_personagens.GetType( personagem_metodo_nome ).GetMethod("Pegar_dados");

                // opcao 1 => entregar Personagem e o metodo coloca actions e delegados 
                // opcao 2 => o metodo devolve um objeto que tem os delegados e action
                
                metodo_info.Invoke(   personagem_objeto_generico , new System.Object[]{ _personagem }  );

                return;


        }


        public void Adicionar_personagem( int _personagem_id , Chave_cache _cache ){


                for( int index_teste = 0 ; index_teste < personagens.Length ; index_teste++  ){

                        if( personagens_ids[ index_teste ] == 0 )
                                {
                                        personagens[ index_teste ] = _personagem_id ;
                                        personagens_ids[ index_teste ] = _obj ;
                                        return;
                                        
                                }

                }

                // tem que aumentar

                int index = personagens.Length;

                System.Object[] novo_obj_arr = new System.Object[ personagens.Length + 10 ];
                int[] novo_ids_arr = new int[ personagens.Length + 10 ];

                for( int index_novo_arr = 0 ; index_novo_arr < personagens.Length ; index_novo_arr++ ){

                        novo_obj_arr[ index_novo_arr ] = personagens[ index_novo_arr ];
                        novo_ids_arr[ index_novo_arr ] = personagens_ids[ index_novo_arr ];
                        

                }

                personagens = novo_obj_arr;
                personagens_ids = novo_ids_arr;

                personagens[ index ] = _obj;
                personagens_ids[ index ] = _personagem_id;

                return;

        }

        public void Remover_personagem ( int _personagem_id ){


                for( int index_teste = 0 ; index_teste < personagens.Length ; index_teste++  ){

                        if( personagens_ids[ index_teste ] == 0 )
                                {
                                        personagens[ index_teste ] = _personagem_id ;
                                        personagens_ids[ index_teste ] = _obj ;
                                        return;
                                        
                                }

                }

                // tem que aumentar

                int index = personagens.Length;

                System.Object[] novo_obj_arr = new System.Object[ personagens.Length + 10 ];
                int[] novo_ids_arr = new int[ personagens.Length + 10 ];

                for( int index_novo_arr = 0 ; index_novo_arr < personagens.Length ; index_novo_arr++ ){

                        novo_obj_arr[ index_novo_arr ] = personagens[ index_novo_arr ];
                        novo_ids_arr[ index_novo_arr ] = personagens_ids[ index_novo_arr ];
                        

                }

                personagens = novo_obj_arr;
                personagens_ids = novo_ids_arr;

                personagens[ index ] = _obj;
                personagens_ids[ index ] = _personagem_id;

                return;

        }




               




}