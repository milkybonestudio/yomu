
using UnityEngine;
using UnityEngine.UI;
using System;



public class Configuration_container : MonoBehaviour {


        [ NonSerialized ] public bool volume_is_pressionado = false;

        [ NonSerialized ] public float x_position = 0f;
        [ NonSerialized ] public float y_position = 0f;
        
        [ NonSerialized ] public GameObject game_object;
        [ NonSerialized ] public RectTransform configuration_container_rect; 

        [ NonSerialized ] public Transform volume_transform;
        [ NonSerialized ] public RectTransform volume_base_rect; 
        [ NonSerialized ] public RectTransform volume_botao_rect; 
        [ NonSerialized ] public RectTransform volume_cor_ativa_rect; 
        [ NonSerialized ] public RectTransform volume_cor_inativa_rect; 

        [ NonSerialized ] public Transform  texto_transform;
        [ NonSerialized ] public RectTransform text_fade_rect; 
        [ NonSerialized ] public RectTransform text_instant_rect; 
        [ NonSerialized ] public RectTransform text_typewrite_rect; 
        [ NonSerialized ] public RectTransform text_active_rect; 

        [ NonSerialized ] public Transform  full_screen_transform;
        [ NonSerialized ] public RectTransform full_screen; 
        [ NonSerialized ] public RectTransform full_screen_ativa; 
        [ NonSerialized ] public Image tela_cheia_YES_image;




        public void Awake () {

            /*

                    As imagens estão no folder que não vao estar presentes na build.

                    Ainda tem que fazer um modelo de carregar no login 
                    As iamgens do login podem ser carregadas no login, mas as imagens do menu são muito grandes. vai levar uns 3/5 frames 

                    Mas menu vai preciasar Liberar esses assets quando entrar em algum jogo;
                    
            */


            game_object = gameObject;

            configuration_container_rect = game_object.GetComponent<RectTransform>();

            // volume
            volume_transform = game_object.transform.GetChild( 0 );                
            
            volume_cor_inativa_rect = volume_transform.GetChild( 0 ).gameObject.GetComponent<RectTransform>();
            volume_cor_ativa_rect   = volume_transform.GetChild( 1 ).gameObject.GetComponent<RectTransform>();
            volume_base_rect        = volume_transform.GetChild( 2 ).gameObject.GetComponent<RectTransform>();
            volume_botao_rect        = volume_transform.GetChild( 3 ).gameObject.GetComponent<RectTransform>();

                    
            //  texto

            texto_transform = game_object.transform.GetChild( 1 );

            text_fade_rect      = texto_transform.GetChild( 0 ).gameObject.GetComponent<RectTransform>();
            text_instant_rect   = texto_transform.GetChild( 1 ).gameObject.GetComponent<RectTransform>();
            text_typewrite_rect = texto_transform.GetChild( 2 ).gameObject.GetComponent<RectTransform>();
            text_active_rect    = texto_transform.GetChild( 3 ).gameObject.GetComponent<RectTransform>();


            // tela cheia

            full_screen = game_object.transform.GetChild( 2 ).gameObject.GetComponent<RectTransform>();

            full_screen_ativa    = full_screen.GetChild( 0 ).gameObject.GetComponent<RectTransform>();
            tela_cheia_YES_image = full_screen.GetChild( 0 ).gameObject.GetComponent<Image>();

            // nao muda a logica, somente a imagem
            Trocar_volume_ativo(   (float)  CONTROLLER__configurations.Pegar_instancia().volume   );

        
        }


        public void _Update(){

                if( Verificar_volume() ) 
                        { return; }

                if( Verificar_texto() ) 
                        { return; }
                        
                if( Verificar_tela_cheia() ) 
                        { return; }

                CONTROLLER__input.Pegar_instancia().manager_cursor.Change_action( Cursor_action.choice ); //Mudar_cursor( Cor_cursor.off );
                
                return;

        }


        public void Trocar_modo_texto( Type_writing_construction _tipo ){

                CONTROLLER__configurations.Pegar_instancia().Mudar_tipo_texto( _tipo );

                Vector3 nova_posicao = new Vector3();
                switch( _tipo ){

                        case Type_writing_construction.fade: nova_posicao = new Vector3( -200f , 0f,0f ); break;
                        case Type_writing_construction.instant: nova_posicao = new Vector3( 0f , 0f,0f ); break; 
                        case Type_writing_construction.typewrite: nova_posicao = new Vector3( 200f , 0f,0f ); break;

                }

                if( nova_posicao != null ) 
                        { text_active_rect.localPosition = nova_posicao; }

                return;

        }


        public void  Trocar_volume_ativo(  float _novo_volume ){

                float novo_width = ( volume_base_rect.rect.width * _novo_volume / 100f );

                float p0 = -(volume_base_rect.rect.width/2);
                float p1  = p0 + novo_width;
                float pM = ( p1 + p0 ) / 2;

                volume_cor_ativa_rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal  ,  novo_width  );
                volume_cor_ativa_rect.localPosition = new Vector3(  pM  ,   0f  ,  0f );

                return;

        }


        public void Trocar_full_screen(){

                Screen.fullScreen = !Screen.fullScreen;
                
                if( CONTROLLER__configurations.Pegar_instancia().full_screen){

                        tela_cheia_YES_image.color = new Color( 1f , 1f,1f , 0f );
                        CONTROLLER__configurations.Pegar_instancia().full_screen = false;

                        return;

                } 
                    
                tela_cheia_YES_image.color = new Color( 1f , 1f,1f , 1f );
                CONTROLLER__configurations.Pegar_instancia().full_screen = true;
                
                return;

        }


        public bool Verificar_volume(){

                float mouse_x = CONTROLLER__data.Pegar_instancia().posicao_mouse[0]  -    configuration_container_rect.localPosition[0]  -  volume_transform.localPosition[0] - 960f;
                float mouse_y = CONTROLLER__data.Pegar_instancia().posicao_mouse[1]  -  configuration_container_rect.localPosition[1]  -  volume_transform.localPosition[1] - 540f ;                

                float x_min  = volume_botao_rect.localPosition[0] - (volume_botao_rect.rect.width / 2) ;
                float x_max  = volume_botao_rect.localPosition[0] + (volume_botao_rect.rect.width / 2) ;
                
                float y_min = volume_botao_rect.localPosition[1] - (volume_botao_rect.rect.height / 2) ;
                float y_max = volume_botao_rect.localPosition[1] + (volume_botao_rect.rect.height / 2) ;

                                
                if(  volume_is_pressionado && Input.GetMouseButton( 0 )  ){

                        float nova_posicao =  mouse_x;
                        if( nova_posicao >  volume_base_rect.rect.width/2 )  { nova_posicao = volume_base_rect.rect.width/2 ;}
                        if( nova_posicao < -volume_base_rect.rect.width/2 )  { nova_posicao = -volume_base_rect.rect.width/2 ;}

                        volume_botao_rect.localPosition = new Vector3(  nova_posicao   ,0f,0f);
                            
                        int novo_volume =    Convert.ToInt32(  100f *  ((nova_posicao   +   volume_base_rect.rect.width/ 2) / volume_base_rect.rect.width )  ) ;
                        Trocar_volume_ativo( (float) novo_volume);
                        CONTROLLER__configurations.Pegar_instancia().Mudar_volume(novo_volume);

                        return true;

                } 

                volume_is_pressionado = false; 
                

                if( Rectangle.Check_point_inside(  mouse_x + x_position,  mouse_y + y_position  , x_min, x_max, y_min , y_max  )  ){

                        if(  Input.GetMouseButtonDown( 0 )  ){ volume_is_pressionado = true; }
                        return true;

                }

                return false;

        }


        public bool Verificar_texto(){




                //  tipo texto         
                float mouse_x = CONTROLLER__data.Pegar_instancia().posicao_mouse[0]  -    configuration_container_rect.localPosition[0]  -  texto_transform.localPosition[0] - 960f;
                float mouse_y = CONTROLLER__data.Pegar_instancia().posicao_mouse[1]  -  configuration_container_rect.localPosition[1]  -  texto_transform.localPosition[1] - 540f ;


                // fade 

                float x_min  = text_fade_rect.localPosition[0] - (text_fade_rect.rect.width / 2) ;
                float x_max  = text_fade_rect.localPosition[0] + (text_fade_rect.rect.width / 2) ;
                
                float y_min = text_fade_rect.localPosition[1] - (text_fade_rect.rect.height / 2) ;
                float y_max = text_fade_rect.localPosition[1] + (text_fade_rect.rect.height / 2) ;



                if( Rectangle.Check_point_inside(  mouse_x + x_position,  mouse_y + y_position  , x_min, x_max, y_min , y_max   )   ){

                        if(   Input.GetMouseButtonDown( 0 ) )
                            { Trocar_modo_texto( Type_writing_construction.fade ); }

                        return true;

                }


                //  instant 

                x_min  = text_instant_rect.localPosition[0] - (text_instant_rect.rect.width / 2) ;
                x_max  = text_instant_rect.localPosition[0] + (text_instant_rect.rect.width / 2) ;
                
                y_min = text_instant_rect.localPosition[1] - (text_instant_rect.rect.height / 2) ;
                y_max = text_instant_rect.localPosition[1] + (text_instant_rect.rect.height / 2) ;


                if( Rectangle.Check_point_inside(  mouse_x + x_position,  mouse_y + y_position  , x_min, x_max, y_min , y_max   )   ){

                        if( Input.GetMouseButtonDown( 0 ) ){ Trocar_modo_texto( Type_writing_construction.instant );}

                        return true;
                }


                // typewrite
                x_min  = text_typewrite_rect.localPosition[0] - (text_typewrite_rect.rect.width / 2) ;
                x_max  = text_typewrite_rect.localPosition[0] + (text_typewrite_rect.rect.width / 2) ;
                
                y_min = text_typewrite_rect.localPosition[1] - (text_typewrite_rect.rect.height / 2) ;
                y_max = text_typewrite_rect.localPosition[1] + (text_typewrite_rect.rect.height / 2) ;



                if( Rectangle.Check_point_inside(  mouse_x,  mouse_y   , x_min, x_max, y_min , y_max   )   ){

                        if( Input.GetMouseButtonDown( 0 ) ){ Trocar_modo_texto( Type_writing_construction.typewrite ); }
                        return true;
                        
                }

                return false;

        }

        public bool Verificar_tela_cheia(){

                float mouse_x = CONTROLLER__data.Pegar_instancia().posicao_mouse[0]  -    configuration_container_rect.localPosition[0]  -  full_screen.localPosition[0] - 960f;
                float mouse_y = CONTROLLER__data.Pegar_instancia().posicao_mouse[1]  -  configuration_container_rect.localPosition[1]  -  full_screen.localPosition[1] - 540f ;

                float x_min  = full_screen_ativa.localPosition[0] - (full_screen_ativa.rect.width / 2) ;
                float x_max  = full_screen_ativa.localPosition[0] + (full_screen_ativa.rect.width / 2) ;
                
                float y_min = full_screen_ativa.localPosition[1] - (full_screen_ativa.rect.height / 2) ;
                float y_max = full_screen_ativa.localPosition[1] + (full_screen_ativa.rect.height / 2) ;

                
                if( Rectangle.Check_point_inside(  mouse_x,  mouse_y   , x_min, x_max, y_min , y_max   )   ){

                        if( Input.GetMouseButtonDown( 0 ) ){ Trocar_full_screen(); }
                        return true;

                }

                return false;

        }





}

