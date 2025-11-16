using System.Collections;
using UnityEngine;


public enum Body_rotation_type {

    generic, 
    
}

public struct Body_visual_data_ROTATION {


        public Body_visual_data_ROTATION_GENERIC generic;
        public Body_rotation_type current_type;


        public Quaternion Get_current(){

            if( current_type == Body_rotation_type.generic )
                { return generic.current; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); return default;
            }
        

        }


        public void __Set_initial_rotation__( Quaternion _rotation ){

                switch( current_type ){

                    case Body_rotation_type.generic: generic.Set_initial_rotation( _rotation ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

                }

        }



        public void Set_off_set( float _x, float _y, float _z ){ Quaternion.Euler( _x, _y, _z ); }
        public void Set_off_set( Quaternion _rotation ){ 


            switch( current_type ){

                case Body_rotation_type.generic: generic.Set_off_set( _rotation ); break;
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

            }            

        }


        public void Set_base_speed( float _rotation ){


            if( current_type == Body_rotation_type.generic )
                { generic.Add_base_speed( _rotation ); return; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }       

        }

        public void Add_base_speed( float _rotation ){


            if( current_type == Body_rotation_type.generic )
                { generic.Add_base_speed( _rotation ); return; }
            

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }       

        }




        public int __Update__( Transform _transform ){


            if( current_type == Body_rotation_type.generic )
                { return generic.Update( _transform ); }
            
            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); return 0;
            }

        }


        public void Force(){ 

            if( current_type == Body_rotation_type.generic )
                { generic.Force(); return; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }
        }



        public void Add( float _x, float _y, float _z = 0f ){ Add( Quaternion.Euler( _x, _y, _z ) );}
        public void Add( Quaternion _rotation ){ 


            if( current_type == Body_rotation_type.generic )
                { generic.Add( _rotation ); return; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }
            
        }

        public void Set( float _x, float _y, float _z ){ Set( Quaternion.Euler( _x, _y, _z ) ); }
        public void Set( Quaternion _rotation ){ 


            if( current_type == Body_rotation_type.generic )
                { generic.Set( _rotation ); return; }

            switch( current_type ){

                case Body_rotation_type.generic: generic.Set( _rotation ); break;
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

            }

        }

        public void Sinalize_new_data(){


            if( current_type == Body_rotation_type.generic )
                { generic.Sinalize_new_data(); return; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }


        }


        public void __Start__( Body_rotation_type _type, Body_rotation_type_data _data  ){

                current_type = _type;

                switch( current_type ){
                    case Body_rotation_type.generic: generic.Start(); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
                }

        }








}


