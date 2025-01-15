

using UnityEngine;

public class Camera_switch_FADE : Camera_switch {




        public float alpha = 0f;

        public override void Start(){



        }


        public override bool Update(){

                alpha += ( Time.deltaTime * 2f );

                alpha = FLOAT.Set_max( alpha, 1f );
                
                controller_cameras.screen_transition_material.SetFloat( "_opacity", alpha );

                return ( alpha == 1f );

        }

        public override void Finish(){

            alpha = 0f;

        }

}