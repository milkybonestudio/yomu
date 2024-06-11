using System;
using System.IO;
using UnityEngine;





public class Gerenciador_save_personagens {



        public Controlador_personagens controlador_personagens;



        // ---- PERSONAGENS LIXEIRA

        public Personagem[] personagens_esperando_para_serem_excluidos;
        public int[] personagens_esperando_para_serem_excluidos_ids;

        // ---------------------------------



        // --- USO SALVANDO STACK
        public int[] personagens_sendo_salvos_segunda_stack; // instanciar quando precisar
        public int[] personagens_com_dados_nao_salvos_na_stack ;// personagens que estao na lixeira também esta aqui 
        public int personagem_sendo_salvo; // dados vao para a segunda stack. se ja esta na segunda precisa disso?


        
        public byte[][][] instrucoes_personagens; // length = numero de personagens
        public int[] index_instrucao_atual; // length = numero de personagens
        public Modo_save modo_save;


        public void Colocar_personagem_na_lixeira( Personagem _personagem ){


                for( int slot_teste = 0 ; slot_teste < personagens_esperando_para_serem_excluidos.Length ;slot_teste++ ){

                        if( personagens_esperando_para_serem_excluidos_ids[ slot_teste ] == 0)
                                {
                                        personagens_esperando_para_serem_excluidos_ids[ slot_teste ] = _personagem.personagem_id;
                                        personagens_esperando_para_serem_excluidos[ slot_teste ] = _personagem;
                                        return;
                                }

                }


                Personagem[] novo_personagens = new Personagem[ personagens_esperando_para_serem_excluidos_ids.Length + 5 ];
                int[] novo_personagens_ids = new int[ personagens_esperando_para_serem_excluidos_ids.Length + 5 ];

                int index_para_acrescentar = personagens_esperando_para_serem_excluidos_ids.Length;

                for( int novo_arr_index = 0; novo_arr_index < personagens_esperando_para_serem_excluidos_ids.Length; novo_arr_index++ ){

                        novo_personagens_ids[ novo_arr_index ]  =  personagens_esperando_para_serem_excluidos_ids[ novo_arr_index ];
                        novo_personagens[ novo_arr_index ]  =  personagens_esperando_para_serem_excluidos[ novo_arr_index ];
                        
                }

                personagens_esperando_para_serem_excluidos_ids[ index_para_acrescentar ] = _personagem.personagem_id;
                personagens_esperando_para_serem_excluidos[ index_para_acrescentar ] = _personagem;

                return;

        
        }

        public Personagem Retirar_personagem_da_lixeira( int _personagem_id ){

                for( int personagem_slot_index = 0; personagem_slot_index  < personagens_esperando_para_serem_excluidos_ids.Length; personagem_slot_index ++ ){

                        if( personagens_esperando_para_serem_excluidos_ids[ personagem_slot_index ] == _personagem_id )
                                { 
                                        Personagem personagem = personagens_esperando_para_serem_excluidos[ personagem_slot_index ];
                                        personagens_esperando_para_serem_excluidos[ personagem_slot_index ] = null;
                                        personagens_esperando_para_serem_excluidos_ids[ personagem_slot_index ] = 0;
                                        return personagem; 

                                }
                        continue;

                        
                }

                return null;

        }




        public Dados_para_salvar Pegar_personagem_para_salvar( Modo_save _modo ){



                if( _modo == Modo_save.salvando_stack )
                        {
                                // o foco quando a stack estiver sendo trocada vai ser sempre 

                                for( int personagem_primeira_stack_index = 0 ; personagem_primeira_stack_index < personagens_com_dados_nao_salvos_na_stack.Length; personagem_primeira_stack_index++ ){

                                        if ( personagens_com_dados_nao_salvos_na_stack[ personagem_primeira_stack_index ] == 0 )
                                                { continue; }
                                                
                                        return Criar_dados_para_salvar_personagem( personagens_esperando_para_serem_excluidos_ids[ personagem_primeira_stack_index ] ); 
                                        
                                }

                                // --- SE ESTA SALVANDO A STACK NAO VAI PARA A LIXEIRA 
                                // ** tudo que estava na lixeira e agora nao esta na lista já foi salvo e agora aquele persoangem esta sendo salvo na stack 2 
                                return null;
                        }

                
                // --- VERIFICAR LIXEIRA
                for( int personagem_lixeira_index = 0 ; personagem_lixeira_index < personagens_esperando_para_serem_excluidos_ids.Length ; personagem_lixeira_index++ ){

                        if( personagens_esperando_para_serem_excluidos_ids[ personagem_lixeira_index ] != 0 )
                                { return Criar_dados_para_salvar_personagem( personagens_esperando_para_serem_excluidos_ids[ personagem_lixeira_index ] ); }

                }
 
                return null ;

        }


        public Dados_para_salvar Criar_dados_para_salvar_personagem( int _personagem_id ) {


                        Dados_para_salvar dados_retorno = new Dados_para_salvar();
                
                        // isso talvez possa demorar 
                        dados_retorno.dados = personagens_esperando_para_serem_excluidos[ _personagem_id ].gerenciador_containers_dados.Compilar_dados();

                        // dados agora vai para a segunda stack
                        personagens_esperando_para_serem_excluidos[ _personagem_id ] = 0;

                        string personagem_nome = ( ( Personagem_nome ) _personagem_id ).ToString() ;
                        string path = Paths_sistema.path_dados_personagens + "/" + personagem_nome + "_dados.dat";

                        dados_retorno.path = path;

                        return dados_retorno;

        }

        

        public void Colocar_instrucoes_de_seguranca(  int _personagem_id,  byte[] _dados_seguranca  ){


                int index = index_instrucao_atual[ _personagem_id ];
                index_instrucao_atual[ _personagem_id ] = index + 1;

                if( index == instrucoes_personagens[ _personagem_id ].Length )
                        { instrucoes_personagens[ _personagem_id ] = BYTE.Aumentar_length_array_2d( instrucoes_personagens[ _personagem_id ], 10 ); }

                instrucoes_personagens[ _personagem_id ][ index ] = _dados_seguranca;

                return; 

        }



        




        public void Declarar_que_personagem_foi_salvo( int _personagem_id ){


                // ---- VERIFICAR LIXEIRA
                
                for( int personagens_lixeira_index = 0 ; personagens_lixeira_index < personagens_esperando_para_serem_excluidos_ids.Length ; personagens_lixeira_index++ ){

                        if( personagens_esperando_para_serem_excluidos_ids[ personagens_lixeira_index ] == _personagem_id  )
                                { 
                                        personagens_esperando_para_serem_excluidos_ids[ personagens_lixeira_index ] = 0;

                                        // agora todas as referencias foram perdidas, tem que reimportar todo o personagem
                                        personagens_esperando_para_serem_excluidos[ personagens_lixeira_index ] = null;
                                        return;
                                }
                        
                        continue;

                }

 
                if( modo_save != Modo_save.salvando_stack )
                        {

                                Debug.Log( "-------------------------------------------------------------------------" );
                                Debug.LogError( $"iformou que o personagem <color=red>{ (( Personagem_nome ) _personagem_id).ToString() }</color> foi salvo mas nao tinha contexto para ele ser salvo. Não estava resetando a stack e ele nao estava na lixeira" );
                                Debug.Log( "-------------------------------------------------------------------------" );
                                throw new Exception();

                        }


                // --- TROCAR DESTINO DAS STACKS

                for( int personagem_primeira_stack_index = 0 ; personagem_primeira_stack_index < personagens_com_dados_nao_salvos_na_stack.Length ; personagem_primeira_stack_index++ ){

                        if( personagens_com_dados_nao_salvos_na_stack[ personagem_primeira_stack_index ] == _personagem_id )
                                {

                                        // TIRA PERSONAGEM DA PRIMEIRA STACK
                                        personagens_com_dados_nao_salvos_na_stack[ personagem_primeira_stack_index ] = 0;

                                        int index_para_adicionar = INT.Pegar_index_valor( personagens_sendo_salvos_segunda_stack , 0 );
                                        if( index_para_adicionar == -1  )
                                                {   

                                                        index_para_adicionar = personagens_sendo_salvos_segunda_stack.Length;
                                                        personagens_sendo_salvos_segunda_stack =  INT.Aumentar_length_array( personagens_sendo_salvos_segunda_stack, 15 );
                                                        
                                                }
                                        
                                        // COLOCA NA SEGUNDA STACK
                                        personagens_sendo_salvos_segunda_stack[ index_para_adicionar ] = _personagem_id;
                                        
                                                

                                        return;


                                        
                                }

                        continue;

                }

                        






        }


        
        public byte[][][][] Pegar_instrucoes_de_seguranca( Modo_save _modo_save ){


                // [ stack ][ personagem ][ instrucoes ][ bytes_instucoes ]

                byte[][][][] retorno = new byte[ 2 ][][][]{

                        new byte[ 0 ][][], 
                        new byte[ 0 ][][], 

                };


                int numero_persoangens_primeira_stack = INT.Length_elementos_maiores_que_0( personagens_com_dados_nao_salvos_na_stack );
                retorno[ 0 ] = new byte[ numero_persoangens_primeira_stack  ][][]; 
                

                // --- PEGA PRIMEIRA STACK
                for(  int personagem_primeira_stack_index = 0 ; personagem_primeira_stack_index < personagens_com_dados_nao_salvos_na_stack.Length ; personagem_primeira_stack_index++ ){

                        int personagem_id = personagens_com_dados_nao_salvos_na_stack[ personagem_primeira_stack_index ];
                        byte[][] personagem_instrucoes = instrucoes_personagens[ personagem_id ];
                        retorno[ 0 ][ personagem_primeira_stack_index ] = personagem_instrucoes;
                        // reseta slot 
                        instrucoes_personagens[ personagem_id ] = new byte[ 20 ][];
                        continue;

                }



                if( _modo_save == Modo_save.salvando_stack )
                        {
                                
                                int numero_persoangens_segunda_stack = INT.Length_elementos_maiores_que_0( personagens_sendo_salvos_segunda_stack );                                
                                retorno[ 1 ] = new byte[ numero_persoangens_segunda_stack  ][][]; 

                                // --- PEGA SEGUNDA STACK
                                for(  int personagem_segunda_stack_index = 0 ; personagem_segunda_stack_index < personagens_sendo_salvos_segunda_stack.Length ; personagem_segunda_stack_index++ ){

                                        int personagem_id = personagens_sendo_salvos_segunda_stack[ personagem_segunda_stack_index ];
                                        byte[][] personagem_instrucoes = instrucoes_personagens[ personagem_id ];
                                        retorno[ 2 ][ personagem_segunda_stack_index ] = personagem_instrucoes;
                                        // reseta slot 
                                        instrucoes_personagens[ personagem_id ] = new byte[ 20 ][];
                                        continue;

                                }


                        }

                return retorno;

  
        }


}