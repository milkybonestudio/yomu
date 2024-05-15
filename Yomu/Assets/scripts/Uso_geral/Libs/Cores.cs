
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;







public static class Cores {





    // public static Color cor_80 = new Color(0.8f,0.8f,0.8f,1f);
    // public static Color cor_85 = new Color(0.8f,0.8f,0.8f,1f);
    // /// ???
    // public static Color cor_95 = new Color(0.93f,0.93f,0.93f,1f);
    // public static Color cor_100 = new Color(1f,1f,1f,1f);




        public static Color Pegar_cor( Nome_cor _nome ){



          switch( _nome ){

            case Nome_cor.nada: return Color.black;
            case Nome_cor.red:  return Color.red;
            case Nome_cor.green:  return Color.green;
            case Nome_cor.blue:  return Color.blue;
            case Nome_cor.black:  return Color.black;
            case Nome_cor.white:  return Color.white;

            case Nome_cor.lily_default_text_color:  return  Color.blue;
            case Nome_cor.eden_default_text_color:  return  Color.black;
            case Nome_cor.bill_default_text_color:  return  Color.black;

            case Nome_cor.molly_default_text_color:  return  Color.blue;
            case Nome_cor.erinbaldo_default_text_color:  return  Color.blue;

            case Nome_cor.riku_default_text_color:  return  new Color(0.035f, 0.22f, 0.016f, 1f);
            case Nome_cor.james_default_text_color:  return new Color(0.2f, 0.031f, 0.008f, 1f) ;
            case Nome_cor.nara_default_text_color:  return  Color.black;
            case Nome_cor.maki_default_text_color:  return  new Color(0.226f,0.009f,0.139f,1f); 
            case Nome_cor.dia_default_text_color:  return  new Color(0.1165895f,0.1496948f,0.1886792f,1f);
            case Nome_cor.takeru_default_text_color:  return  new Color(0.065f,0.110f,0.320f,1f);
            case Nome_cor.nadia_default_text_color:  return  new Color(0.333f, 0.055f, 0.161f, 1f);

            case Nome_cor.ruby_default_text_color:  return  new Color( 0.3490566f ,0.03457636f, 0.09760491f  , 1f);
            case Nome_cor.jayden_default_text_color:  return  new Color( 0.4433962f, 0.03973833f, 0.1786948f , 1f); 
            case Nome_cor.christopher_default_text_color:  return  new Color( 0.1132075f,  0.08831804f , 0.009077962f , 1f);  



            case Nome_cor.dark_1: return new Color(0.95f,0.95f,0.95f,1f);
            case Nome_cor.dark_2: return new Color(0.81f,0.81f,0.81f,1f);
            case Nome_cor.dark_3: return new Color(0.7f,0.7f,0.7f,1f);
            case Nome_cor.dark_4: return new Color(0.6f,0.6f,0.6f,1f); 

            case Nome_cor.dark_5: return new Color(0.4f,0.4f,0.4f,1f);
            case Nome_cor.dark_6: return new Color(0.25f,0.25f,0.25f,1f);
            case Nome_cor.dark_7: return new Color(0.15f,0.15f,0.15f,1f);  
            case Nome_cor.dark_8: return new Color(0.1f,0.1f,0.1f,1f);
            case Nome_cor.dark_9: return new Color(0.07f,0.07f,0.07f,1f);
            case Nome_cor.dark_10: return new Color(0.04f,0.04f,0.04f,1f);

            case Nome_cor.noite : return new Color(0.3906728f,0.402525f,0.5566038f,1f);

            case Nome_cor.noite_dark : return new Color(0.063f, 0.055f, 0.11f , 1f ) ;

            case Nome_cor.noite_dark_plus : return new Color (0.039f, 0.035f, 0.071f , 1f) ;
            
            case Nome_cor.yellow_light : return new Color(0.992f, 1f, 0.137f, 1f);
            case Nome_cor.green_light : return new Color(0.204f, 1f, 0.137f, 1f);



            default: throw new System.ArgumentException("cor nao foi encontrada. veio: " +   _nome.ToString() );


          }


        }



      // public static Color Pegar_cor_geral (  string _thing ){


      //     switch(_thing){

      //       case "white": return Color.white;
           
      //       default: return  new Color(1f,1f,1f,1f);
      //     }




      //   }

    




    //    uso geral 



    





}