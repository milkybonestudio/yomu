using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.CompilerServices;



// controlador interativos só usa logica de interativos, se o player ou algum outro personagem usou algo, pegou algo ou iniciou algo. Esse algo porecisa vir de um tipo de interativo\\



public class Controlador_interativos {


            public static Controlador_interativos instancia;
            public static Controlador_interativos Pegar_instancia(){ return instancia; }



            public BLOCO_conector bloco_conector;
            public Controlador_tela_conector controlador_tela_conector;
            

            // vai ser usado somente na build
            public byte[] dados_interativos_da_cidade;


            public MODULO__leitor_de_arquivos leitor_de_arquivos;



            // --- CANVAS

            public GameObject interativos_container;
            public GameObject interativos_tipo_tela_container;
            public GameObject interativos_tipo_personagem_container;
            public GameObject interativos_tipo_item_container;



            // nao faz mais sentido
            public int interativo_atual_hover = -1;



            // --- ITENS 

            public void Acrescentar_itens( Ponto _ponto, Item_localizador[] _itens ){



            }

            public void Remover_itens( Ponto _ponto, Item_localizador[] _itens ){



            }


            // --- PERSONAGENS

            void Mover_personagem( Ponto _ponto_saida, Ponto _ponto_entrada, Personagem_nome _personagem ){

                  Remover_personagem( _ponto_saida , _personagem);
                  Acrescentar_personagem( _ponto_entrada, _personagem );
                  return;

            }

            public void Acrescentar_personagem( Ponto _ponto, Personagem_nome _personagem ){

                  

            }

            public void Remover_personagem( Ponto _ponto, Personagem_nome _personagem ){



                  Personagem_nome[] personagens_no_ponto = _ponto.ponto_ativo.personagens_no_ponto;

                  bool achou_o_interativo = false;

                  for( int personagem_index = 0 ; personagem_index < personagens_no_ponto.Length ; personagem_index++ ){

                              // --- VERIFICA SE O PERSONAGEM ESTA NO PONTO
                              if( personagens_no_ponto[ personagem_index ] == _personagem )
                                    {
                                          // --- ACHOU PERSONAGEM NO PONTO
                                          personagens_no_ponto[ personagem_index ] = Personagem_nome.nada;
                                          achou_o_interativo = true;
                                          break;
                                    }

                              // --- VERIFICA O PROXIO PERSONAGEM 
                              continue;

                  }


                  #if UNITY_EDITOR

                        if( !( achou_o_interativo ) )
                              { throw new Exception( $"Tentou remover o personagem { _personagem.ToString() } no ponto { _ponto.ponto_ativo.nome }, mas ele nao estava no ponto" ); }

                  #endif

                  // 

                  return;
            

            }






            // --- INTERATIVOS TELA


            public void Acrescentar_interativos_tela_para_subtrair(   Ponto _ponto, int _tipo_alocar_interativos ,byte[][] _interativos_ids ){

                  Modificar_interativos_genericos( _ponto, Tipo_modificacao_interativo_id.subtrair, Tipo_acao.remover, _tipo_alocar_interativos, _interativos_ids );
                  return;
                  
            }


            public void Acrescentar_interativos_tela_para_adicionar(   Ponto _ponto, int _tipo_alocar_interativos ,byte[][] _interativos_ids ){

                  Modificar_interativos_genericos( _ponto, Tipo_modificacao_interativo_id.adicionar, Tipo_acao.remover, _tipo_alocar_interativos, _interativos_ids );
                  return;
                  
            }

            public void Remover_interativos_tela_para_subtrair(   Ponto _ponto, int _tipo_alocar_interativos ,byte[][] _interativos_ids ){

                  Modificar_interativos_genericos( _ponto, Tipo_modificacao_interativo_id.subtrair, Tipo_acao.remover, _tipo_alocar_interativos, _interativos_ids );
                  return;
                  
            }


            public void Remover_interativos_tela_para_adicionar(   Ponto _ponto, int _tipo_alocar_interativos ,byte[][] _interativos_ids ){

                  Modificar_interativos_genericos( _ponto, Tipo_modificacao_interativo_id.adicionar, Tipo_acao.remover, _tipo_alocar_interativos, _interativos_ids );
                  return;
                  
            }





      public enum Tipo_acao{

            acrescentar, 
            remover,

      }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Modificar_interativos_genericos(   Ponto _ponto, Tipo_modificacao_interativo_id _tipo , Tipo_acao _tipo_acao  ,int _tipo_alocar_interativos ,byte[][] _interativos_ids ){

                  if ( _ponto.ponto_ativo == null )
                        {
                              // --- PONTO ESTA COMPRIMIDO

                              // *** mesmo o array no ponto sendo 1d a funcao vai interar sobre o intervalo
                              byte[][] interativos_por_periodo_atuais_comprimidos =  Manipulador_interativos_COMPRIMIDOS.Garantir_mesmo_formato_interativos( _ponto , _tipo,  _tipo_alocar_interativos , _interativos_ids );

                              if( _tipo_acao == Tipo_acao.acrescentar )
                                    { Manipulador_interativos_COMPRIMIDOS.Acrescentar_interativos_tela( interativos_por_periodo_atuais_comprimidos, _interativos_ids ); } // --- ADICIONAR
                                    else 
                                    { Manipulador_interativos_COMPRIMIDOS.Remover_interativos_tela( interativos_por_periodo_atuais_comprimidos, _interativos_ids ); }     // --- REMOVER 
      
                              //** se nao esta ativo nao precisa fazer nada
                              return;

                        }
                        else 
                        {
                              // --- PONTO ESTA ATIVO

                              Ponto_ativo ponto_ativo = _ponto.ponto_ativo;
                              int periodo = Controlador_timer.Pegar_instancia().periodo_atual_id;

                              byte[][] interativos_por_periodo_atuais_descomprimidos =  Manipulador_interativos_DESCOMPRIMIDOS.Garantir_mesmo_formato_interativos( ponto_ativo , _tipo,  _tipo_alocar_interativos , _interativos_ids );

                              if( _tipo_acao == Tipo_acao.acrescentar )
                                    { Manipulador_interativos_DESCOMPRIMIDOS.Acrescentar_interativos_tela( interativos_por_periodo_atuais_descomprimidos, _interativos_ids ); } // --- ADICIONAR
                                    else 
                                    { Manipulador_interativos_DESCOMPRIMIDOS.Remover_interativos_tela( interativos_por_periodo_atuais_descomprimidos, _interativos_ids ); }     // --- REMOVER 

                              
                              // --- PEGA IDS COM A ATUALIZACAO
                              byte[] novos_ids = Manipulador_interativos_DESCOMPRIMIDOS.Criar_interativos_tela_ids_ponto(  ponto_ativo );
                              byte[] ids_antigos = ponto_ativo.tipos_interativos_tela_por_periodo[ periodo ];
            

                              if( Verificar_se_teve_alteracao_nos_ids( novos_ids, ids_antigos ) )
                                    { controlador_tela_conector.Informar_alteracao_ponto_ativo( _ponto ); } // --- TEVE ALTERACAO

                              return;

                              
                        }
                  
                  return;
                  
            }








            // public void Remover_interativos_tela_para_subtrair(   Ponto _ponto, int _tipo_alocar_interativos ,byte[][] _interativos_ids ){

            //       if ( _ponto.ponto_ativo == null )
            //             {
            //                   // --- PONTO ESTA COMPRIMIDO

            //                   // *** mesmo o array no ponto sendo 1d a funcao vai interar sobre o intervalo
            //                   byte[][] interativos_por_periodo_para_subtrair_atuais =  Manipulador_interativos_COMPRIMIDOS.Garantir_mesmo_formato_interativos( _ponto , Tipo_modificacao_interativo_id.subtrair,  _tipo_alocar_interativos , _interativos_ids );
            //                   Manipulador_interativos_COMPRIMIDOS.Remover_interativos_tela( interativos_por_periodo_para_subtrair_atuais, _interativos_ids );

            //                   //** se nao esta ativo nao precisa fazer nada
            //                   return;

            //             }
            //             else 
            //             {
            //                   // --- PONTO ESTA ATIVO

            //                   Ponto_ativo ponto_ativo = _ponto.ponto_ativo;
            //                   int periodo = Controlador_timer.Pegar_instancia().periodo_atual_id;

            //                   byte[][] interativos_por_periodo_para_subtrair_atuais =  Manipulador_interativos_DESCOMPRIMIDOS.Garantir_mesmo_formato_interativos( ponto_ativo , Tipo_modificacao_interativo_id.subtrair,  _tipo_alocar_interativos , _interativos_ids );
            //                   Manipulador_interativos_DESCOMPRIMIDOS.Remover_interativos_tela( interativos_por_periodo_para_subtrair_atuais, _interativos_ids );

                              
            //                   // --- PEGA IDS COM A ATUALIZACAO
            //                   byte[] novos_ids = Manipulador_interativos_DESCOMPRIMIDOS.Criar_interativos_tela_ids_ponto(  ponto_ativo, _interativos_ids );
            //                   byte[] ids_antigos = ponto_ativo.tipos_interativos_tela_por_periodo[ periodo ];
            

            //                   if( Verificar_se_teve_alteracao_nos_ids( novos_ids, ids_antigos ) )
            //                         { controlador_tela_conector.Informar_alteracao_ponto_ativo( _ponto ); } // --- TEVE ALTERACAO

            //                   return;

                              
            //             }
                  
            //       return;
                  
            // }




            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Verificar_se_teve_alteracao_nos_ids( byte[] _ids_novos, byte[] _ids_antigos ){


                  if( _ids_novos.Length != _ids_antigos.Length )
                        {
                              // --- NUMERO DE ELEMENTOS DIFERENTES => TEVE ALTERACAO
                              return true;
                        }

                  // *** ids sempre sao exatos e sem 0

                  for( int index_novos = 0 ; index_novos < _ids_novos.Length ; index_novos++ ){

   
                        // --- VERIFICA SE O ID EXISTE NO ANTIGO
                        for( int index_antigo = 0 ; index_antigo < _ids_antigos.Length  ;  index_antigo++ ){

                              // --- VERIFICA SE O ID_NOVO ESTA NO ID_ANTIGO
                              if( _ids_antigos[ index_antigo ] == _ids_novos[ index_novos ] )
                                    {
                                          // --- JA EXISTIA, VERIFICAR O PROXIMO NOVO
                                          break;
                                    }

                              if( index_antigo == ( _ids_antigos.Length - 1 ) )
                                    {
                                          // --- ULTIMO ELEMENTO E AINDA NAO FOI ACHADO => NAO TEM => TEVE ALTERACAO
                                          return true;
                                    }

                        }

                        // --- ELEMNTE DO LOOP FOI ACHADO, VERIFICAR O PROXIMO
                        continue;

                  }

                  // --- NENHUM ERA DIFERENTE
                  return false;

            }




            // [MethodImpl(MethodImplOptions.AggressiveInlining)]
            // private void Verificar_ponto( Ponto _ponto ){

            //       if( _ponto.ponto_esta_sendo_monitorado )
            //             { 
            //                   // --- ATUALIZA PONTOS
            //                   Atualizar_interativos_tela_ponto( _ponto );

            //                   // --- TROCA TELA COM OS NOVOS INTRATIVOS
            //                   // *** talvez trave se muitos scripts adicionarem ou removerem interativos em sequencia
            //                   controlador_tela_conector.Trocar_tela( _ponto :_ponto.ponto_esta_sendo_monitorado, _tem_transicao :false );
            //             }


            //       return;

            // }




            public void Atualizar_interativos_tela_ponto( Ponto _ponto ){


                  // *** aqui ele vai ter que criar um byte[] com os interativos dos periodos

                  //  pode ter algumas coisas como default => arr[ 1 ], sub => arr[ 2 ], add => arr[ 5 ]
                  //  ele nao pode mudar os interativos pois seria muita memoria, e vai ser refeito no proximo frame de qualquer jeito



            }




            public Interativo_item[] Criar_interativos_item( Ponto _ponto ){

                  throw new Exception( "ainda tem que fazer" );

            }


            public Interativo_personagem[] Criar_interativos_personagem( Ponto _ponto ){

                  throw new Exception( "ainda tem que fazer" );
                  
            }


            public Interativo_tela[] Criar_interativos_tela( Ponto _ponto  ){

                  #if UNITY_EDITOR

                        return Criar_interativos_tela_DEVELOPMENT( _ponto );

                  #else

                        return Criar_interativos_tela_BUILD( _ponto );

                  #endif


            }


            private Interativo_tela[] Criar_interativos_tela_BUILD( Ponto _ponto  ){  
                  

                  // int ponto_id = ( int ) _ponto.ponto_id;
                  // int periodo_atual_id = Controlador_timer.Pegar_instancia().periodo_atual_id;

                  // // --- PEGAR INTERATIVOS 
                  // byte[][] interativos_default_PERIODOS = _ponto.interativos_tipo_tela_default_ids;
                  // byte[][] interativos_para_adicionar_PERIODOS = _ponto.interativos_por_periodo_para_adicionar;
                  // byte[][] interativos_para_subtrair_PERIODOS = _ponto.interativos_por_periodo_para_subtrair;

                  // // --- PEGAR INTERATIVOS DO PERIODO
                  // byte[] interativos_default = Manipulador_interativos_DESCOMPRIMIDOS.Pegar_interativos_com_alocacao_comprimida( interativos_default_PERIODOS , periodo_atual_id );
                  // byte[] interativos_para_adicionar = Manipulador_interativos_DESCOMPRIMIDOS.Pegar_interativos_com_alocacao_comprimida( interativos_para_adicionar_PERIODOS , periodo_atual_id );
                  // byte[] interativos_para_subtrair = Manipulador_interativos_DESCOMPRIMIDOS.Pegar_interativos_com_alocacao_comprimida( interativos_para_subtrair_PERIODOS , periodo_atual_id );

                  // // --- PEGAR FINAL
                  // byte[] interativos_finais = BYTE.Aplicar_subtrair_e_adicionar_array( interativos_default, interativos_para_subtrair, interativos_para_adicionar );
                  // interativos_finais = BYTE.Remover_valor( interativos_finais, 0 );

                  // Interativo_tela[] interativos_retorno = Leitor_interativos_tela.Pegar_interativos_tela(  _ponto.posicao,  interativos_finais );

                  // return interativos_retorno; 

                  return null;
                  
            }


            // #if UNITY_EDITOR
            // #end

                  private Interativo_tela[] Criar_interativos_tela_DEVELOPMENT( Ponto _ponto ){


                        // int periodo = Controlador_timer.Pegar_instancia().periodo_atual_id;

                        // byte[][] interativos_tipo_tela_default_ids_por_periodo  =  _ponto.ponto_ativo.interativos_tipo_tela_default_ids_por_periodo ;
                        // byte[][] interativos_para_adicionar_por_posicao_por_periodo  = _ponto.ponto_ativo.interativos_por_periodo_para_adicionar;
                        // byte[][] interativos_para_subtrair_por_posicao_por_periodo  =  _ponto.ponto_ativo.interativos_por_periodo_para_subtrair;
                        

                        // // --- GARANTE QUE TODOS EXISTEM
                        // Verificador_interativos_DEVELOPMENT.Verificar_interativos_ids( _ponto, interativos_default_por_posicao, interativos_para_subtrair_por_posicao_por_periodo, interativos_para_adicionar_por_posicao_por_periodo ) ;
                        

                        // byte[] interativos_default = interativos_tipo_tela_default_ids_por_periodo[ periodo ];
                        // byte[] interativos_para_subtrair = _ponto.ponto_ativo.interativos_por_periodo_para_subtrair[ periodo ];
                        // byte[] interativos_para_adicionar = _ponto.ponto_ativo.interativos_por_periodo_para_adicionar[ periodo ];


                        // byte[] interativos_finais_ids = BYTE.Aplicar_subtrair_e_adicionar_array( interativos_default , interativos_para_subtrair, interativos_para_adicionar );


                        // Interativo_tela[] interativos_tipo_tela_retorno = new Interativo_tela[ interativos_finais_ids.Length ] ;


                        // for( int interativo_slot = 0 ; interativo_slot < interativos_finais_ids.Length ; interativo_slot++ ){


                        //             // byte interativo_id = interativos_finais_ids[ interativo_slot ];

                        //             // //Interativo_tela_DADOS_DESENVOLVIMENTO 
                        //             // Interativo_tela_DADOS_DESENVOLVIMENTO interativo_Tela_DADOS_DESENVOLVIMENTO = Leitor_interativos_tela.Pegar_interativo( _ponto.posicao , interativo_id );
                        //             // Interativo_tela interativo_tela = Construtor_interativos_DEVELOPMENT.Criar_interativo_tela_com_DADOS_DEVELOPMENT( interativo_Tela_DADOS_DESENVOLVIMENTO );
                                    
                        //             // interativos_tipo_tela_retorno[ interativo_slot ] = interativo_tela;

                        //             continue;

                        // }

                        // return interativos_tipo_tela_retorno;                        

                        return null;

                  }



    





            public void Ativar_interativo_tela( Interativo_tela _interativo_tela ){

                        Tipo_interativo_tela tipo = _interativo_tela.tipo_interativo_tela;
                  
                        switch( tipo  ){

                              case Tipo_interativo_tela.movimento: Receptor_interativo_tela_movimento.Receber( _interativo_tela ); return;
                              // case Tipo_interativo_tela.conversa: Receber_personagem( interativo ); return;
                              // case Tipo_interativo_tela.item: Receber_item( interativo ); return;
                              // case Tipo_interativo_tela.cenas: Receber_visual_novel( interativo ); return;
                              // case Tipo_interativo_tela.utilidade: Receber_utilidade( interativo ); return;

                        }

            }



            public void Ativar_interativo_personagem( Interativo_personagem _interativo_personagem ){

                         

                        Tipo_interativo_personagem tipo = _interativo_personagem.tipo_interativo_personagem;
                  
                        switch( tipo  ){

                              //case Tipo_interativo_personagem.conversa: Receptor_interativo_tela_movimento.Receber( _interativo_tela ); return;


                        }

            }


            public void Ativar_interativo_item( Interativo_item _interativo_item ){

                         
                        Tipo_interativo_item tipo = _interativo_item.tipo_interativo_item;
                  
                        switch( tipo  ){

                              case Tipo_interativo_item.item: return; 


                        }

            }




            public void Esconder_interativos( bool _valor ){

                        interativos_container.SetActive( !_valor );
                        return;

            }



            




}