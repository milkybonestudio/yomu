using System.Runtime.CompilerServices;
using UnityEngine;



unsafe public partial struct Body {


        private Body_data_creation constructor_data;
        public void Set_body_constructor_data( Body_data_creation _data ){ constructor_data = _data; }
        

        public void Create(  GameObject _UI_component_game_object = null ){

            //mark
            // ** agora que body nao é mais uma abastracao poderia deixar os gameobjects para serem pegos em container
            // ** poderia ter um container para quando tiver anchour e só muda os valores 


            state = Body_state.constructed;

            // ** --- LOGIC
            
        
            constructor_data.Verify(); // ** GUARANTEE STUFF

                scale.__Start__( constructor_data.scale_type, constructor_data.scale_type_data );
                position.__Start__( constructor_data.position_type, constructor_data.position_type_data );
                rotation.__Start__( constructor_data.rotation_type, constructor_data.rotation_type_data );

                anchour_scale.__Start__( constructor_data.anchour_scale_type, constructor_data.anchour_scale_type_data );
                anchour_rotation.__Start__( constructor_data.anchour_rotation_type, constructor_data.anchour_rotation_type_data );
                anchour_position.__Start__( constructor_data.anchour_position_type, constructor_data.anchour_position_type_data );




            // ** --- CONSTRUCT WORLD PART

            
            if( _UI_component_game_object == null )
                { _UI_component_game_object = new GameObject( name ); } // ** receber null quer dizer que o objeto quer um container para colocar coisas depois

            GameObject generic_object = _UI_component_game_object;
            Transform generic_transform = _UI_component_game_object.transform;
            Transform original_parent = generic_transform.parent; 


            // ** SIMPLE CONTAINERS
            
            body_container = generic_object;
            body_container_transform = generic_transform;

            anchour_container = generic_object;
            anchour_container_transform = generic_transform;

            self_container = generic_object;
            self_container_transform = generic_transform;

            body_object = generic_object;
            body_object_transform = generic_transform;

            body_container.name = name;


        
            Vector3 initial_position = generic_transform.localPosition;
            Vector3 initial_scale = generic_transform.localScale;
            Quaternion initial_rotation = generic_transform.localRotation;

            constructor_data.initial_position_in_parent = initial_position;
            constructor_data.initial_scale_in_parent = initial_scale;
            constructor_data.initial_rotation_in_parent = initial_rotation;


            position.__Set_initial_position__( initial_position * PPU.value );
            rotation.__Set_initial_rotation__( initial_rotation );
            scale.__Set_initial_scale__( initial_scale );


            
            if(  constructor_data.put_in_container )
                { body_container_transform.SetParent( container_bodies_transform, false ); }



            // ** preferir nao usar, as UIs vao ter as posicoes certas nos prefabs
            // ** os devices e as figures vao ser colocados no Initialize
            if( constructor_data.transform_in_parent.position.Is_not_default() )
                {
                    Vector3 initial_position_in_parent = constructor_data.transform_in_parent.position.Convert_to_vector();
                    body_container_transform.localPosition = ( initial_position_in_parent * PPU.value_inverse );
                    Console.Log( body_container_transform.localPosition );
                    position.__Set_initial_position__( initial_position_in_parent );

                    if( ( constructor_data.NOT_force_transform & Transform_type.position ) == 0 )
                        { position.Force(); }
                }

            if( constructor_data.transform_in_parent.scale.Is_not_default() )
                {
                    Vector3 initial_scale_in_parent = constructor_data.transform_in_parent.scale.Convert_to_vector();
                    body_container_transform.localScale = ( initial_scale_in_parent );
                    scale.__Set_initial_scale__( initial_scale_in_parent );
                }




            // QUATERNION.Guarantee_value( ref constructor_data.rotation_in_parent, initial_rotation );
            // self_container_transform.localRotation = constructor_data.rotation_in_parent;
            // rotation.__Set_initial_rotation__( constructor_data.rotation_in_parent );

            VECTOR_3.Guarantee_value( ref constructor_data.scale_in_parent, initial_scale );
            self_container_transform.localScale = constructor_data.scale_in_parent;
            scale.__Set_initial_scale__( constructor_data.scale_in_parent );

            if( ( constructor_data.NOT_force_transform & Transform_type.rotation ) == 0 )
                { rotation.Force(); }

            if( ( constructor_data.NOT_force_transform & Transform_type.scale ) == 0 )
                { scale.Force(); }




            if( constructor_data.need_anchour )
                {
                
                    body_container = new GameObject( $"{ name }_Body_container" );
                    body_container_transform = body_container.transform;

                    anchour_container = new GameObject( $"anchour_container" );
                    anchour_container_transform = anchour_container.transform;

                    self_container = new GameObject( $"self_container" );
                    self_container_transform = self_container.transform;


                    body_object_transform.SetParent( self_container_transform, false );
                    self_container_transform.SetParent( anchour_container_transform, false );
                    anchour_container_transform.SetParent( body_container_transform, false );

                    body_container_transform.SetParent( original_parent , false );


                    if(  constructor_data.put_in_container )
                        { body_container_transform.SetParent( container_bodies_transform, false ); }


                    // ** reajusta
                    body_object_transform.localPosition = Vector3.zero;
                    body_object_transform.localRotation = Quaternion.identity;
                    body_object_transform.localScale = Vector3.one;

                    body_container_transform.localPosition = initial_position;
                    self_container_transform.localRotation = initial_rotation;
                    self_container_transform.localScale = initial_scale;




                    // ** SET DATA

                    anchour_position.__Set_current_initial_position__( constructor_data.anchour_position );
                    self_container_transform.localPosition = ( -1f * constructor_data.anchour_position * PPU.value_inverse );
                    anchour_container_transform.localPosition = ( constructor_data.anchour_position * PPU.value_inverse );


                    VECTOR_3.Guarantee_value( ref constructor_data.anchour_scale, Vector3.one );
                    anchour_scale.__Set_initial_scale__( constructor_data.anchour_scale );
                    body_container_transform.localScale = constructor_data.anchour_scale;


                    QUATERNION.Guarantee_value( ref constructor_data.anchour_rotation, Quaternion.identity );
                    anchour_rotation.__Set_initial_rotation__( constructor_data.anchour_rotation );
                    anchour_container_transform.localRotation = constructor_data.anchour_rotation;
                    
                    
                    if( ( constructor_data.NOT_force_transform_anchour & Transform_type.position ) == 0 )
                        { anchour_position.Force(); }

                    if( ( constructor_data.NOT_force_transform_anchour & Transform_type.rotation ) == 0 )
                        { anchour_rotation.Force(); }

                    if( ( constructor_data.NOT_force_transform_anchour & Transform_type.scale ) == 0 )
                        { anchour_scale.Force(); }


                }

            // ** RENDER

            if( constructor_data.need_camera_render )
                {
                    // ** fazer depois
                    // constructor_data.dimensions_render
                }



            Console.Log( body_container_transform.localPosition );
            
            // ** EXTRAS

                if( constructor_data.parent != null )
                    { body_container_transform.SetParent( constructor_data.parent.transform, false ); }

                
            Update();


            
        }



}
