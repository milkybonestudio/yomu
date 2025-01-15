using UnityEngine;

public struct Component_visual_data_SCALE {


        public void Start(){

                speed_per_second = 1f; // ** depois pegar por config
                base_speed_per_second = 1f;
                off_set = Vector3.zero;
                normal = Vector3.one;
                focus = Vector3.one;
                focus_active = false;
                current = Vector3.one;

        }

        public float global_multiplier;


        public float speed_per_second; // ** pode puxar de config
        public float base_speed_per_second; // ** eu controlo 


        
        public Vector3 current; // ** virtual, something can change it later, but this is the official one

        public bool focus_active;
        public Vector3 focus; // marker

        public Vector3 off_set; // marker
        public Vector3 normal; // marker

        public Vector3 final;



        public Vector3 Calculate_final(){

                // Console.Log( "global_multiplier: " + global_multiplier );
                // Console.Log( "off_set: " + off_set );
                // Console.Log( "normal: " + normal );
                // Console.Log( "final: " + final );
                

                final = ( normal + off_set );

                if( focus_active )
                    { final += focus; }

                final.x *= global_multiplier ;
                final.y *= global_multiplier ;

                Vector3 resto = ( current - final );

                // Console.Log( "Resto0: " + resto );

                float frame_difference = base_speed_per_second * speed_per_second * Time.deltaTime;


                Vector3 resto_abs = resto;
                
                    resto_abs.x = FLOAT.Abs( resto.x );
                    resto_abs.y = FLOAT.Abs( resto.y );
                    resto_abs.z = FLOAT.Abs( resto.z );

                float max = 0f;

                if( resto_abs.x  > max )
                    { max = resto_abs.x; }

                if( resto_abs.y  > max )
                    { max = resto_abs.y; }

                if( resto.z > max )
                    { max = resto_abs.z; }

                if( max < 0.005f )
                    { current = final; return current; }
                
                float frame_max = frame_difference / max;

                current.x -= resto.x * ( frame_max );
                current.y -= resto.y * ( frame_max );
                current.z -= resto.z * ( frame_max );

                return current;
                

        }



}
