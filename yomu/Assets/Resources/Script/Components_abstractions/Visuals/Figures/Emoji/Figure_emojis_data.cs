

using System;
using UnityEngine;



public struct Figure_emojis {



        public static Figure_emojis Get(){

            Figure_emojis emojis = new Figure_emojis();
                emojis.emojis = new Figure_emoji_data[ 10 ];
            return emojis;

        }


        public Figure_emoji_data[] emojis;
        public GameObject container_emojis;


        public void Add_emoji( Figure_mode_emoji _emoji ){

                int slot = -1;
                while( ++slot < emojis.Length ){

                    if(  !!!( emojis[ slot ].activated ) )
                        { break; }
                }

                if( slot == emojis.Length )
                    { Array.Resize( ref emojis, ( emojis.Length + 10 ) ); }
                
                
                Figure_emoji_data data = Figure_emojis_list.Get( _emoji );
                            
                    data.place = GAME_OBJECT.Criar_filho( "emoji", container_emojis );
                    data.render = data.place.AddComponent<SpriteRenderer>();
                    data.place.transform.SetParent( container_emojis.transform, false );
                    data.container = container_emojis;
                    data.activated = true;


                Verification( data );

                // --- COMECA NA PRIMEIRA
                data.Pass_image();

                emojis[ slot ] = data;

                return;

        }

        private void Verification( Figure_emoji_data data ){


                if( data.frames_per_second == 0 )
                    { CONTROLLER__errors.Throw( $"Dit not define the frame rate of the emoji { data.emoji }" ); }

                if( data.speed_pixels_per_second == 0 && data.move_type != Figure_emoji_movement.not_move )
                    { CONTROLLER__errors.Throw( $"Dit not define the speed of the emoji { data.emoji }" ); }

                


        }

        public int Update(){

            int ret = 0;

            for( int slot = 0 ; slot < emojis.Length ; slot++ ){

                if( emojis[ slot ].activated )
                    { ret += emojis[ slot ].Update(); }

            }

            return ret;

        }

}




