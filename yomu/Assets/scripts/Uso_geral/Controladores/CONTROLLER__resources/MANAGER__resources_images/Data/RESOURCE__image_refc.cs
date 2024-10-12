using UnityEngine;

/*      ref_1 ----
                    |_______  image
        ref_2 ----                       */


public class RESOURCE__image_ref {

        public RESOURCE__image_ref( RESOURCE__image _image ){ 

            if( _image == null  )
                { CONTROLLER__errors.Throw( "Tried to creat a image ref but the image comes null" ); }

            image = _image;
            module = _image.module_images;
        }

        
        public string localizador; // ** localizador local
        public RESOURCE__image image;
        public MODULE__context_images module;
        public int image_slot_index;
        


        // ** define se esta com os recursos completos ou minimos 
        public RESOURCE__image_ref_state ref_state;
        
        

        // --- METODOS QUE VAO PARA O MODULO


        public UnityEngine.Sprite Get_sprite(){ return module.Get_sprite( this );

                // // ** talvez devolver uma sprite normal
                // if( ref_state == RESOURCE__image_ref_state.ref_closed )
                //     { CONTROLLER__errors.Throw( $"try to get the sprite in { localizador } but the ref is closed" ); }
                
                // return null;
                // //return image.Get_sprite();
            
        }

        
        public Texture Get_texture(){ return module.Get_texture( this );

            
            // // ** talvez devolver uma sprite normal
            // if( ref_state == RESOURCE__image_ref_state.ref_closed )
            //     { CONTROLLER__errors.Throw( $"try to get the sprite in { localizador } but the ref is closed" ); }
            
            //     //return image.Get_texture();

            // return null;

        }

        

        // ** imagem vai ser deletada completamente 
        public void Delete(){ module.Delete( this );

            // image.Delete( this ); 
            // ref_state = RESOURCE__image_ref_state.ref_closed;

        } 

        // ** dados vao ser perdidos, mas a referencia da imagem volta 
        public void Unload(){ module.Unload( this ); }

        // ** volta para o minimo 
        public void Free(){ module.Free( this ); }


        // --- PEGAR RECURSOS

        // ** sinaliza que a imagem pode carregar o minimo 
        public void Load(){  Debug.Log( "module: " + module ); module.Load( this ); }

        // ** sinaliza que pode começar a pegar a texture
        public void Get_ready(){ module.Get_ready( this ); }


 
}
