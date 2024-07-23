using System;
using UnityEngine;
using System.IO;


public class Controlador_instrucoes_de_seguranca {



                //  ** LOGICA
                //  O jogo tem que salvar em run time, mas eu preciso minimizar o acesso ao disco. 
                //  escrever 10 bytes em 10 arquivos é muito ( muito ) mais lento que 100 bytes em 1 arquivo 

                //  Com as instrucoes de seguranca eu posso ir para o momento atual do jogo com o momento passado
                //     fn_atualizar (  arquivo_antigo , instrucoes_de_seguranca ) => arquivo _atual
                //  mas esses dados só vão ser usados caso o sistema seja interrempido ( tanto pelo player para evitar uma escolha ruim quanto pelo proprio sistema )  
                //  decodificar as instrucoes vai levar muito mais tempo, é somente para seguranca.

                //   O jogo vai ir salvando lentamente os arquivos de cada entidade ( personagem, cidade, plot ) como um grande container
                //   e quando o player fechar a aplicação ou sair do jogo para o menu o jogo vai primeiro salvar todos os containers ativos

                // As instrucoes de seguranca vão ficar em uma grande stack de momentos que contem todas as instrucoes para faze o sistema passar do ponto p1 para o ponto p2. 
                // tendo como padrao o formato: [  momento 1  ][ momento 2 ] ... [ momento n ]
                // cada momento: [ momento ] => [   intrucao 1   ]  
                //                              [   intrucoa 2   ]
                //                              [   intrucoa 3   ]
                //                              [      ....      ]


                // formato [ id stack ][ bloco ]
                // bloco : [ 1 seguranca ]  [  length 2 bytes  ]  [ dados ]  [ 1 seguanca ]
                 


                //  ** SEGURANCA
                //  o Jogo tem 2 planos de entidades principais : primeiro plano e segundo plano 
                //    - primeiro plano tem as entidades que estão perto do player e são atualizados com frequencia mas quase não são trocados 
                //    - segundo plano tem as entidades longe do player e são atualizados com baixa frequencia mas são trocados constantemente
                //  esses planos vão ser salvos em turnos com certos requerimentos :
                //  primeiro_plano => length dos dados de seguranca passarem de 200kb 
                //  segundo plano  => sempre que tiver alguma cidade secundaria para atualizar, ele tem que salvar as entidades que não vão mais ser usadas 

                //  O controlador_save vai sempre verificar qual p



                public static Controlador_instrucoes_de_seguranca instancia;
                public static Controlador_instrucoes_de_seguranca Pegar_instancia(){ return instancia; }

                public static Controlador_instrucoes_de_seguranca Construir (){

                        Controlador_instrucoes_de_seguranca controlador = new Controlador_instrucoes_de_seguranca();


                                controlador.controlador_save = Controlador_save.Pegar_instancia();
                        
                        
                                if( ! ( File.Exists( Paths_sistema.path_arquivo__stack_1 ) ) )
                                        {  throw new Exception( $"stack_1 nao foi encontrada no path { Paths_sistema.path_arquivo__stack_1 }" );  }

                                if( ! ( File.Exists( Paths_sistema.path_arquivo__stack_2 ) ) )
                                        {  throw new Exception( $"stack_2 nao foi encontrada no path { Paths_sistema.path_arquivo__stack_2 }" );  }

                                        
                                FileMode file_mode = FileMode.Open;
                                FileAccess file_accees = FileAccess.ReadWrite;
                                FileShare file_share = FileShare.Read;
                                FileOptions file_options = FileOptions.WriteThrough;
                        
                                controlador.strems_stacks[ 0 ] = new FileStream( Paths_sistema.path_arquivo__stack_1, file_mode, file_accees , file_share, controlador.length_arquivo_instrucoes_de_seguranca , file_options );
                                controlador.strems_stacks[ 1 ] = new FileStream( Paths_sistema.path_arquivo__stack_2, file_mode, file_accees , file_share, controlador.length_arquivo_instrucoes_de_seguranca , file_options );

                        instancia = controlador;
                        return controlador;

                }


                public Controlador_save controlador_save;

                public int[] indexes_instrucoes_de_seguranca = new int[]{ 0 , 0 };
                public FileStream[] strems_stacks = new FileStream[ 2 ];


                public int length_arquivo_instrucoes_de_seguranca = 500_000;
                public int length_para_iniciar_troca = 200_000;
                public int length_arquivo_segurancao = 0;

        
                public int id_stack = 1; // sempre aponta para a primeira





                public void Update( Modo_save _modo ){

                
                        // --- PEGAR DADOS
                        
                        byte[][][][] arquivos_instrucoes_personagens_completos =  Controlador_personagens.Pegar_instancia().gerenciador_save.Pegar_instrucoes_de_seguranca_personagens( _modo );
                        byte[][][][] instrucoes_de_seguranca_cidades_completos = Controlador_cidades.Pegar_instancia().gerenciador_save.Pegar_instrucoes_de_seguranca_cidades( _modo );

                        byte[][] buffers_stacks = new byte[ 2 ][];

                        int numero_stacks_maximo = 2;

                        for( int stack_index = 0 ; stack_index < numero_stacks_maximo ;  stack_index++ ){


                                byte[][][]  personagens_instrucoes  =  arquivos_instrucoes_personagens_completos[ stack_index ] ;
                                byte[][][]  cidades_instrucoes =  instrucoes_de_seguranca_cidades_completos[ stack_index ] ;

                                int tamanho_final_buffer = 0;

                                tamanho_final_buffer += BYTE.Pegar_quantidade_de_bytes_arr_3d( personagens_instrucoes );
                                tamanho_final_buffer += BYTE.Pegar_quantidade_de_bytes_arr_3d( cidades_instrucoes );

                                if( tamanho_final_buffer > 0 )
                                        {
                                                // tem algo para salvar 

                                                tamanho_final_buffer += 2; // 1 no inicio e no final
                                                tamanho_final_buffer += 2; // length dos dados

                                        }

                                buffers_stacks[ stack_index ] = new byte[ tamanho_final_buffer ];
                                byte[] buffer_atual = buffers_stacks[ stack_index ];

                                buffer_atual[ 0 ] = ( byte ) 1 ;
                                buffer_atual[ 1 ] = ( byte ) ( tamanho_final_buffer >> 8 ) ;
                                buffer_atual[ 2 ] = ( byte ) ( tamanho_final_buffer >> 0 ) ;
                                buffer_atual[ tamanho_final_buffer - 1 ] = ( byte ) 1 ;

        
                                int index_buffer = 3; // comeca no 3 por conta do 1 no inicio + lgn 

                                byte[][][][] containers_genericos = new byte[][][][]{

                                                // --- TEM QUE TER TODOS OS OBJETOS
                                                personagens_instrucoes ,
                                                cidades_instrucoes 
                                };


                                for( int generico_container_index = 0 ; generico_container_index < containers_genericos.Length; generico_container_index++ ){

                                        byte[][][] container = containers_genericos[  generico_container_index ];
 
                                        for( int generico_index = 0 ; generico_index < container.Length ; generico_index++ ){

                                                byte[][] instrucoes = container[ generico_index ];

                                                for(  int instrucao_id = 0 ; instrucao_id  < instrucoes.Length ; instrucao_id ++  ){

                                                        byte[] instrucao = instrucoes[ instrucao_id ];

                                                        for( int byte_index = 0 ; byte_index < instrucao.Length ; byte_index++ ){

                                                                index_buffer++ ;
                                                                buffer_atual[ index_buffer ] = instrucao[ byte_index ] ;

                                                        }

                                                }

                                        }

                                }

                                indexes_instrucoes_de_seguranca[ stack_index ] += buffer_atual.Length;
                                strems_stacks[ stack_index ].Write( buffer_atual, 0, buffer_atual.Length );
                                strems_stacks[ stack_index ].Flush();

                                continue;


                        }

                        return;

                                        

                }




        //     public void Verificar_arquivo_das_instrucoes_de_seguranca(){


        //                 // --- VERIFICAR SE O PROGRAMA FOI ENCERRADO CORRETAMENTE 

        //                 strems_stacks[ 0 ].Seek( 0 ,  SeekOrigin.Begin );
        //                 int numero_inicial_seguranca = strems_stacks[ 0 ].ReadByte();

        //                 strems_stacks[ 1 ].Seek( 0 ,  SeekOrigin.End );
        //                 int numero_final_seguranca = strems_stacks[ 1 ].ReadByte();


        //                 if(  numero_inicial_seguranca != byte_segurancao_iniciar_jogo ||  numero_final_seguranca != byte_segurancao_iniciar_jogo )
        //                 {

        //                         // ** se o arquivo existir mostrar uma mensagem para o player falando que o programa esta arrumando.
        //                         // vai demorar um pouco

        //                         throw new Exception();

        //                 }


        //     }



            public void Renovar_stacks_instrucoes( int _stack ){

                        // vai ser chamado sempre quando o save for finalizado 

                        // 0  => 1 main 
                        // 1  => 2 secundaria
                        // 2  =>  as 2

                        // seta novas insrucoes vazias
                        strems_stacks[ 0 ].Seek( 0 ,  SeekOrigin.Begin );
                        byte[] novo_buffer_instrucoes = new byte[ length_arquivo_instrucoes_de_seguranca ];

                        novo_buffer_instrucoes[ 0 ] = ( byte ) 1; // seguranca
                        novo_buffer_instrucoes[ 1 ] = ( byte ) 1; // id stack

                        novo_buffer_instrucoes[ length_arquivo_instrucoes_de_seguranca - 1 ] = ( byte ) 1;

                        strems_stacks[ 0 ].Write( novo_buffer_instrucoes , 0 ,novo_buffer_instrucoes.Length );
                        strems_stacks[ 0 ].Flush();

                        int index_para_comecar = 2; // seguranca + id
                        indexes_instrucoes_de_seguranca = new int[] {
                                
                                index_para_comecar, 
                                index_para_comecar,

                        };

                        strems_stacks[ 0 ].Seek( index_para_comecar ,  SeekOrigin.Begin );

                        return;
                  


            }






}