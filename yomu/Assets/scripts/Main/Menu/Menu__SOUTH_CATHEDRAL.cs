using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;


// ** Menu seria uma interface, vai ter coisas como MENU__default, MENU__halloween etc
unsafe public class Menu__SOUTH_CATHEDRAL : PROGRAM_MODE { 


        public static Menu instancia;
        public static Menu Pegar_instancia(){ return instancia; }
        
        public override void Construct(){ return; }
        public override Transition_program Construct_transition( Transition_program_data _data ){ 

                Transition_program transition = Transition_program.Get();

                return transition;

        }

        // --- CONTROLADORES

        public Controlador_tela_menu controlador_tela_menu;

        public Tipo_menu_background menu_background;
            
        // --- BLOCOS

        public Galeria_menu galeria_menu;
        public Personagens_menu personagens_menu;
        public Configuracoes_menu configuracoes_menu;
        public Novo_jogo_menu novo_jogo_menu;
        


        public Action[] updates;



        // --- OPCOES

        public GameObject opcoes_container;
        public Interativo_menu[] menu_opcoes_arr;
        public UI_button[] botoes = new UI_button[ 5 ];



        public Menu_bloco estado_atual = Menu_bloco.novo_jogo;        
        public CONTROLLER__data controlador_dados;


    public override void Clean_resources(){ throw new NotImplementedException(); }

    // ** precisa acrescentar Control_flow _control_flow quando tirar o mono
    public override void Update( Control_flow _flow ){


            
            return;

            bool esta_nos_botoes = Update_botoes();

            if( esta_nos_botoes )
                { return; }
            
            switch( estado_atual ){


                    case Menu_bloco.transition: break;
                    case Menu_bloco.novo_jogo: novo_jogo_menu.Update(); break;
                    case Menu_bloco.configuracoes: configuracoes_menu.Update(); break;

                    case Menu_bloco.galeria:  galeria_menu.Update(); break;
                    case Menu_bloco.personagens:  personagens_menu.Update(); break;
                    case Menu_bloco.saves:  ; break;
                    
            }

            return;

        }

        public override void Destroy(){
            
        }

        public bool Update_botoes(){

            
                // bool is_click =  Input.GetMouseButtonUp( 0 );
                
                for( int i = 0 ;    i <  botoes.Length ;   i++)
                    { botoes[ i ].Update( null ); }

                return false ;

        }

        public void Finalizar(){

                //mark
                // ** vai deixar null o menu e vai destuir o game_object que vier do prefab
                //Mono_instancia.DestroyImmediate();
                // canvas = null;
                // canvas_menu = null;
                // canvas_menu_movel = null;
                // canvas_menu_image  = null;
                // canvas_menu_rect  = null;
            
        }







     
    
}
