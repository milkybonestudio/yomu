using System;

#if UNITY_EDITOR || true


        public static class Teste_cidades_DEVELOPMENT {



                public static void Verificar_se_cidade_realmente_foi_pedida( int slot_teste, int _cidade_id , Task_req[] requisicoes_cidades , Dados_containers_cidade[] dados_containers_cidades ,  System.Object[] cidades_AIS  ){


                        if( requisicoes_cidades[ slot_teste] == null )
                                {
                                        if( dados_containers_cidades[ slot_teste ] == null || cidades_AIS[ slot_teste ] == null )
                                                {       
                                                        Console.Log("-------------------<color=red> ERRO </Color> ----------------------");
                                                        Console.LogError( $"em dados_dinamicos personagem o personagem { (  ( Personagem_nome ) _cidade_id  ).ToString() } nao foi excluido corretamente" );
                                                        Console.Log("-----------------------------------------------");
                                                        throw new Exception();
                                                }
                                }


                }


        }




#endif