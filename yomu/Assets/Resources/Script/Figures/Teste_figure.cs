using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Teste_figure : Figure {


        static Teste_figure(){ Figure.Put_data( "Lily", "Clothes" ); }

        public Teste_figure(){


                figure_emotions.Add( new Teste_figure_MAD().Construct( this, Visual_figure.mad ) );

                
        }

    
        // --- IMAGE LIST

        // ** sempre vao ter prealloc como compress_low_quality 
        // ** cada Figure_image_component vai ter outra copia que pode mudar o recurso de acordo com a necessidade

        public RESOURCE__image_ref body_1 = Get_image_reference( "lily_clothes_body_1" );
        public RESOURCE__image_ref body_2 = Get_image_reference_not_root( "Clothes/lily_clothes_bracos_1" );

        public RESOURCE__image_ref head_1;

        
}