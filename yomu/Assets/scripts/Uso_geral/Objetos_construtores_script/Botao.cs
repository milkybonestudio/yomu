using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using TMPro;



public enum Tipo_botao{
    
    estatico = 0,
    cor = 1,
    dinamico_E_cor = 2,
    dinamico = 3,

}





public class Botao{
    

    public Tipo_botao tipo_botao;
    public Cor_cursor cursor_hover = Cor_cursor.green;

    public string som_click = null;

    public bool pode_hover;

    public float width;
    public float height;
    public float x_position;
    public float y_position;

    public float x_min;
    public float x_max;

    public float y_min;
    public float y_max;

    public float text_width;
    public float text_height;

    public GameObject game_object;

    public Transform parent_transform;

    public string nome;

    public GameObject text_game_object;
    
    public TextMeshProUGUI text_container; 

    public Image imagem_slot;

    public Sprite[] sprites_arr;
    public Color[] cores_arr;

    public int id_sprite_atual;
    public int id_cor_atual;

    public Action handler_mouse;

    public Action entrar_mouse;
    public Action sair_mouse;
    public Action click;

    public bool botao_esta_trancado =  false;


    public Coroutine visibilidade_botao_coroutine;

    
    
    public RectTransform rect_imagem;




    
    public Botao(

        string _nome, 
        float _width, 
        float _height,
        float _x_position,
        float _y_position,
        Transform _parent_transform ,
        //           nao testei para ver se vai dar problema
        Action  _on_click = null, 
        Tipo_botao _tipo_botao = Tipo_botao.cor ,
        bool _pode_hover = true,
        Sprite[] _sprites_arr = null, 
        Color[] _cores_arr = null
    
    ) {




        if(    (_tipo_botao == Tipo_botao.dinamico_E_cor || _tipo_botao == Tipo_botao.dinamico ) && _sprites_arr == null  ){

                throw new ArgumentException("nao veio spraits botao");

        }



         if( _sprites_arr == null ){ _sprites_arr = new Sprite[]{ null } ; } 
         if( _cores_arr == null){ _cores_arr = new Color[]{    new Color(0.85f,0.85f,0.85f,1f)   ,  new Color(1f,1f,1f,1f)   } ;}


            this.tipo_botao = _tipo_botao;
            this.pode_hover = _pode_hover;
            this.sprites_arr = _sprites_arr;
            this.cores_arr = _cores_arr;
         

            this.nome = _nome;
            this.width = _width;
            this.height = _height;



            // (x) posicao na tela  =>  mudou para centro
            /*

                0 ,1080     1920 , 1080

                0,0          1920 , 0


            */

            this.x_position = _x_position + 960f;
            this.y_position = _y_position + 540f;

            
             this.y_max = this.y_position + this.height / 2f;
             this.y_min = this.y_position - this.height / 2f;


             this.x_max = this.x_position + this.width / 2f;
             this.x_min =  this.x_position - this.width / 2f;


            


            this.parent_transform = _parent_transform;


            this.game_object  =  new GameObject(_nome);

            this.game_object.transform.SetParent(_parent_transform, false);

          ///                                                            na tela            na tela
            this.game_object.transform.localPosition = new Vector3(   _x_position , _y_position , 0f);

            

            
            this.imagem_slot  =  this.game_object.AddComponent<Image>();
            this.rect_imagem = this.game_object.GetComponent<RectTransform>();

            this.rect_imagem.SetSizeWithCurrentAnchors(   RectTransform.Axis.Horizontal , this.width   );
            this.rect_imagem.SetSizeWithCurrentAnchors(   RectTransform.Axis.Vertical , this.height    );


            this.imagem_slot.sprite = sprites_arr[0];

         
            this.click = _on_click;


                 

    }






    public void Esconder_botao(float _tempo_ms){

        if(_tempo_ms == 0f){

            this.imagem_slot.color = new Color(1f,1f,1f,0f);
            this.text_container.color = new Color(1f,1f,1f,0f);

            return;
        }


        if (visibilidade_botao_coroutine != null){

            Mono_instancia.Stop_coroutine( visibilidade_botao_coroutine );
            visibilidade_botao_coroutine = null;

        }

        visibilidade_botao_coroutine = Mono_instancia.Start_coroutine(  Mudar_visibilidade_botao_c( -1f,  _tempo_ms) );
        return;


    }



    public void Mostrar_botao(float _tempo_ms){

        if(_tempo_ms == 0f){

            this.imagem_slot.color = new Color(1f,1f,1f,1f);
            this.text_container.color = new Color(1f,1f,1f,1f);

            return;
        }

        if (visibilidade_botao_coroutine != null){

            Mono_instancia.Stop_coroutine( visibilidade_botao_coroutine );
            visibilidade_botao_coroutine = null;

        }

        visibilidade_botao_coroutine = Mono_instancia.Start_coroutine(  Mudar_visibilidade_botao_c( 1f, _tempo_ms) );
        return;

    }

    

    public void Trancar_botao(){

        botao_esta_trancado =  true;
        return;

    }

    public void Liberar_botao(){

        botao_esta_trancado =  false;
        return;


    }

    public IEnumerator Mudar_visibilidade_botao_c( float _sign ,float _tempo_ms){


            int numero_ciclos =  (int)  (   ( _tempo_ms * 60f ) /  1000f );


            float valor_inicial = this.imagem_slot.color[3];
            float valor_final =  (1f + _sign) / 2f ;


            float a_atual = valor_inicial;

            
            float d_a = valor_final / (float) numero_ciclos  ;
            
            for(int i = 0;  i< numero_ciclos  ; i++){

                    float valor_modificado = a_atual * a_atual;

                    Color cor_rgb = this.imagem_slot.color;
                    Color nova_cor = new Color( cor_rgb[0], cor_rgb[1], cor_rgb[2],  a_atual);
                    this.imagem_slot.color = nova_cor;

                    a_atual  += ( _sign * d_a);
                    yield return null;
                

            }


            Color cor_rgb_final = this.imagem_slot.color;
            Color cor_final = new Color( cor_rgb_final[0], cor_rgb_final[1], cor_rgb_final[2],  valor_inicial  );
            this.imagem_slot.color = cor_final;
    

            this.imagem_slot.color = Color.white;

            visibilidade_botao_coroutine = null;
            yield break;


    }



    public void Colocar_imagem(string _path){

        Sprite sprite  = Resources.Load<Sprite>(_path);
        if(sprite == null) throw new ArgumentException("nao foi achado imagem no path: " + _path);

        
        this.imagem_slot.sprite = sprite;
        
        return;

    }



    public void Colocar_som_click(string _path){

        som_click = _path;
        return;
    }



    public void Colocar_texto(

        string _text,
        float _text_width = 0f,
        float _text_height = 0f,
        float _font_size = 5f,
        TextAlignmentOptions _align = TextAlignmentOptions.MidlineGeoAligned
                
        ){


            
                    this.text_width = _text_width;
                    this.text_height = _text_height;

                    this.text_game_object = new GameObject("Text");
                    text_container = text_game_object.AddComponent<TextMeshProUGUI>();

                    text_container.alignment = _align;
                    


                    text_container.text = _text;

                    text_container.color = Color.black;
                    text_container.fontSize = _font_size;

                    RectTransform text_rect = text_container.GetComponent<RectTransform>();

                    this.text_game_object.transform.SetParent(    this.game_object.transform   ,false);
                    
                    text_rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal  ,  this.text_width );
                    text_rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical  ,  this.text_height );


    }

     
    
    public void Mudar_cor_hover(Cor_cursor _nova_cor){

        cursor_hover = _nova_cor;
        return;

    }


    public bool Update(bool is_click , float[] _posicao_mouse){

        

        if( botao_esta_trancado  ) return false;
        

        bool ver = Rectangle.Check_point_inside(_posicao_mouse[0] , _posicao_mouse[1] , this.x_min ,this.x_max,  this.y_min, this.y_max );

        if(ver){

            

            //mark 
            //** mudou
            CONTROLLER__input.Pegar_instancia().manager_cursor.Change_action( Cursor_action.choice  ); // cursor_hover

            if(som_click != null && is_click) CONTROLLER__audio.Pegar_instancia().Acrecentar_sfx( som_click );
            
            if(this.tipo_botao == Tipo_botao.cor){


                if(this.id_cor_atual == 0) {

                    this.id_cor_atual = 1;
                    this.imagem_slot.color = this.cores_arr[1];

                }

                


            } else if( this.tipo_botao == Tipo_botao.dinamico ){

                this.imagem_slot.sprite = sprites_arr[1];

            }


            //  important!
            if(is_click) this.click();

            return true;

            
        } 

            //Controlador_cursor.Pegar_instancia().Mudar_cursor(Cor_cursor.off);

             if(this.tipo_botao == Tipo_botao.cor){

                if(this.id_cor_atual == 1) {

                    this.id_cor_atual = 0;
                    this.imagem_slot.color = this.cores_arr[0];

                }

                


            } else if( this.tipo_botao == Tipo_botao.dinamico ){

                    this.imagem_slot.sprite = sprites_arr[0];

            }


        

        return false;




        
    }




    public void handler_mouse_estatico_E_estatico(){

    }










}