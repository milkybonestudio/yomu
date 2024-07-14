using System;

#if UNITY_EDITOR || true


        public static class Teste_plots_DEVELOPMENT {


                public static void Verificar_se_plot_realmente_foi_pedido( int slot_teste, int _plot_id , Task_req[] requisicoes_plots , Dados_containers_plot[] dados_containers_plots ,  System.Object[] plots_AIS  ){


                        if( requisicoes_plots[ slot_teste] == null )
                                {
                                        if( dados_containers_plots[ slot_teste ] == null || plots_AIS[ slot_teste ] == null )
                                                {       
                                                        Console.Log("-------------------<color=red> ERRO </Color> ----------------------");
                                                        Console.LogError( $"em dados_dinamicos personagem o personagem { (  ( Personagem_nome ) _plot_id  ).ToString() } nao foi excluido corretamente" );
                                                        Console.Log("-----------------------------------------------");
                                                        throw new Exception();
                                                }
                                }


                }




        }







#endif