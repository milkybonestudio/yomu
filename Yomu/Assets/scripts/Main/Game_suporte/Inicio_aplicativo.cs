using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio_aplicativo : MonoBehaviour{


    [ SerializeField ] public float tempo_video = 13;
    
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){


        tempo_video -= Time.deltaTime;
        if( tempo_video < 0 ){

            SceneManager.LoadSceneAsync("in_game" );

        }


        
    }
}
