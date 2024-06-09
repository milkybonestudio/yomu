using System;
using System.IO;




public class Controlador_save_personagens {

        
        public Controlador_save_personagens ( ){ 

                // **ele precisa ter pointers para os arrays containers dos personagens ativos

                // compactar_instrucoes personagens 
                // compactar_containers

                controlador_save = Controlador_save.Pegar_instancia();

            
        }


        public Containers_dados_personagem[] containers_dados_personagens = new Containers_dados_personagem[ 10 ];
        public Controlador_save controlador_save;
        public int[] personagens_para_salvar_primeiro_plano = new int[ 10 ];
        public int[] personagens_para_salvar_segundo_plano =  new int[ 10 ];


        public byte[] dados_para_adicionar_personagens;

        public int frames = 0;


        public int[] Iniciar_salvar(){

                int[] personagens_ativos = Controlador_personagens.Pegar_instancia().personagens_ativos;
                int[] 




        }



        public bool Verificar_se_tem_personagens_para_salvar(){

                for( int slot_personagem_para_salvar = 0 ; slot_personagem_para_salvar < personagens_para_salvar.Length ; slot_personagem_para_salvar++ ){

                        if( personagens_para_salvar[ slot_personagem_para_salvar ] != 0  )
                                {
                                        Containers_dados_personagem container = containers_dados_personagens[ slot_personagem_para_salvar ];

                                        string path = controlador_save.path_dados_personagens + "/" + (( Personagem_nome ) personagens_para_salvar[ slot_personagem_para_salvar ]).ToString() + "_dados.dat";
                                        byte[] dados = Compilar_dados_personagem( container );
                                        
                                
                                        personagens_para_salvar[ slot_personagem_para_salvar ] = 0;
                                        containers_dados_personagens[ slot_personagem_para_salvar ] = null;

                                        controlador_save.Criar_task_salvar_dados( path , dados );
                                        return true;

                                
                                        
                                }

                }

                // nao tem nada

                return false ;


        }


        public byte[] Compilar_dados_personagem( Containers_dados_personagem _dados ){

                // vai levar em conta que certos dados sempre tem uma margem que pode ser cortado 


        }

        
        public byte[][][] Pegar_instrucoes_de_seguranca( Modo_save_atual _modo_save ){

                // vai voltar sempre um byte[ 4 ][] 

                byte[][][] retorno = new byte[ 4 ][][]{

                        new byte[ 0 ][], 
                        new byte[ 0 ][], 
                        new byte[ 0 ][], 
                        new byte[ 0 ][]
                };



                byte[][][] primeiro_plano_instrucoes = Pegar_intrucoes_primeiro_plano();

                retorno[ 0 ] = fn();




                switch( _modo_save ){

                        case Modo_save_atual.nada: return Compactar_intrucoes_de_seguranca_simples();
                        case Modo_save_atual.salvando_primeiro_plano: return Compactar_intrucoes_de_seguranca_salvando_primeiro_plano();
                        case Modo_save_atual.salvando_segundo_plano: return Compactar_intrucoes_de_seguranca_salvando_segundo_plano();

                }




                // aqui poderia pegar 1 arquivo para fazer o update também 
                // se o arquivo for muito grande pode passar para o multithread e impedir novos updates até que ele acabe




  
        }


        public byte[][][] Pegar_intrucoes_primeiro_plano( Modo_save_atual _modo ){


                byte[][][] retorno = new byte[ 2 ][][];



                if( _modo == Modo_save_atual.salvando_primeiro_plano )
                
                        {

                                // dados personagens sempre esta no formato: 
                                        
                                // [      1 byte            2 bytes            char     ] 
                                // [  metodo_geral  ,  metodo_especifico ,    2 bytes    ]


                                byte[][] dados_completo =  Controlador_personagens.Pegar_instancia().dados_para_adicionar_primeiro_plano;

                                int numero_personagens_file_1 = 0;

                                for( int index = 0 ; index < dados_completo.Length ; index++ ){

                                        byte[] dados = dados_completo[ index ];

                                        int personagem = 0; 
                                        personagem +=   (( int ) dados[ 3 ] << 8 );
                                        personagem +=   (( int ) dados[ 3 ] << 0 );


                                        INT.Tem_valor_no_array( personagens_para_salvar_primeiro_plano , personagem );
                                        


                                }

                                byte[][] dados_file_1 = ;
                                byte[][] dados_file_2 = ;






                                retorno[ 0 ] = Controlador_personagens.Pegar_instancia().dados_para_adicionar_primeiro_plano ;
                                retorno[ 1 ] = Controlador_personagens.Pegar_instancia().dados_para_adicionar_primeiro_plano ;

                                return retorno;

                        }


                // --- NORMAL
                


                byte[][] dados_para_adicionar_personagens_primario =  
                retorno[ 0 ] = dados_para_adicionar_personagens_primario;


                retorno[ 0 ] =  BYTE.Compactar_byte_array_3d_PARA_NULL( dados_para_compactar_primeiro_plano );




        }

        

        public byte[][] Compactar_intrucoes_de_seguranca_simples(){

                

                byte[][] retorno = new byte[ 4 ][];


                // --- PRIMARIO

                // talvez tenha que aumentar 
                byte[][][] dados_para_compactar_primeiro_plano = new byte[ 1 ][][];
                

                byte[][] dados_para_adicionar_personagens_primario =  Controlador_personagens.Pegar_instancia().dados_para_adicionar_primeiro_plano;
                dados_para_compactar_primeiro_plano[ 0 ] = dados_para_adicionar_personagens_primario;


                retorno[ 0 ] =  BYTE.Compactar_byte_array_3d_PARA_NULL( dados_para_compactar_primeiro_plano );





                // ---- SECUNDARIO

                byte[][][] dados_para_compactar_segundo_plano = new byte[ 1 ][][];

                byte[][] dados_para_adicionar_personagens_secundario =  Controlador_personagens.Pegar_instancia().dados_para_adicionar_segundo_plano;
                dados_para_compactar_segundo_plano[ 0 ] = dados_para_adicionar_personagens_secundario;


                retorno[ 2 ] =  BYTE.Compactar_byte_array_3d_PARA_NULL( dados_para_compactar_segundo_plano );





                return retorno;

                

        }





        // vai ser resetado quando save realmente salvar em disco
        byte[][] dados_de_seguranca = new byte[ 100 ][];




        public string[] nomes_arquivos_personagens;
        public int numero_de_arquivos_personagem;


        // CAMPOS

        // public Dados_sistema_personagem[] dados_sistema_personagens;
        public Personagem[] personagens;

        public string path_save_personagens;

        
        
        public void Construir_streams( Dados_sistema_personagem_essenciais _dados_sistema_personagem ){

                // agora as streams vão ficar no personagem, tem que tomar cuidado para quando um persoangem não estivar mais ativo remover as streams;


                // todos os streams vao ter o mesmo FileOptions => qunaod ativar o Flush() no writer ele vai salvar realmente o arquivo 
                // os dados vão ser colocados com o gravador ao longo do tempo. 
                
                
                FileMode file_mode = FileMode.Open;
                FileAccess file_accees = FileAccess.ReadWrite;
                FileShare file_share = FileShare.Read;
                FileOptions file_options = FileOptions.WriteThrough;

                // string path_personagem = path_save_personagens + _dados_sistema_personagem.nome_personagem.ToString() + "/";

                

        }


        public void Mudar_container_geral_para_arquivos_completos( Personagem_nome _nome ){}







}