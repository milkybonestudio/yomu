using UnityEngine;


public abstract class Component {


        public RESOURCE__structure_copy structure;
        public GameObject component_container;

        public string name;

        public Component_data data = Component_data.Construct();

        public void Instanciate( GameObject _place_to_instanciate ){

            structure.Instanciate( _place_to_instanciate );
            component_container = structure.structure_game_object;


        }



        // ** passar com base.Update()
        public virtual void Update( Control_flow _control_flow ){

                if( component_container == null )
                    { return; }

                component_container.transform.localPosition = data.position.Calculate_final();
                component_container.transform.localRotation = data.rotation.Calculate_final();
                component_container.transform.localScale = data.scale.Calculate_final();

                // ** individual material update?
                
        }






        // --- CHANGE DATA

            public virtual void Change_global_multiplier( float _new_multiplier ){ data.Change_global_multiplier( _new_multiplier ); }

            // ** SCALE
                
                // 100%?
                public virtual void Rescale( float _new_scale_percent ){ float _new_scale = ( _new_scale_percent / 100f); data.scale.normal += new Vector3( _new_scale, _new_scale, _new_scale ); }
                    public virtual void Rescale( float _new_scale_percent_X, float _new_scale_percent_Y ){ data.scale.normal += new Vector3( ( _new_scale_percent_X/100f ), ( _new_scale_percent_Y/100f ), 0f ); }
                        public virtual void Rescale( Vector3 _new_scale ){ data.scale.normal += _new_scale; }

                    


                public virtual void Rescale_to( float _new_scale_percent ){ float _new_scale = ( _new_scale_percent / 100f); data.scale.normal = new Vector3( _new_scale, _new_scale, _new_scale ); }
                    public virtual void Rescale_to( float _new_scale_percent_X, float _new_scale_percent_Y ){ data.scale.normal = new Vector3( ( _new_scale_percent_X/100f ), ( _new_scale_percent_Y/100f ), data.scale.normal.z ); }
                        public virtual void Rescale_to( Vector3 _new_scale ){ data.scale.normal = _new_scale; }


                public virtual void Change_focus_scale( float _new_scale ){ data.scale.focus = new Vector3( _new_scale, _new_scale, _new_scale ); }
                    public virtual void Change_focus_scale( Vector3 _new_scale ){ data.scale.focus = _new_scale; }
                public virtual void Change_off_set_scale( Vector3 _position ){ data.scale.off_set = _position; }

                public virtual void Change_base_speed_per_second_scale( float _new_scale_percent ){ float _new_scale = ( _new_scale_percent / 100f); data.scale.base_speed_per_second = _new_scale; }
                

                public virtual void Force_scale(){  }


            // ** POSITION
                
                public virtual void Move( Vector3 _position ){ data.position.normal += _position; }
                    public virtual void Move( float _x, float _y, float _z = 0f ){ data.position.normal += new Vector3( _x, _y, _z ); }

                public virtual void Move_to( Vector3 _position ){ data.position.normal = _position; }
                    public virtual void Move_to( float _x, float _y, float _z ){ data.position.normal = new Vector3( _x, _y, _z ); }

                public virtual void Change_focus_position( Vector3 _position ){ data.position.focus = _position; }
                    public virtual void Change_focus_position( float _x, float _y, float _z ){ data.position.focus = new Vector3( _x, _y, _z ); }

                public virtual void Change_off_set_position( Vector3 _position ){ data.position.off_set = _position; }
                    public virtual void Change_off_set_position( float _x, float _y, float _z ){ data.position.off_set = new Vector3( _x, _y, _z ); }
                    
                public virtual void Change_base_speed_position( float _position ){ data.position.base_speed_per_second = _position; }
            

            public virtual void Force_move(){}


            // ** ROTATION
            
            
            public virtual void Rotate_to( Quaternion _rotation ){ data.rotation.normal = _rotation; }

            public virtual void Rotate( Quaternion _rotation ){ data.rotation.normal *= _rotation; }
                public virtual void Rotate( float _x, float _y, float _z ){ data.rotation.normal *= Quaternion.Euler( _x, _y, _z ); }

            public virtual void Change_focus_rotation( Quaternion _rotation ){ data.rotation.focus = _rotation; }
            public virtual void Change_off_set_rotation( Quaternion _rotation ){ data.rotation.off_set = _rotation; }
            public virtual void Change_base_speed_rotation( float _rotation ){ data.rotation.base_speed_per_second = _rotation; }
            













}
