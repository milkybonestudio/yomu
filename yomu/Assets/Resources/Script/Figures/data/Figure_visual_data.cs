using UnityEngine;

public struct Figure_visual_data {



        public static Figure_visual_data Construct(){

                Figure_visual_data ret = new Figure_visual_data();
                
                ret.scale.Start();
                ret.position.Start();
                ret.rotation.Start();

                ret.Change_global_multiplier( 1f );

                return ret;
        }   



        // ** all

        // ** close camera -> x>1 -> move -> k*d, scale-> k*scale
        public float global_multiplier;


        public Figure_visual_data_SCALE scale;
        public Figure_visual_data_POSITION position;
        public Figure_visual_data_ROTATION rotation;



        public void Set_focus( bool _is_focus ){

            position.focus_active = _is_focus;
            scale.focus_active = _is_focus;
            rotation.focus_active = _is_focus;

        }

        public void Change_global_multiplier( float _new ){

                global_multiplier = _new;

                    position.global_multiplier = _new;
                    scale.global_multiplier = _new;
                    rotation.global_multiplier = _new;

        }




}
