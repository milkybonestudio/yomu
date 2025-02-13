using UnityEngine;


public struct Body_constructor {

    public void Set_off_set_rotation( bool _value ){ need_off_set_rotation = _value; }

    // ** precisa objecto( move / scale ) -> point 1 ( para x + y = 0 ) -> point 2 ( base rotation ) -> object( nothing )
    public bool need_off_set_rotation; // ** 3 gameObjects
    
}

public class Body {


        private static GameObject container_bodies;


        // real objects
        public GameObject body_container; // ** move + scale
        public GameObject off_set_rotation_container;
        public GameObject structure_container; // ** self rotation

        // ** body e structure podem ser os mesmos

        public GameObject object_to_self_rotate;
        public GameObject object_to_move;

        public Transform body_transform;

        public Vector3 local_position;
        public Vector3 local_scale;
        public Quaternion local_rotation;



        public string name;

        public Body_data body_data = Body_data.Construct();


        public Body_constructor constructor;


        private bool get_container;





        public virtual void Create_body( GameObject _UI_component_game_object ){

                
                    
                if( _UI_component_game_object == null )
                    { _UI_component_game_object = new GameObject( name ); }

                GameObject _place_to_instanciate = _UI_component_game_object.transform.parent?.gameObject;
                
                
                if( _place_to_instanciate == null )
                    {
                        if( container_bodies == null )
                            { container_bodies = GameObject.Find( "Containers/Bodies" ); get_container = true; }

                         _place_to_instanciate = container_bodies; 
                    }



                if( constructor.need_off_set_rotation )
                    {
                        body_container = new GameObject( "Container_component" );
                        off_set_rotation_container = GAME_OBJECT.Criar_filho( "Container_off_set_rotation_UP", body_container );

                        _UI_component_game_object.transform.SetParent( off_set_rotation_container.transform, false );
                        structure_container = _UI_component_game_object;
                    }
                    else 
                    {
                        body_container = _UI_component_game_object;
                        structure_container = _UI_component_game_object;
                    }


                body_container.transform.SetParent( _place_to_instanciate.transform, false );



                Transform transform = structure_container.transform;

                Vector2 position = ( transform.localPosition * PPU.value_inverse );
                
                body_container.transform.localPosition = position;
                body_container.name = structure_container.name;
                transform.localPosition = Vector3.zero;

                body_data.position.current = position;
                body_data.position.normal = position;
            

                // ** structure_container == null -> nao tem nada
                

        }




        public void Set_body_container_parent( GameObject _new_parent ){

            body_container.transform.SetParent( _new_parent.transform, false ); 

        }


        // ** if something override
        public virtual void Update_visual(){}


        // ** passar com base.Update()
        public virtual int Update( Control_flow _control_flow ){

                // --- CACHE DATA

                body_transform = body_container.transform;
                        
                    local_position = body_transform.localPosition;
                    local_scale = body_transform.localScale;
                    local_rotation = body_transform.localRotation;




                // Console.Log( "veio update body " + name  );
                
                if( body_container == null )
                    { return 1; }

                Update_visual();

                Update_body();
                
                return 1;
                
        }


        public void Update_body(){




                // --- POSITION 
                Vector3 vector_position = body_data.position.Calculate_final();
                Vector3 dif_vector_position = ( body_data.position.current_in_object - vector_position );

                if( ( dif_vector_position.x != 0f ) || ( dif_vector_position.x != 0f ) || ( dif_vector_position.z != 0f ) )
                    { body_transform.localPosition = vector_position; body_data.position.current_in_object = vector_position; }


                // --- SCALE
                body_transform.localScale = body_data.scale.Calculate_final();

                // --- RATATION OFF SET
                // ** referente a ancora
                if( off_set_rotation_container != null )
                    { body_transform.localRotation = body_data.off_set_rotation.Calculate_final(); }


                // --- ROTATION SELF

                Quaternion final_rotation = body_data.rotation.Calculate_final();
                //Quaternion dif_final_rotation =  ( final_rotation - body_data.rotation.current_in_object );

                // 
                if( final_rotation ==  body_data.rotation.current_in_object  )
                    { body_transform.transform.localRotation = final_rotation; body_data.rotation.current_in_object = final_rotation; }

                

        }





            // ** SCALE
                
                // 100%?
                public virtual void Rescale( float _new_scale_percent ){ float _new_scale = ( _new_scale_percent / 100f); body_data.scale.normal += new Vector3( _new_scale, _new_scale, _new_scale ); }
                    public virtual void Rescale( float _new_scale_percent_X, float _new_scale_percent_Y ){ body_data.scale.normal += new Vector3( ( _new_scale_percent_X/100f ), ( _new_scale_percent_Y/100f ), 0f ); }
                        public virtual void Rescale( Vector3 _new_scale ){ body_data.scale.normal += _new_scale; }

                    
                public virtual void Rescale_to( float _new_scale_percent ){ float _new_scale = ( _new_scale_percent / 100f); body_data.scale.normal = new Vector3( _new_scale, _new_scale, _new_scale ); }
                    public virtual void Rescale_to( float _new_scale_percent_X, float _new_scale_percent_Y ){ body_data.scale.normal = new Vector3( ( _new_scale_percent_X/100f ), ( _new_scale_percent_Y/100f ), body_data.scale.normal.z ); }
                        public virtual void Rescale_to( Vector3 _new_scale ){ body_data.scale.normal = _new_scale; }



                public virtual void Force_scale(){  }


            // ** POSITION
                
                public virtual void Move( Vector3 _position ){ body_data.position.normal += _position; }
                    public virtual void Move( float _x, float _y, float _z = 0f ){ body_data.position.normal += new Vector3( _x, _y, _z ); }

                public virtual void Move_to( Vector3 _position ){ throw new System.Exception(); body_data.position.normal = _position; }
                    public virtual void Move_to( float _x, float _y, float _z ){ body_data.position.normal = new Vector3( _x, _y, _z ); }
            

            public virtual void Force_move(){}


            // ** ROTATION SELF
            
            
            public virtual void Rotate_to( Quaternion _rotation ){ body_data.rotation.normal = _rotation; }
                public virtual void Rotate_to( float _x, float _y, float _z ){ body_data.rotation.normal = Quaternion.Euler( _x, _y, _z ); }

            public virtual void Rotate( Quaternion _rotation ){ body_data.rotation.normal *= _rotation; }
                public virtual void Rotate( float _x, float _y, float _z ){ body_data.rotation.normal *= Quaternion.Euler( _x, _y, _z ); }




            // ** ROTATION OFF SET

            private void Verify_off_set_rotation(){ if( off_set_rotation_container == null ){ CONTROLLER__errors.Throw( $"tried to rotated in the off_set in the object { name } but there is not set to off_set rotation" ); } }

            public virtual void Rotate_off_set_to( Quaternion _rotation ){ body_data.off_set_rotation.normal = _rotation; }
                public virtual void Rotate_off_set_to( float _x, float _y, float _z ){ body_data.off_set_rotation.normal = Quaternion.Euler( _x, _y, _z ); }

            public virtual void Rotate_off_set( Quaternion _rotation ){ body_data.off_set_rotation.normal *= _rotation; }
                public virtual void Rotate_off_set( float _x, float _y, float _z ){ body_data.off_set_rotation.normal *= Quaternion.Euler( _x, _y, _z ); }


            public virtual void Set_rotation_position_off_set( Vector3 _position ){ Verify_off_set_rotation(); off_set_rotation_container.transform.localPosition = _position * -1f; structure_container.transform.localPosition = _position; }
                public virtual void Set_rotation_position_off_set( float _x, float _y, float _z ){ Verify_off_set_rotation(); Set_rotation_position_off_set( new Vector3( _x, _y, _z ) ); }



            

}



        //mark

        // ** off sets vao ser trocados instantaneamente
        /*
            [ world ]
                -- [ component_container ]
                    -- [ rotation off-set_container ]
                        -- [ structure container ]
                            -- [ things ]
                            -- [ things ]
                            -- [ things ]        
        */
