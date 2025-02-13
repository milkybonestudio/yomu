using UnityEngine;


public struct Device_animation_simple {


        public static Device_animation_simple Construct( GameObject _game_object ){

                Device_animation_simple d_animation = new Device_animation_simple();

                    d_animation.value_0.scale = Vector3.one;
                    d_animation.value_1.scale = Vector3.one;
                    
                    d_animation.container = new Body();
                    d_animation.container.structure_container = _game_object;
                    d_animation.container.body_container = _game_object;
                    
                return d_animation;

        }


        public void Update(){ /*container.Update_body();*/ }

        public void Change( int i ){

            if( i == 1 )
                {
                    container.Move_to( value_1.position );
                    container.Rotate_to( value_1.rotation );
                    container.Rescale_to( value_1.scale );
                    return;
                }

            if( i == 0 )
                {
                    container.Move_to( value_0.position );
                    container.Rotate_to( value_0.rotation );
                    container.Rescale_to( value_0.scale );
                    return;                    
                }

        }


        public Basic_transform value_0;
        public Basic_transform value_1;

        public Body container;


}
