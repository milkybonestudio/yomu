using UnityEngine;
using System;



public static  class Mat {



     public static System.Random random =  new System.Random();
      
     public static float Pegar_chance(){

                // retorna float 0-1
                return  ((float) (random.Next(  100001 ) ) ) / 100000f;

        }

     

          public static T[] Calcular_array_generico_enum<T>(    T[] _default, T[] _subtrair = null, T[]  _acrescentar  = null ){ 



               if(_subtrair == null) { _subtrair = new T[0]; }
               if(_acrescentar == null) { _acrescentar = new T[0]; }

               int[] DEFAULT = new int[  _default.Length];
               int[] SUBTRAIR = new int[  _subtrair.Length];
               int[] ACRESCENTAR = new int[  _acrescentar.Length];

               int index = 0;
               int length = 0;


               length = DEFAULT.Length;
               
               while(index < length){ 

                    DEFAULT[index] =  (int) (System.Object) _default[index];

                    index++;
               }

               length = SUBTRAIR.Length;
               index = 0;
               
               while(index < length){ 

                    SUBTRAIR[index] =  (int) (System.Object) _subtrair[index];

                    index++;
               }


               length = ACRESCENTAR.Length;
               index = 0;
               
               while(index < length){ 

                    ACRESCENTAR[index] =  (int) (System.Object) _acrescentar[index];

                    index++;
               }

               int[] retorno_int = INT.Aplicar_subtrair_e_adicionar_array(DEFAULT, SUBTRAIR, ACRESCENTAR);

               T[] arr_retorno = new T[  retorno_int.Length  ];

               for(int k = 0;k< arr_retorno.Length;k++){

                    arr_retorno[ k ] = (T) (System.Object) retorno_int[ k ];

               }

               return arr_retorno;


          }









          // public static int[] calcular_teste_enum_exp(Interativo_nome[]  arr){

          //      int[] a = new int[arr.Length];

          //      for(  int i = 0;  i < arr.Length  ; i++  ){

          //                a[i] =  (int) arr[i];

          //      }

          //      return a;


          // }













     public static bool Verificar_ponto_dentro_poligono(float[] _ponto , float[] _poligono ){

            if(_poligono == null) return false;

            if( _poligono.Length % 2 != 0  ) throw new ArgumentException("fora do padrao");
            

            bool resultado = false;
            int numero_pontos = _poligono.Length / 2;
            
            
                int j = _poligono.Length;
                int i = 0;
                int k = 1;           
                    
        
                for(   int cont = 0 ; cont < numero_pontos - 1 ; cont ++){

                      
                    if(    (  _ponto[1] < _poligono[k] )    !=     (_ponto[1]<(_poligono[k+2]))    &&     (_ponto[0]<   ((_ponto[1]+( - _poligono[k] ))*(_poligono[i+2]-_poligono[i])/(   _poligono[k+2]  - _poligono[k]     ))+(_poligono[i]))       )  resultado =! resultado;    
                    i = i+ 2;
                    k = k + 2 ; 

                }

                return resultado;

        }


      
     public static bool Verificar_ponto_dentro_retangulo ( float x, float y, float x_rect_min,  float x_rect_max   ,float y_rect_min,  float y_rect_max  ){

          return  !(  x  <  x_rect_min    ||  x> x_rect_max   ||   y < y_rect_min   ||  y> y_rect_max  );

     }


     public static void Verificar_ponto_dentro_retangulo_REF (  ref bool dentro ,  float x, float y, float x_rect_max,  float x_rect_min   ,float y_rect_max,  float y_rect_min  ){

          dentro = !(  x  <  x_rect_min    ||  x> x_rect_max   ||   y < y_rect_min   ||  y> y_rect_max  );

          return;
          
     }



    



    public static int Pegar_lado_colidido_retangulo(  float[] pontos_reta_entrada,  float[] pontos_lados_possiveis   , int point = 0 ){



          // Debug.Log("p1: " + pontos_lados_possiveis[ 0 ] + ", " + pontos_lados_possiveis[ 1 ] );
          // Debug.Log("p2: " + pontos_lados_possiveis[ 2 ] + ", " + pontos_lados_possiveis[ 3 ] );
          // Debug.Log("p3: " + pontos_lados_possiveis[ 4 ] + ", " + pontos_lados_possiveis[ 5 ] );
          // Debug.Log("p4: " + pontos_lados_possiveis[ 6 ] + ", " + pontos_lados_possiveis[ 7 ] );

        
          bool is_cross = false;

       
          for(  int  i = 0 ;   i <  4  ; i++  ){




               is_cross = Verificar_cross_retas(

                    i,

                    pontos_reta_entrada[0],
                    pontos_reta_entrada[1],
                    pontos_reta_entrada[2],
                    pontos_reta_entrada[3],

                    pontos_lados_possiveis[  (i * 2) ],
                    pontos_lados_possiveis[  (i * 2) + 1 ],

                    
                    pontos_lados_possiveis[  ( (i * 2  ) + 2 ) % 8],
                    pontos_lados_possiveis[  ( (i * 2  ) + 3 ) % 8]

               );

             
          
               if( is_cross) {  return i ; }


          }



          //Debug.Log("nao foi cross, point: " + point );


         throw new ArgumentException("não foi achado um lado com cross em Pegar_lado_colidido_retangulo");

          switch ( point ){

               case 1 : return 2;
               case 2 : return 2;
               case 3 : return 3;
               case 4 : return 1;

          }
        
         
     



           

    }



                                    //                           1   2                                                      3    4
    public static bool Verificar_cross_retas( int lado ,  float p_x_1  , float p_y_1,  float p_x_2  , float p_y_2   ,      float p_x_3  , float p_y_3,  float p_x_4  , float p_y_4     ){


      
      // if( (p_x_2 == p_x_3 ) || (p_x_2 == p_x_4)  ) return true;



    
     float PX = 
     
     ( (p_x_1  *  p_y_2   -  p_y_1 * p_x_2   ) * (p_x_3 - p_x_4)    -   (p_x_1 -p_x_2  ) * (   p_x_3 * p_y_4   -  p_y_3 * p_x_4 )  ) 

     / 

     (     ( p_x_1 - p_x_2  ) * (   p_y_3 - p_y_4  )  - ( p_y_1 - p_y_2 ) * ( p_x_3 - p_x_4 )   )  ;










     if(  ! float.IsFinite(PX) ){ return false; } 
     

     float PY =
      (  ( p_x_1  *  p_y_2   -  p_y_1 * p_x_2   ) * (p_y_3 - p_y_4)    -   (p_y_1 -p_y_2  ) * (   p_x_3 * p_y_4   -  p_y_3 * p_x_4 )  ) 
      / 
     (   ( p_x_1 - p_x_2  ) * (   p_y_3 - p_y_4  )  - ( p_y_1 - p_y_2 ) * ( p_x_3 - p_x_4 )   )  ;



  
        




     #if UNITY_WEBGL 





               //  Debug.Log("PX pre : " + PX);
               //  Debug.Log("PY pre : " + PY);



               // PX = Ajustar_webgl( PX );
               // PY = Ajustar_webgl( PY );

               // Debug.Log("PX: " + PX);
               // Debug.Log("new_PX: " + new_PX);

               // Debug.Log("X eh igual: " + ( new_PX == PX ) );


               // Debug.Log("PY: " + PY);
               // Debug.Log("new_PY: " + new_PY);
               // Debug.Log("Y eh igual: " + ( new_PY == PY ) );


               // float sign_save  = 1f;

               // float delta = 0f;

               // if( PX < 0 ) { sign_save = -1f; PX *= -1f; }

               // Debug.Log("PX: " + PX );
               // Debug.Log("sign: " + sign_save );

               // float p_save =    ( float ) ( int  ) PX;

               // delta = PX - p_save;
               // Debug.Log("delta_X: " + delta );

               // if( delta != 0f ) {

               //           if( (delta) > 0.99999f || (delta) < 0.00001f  ){ 

               //                     Debug.Log("deltaX: " + (PX - p_save));
               //                     Debug.Log("vai mudar PX");

               //                     if ( (delta) > 0.99999f ){ p_save += 1f ;}

               //                     Debug.Log("dentro if ");
               //                     Debug.Log("PX: " + PX );
               //                     Debug.Log("sign: " + sign_save );
               //                     PX = p_save;                    
                              
               //           }


               // } 


               // PX *= sign_save;



               // sign_save  = 1f;

               // if( PY < 0 ) { sign_save = -1f; PY *= -1f; }

               // Debug.Log("PY: " + PY );
               // Debug.Log("sign: " + sign_save );

               // p_save =    ( float ) ( int  ) PY;

               // delta = ( PY - p_save );

               // Debug.Log("delta_X: " + delta );

               // if( delta != 0f ) {

               //           if( (delta) > 0.99999f || (delta) < 0.00001f  ){ 

               //                     Debug.Log("deltaX: " + (PY - p_save));
               //                     Debug.Log("vai mudar PY");

               //                     if ( (delta) > 0.99999f ){ p_save += 1f ;}

               //                     Debug.Log("dentro if ");
               //                     Debug.Log("PY: " + PY );
               //                     Debug.Log("sign: " + sign_save );
               //                     PY = p_save;                    
                              
               //           }


               // } 


               // PY *= sign_save;



               
 
               


               // Debug.Log("PX pos : " + PX);
               // Debug.Log("PY pos : " + PY);

               // Debug.Log("------------");

       

     //  p_x_1 = MathF.Round( p_x_1, 0 );
     //  p_x_2 = MathF.Round( p_x_2, 0 );
     //  p_x_3 = MathF.Round( p_x_3, 0 );
     //  p_x_4 = MathF.Round( p_x_4, 0 );

     //  p_y_1 = MathF.Round( p_y_1, 0 );
     //  p_y_2 = MathF.Round( p_y_2, 0 );
     //  p_y_3 = MathF.Round( p_y_3, 0 );
     //  p_y_4 = MathF.Round( p_y_4, 0 );
      


     #endif 








     // Debug.Log("teste igual 1: " +  ((PX == p_x_3) && (PX == p_x_4)) );
     // Debug.Log("teste igual 2: " +   (    (PY ==  p_y_3)  &&   (PY == p_y_4)   ));
     // Debug.Log("teste igual 3: " +  ((PX == p_x_1) && (PX == p_x_2)) );
     // Debug.Log("teste igual 4: " +  (    (PY ==  p_y_1)  &&   (PY == p_y_2)   )  );



   
     // Debug.Log( "p_x_3: " + p_x_3 ) ; 
     // Debug.Log( "p_x_4: " + p_x_4 ) ; 

     
     // Debug.Log( "p_y_3: " + p_y_3 ) ; 
     // Debug.Log( "p_y_4: " + p_y_4 ) ; 
     



     //bool v1  = (       ( (PX < p_x_3) != (PX < p_x_4) )    ||     ((PX == p_x_3) || (PX == p_x_4))     )        &&              ((    (PY <  p_y_3)  !=   (PY < p_y_4)   )    ||     (    (PY ==  p_y_3)  ||   (PY == p_y_4)   )    ) ;

     bool v1_1 = ( (PX < p_x_3) != (PX < p_x_4) ) ;
     bool v1_2 = (    -0.1f  <   (PX - p_x_3 ) && (  (PX - p_x_3 ) < 0.1f   )      ||  ( PX == p_x_4 )) ;
     bool v1_3 = (    (PY <  p_y_3)  !=   (PY < p_y_4)   )    ;
     bool v1_4 =   (    (   -0.1f < (PY - p_y_3)  &&  (PY - p_y_3) < 0.1f     )     ||   (PY == p_y_4)   )  ;

     bool v1  = ( v1_1  ||  v1_2  ) &&  ( v1_3  ||  v1_4 ) ; 
     
   // Debug.Log( "v1 : " + v1 ) ; 

     

     // Debug.Log("v1_1 : " +   ( (PX < p_x_3) != (PX < p_x_4) )   );
     // Debug.Log("v1_2 : " +  ((PX == p_x_3) || (PX == p_x_4))    );
     // Debug.Log("v1_3 : " +  (    (PY <  p_y_3)  !=   (PY < p_y_4)   )   );
     // Debug.Log("v1_4 : " +    (    (PY ==  p_y_3)  ||   (PY == p_y_4)   )  );

     // Debug.Log("PY  : " + ( PY  ) ); 
     // Debug.Log("p_y_3 : " + ( p_y_3) );
 
     // Debug.Log("PY == p_y_3: " + ( PY == p_y_3 ));


     // Debug.Log("PY == -105f: " + ( PY == -105f ));
     // Debug.Log(" com floor PY == -105f: " + (  Math.Floor(  PY ) == -105f ));
     // Debug.Log("floor: " +  Math.Floor(  PY ) );


     // Debug.Log("floats.equals: " + float.Equals(  PY , p_y_3  )  );


     // Debug.Log("-105 == p_y_3: " + ( -105f == p_y_3 ));

     // Debug.Log("float: " + ( -105f == -105f ) ) ;
     // Debug.Log("int: " + ( -105 == -105 ) ) ;
     

   
// Debug.Log("__________");

     // Debug.Log( "p_x_1: " + p_x_1 ) ; 
     // Debug.Log( "p_x_2: " + p_x_2 ) ; 

     
     // Debug.Log( "p_y_1: " + p_y_1 ) ; 
     // Debug.Log( "p_y_2: " + p_y_2 ) ; 
     



     bool v2_1 =  ( (PX < p_x_1) != (PX < p_x_2) )   ;
     bool v2_2 =  ( (   (   -0.1f < (PX - p_x_1)  &&  (PX - p_x_1) < 0.1f     )        ) || (PX == p_x_2) )   ;
     bool v2_3 = (    (PY <  p_y_1)  !=   (PY < p_y_2)   )  ; 
     bool v2_4 =  (  (   -0.1f < (PY - p_y_1)   &&  (PY - p_y_1)  < 0.1f     )     ||   (PY == p_y_2)   ) ; 

     bool v2 = (  v2_1   ||  v2_2 )    &&     (  v2_3  ||  v2_4   ) ;




     bool OLD =  ( ( PY == p_y_3 ) || ( PY == p_y_4 ) ) ;

     bool NEW =  ( 
                    (   -0.1f < (PY - p_y_3)   &&  (PY - p_y_3)  < 0.1f     )   

                    ||   
                    
                    (   -0.1f < (PY - p_y_4)   &&  (PY - p_y_4)  < 0.1f     )  
                ) ; 




     // Debug.Log( "v2 : " + v2 ) ;


     // Debug.Log( "v2_1 : " + ( (PX < p_x_1) != (PX < p_x_2) ) ) ;
     // Debug.Log( "v2_2 : " + ( (PX == p_x_1) || (PX == p_x_2) ) ) ;

     // Debug.Log("PX: " + PX ) ;
     // Debug.Log("p_x_1: "  + p_x_1 ) ;
     // Debug.Log("PX == p_x_1 : " + ( PX == p_x_1 ) );



     // Debug.Log( "v2_3 : " + (    (PY <  p_y_1)  !=   (PY < p_y_2)   ) ) ;
     // Debug.Log( "v2_4 : " + (    (PY ==  p_y_1)  ||   (PY == p_y_2)   )    ) ;
     

    
    
     if(  v1 && v2     ) {

          
     //      Debug.Log("lado cross: " + lado);

     //     Debug.Log("PX: " + PX );
     //      Debug.Log("PX_cima: " +  ( (p_x_1  *  p_y_2   -  p_y_1 * p_x_2   ) * (p_x_3 - p_x_4)    -   (p_x_1 -p_x_2  ) * (   p_x_3 * p_y_4   -  p_y_3 * p_x_4 )  )  );
     //      Debug.Log("PX_baixo: " + (     ( p_x_1 - p_x_2  ) * (   p_y_3 - p_y_4  )  - ( p_y_1 - p_y_2 ) * ( p_x_3 - p_x_4 )   )   );

     //      Debug.Log("PY: " + PY );
     //      Debug.Log("PY_cima: " +  ( (p_x_1  *  p_y_2   -  p_y_1 * p_x_2   ) * (p_y_3 - p_y_4)    -   (p_y_1 -p_y_2  ) * (   p_x_3 * p_y_4   -  p_y_3 * p_x_4 )  )  );
     //      Debug.Log("PY_baixo: " +  (   ( p_x_1 - p_x_2  ) * (   p_y_3 - p_y_4  )  - ( p_y_1 - p_y_2 ) * ( p_x_3 - p_x_4 )   ) );

     //      Debug.Log("p_x_1: " + p_x_1 );
     //      Debug.Log("p_y_1: " + p_y_1 );

     //      Debug.Log("p_x_2: " + p_x_2 );
     //      Debug.Log("p_y_2: " + p_y_2 );




     //      Debug.Log("p_x_3: " + p_x_3 );
     //      Debug.Log("p_y_3: " + p_y_3 );

     //      Debug.Log("p_x_4: " + p_x_4 );
     //      Debug.Log("p_y_4: " + p_y_4 );




          return true;


     } 

    // Debug.Log("lado " + lado + " nao passou");



     return false;


     
     // float a  =  (((p_x_3  -  PX) / (  p_y_3 - PY  ) ) - (   (PX - p_x_4) / (  PY-p_y_4 )  )   ) ;

     // float dif  = 0.05f;

     //      Debug.Log("teste: " + ((p_x_3  -  PX) / (  p_y_3 - PY  )));

      
     //      Debug.Log( "a: " + a);

     //      Debug.Log("PX: " + PX );
     //      Debug.Log("PX_cima: " +  ( (p_x_1  *  p_y_2   -  p_y_1 * p_x_2   ) * (p_x_3 - p_x_4)    -   (p_x_1 -p_x_2  ) * (   p_x_3 * p_y_4   -  p_y_3 * p_x_4 )  )  );
     //      Debug.Log("PX_baixo: " + (     ( p_x_1 - p_x_2  ) * (   p_y_3 - p_y_4  )  - ( p_y_1 - p_y_2 ) * ( p_x_3 - p_x_4 )   )   );

     //      Debug.Log("PY: " + PY );
     //      Debug.Log("PY_cima: " +  ( (p_x_1  *  p_y_2   -  p_y_1 * p_x_2   ) * (p_y_3 - p_y_4)    -   (p_y_1 -p_y_2  ) * (   p_x_3 * p_y_4   -  p_y_3 * p_x_4 )  )  );
     //      Debug.Log("PY_baixo: " +  (   ( p_x_1 - p_x_2  ) * (   p_y_3 - p_y_4  )  - ( p_y_1 - p_y_2 ) * ( p_x_3 - p_x_4 )   ) );

     //      Debug.Log("p_x_1: " + p_x_1 );
     //      Debug.Log("p_y_1: " + p_y_1 );

     //      Debug.Log("p_x_2: " + p_x_2 );
     //      Debug.Log("p_y_2: " + p_y_2 );




     //      Debug.Log("p_x_3: " + p_x_3 );
     //      Debug.Log("p_y_3: " + p_y_3 );

     //      Debug.Log("p_x_4: " + p_x_4 );
     //      Debug.Log("p_y_4: " + p_y_4 );

       
          

     //      Debug.Log("lado: " + lado);
 
     // if(     a * a    <  dif * dif   ){

     //      Debug.Log( "a: " + a);

     //      Debug.Log("lado: " + lado);
     //      return true;
     // }
     




     


//     bool resultado = false; 

//     if( Verificar_ponto_passa_reta_flip( PX , PY , p_x_1, p_y_1,  p_x_3, p_y_3 )  ) resultado = !resultado;
//     if( Verificar_ponto_passa_reta_flip( PX , PY , p_x_3, p_y_3,  p_x_2, p_y_2  )  ) resultado = !resultado;
//     if( Verificar_ponto_passa_reta_flip( PX , PY ,  p_x_2, p_y_2,   p_x_4, p_y_4 )  ) resultado = !resultado;
//     if( Verificar_ponto_passa_reta_flip( PX , PY , p_x_4, p_y_4 ,  p_x_1, p_y_1  )  ) resultado = !resultado;

   
//    return resultado;

    

  }



     public static float Ajustar_webgl( float _numero ){

              // Debug.Log("numero que veio ajustar: " + _numero );

               float sign = 1f ;
               if( _numero < 0f ){  _numero *= -1f ; sign = -1f; }
               _numero = MathF.Round( _numero, 0 ) ;
               _numero *= sign;
               //Debug.Log("novo numero dentro ajustar: " + _numero );

               return _numero;

     }






public static  bool Verificar_ponto_passa_reta_flip(  float ponto_teste_x    , float ponto_teste_y  ,      float p_x_1    ,  float p_y_1    ,   float p_x_2    ,  float p_y_2 ){

     float ponto_x_final = ((  ponto_teste_y - p_y_2  ) * (  p_x_2 - p_x_1 ) / (p_y_2 - p_y_1)) + (p_x_2);
     // Debug.Log("PONTO FINAL: " + ponto_x_final);
     // Debug.Log("a: " + ponto_teste_x + " || b: " + ponto_x_final);

     if(     ponto_x_final > ponto_teste_x   &&       (    (ponto_teste_y <=  p_y_1)  !=   (ponto_teste_y <= p_y_2)   )    )  return true;

     return false;
          

    }

  
  public static int Calcular_ponto_entrada_retangulo(  float[]  _obj_1_project_pontos  ,   float[] _obj_2_project_pontos ){

 
 bool  colisao = false;


  for(   int i =0 ;  i  < 8  ;  i = i + 2  ){


              colisao    =    !(  _obj_1_project_pontos[i] < _obj_2_project_pontos[0]      ||       _obj_1_project_pontos[i]   >  _obj_2_project_pontos[2]     ||    _obj_1_project_pontos[i + 1]    >   _obj_2_project_pontos[1]    ||   _obj_1_project_pontos[  i+ 1]     <  _obj_2_project_pontos[5]  );
 
             
              if(colisao){

                
                return (i / 2 )+ 1 ;
                
                }


            }



         for(   int k =0 ;  k  < 8  ;  k = k + 2  ) {


              colisao    =    !(  _obj_2_project_pontos[k] < _obj_1_project_pontos[0]      ||       _obj_2_project_pontos[k]   >  _obj_1_project_pontos[2]     ||    _obj_2_project_pontos[k + 1]    >   _obj_1_project_pontos[1]    ||   _obj_2_project_pontos[  k+ 1]     <  _obj_1_project_pontos[5]  );

              if(colisao){
               
                return  -(  (k / 2) + 1 );
                
                }


            }


            throw new ArgumentException("nao foi achado ponto");


            return 0;





  }



    // public static bool Verificar_colisao_retangulos(   Fisica_objeto  _obj_1  ,    Fisica_objeto _obj_2  ){
    public static bool Verificar_colisao_retangulos(   float[]  _obj_1_project_pontos  ,    float[] _obj_2_project_pontos  ){


         // retorno true se tem pelo menos 1 ponto dentro um do outro, calculei os 2 para nao ter a posibilidade de um pequeno entrar em um grande e calcular a partir do grande

         
         bool colisao = false; 

         for(   int i =0 ;  i  < 8  ;  i = i + 2  ){


              colisao    =    !(  _obj_1_project_pontos[i] < _obj_2_project_pontos[0]      ||       _obj_1_project_pontos[i]   >  _obj_2_project_pontos[2]     ||    _obj_1_project_pontos[i + 1]    >   _obj_2_project_pontos[1]    ||   _obj_1_project_pontos[  i+ 1]     <  _obj_2_project_pontos[5]  );
 
             
              if(colisao){

               
                return true;}


            }



          
         for(   int k =0 ;  k  < 8  ;  k = k + 2  ){


              colisao    =    !(  _obj_2_project_pontos[k] < _obj_1_project_pontos[0]      ||       _obj_2_project_pontos[k]   >  _obj_1_project_pontos[2]     ||    _obj_2_project_pontos[k + 1]    >   _obj_1_project_pontos[1]    ||   _obj_2_project_pontos[  k+ 1]     <  _obj_1_project_pontos[5]  );

              if(colisao){ return true;}


            }

         return false;

}












 public static bool Verificar_colisao_retangulos_com_variacao_mov(   float[]  _obj_1  , float _var_1_x , float _var_1_y,    float[] _obj_2 ,  float _var_2_x = 0f  ,  float _var_2_y = 0f ){


         // retorno true se tem pelo menos 1 ponto dentro um do outro, calculei os 2 para nao ter a posibilidade de um pequeno entrar em um grande e calcular a partir do grande




        
         
         bool colisao = false; 

         for(   int i =0 ;  i  < 8  ;  i = i + 2  ){

          

                 
              colisao    =    
              
              
              !(     (  _obj_1[i] + _var_1_x      < _obj_2[0] +_var_2_x   )  
              
              ||       (_obj_1[i] + _var_1_x  >  _obj_2[2] + _var_2_x   ) 
              
              ||   ( _obj_1[i + 1] + _var_1_y   >   _obj_2[1] + _var_2_y ) 

              ||   (_obj_1[  i+ 1]  + _var_1_y    <  _obj_2[5] + _var_2_y  )  );
 
             
              if(colisao){

               
                return true;}


            }



          
         for(   int k =0 ;  k  < 8  ;  k = k + 2  ){


              colisao    =   
                 !( ( _obj_2[k]  +  _var_2_x  < _obj_1[0] + _var_1_x   )

                 ||     (  _obj_2[k] + _var_2_x  >  _obj_1[2] + _var_1_x   )
                 
                 ||   ( _obj_2[k + 1]  + _var_2_y  >   _obj_1[1] + _var_1_y  )  
                 
                 ||  ( _obj_2[  k+ 1]  +_var_2_y   <  _obj_1[5]  + _var_1_y ) );

              if(colisao){ return true;}


            }

         return false;

}










    public static float[] Transformar_dados_em_pontos(   float[] _position   ,   float[] _tamanho   ){

       float width = _tamanho[0];
       float height = _tamanho[1];

       float pX = _position[0];
       float pY = _position[1];

     

      /* 
           0------1
           |      |
           |      |
           3------2
      */

       float[] final = new float[8];

         final[0] = pX - (  width / 2 );
         
         final[1] = pY + (  height / 2 );

         
         final[2] = pX + (  width / 2 );
         final[3] = pY + (  height / 2 );

         
         final[4] = pX + (  width / 2 );
         final[5] = pY - (  height / 2 );

         
         final[6] = pX - (  width / 2 );
         final[7] = pY - (  height / 2 );



         return final;

     

}





// public static T[] Aumentar_numero_arr<T> (T[] arr_inicial , int _novo_length){
          
//           T[] novo_arr = new T[_novo_length];
            
//             for(   int i = 0;   i < _novo_length  ;i++   ){

//             }



//      return arr_inicial;




// }







}


