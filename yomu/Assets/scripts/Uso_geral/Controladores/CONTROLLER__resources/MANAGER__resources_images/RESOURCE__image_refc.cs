using UnityEngine;



public class RESOURCE__image_ref {

        public RESOURCE__image_ref( RESOURCE__image _image ){ image = _image; }


        /*
                ref_1 ----
                          |_______  image
                ref_2 ----   
        */


        public RESOURCE__image image;
        public string localizador; // ** localizador local

        public int image_slot_index;

        // ** define se esta com os recursos completos ou minimos 
        private RESOURCE__image_state state;


        public UnityEngine.Sprite Get_sprite(){


            // ** talvez devolver uma sprite normal
            if( state == RESOURCE__image_state.ref_closed )
                { CONTROLLER__errors.Throw( $"try to get the sprite in { localizador } but the ref is closed" ); }

            if( state == RESOURCE__image_state.minimun_resources )
                { image. }

            
        }

        

        public Texture Get_texture(){

        }

        public void Delete(){} // ** indica que nao precisa mais da referencia 
        public void Free(){}   // ** volta para o minimo
 
 
        private void Liberate_texture(){}


}
