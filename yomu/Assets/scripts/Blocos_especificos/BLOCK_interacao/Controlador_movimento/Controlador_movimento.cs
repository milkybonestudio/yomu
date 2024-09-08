using UnityEngine;


public class Controlador_movimento {


        /*


                tipos de movimento:



                Movimentar_PONTO(); 

                Movimento_LOCAL();

                Movimento_CIDADE();


                perto : movimenta dentro do mesmo local
                
                longe : movimenta entre dimensoes maiores 

                       zona   :  zona
                       cidade :  cidade
                       regiao :  regiao
                


                visao_ampla : movimenta entre blocos, pode custar tempo
                        
                todo zona_1.local_0 sepre vai ser o minimapa que leva para algum local

                todo cidade_1.zona_0 sempre vai ser o minimapa que leva para algum local, e a partir de zona sempre precisa ter o quanto que custa


                se um personagem sem ser o player for se movimentar com custo o personagem fica no limbo até que o custo seja efetivado

                todo mover precisa mover o player para algum ( 0 0 0 00 0 ) ou algo. 
        
        */



        public static Controlador_movimento instancia;
        public static Controlador_movimento Pegar_instancia(){ return instancia; }

        public static Controlador_movimento Construir(){ 

                Controlador_movimento controlador = new Controlador_movimento(); 
                
                instancia = controlador;
                return instancia;
                
        }


        public void Mover_personagem_PONTO( Personagem _personagem, Locator_position _nova_posicao ){

                // *** MOVE O PERSONAGEM DENTRO DE UM MESMO LOCAL

                // --- VERIFICA SE JA NAO ESTA NA POSICAO
                if( _personagem.posicao.posicao_id ==_nova_posicao.posicao_id )  
                        { return; } // --- JA ESTA NA POSICAO
                        

        }


        public void Mover_personagem_LOCAL( Personagem _personagem, Locator_position _nova_posicao ){

                // --- VERIFICA SE JA NAO ESTA NA POSICAO
                if( _personagem.posicao.posicao_id ==_nova_posicao.posicao_id )  
                        { return; } // --- JA ESTA NA POSICAO
                        

        }

        
        public void Mover_personagem_CIDADE( Personagem _personagem, Locator_position _nova_posicao ){

                // --- VERIFICA SE JA NAO ESTA NA POSICAO
                if( _personagem.posicao.posicao_id ==_nova_posicao.posicao_id )  
                        { return; } // --- JA ESTA NA POSICAO
                


        }




}