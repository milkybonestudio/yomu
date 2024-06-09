using System;
using UnityEngine;
using System.IO;


public class Controlador_instrucoes_de_seguranca {

                public static Controlador_instrucoes_de_seguranca instancia;
                public static Controlador_instrucoes_de_seguranca Pegar_instancia(){ return instancia; }

                public Controlador_instrucoes_de_seguranca(){

                        controlador_save = Controlador_save.Pegar_instancia();
                        path_instrucoes_de_seguranca_1 = controlador_save.path_save_folder + "/Dados_programa/instrucoes_de_seguranca_1.dat";
                        path_instrucoes_de_seguranca_2 = controlador_save.path_save_folder + "/Dados_programa/instrucoes_de_seguranca_2.dat";
                        

                
                        if( ! ( File.Exists( path_instrucoes_de_seguranca ) ) )
                                {  throw new Exception( "nao era para vir aqui" );  }
                                        
                        FileMode file_mode = FileMode.Open;
                        FileAccess file_accees = FileAccess.ReadWrite;
                        FileShare file_share = FileShare.Read;
                        FileOptions file_options = FileOptions.WriteThrough;
                
                        stream_instrucoes_de_seguranca_1 = new FileStream( path_instrucoes_de_seguranca_1, file_mode, file_accees , file_share, length_arquivo_instrucoes_de_seguranca , file_options );
                        stream_instrucoes_de_seguranca_2 = new FileStream( path_instrucoes_de_seguranca_2, file_mode, file_accees , file_share, length_arquivo_instrucoes_de_seguranca , file_options );

                }


                public Controlador_save controlador_save;

                public int index_byte_instrucoes_de_seguranca_1 = 0;
                public FileStream stream_instrucoes_de_seguranca_1;

                
                public int index_byte_instrucoes_de_seguranca_2 = 0;
                public FileStream stream_instrucoes_de_seguranca_2;


                int length_arquivo_instrucoes_de_seguranca = 500_000;
                int length_arquivo_segurancao = 0;

                string path_instrucoes_de_seguranca_1;
                string path_instrucoes_de_seguranca_2;

                public int arquivo_main = 0; // arquivo que vai ser colocados os aqrquivos novos 


                public void Update( Modo_save_atual _modo ){


                        // esse update sempre vai ser  chamado independete se o sistema esta salvando algo ou não 
                        Update_primario( _modo );
                        Update_secundario( _modo );


                }


                public void Update_primario( Modo_save_atual _modo ){

                        // --- PEGAR INSTRUCOES DE TODOS OS DADOS

                        // 0 => primario, 1 => priumario_2 , 1 => secundario_1, secundario_2
                        byte[][][] dados_personagens_seguranca = controlador_save.controlador_save_personagens.Compactar_intrucoes_de_seguranca( _modo );
                        byte[][][] dados_personagens_seguranca = controlador_save.controlador_save_personagens.Pegar_instrucoes_de_seguranca( _modo );

                        byte[][][] dados_cidades_seguranca = controlador_save.controlador_save_cidades.Pegar_instrucoes_de_seguranca( _modo );




                        //byte[] dados_woirld = controlador_save_world.Pegar_dados_em_espera();

                        int length_dados_para_adicionar = 0;

                        length_dados_para_adicionar += 2; // 1 no inicio e no final
                        length_dados_para_adicionar += 2; // length dos dados
                        length_dados_para_adicionar += dados_personagens_seguranca.Length; // length personagens



                        byte[] dados_para_adicionar = new byte[ length_dados_para_adicionar ];

                        // se byte[ length - 1 ] for 0 => nao foi salvo corretamente;
                        

                        dados_para_adicionar[ 0 ] = 1 ;
                        dados_para_adicionar[ 1 ] = ( byte ) ( length_dados_para_adicionar >> 8 ) ;
                        dados_para_adicionar[ 2 ] = ( byte ) ( length_dados_para_adicionar >> 0 ) ;
                        dados_para_adicionar[ ( dados_para_adicionar.Length - 1 ) ] = 1 ;

                        int index_acumulador = 3; // comeca realmente no 3

                        int index = 0;

                        for(  index = 0;  index < dados_personagens_seguranca.Length ; index++ ){

                                dados_para_adicionar[ index_acumulador +  index ] = dados_personagens_seguranca[ index ];

                        }

                        //length_arquivo_segurancao += 
                        index_byte_instrucoes_de_seguranca_1 += dados_personagens_seguranca.Length;
                        stream_instrucoes_de_seguranca_1.Write( dados_personagens_seguranca, 0, dados_personagens_seguranca.Length );
                        stream_instrucoes_de_seguranca_1.Flush();

                }


                public void Update_secundario(){

                }





            public void Verificar_arquivo_das_instrucoes_de_seguranca(){


                    int numero_inicial_seguranca = stream_instrucoes_de_seguranca_1.ReadByte();
                    stream_instrucoes_de_seguranca_1.Seek( 0 ,  SeekOrigin.End );
                    int numero_final_seguranca = stream_instrucoes_de_seguranca_1.ReadByte();


                    if(  numero_inicial_seguranca != numero_final_seguranca  )
                        {

                            // ** se o arquivo existir mostrar uma mensagem para o player falando que o programa esta arrumando.
                            // vai demorar um pouco

                        }


            }

            public void Renovar_arquivo_das_instrucoes(){

                            
                    // seta novas insrucoes vazias
                    stream_instrucoes_de_seguranca_1.Seek( 0 ,  SeekOrigin.Begin );
                    byte[] novo_buffer_instrucoes = new byte[ length_arquivo_instrucoes_de_seguranca ];

                    novo_buffer_instrucoes[ 0 ] = ( byte ) 1;
                    novo_buffer_instrucoes[ novo_buffer_instrucoes.Length - 1 ] = ( byte ) 1;

                    stream_instrucoes_de_seguranca_1.Write( novo_buffer_instrucoes , 0 ,novo_buffer_instrucoes.Length );
                    stream_instrucoes_de_seguranca_1.Flush();

                    stream_instrucoes_de_seguranca_1.Seek( 0 ,  SeekOrigin.Begin );

                    return;
                  


            }






}