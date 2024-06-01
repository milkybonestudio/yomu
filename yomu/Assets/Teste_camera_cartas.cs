using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste_camera_cartas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start( ) {


    }

    // Update is called once per frame
    void Update( ) {

            gameObject.transform.localPosition += ( new Vector3( -0.1f , -0.1f, 0f  ) );
            Debug.Log("x: " + gameObject.transform.localRotation.x );
            float novo_x = gameObject.transform.localRotation.x * 100f - 0.1f ; 
            Debug.Log("novox : " + novo_x );
            gameObject.transform.localRotation = ( Quaternion.Euler(   25f , 25f , 25f ) );
            // gameObject.transform.localRotation = ( Quaternion.Euler( ( (gameObject.transform.localRotation.x * 180f ) - 0.1f), (gameObject.transform.localRotation.y * 180f ),  (gameObject.transform.localRotation.z * 180f ) )  );
            


    }
}
