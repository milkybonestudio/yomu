using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio_aplicativo : MonoBehaviour{


        private bool ja_esta_carregando = false;

        [ SerializeField ] public float tempo_video = 11f;
        
    
        // Update is called once per frame
        void Update(){

                if( ja_esta_carregando ){ return; }

                tempo_video -= Time.deltaTime;

                if( tempo_video < 0 ){

                        ja_esta_carregando = true;
                        SceneManager.LoadSceneAsync("in_game" );

                }
                
        }

}
