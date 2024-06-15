
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



}







#endif