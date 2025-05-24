using UnityEngine;


public struct Device_animation_simple_2_points {


        public static Device_animation_simple_2_points Construct( Device _device ){

                Device_animation_simple_2_points d_animation = new Device_animation_simple_2_points();

                    d_animation.value_0.scale = Vector3.one;
                    d_animation.value_1.scale = Vector3.one;

                    d_animation.device = _device;
                    
                return d_animation;

        }

        public Basic_transform value_0;
        public Basic_transform value_1;

        public Device device;

        public void Change( int i ){

            
            if( i == 1 )
                {
                    device.body.position.Set( value_1.position );
                    device.body.rotation.Set( value_1.rotation );
                    device.body.scale.Set( value_1.scale );
                    return;
                }

            if( i == 0 )
                {
                    device.body.position.Set( value_0.position );
                    device.body.rotation.Set( value_0.rotation );
                    device.body.scale.Set( value_0.scale );
                    return;                    
                }

        }



}
