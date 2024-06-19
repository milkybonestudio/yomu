using System;
using UnityEngine;




/*


UI =>   

tem um nome no enum Tipo_UI que vai apontar para uma class com o tipo de UI

tem um enum para cada tipo de Ui para cada componente da UI

todo tipo de UI precisa ter 3 funcoes:


Mudar_visibilidade  => pega um bool[] que o index representa se o componente vai ser mostrado. bool[   (int) enum.componente   ] == true  => vai mostrar
Esconder => esconde tudo 
Mostrar => mostra tudo 


se o objeto tem componentes moveis ele não pode mover se estiver escondido



*/









public class UI_info {



    public GameObject game_object;
    public Tipo_UI tipo;
    public Action Mostrar;
    public Action Esconder;
    public Action< bool[] , bool > Mudar_visibilidade;

    public UI_info( GameObject _game_object = null , Tipo_UI _tipo = Tipo_UI.nada , Action< bool[] , bool> _mudar_visibilidade = null ,  Action _esconder = null , Action _mostrar = null){

        this.game_object = _game_object;
        this.Esconder = _esconder;
        this.Mostrar = _mostrar;
        this.tipo = _tipo ;
        this.Mudar_visibilidade = _mudar_visibilidade;

    }

}







public class Controlador_UI {


      
        public static Controlador_UI instancia;
        public static Controlador_UI Pegar_instancia(){ return instancia; }
        public static Controlador_UI Construir(){ instancia = new Controlador_UI(); return instancia;}



    public System.Object UI_objeto;

    public GameObject game_object = null;

    public Tipo_UI tipo_UI_atual = Tipo_UI.nada;
    public UI_info info;


    public void Iniciar() {

        game_object = GameObject.Find( "Tela/UI/UI_container" );
        info = new UI_info();

    }

    public Action UI_objeto_update;

    public bool foi_ativado = false;

    public bool Update(){

        /*  UI pode corta o fluxo anted de chegar em cada bloco. o jeito que ele vai mudar foi_ativado depende de cada objeto  */
        /*  choice => sempre retona true. o jogo para completamenta para o player fazer a escolha   */
        /*  icones => retorna true se algo for ativado   */

        // Ui nao vai ativar necessariamente algo no bloco_jogo. nesse logica Mapa estaria em Ui e não em jogo.

        foi_ativado = false;

        if( UI_objeto_update != null ) { UI_objeto_update(); } 

        return foi_ativado;



    }




    public void Mudar_UI() {


        Req_mudar_UI _req_ui = Dados_blocos.req_mudar_UI;

        if( _req_ui == null  ){  return ; }

        

        Tipo_UI _novo_tipo = _req_ui.novo_tipo_UI ;  
        bool[] _mostrar =  _req_ui.UI_partes ;
        bool instantaneo = _req_ui.instantaneo ; 


        // Debug.Log("instantaneo: " +  instantaneo);
        // Debug.Log("novo tipo : " + _novo_tipo);
        // Debug.Log("mostrar: " + _mostrar.Length);
        
       // throw new ArgumentException("a");

        if( _novo_tipo == this.info.tipo ) { 

            if( _mostrar != null ){ info.Mudar_visibilidade( _mostrar , instantaneo );}
    
            
        }  else {

                if( _mostrar == null ){ _mostrar = new bool[]{ true };}
                
                // precisa destruir a antiga


                switch( _novo_tipo ){

                    case Tipo_UI.in_game:  In_game_UI.Iniciar(  instantaneo, _mostrar  ); break;


                }

        }

        Dados_blocos.req_mudar_UI = null;

    

    }







}