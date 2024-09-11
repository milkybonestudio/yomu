using System;
using System.IO;
using UnityEngine;


public class MODULO__buffer_entidade : INTERFACE__buffer {

        // ** a funcao principal por hora é guardar o buffer e salvar

        public MODULO__buffer_entidade( Tipo_entidade _tipo ){ 

            tipo_entidade = _tipo; 

        }


        public Tipo_entidade tipo_entidade;
        
        //[ tipo_entidade ( 1byte ) ] [ personagem_id[ 4 bytes ] | posicao( 2 bytes ) | length( 2 bytes ) | length bytes ]
        public byte[] entidades_instrucoes_stack = new byte[ 10_000 ];
        public int index_instrucao_atual_stack;


        // ** qual entidade
        // ** entidade id
        // ** fn : oque vai fazer ( interpretado na hora da reconstrucao )
        // ** dados


        public void Colocar_instrucoes_de_seguranca( int _entidade_id, byte _fn, byte[] _dados ){


                // ---  GARANTIR TAMANHO
                int total_bytes =   index_instrucao_atual_stack +
                                    1 + // tipo
                                    4 + // id
                                    1 + // fn
                                    2 + // length
                                    _dados.Length;
                                 
                if(  total_bytes < entidades_instrucoes_stack.Length )
                    { Array.Resize( ref entidades_instrucoes_stack, entidades_instrucoes_stack.Length + 1_000 ); }

                
                // --- COLOCAR TIPO ENTIDADE
                entidades_instrucoes_stack[ index_instrucao_atual_stack ] = ( byte )( tipo_entidade );
                index_instrucao_atual_stack++;


                // --- COLOCAR ENTIDADE ID
                entidades_instrucoes_stack[ index_instrucao_atual_stack ] = ( byte )( _entidade_id >> 24 );
                index_instrucao_atual_stack++;

                entidades_instrucoes_stack[ index_instrucao_atual_stack ] = ( byte )( _entidade_id >> 16 );
                index_instrucao_atual_stack++;

                entidades_instrucoes_stack[ index_instrucao_atual_stack ] = ( byte )( _entidade_id >> 8 );
                index_instrucao_atual_stack++;

                entidades_instrucoes_stack[ index_instrucao_atual_stack ] = ( byte )( _entidade_id >> 0 );
                index_instrucao_atual_stack++;


                // --- COLOCAR FN
                entidades_instrucoes_stack[ index_instrucao_atual_stack ] = _fn ;
                index_instrucao_atual_stack++;


                // --- COLOCAR LENGTH
                entidades_instrucoes_stack[ index_instrucao_atual_stack ] = ( byte )( _dados.Length >> 8 );
                index_instrucao_atual_stack++;

                entidades_instrucoes_stack[ index_instrucao_atual_stack ] = ( byte )( _dados.Length >> 0 );
                index_instrucao_atual_stack++;


                // --- COPIAR DADOS
                BYTE.Copiar_elementos_de_array( entidades_instrucoes_stack, index_instrucao_atual_stack, _dados, _dados.Length );
                index_instrucao_atual_stack += _dados.Length;

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
