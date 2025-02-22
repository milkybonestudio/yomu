using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;




public enum Tipo_mudanca {

    sair, 
    entrar

}



public class BLOCO_story : BLOCK {

      
        // --- INSTANCIA

        public static BLOCO_story instancia;
        public static BLOCO_story Pegar_instancia(){ return instancia; }


        // --- INTERFACE

        
        public override void Finalizar(){}
        public override void Iniciar(){}
        public override void Destruir(){}
        public override Task_req Carregar_dados(){ return null; }


        // --- DEFAULT BLOCOS

        // ** vai ser struct para poder salvar 
        public Localizador_simples lidar_retorno_localizador;
        public Localizador_simples mudar_UI_localizador;
        public Localizador_simples mudar_input_localizador;
        

        // --- DADOS

        //public GameObject container_visual_novel;

        public Modo_visual_novel modo_visual_novel_atual = Modo_visual_novel.normal;
        public Screen_play screen_play = null;
        public Dados_figure_personagem[] dados;


        public  float  tempo_para_passar_cena_atutomatica_milisegundos;
        public  float  tempo_de_intervalo_entre_clicks_automaticos_milisegundos = 75f;
        public  float  tempo_padrao_para_iniciar_atutomatico_milisegundos = 1200f;

        public  int    space_skip_scene  = 1;
        public  bool   space_skip_scene_trava  = false;


        // --- CONTROLADORES

        public Controlador_UI_visual_novel controlador_UI_visual_novel;
        public Leitor_visual_novel leitor_visual_novel;
        public Controlador_tela_story controlador_tela_story;
        public Controlador_personagens_visual_novel controlador_personagens_visual_novel;

        
        // public Animacao animacao?
        public Bloqueador_cenas_visual_novel bloqueador = null;



      
        public void Mudar_modo_visual_novel ( Modo_visual_novel _novo_modo ){

            modo_visual_novel_atual = _novo_modo;

            return;

        }



        public override void Update( Control_flow _control_flow ){


                CONTROLLER__input.Pegar_instancia().manager_cursor.Change_action( Cursor_action.choice ); //Mudar_cursor( Cor_cursor.off );


                switch( modo_visual_novel_atual ){

                    //case Modo_visual_novel.choice: Update_choice(); break;
                    case Modo_visual_novel.normal: Update_normal(); break;
                    throw new Exception( "nao foi colocado o tipo de update viausl novel" );
                    
                }

        }


        public void Update_normal(){

 
                if( !screen_play.esta_ativo )
                    { return; }


                // --- VERIFICA SE ESTA BLOQUEADO
                if(  bloqueador.tipo_bloqueio_atual == Tipo_bloqueio_visual_novel.sem_bloqueio )
                    {
                        // --- VERIFICA SE PODE DESBLOQUEAR
                        bloqueador.Update();

                        // --- SE DESBLOQUEAR COMECA A PEGAR NO PROXIMO  
                        return;
                    
                    }


                Verificar_animacao();
                Verificacao_passar_cena();

                return;


        }

        public void Verificacao_passar_cena(){


            // --- PEGA DADOS 

            bool click_ir = ( Input.GetMouseButtonDown( 0 )  || Input.GetKeyDown( KeyCode.Space ) );
            bool click_voltar = Input.GetMouseButtonDown( 1 ) || Input.GetKeyDown( KeyCode.Escape );

            bool pressionar_ir = Input.GetKey( KeyCode.Space );
            bool pressionar_voltar = Input.GetKey( KeyCode.Escape );


            // --- VERIFICAR CLICK MANUAL
            if( click_ir ) 
                { 
                    leitor_visual_novel.Ler_cena( "update" ); 
                    return; 
                }

            if(   click_voltar   ) 
                {
                    leitor_visual_novel.Ler_cena_inversa( "update" );
                    return;
                }


            // --- VERIFICAR MODO AUTOMATICO
    
            if(  pressionar_ir  ||  pressionar_voltar )
                {

                    tempo_para_passar_cena_atutomatica_milisegundos +=  ( Time.deltaTime * 1_000 );

                    if( tempo_para_passar_cena_atutomatica_milisegundos < tempo_padrao_para_iniciar_atutomatico_milisegundos )
                        { return; } // --- AINDA TEM TEMPO

                    if( tempo_para_passar_cena_atutomatica_milisegundos > ( tempo_de_intervalo_entre_clicks_automaticos_milisegundos + tempo_padrao_para_iniciar_atutomatico_milisegundos ) )
                        {
                            // --- PODE DAR O CLICK AUTOMATICO

                                if( ( pressionar_ir ) && !!!( pressionar_voltar ) ) 
                                    { leitor_visual_novel.Ler_cena( "update automatico" ); }

                                if( !!!( pressionar_ir ) && ( pressionar_voltar ) ) 
                                    { leitor_visual_novel.Ler_cena_inversa( "update automatico" );}  

                                tempo_para_passar_cena_atutomatica_milisegundos = tempo_padrao_para_iniciar_atutomatico_milisegundos;
                                

                            

                        }

                    

                }  
                else
                {
                    // --- COLOCA O TEMPO PADRAO
                    tempo_para_passar_cena_atutomatica_milisegundos = tempo_padrao_para_iniciar_atutomatico_milisegundos;
                }

            return;


        }

                



        public void Verificar_animacao(){
            

                // if( controlador_tela_visual_novel.animacao_visual_novel != null ) 
                //     {

                //         controlador_tela_visual_novel.Update_animation();

                //         // return? 

                //         if(controlador_tela_visual_novel.animacao_visual_novel != null ) 
                //             { if( controlador_tela_visual_novel.animacao_visual_novel.ciclos_bloqueio > 0 ) { return; } } //wtf 

                //     }
                    
                // return;

        }       



        

    //     public Dados_figure_personagem Pegar_dados_figure (){
    //         return null;


    //     }




    // public Figure_personagem Construir_figure ( Dados_figure_personagem _dados ){
    //     return null;

         
    //     #if UNITY_EDITOR
    //     // vai ter que ter os paths
        



    //     #endif

    //     // vai ter que ter os ids 




    // }





}
