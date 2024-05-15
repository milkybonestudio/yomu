using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lala_icon_UI : MonoBehaviour {

    void Start(){

        gameObject.GetComponent<Image>().color = Color.red;
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal , 500f  );
        rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical , 500f  );

    }

    void Update(){

        gameObject.transform.localPosition += new Vector3( 0.1f,0.1f, 0f);
        
    }
}
