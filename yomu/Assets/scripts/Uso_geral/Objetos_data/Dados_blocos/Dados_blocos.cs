
using System;
using UnityEngine;
 


public class Dados_blocos {


        public static Dados_blocos instancia;
        public static Dados_blocos Pegar_instancia(){ return instancia; }
        public static Dados_blocos Construir(){ instancia = new Dados_blocos(); return instancia;}


        public Req_transicao req_transicao = null ;
        public Req_mudar_UI req_mudar_UI = null ;
        public Req_mudar_input req_mudar_input= null ;



        public Plataforma_START plataforma_START ;
        public Plataforma_RETURN plataforma_RETURN ;





        public Visual_novel_START visual_novel_START ;
        public Visual_novel_RETURN visual_novel_RETURN ;


        // public Jogo_START jogo_START ;
        // public Jogo_RETURN jogo_RETURN ;

        public Movimento_START movimento_START ;
        public Movimento_RETURN movimento_RETURN ;

        
        public Cartas_START cartas_START ;
        public Cartas_RETURN cartas_RETURN ;
        
        public Conversa_START conversa_START ;
        public Conversa_RETURN conversa_RETURN ;

        public Minigame_START minigame_START ;
        public Minigame_RETURN minigame_RETURN ;





        public void Colocar_nova_req( Req_transicao _req_transicao ){

            if( req_transicao != null) 
                {
                    string req_1  =  req_transicao.novo_bloco.ToString();
                    string req_2  = _req_transicao.novo_bloco.ToString();
                    throw new ArgumentException("foi colocado 2 reqs ao mesmo tempo. req 1 estava indo para: " + req_1 + ", req 2 estava querendo ir para: " +  req_2 );

                }
            
            req_transicao = _req_transicao;
            return;


        }



}

