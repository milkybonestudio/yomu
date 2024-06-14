
#if UNITY_EDITOR

using System;




public class static Teste_play {


    public static void Verificar_se_personagem_realmente_foi_pedido( int slot_teste, Task_req[] requisicoes_personagens , Dados_containers_personagem[] dados_containers_personagens ,  System.Object[] personagens_AIs  ){


            if( requisicoes_personagens[ slot_teste] == null )
                    {
                            if( dados_containers_personagens[ slot_teste ] == null || personagens_AIs[ slot_teste ] == null )
                                    {       
                                            Debug.Log("-------------------<color=red> ERRO </Color> ----------------------");
                                            Debug.LogError( $"em dados_dinamicos personagem o personagem { (  ( Personagem_nome ) _personagem_id  ).ToString() } nao foi excluido corretamente" )
                                            Debug.Log("-----------------------------------------------");
                                            throw new Exception();
                                    }
                    }


    }



}







#endif