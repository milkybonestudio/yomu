using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public static class Teste_figure_context{

        public static Figure figure;

        public static void U(){


                    // ** cria sem context -> default visual novel
                    // ** constroi mas nao define o lugar para instanciar a figure, vai ficar no container generico
                    figure = Teste_figure.Construct();

                    // ** cria com context
                    figure = Teste_figure.Construct( Figure_use_context.conversation );

                    // ** constroi e já fala o local
                    figure = Teste_figure.Construct().Set( GameObject.Find( "Container_teste" ) );

                    // ** Seta o lugar
                    figure.Set( GameObject.Find( "Container_teste" ) );


                    
                    // ** Setar como null vai fazer o gameObject ser instanciado no container generico
                    figure.Set( null );




                    // ** vai começar a carregar os recursor de um modo
                    figure.Prepare( Figure_mode_type.mad );

                    // ** vai voltar os recursos para o minomo e destruir a teture. Tomar cuidado quando usar
                    figure.Reduce( Figure_mode_type.mad );


                    // ** vai preparar de todos os modos
                    figure.Prepare();

                    // ** libera todos os recursos, tomar muito cuido
                    figure.Reduce();


                    // ** coloca ele no jogo, força a instanciar um modo
                    // ** seria melhor fazer figure.Prepare() -> figure.Instanciate
                    // ** se nao definir um lugar antes ele vai dar um erro
                    figure.Instanciate( Figure_mode_type.mad );

                    // ** coloca ele no jogo, força a instanciar um modo
                    // ** seria melhor fazer figure.Prepare() -> figure.Instanciate
                    figure.Instanciate( Figure_mode_type.mad, GameObject.Find( "Container_teste" ) );



                    // ** troca o modo
                    // ** sempre preferir figure.Prepare() -> figure.Change()
                    figure.Change_mode( Figure_mode_type.mad );


                    // ** todos os metodos das figures tem argumentos em forma de structs especificos
                        // ** depois de 50~ elementos vale mais a pena usar classes
                        
                    figure.Blick( new Blink_data() );
                    figure.Speak( new Speak_data() );




                    //test

                    // ** pega modo
                    // ** usado somente para teste, nao tem porque ficar mexendo nele diretamente
                    figure.Get( Figure_mode_type.mad );

                    //test



        }

}

public class Teste_figure : Figure {


        // ** pode mudar o contexto, esta como default para personagens 
        // ** caso nao coloque os dados vai dar erro, o End() sempre limpa os dados estaticos. 
        // ** Se nao der o end() vai dar erro quando fizer o update, e se der o end mas nao colcoar o put() também vai dar erro porque main_folder/root_path vao estar null
        public static Figure Construct( Figure_use_context _context = Figure_use_context.visual_novel ){ Put_data( _context: _context, _main_folder: "Lily", _root_path: "Clothes" /* _resources_context: Resource_context.X*/ ); return new Teste_figure(); }


        public Teste_figure(){

                figure_modes.Add( new Teste_figure_MAD().Construct( _figure: this, _visual_figure: Figure_mode_type.mad, _images_links_length: 10, _resources_length: 10 ) );

        }

        // ** nao precisa no final, somente para testes
        public override void Update( Control_flow _flow ){

            base.Update( _flow );
            Teste_figure_TESTE.Update( this );

        }

        public RESOURCE__image_ref head_1 = Get_image_reference_not_root( "Clothes/head_1" );

        // public RESOURCE__image_ref exp_1 = Get_image_reference( "exp_1" );

        public RESOURCE__image_ref[] exp_1_mouth = Get_images_reference( "exp_1", 2 );
    
        public RESOURCE__image_ref body_1 = Get_image_reference( "body_1" );

        public RESOURCE__image_ref boots_1 = Get_image_reference_not_root( "Clothes/boots_1" );
        public RESOURCE__image_ref top_1 = Get_image_reference_not_root( "Clothes/top_1" );
        public RESOURCE__image_ref arms_1 = Get_image_reference_not_root( "Clothes/arms_1" );
        public RESOURCE__image_ref arms_2 = Get_image_reference_not_root( "Clothes/arms_2" );




}





public static class Teste_figure_TESTE {

    public static void Update( Figure figure ){


                // --- MOVE
                if(  Input.GetKey( KeyCode.LeftArrow ))
                    { figure.Move( -50, 0 ); }

                
                if(  Input.GetKey( KeyCode.RightArrow ))
                    { figure.Move( 50, 0 ); }

                if(  Input.GetKey( KeyCode.UpArrow ))
                    { figure.Move( 0, 50 ); }

                if(  Input.GetKey( KeyCode.DownArrow ))
                    { figure.Move( 0, -50 ); }


                // --- ROTATION


                if(  Input.GetKey( KeyCode.Q ))
                    { figure.Rotate( 35f, 0, 0 ); }


                if(  Input.GetKey( KeyCode.W ))
                    { figure.Rotate( -35f, 0, 0 ); }



                if(  Input.GetKey( KeyCode.A ))
                    { figure.Rotate( 0, 35f, 0 ); }


                if(  Input.GetKey( KeyCode.S ))
                    { figure.Rotate( 0, -35f, 0 ); }



                if(  Input.GetKey( KeyCode.Z ))
                    { figure.Rotate( 0, 0, 35f ); }


                if(  Input.GetKey( KeyCode.X ))
                    { figure.Rotate( 0, 0, -35f ); }



                // --- SCALE


                if(  Input.GetKey( KeyCode.E ))
                    { figure.Rescale( 35f, 0 ); }


                if(  Input.GetKey( KeyCode.R ))
                    { figure.Rescale( -35f, 0 ); }



                if(  Input.GetKey( KeyCode.D ))
                    { figure.Rescale( 0, 35f ); }


                if(  Input.GetKey( KeyCode.F ))
                    { figure.Rescale( 0, -35f ); }




    }

}



