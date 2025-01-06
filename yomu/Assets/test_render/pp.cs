using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey( KeyCode.A ) )
            { gameObject.transform.localRotation *= Quaternion.Euler( 25f * Time.deltaTime, 25f * Time.deltaTime, 25f * Time.deltaTime  ); }
        
    }
}
