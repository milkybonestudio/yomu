using UnityEngine;

public struct Figure_visual_data_POSITION {


        public void Start(){

                speed_per_second = 1f; // ** depois pegar por config
                base_speed_per_second = 500f;

                focus_active = false;

                off_set = Vector3.zero;
                normal = Vector3.one;
                focus = Vector3.one;


        }


        public float speed_per_second; // ** pode puxar de config
        public float base_speed_per_second; // ** eu controlo 


        public float global_multiplier;
        
        // ** virtual
        public Vector3 current; // ** virtual, something can change it later, but this is the official one


        public bool focus_active;
        public Vector3 focus; // marker
        

        public Vector3 off_set; // marker
        public Vector3 normal; // ** set 


        public Vector3 final;


        public Vector2 Calculate_final(){



                final = ( off_set + normal );

                //Console.Log( "Final: " + final );

                if( focus_active )
                    { final += focus; }

                 final *= global_multiplier;

                
                Vector3 resto = ( current - final );

                float distance = Mathf.Sqrt( ( resto.x * resto.x ) + ( resto.y * resto.y ) );
                float frame_difference = ( base_speed_per_second * speed_per_second * Time.deltaTime );
                // Console.Log( "distancia" + distance );
                


                // Console.Log( "Current: " + current );
                // Console.Log( "Final: " + final );


                if( distance <= frame_difference )
                    {  current = final; return current;  }
                

                
                float alp = ( frame_difference / distance  );

                current.x -= ( alp * resto.x );
                current.y -= ( alp * resto.y );
                current.z -= ( alp * resto.z );

                Console.Log( "current: " + current );
                return current;
            

        }




}
