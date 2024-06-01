using System;
using System.IO;




public class Controlador_save_personagens {

        
        public Controlador_save_personagens ( Dados_sistema_personagem[] _dados_sistema_personagens, int _save ){ 


                nomes_arquivos_personagens = Enum.GetNames( typeof( Arquivos_dados_personagem ) );
                // o numero 0 é o container geral
                numero_de_arquivos_personagem = nomes_arquivos_personagens.Length - 1;

                    
                path_save_personagens = Paths_gerais.Pegar_path_folder_dados_save( _save ) + "/Personagens/"; 
            
                for( int personagem_index = 0 ; personagem_index <  dados_sistema_personagens.Length ; personagem_index++){
                        
                        if( dados_sistema_personagens[ personagem_index ].personagem_esta_ativo ){ Construir_streams( _dados_sistema_personagens[ personagem_index ] ); }

                }

            
        }


        public byte[] dados_para_adicionar_personagens;

        public int frames = 0;

        
        public byte[] Pegar_dados_em_espera(){
                

                // na realidade eu posso ir salvando aos poucos sem nenhum problema 
                // oque eu tenho que garantir é que o primeiro flush vai ser sempre do save de segurança 

                
                frames = ( frames + 1 ) % 10 ;

                if( frames == 0 ) {

                }

                
                byte[][] dados_para_adicionar_personagens =  Controlador_personagens.Pegar_instancia().dados_para_adicionar;
                

                int dados_length = 0;
                int dados_arr_index = 0; 

                for( dados_arr_index = 0 ; dados_arr_index < dados_para_adicionar_personagens.Length ; dados_arr_index++ ){

                        if( dados_para_adicionar_personagens[ dados_arr_index] == null ) { break; }
                        dados_length += dados_para_adicionar_personagens[ dados_arr_index].Length;

                        continue;
                        
                }


                byte[] dados_compilados = new byte[ dados_length ];

                int index_atual = 0 ;


                for(  dados_arr_index = 0 ; dados_arr_index < dados_para_adicionar_personagens.Length ; dados_arr_index++ ){

                        if( dados_para_adicionar_personagens[ dados_arr_index] == null ) { break; }

                        byte[] dados = dados_para_adicionar_personagens[ dados_arr_index ];  

                        for( int dados_index = 0 ; dados_index < dados.Length ; dados_index++ ){

                                dados_compilados[ index_atual ] = dados[ dados_index ] ;
                                index_atual++ ;
                                
                        }

                        continue;
                        
                }

                
                for( dados_arr_index = 0 ; dados_arr_index < dados_para_adicionar_personagens.Length ; dados_arr_index++ ){

                        dados_para_adicionar_personagens[ dados_arr_index] = null;
                        
                }


                return dados_compilados;


                // aqui poderia pegar 1 arquivo para fazer o update também 
                // se o arquivo for muito grande pode passar para o multithread e impedir novos updates até que ele acabe




  
        }





        // vai ser resetado quando save realmente salvar em disco
        byte[][] dados_de_seguranca = new byte[ 100 ][];




        public string[] nomes_arquivos_personagens;
        public int numero_de_arquivos_personagem;


        // CAMPOS

        public Dados_sistema_personagem[] dados_sistema_personagens;
        public Personagem[] personagens;

        public string path_save_personagens;

        
        
        public void Construir_streams( Dados_sistema_personagem _dados_sistema_personagem ){

                // agora as streams vão ficar no personagem, tem que tomar cuidado para quando um persoangem não estivar mais ativo remover as streams;


                // todos os streams vao ter o mesmo FileOptions => qunaod ativar o Flush() no writer ele vai salvar realmente o arquivo 
                // os dados vão ser colocados com o gravador ao longo do tempo. 
                
                int tipo_armazenamento = _dados_sistema_personagem.tipo_armazenamento;

                FileMode file_mode = FileMode.Open;
                FileAccess file_accees = FileAccess.ReadWrite;
                FileShare file_share = FileShare.Read;
                FileOptions file_options = FileOptions.WriteThrough;

                string path_personagem = path_save_personagens + _dados_sistema_personagem.nome_personagem.ToString() + "/";

                


                if( tipo_armazenamento == 0 ){
                        
                        // esta tudo em 1 container
                        // o container geral tem sempre as informacoes de como chegar nos dados dentro dele no inicio do container 

                        string path_para_container_geral = path_personagem + "dados_gerais_container.dat";
                        int tamanho_buffer_arquivo_completo = _dados_sistema_personagem.length_container_geral;

                        _dados_sistema_personagem.streams = new FileStream[ 1 ];
                        _dados_sistema_personagem.streams[ 0 ] = new FileStream( path_para_container_geral, file_mode, file_accees , file_share, tamanho_buffer_arquivo_completo , file_options );
                        
                        
                        return;

                } 


                if( tipo_armazenamento == 1 ){

                        // esta separado em cada arquivo 

                        // ** tomar cuidado quando for modificar algum container. Tem que modificar também no 

                        int[] buffers_tamanhos = _dados_sistema_personagem.length_containers;

                        int index_inicial_sem_o_container_geral = 1;

                        // _dados_sistema_personagem.streams
                        // _dados_sistema_personagem.streams_gravadores

                        for( int campo = index_inicial_sem_o_container_geral ; campo < numero_de_arquivos_personagem ; campo++ ){

                                string path_dados_internos = path_personagem +  nomes_arquivos_personagens[ campo ]  + ".dat";
                                int tamanho_dados_internos = buffers_tamanhos[ ( int ) Arquivos_dados_personagem.dados_internos ];

                        }



                }

        }


        public void Mudar_container_geral_para_arquivos_completos( Personagem_nome _nome ){}







}