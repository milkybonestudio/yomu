

// ** 
using UnityEngine;

public partial struct Body_visual_data_POSITION__GENERIC {


        public void Set_off_set( float _x, float _y, float _z ){ new Vector3( _x, _y, _z ); }
        public void Set_off_set( Vector3 _position ){ off_set = _position; }


        public void Set_initial_position( Vector3 _position ){
            current = _position; 
            normal = _position;
        }


        public void Force(){ force = true; }

            public void Add( Vector3 _position ){ Sinalize_new_data(); normal += _position; }
            public void Set( Vector3 _position ){ Sinalize_new_data(); normal = _position; }



        public void Set_base_speed_position( float _position ){ base_speed_per_second = _position; }
        public void Add_base_speed_position( float _position ){ base_speed_per_second += _position; }


        public void Start(){

            speed_per_second = 100f; // ** depois pegar por config
            base_speed_per_second = 100f;

            focus_active = false;

            off_set = Vector3.zero;
            normal = Vector3.one;
            focus = Vector3.one;

            Sinalize_new_data();

        }


        public float speed_per_second; // ** pode puxar de config
        public float base_speed_per_second; // ** eu controlo 


        public float global_multiplier;

        public bool force;
        public bool focus_active;

        private bool finished;
        private bool need_recalculate_final;
        private bool need_recalculate_unit_vector;

        public Vector3 focus;
        public Vector3 off_set;
        public Vector3 normal; 


        public Vector3 current;
        private Vector3 final;

        private Vector3 unit_vector;


        public void Sinalize_new_data(){

            finished = false;
            need_recalculate_final = true;
            need_recalculate_unit_vector = true;

        }


        public void Update( Transform _transform ){

            // Console.Log( "entrou update" );

            if( finished )
                { return; }
                
            Move( _transform );

        }


        private void finish(){

            finished = true;
            need_recalculate_final = true;
            need_recalculate_unit_vector = true;
            force = false;

        }

        private Vector3 Calculate_final(){

            Vector3 ret = normal;
                
                ret.x += off_set.x;
                ret.y += off_set.y;
                ret.z += off_set.z;

                if( focus_active )
                    {
                        ret.x += focus.x;
                        ret.y += focus.y;
                        ret.z += focus.z;
                    }
            
            return ret;

        }


        //performance
        // ** no inline? 
        // ** se precisar mover vai ter que carregar a fn mas se precisar mover a coisa mais pesada 
        // ** vai ser o transform.localPosition = thing
        private void Move( Transform _transform ){

                // --- VERIFICAR NOVO PONTO


                if( need_recalculate_final )
                    {
                        need_recalculate_final = false;
                        final = Calculate_final();
                    }


                if( force )
                    {
                        finish();
                        current = final;
                        // Console.Log( "will move" );
                        _transform.localPosition = ( current * PPU.value_inverse );
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


                float pixels_speed_frame = ( ( base_speed_per_second + speed_per_second ) * Time.deltaTime );
                // Console.Log( "pixels_speed_frame: " + pixels_speed_frame );

                if( distance_2 <= pixels_speed_frame * pixels_speed_frame )
                    {  
                        finish();
                        current = final;
                    }
                    else
                    {
                        finished = false;

                        current.x -= ( unit_vector.x * pixels_speed_frame );
                        current.y -= ( unit_vector.y * pixels_speed_frame );
                        current.z -= ( unit_vector.z * pixels_speed_frame );
                    }
                
                    resto = current;

                    resto.x *= PPU.value_inverse;
                    resto.y *= PPU.value_inverse;
                    resto.z *= PPU.value_inverse;

                    
                // ** MOVE
                _transform.localPosition = resto; 

        }


}
