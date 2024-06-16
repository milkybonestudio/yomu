using System.Collections;
using UnityEngine;


public static class Localizador_personagens {


    // vai abrir um grafico 
    
    public static int[] personagens_sendo_verificados = new int[ 100 ]; // max

    public static void Construir(){

        //  sempre que clicar F1


    }

    public static void Destruir(){

        // sempre que trocar de modo ou esconder as ferramentas


    }

    // se tiver algum metodo que precise de imput jogar no coroutine e esperar ele sair 
    public static bool esta_trancado_esperando_resposta = false;

    public static bool Update(){

        if( esta_trancado_esperando_resposta )
            { return false; }

        // vai adicionar personagem para verificar
        if( Input.GetKeyDown( KeyCode.RightControl ) && Input.GetKeyDown( KeyCode.A )  )
            { 



            }

        return true;

        



    }

     
    public static IEnumerator Pegar_novos_personagens() {

        string texto_para_pegar_personagens = "";

        while( true ){

            if(   Input.GetKey( KeyCode.KeypadEnter )   )
                {
                    // FINALIZXAR
                    // trim texto e pegar personagens 
                    // verifiar se eles existem 

                    yield break;


                }


            texto_para_pegar_personagens += Controlador_input.Pegar_teclas_presionadas();

            // Escrever novo valor tela () => fazer depois

            
            yield return null;


        }


    }







}