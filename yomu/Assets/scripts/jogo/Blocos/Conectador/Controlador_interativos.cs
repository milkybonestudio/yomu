using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
   os interativos vão ser unicos, porta_n vai ser diferente de porta_d 
   porque?
   pode ser que mude a imagem?
*/

public class Controlador_interativos {



            public static Controlador_interativos instancia;
            public static Controlador_interativos Pegar_instancia(){ return instancia; }


            public static Controlador_interativos Construir( BLOCO_conector _bloco ){ 


                  instancia = new Controlador_interativos(); 

                        
                        instancia.interativos_canvas = new GameObject( "Interativos" );
                        instancia.interativos_canvas.transform.SetParent( _bloco.container_conector.transform , false );            
                        instancia.bloco_conector = _bloco;

                  
                  return instancia;
                  
            }



            public GameObject interativos_container;
            public  GameObject interativos_canvas;
            public BLOCO_conector bloco_conector;

            public Interativo[] interativos_arr = new Interativo[ 0 ];

            public GameObject[] interativos_game_objects_arr;

            public int interativo_atual_hover = -1;


            public void Esconder_interativos( bool _valor ){

                        interativos_container.SetActive(!_valor);

                        return;

            }

    


            public void Criar_interativos( Ponto _ponto ){

                        interativo_atual_hover = -1;
                        
                        if(interativos_container != null){ Mono_instancia.DestroyImmediate(interativos_container);}


                        interativos_container = new GameObject("Container");
                        interativos_container.transform.SetParent(interativos_canvas.transform, false);

                        Controlador_jogo_data jogo_data = Controlador_jogo_data.Pegar_instancia();
                        Interativo_nome[] interativos_nomes = _ponto.interativos_nomes;
                        
                        int numero_interativos = interativos_nomes.Length;
                        string path =  "images/in_game/" +  _ponto.folder_path;
                        int periodo =    ( Controlador_timer.Pegar_instancia().periodo_atual_id);

                        


                        interativos_game_objects_arr = new GameObject[numero_interativos];
                        interativos_arr = new Interativo[interativos_nomes.Length];



                        
                        for( int i= 0; i < numero_interativos  ;i++){

                              
                                    string name  = "Interativo_" + Convert.ToString( interativos_nomes[ i ] );

                                    GameObject interativo_game_object = new GameObject(name);
                                    interativos_game_objects_arr[i] = interativo_game_object;


                                    Interativo interativo = Lista_interativos.Pegar_interativo( interativos_nomes[i] );
                                    interativos_arr[i] = interativo;

                                    // interativos_arr[i] = jogo_data.lista_interativos[  (int) interativos_nomes[i] ];





                                    interativos_arr[i].image_slot =  interativo_game_object.AddComponent<Image>();

                                    RectTransform rect = interativo_game_object.GetComponent<RectTransform>();
                                    rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical ,  1080f );
                                    rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal ,  1920f );

                                    interativo_game_object.transform.SetParent( interativos_container.transform , false );


                                    Carregar_imagens_interativo(  interativos_arr[ i ] ,  path , periodo);


                        }

            }





    public void Carregar_imagens_interativo(  Interativo _interativo  , string _path , int _periodo){

             
            string variante_periodo = "";

            if(_interativo.tipo_get  == Tipo_get_interativo.dia_E_noite){

                  if(_periodo < 3){ variante_periodo = "_d"; } else { variante_periodo = "_n";}

            } 
      
        

            if(_interativo.tipo_mouse_hover == Interativo_tipo_mouse_hover.nada_E_nada){


                  _interativo.interativo_image_1 = null;
                  _interativo.cor_image_1 = Color.clear;
                  
                  _interativo.interativo_image_2 = null;
                  _interativo.cor_image_2 = Color.clear;
                  
               
                  
            } else

            if(  _interativo.tipo_mouse_hover == Interativo_tipo_mouse_hover.nada_E_one){

                  _interativo.interativo_image_1 = null;
                  _interativo.cor_image_1 = Color.clear;

                  _interativo.interativo_image_2 = Resources.Load<Sprite>( _path + _interativo.nome +  variante_periodo);

                   
                   if(_interativo.interativo_image_2 == null){ throw new ArgumentException("nao foia chado imagem no path: " + _path + _interativo.nome +  variante_periodo + ". Modelo: nada_E_one");}
                  _interativo.cor_image_2 = Color.white;
                  

            } else 

            if(_interativo.tipo_mouse_hover == Interativo_tipo_mouse_hover.one_E_one){

                  _interativo.interativo_image_1 = Resources.Load<Sprite>( _path + _interativo.nome +  variante_periodo);

                  if(_interativo.interativo_image_1 == null){ throw new ArgumentException("nao foia chado imagem no path: " + _path + _interativo.nome +  variante_periodo + ". Modelo: one_E_one" );}
                  
                  _interativo.cor_image_1 = Color.white;
                  _interativo.interativo_image_2 = _interativo.interativo_image_1;
                  _interativo.cor_image_2 = Color.white;
                  

            } else 


            if(_interativo.tipo_mouse_hover == Interativo_tipo_mouse_hover.one_E_two){

                  _interativo.interativo_image_1 = Resources.Load<Sprite>( _path + _interativo.nome +  "_1" + variante_periodo);
                  _interativo.cor_image_1 = Color.white;
                  if(_interativo.interativo_image_1 == null){throw new ArgumentException("nao foia chado imagem no path: " + _path + _interativo.nome + "_1" +   variante_periodo + ". Modelo: one_E_two");}
                  
                  _interativo.interativo_image_2 = Resources.Load<Sprite>( _path + _interativo.nome +  "_2" + variante_periodo);
                  if(_interativo.interativo_image_2 == null){throw new ArgumentException("nao foia chado imagem no path: " + _path + _interativo.nome + "_2" +   variante_periodo +". Modelo: one_E_two");}
                  _interativo.cor_image_1 = Color.white;
                  

            } else 

            if(_interativo.tipo_mouse_hover  ==  Interativo_tipo_mouse_hover.one_80_E_one_100  ){

                  _interativo.interativo_image_1 = Resources.Load<Sprite>( _path  + _interativo.nome  + variante_periodo);
                  _interativo.cor_image_1 = new Color(0.8f,0.8f,0.8f,1f);
                  
                   if(_interativo.interativo_image_1 == null){ throw new ArgumentException("nao foi achado imagem no path: " + _path + _interativo.nome +  variante_periodo + ". Modelo: one_80_E_one_100");}

                  _interativo.interativo_image_2 = _interativo.interativo_image_1;
                  _interativo.cor_image_2 = Color.white;

                      

            }

            _interativo.image_slot.sprite = _interativo.interativo_image_1;
            _interativo.image_slot.color = _interativo.cor_image_1;


    }




    public void Trocar (int _id){


            Interativo interativo = interativos_arr[_id];

            interativo.image_slot.sprite = interativo.interativo_image_2;
            interativo.image_slot.color = interativo.cor_image_2;


            

    }


  






      public void Limpar_sprite_interativos(  int[] _interativos_para_limpar_sprite ){


            return;


            // for(int i = 0;i < _interativos_para_limpar_sprite.Length ;i++){
                    
            //         Controlador_jogo_data.Pegar_instancia().lista_interativos[ _interativos_para_limpar_sprite[i] ].interativo_image_1 = null;
            //         Controlador_jogo_data.Pegar_instancia().lista_interativos[ _interativos_para_limpar_sprite[i] ].interativo_image_2 = null;
            // }

            // return;

    }



     
    public void Carregar_sprite_interativo(Interativo _interativo , string _path){

    /*
      *
      *    aqui vai ser um pouco mais complicado
      *
    */ 


    if(_interativo.tipo_get  == Tipo_get_interativo.nao_altera){

    } else 

    if(_interativo.tipo_get  == Tipo_get_interativo.dia_E_noite){

    } 

      
      if(_interativo.tipo_mouse_hover == Interativo_tipo_mouse_hover.nada_E_nada) {
        
        _interativo.image_slot.color = Color.clear;
        return;
      }

      /*
      *   interar sobre os tipos de mouse_hover para pegar as imagens, path depende de Tipo_get_interativo
      */
      
      
    }








  
    public void Ativar_interativo(int _interativo_index){




            Interativo interativo = interativos_arr[_interativo_index];
            Interativo_nome interativo_nome = interativo.interativo_nome ;


            Script_jogo_nome script_interativo_em_espera = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.Pegar_script_interativo_em_espera(  interativo_nome  );

            if(  script_interativo_em_espera != Script_jogo_nome.nada  ){

                        Scripts_jogo.Ativar_script( script_interativo_em_espera );  
                        return;

            }


      
            switch(interativo.tipo){

                  case Tipo_interativo.movimento: Receber_movimento( interativo ); return;
                  case Tipo_interativo.personagem: Receber_personagem( interativo ); return;
                  case Tipo_interativo.item: Receber_item( interativo ); return;
                  case Tipo_interativo.cenas: Receber_visual_novel( interativo ); return;
                  case Tipo_interativo.utilidade: Receber_utilidade( interativo ); return;

            }

    }

    public void Receber_utilidade(Interativo _interativo){

          Interativo_nome interativo_nome = _interativo.interativo_nome;
         
          Controlador_utilidades.Pegar_instancia().Iniciar_utilidade( interativo_nome );

          return;

    }


    public void Receber_movimento(Interativo _interativo){


    
          Ponto_nome ponto_destino  =  _interativo.ponto_destino;
          // tempo vai ser pego dentro das verificacoes'
          

        


         //mark 
         // pode ser util depois, mas Controlador_verificacoes é um nome horrivel
         // if(  ponto_destino == Ponto_nome.pegar_por_script ) ponto_destino = Controlador_verificacoes.Pegar_instancia().Pegar_ponto_variante(_interativo.interativo_nome);`





          //bool ponto_is_bloqueado =  Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.lista_pontos_bloqueados[ponto_destino];

          Script_jogo_nome script_espera = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.lista_scripts_por_pontos_bloqueados[ (int) ponto_destino ];

          Scripts_jogo.Ativar_script( script_espera );  
          Scripts_jogo.Ativar_script( _interativo.script_jogo_nome );  


          //Controlador_movimento.Pegar_instancia().Mover_player(ponto_destino);
              
          
          return;
    
    }










   public void Receber_personagem( Interativo _interativo ){

      
                  // Personagem_nome nome = _interativo.personagem;
                  // string conversa_nome = _interativo.conversa_nome;

                  // string personagem_nome = nome.ToString();
                  

                  // Controlador_conversas.Pegar_instancia().Iniciar_conversas( personagem_nome  , conversa_nome  );

                  // return;

     
   }

   
   public void Receber_item( Interativo _interativo ){

     ///   fazercom req
    // if(_interativo.script != 0 ) controlador.controlador_scripts.Ativar_script(_interativo.script);

     return;


   }

   

   public void Receber_visual_novel ( Interativo _interativo ){


            Script_jogo_nome script_id = _interativo.script_jogo_nome;
            
            Scripts_jogo.Ativar_script(  script_id );

            Req_transicao req = new Req_transicao(

                  _tipo_troca_bloco: Tipo_troca_bloco.START,
                  _novo_bloco: Bloco.visual_novel,
                  _tipo_transicao: Tipo_transicao.instantaneo

            );

            
            Dados_blocos.visual_novel_START = new Visual_novel_START(   _interativo.nome_screen_play   );
            Dados_blocos.Colocar_nova_req(req);
      

            return;
     
   }


     


     



   public  void Ativar_hover_interativo( int _id ){

    
            Interativo interativo = interativos_arr[_id];

            interativo.image_slot.sprite = interativo.interativo_image_2;
            interativo.image_slot.color = interativo.cor_image_2;


       
         

  }





   public void Tirar_hover_interativo( int _id ){

            
            Interativo interativo = interativos_arr[_id];

            interativo.image_slot.sprite = interativo.interativo_image_1;
            interativo.image_slot.color = interativo.cor_image_1;






   }











}