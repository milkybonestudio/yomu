using System;
using UnityEngine;



public class MANAGER__textures_resources {


        // *** CLEAN IN EDITOR
        public static MANAGER__textures_resources instance;
        public MANAGER__textures_resources(){ instance = this; }
        
        public static void Clean_all(){ foreach( Texture2D t in instance.textures ){ if( t != null ) { GameObject.Destroy( t ); } } }

        // --- DATA
        
        public Texture2D[] textures = new Texture2D[ 100 ];

        
        // --- MAIN METHODS

        public void Liberate_texture( RESOURCE__image _image ){

                _image.single_image.sprite = null;
                _image.single_image.texture_exclusiva_native_array.Dispose();

                int slot = _image.single_image.slot_texture;
                Texture2D texture = textures[ slot ];
                textures[ slot ] = null;

                if( texture != null )
                    { CONTROLLER__errors.Throw( $"tried to liberate texture of the image <Color=lightBlue>{ _image.name }</Color>, but there is no texture in the slot <Color=lightBlue>{ slot }</Color>" ); }

                GameObject.Destroy( texture );



        }


        public void Get_texture( RESOURCE__image _image ){ 

            
                _image.single_image.texture_exclusiva = new Texture2D( _image.width, _image.height, TextureFormat.RGBA32, false );
                _image.single_image.texture_exclusiva.filterMode = FilterMode.Point;
                _image.single_image.texture_exclusiva_native_array = _image.single_image.texture_exclusiva.GetPixelData<Color32>( 0 );

                int slot = 0;
                while( slot++ < textures.Length ){

                    if( textures[ slot ] != null )
                        { continue; }

                    textures[ slot ] = _image.single_image.texture_exclusiva;
                    _image.single_image.slot_texture = slot;
                    
                    return;
                        
                }

                Array.Resize( ref textures, ( textures.Length + 50 ) );
                textures[ slot ] = _image.single_image.texture_exclusiva;
                _image.single_image.slot_texture = slot;


        }

        // --- SUPPORT

        public int Get_bytes_allocated(){ return TOOL__get_bytes_allocated.Get( this ); }


}

