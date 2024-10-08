using UnityEngine;
using System;



public static  class ____Mat {


      
    //  public static bool Verificar_ponto_dentro_retangulo ( float x, float y, float x_rect_min,  float x_rect_max   ,float y_rect_min,  float y_rect_max  ){

    //       return  !!!(  x  <  x_rect_min    ||  x > x_rect_max   ||   y < y_rect_min   ||  y> y_rect_max  );

    //  }



    //  public static void Verificar_ponto_dentro_retangulo_REF (  ref bool dentro ,  float x, float y, float x_rect_max,  float x_rect_min   ,float y_rect_max,  float y_rect_min  ){

    //       dentro = !(  x  <  x_rect_min    ||  x> x_rect_max   ||   y < y_rect_min   ||  y> y_rect_max  );

    //       return;
          
    //  }




    // public static int Pegar_lado_colidido_retangulo(  float[] pontos_reta_entrada,  float[] pontos_lados_possiveis   , int point = 0 ){


    //         for(  int  i = 0 ;   i <  4  ; i++  ){

    //                 bool is_cross = Verificar_cross_retas   (
    //                                                             i,

    //                                                             pontos_reta_entrada[0],
    //                                                             pontos_reta_entrada[1],
    //                                                             pontos_reta_entrada[2],
    //                                                             pontos_reta_entrada[3],

    //                                                             pontos_lados_possiveis[  (i * 2) ],
    //                                                             pontos_lados_possiveis[  (i * 2) + 1 ],
                                                                
    //                                                             pontos_lados_possiveis[  ( (i * 2  ) + 2 ) % 8],
    //                                                             pontos_lados_possiveis[  ( (i * 2  ) + 3 ) % 8]
    //                                                         );
                
    //                 if( is_cross) 
    //                     {  return i ; }

    //                 continue;
                    
    //         }

    //         throw new ArgumentException("não foi achado um lado com cross em Pegar_lado_colidido_retangulo");

    // }


    // public static bool Verificar_cross_retas( int lado ,  float p_x_1  , float p_y_1,  float p_x_2  , float p_y_2   ,      float p_x_3  , float p_y_3,  float p_x_4  , float p_y_4     ){


    //         float PX =                     
    //                     ( 
    //                         ( ( p_x_1  *  p_y_2 )  -  ( p_y_1 * p_x_2 )   ) * ( p_x_3 - p_x_4 )    -   ( p_x_1 - p_x_2  ) * (   p_x_3 * p_y_4   -  p_y_3 * p_x_4 )
    //                     ) 
    //                     / 
    //                     (
    //                         ( p_x_1 - p_x_2  ) * (   p_y_3 - p_y_4  )  - ( p_y_1 - p_y_2 ) * ( p_x_3 - p_x_4 )   
    //                     );


    //         if(  !!! ( float.IsFinite(PX) ) )
    //             { return false; } 
            

    //         float PY = (  
    //                         ( 
    //                             ( ( ( p_x_1  *  p_y_2 )   -  ( p_y_1 * p_x_2 ) ) )
    //                             * 
    //                             ( p_y_3 - p_y_4 ) 
    //                         )
    //                         -  
    //                         (
    //                             ( ( p_y_1 - p_y_2  ) * ( p_x_3 * p_y_4 ) ) - ( p_y_3 * p_x_4 )
    //                         )  
    //                     ) 
    //                     / 
    //                     (   
    //                         ( ( p_x_1 - p_x_2  ) * (   p_y_3 - p_y_4  ) )  
    //                         - 
    //                         ( ( p_y_1 - p_y_2 ) * ( p_x_3 - p_x_4 ) )
    //                     );



    //         bool v1_1 = ( (PX < p_x_3) != (PX < p_x_4) ) ;
    //         bool v1_2 = (    -0.1f  <   (PX - p_x_3 ) && (  (PX - p_x_3 ) < 0.1f   )      ||  ( PX == p_x_4 )) ;
    //         bool v1_3 = (    (PY <  p_y_3)  !=   (PY < p_y_4)   )    ;
    //         bool v1_4 =   (    (   -0.1f < (PY - p_y_3)  &&  (PY - p_y_3) < 0.1f     )     ||   (PY == p_y_4)   )  ;

    //         bool v1  = ( v1_1  ||  v1_2  ) &&  ( v1_3  ||  v1_4 ) ; 


    //         bool v2_1 =  ( (PX < p_x_1) != (PX < p_x_2) )   ;
    //         bool v2_2 =  ( (   (   -0.1f < (PX - p_x_1)  &&  (PX - p_x_1) < 0.1f     )        ) || (PX == p_x_2) )   ;
    //         bool v2_3 = (    (PY <  p_y_1)  !=   (PY < p_y_2)   )  ; 
    //         bool v2_4 =  (  (   -0.1f < (PY - p_y_1)   &&  (PY - p_y_1)  < 0.1f     )     ||   (PY == p_y_2)   ) ; 

    //         bool v2 = (  v2_1   ||  v2_2 )    &&     (  v2_3  ||  v2_4   ) ;




    //         bool OLD =  ( ( PY == p_y_3 ) || ( PY == p_y_4 ) ) ;

    //         bool NEW =  ( 
    //                         (   -0.1f < (PY - p_y_3)   &&  (PY - p_y_3)  < 0.1f     )   

    //                         ||   
                            
    //                         (   -0.1f < (PY - p_y_4)   &&  (PY - p_y_4)  < 0.1f     )  
    //                     ) ; 
            
            
    //         if(  v1 && v2 ) 
    //             { return true; } 


    //         return false;

    // }



        public static float Ajustar_webgl( float _numero ){

                float sign = 1f ;

                if( _numero < 0f )
                    {  
                        _numero *= -1f; 
                        sign = -1f; 
                    }
                
                _numero = MathF.Round( _numero, 0 ) ;
                _numero *= sign;
                
                return _numero;

        }



        public static  bool Verificar_ponto_passa_reta_flip(  float ponto_teste_x, float ponto_teste_y,  float p_x_1,  float p_y_1, float p_x_2, float p_y_2 ){


                float ponto_x_final = ((  ponto_teste_y - p_y_2  ) * (  p_x_2 - p_x_1 ) / (p_y_2 - p_y_1)) + (p_x_2);

                return ponto_x_final > ponto_teste_x   &&       (    (ponto_teste_y <=  p_y_1)  !=   (ponto_teste_y <= p_y_2)   );
            
        }

  
        // public static int Calcular_ponto_entrada_retangulo(  float[]  _obj_1_project_pontos  ,   float[] _obj_2_project_pontos ){

        

        //         for(   int i =0 ;  i  < 8  ;  i = i + 2  ){


        //                 bool colisao    =    !!!(   
        //                                             ( _obj_1_project_pontos[ i ] < _obj_2_project_pontos[ 0 ] )
        //                                             ||
        //                                             ( _obj_1_project_pontos[ i ]   >  _obj_2_project_pontos[ 2 ] )
        //                                             ||
        //                                             ( _obj_1_project_pontos[ ( i + 1 ) ] >  _obj_2_project_pontos[ 1 ] )
        //                                             ||
        //                                             ( _obj_1_project_pontos[  ( i + 1 ) ]  <  _obj_2_project_pontos[ 5 ] ) 

        //                                         );
            
        //                 if( colisao )
        //                     { return ( i / 2 ) + 1; }

        //                 continue;

        //         }



        //         for(   int k =0 ;  k  < 8  ;  k = k + 2  ) {


        //                 bool colisao    =    !!!(
        //                                             ( _obj_2_project_pontos[ k ] < _obj_1_project_pontos[ 0 ] )
        //                                             ||
        //                                             ( _obj_2_project_pontos[ k ]   >  _obj_1_project_pontos[ 2 ] )
        //                                             ||
        //                                             ( _obj_2_project_pontos[ ( k + 1 ) ]    >   _obj_1_project_pontos[ 1 ] )    
        //                                             ||
        //                                             ( _obj_2_project_pontos[  ( k + 1 ) ]     <  _obj_1_project_pontos[ 5 ] )
        //                                         );

        //                 if(colisao)
        //                     { return  -(  (k / 2) + 1 ); }
                            
        //                 continue;

        //         }

        //         throw new ArgumentException("nao foi achado ponto");
                

        // }



        // // public static bool Verificar_colisao_retangulos(   Fisica_objeto  _obj_1  ,    Fisica_objeto _obj_2  ){
        // public static bool Verificar_colisao_retangulos(   float[]  _obj_1_project_pontos  ,    float[] _obj_2_project_pontos  ){

        //         // retorno true se tem pelo menos 1 ponto dentro um do outro, calculei os 2 para nao ter a posibilidade de um pequeno entrar em um grande e calcular a partir do grande


        //         for(  int i = 0 ;  i  < 8  ;  i = i + 2  ){


        //                 bool colisao  =  !!!(  
        //                                         ( _obj_1_project_pontos[ i ] < _obj_2_project_pontos[ 0 ] )
        //                                         ||
        //                                         ( _obj_1_project_pontos[ i ]   >  _obj_2_project_pontos[ 2 ] )     
        //                                         ||
        //                                         ( _obj_1_project_pontos[ ( i + 1 ) ]    >   _obj_2_project_pontos[ 1 ] )
        //                                         ||
        //                                         ( _obj_1_project_pontos[  ( i + 1 ) ]     <  _obj_2_project_pontos[ 5 ] )
        //                                     );
            
        //                 if( colisao )
        //                     { return true; }


        //         }


        //         for(   int k = 0 ;  k  < 8  ;  k = ( k + 2 )  ){

        //             bool colisao =     !!!(  
        //                                         ( _obj_2_project_pontos[ k ] < _obj_1_project_pontos[ 0 ] )      
        //                                         ||  
        //                                         ( _obj_2_project_pontos[ k ]   >  _obj_1_project_pontos[ 2 ] )
        //                                         ||   
        //                                         ( _obj_2_project_pontos[ ( k + 1 ) ]    >   _obj_1_project_pontos[ 1 ])
        //                                         || 
        //                                         ( _obj_2_project_pontos[  ( k + 1 ) ]     <  _obj_1_project_pontos[ 5 ]  ) 
        //                                     );

        //             if( colisao )
        //                 { return true;}


        //         }

        //         return false;


        // }


        // public static bool Verificar_colisao_retangulos_com_variacao_mov(   float[]  _obj_1  , float _var_1_x , float _var_1_y,    float[] _obj_2 ,  float _var_2_x = 0f  ,  float _var_2_y = 0f ){


        //         // retorno true se tem pelo menos 1 ponto dentro um do outro, calculei os 2 para nao ter a posibilidade de um pequeno entrar em um grande e calcular a partir do grande
                
        //         for(  int i = 0 ;  i  < 8  ;  i = i + 2 ){
    
        //                 bool colisao    =                            
        //                                     !!!(  (  _obj_1[ i ] + _var_1_x      < _obj_2[ 0 ] +_var_2_x   )  
        //                                     ||       
        //                                     ( _obj_1[i] + _var_1_x  >  _obj_2[2] + _var_2_x   ) 
        //                                     ||
        //                                     ( _obj_1[i + 1] + _var_1_y   >   _obj_2[1] + _var_2_y ) 
        //                                     ||   
        //                                     ( _obj_1[  i+ 1]  + _var_1_y    <  _obj_2[5] + _var_2_y  ) );
            
                        
        //                 if( colisao )
        //                     { return true; }

        //                 continue;

        //         }

                
        //         for(   int k =0 ;  k  < 8  ;  k = k + 2  ){


        //                 bool colisao    =   
        //                                      !!!( 
        //                                             ( _obj_2[ k ]  +  _var_2_x  < _obj_1[ 0 ] + _var_1_x   ) 
        //                                             ||     
        //                                             (  _obj_2[ k ] + _var_2_x  >  _obj_1[ 2 ] + _var_1_x   )
        //                                             ||   
        //                                             ( _obj_2[ k + 1 ]  + _var_2_y  >   _obj_1[ 1 ] + _var_1_y  )  
        //                                             ||
        //                                             ( _obj_2[  k + 1 ]  +_var_2_y   <  _obj_1[ 5 ]  + _var_1_y ) 
        //                                         );


        //                 if( colisao )
        //                     { return true;}
                            
        //                 continue;

        //         }

        //         return false;

        // }




        // public static float[] Transformar_dados_em_pontos(  float[] _position,   float[] _tamanho ){

        //         float width = _tamanho[ 0 ];
        //         float height = _tamanho[ 1 ];

        //         float pX = _position[ 0 ];
        //         float pY = _position[ 1 ];



        //         /* 
        //             0------1
        //             |      |
        //             |      |
        //             3------2
        //         */

        //         float[] final = new float[ 8 ];

        //         final[ 0 ] = ( pX - (  width / 2 ) );
                
        //         final[ 1 ] = ( pY + (  height / 2 ) );

                
        //         final[ 2 ] = ( pX + (  width / 2 ) );
        //         final[ 3 ] = ( pY + (  height / 2 ) );

                
        //         final[ 4 ] = ( pX + (  width / 2 ) );
        //         final[ 5 ] = ( pY - (  height / 2 ) );

                
        //         final[ 6 ] = ( pX - (  width / 2 ) );
        //         final[ 7 ] = ( pY - (  height / 2 ) );


        //         return final;


        // }


}


