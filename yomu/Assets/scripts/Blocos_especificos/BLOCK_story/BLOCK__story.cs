using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;


/*

        Controlador_UI => geral 
        mas iniciar vai ser pelo bloco 

        Controlador_UI {

                // so vai ser chamado uma vez 
                // vai passar todos os possiveis Actions que essa parte de UI pode ter 

                                        //  ja vai estar em player
                public Colocar_dados(    Bloco  ,  byte[] , Action[]  ){

                }

        }

*/



/*


    Figures: 


    Para construir uma figure eu preciso dos dados_figure. Esses dados vão ser adiquiridos de jeitos diferentes dependendo se for o modo producao ou se for na build 

        build => vai ter um dic com os dados de cada figure_id, esse dic vai importar 2 arquivos e deixar na memoria se forem pequenos os Figure_localizador e Figure_dados;
        editor(teste) => os dados vao ser pegos diretamente nos Personagem_figure_dados

    Oque eu preciso mudar: 

        1 opcao: 
            - set vai ter 2 propriedades: figures_ids e figures_nomes. 
                    => figures ids => so estao presentes na build
                    => figures_nomes => so vao estar presentes no editor(teste) 
            



*/



/*


    continua sendo instanciado no controlador
    precisa ser instanciado somente no jogo;


*/




public enum Tipo_mudanca {

    sair, 
    entrar

}





public class BLOCO_story : INTERFACE__bloco {

       // ** UPDATE DE LOGICA :
       // um plot sempre tem que ser encerrado, VN nao pode iniciar outra VN

      
        // --- INSTANCIA

        public static BLOCO_story instancia;
        public static BLOCO_story Pegar_instancia(){ return instancia; }


        // --- INTERFACE

        // public void Pegar_bloco(){ return Bloco.visual_novel; }
        // public void Update(){}
        // public void Finalizar(){}
        // public void Iniciar(){}
        // public void Destruir(){}

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



        public void Update(){


                Controlador_cursor.Pegar_instancia().Change_action( Cursor_action.choice ); //Mudar_cursor( Cor_cursor.off );


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
