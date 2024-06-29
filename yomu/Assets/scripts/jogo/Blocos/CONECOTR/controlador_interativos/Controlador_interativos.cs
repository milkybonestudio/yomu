using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Controlador_interativos {



            public static Controlador_interativos instancia;
            public static Controlador_interativos Pegar_instancia(){ return instancia; }



            public BLOCO_conector bloco_conector;
            public Construtor_interativos construtor_interativos;


            // vai ser usado somente na build
            public byte[] dados_interativos_da_cidade;




            // testar

            public Interativo_personagem[] interativos_tipo_personagem;
            public Interativo_item[] interativos_tipo_item;
            public Interativo_tela[] interativos_tipo_tela;


            // --- CANVAS

            public GameObject interativos_container;

            public GameObject interativos_tipo_tela_container;
            public GameObject interativos_tipo_personagem_container;
            public GameObject interativos_tipo_item_container;


            public Gerenciador_imagens_interativos gerenciador_imagens_interativos;
            


            //public Interativo[] interativos_arr = new Interativo[ 0 ];
            // ** os gameObjects ficam agora nos interativos 
            //public GameObject[] interativos_game_objects_arr;


            // nao faz mais sentido
            public int interativo_atual_hover = -1;



            public static Controlador_interativos Construir(){ 


                  Controlador_interativos controlador = new Controlador_interativos(); 
                        

                        // --- CONTROLADORES

                        controlador.bloco_conector = BLOCO_conector.Pegar_instancia();
                        controlador.construtor_interativos = new Construtor_interativos( controlador );

                        // --- CRIAR CANVAS 

                        controlador.interativos_container = new GameObject( "Interativos_container" );
                        controlador.interativos_container.transform.SetParent( controlador.bloco_conector.container_conector.transform, false );


                        controlador.interativos_tipo_tela_container = new GameObject( "Interativos_tipo_tela_container" );
                        controlador.interativos_tipo_tela_container.transform.SetParent( controlador.interativos_container.transform, false );

                        controlador.interativos_tipo_personagem_container = new GameObject( "Interativos_tipo_personagem_container" );
                        controlador.interativos_tipo_personagem_container.transform.SetParent( controlador.interativos_container.transform, false );

                        controlador.interativos_tipo_item_container = new GameObject( "Interativos_tipo_item_container" );
                        controlador.interativos_tipo_item_container.transform.SetParent( controlador.interativos_container.transform, false );



                  instancia = controlador; 
                  return instancia;
                  
            }


            public void Esconder_interativos( bool _valor ){

                        interativos_container.SetActive( !_valor );
                        return;

            }


            public Interativo[] Criar_interativos( Ponto _p  ){  return null; } // excluirt


            unsafe public Interativo_tela[] Criar_interativos_tela( Posicao_local _posicao_local ){


                        Cidade cidade = Controlador_cidades.instancia.cidades[ _posicao_local.cidade_id ];
                        int[] interativos_default  = cidade.interativos_tela_por_posicao[ _posicao_local.regiao_id ][ _posicao_local.area_id ][ _posicao_local.ponto_id ];
                        int[] interativos_para_subtrair  = cidade.interativos_tela_para_subtrair_ids[ _posicao_local.regiao_id ][ _posicao_local.area_id ][ _posicao_local.ponto_id ];
                        int[] interativos_para_adicionar  = cidade.interativos_tela_para_adicionar_ids[ _posicao_local.regiao_id ][ _posicao_local.area_id ][ _posicao_local.ponto_id ];

                        int[] interativos_finais_ids = INT.Aplicar_subtrair_e_adicionar_array( interativos_default , interativos_para_subtrair, interativos_para_adicionar );

                        Interativo_tela[] interativos_retorno = new Interativo_tela[ interativos_finais_ids.Length ];

                        // pegar e pensar melhor depois
                        // ** vao ser todas iguais, porque os interativos vao ser do mesmo ponto


                        // acho que tem que ser long para fazer pointer + p0?
                        long pointer_container_da_area = 0;

                        for( int interativo_tela_slot = 0 ; interativo_tela_slot < interativos_finais_ids.Length ; interativo_tela_slot++ ){

                                    // int interativo_tela_id =  interativos_finais_ids[ interativo_tela_slot ];

                                    // long pointer_inicial_busca =( ( long )( &dados_interativos_da_cidade ) + pointer_container_da_area + ( interativo_tela_id << 2 ) ) ;

                                    // int ponto_1  =  *( int* ) ( pointer_inicial_busca  + 0l );
                                    // int ponto_2  =  *( int* ) ( pointer_inicial_busca  + 4l );



                                    // byte[] dados =   * ( byte* ) ( ( long ) &dados_interativos_da_cidade   + ( long ) ( ponto_1 << 2 ) );


                                    // // talvez?
                                    // // int ponto_1  =  *( int* ) (  ( long )( &dados_interativos_da_cidade ) + pointer_container_da_area + ( interativo_tela_id << 2 ) );
                                    // // int ponto_2  =  *( int* ) (  ( long )( &dados_interativos_da_cidade ) + pointer_container_da_area + ( interativo_tela_id << 2 ) );


                                    // byte[] dados_interativo_compactos  = new byte[ ( ponto_final_dados - ponto_inicial_dados ) ] ;

                                    // for( int index_dados = 0 ; index_dados < dados_interativo_compactos.Length ; index_dados++ ){

                                    //             dados_interativo_compactos[ index_dados ] = dados_interativos_da_cidade[ ( ponto_inicial_dados + index_dados ) ] ;

                                    // }

                                    // interativos_retorno[ interativo_tela_slot ] = Criar_interativo_tela( dados_interativo_compactos , interativo_tela_id ) ;

                                    continue;

                        }

                        return interativos_retorno;



            }


            public Interativo_tela Criar_interativo_tela(  byte[] _dados, int _interativo_tela_id ){

                        int periodo = Controlador_timer.instancia.periodo_atual_id;

                        Interativo_tela interativo_tela  = new Interativo_tela( _interativo_tela_id );

                        // interar sobre o container ... 


                        int sprite_id_imagem_1 = interativo_tela.sprites_imagem_1_ids_unicos_por_periodo[ periodo ];
                        int sprite_id_imagem_2 = interativo_tela.sprites_imagem_2_ids_unicos_por_periodo[ periodo ];

                        Sprite sprite_imagem_1 =  gerenciador_imagens_interativos.Pegar_sprite( sprite_id_imagem_1 );
                        Sprite sprite_imagem_2 =  gerenciador_imagens_interativos.Pegar_sprite( sprite_id_imagem_2 );

                        return interativo_tela;

                        


            }

            public Interativo_tela[] Criar_interativos_tela_DESENVOLVIMENTO( Posicao_local _posicao_local ){


                  Cidade cidade = Controlador_cidades.Pegar_instancia().Pegar_cidade_DESENVOLVIMENTO( "controlador_interativos", _posicao_local.cidade_id );

                  int[][][][] interativos_default_por_posicao  =  cidade.interativos_tela_por_posicao;
                  int[][][][] interativos_para_subtrair_por_posicao  =  cidade.interativos_tela_para_subtrair_ids;
                  int[][][][] interativos_para_adicionar_por_posicao  =  cidade.interativos_tela_para_adicionar_ids;

                  if( interativos_default_por_posicao == null )
                        { Console.LogError( "" ); throw new Exception(""); }


                  // --- VERIFICAR 
                  // *** talvez passar para uma class especial de teste 

                  // --- DEFAULT
                  
                  if( interativos_default_por_posicao == null )
                        { Console.LogError( "interativos_default_por_posicao estava null" ); throw new Exception(""); }
                  
                  if( interativos_default_por_posicao[ _posicao_local.regiao_id ]  == null )
                        { Console.LogError( "interativos_default_regiao estava null" ); throw new Exception(""); }


                  if( interativos_default_por_posicao[ _posicao_local.regiao_id ][ _posicao_local.area_id ] == null )
                        { Console.LogError( "interativos_default_area estava null" ); throw new Exception(""); }


                  if( interativos_default_por_posicao[ _posicao_local.regiao_id ][ _posicao_local.area_id ][ _posicao_local.ponto_id ] == null )
                        { Console.LogError( "interativos_default_ponto estava null" ); throw new Exception(""); }


                  // --- SUBTRAIR

                  if( interativos_para_subtrair_por_posicao == null )
                        { Console.LogError( "interativos_para_subtrair_por_posicao estava null" ); throw new Exception(""); }

                  if( interativos_para_subtrair_por_posicao[ _posicao_local.regiao_id ]  == null )
                        { Console.LogError( "interativos_para_subtrair_regiao estava null" ); throw new Exception(""); }


                  
                  if( interativos_para_subtrair_por_posicao[ _posicao_local.regiao_id ][ _posicao_local.area_id ] == null )
                        { Console.LogError( "interativos_para_subtrair_area estava null" ); throw new Exception(""); }


                  
                  if( interativos_para_subtrair_por_posicao[ _posicao_local.regiao_id ][ _posicao_local.area_id ][ _posicao_local.ponto_id ] == null )
                        { Console.LogError( "interativos_para_subtrair_ponto estava null" ); throw new Exception(""); }



                  // --- ADICIONAR


                  if( interativos_para_adicionar_por_posicao == null )
                        { Console.LogError( "interativos_para_adicionar_por_posicao estava null" ); throw new Exception(""); }


                  if( interativos_para_adicionar_por_posicao[ _posicao_local.regiao_id ]  == null )
                        { Console.LogError( "interativos_para_adicionar_regiao estava null" ); throw new Exception(""); }


                  
                  if( interativos_para_adicionar_por_posicao[ _posicao_local.regiao_id ][ _posicao_local.area_id ] == null )
                        { Console.LogError( "interativos_para_adicionar_area estava null" ); throw new Exception(""); }


                  
                  if( interativos_para_adicionar_por_posicao[ _posicao_local.regiao_id ][ _posicao_local.area_id ][ _posicao_local.ponto_id ] == null )
                        { Console.LogError( "interativos_para_adicionar_ponto estava null" ); throw new Exception(""); }



                  int[] interativos_default = interativos_default_por_posicao[ _posicao_local.regiao_id ][ _posicao_local.area_id ][ _posicao_local.ponto_id ];
                  int[] interativos_para_subtrair = interativos_para_subtrair_por_posicao[ _posicao_local.regiao_id ][ _posicao_local.area_id ][ _posicao_local.ponto_id ];
                  int[] interativos_para_adicionar = interativos_para_adicionar_por_posicao[ _posicao_local.regiao_id ][ _posicao_local.area_id ][ _posicao_local.ponto_id ];

                  int[] interativos_finais_ids = INT.Aplicar_subtrair_e_adicionar_array( interativos_default , interativos_para_subtrair, interativos_para_adicionar );

                  Interativo_tela[] interativos_tipo_tela_retorno = new Interativo_tela[ interativos_finais_ids.Length ] ;


                  for( int interativo_slot = 0 ; interativo_slot < interativos_finais_ids.Length ; interativo_slot++ ){


                              int interativo_id = interativos_finais_ids[ interativo_slot ];

                              Interativo_tela_DADOS_DESENVOLVIMENTO interativo_tela_dados_desenvolvimento = Leitor_interativos_tela_DESENVOLVIMENTO.Pegar( _posicao_local , interativo_id );
                              Interativo_tela interativo_tela = construtor_interativos.Criar_interativo_tela_DEVELOPMENT( interativo_tela_dados_desenvolvimento );
                              gerenciador_imagens_interativos.Colocar_sprites_interativo_tela_DESENVOLVIMENTO( interativo_tela_dados_desenvolvimento , interativo_tela );

                              interativos_tipo_tela_retorno[ interativo_slot ] = interativo_tela;

                              continue;

                  }


      	      return interativos_tipo_tela_retorno;

                  

            }


            public Interativo_tela Criar_interativo_tela_DEVELOPMENT( Posicao_local _posicao_local , int  _interativo_id ){


                        Interativo_tela_DADOS_DESENVOLVIMENTO interativo_tela_dados_desenvolvimento = Leitor_interativos_tela_DESENVOLVIMENTO.Pegar( _posicao_local , _interativo_id );
                        Interativo_tela interativo_tela = construtor_interativos.Criar_interativo_tela_DEVELOPMENT( interativo_tela_dados_desenvolvimento );

                        gerenciador_imagens_interativos.Colocar_sprites_interativo_tela_DESENVOLVIMENTO( interativo_tela_dados_desenvolvimento , interativo_tela );
                        
                        return interativo_tela;

            }


    


            public void Mudar_interativos ( Ponto _ponto ){

                        // depois tirar
                        interativo_atual_hover = -1;
                        
                        if( interativos_tipo_tela_container == null )
                              { throw new Exception( "interativos_tipo_tela_container estava null" ); }

                              


                        // int[] interativos_tipo_tela_ids = null; // ver 
                        // Interativo_tela[] novos_interativos_tipo_tela = construtor_interativos.Criar_interativos_tipo_tela( interativos_tipo_tela_ids );

                        // int[] interativos_tipo_item_ids = null; // ver 
                        // Interativo_item[] novos_interativos_tipo_item = construtor_interativos.Criar_interativos_tipo_item( interativos_tipo_item_ids );

                        // int[] interativos_tipo_personagem_ids = null; // ver 
                        // Interativo_personagem[] novos_interativos_tipo_personagem = construtor_interativos.Criar_interativos_tipo_personagem( interativos_tipo_personagem_ids );





                        // interativo_atual_hover = -1;
                        
                        // if(interativos_container != null){ Mono_instancia.DestroyImmediate(interativos_container);}


                        // interativos_container = new GameObject("Container");
                        // interativos_container.transform.SetParent(interativos_canvas.transform, false);

                        // Controlador_jogo_data jogo_data = Controlador_jogo_data.Pegar_instancia();
                        // Interativo_nome[] interativos_nomes = _ponto.interativos_nomes;
                        
                        // int numero_interativos = interativos_nomes.Length;
                        // string path =  "images/in_game/" +  _ponto.folder_path;
                        // int periodo =    ( Controlador_timer.Pegar_instancia().periodo_atual_id);

                        


                        // interativos_game_objects_arr = new GameObject[numero_interativos];
                        // interativos_arr = new Interativo[interativos_nomes.Length];



                        
                        // for( int i= 0; i < numero_interativos  ;i++){

                              
                        //             string name  = "Interativo_" + Convert.ToString( interativos_nomes[ i ] );

                        //             GameObject interativo_game_object = new GameObject(name);
                        //             interativos_game_objects_arr[i] = interativo_game_object;


                        //             Interativo interativo = null;
                        //             //Lista_interativos.Pegar_interativo( interativos_nomes[i] );
                        //             interativos_arr[i] = interativo;

                        //             // interativos_arr[i] = jogo_data.lista_interativos[  (int) interativos_nomes[i] ];



                        //             interativos_arr[i].image_slot =  interativo_game_object.AddComponent<Image>();

                        //             RectTransform rect = interativo_game_object.GetComponent<RectTransform>();
                        //             rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical ,  1080f );
                        //             rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal ,  1920f );

                        //             interativo_game_object.transform.SetParent( interativos_container.transform , false );


                        //             Carregar_imagens_interativo(  interativos_arr[ i ] ,  path , periodo);


                        // }

            }






    public void Ativar_interativo( int _interativo_index ){

            // ** pensar depois


            // Interativo interativo = interativos_arr[_interativo_index];
            // Interativo_nome interativo_nome = interativo.interativo_nome ;


            // Script_jogo_nome script_interativo_em_espera = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.Pegar_script_interativo_em_espera(  interativo_nome  );

            // if(  script_interativo_em_espera != Script_jogo_nome.nada  ){


            //             //Scripts_jogo.Ativar_script( script_interativo_em_espera );  
            //             return;

            // }


      
            // switch(interativo.tipo){

            //       case Tipo_interativo.movimento: Receber_movimento( interativo ); return;
            //       case Tipo_interativo.personagem: Receber_personagem( interativo ); return;
            //       case Tipo_interativo.item: Receber_item( interativo ); return;
            //       case Tipo_interativo.cenas: Receber_visual_novel( interativo ); return;
            //       case Tipo_interativo.utilidade: Receber_utilidade( interativo ); return;

            // }

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


      // *** FAZER INTERNO
      //     Script_jogo_nome script_espera = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.lista_scripts_por_pontos_bloqueados[ (int) ponto_destino ];
      //     Scripts_jogo.Ativar_script( script_espera );  
      //     Scripts_jogo.Ativar_script( _interativo.script_jogo_nome );  


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
            
            //Scripts_jogo.Ativar_script(  script_id );

            Req_transicao req = new Req_transicao(

                  _tipo_troca_bloco: Tipo_troca_bloco.START,
                  _novo_bloco: Bloco.visual_novel,
                  _tipo_transicao: Tipo_transicao.instantaneo

            );

            
            Dados_blocos.visual_novel_START = new Visual_novel_START(  _interativo.nome_screen_play );
            Dados_blocos.Colocar_nova_req( req );
      

            return;
     
   }


     


     



   public  void Ativar_hover_interativo( int _id ){

    
            // Interativo interativo = interativos_arr[_id];

            // interativo.image_slot.sprite = interativo.interativo_image_2;
            // interativo.image_slot.color = interativo.cor_image_2;


       
         

  }





   public void Tirar_hover_interativo( int _id ){

            
            // Interativo interativo = interativos_arr[_id];

            // interativo.image_slot.sprite = interativo.interativo_image_1;
            // interativo.image_slot.color = interativo.cor_image_1;






   }











}