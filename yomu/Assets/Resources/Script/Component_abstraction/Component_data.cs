using UnityEngine;

public struct Component_data {


        public static Component_data Construct(){

                Component_data ret = new Component_data();
                
                ret.scale.Start();
                ret.position.Start();
                ret.rotation.Start();

                ret.Change_global_multiplier( 1f );

                return ret;
        }   



        // ** all


        public Component_visual_data_SCALE scale;
        public Component_visual_data_POSITION position;
        public Component_visual_data_ROTATION rotation;



        public void Set_focus( bool _is_focus ){

            position.focus_active = _is_focus;
            scale.focus_active = _is_focus;
            rotation.focus_active = _is_focus;

        }

        public void Change_global_multiplier( float _new ){


                position.global_multiplier = _new;
                scale.global_multiplier = _new;
                rotation.global_multiplier = _new;

        }




}
