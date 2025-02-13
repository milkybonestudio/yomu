using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Albuin : MonoBehaviour{

    private float speed = 25f;

    public float time_alive;

    public Animator animator;

    void Start(){
        animator = gameObject.GetComponent<Animator>();
    }

    void Update(){


            time_alive += Time.deltaTime;

            if( time_alive > 15 )
                { return; }


            Vector3 position_player = Player_controller.player.gameObject.transform.localPosition;

            float dif = position_player.x - gameObject.transform.localPosition.x;
            if( ( dif ) > 10 || ( dif < - 10 ) )
                { animator.SetTrigger( "stop" ); return; }
            
            animator.SetTrigger( "run" );

            if( Player_controller.player.state == Player_state.sex )
                {  }
                else
                {
                    // Debug.Log( "time" );
                    // Debug.Log( "player x : " + position_player.x );
                    // Debug.Log( "albuin: " + gameObject.transform.localPosition.x );

                    float sign = 1f;
                    gameObject.transform.localScale = new Vector3( 1f, 1f, 1f );

                    if( position_player.x < gameObject.transform.localPosition.x )
                        { 
                            sign = -1f; 
                            gameObject.transform.localScale = new Vector3( -1f, 1f, 1f );
                        }

                    
                    gameObject.transform.localPosition += new Vector3( ( sign * speed * Time.deltaTime), 0f,0f );

                }

        
    }
}
