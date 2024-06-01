using UnityEngine;
using System;
using System.Reflection;




public static class Teste_movimento {


        // ** criar ferramentas de suporte 

        public static void Criar(){
                

                // mudar update jogo para movimento
                // ** definir os dados do teste 
                

                Jogo.Pegar_instancia().bloco_atual = Bloco.movimento;
                
                Definir_estado_jogo_1();





        }

        

        public static void Ferramenta_1(){


                // Ferramenta do update 


        
        // var b =   s.GetType("teste_dll.Math_teste").GetMethod("Somar");
        // Action action = DelegateBuilder.BuildDelegate<Action<float, float>>( b );
        // flow d = new flow( b );
        // b c = new b();
        // float g =  (float) b.Invoke(   null , new System.Object[] {  1f,1f  }   );
        // float x  = 0f;





        }



        public static void Ferramenta_1_update(){


                // vai ser chamado no bloco de desenvolvimento

                Debug.Log( "esta atualizando as ferramentas" );


        }



        public static void Definir_estado_jogo_1(){

                // --- construir personagem

                Personagem lily = new Personagem();
                lily.dados_sistema = new Dados_sistema_personagem();
                lily.dados_sistema.personagem_esta_ativo = true;
                lily.dados_sistema.nome_personagem = Personagem_nome.Lily;

                // funcionou
                Controlador_dados_dinamicos.Pegar_instancia().dados_run_time.Carregar_personagem( lily );

                

                // ---------------------

                Controlador_personagens.Pegar_instancia().personagens[ ( int ) Personagem_nome.Lily ] = lily;
                return;



        }


}