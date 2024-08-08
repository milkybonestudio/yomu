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
using System.Runtime.CompilerServices;






public static class Teste_escopo {


        public static bool ativado = true;


        public static Dispositivo dispositivo_teste;

        public static GameObject teste_body;
        public static Image imagem;
        public static Rigidbody2D   body ;

        public static Animator anim ;

        public static int  run_1_HASH = 0;



        public static void Testar(){

                if( ! ( ativado ) ){ return; }
                // iniciar 
                teste_body = GameObject.Find("Tela/Canvas/Jogo");




                dispositivo_teste = Dispositivo__teste.Construir();
                
                dispositivo_teste.Descompactar_dados();
                dispositivo_teste.Ativar_dispositivo( teste_body );

                
                

                // dispositivo_teste.Definir_imagens();
                // dispositivo_teste.Carregar_imagens();
                // dispositivo_teste.Anexar_dispositivo( teste_body );
                // dispositivo_teste.Colocar_imagens();




                //byte[] dados_webp = System.IO.File.ReadAllBytes( "C:\\Users\\User\\Desktop\\yomu_things\\teste\\imagem_para_carregar.webp" );
                // Debug.Log( dados_webp.Length );
                
                // Color32[] cores = ( new WebP() ).Decode( dados_webp );

                // Debug.Log( cores.Length );

                // Sprite sprite = SPRITE.Transformar_colors_container_TO_sprite( cores );

//                byte[] dados_png = System.IO.File.ReadAllBytes( "C:\\Users\\User\\Desktop\\yomu_things\\teste\\a.png" );


                //GameObject.Find("Tela/Canvas/Jogo/EXCLUIR DEPOIS").GetComponent<Image>().sprite = SPRITE.Transformar_png_TO_sprite( dados_png );


                //GameObject.Find("Tela/Canvas/Jogo/EXCLUIR DEPOIS").GetComponent<Image>().sprite = ( new WebP()).Decode_2( dados_webp );





        }


        public static void Update(){


            dispositivo_teste.Update();


         


        }



}