
using UnityEngine;

public struct Body_visual_data_ROTATION_GENERIC {



    public void Set_initial_rotation( Quaternion _anchour_rotation ){ current = _anchour_rotation; normal = _anchour_rotation; }


    public void Force(){ force = true; }

    public void Add( float _x, float _y, float _z ){ Add( Quaternion.Euler( _x, _y, _z ) ); }
    public void Add( Quaternion _anchour_rotation ){ Sinalize_new_data(); normal *= _anchour_rotation; }

    public void Set( float _x, float _y, float _z ){ Set( Quaternion.Euler( _x, _y, _z ) ); }
    public void Set( Quaternion _anchour_rotation ){ Sinalize_new_data(); normal = _anchour_rotation; }


    public void Add_off_set( float _x, float _y, float _z ){ Add_off_set( Quaternion.Euler( _x, _y, _z ) ); }
    public void Add_off_set( Quaternion _anchour_rotation ){ Sinalize_new_data(); off_set *= _anchour_rotation; }

    public void Set_off_set( float _x, float _y, float _z ){ Set_off_set( Quaternion.Euler( _x, _y, _z ) ); }
    public void Set_off_set( Quaternion _anchour_rotation ){ Sinalize_new_data(); off_set = _anchour_rotation; }


    public void Add_base_speed( float _x ){ base_speed_per_second += _x; }
    public void Set_base_speed( float _x ){ base_speed_per_second = _x; }




    public void Start(){

            speed_per_second = 1f; // ** depois pegar por config
            base_speed_per_second = 180f;
            focus_active = false;

            Sinalize_new_data();

            off_set = Quaternion.identity;
            normal = Quaternion.identity;
            focus = Quaternion.identity;

    }


    public float global_multiplier;
    public float speed_per_second; // ** pode puxar de config
    public float base_speed_per_second; // ** eu controlo 


    public Quaternion focus; // marker
        public bool focus_active;
    public Quaternion off_set; // marker
    public Quaternion normal; // marker

    public Quaternion current;
    public Quaternion final;

    public bool force;
    private bool finished;
    private bool need_recalculate_final;

    public void Sinalize_new_data(){

        finished = false;
        need_recalculate_final = true;

    }

    private void finish(){

        finished = true;
        need_recalculate_final = true;
        force = false;

    }

    
    public void Update( Transform _transform ){


        if( finished )
            { return; }

        Rotate( _transform );
        
    }

    private void Rotate( Transform _transform ){

        if( need_recalculate_final )
            {
                need_recalculate_final = false;

                final = normal * off_set;
                
                if( focus_active )
                    { final *= focus;}

            }

        if( force )
            {
                finish();
                current = final;
                _transform.localRotation = current;
                return;
            }
        
        if( Quaternion.Dot( current, final ) > 0.999f )
            { 
                finish();
                current = final;
                _transform.localRotation = current;
                return;
            }

        current = Quaternion.RotateTowards( current, final, ( base_speed_per_second * speed_per_second * Time.deltaTime ) );
        _transform.localRotation = current;

    }


}
