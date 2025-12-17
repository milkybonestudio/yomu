using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Personagens_menu {


        public GameObject personagens_container;

        // public Menu_objects_generico menu_personagens_botao_proximo;
        // public Menu_objects_generico menu_personagens_botao_anterior;

        public Interativo_menu[] personagens_arr;

        // tem que ser construido também 
        public Interativo_menu_personagem[] interativos_menu_personagem;


        // --- PARTE MOSTRAR PERSONAGEM

        // ** se null vai criar um novo
        public GameObject standart_container;



        


        public string[] descricoes_personagens; 
        public string[] descricoes_icones;
        public byte[] pngs_personagens; // [    ( 2 bytes ) ( 2 bytes ) ||     ]
        public Sprite[] icones_sprites;
        public Sprite[] standart_sprites;

        

        public void Criar_standart(  ){


                // standart_container = new GameObject( "Standart_personagem" );
                // standart_container.transform.SetParent( personagens_container, false );





        }

        



        public void Update(){


                if( Verificador_click_interativo_menu.Verificar( personagens_arr ) != -1 )
                        {
                                // --- CLICOU EM ALGUM 


                        }

            return;

        }



}