using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acid_flower : MonoBehaviour {


    public GameObject mob = null; 

    void Start() {
    
       // mob = new Mob() ;
    
      //  BLOCO_PLATAFORMA.Add_mob( this );
        
    }

    


    void Update() {

        // aqui seria a propria AI 

        if( Input.GetKey( KeyCode.LeftArrow ) ) gameObject.transform.localPosition += new Vector3( -1f , 0, 0f );
        if( Input.GetKey( KeyCode.RightArrow ) ) gameObject.transform.localPosition += new Vector3( 1f , 0 , 0f );


        
        
    }
}
