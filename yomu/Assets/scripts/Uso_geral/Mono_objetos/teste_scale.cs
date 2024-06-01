using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste_scale : MonoBehaviour {
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if( Input.GetKey( KeyCode.P ) ){ g();}


        
    }

    Coroutine coroutine = null;


    
    [SerializeField] int n = 7;
    [SerializeField]float delta = 0.005f;


    void g(){

        if ( coroutine != null ){ 

            StopCoroutine( coroutine ); 
            gameObject.transform.localScale = new Vector3(1f,1f,1f);
            
        }

        coroutine = StartCoroutine( a() );

        IEnumerator a(){
               
            yield return null;

            Vector3 vec_acumulador = new Vector3(  1f,1f,1f  );
            
            int i = 0;

            

            for( i = 0 ; i < n  ;i++ ){

                vec_acumulador += new Vector3(  delta , - delta , 0f );
                gameObject.transform.localScale = vec_acumulador;
                Ajustar_posicao();
                yield return null;
                
            }

            
            for( i = 0 ; i < n  ;i++ ){

                vec_acumulador += new Vector3(  -delta ,  delta , 0f );
                gameObject.transform.localScale = vec_acumulador;
                Ajustar_posicao();
                yield return null;

            }
            coroutine = null;
            yield break;

        }


    }

    void  Ajustar_posicao() {

        float y_old  =  gameObject.GetComponent<RectTransform>().rect.height;
        float y_scale  = gameObject.transform.localScale[ 1 ];

        float nova_posicao = ( y_old * y_scale - 1080f ) / 2f;
        Debug.Log("nova_posicao: " + nova_posicao );

        gameObject.transform.localPosition = new Vector3( 0f , nova_posicao , 0f  );
        return;

    }
}
