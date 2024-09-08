using UnityEngine;
using System;
using UnityEngine.UI;




public class Botao_mono : MonoBehaviour {


    //  a imagem atual vai ser sempre a off 

    [NonSerialized] public Sprite imagem_off = null ;
    [NonSerialized] public Color imagem_off_cor = Color.clear;

    public Sprite imagem_on = null ;
    public Color imagem_on_cor = Color.clear;

    

    public Sprite imagem_press = null ;
    public Color imagem_press_cor = Color.clear;

    public Image imagem_slot = null;

    public Collider2D collider;


    public Action Mouse_entrar = null;
    public Action Mouse_sair = null;
    public Action Mouse_click = null;


    bool esta_dentro = false ;
    bool esta_press = false;


    public void Start() {


            imagem_slot = gameObject.GetComponent<Image>();
            imagem_off =  imagem_slot.sprite;
            imagem_off_cor = imagem_slot.color;


            if ( Mouse_entrar == null ) { Mouse_click = ()=>{} ;} 
            if ( Mouse_sair == null ) { Mouse_click = ()=>{} ;} 
            if ( Mouse_click == null ) { Mouse_click = ()=>{} ;} 

            if( imagem_on == null ) { imagem_on = imagem_off; }
            if( imagem_press == null ) { imagem_press = imagem_on; }



    }

           
    public Estado_botao update() {


        //     Vector2 posicao_mouse =  Controlador_cursor.Pegar_posicao_cursor_atual();
        //     bool esta_tocando = colider.OverlapPoint( posicao_mouse ) ;
        //     bool nao_esta_tocando = !( esta_tocando ) ;

        //     bool ESTAVA_tocando = this.esta_dentro;
        //     bool NAO_ESTAVA_tocando = !( this.esta_dentro );

        //     this.esta_dentro = esta_tocando;
    

        //     if( NAO_ESTAVA_tocando && nao_esta_tocando  ) { return new Estado_botao() /*tudo false*/ ;  }
        //     if( NAO_ESTAVA_tocando && esta_tocando ){ return Lidar_mouse_entrar(); } 
        //     if( ESTAVA_tocando && nao_esta_tocando  ) { return Lidar_mouse_saiu(); }
        //     if( ESTAVA_tocando && esta_tocando ){ return Lidar_mouse_sobre(); }

        return new Estado_botao();


    }

    public Estado_botao Lidar_mouse_saiu(){ 


        //     Mouse_sair();

        //     imagem_slot.sprite = imagem_off; 
        //     imagem_slot.color = imagem_off_cor;

            Estado_botao estado_botao_retorno = new Estado_botao();
            estado_botao_retorno.esta_dentro = false;
            estado_botao_retorno.esta_pressionado = false;
            estado_botao_retorno.click_ativado = false;

            return estado_botao_retorno ;


    }

    public Estado_botao Lidar_mouse_entrar(){ 

        //     Mouse_entrar();

        //     imagem_slot.sprite = imagem_on; 
        //     imagem_slot.color = imagem_on_cor;

            Estado_botao estado_botao_retorno = new Estado_botao();
            estado_botao_retorno.esta_dentro = true;
            estado_botao_retorno.esta_pressionado = false;
            estado_botao_retorno.click_ativado = false;

            return estado_botao_retorno ;


    }


    

    public Estado_botao Lidar_mouse_sobre(){


            bool esta_pressionando  = Input.GetMouseButton( 0 );
        //     if( esta_pressionando ) { imagem_slot.sprite = imagem_press; imagem_slot.color = imagem_press_cor; } else { imagem_slot.sprite = imagem_on; imagem_slot.color = imagem_on_cor;  }

            bool esta_click = Input.GetMouseButtonUp( 0 ); 
        //     if( esta_click ){ Mouse_click(); }


            Estado_botao estado_botao_retorno = new Estado_botao();
            estado_botao_retorno.esta_pressionado = esta_pressionando;
            estado_botao_retorno.click_ativado = esta_click;
            estado_botao_retorno.esta_dentro = true;

            return estado_botao_retorno;

            
    }




}
