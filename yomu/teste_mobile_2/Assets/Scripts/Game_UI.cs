using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_UI : MonoBehaviour{


    public Camera camera_UI;
    

    void Start(){}



    void Update(){

        int slot = -1;
        // Debug.Log( "<Color=lightBlue>----------------------------</Color>" );
        Touch_data[] datas = Player_controller.player.touch_manager.touches;
        // while( ++slot < datas.Length ){

        //     Debug.Log( $"touch { slot }: { datas[ slot ].state }" );

        // }

        Verify_UI();

    }

    public void Verify_UI(){

        if( Input.touchCount == 0 )
            { return; }


        // Debug.Log( "--------------------" );
        foreach( Touch t in Input.touches ){

                Vector3 click_position = t.position;
                Ray ray = camera_UI.ScreenPointToRay( click_position );

                bool have_something = Physics.Raycast( ray, out RaycastHit hit );

                if( !!!( have_something ) )
                    { return; }
                    
                Player_controller.player.Activate_UI( hit.transform.gameObject.name );

        }

    }

}
