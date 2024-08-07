
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;




public static class Cores {

    // *** USOS INTERNO ESPECIFICO

    public static Color cor_default_dispositivo = ( Color ) new Color32( 1,1,1,1 );


    public static Color clear                   = new Color(0f,0f,0f,0f);


    public static Color maroon	                = ( Color ) new Color32(128,0,0,255);
 	public static Color dark_red	            = ( Color ) new Color32(139,0,0,255);
 	public static Color brown	                = ( Color ) new Color32(165,42,42,255);
 	public static Color firebrick	            = ( Color ) new Color32(178,34,34,255);
 	public static Color crimson	                = ( Color ) new Color32(220,20,60,255);
 	public static Color red	                    = ( Color ) new Color32(255,0,0,255);
 	public static Color tomato	                = ( Color ) new Color32(255,99,71,255);
 	public static Color coral	                = ( Color ) new Color32(255,127,80,255);
 	public static Color indian_red	            = ( Color ) new Color32(205,92,92,255);
 	public static Color light_coral	            = ( Color ) new Color32(240,128,128,255);
 	public static Color dark_salmon	            = ( Color ) new Color32(233,150,122,255);
 	public static Color salmon	                = ( Color ) new Color32(250,128,114,255);
 	public static Color light_salmoz            = ( Color ) new Color32(255,160,122,255);
 	public static Color orange_red	            = ( Color ) new Color32(255,69,0,255);
 	public static Color dark_orange	            = ( Color ) new Color32(255,140,0,255);
 	public static Color orange	                = ( Color ) new Color32(255,165,0,255);
 	public static Color gold	                = ( Color ) new Color32(255,215,0,255);
 	public static Color dark_golden_rod	        = ( Color ) new Color32(184,134,11,255);
 	public static Color golden_rod	            = ( Color ) new Color32(218,165,32,255);
 	public static Color pale_golden_rod	        = ( Color ) new Color32(238,232,170,255);
 	public static Color dark_khaki	            = ( Color ) new Color32(189,183,107,255);
 	public static Color khaki	                = ( Color ) new Color32(240,230,140,255);
 	public static Color olive	                = ( Color ) new Color32(128,128,0,255);
 	public static Color yellow	                = ( Color ) new Color32(255,255,0,255);
 	public static Color yellow_green            = ( Color ) new Color32(154,205,50,255);
 	public static Color dark_olive_green        = ( Color ) new Color32(85,107,47,255);
 	public static Color olive_drab	            = ( Color ) new Color32(107,142,35,255);
 	public static Color lawn_green	            = ( Color ) new Color32(124,252,0,255);
 	public static Color chartreuse	            = ( Color ) new Color32(127,255,0,255);
 	public static Color green_yellow	        = ( Color ) new Color32(173,255,47,255);
 	public static Color dark_green	            = ( Color ) new Color32(0,100,0,255);
 	public static Color green	                = ( Color ) new Color32(0,128,0,255);
 	public static Color forest_green	        = ( Color ) new Color32(34,139,34,255);
 	public static Color lime	                = ( Color ) new Color32(0,255,0,255);
 	public static Color lime_green	            = ( Color ) new Color32(50,205,50,255);
 	public static Color light_green	            = ( Color ) new Color32(144,238,144,255);
 	public static Color pale_green	            = ( Color ) new Color32(152,251,152,255);
 	public static Color dark_sea_green	        = ( Color ) new Color32(143,188,143,255);
 	public static Color medium_spring_green     = ( Color ) new Color32(0,250,154,255);
 	public static Color spring_green	        = ( Color ) new Color32(0,255,127,255);
 	public static Color sea_green	            = ( Color ) new Color32(46,139,87,255);
 	public static Color medium_aqua_marine      = ( Color ) new Color32(102,205,170,255);
 	public static Color medium_sea_green        = ( Color ) new Color32(60,179,113,255);
 	public static Color light_sea_green	        = ( Color ) new Color32(32,178,170,255);
 	public static Color dark_slate_gray	        = ( Color ) new Color32(47,79,79,255);
 	public static Color teal	                = ( Color ) new Color32(0,128,128,255);
 	public static Color dark_cyan	            = ( Color ) new Color32(0,139,139,255);
 	public static Color aqua	                = ( Color ) new Color32(0,255,255,255);
 	public static Color cyan	                = ( Color ) new Color32(0,255,255,255);
 	public static Color light_cyan	            = ( Color ) new Color32(224,255,255,255);
 	public static Color dark_turquoise	        = ( Color ) new Color32(0,206,209,255);
 	public static Color turquoise	            = ( Color ) new Color32(64,224,208,255);
 	public static Color medium_turquoise        = ( Color ) new Color32(72,209,204,255);
 	public static Color pale_turquoise	        = ( Color ) new Color32(175,238,238,255);
 	public static Color aqua_marine	            = ( Color ) new Color32(127,255,212,255);
 	public static Color powder_blue	            = ( Color ) new Color32(176,224,230,255);
 	public static Color cadet_blue	            = ( Color ) new Color32(95,158,160,255);
 	public static Color steel_blue	            = ( Color ) new Color32(70,130,180,255);
 	public static Color corn_flower_blue        = ( Color ) new Color32(100,149,237,255);
 	public static Color deep_sky_blue	        = ( Color ) new Color32(0,191,255,255);
 	public static Color dodger_blue	            = ( Color ) new Color32(30,144,255,255);
 	public static Color light_blue	            = ( Color ) new Color32(173,216,230,255);
 	public static Color sky_blue	            = ( Color ) new Color32(135,206,235,255);
 	public static Color light_sky_blue	        = ( Color ) new Color32(135,206,250,255);
 	public static Color midnight_blue	        = ( Color ) new Color32(25,25,112,255);
 	public static Color navy	                = ( Color ) new Color32(0,0,128,255);
 	public static Color dark_blue	            = ( Color ) new Color32(0,0,139,255);
 	public static Color medium_blue	            = ( Color ) new Color32(0,0,205,255);
 	public static Color blue	                = ( Color ) new Color32(0,0,255,255);
 	public static Color royal_blue	            = ( Color ) new Color32(65,105,225,255);
 	public static Color blue_violet	            = ( Color ) new Color32(138,43,226,255);
 	public static Color indigo	                = ( Color ) new Color32(75,0,130,255);
 	public static Color dark_slate_blue	        = ( Color ) new Color32(72,61,139,255);
 	public static Color slate_blue	            = ( Color ) new Color32(106,90,205,255);
 	public static Color medium_slate_blue       = ( Color ) new Color32(123,104,238,255);
 	public static Color medium_purple	        = ( Color ) new Color32(147,112,219,255);
 	public static Color dark_magenta	        = ( Color ) new Color32(139,0,139,255);
 	public static Color dark_violet	            = ( Color ) new Color32(148,0,211,255);
 	public static Color dark_orchid	            = ( Color ) new Color32(153,50,204,255);
 	public static Color medium_orchid	        = ( Color ) new Color32(186,85,211,255);
 	public static Color purple	                = ( Color ) new Color32(128,0,128,255);
 	public static Color thistle	                = ( Color ) new Color32(216,191,216,255);
 	public static Color plum	                = ( Color ) new Color32(221,160,221,255);
 	public static Color violet	                = ( Color ) new Color32(238,130,238,255);
 	public static Color magenta	                = ( Color ) new Color32(255,0,255,255);
 	public static Color orchid	                = ( Color ) new Color32(218,112,214,255);
 	public static Color medium_violet_red       = ( Color ) new Color32(199,21,133,255);
 	public static Color pale_violet_red	        = ( Color ) new Color32(219,112,147,255);
 	public static Color deep_pink	            = ( Color ) new Color32(255,20,147,255);
 	public static Color hot_pink	            = ( Color ) new Color32(255,105,180,255);
 	public static Color light_pink	            = ( Color ) new Color32(255,182,193,255);
 	public static Color pink	                = ( Color ) new Color32(255,192,203,255);
 	public static Color antique_white	        = ( Color ) new Color32(250,235,215,255);
 	public static Color beige	                = ( Color ) new Color32(245,245,220,255);
 	public static Color bisque	                = ( Color ) new Color32(255,228,196,255);
 	public static Color blanched_almond	        = ( Color ) new Color32(255,235,205,255);
 	public static Color wheat	                = ( Color ) new Color32(245,222,179,255);
 	public static Color corn_silk	            = ( Color ) new Color32(255,248,220,255);
 	public static Color lemon_chiffon	        = ( Color ) new Color32(255,250,205,255);
 	public static Color light_golden_rod_yellow	= ( Color ) new Color32(250,250,210,255);
 	public static Color light_yellow	        = ( Color ) new Color32(255,255,224,255);
 	public static Color saddle_brown	        = ( Color ) new Color32(139,69,19,255);
 	public static Color sienna	                = ( Color ) new Color32(160,82,45,255);
 	public static Color chocolate	            = ( Color ) new Color32(210,105,30,255);
 	public static Color peru	                = ( Color ) new Color32(205,133,63,255);
 	public static Color sandy_brown	            = ( Color ) new Color32(244,164,96,255);
 	public static Color burly_wood	            = ( Color ) new Color32(222,184,135,255);
 	public static Color tan	                    = ( Color ) new Color32(210,180,140,255);
 	public static Color rosy_brown	            = ( Color ) new Color32(188,143,143,255);
 	public static Color moccasin	            = ( Color ) new Color32(255,228,181,255);
 	public static Color navajo_white	        = ( Color ) new Color32(255,222,173,255);
 	public static Color peach_puff	            = ( Color ) new Color32(255,218,185,255);
 	public static Color misty_rose	            = ( Color ) new Color32(255,228,225,255);
 	public static Color lavender_blush	        = ( Color ) new Color32(255,240,245,255);
 	public static Color linen	                = ( Color ) new Color32(250,240,230,255);
 	public static Color old_lace	            = ( Color ) new Color32(253,245,230,255);
 	public static Color papaya_whip	            = ( Color ) new Color32(255,239,213,255);
 	public static Color sea_shell	            = ( Color ) new Color32(255,245,238,255);
 	public static Color mint_cream	            = ( Color ) new Color32(245,255,250,255);
 	public static Color slate_gray	            = ( Color ) new Color32(112,128,144,255);
 	public static Color light_slate_gray        = ( Color ) new Color32(119,136,153,255);
 	public static Color light_steel_blue        = ( Color ) new Color32(176,196,222,255);
 	public static Color lavender	            = ( Color ) new Color32(230,230,250,255);
 	public static Color floral_white	        = ( Color ) new Color32(255,250,240,255);
 	public static Color alice_blue	            = ( Color ) new Color32(240,248,255,255);
 	public static Color ghost_white	            = ( Color ) new Color32(248,248,255,255);
 	public static Color honeydew	            = ( Color ) new Color32(240,255,240,255);
 	public static Color ivory	                = ( Color ) new Color32(255,255,240,255);
 	public static Color azure	                = ( Color ) new Color32(240,255,255,255);
 	public static Color snow	                = ( Color ) new Color32(255,250,250,255);
 	public static Color black	                = ( Color ) new Color32(0,0,0,255);
 	public static Color dim_grey	            = ( Color ) new Color32(105,105,105,255);
 	public static Color grey	                = ( Color ) new Color32(128,128,128,255);
 	public static Color dark_grey	            = ( Color ) new Color32(169,169,169,255);
 	public static Color silver	                = ( Color ) new Color32(192,192,192,255);
 	public static Color light_grey	            = ( Color ) new Color32(211,211,211,255);
 	public static Color gainsboro	            = ( Color ) new Color32(220,220,220,255);
 	public static Color white_smoke	            = ( Color ) new Color32(245,245,245,255);
 	public static Color white	                = ( Color ) new Color32(255,255,255,255);


    public static Color grey_90	                = new Color( ( 1f * 0.9f ), ( 1f * 0.9f ), ( 1f * 0.9f ), 1f );
    public static Color grey_80	                = new Color( ( 1f * 0.8f ), ( 1f * 0.8f ), ( 1f * 0.8f ), 1f ); 
    public static Color grey_70	                = new Color( ( 1f * 0.7f ), ( 1f * 0.7f ), ( 1f * 0.7f ), 1f );
    public static Color grey_60	                = new Color( ( 1f * 0.6f ), ( 1f * 0.6f ), ( 1f * 0.6f ), 1f );
    public static Color grey_50	                = new Color( ( 1f * 0.5f ), ( 1f * 0.5f ), ( 1f * 0.5f ), 1f );
    public static Color grey_40	                = new Color( ( 1f * 0.4f ), ( 1f * 0.4f ), ( 1f * 0.4f ), 1f );
    public static Color grey_30	                = new Color( ( 1f * 0.3f ), ( 1f * 0.3f ), ( 1f * 0.3f ), 1f );
    public static Color grey_20	                = new Color( ( 1f * 0.2f ), ( 1f * 0.2f ), ( 1f * 0.2f ), 1f );
    public static Color grey_10	                = new Color( ( 1f * 0.1f ), ( 1f * 0.1f ), ( 1f * 0.1f ), 1f );




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



            case Nome_cor.white_080: return new Color( 0.8f, 0.8f, 0.8f, 1f);
            case Nome_cor.white_100: return new Color( 1f, 1f, 1f, 1f);



            default: throw new System.ArgumentException("cor nao foi encontrada. veio: " +   _nome.ToString() );


          }


        }




}