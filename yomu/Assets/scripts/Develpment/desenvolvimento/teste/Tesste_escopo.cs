using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Png_decoder;
using Unity.Collections;
using UnityEngine.SceneManagement;


public static class Teste_escopo {


        public static bool ativado = true;


        public static GameObject teste_body;
        public static Image imagem;
        public static Rigidbody2D   body ;

        public static Animator anim ;

        public static int  run_1_HASH = 0;


        public static void Testar(){

                if( ! ( ativado ) ){ return; }
                // iniciar 
                teste_body = GameObject.Find("Tela/Canvas/Jogo");












        }


        public static void Update(){


         


        }



}