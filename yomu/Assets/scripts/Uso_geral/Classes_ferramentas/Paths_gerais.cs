using System;
using UnityEngine;


    public static class Paths_gerais {



            public static string Pegar_path_dados_dlls(){

                #if UNITY_EDITOR
                
                    // nao pode pegar pelo path
                    return null;

                #endif

                return System.IO.Path.Combine( Application.dataPath , "Dados_run_time" );

            }



            public static string Pegar_path_folder_dados_usuario(){

                #if UNITY_EDITOR

                    return System.IO.Path.Combine( Application.dataPath , "Editor/Folder_dados_teste", "Dados_usuario" );
                    
                #endif

                throw new Exception();

                return System.IO.Path.Combine( Application.persistentDataPath , "Dados_usuario" );


            }



            public static string Pegar_path_folder_dados_save( int _save ){

                    
                    #if UNITY_EDITOR
                        return System.IO.Path.Combine( Application.dataPath , "Editor/Folder_dados_teste", $"save_{ _save.ToString() }" );
                    #endif

                    throw new Exception();
                    return System.IO.Path.Combine( Application.persistentDataPath ,  $"save_{ _save.ToString() }" );

                
            }

            public static string Pegar_path_folder_dados_estaticos(){

                    
                    #if UNITY_EDITOR

                        // nao vai chamar no editor

                        return System.IO.Path.Combine( Application.dataPath , "Editor/Folder_dados_teste", "Dados_estaticos" );


                    #endif

                    throw new Exception();

                    // vai vir aqui para o jogo normal
                    return System.IO.Path.Combine( Application.dataPath ,  "Dados_estaticos" );

            
            }







            public static string Pegar_path_imagens_DESENVOLVIMENTO(){

                    string path_folder_jogo = System.IO.Directory.GetCurrentDirectory();


                    string pai = System.IO.Directory.GetParent( path_folder_jogo ).FullName;

                    string retorno = pai + System.IO.Path.Combine( pai, "Imagens" );

                    if( ! ( System.IO.Directory.Exists( retorno ) ) )
                        { throw new Exception( $" path para imagens nao foi encontrado, path: { retorno } " ); }

                    return retorno;

            }

            public static string Pegar_path_imagens_personagens_DESENVOLVIMENTO(){

                    string path_imagens = Pegar_path_imagens_DESENVOLVIMENTO();
                    string path_personagens = System.IO.Path.Combine( path_imagens , "Personagens" );
                    return path_personagens;

            }

            public static string Pegar_path_imagens_interativos_DESENVOLVIMENTO(){

                    string path_imagens = Pegar_path_imagens_DESENVOLVIMENTO();
                    string path_personagens = System.IO.Path.Combine( path_imagens , "Interativos" );
                    return path_personagens;

            }



            public static string Pegar_path_folder_dados_save_default(){

                    // aqui vai voltar o folder que tem os dados para carregar 

                    #if UNITY_EDITOR

                        // esses dados vao ser os dados usados na versao final 
                        return Application.dataPath + "/Editor/Dados_saves_default";

                    #else
                        // o jogo deve salvar uma copia aqui dos dados default
                        // o folder_morte também vai estar aqui
                        return Application.streamingAssetsPath + "save_default/personagens";

                    #endif



            }


            public static string Pegar_path_folder_com_os_saves_defaults() {


                throw new Exception( "ainda nao fiz" );
                
                #if UNITY_EDITOR 

                         // assets 
                    return Application.dataPath  + "/Editor";


                #endif



            }


            public static string Pegar_path_folder_usuario(){


                #if UNITY_EDITOR

                    return Application.dataPath + "/Resources/files";

                #endif


                return Application.persistentDataPath + "/user_info";

            }




        // SOMENTE PRODUCAO
        // se algum codigo pedir aqui na builda vai dar erro 

        #if UNITY_EDITOR


                public static string Pegar_path_folder_dados_producao(){

                    return Application.dataPath + "/Editor/Dados_producao";

                }


        #endif





    }