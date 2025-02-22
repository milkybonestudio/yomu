
using System.IO;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;




public class CONTROLLER__saving {

            
        public static CONTROLLER__saving instancia;
        public static CONTROLLER__saving Pegar_instancia(){ return instancia; }

        
        public MODULO__gerenciador_instrucoes_de_seguranca modulo_gerenciador_instrucoes_de_seguranca;



        public void Destroy(){

            modulo_gerenciador_instrucoes_de_seguranca.strem_stack?.Close();

        }
        

        public Saving_state saving;


        public Buffer[] buffers_dados;


        public float minimun_time_to_save_ms = 2_000f;


        public void Update( Control_flow _control_flow ){}



        public void Match_disc_to_real( File_to_save[] _dados_pedidos ){


                //Garantir_dados_para_salvar( _dados_pedidos ); // 0.2ms/file => 2ms 10 - files  => 10ms( 50 files )


                for( int pedido_index = 0 ; pedido_index < _dados_pedidos.Length ; pedido_index++ ){

                        File_to_save dados_para_salvar = _dados_pedidos[ pedido_index ];

                        string path = dados_para_salvar.path;
                        byte[] dados = dados_para_salvar.dados;

                        if( path == null )
                            { continue; }

                    
                        string path_temp_arquivo_NOVO = ( path + ".temp" ) ;
                        string path_temp_arquivo_ANTIGO = ( path + ".2.temp" );

                        System.IO.File.WriteAllBytes( path_temp_arquivo_NOVO , dados  );

                        FileStream str = FILE_STREAM.Criar_stream( _path: path_temp_arquivo_NOVO, _tamanho_buffer: 0 );

                        str.Flush();
                        str.Close();


                        // muda o nome do antigo
                        System.IO.File.Move(  path , path_temp_arquivo_ANTIGO );

                        // coloca o nome correto 
                        System.IO.File.Move(  path_temp_arquivo_NOVO, path  );

                        // deleta o save
                        System.IO.File.Delete( path_temp_arquivo_ANTIGO );


                }

        
                return;

        }



}



