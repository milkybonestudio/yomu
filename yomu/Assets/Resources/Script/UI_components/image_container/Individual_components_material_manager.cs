

using UnityEngine;



public struct Individual_components_material_manager {

        public static Individual_components_material_manager Construct( SpriteRenderer _render ){

            Individual_components_material_manager manager = default;

                manager.material = new Material( Shaders.individual_components );
                _render.material = manager.material;

            return manager;

        }

        public Material material;
        public string name;
        
        // public void Change_material( Material _new_material ){ 

        //         GameObject.Destroy( render.material );  // precisa
        //         render.material = _new_material; 

        // }

        public void Destroy(){

            if( material != null )
                { GameObject.Destroy( material ); }

        }


        public void Update_material(){
            
                if( material == null )
                    { return; }

                if( have_mask )
                    { Update_mask(); }

                if( have_mask_position )
                    { Update_mask_position(); }

        }


        // ** MASK SELF


        private bool have_mask;

        public Vector2 mask_dimensions;
        public Vector2 new_mask_dimensions;

        // public float new_mask_width;
        // public float new_mask_height;

        public void Add_mask( float _width, float _height ){

                // Console.Log( "Veio Add_mask" );

                new_mask_dimensions.x += _width;
                new_mask_dimensions.y += _height;

                // Console.Log( "Antes de adicionar" );

                // Console.Log( "new_mask_width " + new_mask_dimensions.x  );
                // Console.Log( "mask_width " + mask_dimensions.x  );

                // Console.Log( "new_mask_height " + new_mask_dimensions.y  );
                // Console.Log( "mask_height " + mask_dimensions.y  );
                // Console.Log("--------------" );


        }

        public void Set_mask( float _width, float _height ){

                Console.Log( "VEIO SET MASK" );

                if( !!!( have_mask ) )
                    { CONTROLLER__errors.Throw( $"in the ui { name } tried to change the mas but the mask was not give Apply" ); }


                Console.Log( "_width: " + _width );
                Console.Log( "_height: " + _height );

                new_mask_dimensions.x = _width;
                new_mask_dimensions.y = _height;


                Console.Log( "_width: " + _width );
                Console.Log( "_height: " + _height );


        }



        public void Activate_mask( float _initial_width, float _initial_height ){


                if( have_mask )
                    { return; }
                
                // Console.Log( "_initial_width: " + _initial_width );
                // Console.Log( "_inital_height: " + _initial_height );

                have_mask = true;
                material.SetInt( Shaders.individual_components_mask_is_active, 1 );

                mask_dimensions.x =_initial_width;
                mask_dimensions.y = _initial_height;

                new_mask_dimensions = mask_dimensions;


                material.SetVector( Shaders.individual_components_mask_dimensions, mask_dimensions );

                // Console.Log( "mask_width: " + mask_dimensions.x );
                // Console.Log( "mask_height: " + mask_dimensions.y );

                

        }


        public void deactive_mask(){

                if( !!!( have_mask ) )
                    { return; }

                have_mask = false;
                material.SetInt( Shaders.individual_components_mask_is_active, 0 );

                mask_dimensions.x = 0;
                mask_dimensions.y = 0;

                return;
                
        }



        public void Update_mask(){


                if( new_mask_dimensions == mask_dimensions )
                    { return;}

                material.SetVector( Shaders.individual_components_mask_dimensions, new_mask_dimensions ); 
                mask_dimensions = new_mask_dimensions;

                return;
            
        }


        // ** MASK POSITION

        // ** use only for plat simple stuff
        // ** if the container move all move -> best not use 

        // ** depois fazer uma verçao que vai usar outra camera para gerar uma texture completa, essa pode mover rotacionar e os krl


        private bool have_mask_position;

        //  x,  y,  width,  height
        public Vector4 mask_position_variables;
        public Vector4 new_mask_position_variables;


        public UI_component mask_position_reference_component;


        public void Add_mask_position( float _x_position, float _y_position ){


                if( !!!( have_mask_position ) )
                    { CONTROLLER__errors.Throw( $"in the ui { name } tried to change the mas but the mask was not give Apply" ); }

                new_mask_position_variables.x += ( _x_position * PPU.value );
                new_mask_position_variables.y += ( _y_position * PPU.value );
                
        }
        

        public void Add_mask_position_dimensions( float _width, float _height ){


                if( !!!( have_mask_position ) )
                    { CONTROLLER__errors.Throw( $"in the ui { name } tried to change the mas but the mask was not give Apply" ); }

                new_mask_position_variables.z += _width;
                new_mask_position_variables.w += _height;
                
        }


        public void Set_mask_position_dimensions( float _width, float _height ){

                if( !!!( have_mask_position ) )
                    { CONTROLLER__errors.Throw( $"in the ui { name } tried to change the mas but the mask was not give Apply" ); }

                new_mask_position_variables.z = _width;
                new_mask_position_variables.w = _height;

        }




        public void Set_mask_position( float _x_position, float _y_position ){

                if( !!!( have_mask_position ) )
                    { CONTROLLER__errors.Throw( $"in the ui { name } tried to change the mas but the mask was not give Apply" ); }

                new_mask_position_variables.x = _x_position;
                new_mask_position_variables.y = _y_position;

        }




        public void Activate_mask_position( float _initial_width, float _initial_height, UI_component _position_reference_component ){

                
                mask_position_reference_component = _position_reference_component;

                if( have_mask_position )
                    { return; }

                have_mask_position = true;                

                mask_position_variables.z = _initial_width;
                mask_position_variables.w = _initial_height;

        }


        public void Deactive_mask_position(){

                if( !!!( have_mask_position ) )
                    { return; }

                have_mask_position = false;
                material.SetInt( Shaders.individual_components_mask_position_is_active, 0 );

                new_mask_position_variables = default;
                                 
        }


        public bool mask_position_initiated; // ** there is not a gameObject in the Activate()

        public void Update_mask_position(){


                if( !!!( mask_position_initiated ) )
                    {

                        // ** GET POSITION
                        Vector3 position = mask_position_reference_component.body.body_container.transform.position; // ** NEED GLOBAL NOT CACHE

                        
                        new_mask_position_variables.x = position.x;
                        new_mask_position_variables.y = position.y;

                        mask_position_initiated = true;

                        // copia para o new
                        new_mask_position_variables = mask_position_variables;
                        

                        material.SetInt( Shaders.individual_components_mask_position_is_active, 1 );
                        material.SetVector( Shaders.individual_components_mask_position_variables, mask_position_variables );

                        return;
                        
                    }

                // --- UPDATE POSITION

                //mark ver depois
                // Vector3 anchor_position = mask_position_reference_component.local_position;
                Vector3 anchor_position = Vector3.zero;
                

                    new_mask_position_variables.x = anchor_position.x;
                    new_mask_position_variables.y = anchor_position.y;
                

                bool need_update = false;

                         if( FLOAT.Abs( new_mask_position_variables.w - mask_position_variables.w ) > 0.05f )
                            { 
                                need_update = true;
                            }
                    else if( FLOAT.Abs( new_mask_position_variables.x - mask_position_variables.x ) > 0.05f )
                            { 
                                need_update = true;
                            }
                    else if( FLOAT.Abs( new_mask_position_variables.y - mask_position_variables.y ) > 0.05f )
                            { 
                                need_update = true;
                            }
                    else if( FLOAT.Abs( new_mask_position_variables.z - mask_position_variables.z ) > 0.05f )
                            { 
                                need_update = true;
                            }
                    

                if( need_update )
                    {
                        mask_position_variables = new_mask_position_variables;
                        material.SetVector( Shaders.individual_components_mask_position_variables, mask_position_variables );
                        Console.Log( "will change to " + mask_position_variables );
                    }


        }




}
