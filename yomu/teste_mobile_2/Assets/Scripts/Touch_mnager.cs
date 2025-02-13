using UnityEngine;


public enum Touch_state {

    off, 
    used,

}

public struct Touch_data {

    public Touch_state state;
    public Touch touch;

    public float time_pressed_ms;

    public Vector2 start_position;
    public Vector2 current_position;
    
}



public class Touch_manager {


        /*
                -> update touches 
                -> update abstracoes secundarias
        */

        // ** id -> index
        public Touch_data[] touches = new Touch_data[ 5 ];
        public int number_touches;

        public void Update(){

                float delta_time = Time.deltaTime;
                int slot;


                Touch[] touches_input = Input.touches;
                number_touches = touches_input.Length;



                slot = -1;
                while(  ++slot < touches.Length )
                    { touches[ slot ].state = Touch_state.off; }

                foreach( Touch touch in touches_input ){

                    int id = touch.fingerId;
                    if( touches[ id ].state == Touch_state.off )
                        { 
                            // --- START
                            touches[ id ].start_position = touch.position; 
                        }

                    touches[ id ].current_position = touch.position;
                    touches[ id ].state = Touch_state.used;
                    
                }


                // --- RESET NOT USED
                slot = -1;
                while(  ++slot < touches.Length ){ 

                    if( touches[ slot ].state == Touch_state.off )
                        { touches[ slot ] = default; } 

                }
                


        }


}

