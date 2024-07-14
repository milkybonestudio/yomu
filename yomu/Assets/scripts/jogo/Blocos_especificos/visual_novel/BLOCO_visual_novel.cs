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


// fn ( Tipo_mudanca, Bloco ) {



// }


public enum Tipo_mudanca {

    sair, 
    entrar

}



public class BLOCO_visual_novel {

       // ** UPDATE DE LOGICA :
       // um plot sempre tem que ser encerrado, VN nao pode iniciar outra VN

      
        public static BLOCO_visual_novel instancia;
        public static BLOCO_visual_novel Pegar_instancia(){ return instancia; }

        public Action  Lidar_retorno ;
        public Action  Mudar_UI ;
        public Action  Mudar_input ;

        public Controlador_UI_visual_novel controlador_UI_visual_novel;


        public GameObject container_visual_novel;




        public Leitor_visual_novel leitor_visual_novel;
        public Controlador_tela_visual_novel controlador_tela_visual_novel;
        public Controlador_personagens_visual_novel controlador_personagens_visual_novel;


        public Modo_visual_novel modo_visual_novel_atual = Modo_visual_novel.normal;

        public Screen_play screen_play = null;


        public Bloqueador bloqueador = null;

        public Dados_figure_personagem[] dados;

            
        public  int  space_skip_scene  = 1;
        public  bool space_skip_scene_trava  = false;

        public static  BLOCO_visual_novel Iniciar_bloco_visual_novel(){
            
            if( instancia != null )
                { throw new Exception( "tenteou criar BLOCO_VN mas a instancia nao estava null" ); }

            instancia = new BLOCO_visual_novel(); 
            instancia.Iniciar();
            return instancia;

        }

        public void Iniciar(){

                    
                // --- FERRAMENTAS

                leitor_visual_novel  = Leitor_visual_novel.Construir();
                controlador_personagens_visual_novel = Controlador_personagens_visual_novel.Construir();
                controlador_tela_visual_novel = Controlador_tela_visual_novel.Construir();
                controlador_UI_visual_novel = new Controlador_UI_visual_novel();
                bloqueador = new Bloqueador();

                
                // --- ACTIONS 

                Mudar_UI = Visual_novel_mudar_UI.Default ; 
                Mudar_input = Visual_novel_mudar_input.Default ; 
                Lidar_retorno = Visual_novel_lidar_retorno.Default;

                // *** isso deveria vir da req também 
                Mudar_UI();
                Mudar_input();




                // --- INICIAR SCREEN PLAY

                Visual_novel_START data_visual_novel_start = Dados_blocos.visual_novel_START;

                if( data_visual_novel_start == null)
                    { throw new Exception( "nao veio os dados para iniciar visual novel" ); }

                string  path_background_inicial =   data_visual_novel_start.path_background_inicial;
                Nome_screen_play nome = data_visual_novel_start.nome_screen_play;

        
                // --- TELA
                
                controlador_tela_visual_novel.Criar_tela();
                controlador_tela_visual_novel.Mudar_background( _path: path_background_inicial , _tem_transicao:false , _foco: 0 , _id_cor: ( int ) Nome_cor.white ); 

                
                screen_play = Interpretador.Pegar_screen_play ( nome );

                screen_play.path_background_atual = path_background_inicial;
                screen_play.esta_ativo = true;

                leitor_visual_novel.Ativar( screen_play );
                
                return;



        }






    public static void Finalizar(){


            instancia = null;

            Controlador_personagens_visual_novel.instancia = null;
            Controlador_tela_visual_novel.instancia = null;
            Leitor_visual_novel.instancia = null;
            
            return;


    }




      
    public void Mudar_modo_visual_novel ( Modo_visual_novel _novo_modo ){

      modo_visual_novel_atual = _novo_modo;

      return;

    }




    

    public Dados_figure_personagem Pegar_dados_figure (){
        return null;


    }




    public Figure_personagem Construir_figure ( Dados_figure_personagem _dados ){
        return null;

         
        #if UNITY_EDITOR
        // vai ter que ter os paths
        



        #endif

        // vai ter que ter os ids 




    }



        public void Update(){

                
                Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );

                    
                    if(  bloqueador.Esta_bloqueado() ){ 


                            bloqueador.Update(); 
                            if( bloqueador.Esta_bloqueado() ) { return; }

                            if( bloqueador.tem_click ){

                                    bloqueador.tem_click = false;
                                    leitor_visual_novel.Ler_cena( "desbloqueio" );

                            }


                            return;

                    }

                    if(controlador_tela_visual_novel.animacao_visual_novel != null ) {

                            controlador_tela_visual_novel.Update_animation();

                            // return? 

                            if(controlador_tela_visual_novel.animacao_visual_novel != null ) {

                                    if(controlador_tela_visual_novel.animacao_visual_novel.ciclos_bloqueio>0) return;//wtf

                            }

                    }


                    if(  modo_visual_novel_atual == Modo_visual_novel.choice ) { return; }

                    if( !screen_play.esta_ativo ) { return; }

                    

                    if(   Controlador_input.Get_down(Key_code.space) ||  Controlador_input.Get_down(Key_code.mouse_left) ) {

                        leitor_visual_novel.Ler_cena( "update" ); // Passar_cena();
                        return;
                    
                    }

                    if(    Input.GetKeyDown(KeyCode.Escape)   ||  Input.GetMouseButtonDown(1) ) {

                        leitor_visual_novel.Ler_cena_inversa( "update" );
                        return;

                    }

                
                    if(  Controlador_input.Get(Key_code.space)  ||  Input.GetKey(KeyCode.Escape) ){

                        space_skip_scene++;

                        if(space_skip_scene>0){
                    
                            space_skip_scene = space_skip_scene % 7 ; // 5
                        
                                if(space_skip_scene == 1){  
                                
                                    if(Controlador_input.Get(Key_code.space) && !Input.GetKey(KeyCode.Escape)) {
                                        leitor_visual_novel.Ler_cena( "update" );
                                        return;
                                    }

                                    if(!Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Escape)) {
                                        leitor_visual_novel.Ler_cena_inversa( "update" );
                                        
                                    }
                                
                                    return; 
                                
                                }
                                
                        } 

                    }  else {

                        space_skip_scene = -80;
                    
                    }



        }





}