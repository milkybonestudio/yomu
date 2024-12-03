using TMPro;
using UnityEngine;


public struct DATA__UI_text_container {


    public Type_UI_text_container type;


        public Type_writing_construction tipo_texto;

        public float speed ;
        public float base_speed ;
        public float speed_multiplier ;
        public int characters_multiplier ;


        public Coroutine texto_coroutine;
        

        public string path_locator;
        public string main_folder;


        // ** tem que ser por segundo
        public int characters_per_cycle() {  


                if( speed <= 2f )
                    { return characters_multiplier; }

                if( speed<=2.5f )
                    { return ( characters_multiplier * 2 ); }

                return ( characters_multiplier *3 ); 
                

        }
    






}