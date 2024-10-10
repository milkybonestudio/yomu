using System;
using UnityEngine;



public class MODULE__textures_manager {


        public MODULE__textures_manager(){ TOOL__create_initial_textures.Create( this ); }

        // --- DATA
        
        public Texture2D[][] textures; 
        public Texture_allocated_flags[][] textures_locks;
        public string[][] indentificadores;

        public Texture2D[] textures_exclusivas = new Texture2D[ 50 ];

        // --- MAIN METHODS
        

        // ** retorna se precisou criar novas
        // ** pode ser chamado normalmente 
        public bool Get_texture( RESOURCE__image_data _data ){

                string _indentificador = _data.image_path;
                int _width = _data.width;
                int _height = _data.height;
                bool create_new_texture = false;


                if( _width < 1 || _height < 1 )
                    { CONTROLLER__errors.Throw( $"dimensions wrong. height: { _height }, width: { _width }"); }


                Dimension_higher_to_low dimensions = Get_higher_number( _width, _height );

                if( dimensions.higher > 1500 )
                    {
                        // --- SPECIFIC

                        _data.texture_allocated.exclusive_texture  = true;

                        int slot_livre = Get_free_exclusive_textures_slot();
                        textures_exclusivas[ slot_livre ] = new Texture2D( _width, _height );
                        
                        _data.texture_allocated.native_array = textures_exclusivas[ slot_livre ].GetPixelData<Color32>( 0 );

                        return true;
                    }


                if( ( Abs( ( _width - _height ) )   * 1000 ) / _height < 1100 )
                    {
                        // --- SQUARE
                    
                        int size_slot_square = TOOL__get_size_slot.Get_slot_square_internal( dimensions.higher );
                        int slot_unlock_square = Get_free_slot( size_slot_square, ref create_new_texture );
                        
                        _data.texture_allocated.exclusive_texture = false;

                        indentificadores[ size_slot_square ][ slot_unlock_square ] = _indentificador;
                        textures_locks[ size_slot_square ][ slot_unlock_square ].allocated_in_image = true;

                        _data.texture_allocated.texture_size_slot = size_slot_square;
                        _data.texture_allocated.texture_id = slot_unlock_square;

                        // ** a texture ainda pode te pixels da ultima imagem
                        //mark
                        // limpar_text()

                        _data.texture_allocated.native_array = textures[ size_slot_square ][ slot_unlock_square ].GetPixelData<Color32>( 0 );

                        return create_new_texture;

                    }


                // --- RECT
                
                int size_slot_rect = TOOL__get_size_slot.Get_slot_rect_internal( dimensions );
                int slot_unlock_rect = Get_free_slot( size_slot_rect, ref create_new_texture );
                
                _data.texture_allocated.exclusive_texture = false;

                indentificadores[ size_slot_rect ][ slot_unlock_rect ] = _indentificador;
                textures_locks[ size_slot_rect ][ slot_unlock_rect ].allocated_in_image = true;

                _data.texture_allocated.texture_size_slot = size_slot_rect;
                _data.texture_allocated.texture_id = slot_unlock_rect;

                //mark
                // ** a texture ainda pode te pixels da ultima imagem
                
                _data.texture_allocated.native_array = textures[ size_slot_rect ][ slot_unlock_rect ].GetPixelData<Color32>( 0 );

                
                return create_new_texture;
                    
        
        }


        public void Reduze_textures_allocated( Texture_sizes _size_slot, int number ){

            // will try to reduze the number or the most as possible. the texture can not be allocated
            throw new Exception();

        }

        // --- SUPPORT

        public int Get_bytes_allocated(){

            return TOOL__get_bytes_allocated.Get( this );
        }



        // --- INTERNAL


        private int Get_free_exclusive_textures_slot(){


                for( int i = 0 ; i < textures_exclusivas.Length ; i++ ){

                        if( textures_exclusivas[ i ] == null )
                            { return i; }

                }

                int slot = textures_exclusivas.Length;
                Array.Resize( ref textures_exclusivas, ( textures_exclusivas.Length + 10 ) );

                return slot;

        }


        private int Get_free_slot( int _size_slot, ref bool _create_new ){

                Texture_allocated_flags[] locks = textures_locks[ _size_slot ];

                for( int i = 0 ; i < locks.Length ; i++ ){

                    if( !!!( locks[ i ].allocated_in_image ) )
                        { return i; }

                    continue;

                }

                int slot_livre = locks.Length;
                _create_new = true;
                Array.Resize( ref textures[ _size_slot ], ( textures.Length + 1 ) );
                Array.Resize( ref locks, ( locks.Length + 1 ) );

                // --- CREATE NEW TEXTURE
                textures[ _size_slot ][ slot_livre ] = new Texture2D( textures[ _size_slot ][ slot_livre ].width, textures[ _size_slot ][ slot_livre ].height );
                return slot_livre;


        }

        


        private Dimension_higher_to_low Get_higher_number( int n1, int n2 ){

            Dimension_higher_to_low str = new Dimension_higher_to_low();

            if( n1 > n2 )
                { str.higher = n1; str.lower  = n2; }
                else
                { str.higher = n2; str.lower  = n1; }

            return str;

        }

        private int Abs( int i ){
            if( i < 0 )
                { return -i; }
            return i;
        }


}

