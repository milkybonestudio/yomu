using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class Galeria_menu {



      public GameObject galery_container;

      public Menu_objects_generico menu_galery_botao_proximo;
      public Menu_objects_generico menu_galery_botao_anterior;

      public Menu_objects_generico[] menu_galery_arr = new Menu_objects_generico[ 8 ];

      public int numero_pagina_galeria = 0;






      public void Update(){

            return;

      }


      public void Passar_pagina_galeria(){


            int max =  ( Controlador_configuracoes.Pegar_instancia().galeria_imagens_liberadas.Length / 6 );

            if(  numero_pagina_galeria  +  1  > max  ){ return; }

            numero_pagina_galeria++;

            Verificar_galeria();
            return;

      }


      public void Voltar_pagina_galeria(){

            if(  numero_pagina_galeria  - 1  < 0  ) { return; }
            numero_pagina_galeria--;   
            Verificar_galeria();
            return;

      }





      public void Verificar_galeria(){

            // int p0 =  numero_pagina_galeria * 6;
            // for(int i = 0 ;  i < 6 ; i++){

            //     bool esta_liberada = controlador_configuracoes.galeria_imagens_liberadas[i];
            //     if( esta_liberada ){  

            //       // tem que passar depois para o sistema proprio
            //       string path_imagem = "images/menu_images/galeria_image_" + Convert.ToString( i );
            //       Sprite imagem_persoangem_galeria_quadro = Resources.Load<Sprite>( path_imagem );
            //       menu_galery_arr[i].image.sprite = imagem_persoangem_galeria_quadro;

            //     }

            // }

            return;

      }





}