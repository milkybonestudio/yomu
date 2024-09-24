using System;
using System.Reflection;
using UnityEngine;


/*

    quem precisa disso? 
    
    fn finaliza e coisas faz sentido
    mas em coisas muito especificas como entidades pode nao fazer muito sentido
    talvez deixar esse ob direto no personagem?
    essa classe foi criada em mente como se a dll fosse managed e fosse facilmente explit. agora tem que pensar de um novo jeito

    // ** nao faz sentido porque quando for plugin os pontos de entrada precisam usar static extend. entao essa funcoes precisam existir em uma classe no main 

*/


public class MODULO__leitor_dll {

        

        private struct Dados {

                public string nomes_classes;
                public int localizadores_ids;
                public object objetos;
                public Task_req requisicoes;

        }


        public MODULO__leitor_dll(  string _nome_dll, int _numero_inicial_de_slots ){ 

                nome_dll = _nome_dll;
                dados = new Dados[ _numero_inicial_de_slots ];
                
                #if UNITY_EDITOR

                        // o editor consegue pegar eles normalmente
                        asm = Assembly.Load( nome_dll );

                        if( asm == null )
                            { throw new Exception( $"nao foi achado a dll: { nome_dll }" ); }

                #else
                        string path = System.IO.Path.Combine( Paths_sistema.path_dlls_dados_dinamicos, nome_dll );
                        asm = Assembly.LoadFrom( path );
                        if( asm == null )
                            { throw new Exception( $"nao foi achado a dll: { nome_dll }" ); }

                #endif


                return;

        }

        public string nome_dll;
        
        public Assembly asm;
        
        private Dados[] dados;



        // ** metodo retorno o obj
        public object Criar_objeto( string _classe, object[] _args ){ 

        
                Type tipo = asm.GetType( _classe );
                if( tipo == null )
                    { throw new Exception( $"nao achou a classe { _classe }" ); }
                
            
                object objeto =  asm.CreateInstance( 

                        typeName: _classe, 
                        ignoreCase: false,
                        bindingAttr : System.Reflection.BindingFlags.CreateInstance, 
                        binder: null, 
                        args: _args, 
                        culture: null, 
                        activationAttributes: null
                );

                if( objeto == null )
                    { throw new Exception( $"nao conseguiu criar o objeto { _classe }"); }
                    

                return objeto;

            
        }


        // ** metodo retorno o obj
        public object Pegar_objeto( string _classe, string _metodo, object[] _args ){ 

        
                Type tipo = asm.GetType( _classe );
                if( tipo == null )
                    { throw new Exception( $"nao achou a classe { _classe }" ); }
                

                MethodInfo metodo_info  = tipo.GetMethod( _metodo );
                if( metodo_info == null )
                    { throw new Exception( $"nao achou o metodo { _metodo }" ); }
                    

                return metodo_info.Invoke(   null , _args  );

            
        }

        public void Invoke_method( string _classe, string _metodo, object[] _args ){

                        
                Type tipo = asm.GetType( _classe );
                if( tipo == null )
                    { throw new Exception( $"nao achou a classe { _classe }" ); }
                

                MethodInfo metodo_info  = tipo.GetMethod( _metodo );
                if( metodo_info == null )
                    { throw new Exception( $"nao achou o metodo { _metodo }" ); }
                    

                metodo_info.Invoke(   null , _args  );

                return;

        }

        

        public object Pegar_objeto  ( int slot_index ){

                // sempre tem que carregar primeiro. Em teste carrega primeiro para colocar o path e logo em sequencia já pega 

                object objeto =  dados[ slot_index ].objetos;
                

                // --- VERIFICA SE O OBJETO FOI CARREGADO
                if( objeto != null )
                        {  return objeto ;} // --- DEVOLVE OBJETO


                // --- VAI FORCAR
                string classe_nome =  dados[ slot_index ].nomes_classes;
                objeto =  asm.CreateInstance( classe_nome);

                if( objeto == null )
                        {  throw new Exception( $"tentou criar um objeto com a classe { classe_nome } mas veio null a instancia" ) ;}


                dados[ slot_index ].objetos = objeto;

                return objeto;

        }



        public Task_req Carregar_objeto_NA_MULTITHREAD( string _nome_classe ){

                
                Task_req task = new Task_req(  ( "pegar_objeto" + nome_dll + "_dll" ) );
                


                task.fn_multithread = ( Task_req _req ) => {
                                                                // --- CARREGA AI
                                                        
                                                                object AI =  asm.CreateInstance( _nome_classe );
                                                                task.dados = new object[]{ AI };
                                                                
                                                                return;

                                                        };

                task.fn_forcar_finalizar = ( Task_req _req ) => {
                                                                    object AI =  asm.CreateInstance( _nome_classe );
                                                                    _req.dados = new object[]{ AI };

                                                                    return;

                                                                };


                CONTROLLER__tasks.Pegar_instancia().Adicionar_task( task );

                return task;


        }






}