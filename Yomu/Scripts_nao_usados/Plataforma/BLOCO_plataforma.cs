using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;







public enum conteudo {

    fluido = 1,
    solido = 2,
         
}

public enum mov_type {
         fixo = 1,
         movel = 2,

}


public enum Tipo_objeto{

      NENHUM = 0,  
      player = 1,
      mob = 2,
      terreno = 3,
      projetil = 4,


}


public enum Fase_resultado {

        sucesso,
        falha,
        sair,
        morte,

}


public enum Tipo_sair{

        sucesso,
        falha,

}

public enum Objetivo_fase {

        matar_todos_os_mobs,
        chegar_ponto_destino,
        passar_tempo,


}


public enum Tipo_lidar_falha {

        normal,
        perder_itens,
        loop,

}








public class BLOCO_plataforma{



        public static BLOCO_plataforma instancia; 
        public static BLOCO_plataforma Pegar_instancia(bool _forcar = false ){if(instancia == null|| _forcar ){ instancia = new BLOCO_plataforma(); instancia.Iniciar();} return instancia;}


        

        public Controlador_camera controlador_camera;

        public Controlador_player controlador_player;

        public Controlador_background_plataforma controlador_background_plataforma;

        public Itens itens;


        public GameObject world;

        public GameObject canvas_plataform;

        public GameObject canvas;

        public GameObject background;

        

        public GameObject meio_p_1;
        public GameObject meio_p_2;
        public GameObject meio_p_3;

//        public GameObject frente;


        public bool is_active = false;

        public Mob[] mobs_in_world = new Mob[0];

        public Terreno[] terrenos_in_world =new Terreno[0];

        public Projetil[] projeteis_arr = new Projetil[50];


        public Itens_localizador[] loot_atual = new Itens_localizador [10];
        public int[] loot_quantidade = new int[10];


        public  System.Diagnostics.Stopwatch timer;

        public Objetivo_fase objetivo_fase = Objetivo_fase.matar_todos_os_mobs;

        public float tempo_fase = -1f;

        public Action  Lidar_retorno;


        public Dados_blocos dados_blocos;

        public long ciclo_ = 0;



        
    public void Lidar_retorno_default(){

        

        Colocar_input_default();
        Colocar_UI_default();
        return;

    }

    public void Colocar_input_default(){


            Req_mudar_input novo_input = new Req_mudar_input() ;

            novo_input.ativar_movimentacao_mouse = false;

            novo_input.cor_cursor = Cor_cursor.invisivel;

            novo_input.tipo_teclado = Tipo_teclado.plataforma;

            this.dados_blocos.req_mudar_input = novo_input ;


    }

    public void Colocar_UI_default(){


            Req_mudar_UI novo_UI = new Req_mudar_UI() ;

            novo_UI.UI_partes = new bool[3];


            novo_UI.UI_partes[ ( int ) In_game_UI_partes.todas ] = false ;
            novo_UI.UI_partes[ ( int ) In_game_UI_partes.barra_superior ] = false ;
            novo_UI.UI_partes[ ( int ) In_game_UI_partes.pergaminho ] = false ;

            novo_UI.novo_tipo_UI = Tipo_UI.in_game;
            novo_UI.instantaneo = false;

            this.dados_blocos.req_mudar_UI = novo_UI ;


    }




        

        public void Iniciar(){

                Lidar_retorno = Lidar_retorno_default;
                
                controlador_player = Controlador_player.Pegar_instancia(true);
                controlador_camera = Controlador_camera.Pegar_instancia(true);

                dados_blocos = Dados_blocos.Pegar_instancia();

                Handler_colisoes.plataforma = this;

                itens = new Itens();

        
        }



        public void Iniciar_plataforma(){

                Colocar_input_default();
                Colocar_UI_default();



                Controlador_input.ativar_movimentacao_mouse = false;
                Controlador_cursor.Pegar_instancia().Mudar_cursor(Cor_cursor.invisivel);
                Controlador_input.tipo_teclado = Tipo_teclado.plataforma;


                Plataforma_START dados = dados_blocos.plataforma_START;

                timer = new  System.Diagnostics.Stopwatch();
            
                // Controlador_input.ativar_movimentacao_mouse = false;
                // Controlador_input.tipo_teclado = Tipo_teclado.plataforma;

                string[] personagens_to_load = dados.personagens_to_load;
                string fase_to_load = dados.fase_to_load;
                string objetivo_fase_str =  dados.objetivo_fase;
                
                tempo_fase = dados.tempo_fase;

                objetivo_fase =  ( Objetivo_fase )  Enum.Parse(    typeof( Objetivo_fase ) ,  objetivo_fase_str  ) ;



                canvas = GameObject.Find("Tela/Canvas/Plataforma");
                canvas_plataform = new GameObject("Plataforma_canvas");
                

                //   fazer algo tipo   Ajustar_posicao_canvas(); para a plataforma nao ficar atras da cenas

                canvas_plataform.transform.SetParent(canvas.transform, false);

                Image image = canvas_plataform.AddComponent<Image>();
                image.color = Color.black;

                RectTransform rect = canvas_plataform.GetComponent<RectTransform>();
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal , 1920f);
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical , 1080f);


                background = new GameObject("Background_plataforma");
                background.transform.SetParent(canvas_plataform.transform, false);


                world = new GameObject("world");
                world.transform.SetParent(canvas_plataform.transform, false);



                meio_p_1 =  new GameObject("Meio_p_1");
                meio_p_2 =  new GameObject("Meio_p_2");
                meio_p_3 =  new GameObject("Meio_p_3");


                meio_p_1.transform.SetParent(world.transform, false);
                meio_p_2.transform.SetParent(world.transform, false);
                meio_p_3.transform.SetParent(world.transform, false);

                 

                /*
                *  ex nome:  catedral/floresta_01
                */

              //  controlador.modo_tela_atual = Modo_tela.plataforma;

                // world = new GameObject("World");
                // world.transform.SetParent(   canvas_plataform.transform   ,  false   );


                controlador_player.Pegar_personagens_player( personagens_to_load);
                Construtor_fase_plataforma.Construir( fase_to_load ,  this  );



  
                controlador_player.Colocar_personagem_no_world();
                Handler_colisoes.Verificar_objetos_perto_player();

                

                controlador_background_plataforma.Colocar_valores();
                controlador_background_plataforma.Atualizar_background();

                timer.Start();


        }




        public void Zerar_dados(){
                
                Mono_instancia.DestroyImmediate(canvas);
                canvas = null;
                canvas_plataform = null;
                world = null;
                background = null;

                meio_p_1 = null;
                meio_p_2 = null;
                meio_p_3 = null;
                timer = null;

                mobs_in_world = null;
                terrenos_in_world =null;
                projeteis_arr = new Projetil[200];
                loot_atual = new Itens_localizador [100];
                loot_quantidade = new int[100];
                
                itens.lista = null;

                return;

        }


        public void Verificar_condicao_encerramento(){


                if( controlador_player.player_atual.stats.vida <= 0 ){

                        Encerrar_fase( Fase_resultado.sucesso );

                }

                if(objetivo_fase == Objetivo_fase.passar_tempo){


                        return;
                }

                if(objetivo_fase == Objetivo_fase.matar_todos_os_mobs){

                        int numero_mobs_possiveis = mobs_in_world.Length;

                        for(   int mob_id = 0;  mob_id < numero_mobs_possiveis  ;  mob_id++  ){

                                if(  !mobs_in_world[ mob_id ].stats.is_destruido ) return;

                        }

                        Encerrar_fase(Fase_resultado.sucesso);

                        return;
                }

                if(objetivo_fase == Objetivo_fase.chegar_ponto_destino){


                        return;
                }






        }

        

        public void Update() {


               // Verificar_condicao_encerramento();

                /// nao precisa mais 

                // if(data_output != null){ 
                        
                //         _data.plataforma_data_OUTPUT = data_output;
                //         return;
                        
                // }
                
                ciclo_++;
                
                if(Input.GetKeyDown(KeyCode.O)) {
                        foreach( Itens_localizador i in loot_atual ) {Debug.Log(i.ToString());};};
                if(Input.GetKeyDown(KeyCode.K)){Encerrar_fase( Fase_resultado.morte );}


                // nao precisa ser todo ciclo dps


                Handler_colisoes.Verificar_objetos_perto_player();


                controlador_camera.Seguir_player();

                

                //  chacar stats e passivos

                Update_stats();





                Fisica_plataforma.Update_fisica(this);



                // input


                Update_projeteis();

                controlador_player.player_atual.Update_teclado();


                Update_AIs();


                
                Fisica_plataforma.Update_velocidade(this);

                Handler_colisoes.Verificar_objetos();

                Fisica_plataforma.Update_movimento(this);
                

                Update_animacao();


        }







        public void Update_stats(){


                for(   int t = 0  ;  t <  terrenos_in_world.Length   ;  t++   ){

                        if(  terrenos_in_world[ t ].stats.is_destruido ) continue;

                        if(  terrenos_in_world[ t ].stats.is_inativo    ||   !terrenos_in_world[ t ].stats.tem_update ) continue;

                        terrenos_in_world[ t ].stats.Update();

                }


                for(   int m = 0  ;  m <  mobs_in_world.Length   ;  m++   ){

                        
                        if(mobs_in_world[ m ].stats.is_inativo) continue;

                        if(  mobs_in_world[ m ].stats.is_destruido   ||   !mobs_in_world[ m ].stats.tem_update ) continue;
                        
                        mobs_in_world[ m ].stats.Update();

                }


                for(   int  p = 0  ;  p <  projeteis_arr.Length   ;  p++   ){

                    if(   projeteis_arr[ p ]  == null  ) continue;

                    if(projeteis_arr[ p ].stats.tem_update) projeteis_arr[ p ].stats.Update();

                }

                controlador_player.player_atual.stats.Update();


        }




        public void Update_animacao(){



            for(   int t = 0  ;  t <  terrenos_in_world.Length   ;  t++   ){

                  terrenos_in_world[ t ].animations.Update();

            }


            for(   int m = 0  ;  m <  mobs_in_world.Length   ;  m++   ){

                if(!mobs_in_world[ m ].stats.is_destruido ) mobs_in_world[ m ].animations.Update();

            }


            for(   int  p = 0  ;  p <  projeteis_arr.Length   ;  p++   ){

            if(   projeteis_arr[ p ]  != null  )  projeteis_arr[ p ].animations.Update();

            }


            controlador_player.player_atual.animations.Update();



        }



        public void Update_projeteis(){

            
            for(int i =  0;  i < projeteis_arr.Length    ; i++){

                
                    if(projeteis_arr[i] != null ) projeteis_arr[i].efeito_tempo();


            }
            


        }


        public void Update_AIs(){


                for(int m = 0;  m < mobs_in_world.Length   ;m++){


                        if(mobs_in_world[m].stats.is_destruido) continue;
                        if(mobs_in_world[m].stats.is_inativo) continue;

                        mobs_in_world[m].Update_AI(mobs_in_world[m]);

                }


                for(int t = 0;  t < terrenos_in_world.Length   ;t++){


 
                        if(terrenos_in_world[t].Update_AI == null) continue;
                        if(terrenos_in_world[t].stats.is_destruido) continue;
                        if(terrenos_in_world[t].stats.is_inativo) continue;

                        terrenos_in_world[t].Update_AI(terrenos_in_world[t]);

                }


               


        }














        public void Remover_projetil(int _id){
            
            Mono_instancia.DestroyImmediate(   projeteis_arr[_id].projetil_game_object  );
            projeteis_arr[_id]  = null;

        }



        public void Adicionar_projetil(Projetil _projetil){


                for(int i = 0  ; i < projeteis_arr.Length ;i++  ){

                    if(projeteis_arr[i] == null) {

                        projeteis_arr[i] = _projetil;
                        _projetil.id = i;
                        return;
                    }

                }            


                int length = projeteis_arr.Length;
                Projetil[] arr = new Projetil[(length * 2)];

                for(int _i = 0  ; _i < projeteis_arr.Length ; _i++  ){

                        arr[_i]  =  projeteis_arr[_i];

                }

                arr[length] = _projetil;
                _projetil.id = length;
                projeteis_arr = arr;

        }




        public void Encerrar_fase(Fase_resultado _resultado){



                Plataforma_RETURN dados_RETURN = new Plataforma_RETURN();
                dados_RETURN.tipo_troca_bloco = Tipo_troca_bloco.OUT;
                dados_RETURN.motivo_encarramento = _resultado.ToString();

                if(  _resultado == Fase_resultado.morte ){

                        //  talvez personagens diferentes possam ter variaveis diferentes, por exemplo vale a pena ir com o char X porque o retorno é sempre 100%

                        dados_RETURN.itens_loot = null;
                        dados_RETURN.itens_quantidade = null;


                } else {


                        dados_RETURN.itens_loot = loot_atual;
                        dados_RETURN.itens_quantidade = loot_quantidade;
                        //   fazer xp depois, em caso de morte o xp é reduzido/zerado


                }




               
                

               int total_mobs_eliminados = 0;    

               for(int m = 0  ;  m  < mobs_in_world.Length   ;m++){
                      
                      if(mobs_in_world[m].stats.is_destruido) total_mobs_eliminados++;

               }

               dados_RETURN.total_mobs_eliminados = total_mobs_eliminados;

               timer.Stop();

               dados_RETURN.tempo_jogo =   (  Convert.ToSingle(timer.ElapsedMilliseconds) / 1000f);





               dados_blocos.req_transicao = new Req_transicao(

                        Tipo_troca_bloco.OUT
                        
               );
          
                
                return;
        
        }



        public void Destruir_objeto(int _id , Tipo_objeto _tipo){

        


                if(_tipo == Tipo_objeto.player){

                        controlador_player.player_atual.is_dead = true;
                        

                        //controlador_player.Mudar_personagem();
                        return;

                }

                if(_tipo == Tipo_objeto.mob){

                        mobs_in_world[_id].stats.is_destruido = true;

                        Mono_instancia.DestroyImmediate(mobs_in_world[_id].mob_game_object);

                        mobs_in_world[_id].drops.Pegar_drop();


                        return;

                }

                if(_tipo == Tipo_objeto.terreno){
                    
                        

                }

                
                return;
        }



}





