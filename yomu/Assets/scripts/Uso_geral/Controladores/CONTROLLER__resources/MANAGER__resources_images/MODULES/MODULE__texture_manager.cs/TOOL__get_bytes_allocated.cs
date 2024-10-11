

using UnityEngine;

public static class TOOL__get_bytes_allocated {

    public static int Get( MANAGER__textures_resources _module ){

                
                int accumulator = 0;
                for( int texture_slot_index = 0 ; texture_slot_index < _module.textures.Length ; texture_slot_index++ ){

                        Texture2D[] textures_no_slot = _module.textures[ texture_slot_index ];
                        Texture2D texture_example = textures_no_slot[ 0 ];
                        

                        const int bytes_per_pixel = 4;
                        accumulator += ( texture_example.width * texture_example.height * bytes_per_pixel * textures_no_slot.Length );
                        continue;

                }

                Texture2D[] textures_exclusivas = _module.textures_exclusivas;

                for( int text_especifica_index = 0 ; text_especifica_index < textures_exclusivas.Length ; text_especifica_index++ ){

                        if( textures_exclusivas[ text_especifica_index ] == null )
                            { continue; }
                        
                        const int bytes_per_pixel = 4;
                        accumulator += ( textures_exclusivas[ text_especifica_index ].width * textures_exclusivas[ text_especifica_index ].height * bytes_per_pixel );
                        continue;

                }


                return accumulator;

        }


}