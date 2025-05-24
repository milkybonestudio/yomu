using UnityEngine;







unsafe public partial struct Body {

        static Body(){

            container_bodies = GameObject.Find( "Containers/Bodies" ); 
            container_bodies_transform = container_bodies.transform;
            only_names_to_update = new string[]{

                // "Example_devices_with_UIs__TYPE_1",

            };

        }


        private static GameObject container_bodies;
        private static Transform container_bodies_transform;
        private static string[] only_names_to_update;


        public Body_state state;

        // ** vai ter name no body e na abstracao
        // ** nao faz sentido o codigo precisar entrar no body para ter o name, mas faz sentido o bod ter o name
        public string name;
        private bool get_container;


        // real objects
        public GameObject body_container; // ** move + scale
        public Transform body_container_transform;

        public GameObject anchour_container;// ** rotate, move ( relative to rot ), scale
        public Transform anchour_container_transform;

        public GameObject self_container; // ** self rotation
        public Transform self_container_transform;

        
        public GameObject body_object; // ** coisa em si
        public Transform body_object_transform;


        
        public Body_visual_data_POSITION position;
        public Body_visual_data_ROTATION rotation;
        public Body_visual_data_SCALE scale;

        public Body_visual_data_POSITION_ANCHOUR anchour_position;
        public Body_visual_data_ROTATION anchour_rotation;
        public Body_visual_data_SCALE anchour_scale;


        //mark
        // ** se nao usar ele vai 

        public void Set_parent( Body_set_parent_data _data ){


            if( state != Body_state.constructed )
                { CONTROLLER__errors.Throw( $"Tried to set_parent of the body <Color=lightBlue>{ name }</Color> but the state was <Color=lightBlue>{ state }</Color>" ); }

            body_container_transform.SetParent( _data.parent.transform, false );

            if( _data.set_new_transform )
                {

                    body_container_transform.localPosition = _data.position;
                    position.__Set_initial_position__( _data.position );

                    QUATERNION.Guarantee_value( ref _data.rotation );
                    self_container_transform.localRotation = _data.rotation;
                    rotation.__Set_initial_rotation__( _data.rotation );

                    VECTOR_3.Guarantee_value( ref _data.scale, Vector3.one );
                    self_container_transform.localScale = _data.scale;
                    scale.__Set_initial_scale__( _data.scale );
                }

            if( _data.set_new_transform_anchour )
                {

                    self_container_transform.localPosition = _data.anchour_position;
                    anchour_position.__Set_current_initial_position__( _data.anchour_position );

                    VECTOR_3.Guarantee_value( ref _data.anchour_scale, Vector3.one );
                    body_container_transform.localScale = _data.anchour_scale;
                    anchour_scale.__Set_initial_scale__( _data.anchour_scale );

                    QUATERNION.Guarantee_value( ref _data.anchour_rotation );
                    anchour_container_transform.localRotation = _data.anchour_rotation;
                    anchour_rotation.__Set_initial_rotation__( _data.anchour_rotation );

                }

        }



        private void Sinalize_all_new_data(){

            position.Sinalize_new_data();
            rotation.Sinalize_new_data();
            scale.Sinalize_new_data();

            anchour_position.Sinalize_new_data();
            anchour_rotation.Sinalize_new_data();
            anchour_scale.Sinalize_new_data();

        }


        public void Update( Control_flow _control_flow ){

            if( state != Body_state.constructed )
                { return; }
                
            #if UNITY_EDITOR
                if( only_names_to_update.Length > 0  )
                    {
                        bool need_update = false;
                        foreach( string _name in only_names_to_update ){
                            if( _name == name  )
                                { need_update = true; break; }
                        }

                        if( !!!( need_update ) )
                            { return; }
                    }
            #endif


            // Console.Log( $"Updata body <Color=lightBlue>{ name }</Color>" );
            position.__Update__( body_container_transform );
            rotation.__Update__( self_container_transform );
            scale.__Update__( self_container_transform );


            if( constructor_data.need_anchour )
                {
                    anchour_scale.__Update__( body_container_transform );
                    anchour_position.__Update__( anchour_container_transform, self_container_transform );
                    anchour_rotation.__Update__( anchour_container_transform );
                }

            // Console.Log( "<Color=lightBlue>-----------------------------</Color>" );

            return;
            
        }



        // ** 


        public void Add_game_object( GameObject _new_game_object ){ 

            if( _new_game_object == null )
                { CONTROLLER__errors.Throw( $"Tried to add a game_object to <Color=lightBlue>{ name }</Color>, but the game object was null" ); }

            // ** talvez colocar uma flag para quando isso pode acontecer
            // ** faz sentido nas figures 
            _new_game_object.transform.SetParent( body_object_transform, false ); 
        }




        public void Destroy( ref Body _body ){


            //performance
            // ** pode ser somente editor
            // ** seria interessante que nunca poderia destruir o objeto em si pelo body
            if( body_object_transform.childCount > 0 )
                { CONTROLLER__errors.Throw( $"Tried to destroy body <Color=lightBlue>{ name }</Color> but the object was still in the body_object" ); }

            GameObject.Destroy( body_container );
            _body = default;
                
        }


}
