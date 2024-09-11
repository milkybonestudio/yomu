using System;
using UnityEngine;
using System.IO;


        //  ** LOGICA
        //  O jogo tem que salvar em run time, mas eu preciso minimizar o acesso ao disco. 
        //  escrever 10 bytes em 10 arquivos é muito ( muito ) mais lento que 100 bytes em 1 arquivo 

        //  Com as instrucoes de seguranca eu posso ir para o momento atual do jogo com o momento passado
        //     fn_atualizar (  arquivo_antigo , instrucoes_de_seguranca ) => arquivo _atual
        //  mas esses dados só vão ser usados caso o sistema seja interrempido ( tanto pelo player para evitar uma escolha ruim quanto pelo proprio sistema )
        //  decodificar as instrucoes vai levar muit o mais tempo, é somente para seguranca.

        // ** quando a stack ficar perto de 50% do tamanho maximo o sistema vai salvar todos os dados atuais em disco

        // As instrucoes de seguranca vão ficar em uma grande stack de momentos que contem todas as instrucoes para faze o sistema passar do ponto p1 para o ponto p2.
        // tendo como padrao o formato: [  momento 1  ][ momento 2 ] ... [ momento n ]
        // cada momento: [ momento ] => [   intrucao 1   ]
        //                              [   intrucoa 2   ]
        //                              [   intrucoa 3   ]
        //                              [      ....      ]



        // formato : [ 1 seguranca ]  [  length 3 bytes  ]  [ dados length bytes ]  [ 1 seguanca ]

            


        //  ** SEGURANCA
        //  o Jogo tem 2 planos de entidades principais : primeiro planoe segundo plano 
        //    - primeiro plano tem as entidades que estão perto do player e são atualizados com frequencia mas quase não são trocados 
        //    - segundo plano tem as entidades longe do player e são atualizados com baixa frequencia mas são trocados constantemente



        //  esses planos vão ser salvos em turnos com certos requerimentos :
        //  primeiro_plano => length dos dados de seguranca passarem de 200kb 
        //  segundo plano  => sempre que tiver alguma cidade secundaria para atualizar, ele tem que salvar as entidades que não vão mais ser usadas 

        //  O controlador_save vai sempre verificar qual p


public class MODULO__gerenciador_instrucoes_de_seguranca {


        public MODULO__gerenciador_instrucoes_de_seguranca(){

            
                if( ! ( File.Exists( Paths_sistema.path_arquivo__stack ) ) )
                        {  throw new Exception( $"stack nao foi encontrada no path { Paths_sistema.path_arquivo__stack }" );  }

                strem_stack =  FILE_STREAM.Criar_stream( _path : Paths_sistema.path_arquivo__stack, _tamanho_buffer: tamanho_buffer );

        }

    
        public FileStream strem_stack;

        public int length_arquivo_instrucoes_de_seguranca = 500_000;
        public int length_para_iniciar_troca = 200_000;
        public int length_arquivo_segurancao = 0; // ???


        public byte[][] arquivos_instrucoes_personagens_completos; // primeira + segunda stack

        public Dados_para_salvar_stack dados_para_salvar_stack = new Dados_para_salvar_stack();


        public byte[] buffer_para_salvar_stack = new byte[ 20_000 ];

        public int numero_bloco_atual = 0;
        public int pointer_atual_buffer_stack;

        public int tamanho_buffer = 20_000;

        // ** buffer com todos os dados para pegar e salvar na stack. 
        public INTERFACE__buffer[] buffers_para_salvar_stack;


        public void Salvar_instrucoes_em_disco(){



                // --- COLOCAR ID
                numero_bloco_atual++;

                int index_bloco_id = 0;
                int index_bloco_tamanho = 2;
                int index_buffer = 4; // comeca depois do id 
                
                buffer_para_salvar_stack[ ( index_bloco_id + 0 ) ] = ( byte ) ( numero_bloco_atual >> 8 );
                buffer_para_salvar_stack[ ( index_bloco_id + 1 ) ] = ( byte ) ( numero_bloco_atual >> 0 );

                //INTERFACE__controlador_entidade[] controladores_entidades;

                
                // --- COLOCAR DADOIS
                
                for( int interface_index = 0 ; interface_index < buffers_para_salvar_stack.Length ; interface_index++  ){

                        INTERFACE__buffer buffer = buffers_para_salvar_stack[ interface_index ];
                        index_buffer = Passar_dados_para_buffer( index_buffer, buffer );
                        continue;

                }

                
                buffer_para_salvar_stack[ ( index_bloco_tamanho + 0 ) ] = ( byte ) ( index_buffer >> 8 );
                buffer_para_salvar_stack[ ( index_bloco_tamanho + 1 ) ] = ( byte ) ( index_buffer >> 0 );

            
                // --- PASSAR DADOS PARA A STACK
                
                strem_stack.Seek(  pointer_atual_buffer_stack, SeekOrigin.Begin  ); // --- DEFINI NOVAMENTE POR SEGURANCA

                strem_stack.Write( buffer_para_salvar_stack, 0, index_buffer );
                strem_stack.Flush();

                return;
                                

        }



    public void Renovar_stacks_instrucoes(){

                // vai ser chamado sempre quando o save for finalizado 

                // seta novas insrucoes vazias
                strem_stack.Seek( 0 ,  SeekOrigin.Begin );
                byte[] novo_buffer_instrucoes = new byte[ length_arquivo_instrucoes_de_seguranca ];

                novo_buffer_instrucoes[ 0 ] = ( byte ) 1; // seguranca
                novo_buffer_instrucoes[ 1 ] = ( byte ) 1; // id stack
                novo_buffer_instrucoes[ length_arquivo_instrucoes_de_seguranca - 1 ] = ( byte ) 1; // seguranca


                strem_stack.Write( novo_buffer_instrucoes , 0 ,novo_buffer_instrucoes.Length );
                strem_stack.Flush();


                numero_bloco_atual = 0;
                pointer_atual_buffer_stack = 2; // seguranca + id

                strem_stack.Seek( pointer_atual_buffer_stack ,  SeekOrigin.Begin );

                return;
            

    }



    private int Passar_dados_para_buffer( int index_buffer, INTERFACE__buffer _buffer ){
        

            Buffer_localizador instrucoes = _buffer.Pegar_dados();

            byte[] instrucoes_dados = instrucoes.buffer; 
            int length = instrucoes.pointer;

            int novo_index = ( index_buffer + length );

            if( novo_index > buffer_para_salvar_stack.Length )
                { Array.Resize( ref buffer_para_salvar_stack, tamanho_buffer + 2_000 ); }


            if( novo_index > 64_000 )
                { throw new Exception( "tipo... wtf?"); }
            
            Garantir_tamanho_stack( novo_index );

            BYTE.Copiar_elementos_de_array( buffer_para_salvar_stack, index_buffer, instrucoes_dados, length );

            return novo_index;

    }


    



    private void Garantir_tamanho_stack( int _tamanho_buffer ){


            if( ( pointer_atual_buffer_stack + _tamanho_buffer ) < strem_stack.Length  )
                { return; }  
            

            Debug.Log( "Precisou extender a stack" );

            byte[] stack_redimensionada = new byte[ strem_stack.Length + 100_000 ];
            byte[] dados = System.IO.File.ReadAllBytes( Paths_sistema.path_arquivo__stack );

            BYTE.Copiar_elementos_de_array( stack_redimensionada, 0, dados, dados.Length );

            // ** nao sei se consegue sobre escrever, acho que sim
            System.IO.File.WriteAllBytes( Paths_sistema.path_arquivo__stack, stack_redimensionada );

            strem_stack.Close();

            strem_stack = FILE_STREAM.Criar_stream( _path : Paths_sistema.path_arquivo__stack, _tamanho_buffer:  tamanho_buffer );

            return;

    }


}