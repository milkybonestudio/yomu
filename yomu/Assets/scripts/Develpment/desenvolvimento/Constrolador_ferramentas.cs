using UnityEngine;

public static class Controlador_ferramentas {


        public static void Atualizar_ferramentas_desenvolvimento() {
            // aqui pode criar as ferramentas 
            // vai ser criadas com as F teclas. F1, F2 ... 


            Desenvolvimento desenvolvimento = Desenvolvimento.Pegar_instancia();

            KeyCode chave = KeyCode.Space;


            // --- LOCALIZADOR_PERSONAGENS

            chave = Chaves_ferramentas.Pegar_chave( Ferramenta_desenvolvimento.localizador_personagens );

            if( Input.GetKeyDown( chave ) )
                {


                    if( desenvolvimento.ferramenta_atual == Ferramenta_desenvolvimento.localizador_personagens )
                        { 

                            desenvolvimento.ferramenta_atual = Ferramenta_desenvolvimento.nada;
                            // deletar 

                            return;

                        }

                    if( desenvolvimento.ferramenta_atual != Ferramenta_desenvolvimento.nada )
                        {
                            // --- DESTRUI ANTIGO

                        }

            
                    // criar

                    return;

                }


        }


}