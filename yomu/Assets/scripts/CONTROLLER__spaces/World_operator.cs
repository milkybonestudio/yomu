

using System;
using System.Collections.Generic;
using UnityEngine;

public class World_operator {


        public static World_operator Construct( string _path ){

                World_operator world = new World_operator();

                    world.main_container = GameObject.Find( ( _path + "/Main_container" ) );
                    world.second_container = GameObject.Find( ( _path + "/Main_container/Second_container" ) );

                    if ( world.main_container.TryGetComponent<SpriteRenderer>( out SpriteRenderer sprite_render ) )
                        { GameObject.Destroy( sprite_render ); }
                    world.dic = new Dictionary<string, RESOURCE__structure_copy>();

                    
                return world;

        }


        private Dictionary<string, RESOURCE__structure_copy> dic;

        public bool Have_things(){

            return ( dic.Count > 0 );

        }

        public void Add( RESOURCE__structure_copy _thing ){

            dic.Add( _thing.name, _thing );
            _thing.Set_parent( second_container );
            
        }

        public RESOURCE__structure_copy Get( string _name ){

            return dic[ _name ];
        }

        public void Free(){

            foreach( RESOURCE__structure_copy copy in dic.Values ){
                    copy.Delete();
            }

            dic.Clear();

            GameObject.Destroy( second_container );
            second_container = GAME_OBJECT.Criar_filho( "Second_container", main_container );

        }

        private GameObject main_container; // ** nunca destruir
        private GameObject second_container; // ** quando Free() pode destruir tudo

}

