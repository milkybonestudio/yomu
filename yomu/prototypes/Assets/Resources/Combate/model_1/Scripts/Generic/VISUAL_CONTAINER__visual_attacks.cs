using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class VISUAL_CONTAINER__visual_attacks {


        public static GameObject container_visual_attacks = GameObject.Find( "Canvas/Attacks" );
        public static Dictionary<int, Visual_attack_screen_data> list = new Dictionary<int, Visual_attack_screen_data>();

        private static void Change_sprite( Visual_attack_screen_data _data, Sprite _sprite ){

            _data.image.sprite = _sprite;

            _data.rect_transform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, _sprite.rect.width );
            _data.rect_transform.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, _sprite.rect.height );



        }

        public static int id;
        // ** player -> vec(0,0,0)
        public static void Add_visual_attack( Visual_attack _visual_attack, Vector3 _position_attack = default ){

            

            Audios.Create_audio( _visual_attack.audio_name );

            Visual_attack_screen_data data = new Visual_attack_screen_data();

                if( _visual_attack.number_frames < 1 )
                    { throw new System.Exception( "animation have less than 1 frame" ); }

                data.game_object = new GameObject( "attak" );
                data.game_object.transform.SetParent( container_visual_attacks.transform, false );
                data.game_object.transform.localPosition = _position_attack;
                
                data.image = data.game_object.AddComponent<Image>();
                data.rect_transform = data.game_object.GetComponent<RectTransform>();
                
                data.time_per_frame = 1f / 12f;
                data.sprites = new Sprite[ _visual_attack.number_frames ];

            
                for( int i = 0 ; i < _visual_attack.number_frames ; i++ ){

                    string path = Paths_combate_modelo_1.Get_path( $"Visual_attacks/{ _visual_attack.path_name }_{ i }" );
                    data.sprites[ i ] = Resources.Load<Sprite>( path );
                    if( data.sprites[ i ] == null )
                        { throw new System.Exception( $"Did not find in the path <Color=lightBlue>{ path }</Color>" ); }

                }

                Change_sprite( data, data.sprites[ 0 ] );


            list.Add( id++, data );

        }


        private static int[] values_to_remove = new int[ 1_000 ];
        private static int index_values_to_remove = -1;



        public static void Update(){

            foreach( KeyValuePair<int, Visual_attack_screen_data> kv in list ){

                Visual_attack_screen_data data = kv.Value;
                data.current_time += Time.deltaTime;

                if( data.current_time >= data.time_per_frame )
                    {
                        data.current_time -= data.time_per_frame;
                        ++data.current_image;
                        if( data.current_image == data.sprites.Length )
                            {
                                // ** END
                                GameObject.Destroy( kv.Value.game_object );
                                index_values_to_remove++;
                                values_to_remove[ index_values_to_remove ] = kv.Key;
                                continue;

                            }
                        Change_sprite( data, data.sprites[ data.current_image ] );
                        
                    }

            }

            for( int index = 0 ; index < ( index_values_to_remove + 1 ) ; index++ ){
                list.Remove( values_to_remove[ index ] );
            }

            index_values_to_remove = -1;
                

        }


}