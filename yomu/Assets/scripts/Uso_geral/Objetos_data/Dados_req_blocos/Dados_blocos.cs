
using System;
using UnityEngine;
 


public static class Dados_blocos {




        public static Req_transicao req_transicao ;
        public static Req_mudar_UI req_mudar_UI ;
        public static Req_mudar_input req_mudar_input;


        // public static Plataforma_START plataforma_START ;
        // public static Plataforma_RETURN plataforma_RETURN ;


        public static Visual_novel_START visual_novel_START ;
        public static string[] visual_novel_finalizar_localizador;
        public static Visual_novel_RETURN visual_novel_RETURN ;


        public static Conector_START conector_START ;
        public static string[] conector_finalizar_localizador;
        public static Conector_RETURN conector_RETURN ;

        
        public static Cartas_START cartas_START ;
        public static string[] cartas_finalizar_localizador;
        public static Cartas_RETURN cartas_RETURN ;
        
        public static Conversa_START conversa_START ;
        public static string[] conversas_finalizar_localizador;
        public static Conversa_RETURN conversa_RETURN ;

        public static Minigame_START minigames_START ;
        public static string[] minigames_finalizar_localizador;
        public static Minigame_RETURN minigames_RETURN ;



        public static void Colocar_nova_req( Req_transicao _req_transicao ){

            if( req_transicao != null) 
                {
                    string req_1  =  req_transicao.novo_bloco.ToString();
                    string req_2  = _req_transicao.novo_bloco.ToString();
                    throw new ArgumentException("foi colocado 2 reqs ao mesmo tempo. req 1 estava indo para: " + req_1 + ", req 2 estava querendo ir para: " +  req_2 );

                }
            
            req_transicao = _req_transicao;
            return;


        }

        public static void Resetar(){ 
            

                req_transicao  = null ;
                req_mudar_UI  = null ;
                req_mudar_input = null ;


                visual_novel_START  = null ;
                visual_novel_RETURN  = null ;


                conector_START  = null ;
                conector_RETURN  = null ;

        
                cartas_START  = null ;
                cartas_RETURN  = null ;
        
                conversa_START  = null ;
                conversa_RETURN  = null ;

                minigames_START  = null ;
                minigames_RETURN  = null ;




        }


}

