using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class Touch_container {


}

public class Main : MonoBehaviour{


    public Touch[] Get_touches(){ return Input.touches; }


    private Touch[] touches;

    private bool have_pre;
    private Touch touch_pre;
    public GameObject container;

    void Update(){

        // Debug.Log( ( Input.acceleration - Vector3.back ) );

        Debug.Log( "width: " + Screen.width );
        Debug.Log( "height: " + Screen.height );

        if( Input.touchCount != 0 )
            {   Handheld.Vibrate(); }


            
    }
}
