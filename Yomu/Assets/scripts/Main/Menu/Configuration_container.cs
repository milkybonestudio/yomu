
using UnityEngine;
using UnityEngine.UI;
using System;





  
  
  
  
  
  
  
  public class Configuration_container{


    public bool volume_is_pressionado = false;


    public float x_position = 0f;
    public float y_position = 0f;

    
    public GameObject game_object;
    

    public RectTransform configuration_container_rect; 


    public RectTransform volume_rect;
    public RectTransform volume_base_rect; 
    public RectTransform volume_botao_rect; 
    public RectTransform volume_cor_ativa_rect; 
                         
    public RectTransform volume_cor_inativa_rect; 


    public RectTransform  texto_rect;
    public RectTransform text_fade_rect; 
    public RectTransform text_instant_rect; 
    public RectTransform text_typewrite_rect; 

    public RectTransform text_active_rect; 



    public RectTransform full_screen; 
    public RectTransform full_screen_ativa; 
    public Image tela_cheia_YES_image;




    public void Trocar_modo_texto( Tipo_construcao_texto _tipo){


        Controlador_configuration.Pegar_instancia().Mudar_tipo_texto(_tipo);
        
        Vector3 nova_posicao = new Vector3();
        switch(_tipo){

            case Tipo_construcao_texto.fade: nova_posicao =new Vector3( -200f , 0f,0f)  ; break;
            case Tipo_construcao_texto.instant: nova_posicao =new Vector3( 0f , 0f,0f)  ;break; 
            case Tipo_construcao_texto.typewrite: nova_posicao =new Vector3( 200f , 0f,0f)  ; break;

        }

        if(nova_posicao != null) text_active_rect.localPosition = nova_posicao;

        

        return;

    }



    public void  Trocar_volume_ativo(  float _novo_volume ){



        float novo_width =  volume_base_rect.rect.width * _novo_volume / 100f;


        float p0 = -(volume_base_rect.rect.width/2);


        float p1  = p0 + novo_width;


        float pM = (p1 + p0 ) / 2;


        volume_cor_ativa_rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal  ,  novo_width  );
        volume_cor_ativa_rect.localPosition = new Vector3(  pM  ,   0f  ,  0f );

        return;

    }


    public void Trocar_full_screen(){


        Screen.fullScreen = !Screen.fullScreen;
        

         if(Controlador_configuration.Pegar_instancia().full_screen){

            tela_cheia_YES_image.color = new Color( 1f , 1f,1f , 0f );

            Controlador_configuration.Pegar_instancia().full_screen = false;



         }


         else {
            
            tela_cheia_YES_image.color = new Color( 1f , 1f,1f , 1f );
            Controlador_configuration.Pegar_instancia().full_screen = true;
            
            }
         


        return;

    }


    public void Update(){

         
            float mouse_x = Controlador_data.Pegar_instancia().posicao_mouse[0];
            float mouse_y = Controlador_data.Pegar_instancia().posicao_mouse[1];

         
            float x_min ;
            float x_max ;
            
            float y_min;
            float y_max ;
            



           //   volume 








           

            mouse_x = Controlador_data.Pegar_instancia().posicao_mouse[0]  -    configuration_container_rect.localPosition[0]  -  volume_rect.localPosition[0] - 960f;
            mouse_y = Controlador_data.Pegar_instancia().posicao_mouse[1]  -  configuration_container_rect.localPosition[1]  -  volume_rect.localPosition[1] - 540f ;
            

            x_min  = volume_botao_rect.localPosition[0] - (volume_botao_rect.rect.width / 2) ;
            x_max  = volume_botao_rect.localPosition[0] + (volume_botao_rect.rect.width / 2) ;
            
            y_min = volume_botao_rect.localPosition[1] - (volume_botao_rect.rect.height / 2) ;
            y_max = volume_botao_rect.localPosition[1] + (volume_botao_rect.rect.height / 2) ;


              

            
            
           if(  volume_is_pressionado && Controlador_input.Get(Key_code.mouse_left) ){



                    


                   float nova_posicao =  mouse_x;
                   if(nova_posicao >  volume_base_rect.rect.width/2 )   nova_posicao = volume_base_rect.rect.width/2 ;
                   if(nova_posicao < -volume_base_rect.rect.width/2 )   nova_posicao = -volume_base_rect.rect.width/2 ;

                   volume_botao_rect.localPosition = new Vector3(  nova_posicao   ,0f,0f);
                     

                    int novo_volume =    Convert.ToInt32(  100f *  ((nova_posicao   +   volume_base_rect.rect.width/ 2) / volume_base_rect.rect.width )  ) ;

                    Trocar_volume_ativo( (float) novo_volume);


                    Controlador_configuration.Pegar_instancia().Mudar_volume(novo_volume);



                    return;

            }  else{
                   
                   volume_is_pressionado = false;

            }







            if(Mat.Verificar_ponto_dentro_retangulo(  mouse_x + x_position,  mouse_y + y_position  , x_min, x_max, y_min , y_max   )   ){

                    if(  Controlador_input.Get_down(Key_code.mouse_left)  ){

                            volume_is_pressionado = true;
                        


                    }


                }


                        

 

       






           //  tipo texto 


           

           
            mouse_x = Controlador_data.Pegar_instancia().posicao_mouse[0]  -    configuration_container_rect.localPosition[0]  -  texto_rect.localPosition[0] - 960f;
            mouse_y = Controlador_data.Pegar_instancia().posicao_mouse[1]  -  configuration_container_rect.localPosition[1]  -  texto_rect.localPosition[1] - 540f ;




            // fade 

            x_min  = text_fade_rect.localPosition[0] - (text_fade_rect.rect.width / 2) ;
            x_max  = text_fade_rect.localPosition[0] + (text_fade_rect.rect.width / 2) ;
            
            y_min = text_fade_rect.localPosition[1] - (text_fade_rect.rect.height / 2) ;
            y_max = text_fade_rect.localPosition[1] + (text_fade_rect.rect.height / 2) ;



            if(Mat.Verificar_ponto_dentro_retangulo(  mouse_x + x_position,  mouse_y + y_position  , x_min, x_max, y_min , y_max   )   ){

                 if(   Controlador_input.Get_down(Key_code.mouse_left) ){

                    Trocar_modo_texto( Tipo_construcao_texto.fade);

                 }

                




                return;
            }





            //  instant 


            x_min  = text_instant_rect.localPosition[0] - (text_instant_rect.rect.width / 2) ;
            x_max  = text_instant_rect.localPosition[0] + (text_instant_rect.rect.width / 2) ;
            
            y_min = text_instant_rect.localPosition[1] - (text_instant_rect.rect.height / 2) ;
            y_max = text_instant_rect.localPosition[1] + (text_instant_rect.rect.height / 2) ;



            if(Mat.Verificar_ponto_dentro_retangulo(  mouse_x + x_position,  mouse_y + y_position  , x_min, x_max, y_min , y_max   )   ){

                 if( Controlador_input.Get_down(Key_code.mouse_left) ){

                    Trocar_modo_texto( Tipo_construcao_texto.instant );


                 }

                return;
            }




            // typewrite


            x_min  = text_typewrite_rect.localPosition[0] - (text_typewrite_rect.rect.width / 2) ;
            x_max  = text_typewrite_rect.localPosition[0] + (text_typewrite_rect.rect.width / 2) ;
            
            y_min = text_typewrite_rect.localPosition[1] - (text_typewrite_rect.rect.height / 2) ;
            y_max = text_typewrite_rect.localPosition[1] + (text_typewrite_rect.rect.height / 2) ;



            if(Mat.Verificar_ponto_dentro_retangulo(  mouse_x,  mouse_y   , x_min, x_max, y_min , y_max   )   ){

                 if( Controlador_input.Get_down(Key_code.mouse_left) ){

                    Trocar_modo_texto( Tipo_construcao_texto.typewrite );



                 }

                return;
            }










           //  full screen




           
           
            mouse_x = Controlador_data.Pegar_instancia().posicao_mouse[0]  -    configuration_container_rect.localPosition[0]  -  full_screen.localPosition[0] - 960f;
            mouse_y = Controlador_data.Pegar_instancia().posicao_mouse[1]  -  configuration_container_rect.localPosition[1]  -  full_screen.localPosition[1] - 540f ;




            x_min  = full_screen_ativa.localPosition[0] - (full_screen_ativa.rect.width / 2) ;
            x_max  = full_screen_ativa.localPosition[0] + (full_screen_ativa.rect.width / 2) ;
            
            y_min = full_screen_ativa.localPosition[1] - (full_screen_ativa.rect.height / 2) ;
            y_max = full_screen_ativa.localPosition[1] + (full_screen_ativa.rect.height / 2) ;


            
            if(Mat.Verificar_ponto_dentro_retangulo(  mouse_x,  mouse_y   , x_min, x_max, y_min , y_max   )   ){

                 if( Controlador_input.Get_down(Key_code.mouse_left) ){

                Trocar_full_screen();



                 }

                return;
            }



            

            

      



        return;
    }



        public Configuration_container(float _x_position , float _y_position , Transform _transform){

            

            float x_position = _x_position;
            float y_position = _y_position;



            game_object = new GameObject("Configurations_container");
            
            Image image = game_object.AddComponent<Image>();

            image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_corpo");

            configuration_container_rect = game_object.GetComponent<RectTransform>();
            configuration_container_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  720f   );
            configuration_container_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  700f   );



            game_object.transform.SetParent(  _transform, false );
            game_object.transform.localPosition = new Vector3(_x_position, _y_position , 0f);

          

          









                //   volume

          
            GameObject volume = new GameObject("Volume");
            volume.transform.SetParent(game_object.transform, false);

            volume_rect = volume.AddComponent<RectTransform>();

            volume_rect.localPosition = new Vector3(0f,110f);
            
            







            GameObject volume_cor_inativa = new GameObject("Volume_cor_inativa");
            volume_cor_inativa.transform.SetParent(volume.transform,false);


            Image volume_cor_inativa_image = volume_cor_inativa.AddComponent<Image>();
            volume_cor_inativa_image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_volume_cor_inativo");

            
            volume_cor_inativa_rect = volume_cor_inativa.GetComponent<RectTransform>();
            volume_cor_inativa_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  450f   );
            volume_cor_inativa_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  50f   );
            volume_cor_inativa_rect.localPosition = new Vector3(0f,0f,0f);

            








                //  configurar dependendo do som
            GameObject volume_cor_ativa = new GameObject("Volume_cor_ativa");
            volume_cor_ativa.transform.SetParent(volume.transform, false);
            Image volume_cor_ativa_image = volume_cor_ativa.AddComponent<Image>();
            volume_cor_ativa_image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_volume_cor_ativo");

            
            volume_cor_ativa_rect = volume_cor_ativa.GetComponent<RectTransform>();
            volume_cor_ativa_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  450f   );
            volume_cor_ativa_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  50f   );

            volume_cor_ativa_rect.localPosition = new Vector3(1f,1f,1f);


            













            GameObject volume_base = new GameObject("Volume_base");
            volume_base.transform.SetParent(volume.transform, false);

            Image volume_base_image = volume_base.AddComponent<Image>();
            volume_base_image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_volume_base");

            volume_base_rect = volume_base.GetComponent<RectTransform>();
            volume_base_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  450f   );
            volume_base_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  50f   );
            volume_base_rect.localPosition = new Vector3(0f,0f,0f);








            
            GameObject volume_botao = new GameObject("volume_botao");
            volume_botao.transform.SetParent(volume.transform, false);
            Image volume_botao_image = volume_botao.AddComponent<Image>();
            volume_botao_image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_volume_botao");


            float p_max = 225f;
            float p_min = -225f;

            float posicao_atual =  (((Controlador_configuration.Pegar_instancia().volume) *  (   (p_max - p_min)/100f     )   ) -  p_max);

            
            volume_botao_rect = volume_botao.GetComponent<RectTransform>();
            volume_botao_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  75f   );
            volume_botao_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  75f   );
            volume_botao_rect.localPosition = new Vector3(posicao_atual,0f,0f);

         

            




    






            //  texto


            GameObject tipo_texto = new GameObject("Tipo_texto");
            tipo_texto.transform.SetParent(game_object.transform, false);
            texto_rect = tipo_texto.AddComponent<RectTransform>();
            texto_rect.localPosition = new Vector3(0f,-90f,0f);




            GameObject tipo_texto_fade = new GameObject("Tipo_texto_fade");
            tipo_texto_fade.transform.SetParent(tipo_texto.transform, false);
            Image tipo_texto_fade_image = tipo_texto_fade.AddComponent<Image>();
            tipo_texto_fade_image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_tipo_text_fade");

            text_fade_rect = tipo_texto_fade.GetComponent<RectTransform>();
            text_fade_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  150f   );
            text_fade_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  75f   );
            text_fade_rect.transform.localPosition = new Vector3(-200f, 0f ,0f);






            GameObject tipo_texto_instant = new GameObject("Tipo_texto_instant");
            tipo_texto_instant.transform.SetParent(tipo_texto.transform, false);
            Image tipo_texto_instant_image = tipo_texto_instant.AddComponent<Image>();
            tipo_texto_instant_image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_tipo_text_instant");

            
            text_instant_rect = tipo_texto_instant.GetComponent<RectTransform>();
            text_instant_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  150f   );
            text_instant_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  75f   );
            text_instant_rect.transform.localPosition = new Vector3(0f, 0f ,0f);
           







            GameObject tipo_texto_typewrite = new GameObject("Tipo_texto_typewrite");
            tipo_texto_typewrite.transform.SetParent(tipo_texto.transform, false);
            Image tipo_texto_typewrite_image = tipo_texto_typewrite.AddComponent<Image>();
            tipo_texto_typewrite_image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_tipo_text_typewrite");

            text_typewrite_rect = tipo_texto_typewrite.GetComponent<RectTransform>();
            text_typewrite_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  150f   );
            text_typewrite_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  75f   );
            text_typewrite_rect.transform.localPosition = new Vector3(200f, 0f ,0f);





            GameObject text_active = new GameObject("Text_active");
            text_active.transform.SetParent(tipo_texto.transform, false);
            Image text_active_image = text_active.AddComponent<Image>();
            text_active_image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_tipo_text_ESCOLHIDO");

            text_active_rect = text_active.GetComponent<RectTransform>();
            text_active_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  150f   );
            text_active_rect.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  75f   );
            text_active_rect.transform.localPosition = new Vector3(-200f, 0f ,0f);

            


            

            // tela cheia



            GameObject tela_cheia = new GameObject("Tela_cheia");
            tela_cheia.transform.SetParent( game_object.transform, false);
            Image tela_cheia_image = tela_cheia.AddComponent<Image>();
            tela_cheia_image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_full_screen");



            full_screen = tela_cheia.GetComponent<RectTransform>();
            full_screen.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  75f   );
            full_screen.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  75f   );
            full_screen.localPosition = new Vector3(0f,-280f,0f);




            GameObject tela_cheia_YES =  new GameObject("Tela_cheia_YES");
            tela_cheia_YES.transform.SetParent( tela_cheia.transform, false);
            tela_cheia_YES_image = tela_cheia_YES.AddComponent<Image>();
            tela_cheia_YES_image.sprite = Resources.Load<Sprite>("images/utilidade_geral/configurations/configurations_full_screen_ATIVO");
            tela_cheia_YES_image.color = new Color(1f,1f,1f,0f);


            full_screen_ativa = tela_cheia_YES.GetComponent<RectTransform>();
            full_screen_ativa.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal   ,  75f   );
            full_screen_ativa.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical   ,  75f   );
            full_screen_ativa.localPosition = new Vector3(0f,0f,0f);
            


            //    ativar depois


            Trocar_volume_ativo(   (float)  Controlador_configuration.Pegar_instancia().volume   );

        


        }



  }

