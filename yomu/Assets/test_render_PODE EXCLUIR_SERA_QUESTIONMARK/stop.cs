using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop : MonoBehaviour
{
    Camera c;
    GameObject ob;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        ob = GameObject.Find( "character" );
        c = ob.GetComponent<Camera>();
        ob.SetActive( false );

        
        
    }

    // Update is called once per frame
    void Update()
    {

        if( Input.GetKeyDown( KeyCode.O ) )
            { ob.SetActive( false ); }


        if( Input.GetKeyDown( KeyCode.P ) )
            { ob.SetActive( true ); }

        
    }
}
