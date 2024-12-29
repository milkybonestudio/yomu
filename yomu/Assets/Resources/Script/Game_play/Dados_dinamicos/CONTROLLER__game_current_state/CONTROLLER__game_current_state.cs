using UnityEngine;

unsafe public class CONTROLLER__game_current_state {



        public static CONTROLLER__game_current_state instance;
        public static CONTROLLER__game_current_state Get_instance(){ return instance; }

        
        public Block_type current_block;
        public int modo_atual;
        public Input_device input_device_atual;



        public void Verify_plataform(){

            
                switch( Application.platform ){

                    case RuntimePlatform.WindowsPlayer: break;
                    default: CONTROLLER__errors.Throw( $"application can not handle { Application.platform }" ); break;
                }

        }


    

}