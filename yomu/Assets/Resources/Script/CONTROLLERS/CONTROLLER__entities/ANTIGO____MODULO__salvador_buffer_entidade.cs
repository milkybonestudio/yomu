using System;
using System.IO;
using UnityEngine;


unsafe public class MODULO__buffer_entidade {

        // ** a funcao principal por hora é guardar o buffer e salvar

        public MODULO__buffer_entidade( Entity_type _tipo ){ 

            tipo_entidade = _tipo; 

        }

        public Buffer buffer = new Buffer( 10_000 );


        public Entity_type tipo_entidade;
        
        // [ tipo_entidade ( 1byte ) ] [ personagem_id[ 4 bytes ] | posicao( 2 bytes ) | length( 2 bytes ) | length bytes ]
        public byte[] entidades_instrucoes_stack = new byte[ 500 ]; // usado para 
        public int index_instrucao_atual_stack;

        public byte[] array_temporario_interno = new byte[ 500 ]; // usado para criar os dados
        public int array_temporario_interno_pointer;
        public byte[] array_temporario_externo = new byte[ 500 ]; // usado para criar os dados
        public int array_temporario_externo_pointer;


        // ** qual entidade
        // ** entidade id
        // ** fn : oque vai fazer ( interpretado na hora da reconstrucao )
        // ** dados


        public void Colocar_instrucoes_de_seguranca( int _entidade_id, byte _fn, byte[] _dados ){

                Put_information_internal_buffer( _entidade_id, _fn, _dados.Length );

                // --- COPIAR DADOS
                BYTE.Copiar_elementos_de_array( array_temporario_interno, array_temporario_interno_pointer, _dados, _dados.Length );
                array_temporario_interno_pointer += _dados.Length;

                // ** colocar no buffer
                buffer.Add_data( array_temporario_interno, array_temporario_interno_pointer );
                return;

        }


        public void Put_safety_instructions_pointer( int _entidade_id, byte _fn, byte* _dados_pointer, int _length ){

                Put_information_internal_buffer( _entidade_id, _fn, _length );

                // ** adiciona as instrucoes sem os dados
                buffer.Add_data( array_temporario_interno, array_temporario_interno_pointer );
                // ** adiciona os dados
                buffer.Add_data_pointer( _dados_pointer, _length );
                return;

        }


        private void Put_information_internal_buffer( int _entidade_id, byte _fn, int _length  ){

                // ---  GARANTIR TAMANHO
                int total_bytes =   index_instrucao_atual_stack +
                                    1 + // tipo
                                    4 + // id
                                    1 + // fn
                                    2 ; // length
                            
                                 
                if(  total_bytes < entidades_instrucoes_stack.Length )
                    { Array.Resize( ref entidades_instrucoes_stack, entidades_instrucoes_stack.Length + 1_000 ); }

                
                // --- COLOCAR TIPO ENTIDADE
                array_temporario_interno_pointer = 0;
                array_temporario_interno[ array_temporario_interno_pointer ] = ( byte )( tipo_entidade );
                array_temporario_interno_pointer++;


                // --- COLOCAR ENTIDADE ID
                array_temporario_interno[ array_temporario_interno_pointer ] = ( byte )( _entidade_id >> 24 );
                array_temporario_interno_pointer++;

                array_temporario_interno[ array_temporario_interno_pointer ] = ( byte )( _entidade_id >> 16 );
                array_temporario_interno_pointer++;

                array_temporario_interno[ array_temporario_interno_pointer ] = ( byte )( _entidade_id >> 8 );
                array_temporario_interno_pointer++;

                array_temporario_interno[ array_temporario_interno_pointer ] = ( byte )( _entidade_id >> 0 );
                array_temporario_interno_pointer++;


                // --- COLOCAR FN
                array_temporario_interno[ array_temporario_interno_pointer ] = _fn ;
                array_temporario_interno_pointer++;


                // --- COLOCAR LENGTH
                array_temporario_interno[ array_temporario_interno_pointer ] = ( byte )( _length >> 8 );
                array_temporario_interno_pointer++;

                array_temporario_interno[ array_temporario_interno_pointer ] = ( byte )( _length >> 0 );
                array_temporario_interno_pointer++;

                return;

        }




        // *** INTERFACE


        // ** para salvar em disco( ** somente quando a stack ficar vazia )
        public Buffer_localizador[] Pegar_todos_os_dados_para_salvar(){ return null; }

        // ** somente dados que não precisam mais estar na ram
        public Buffer_localizador[] Pegar_dados_para_salvar(){ return null;}
        
        // ** salvar na stack 
        public Buffer_localizador Pegar_instrucoes_de_seguranca(){

                // ** precisa colocar novamente sempre que for salvar em caso de expancao do array
                Buffer_localizador instrucoes = new Buffer_localizador();

                instrucoes.buffer = entidades_instrucoes_stack;
                instrucoes.pointer = index_instrucao_atual_stack;
                index_instrucao_atual_stack = 0;

                // ** vai salvar os dados no mesmo frame, os dados que ficarem no buffer são contados somente dentro do range do pointer
                return instrucoes;
  
        }


        
}
