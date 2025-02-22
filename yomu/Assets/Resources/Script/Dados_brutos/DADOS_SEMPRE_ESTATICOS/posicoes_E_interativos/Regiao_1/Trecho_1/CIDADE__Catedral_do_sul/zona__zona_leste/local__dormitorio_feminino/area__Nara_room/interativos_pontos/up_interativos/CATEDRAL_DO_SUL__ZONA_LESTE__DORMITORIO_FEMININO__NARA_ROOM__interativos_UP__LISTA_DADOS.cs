using UnityEngine;
using System;



#if UNITY_EDITOR && ( REGIAO_1 || REGIAO_1__trecho_1 || REGIAO_1__CATEDRAL_DO_SUL || FORCAR_TUDO  )


        public static class CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__interativos_UP__LISTA_DADOS {

                public static Interativo_tela_DADOS_DESENVOLVIMENTO[] dados;

                public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar_interativo(  Locator_position _posicao,  int _interativo_id  ){

                    int ponto_id = _posicao.local_position.ponto_id;

                    if( dados == null )
                            { 
                                Colocar_interativos(); 

                                Type tipo_interativo = typeof( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__UP__interativo );
                                string nome_area = typeof( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__ponto ).Namespace;

                            }

                    if( dados[ _interativo_id ] == null )
                            { throw new Exception( $" o interativo { ( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__UP__interativo ) _interativo_id } na nao foi criado" ); }

                    if( ponto_id != dados[ _interativo_id ].ponto_id )
                            { 
                                    Debug.LogError( "O ponto_id estava diferente em CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__interativos_UP__LISTA_DADOS.Pegar().");
                                    Debug.LogError( $" O id que veio foi: { ponto_id } e oque tinha sido definido no interativo foi { dados[ _interativo_id ].ponto_id }" );
                                    throw new Exception(); 
                            }

                    return dados[ _interativo_id ];

                }


                public static void Colocar_interativos(){

                        dados = new Interativo_tela_DADOS_DESENVOLVIMENTO[ 100 ];

                        // --- ZERO

                        int index = 0;

                        // ------------------ 
                        
                                index = (int) CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__UP__interativo.espelho;

                        dados[ index ] = new Interativo_tela_DADOS_DESENVOLVIMENTO( index );

                        // faz sentido?
                        dados[ index ].ponto_id = ( int ) CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__ponto.up;

                        // funcao
                        dados[ index ].tipo_interativo =  Tipo_interativo_tela.movimento;
                        
                        // --- cursor
                        dados[ index ].metodo_para_mudar_cursor = Metodo_para_mudar_cursor.cor_unica;
                        dados[ index ].cores_cursor = null;
                        dados[ index ].cor_cursor = Cor_cursor.red;

                        // imagem
                        dados[ index ].metodo_FOLDER_que_as_imagens_estao_salvas = Metodo_FOLDER_que_as_imagens_estao_salvas.contexto_area;
                        dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;
                        dados[ index ].metodo_IMAGENS_DISPONIVEIS_no_mouse_hover = Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover.one_E_one;
                        dados[ index ].metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover = Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover.core_80_e_100;




                        dados[ index ].area = new float[]{

                            1189f,36f,
                            1280f,247f,
                            1374f,298f,
                            1385f,290f,
                            1299f,101f,
                            1364f,60f,
                            1289f,0f,
                            1244f,0f,
                            1189f,36f,
                            
                        };

                        


                }




        }


#endif






