using UnityEngine;

public struct Body_data {


        public static Body_data Construct(){

                Body_data ret = new Body_data();
                
                ret.scale.Start();
                ret.position.Start();
                ret.rotation.Start();
                ret.off_set_rotation.Start();

                ret.Change_global_multiplier( 1f );

                return ret;
        }   



        // ** all


        public Body_visual_data_SCALE scale;
        public Body_visual_data_POSITION position;
        public Body_visual_data_ROTATION rotation;
        public Body_visual_data_ROTATION off_set_rotation;

        



        public void Set_focus( bool _is_focus ){

            position.focus_active = _is_focus;
            scale.focus_active = _is_focus;
            rotation.focus_active = _is_focus;

        }

        public void Change_global_multiplier( float _new ){


                position.global_multiplier = _new;
                scale.global_multiplier = _new;
                rotation.global_multiplier = _new;
                off_set_rotation.global_multiplier = _new;

        }


        // --- CHANGE DATA

                public void Change_focus_scale( float _new_scale ){ scale.focus = new Vector3( _new_scale, _new_scale, _new_scale ); }
                    public void Change_focus_scale( Vector3 _new_scale ){ scale.focus = _new_scale; }
                public void Change_off_set_scale( Vector3 _position ){ scale.off_set = _position; }

                public void Change_base_speed_per_second_scale( float _new_scale_percent ){ float _new_scale = ( _new_scale_percent / 100f); scale.base_speed_per_second = _new_scale; }
                

                public void Change_focus_position( Vector3 _position ){ position.focus = _position; }
                    public void Change_focus_position( float _x, float _y, float _z ){ position.focus = new Vector3( _x, _y, _z ); }

                public void Change_off_set_position( Vector3 _position ){ position.off_set = _position; }
                    public void Change_off_set_position( float _x, float _y, float _z ){ position.off_set = new Vector3( _x, _y, _z ); }
                    
                public void Change_base_speed_position( float _position ){ position.base_speed_per_second = _position; }


            public void Change_focus_rotation( Quaternion _rotation ){ rotation.focus = _rotation; }
            public void Change_off_set_rotation( Quaternion _rotation ){ rotation.off_set = _rotation; }
            public void Change_base_speed_rotation( float _rotation ){ rotation.base_speed_per_second = _rotation; }



            public void Change_focus_rotation_off_set( Quaternion _rotation ){ off_set_rotation.focus = _rotation; }
            public void Change_off_set_rotation_off_set( Quaternion _rotation ){ off_set_rotation.off_set = _rotation; }
            public void Change_base_speed_rotation_off_set( float _rotation ){ off_set_rotation.base_speed_per_second = _rotation; }


















}
