using UnityEngine;

public enum Body_scale_type {

    generic,

}


public partial struct Body_visual_data_SCALE {

        public Body_visual_data_SCALE_GENERIC generic;
        public Body_scale_type current_type;



        public Vector3 Get_current(){

            if( current_type == Body_scale_type.generic )
                { return generic.current; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); return default;
            }
        

        }



        public void __Set_initial_scale__( Vector3 _position ){

                switch( current_type ){

                    case Body_scale_type.generic: generic.Set_initial_scale( _position ); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;

                }

        }



        public void Set_off_set( float _x, float _y, float _z ){ new Vector3( _x, _y, _z ); }
        public void Set_off_set( Vector3 _position ){ 
            
            if( current_type == Body_scale_type.generic )
                { generic.Set_off_set( _position ); return; }

            switch( current_type ){ 
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }            

        }



        public void Set_base_speed( float _position ){
            
            if( current_type == Body_scale_type.generic )
                { generic.Set_base_speed_position( _position ); return; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }       

        }

        public void Add_base_speed( float _position ){
            
            if( current_type == Body_scale_type.generic )
                { generic.Add_base_speed_position( _position ); return; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }       

        }




        public int __Update__( Transform _transform ){

                        
            if( current_type == Body_scale_type.generic )
                { return generic.Update( _transform ); }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); return 0;
            }

        }


        public void Force(){ 
            
            if( current_type == Body_scale_type.generic )
                { generic.Force(); return; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }
        }


        public void Add( float _value ){ Add( new Vector3( _value, _value, _value ) );}
        public void Add( float _x, float _y, float _z = 0f ){ Add( new Vector3( _x, _y, _z ) );}
        public void Add( Vector3 _position ){ 

            if( current_type == Body_scale_type.generic )
                { generic.Add( _position ); return; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }
            
        }

        public void Set( float _value ){ Set( new Vector3( _value, _value, _value ) );}
        public void Set( float _x, float _y, float _z ){ Set( new Vector3( _x, _y, _z ) ); }
        public void Set( Vector3 _position ){ 

            if( current_type == Body_scale_type.generic )
                { generic.Set( _position ); return; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }

        }

        public void Sinalize_new_data(){

            if( current_type == Body_scale_type.generic )
                { generic.Sinalize_new_data(); return; }

            switch( current_type ){
                default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
            }


        }


        public void __Start__( Body_scale_type _type, Body_scale_type_data _data ){

                current_type = _type;

                switch( current_type ){
                    case Body_scale_type.generic: generic.Start(); break;
                    default: CONTROLLER__errors.Throw( $"Can not handle the type <Color=lightBlue>{ current_type }</Color>" ); break;
                }

        }






}

