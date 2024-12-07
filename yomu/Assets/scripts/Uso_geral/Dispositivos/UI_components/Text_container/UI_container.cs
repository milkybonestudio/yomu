using UnityEngine;


public struct UI_container {

    
        public GameObject game_object;


        // --- GENERAL

        public void Hide(){ game_object.SetActive( false ); }
        public void Show(){ game_object.SetActive( true ); }



        // --- MOVIMENTO

        public void Move( float _x_pixels, float _y_pixels ){ game_object.transform.localPosition += new Vector3( _x_pixels, _y_pixels, 0f ); }
        public void Set_position( float _x_position, float _y_position ){ game_object.transform.localPosition = new Vector3( _x_position, _y_position, game_object.transform.localPosition.z ); }


        public void Add_position_X( float _x_pixels ){ game_object.transform.localPosition += new Vector3( _x_pixels, 0f, 0f ); }
        public void Set_position_X( float _x_pixels ){ game_object.transform.localPosition = new Vector3( _x_pixels, game_object.transform.localPosition.y, game_object.transform.localPosition.z ); }


        public void Add_position_Y( float _y_pixels ){ game_object.transform.localPosition += new Vector3( _y_pixels, 0f ); }
        public void Set_position_Y( float _y_pixels ){ game_object.transform.localPosition = new Vector3(  game_object.transform.localPosition.x, _y_pixels, game_object.transform.localPosition.z ); }
        


        // --- SCALE
        public void Add_scale_simple( float _scale ){ game_object.transform.localScale += new Vector3( _scale, _scale, _scale ); }
        public void Set_scale_simple( float _scale ){ game_object.transform.localScale = new Vector3( _scale, _scale, _scale ); }


        public void Add_scale( float _scale ){ game_object.transform.localScale += new Vector3( _scale, _scale, _scale ); }
        public void Set_scale( float _scale_x, float _scale_y, float _scale_z ){ game_object.transform.localScale = new Vector3( _scale_x, _scale_y, _scale_z ); }


        public void Add_scale_X( float _scale ){ game_object.transform.localScale += new Vector3( _scale, 0f, 0f ); }
        public void Set_scale_X( float _scale ){ game_object.transform.localScale = new Vector3( _scale, 0f, 0f ); }


        public void Add_scale_Y( float _scale ){ game_object.transform.localScale += new Vector3( 0f, _scale, 0f ); }
        public void Set_scale_Y( float _scale ){ game_object.transform.localScale = new Vector3( 0f, _scale, 0f ); }

        // --- ROTATION

        public void Add_rotation_X( float _rotation_degrees ){ game_object.transform.localRotation *= Quaternion.Euler( _rotation_degrees, 0f, 0f ); }
        public void Set_rotation_X( float _rotation_degrees ){ game_object.transform.localRotation *= Quaternion.Euler( _rotation_degrees, 0f, 0f ); }

        public void Add_rotation_Y( float _rotation_degrees ){ game_object.transform.localRotation *= Quaternion.Euler( 0f, _rotation_degrees, 0f ); }
        public void Set_rotation_Y( float _rotation_degrees ){ game_object.transform.localRotation *= Quaternion.Euler( 0f, _rotation_degrees, 0f ); }

        public void Add_rotation_Z( float _rotation_degrees ){ game_object.transform.localRotation *= Quaternion.Euler( 0f, 0f, _rotation_degrees ); }
        public void Set_rotation_Z( float _rotation_degrees ){ game_object.transform.localRotation = Quaternion.Euler( 0f, 0f, _rotation_degrees ); }






}