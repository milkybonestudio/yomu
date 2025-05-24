using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public struct Body_visual_data_SCALE_GENERIC {




        public void Set_off_set( float _x, float _y, float _z ){ new Vector3( _x, _y, _z ); }
        public void Set_off_set( Vector3 _position ){ off_set = _position; }



        public void Set_initial_scale( Vector3 _position ){ current = _position; normal = _position; }


        public void Force(){ force = true; }

            public void Add( Vector3 _position ){ Sinalize_new_data(); normal += _position; }
            public void Set( Vector3 _position ){ Sinalize_new_data(); normal = _position; }



        public void Set_base_speed_position( float _position ){ base_speed_per_second = _position; }
        public void Add_base_speed_position( float _position ){ base_speed_per_second += _position; }



        public void Start(){

                speed_per_second = 1f; // ** depois pegar por config
                base_speed_per_second = 1f;
                off_set = Vector3.zero;
                normal = Vector3.one;
                focus = Vector3.one;
                focus_active = false;
                current = Vector3.one;

                Sinalize_new_data();

        }

        // public float global_multiplier;


        public float speed_per_second; // ** pode puxar de config
        public float base_speed_per_second; // ** eu controlo 


        
        public Vector3 current; // ** virtual, something can change it later, but this is the official one

        public bool focus_active;
        public Vector3 focus; // marker

        public Vector3 off_set; // marker
        public Vector3 normal; // marker

        private Vector3 final;

        private Vector3 unit_vector;

        
        private bool finished;
        private bool need_recalculate_final;
        private bool need_recalculate_unit_vector;


        public void Sinalize_new_data(){

            finished = false;
            need_recalculate_final = true;
            need_recalculate_unit_vector = true;
            
        }



        public bool force;


        public void Update( Transform _transform ){

                if( finished )
                    { return; }

                Scale( _transform );

        }

        [MethodImpl( MethodImplOptions.NoInlining )]
        public void Scale( Transform _transform ){


                if( need_recalculate_final )
                    {
                        need_recalculate_final = false;

                        final = ( normal + off_set );

                        if( focus_active )
                            { final += focus; }

                        // final.x *= global_multiplier ;
                        // final.y *= global_multiplier ;
                        // final.z *= global_multiplier ;

                    }

                if( force )
                    {
                        force = false;
                        finished = true;
                        current = final;
                        _transform.localScale = current;
                        return;
                    }


                Vector3 resto = default;

                    resto.x = ( current.x - final.x );
                    resto.y = ( current.y - final.y );
                    resto.z = ( current.z - final.z );
                
                float distance_2 = ( resto.x * resto.x ) + ( resto.y * resto.y ) + ( resto.z * resto.z ) ;

                if( need_recalculate_unit_vector )
                    {
                        need_recalculate_unit_vector = false;
                        float distance_inverse = ( 1f / Mathf.Sqrt( distance_2 ) );

                            unit_vector.x = ( resto.x * distance_inverse );
                            unit_vector.y = ( resto.y * distance_inverse );
                            unit_vector.z = ( resto.z * distance_inverse );
                    }



                float pixels_speed_frame = ( base_speed_per_second * speed_per_second * Time.deltaTime );

                if( distance_2 <= pixels_speed_frame * pixels_speed_frame )
                    {  
                        finished = true;
                        current = final;
                    }
                    else
                    {
                        finished = false;

                        current.x -= ( unit_vector.x * pixels_speed_frame );
                        current.y -= ( unit_vector.y * pixels_speed_frame );
                        current.z -= ( unit_vector.z * pixels_speed_frame );
                    }
                

                // ** MOVE
                
                _transform.localScale = current; 


        }


}

