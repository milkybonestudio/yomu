
using System;
using UnityEngine;
 




public static class Dados_blocos {


        public static Story_START story_START ;
        public static Localizador_lidar_retorno_bloco localizador_lidar_retorno_story;
        public static Story_RETURN story_RETURN ;


        public static Interacao_START interacao_START ;
        public static Localizador_lidar_retorno_bloco localizador_lidar_retorno_interaction;
        public static Interaction_RETURN interaction_RETURN ;

        
        public static Cartas_START cartas_START ;
        public static Localizador_lidar_retorno_bloco localizador_lidar_retorno_cards;
        public static Cartas_RETURN cartas_RETURN ;
        

        public static Minigame_START minigames_START ;
        public static Localizador_lidar_retorno_bloco localizador_lidar_retorno_minigames;
        public static Minigame_RETURN minigames_RETURN ;




        public static Story_START Get_data_start_BLOCK(){

            story_START = new Story_START();
            return story_START;
            
        }



        public static void Resetar(){ 
            

                story_START  = null ;
                story_RETURN  = null ;


                interacao_START  = null ;
                interaction_RETURN  = null ;

        
                cartas_START  = null ;
                cartas_RETURN  = null ;
        
            
                minigames_START  = null ;
                minigames_RETURN  = null ;


        }


}

