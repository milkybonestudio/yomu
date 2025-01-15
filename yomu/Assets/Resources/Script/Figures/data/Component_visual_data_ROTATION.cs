using UnityEngine;

public struct Component_visual_data_ROTATION {



        public void Start(){

                speed_per_second = 1f; // ** depois pegar por config
                base_speed_per_second = 180f;
                focus_active = false;

                off_set = Quaternion.identity;
                normal = Quaternion.identity;
                focus = Quaternion.identity;


        }


        public float global_multiplier;

        public float speed_per_second; // ** pode puxar de config
        public float base_speed_per_second; // ** eu controlo 


        
    
        public Quaternion current; // ** virtual, something can change it later, but this is the official one

        public bool focus_active;
        public Quaternion focus; // marker

        public Quaternion off_set; // marker

        public Quaternion normal; // marker

        public Quaternion final;



        public Quaternion Calculate_final(){

            //mark 
            // ** nao esta fazendo direito, se esta em 0 e o ponto final é 370 ele nao pode só ir para o 10

            final = ( normal * off_set );

            if( focus_active )
                { final *= focus; }
            



            current = Quaternion.RotateTowards( current, final, ( base_speed_per_second * speed_per_second * Time.deltaTime ) );



            return current;
            

        }



}
