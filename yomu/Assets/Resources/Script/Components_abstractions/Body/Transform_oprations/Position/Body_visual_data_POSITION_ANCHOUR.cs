using UnityEngine;


public partial struct Body_visual_data_POSITION_ANCHOUR {

        public Body_position_type current_type;
        
        public Body_visual_data_POSITION__GENERIC generic_container;
        public Body_visual_data_POSITION__GENERIC generic_self;


        public void __Set_current_initial_position__( Vector3 _position ){

                switch( current_type ){

                    case Body_position_type.generic: generic_container.Set_initial_position( ( -1f * _position) ); generic_self.Set_initial_position( _position ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

                }

        }



        public void Set_off_set( float _x, float _y, float _z ){ new Vector3( _x, _y, _z ); }
        public void Set_off_set( Vector3 _position ){ 

            switch( current_type ){

                case Body_position_type.generic: generic_container.Set_off_set( ( -1f * _position) ); generic_self.Set_off_set( _position ); break;
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

            }            

        }



        public void Set_base_speed_position( float _position ){

            switch( current_type ){

                case Body_position_type.generic: generic_container.Set_base_speed_position( _position ); generic_self.Set_base_speed_position( _position ); break;
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

            }       

        }

        public void Add_base_speed_position( float _speed ){

            switch( current_type ){

                case Body_position_type.generic: generic_container.Add_base_speed_position( _speed ); generic_self.Add_base_speed_position( _speed ); break;
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

            }       

        }




        public void __Update__( Transform _transform_container, Transform _transform_self ){

            
            switch( current_type ){

                case Body_position_type.generic: generic_container.Update( _transform_container ); generic_self.Update( _transform_self ); break;
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

            }

        }


        public void Force(){ 

            switch( current_type ){
                case Body_position_type.generic: generic_container.Force(); generic_self.Force(); break;
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }
        }



        public void Add( float _x, float _y, float _z = 0f ){ Add( new Vector3( _x, _y, _z ) );}
        public void Add( Vector3 _position ){ 

            switch( current_type ){
                case Body_position_type.generic: generic_container.Add( ( -1f * _position ) ); generic_self.Add( _position ); break;
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }
            
        }

        public void Set( float _x, float _y, float _z ){ Set( new Vector3( _x, _y, _z ) ); }
        public void Set( Vector3 _position ){ 

            switch( current_type ){

                case Body_position_type.generic: generic_container.Set( ( -1f * _position ) ); generic_self.Set( _position ); break;
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

            }

        }

        public void Sinalize_new_data(){

            switch( current_type ){

                case Body_position_type.generic: generic_container.Sinalize_new_data(); generic_self.Sinalize_new_data(); break;
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

            }


        }


        public void __Start__( Body_position_type _type, Body_position_type_data _data  ){

                current_type = _type;

                switch( current_type ){
                    case Body_position_type.generic: generic_container.Start(); generic_self.Start(); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
                }

        }






}

