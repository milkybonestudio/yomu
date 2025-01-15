using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public static class Teste_figure_context{

        public static Figure figure;

        public static void U(){


                    // ** cria sem context -. default visual novel
                    figure = Teste_figure.Construct();

                    // ** cria com context
                    figure = Teste_figure.Construct( Figure_use_context.conversation );

                    // ** constroi e já fala o local
                    figure = Teste_figure.Construct().Set( GameObject.Find( "Container_teste" ) );

                    // ** constroi mas nao define o lugar
                    figure = Teste_figure.Construct();


                    // ** pega modo
                    // ** usado somente para teste, nao tem porque ficar mexendo nele diretamente
                    figure.Get( Figure_mode_type.mad );



                    // ** vai começar a carregar os recursor de um modo
                    figure.Prepare( Figure_mode_type.mad );

                    // ** vai preparar de todos os modos
                    figure.Prepare();

                    // ** coloca ele no jogo
                    figure.Instanciate( Figure_mode_type.mad, null );

                    // ** troca o modo
                    figure.Change_mode( Figure_mode_type.mad );


                            // ** força a criaçao da texture
                            // ** se nao tiver dado o Set( "place" ) vai dar um erro.
                            // ** a figure vai ficar no container se nao for definido um lugar mas precisa para ser instanciada

                            figure.Get( Figure_mode_type.mad ).Instanciate();

                            // ** os 3 jeitos funcionam para dar o Set( "place" )
                            figure.Set( null ).Get( Figure_mode_type.mad ).Instanciate();
                            figure.Get( Figure_mode_type.mad ).Set( null ).Instanciate();
                            figure.Get( Figure_mode_type.mad ).Instanciate( null );


                    // ** todos os metodos das figures tem argumentos em forma de structs especificos
                        // ** depois de 50~ elementos vale mais a pena usar classes
                        
                    figure.Blick( new Blink_data() );
                    figure.Speak( new Speak_data() );

                    // figure.Rescale_to( 200f );

                    // figure.Get( Figure_mode_type.mad ).Prepare();


        }

}

public class Teste_figure : Figure {


        // ** pode mudar o contexto, esta como default para personagens 
        // ** caso nao coloque os dados vai dar erro, o End() sempre limpa os dados estaticos. 
        // ** Se nao der o end() vai dar erro quando fizer o update, e se der o end mas nao colcoar o put() também vai dar erro porque main_folder/root_path vao estar null
        public static Figure Construct( Figure_use_context _context = Figure_use_context.visual_novel ){ Put_data( _context: _context, _main_folder: "Lily", _root_path: "Clothes" /* _resources_context: Resource_context.X*/ ); return new Teste_figure(); }


        public Teste_figure(){

                figure_modes.Add( new Teste_figure_MAD().Construct( this, Figure_mode_type.mad ) );
                End();

        }

        public override void Update(){

            base.Update();
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



