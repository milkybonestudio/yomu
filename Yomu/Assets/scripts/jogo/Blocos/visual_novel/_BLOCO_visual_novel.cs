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

      
        public static BLOCO_visual_novel instancia;
        public static BLOCO_visual_novel Pegar_instancia(){ return instancia; }
        public static BLOCO_visual_novel Construir(){ instancia = new BLOCO_visual_novel(); return instancia;}



    public void Iniciar(){



            /*

                Leitor_visual_novel.Construir();
                Controlador_personagens_visual_novel.Construir();
                Controlador_tela_visual_novel.Construir();

                ** dados_blocos vai ser criado no jogo

                ** porque mudar_ui é uma action? 
                poderia ser uma function normal que pegar um byte[] com dados sobre o estado da UI 
                qual seria a ui? => pergaminho + opcoes [ nao tem porque mudar ] 
                     tipo pergaminho             
                [        1 byte                                   ]


                ** faz sentido ter controle sobre como a ui vai mudar 

                        => na barra superior tem coisas opcionais 
                        => na barra superior os icones podem mudar 


                fn(){


                    voltar vs: 

                        mudar_ui() => 
                        mudar_input() 


                }


                a pergunta é: onde que o update da ui vai ficar? 
                acho que fazria sentido ela ficar em cada bloco

                blocos: 

                - vs            
                - mmovimento   =>  barra superior 
                - conversa     =>  barra superior ( talvez diferente? )
                - cartas       =>  ui cartas 
                - minigames    =>  proprio
                - lojas        =>  barra superior ( nao pega ) + ui propria 


            */

    
            leitor_visual_novel  = Leitor_visual_novel.Pegar_instancia();
            controlador_personagens_visual_novel = Controlador_personagens_visual_novel.Pegar_instancia();
            controlador_tela_visual_novel = Controlador_tela_visual_novel.Pegar_instancia();


            controlador_UI_visual_novel = new Controlador_UI_visual_novel();

            
            dados_blocos = Dados_blocos.Pegar_instancia();
            
            Mudar_UI = Visual_novel_mudar_UI.Default ; 
            Mudar_input = Visual_novel_mudar_input.Default ; 

            Lidar_retorno = Visual_novel_lidar_retorno.Default;

    }



    public void Zerar_dados(){


            screen_play = null;
            controlador_personagens_visual_novel.Resetar_variaveis();
            controlador_tela_visual_novel.Resetar_variaveis();


    }




    public Action  Lidar_retorno ;
    public Action  Mudar_UI ;
    public Action  Mudar_input ;

    public Controlador_UI_visual_novel controlador_UI_visual_novel;




    public Leitor_visual_novel leitor_visual_novel;
    public Controlador_tela_visual_novel controlador_tela_visual_novel;
    public Controlador_personagens_visual_novel controlador_personagens_visual_novel;
    

    public Dados_blocos dados_blocos;

    public Action fn_click_espera = null;

    public Screen_play screen_play = null;
    
    //public Visual_novel_dados visual_novel_dados;
 
    public Modo_visual_novel modo_visual_novel_atual = Modo_visual_novel.normal;

    public Bloqueador bloqueador = null;

        
    public  int  space_skip_scene  = 1;
    public  bool space_skip_scene_trava  = false;



      
    public void Mudar_modo_visual_novel ( Modo_visual_novel _novo_modo ){

      modo_visual_novel_atual = _novo_modo;

      return;

    }







    // talvez mudar o nome para Iniciar_bloco_visual_novel ou so Iniciar_bloco
    public void Iniciar_visual_novel() {

            bloqueador = new Bloqueador();

            Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off ) ;

            Mudar_UI();
            Mudar_input();

            controlador_tela_visual_novel.Criar_tela();
    
            Visual_novel_START data_start = dados_blocos.visual_novel_START;

            Iniciar_screen_play( data_start );

            return;

    }




/*

        sempre que for editor tem que pegar os dados na hora 


        byte[][][] pngs_array_byte_array

        figure_x => 1 

*/



    public Dados_figure_personagem[] dados;




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




    public void Iniciar_screen_play ( Visual_novel_START _data_visual_novel_start ){


            string  path_background_inicial =   _data_visual_novel_start.path_background_inicial;

            // porque ele esta mudando aqui? 
            if( path_background_inicial == null ){

                
                    path_background_inicial = Player_estado_atual.Pegar_instancia().Pegar_path_imagem_background();
                    controlador_tela_visual_novel.Mudar_background( _path: path_background_inicial , _tem_transicao:false , _foco: 0 , _id_cor: ( int ) Nome_cor.white ); 

            }


            Nome_screen_play nome = _data_visual_novel_start.nome_screen_play;

            Screen_play novo_screen_play = null;

            if( Application.isEditor ){ novo_screen_play = Interpretador.Construir_screen_play ( nome );} else { novo_screen_play= Interpretador.Pegar_screen_play ( nome );}


            #if UNITY_EDITOR

            novo_screen_play = Interpretador.Construir_screen_play ( nome );

            #else 

            novo_screen_play= Interpretador.Pegar_screen_play ( nome );

            #endif




            novo_screen_play.path_background_atual = path_background_inicial;

            novo_screen_play.esta_ativo = true;

            this.screen_play = novo_screen_play;
            

            leitor_visual_novel.Colocar_dados( screen_play );
            
            return;

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



    public void Iniciar_plataforma(  string[] _args ){



    
        // string args = Regex.Replace(_args[0], @"(\r\n)+", "\r\n");

        // string[] chaves_e_fechaduras = args.Split("\r\n");

        // string[] personagens_to_load = chaves_e_fechaduras[1].Split(":")[1].Split(",");

        // for(int personagem = 0;  personagem < personagens_to_load.Length  ; personagem++){

        //     personagens_to_load[personagem] = personagens_to_load[personagem].Trim();

        // }

    
        // string fase_to_load = chaves_e_fechaduras[2].Split(":")[1].Trim();
        // string objetivo_fase = chaves_e_fechaduras[3].Split(":")[1].Trim();
        
        // string tempo_fase_str = chaves_e_fechaduras[4].Split(":")[1].Trim();
    
        // float tempo_fase = -1f;

        

        // if(tempo_fase_str != "p"){

        //     tempo_fase = Convert.ToSingle( tempo_fase_str );
        
        // } 


        // Plataforma_START plataforma_data_START = new Plataforma_START();

        // plataforma_data_START.fase_to_load = fase_to_load;
        // plataforma_data_START.personagens_to_load = personagens_to_load;
        // plataforma_data_START.objetivo_fase = objetivo_fase;




    }





  

    //   public void Ativar_cenas( Screen_play _cenas , bool _is_jump = false){


    //         if(!_is_jump) { 

    //                 string background_path = Player_estado_atual.Pegar_instancia().Pegar_path_imagem_background();
    //                 controlador_tela_visual_novel.Mudar_background( background_path , false , 0 , 0); 
                        
    //         } else {

    //                 fn_click_espera = () => {

                            
    //                         fn_click_espera = null;

    //                 };

    //         }
    //             return;

    // }





    




    public void _Voltar_cena(string _origem = ""){

        // if(visual_novel_dados.bloqueio_transicao) return;

         
        // visual_novel_dados.auto_ativado = false;

        // screen_play.Diminuir_contador_cena();

        //   // if tipo == choice diminuir de novo

        // visual_novel_dados.auto_ativado = false;

    }





 


}