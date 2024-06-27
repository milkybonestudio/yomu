using System;
using UnityEngine;


    public static class Paths_gerais {





            public static string Pegar_path_imagens_DESENVOLVIMENTO(){

                string path_folder_jogo = System.IO.Directory.GetCurrentDirectory();


                string pai = System.IO.Directory.GetParent( path_folder_jogo ).FullName;

                string retorno = pai + System.IO.Path.Combine( pai, "imagens" );

                if( ! ( System.IO.Directory.Exists( retorno ) ) )
                    { throw new Exception( $" path para imagens nao foi encontrado, path: { retorno } " ); }

                return retorno;

            }


            public static string Pegar_path_folder_dados_save( int _save ){

                    
                    #if UNITY_EDITOR

                        // aqui é onde os dados de teste vao estar salvos.
                        // provavelmente vai ter varios saves diferentes, poderia ter um enum com oque cada save significa
                        //          Assets
                        // talvez path de problemas em outros OS? 
                        return Application.dataPath + "/Editor/Dados_saves_para_teste/save_" + _save.ToString() ;


                    #else

                        // vai vir aqui para o jogo normal
                        return Application.persistentDataPath + "/saves/save_" + _save.ToString() + "save_morte/personagens";

                    #endif

                
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