
#if UNITY_EDITOR

using System;




public static class Teste_play {


    public static void Verificar_se_personagem_realmente_foi_pedido( int slot_teste, int _personagem_id , Task_req[] requisicoes_personagens , Dados_containers_personagem[] dados_containers_personagens ,  System.Object[] personagens_AIs  ){


            if( requisicoes_personagens[ slot_teste] == null )
                    {
                            if( dados_containers_personagens[ slot_teste ] == null || personagens_AIs[ slot_teste ] == null )
                                    {       
                                            Console.Log("-------------------<color=red> ERRO </Color> ----------------------");
                                            Console.LogError( $"em dados_dinamicos personagem o personagem { (  ( Personagem_nome ) _personagem_id  ).ToString() } nao foi excluido corretamente" );
                                            Console.Log("-----------------------------------------------");
                                            throw new Exception();
                                    }
                    }


    }

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