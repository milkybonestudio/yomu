using System;
using System.IO;
using UnityEngine;

public static class CONSTRUCTOR__paths_system {

        
        public static void Construct(){


                // --- GET MAIN PATHS

                    Paths_system.path_folder__static_data = Path.Combine( Application.dataPath, "Static_data" ); // Paths_development.path_folder__development_folder_for_simulations_STATIC_DATA; // images container, scripts etc in the game folder in build
                    Paths_system.path_folder__dinamic_data = Application.persistentDataPath ; //Paths_development.path_folder__development_folder_for_simulations_DINAMIC_DATA; // saves and user data etc in the persistent data folder in build
                    

                    #if UNITY_EDITOR

                        // ** os dados dinamicos vao ser mais usados e criados na hora do que os estaticos
                        // ** usar a logica de Arrumar_para_o_sistema() => usar() tem um custo inicial muito grande com o retorno de não colocar logica em paralelo 
                        /*

                            (  ------------------------------- arrumar() ---------------------------- ) ( --- usar() --- )


                            ( --------- usar_build()  ------- )
                            ( --- usar_editor() --- )

                            ( --------- usar_build()  ------- )( --- usar_editor() --- )
                        
                        
                        */

                        // ** mas o arrumar vai colocar muito mais complexidade em ajustar os dados corretamente do que vai ajudar 
                        // ** alem disso eu posso fazer depois exatamente como vai funcionar depois, por hora pode só pegar a imagem pelo path 
                        // ** a logica depois vai ser Get_localizer( path ) => Load_stream( localizer ) => byte[] dados
                        // ** e a logica por hora pode ser ReadAllBytes( path ) => byte[] dados
                        // ** continua sendo fn_fechada( path ) => dados

                        // ** os dados estaticos de logica( scripts ) não vão ser complicados, mas imagens nao vale a pena complicar muito o processo. 


                        // --- TROCA PARA OS FOLDERS DE SIMULACAO
                        Paths_system.path_folder__static_data = Paths_development.path_folder__development_folder_for_simulations_STATIC_DATA; // images container, scripts etc in the game folder in build
                        Paths_system.path_folder__dinamic_data = Paths_development.path_folder__development_folder_for_simulations_DINAMIC_DATA; // saves and user data etc in the persistent data folder in build

                    #endif
                        
                // --- STATIC DATA

                    Paths_system.path_folder__images_containers = Path.Combine( Paths_system.path_folder__static_data, "Images_containers" );
                    Paths_system.path_folder__save_default = Path.Combine( Paths_system.path_folder__static_data,  "Save_default" ); 

                        
                // --- DINAMIC DATA

                    // --- USER DATA 

                        Paths_system.path_folder__user_data = Path.Combine( Paths_system.path_folder__dinamic_data,  "User_data" );

                                Paths_system.path_arquivo_configuracoes = Path.Combine( Paths_system.path_folder__user_data, "configuracoes.dat" ); // vai ter somente as configuracoes, coisas que o player podemo mudar
                                Paths_system.path_arquivo_resumo_persona_usuario = Path.Combine( Paths_system.path_folder__user_data, "persona_usuario.dat" ); // vai ter os dados com as tendencias do usuario. Nao vai ser dependente do save, vai ser do usuario como um todo
                                Paths_system.path_arquivo_dados_menu_E_login_dados = Path.Combine( Paths_system.path_folder__user_data, "menu_E_login_dados.dat" ); // Tem os dados atuais do menu e login. tem quais personagens estao liberados, qual as imagens atuais, quais estão disponiveis.. etc


                    // --- SAVES DATA                            
                        Paths_system.path_folder__saves = Path.Combine( Paths_system.path_folder__dinamic_data,  "Saves" );

                    // --- SYSTEM DATA                            
                
                        Paths_system.path_folder__system = Path.Combine( Paths_system.path_folder__dinamic_data,  "System" );

                            Paths_system.path_arquivo__stack = Path.Combine( Paths_system.path_folder__system, "stack.dat" );
                        

                                
                // --- DADOS ESTATICOS


                // --- USO GERAL

                        // --- DISPOSITIVOS

                                Paths_system.path_folder__imagens_devices = Path.Combine( Application.dataPath, "Resources", "Images", "Geraneral_uses", "Devices" );
                                Paths_system.path_folder__imagens_dispositivos_reutilizaveis = Path.Combine( Application.dataPath, "Resources", "Images", "Reutilizaveis" );


                return;

        }

        private static string Pegar_path_dados_dinamicos_dll( string _dll_nome, string _path_folder_dlls_dados_dinamicos ){

                #if UNITY_EDITOR
                        return null;
                #endif

                string path =  Path.Combine( _path_folder_dlls_dados_dinamicos, _dll_nome );
                path = Path.ChangeExtension( path, ".dll"  );

                if( !!!( System.IO.File.Exists( path ) ) )
                        { throw new Exception( $"Nao foi achado a dll" ); }

                return path;

        }




}