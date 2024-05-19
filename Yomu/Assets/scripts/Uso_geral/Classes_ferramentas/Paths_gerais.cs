using System;
using UnityEngine;


    public static class Paths_gerais {







            public static string Pegar_path_folder_dados_save( int _save ){

                    
                    #if UNITY_EDITOR

                        // aqui é onde os dados de teste vao estar salvos.
                        // provavelmente vai ter varios saves diferentes, poderia ter um enum com oque cada save significa
                        //          Assets
                        return Application.dataPath + "/Editor/Dados_saves_para_teste/" + _save.ToString() + "/Personagens";


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


            public string Pegar_path_folder_com_os_saves_defaults() {


                throw new Exception( "ainda nao fiz" );
                
                #if UNITY_EDITOR 

                         // assets 
                    return Application.dataPath  + "/Editor";


                #endif



            }

        #if UNITY_EDITOR

                // se algum codigo pedir aqui na builda vai dar erro 

                public static string Pegar_path_folder_dados_producao(){

                    return Application.dataPath + "/Editor/Dados_producao";

                }


        #endif





    }