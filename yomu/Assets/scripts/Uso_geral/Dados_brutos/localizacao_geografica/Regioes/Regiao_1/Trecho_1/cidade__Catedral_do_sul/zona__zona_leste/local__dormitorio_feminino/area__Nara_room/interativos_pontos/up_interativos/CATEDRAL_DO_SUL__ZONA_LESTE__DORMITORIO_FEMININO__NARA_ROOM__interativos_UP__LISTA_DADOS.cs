using UnityEngine;
using System;

/*

    nao vai existir no jogo, somente no editor
    quando for construir a build =>  compilar para pegar o byte_arr => criar novo .dat
    sempre deixar a ram o .dat com a cidade inteira. se ficar muito grande pode trocar para regiao

*/

                                             
#if UNITY_EDITOR && ( REGIAO_1 || REGIAO_1__trecho_1 || REGIAO_1__CATEDRAL_DO_SUL || FORCAR_TUDO  )



        public static class CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__interativos_UP__LISTA_DADOS {

                public static Interativo_tela_DADOS_DESENVOLVIMENTO[] dados;

                public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar_interativo(  Posicao _posicao,  int _interativo_id  ){

                    int ponto_id = _posicao.ponto_id;

                    if( dados == null )
                            { 
                                Colocar_interativos(); 

                                Type tipo_interativo = typeof( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__UP__interativo );
                                string nome_area = typeof( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__ponto ).Namespace;

                                Marcador_de_nomes_DEVELOPMENT.Colocar_nome_interativo_tela( tipo_interativo, nome_area, dados );
                                Verificador_interativos_tela_DESENVOLVIMENTO.Verificar  ( ref dados );

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
                        dados[ index ].tipo_interativo =  Tipo_interativo.movimento;
                        
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









                        //         index = (int) Interativo_nome.MESA_up_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.movimento;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // //dados[ index ].ponto_destino = Ponto_nome.MESA_quarto_nara;
                        // dados[ index ].ponto_destino = Ponto_nome.UP_quarto_nara ;

                        // dados[ index ].ponto_nome = Ponto_nome.UP_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.red;

                        // dados[ index ].area = new float[]{

                        // 1448f,457f,
                        // 1468f,572f,
                        // 1464f,578f,
                        // 1448f,587f,
                        // 1449f,602f,
                        // 1439f,604f,
                        // 1434f,596f,
                        // 1423f,602f,
                        // 1430f,613f,
                        // 1425f,637f,
                        // 1407f,612f,
                        // 1398f,614f,
                        // 1398f,641f,
                        // 1377f,642f,
                        // 1358f,632f,
                        // 1355f,647f,
                        // 1310f,671f,
                        // 1309f,677f,
                        // 1278f,688f,
                        // 1276f,701f,
                        // 1241f,715f,
                        // 1218f,702f,
                        // 1216f,691f,
                        // 1205f,683f,
                        // 1196f,687f,
                        // 1184f,677f,
                        // 1183f,667f,
                        // 1145f,647f,
                        // 1144f,524f,
                        // 1176f,471f,
                        // 1259f,420f,
                        // 1308f,451f,
                        // 1368f,397f,
                        // 1448f,457f



                        // };



                        //         index = (int) Interativo_nome.JANELA_up_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.movimento;
                        // dados[ index ].ponto_destino = Ponto_nome.UP_quarto_nara ;

                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;
                        // dados[ index ].ponto_nome = Ponto_nome.UP_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.red;



                        // dados[ index ].area = new float[]{
                            
                        // 1067f,877f,
                        // 1072f,982f,
                        // 1213f,911f,
                        // 1206f,805f,
                        // 1067f,877f


                        //     };



                        //         index = (int) Interativo_nome.CAMA_up_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.movimento;
                        // dados[ index ].ponto_destino = Ponto_nome.UP_quarto_nara ;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;


                        // dados[ index ].ponto_nome = Ponto_nome.nada;

                        // dados[ index ].cor_cursor = Cor_cursor.red;

                        // //dados[ index ].script_jogo_nome = Script_jogo_nome.teste;

                        // dados[ index ].area = new float[]{
                            
                        // 698f,667f,
                        // 716f,677f,
                        // 959f,826f,
                        // 972f,818f,
                        // 987f,827f,
                        // 1000f,810f,
                        // 1037f,792f,
                        // 1059f,777f,
                        // 1079f,775f,
                        // 1069f,762f,
                        // 1096f,746f,
                        // 1094f,677f,
                        // 1030f,637f,
                        // 1034f,612f,
                        // 1012f,609f,
                        // 1006f,596f,
                        // 969f,589f,
                        // 950f,576f,
                        // 941f,564f,
                        // 922f,559f,
                        // 880f,528f,
                        // 874f,513f,
                        // 870f,518f,
                        // 832f,502f,
                        // 823f,502f,
                        // 813f,518f,
                        // 801f,517f,
                        // 788f,532f,
                        // 752f,536f,
                        // 743f,552f,
                        // 743f,584f,
                        // 738f,616f,
                        // 728f,641f,
                        // 720f,655f,
                        // 698f,667f

                        //     };



                        //         index = (int) Interativo_nome.BURACO_up_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.movimento;
                        // dados[ index ].ponto_destino = Ponto_nome.UP_quarto_nara ;

                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite ;
                        // dados[ index ].ponto_nome = Ponto_nome.UP_quarto_nara ;
                        // dados[ index ].cor_cursor = Cor_cursor.blue ;

                        // dados[ index ].area = new float[]{
                        // 728f,887f,
                        // 737f,771f,
                        // 777f,841f,
                        // 728f,887f



                            
                        //     };


                        //     index = (int) Interativo_nome.BAU_up_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.movimento;
                        // dados[ index ].ponto_destino = Ponto_nome.UP_quarto_nara ;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // dados[ index ].ponto_nome = Ponto_nome.UP_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.red;

                        // dados[ index ].area = new float[]{

                        // 718f,506f,
                        // 746f,522f,
                        // 745f,597f,
                        // 733f,627f,
                        // 715f,652f,
                        // 688f,671f,
                        // 672f,671f,
                        // 670f,667f,
                        // 559f,604f,
                        // 715f,509f,
                        // 718f,506f
                            
                        //     };



                        //     index = (int) Interativo_nome.CLOSET_up_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.movimento;
                        // dados[ index ].ponto_destino = Ponto_nome.UP_quarto_nara ;

                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // dados[ index ].ponto_nome = Ponto_nome.UP_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.red;

                        // dados[ index ].area = new float[]{
                        // 678f,23f,
                        // 383f,272f,
                        // 379f,295f,
                        // 374f,298f,
                        // 305f,646f,
                        // 407f,700f,
                        // 763f,483f,
                        // 780f,257f,
                        // 673f,337f,
                        // 652f,325f,
                        // 678f,23f



                            
                        //     };



                        //         index = (int) Interativo_nome.PORTA_up_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.movimento;
                        // dados[ index ].ponto_destino = Ponto_nome.UP_quarto_nara ;

                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;
                        // dados[ index ].ponto_nome = Ponto_nome.UP_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.pink;


                        // dados[ index ].area = new float[]{
                        // 900f,0f,
                        // 894f,174f,
                        // 671f,335f,
                        // 651f,324f,
                        // 677f,0f,
                        // 900f,0f
                            
                        //     };







                        // ///-------- FRONT

                        //         index = (int) Interativo_nome.MESA_front_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.movimento;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;
                        // dados[ index ].ponto_destino = Ponto_nome.MESA_quarto_nara ;
                        // dados[ index ].ponto_nome = Ponto_nome.FRONT_quarto_nara ;
                        // dados[ index ].cor_cursor = Cor_cursor.red;

                        // dados[ index ].area = new float[]{


                        // 313f,76f,
                        // 219f,0f,
                        // 0f,0f,
                        // 0f,578f,
                        // 163f,582f,
                        // 163f,647f,
                        // 279f,707f,
                        // 312f,706f,
                        // 313f,76f


                            
                        // };




                        //         index = (int) Interativo_nome.ESPELHO_front_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.cenas; // ativa espelho para ter a Tipo_interativo.movimento 
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite ;
                        // dados[ index ].ponto_nome = Ponto_nome.FRONT_quarto_nara ;
                        // dados[ index ].cor_cursor = Cor_cursor.red ;

                        // dados[ index ].area = new float[]{

                        // 795f,179f,
                        // 810f,972f,
                        // 1129f,974f,
                        // 1144f,179f,
                        // 795f,179f
                            
                        //     };



                        //         index = (int) Interativo_nome.CORREDOR_front_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.movimento;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;
                        // dados[ index ].ponto_destino = Ponto_nome.CORREDOR_quarto_nara;
                        // dados[ index ].ponto_nome = Ponto_nome.FRONT_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.red;

                        // dados[ index ].area = new float[]{
                        // 1817f,96f,
                        // 1815f,1080f,
                        // 1609f,1080f,
                        // 1604f,215f,
                        // 1817f,96f
                            
                        //     };




                        //         index = (int) Interativo_nome.LILY_corredor_1;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.personagem;
                        
                        // dados[ index ].conversa_nome = "teste";

                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.nao_altera;

                        // dados[ index ].personagem = Personagem_nome.Lily;

                        // dados[ index ].tipo_mouse_hover = Interativo_tipo_mouse_hover.one_E_one;

                        // dados[ index ].ponto_nome = Ponto_nome.FRONT_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.red;

                        // dados[ index ].area = new float[]{
                        // 0f,0f,
                        // 0f,1080f,
                        // 1920f,1080f,
                        // 1920f,0f,
                        // 0f,0f
                            
                        //     };














                        // /*

                        // por hora nao usei


                        //     //----------------------------------- drawer

                        // dados[20].tipo =  Tipo_interativo.movimento;
                        // dados[20].script_jogo_nome = 1 ;
                        // dados[20].ponto_nome = 36;
                        // dados[20].cor_cursor = Cor_cursor.red;

                        // dados[20].area = new float[]{
                        // 1918f,242f,
                        // 1830f,305f,
                        // 1828f,100f,
                        // 1916f,19f,
                        // 1918f,242f
                            
                        //     };


                        // */





                        // //---------------- BACK


                        // /*

                        // por hora nao usei 

                        // //----------------------------------- closet

                        // dados[25].tipo =  Tipo_interativo.movimento;
                        // dados[].nome = "back_closet";
                        // dados[25].ponto_destino = 5 ;
                        // dados[25].ponto_nome = 38;
                        // dados[25].cor_cursor = Cor_cursor.red;

                        // dados[25].area =  new float[]{

                        // 0f,337f,
                        // 83f,389f,
                        // 83f,1080f,
                        // 0f,1080f,
                        // 0f,337f


                            
                            
                        //     };

                        //     //----------------------------------- bau

                        // dados[26].tipo =  Tipo_interativo.movimento;
                        // dados[26].ponto_destino = 9 ;
                        // dados[26].ponto_nome = 38;
                        // dados[26].cor_cursor = Cor_cursor.red;

                        // dados[26].area =  new float[]{

                        // 230f,106f,
                        // 869f,103f,
                        // 887f,209f,
                        // 889f,462f,
                        // 884f,502f,
                        // 875f,512f,
                        // 302f,518f,
                        // 288f,517f,
                        // 262f,493f,
                        // 229f,404f,
                        // 228f,106f,
                        // 230f,106f

                            
                            
                        //     };

                        //     */






                        //         index = (int) Interativo_nome.BURACO_back_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.nao_altera;


                        // dados[ index ].ponto_nome = Ponto_nome.BACK_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.red;

                        // dados[ index ].area =  new float[]{


                        // 1053f,1055f,
                        // 1050f,780f,
                        // 1250f,917f,
                        // 1053f,1055f



                            
                            
                        //     };


                        //         index = (int) Interativo_nome.CAMA_back_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.cenas;
                        



                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;
                        // dados[ index ].ponto_nome = Ponto_nome.BACK_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.red;

                        // dados[ index ].area =  new float[]{

                        // 995f,95f,
                        // 994f,135f,
                        // 985f,166f,
                        // 990f,205f,
                        // 1000f,272f,
                        // 1002f,443f,
                        // 1684f,447f,
                        // 1682f,462f,
                        // 1860f,526f,
                        // 2403f,350f,
                        // 1921f,113f,
                        // 1841f,96f,
                        // 1609f,90f,
                        // 1079f,90f,
                        // 995f,95f
                            
                            
                        //     };




                        // ///----------------CORREDOR


                        //         index = (int) Interativo_nome.MACANETA_corredor_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas =   Metodo_que_as_imagens_estao_salvas.dia_E_noite;
                        // dados[ index ].ponto_nome = Ponto_nome.CORREDOR_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.red;

                        // dados[ index ].area =  new float[]{

                        // 1309f,656f,
                        // 1290f,481f,
                        // 1384f,474f,
                        // 1403f,665f,
                        // 1309f,656f


                            
                        //     };




                        // ///------------------------- DESK



                                
                        //         index =  ( int ) Interativo_nome.LIVRO_1_mesa_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // dados[ index ].ponto_nome = Ponto_nome.MESA_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.green;

                        // dados[ index ].area =  new float[]{


                        // 138f,897f,
                        // 59f,821f,
                        // 51f,800f,
                        // 63f,763f,
                        // 453f,768f,
                        // 498f,850f,
                        // 494f,899f,
                        // 138f,897f



                        //     };


                        // //----------------------------------- 

                        //         index =  ( int ) Interativo_nome.LIVRO_2_mesa_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // dados[ index ].ponto_nome = Ponto_nome.MESA_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.green;

                        // dados[ index ].area =  new float[]{

                        // 63f,768f,
                        // 44f,751f,
                        // 40f,727f,
                        // 46f,710f,
                        // 54f,702f,
                        // 438f,705f,
                        // 483f,782f,
                        // 476f,810f,
                        // 453f,770f,
                        // 63f,768f



                        //     };

                        // //----------------------------------- 


                        //         index =  ( int ) Interativo_nome.LIVRO_3_mesa_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // dados[ index ].ponto_nome = Ponto_nome.MESA_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.green;

                        // dados[ index ].area =  new float[]{

                        // 53f,701f,
                        // 49f,707f,
                        // 23f,681f,
                        // 18f,662f,
                        // 19f,636f,
                        // 29f,616f,
                        // 452f,617f,
                        // 497f,722f,
                        // 492f,776f,
                        // 477f,773f,
                        // 438f,705f,
                        // 53f,701f


                        //     };


                        // //----------------------------------- 


                        //         index =  ( int ) Interativo_nome.LIVRO_4_mesa_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // dados[ index ].ponto_nome = Ponto_nome.MESA_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.green;

                        // dados[ index ].area =  new float[]{


                        // 548f,712f,
                        // 549f,742f,
                        // 708f,820f,
                        // 833f,788f,
                        // 833f,758f,
                        // 672f,658f,
                        // 548f,712f


                        //     };

                        // //----------------------------------- 


                        //         index =  ( int ) Interativo_nome.LIVRO_5_mesa_quarto_nara;
                            
                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // dados[ index ].ponto_nome = Ponto_nome.MESA_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.green;

                        // dados[ index ].area =  new float[]{

                        // 792f,728f,
                        // 788f,651f,
                        // 556f,642f,
                        // 548f,671f,
                        // 568f,731f,
                        // 773f,740f,
                        // 792f,728f



                        //     };


                        //         index =  ( int ) Interativo_nome.LIVRO_6_mesa_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // dados[ index ].ponto_nome = Ponto_nome.MESA_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.green;


                        // dados[ index ].area =  new float[]{


                        // 782f,737f,
                        // 826f,732f,
                        // 835f,716f,
                        // 831f,692f,
                        // 693f,568f,
                        // 522f,616f,
                        // 524f,657f,
                        // 643f,730f,
                        // 782f,737f



                        //     };



                        // //______________caixa


                        //         index =  ( int ) Interativo_nome.CAIXA_mesa_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // dados[ index ].ponto_nome = Ponto_nome.MESA_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.green;

                        // dados[ index ].area =  new float[]{

                        // 884f,609f,
                        // 884f,757f,
                        // 890f,787f,
                        // 1156f,786f,
                        // 1173f,762f,
                        // 1174f,607f,
                        // 884f,609f

                        //     };



                            
                        //         index =  ( int ) Interativo_nome.CARTAS_mesa_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.dia_E_noite;
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.dia_E_noite;

                        // dados[ index ].ponto_nome = Ponto_nome.MESA_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.green;
                        // dados[ index ].area =  new float[]{

                        // 1425f,613f,
                        // 1425f,752f,
                        // 1382f,830f,
                        // 1379f,826f,
                        // 1377f,728f,
                        // 1312f,726f,
                        // 1309f,755f,
                        // 1279f,832f,
                        // 1279f,721f,
                        // 1305f,613f,
                        // 1425f,613f



                        //     };



                        //     //______________tinta


                        //         index =  ( int ) Interativo_nome.TINTA_mesa_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;


                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.dia_E_noite; // imagens por tempo

                        // // lily_comendo_biscoite__MANHA_1
                        
                        // dados[ index ].tipo_mouse_hover = Interativo_tipo_mouse_hover.nada_E_nada;  // cores da imagem


                        // dados[ index ].ponto_nome = Ponto_nome.MESA_quarto_nara;

                        // dados[ index ].cor_cursor = Cor_cursor.green;
                        // dados[ index ].cor_cursor = Cor_cursor.green;

                        // dados[ index ].cores_cursor = new Cor_cursor[]{



                        // };


                        // dados[ index ].area =  new float[]{


                        //     1860f,623f,
                        //     1863f,632f,
                        //     1800f,718f,
                        //     1767f,800f,
                        //     1719f,800f,
                        //     1667f,727f,
                        //     1617f,723f,
                        //     1658f,830f,
                        //     1641f,905f,
                        //     1563f,818f,
                        //     1568f,723f,
                        //     1528f,723f,
                        //     1526f,708f,
                        //     1579f,623f,
                        //     1860f,623f


                        // };














                        //         index =  ( int ) Interativo_nome.CARTA_DIA_mesa_quarto_nara;

                        // dados[ index ] = new Interativo_tela( index );
                        // dados[ index ].tipo_interativo =  Tipo_interativo.utilidade;
                        
                        // dados[ index ].metodo_que_as_imagens_estao_salvas = Metodo_que_as_imagens_estao_salvas.nao_altera;

                        // dados[ index ].tipo_mouse_hover = Interativo_tipo_mouse_hover.one_80_E_one_100;
                        // dados[ index ].ponto_nome = Ponto_nome.MESA_quarto_nara;
                        // dados[ index ].cor_cursor = Cor_cursor.pink;


                        // dados[ index ].area =  new float[]{



                        // 1171f,547f,
                        // 960f,414f,
                        // 813f,514f,
                        // 1027f,624f,
                        // 1171f,547f

                            


                        // };
