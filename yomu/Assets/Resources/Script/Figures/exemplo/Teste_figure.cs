using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Teste_figure : Figure {


        // ** pode mudar o contexto, esta como default para personagens 
        // ** caso nao coloque os dados vai dar erro, o End() sempre limpa os dados estaticos. 
        // ** Se nao der o end() vai dar erro quando fizer o update, e se der o end mas nao colcoar o put() também vai dar erro porque main_folder/root_path vao estar null
        public static Figure Construct(){ Put_data( _main_folder: "Lily", _root_path: "Clothes" /* _resources_context: Resource_context.X*/ ); return new Teste_figure(); }


        public Teste_figure(){

                figure_modes.Add( new Teste_figure_MAD().Construct( this, Figure_mode_type.mad ) );
                End();

        }

        public override void Update(){

            base.Update();
            Teste_figure_TESTE.Update( this );


        }

        public RESOURCE__image_ref head_1 = Get_image_reference_not_root( "Clothes/head_1" );
        public RESOURCE__image_ref exp_1 = Get_image_reference( "exp_1" );
    
        public RESOURCE__image_ref body_1 = Get_image_reference( "body_1" );

        public RESOURCE__image_ref boots_1 = Get_image_reference_not_root( "Clothes/boots_1" );
        public RESOURCE__image_ref top_1 = Get_image_reference_not_root( "Clothes/top_1" );
        public RESOURCE__image_ref arms_1 = Get_image_reference_not_root( "Clothes/arms_1" );
        public RESOURCE__image_ref arms_2 = Get_image_reference_not_root( "Clothes/arms_2" );




}


public static class Teste_figure_TESTE {

    public static void Update( Figure figure ){


                // --- MOVE
                if(  Input.GetKeyDown( KeyCode.LeftArrow ))
                    { figure.Move( -50, 0 ); }

                
                if(  Input.GetKeyDown( KeyCode.RightArrow ))
                    { figure.Move( 50, 0 ); }

                if(  Input.GetKeyDown( KeyCode.UpArrow ))
                    { figure.Move( 0, 50 ); }

                if(  Input.GetKeyDown( KeyCode.DownArrow ))
                    { figure.Move( 0, -50 ); }


                // --- ROTATION


                if(  Input.GetKeyDown( KeyCode.Q ))
                    { figure.Rotate( 35f, 0, 0 ); }


                if(  Input.GetKeyDown( KeyCode.W ))
                    { figure.Rotate( -35f, 0, 0 ); }



                if(  Input.GetKeyDown( KeyCode.A ))
                    { figure.Rotate( 0, 35f, 0 ); }


                if(  Input.GetKeyDown( KeyCode.S ))
                    { figure.Rotate( 0, -35f, 0 ); }



                if(  Input.GetKeyDown( KeyCode.Z ))
                    { figure.Rotate( 0, 0, 35f ); }


                if(  Input.GetKeyDown( KeyCode.X ))
                    { figure.Rotate( 0, 0, -35f ); }



                // --- SCALE


                if(  Input.GetKeyDown( KeyCode.E ))
                    { figure.Rescale( 35f, 0 ); }


                if(  Input.GetKeyDown( KeyCode.R ))
                    { figure.Rescale( -35f, 0 ); }



                if(  Input.GetKeyDown( KeyCode.D ))
                    { figure.Rescale( 0, 35f ); }


                if(  Input.GetKeyDown( KeyCode.F ))
                    { figure.Rescale( 0, -35f ); }








    }

}



