using UnityEngine;
using System;

public static class Polygon {



        public static bool Check_point_inside( Vector2[] _poligono, Vector2 _off_set, Vector2 _ponto ){


                if( _poligono == null )
                    { Console.Log( "poligonos estavam null" ); return false; }

                // --- AJUST VECTOR

                Console.Log( _off_set );
                Console.Log( _ponto );

                // ** move ponto para nao precisar mover pontos_poligono[] 
                _ponto -=  _off_set;


                // Console.Log( "alp: " +  ( 1080f / Screen.height ) );

                // Console.Log( "offset: " + _off_set );
                // Console.Log( $"Ponto principal: { _ponto }" );


                Console.Log( "poligonos.Length: " + _poligono.Length );
                for( int  i = 0 ; i < _poligono.Length ; i++ ){

                    Console.Log( $"ponto { i }: { _poligono[ i ] }" );
                }

                
                bool resultado = false;                
                
                for(   int ponto_index = 0 ; ponto_index < _poligono.Length  ; ponto_index ++){

                        Vector2 ponto_1 = _poligono[ ponto_index ];
                        Vector2 ponto_2 = _poligono[ ( ponto_index + 1 ) % _poligono.Length ];

                        if( (  _ponto.y < ponto_1.y  ) == ( _ponto.y  < ponto_2.y  ) )
                            { continue; }
                        
                        if( (  _ponto.x > ( ( _ponto.y - ponto_1.y   ) * ( ponto_2.x - ponto_1.x ) / (   ponto_2.y  - ponto_1.y ) ) + ponto_1.x  ) ) 
                            { continue; }

                        resultado = !!!( resultado );

                        continue;

                }

                // Console.Log( "resultado: " + resultado );

                return resultado;

        }



        public static bool Check_point_inside( float[] _ponto , float[] _poligono ){

                if( _poligono == null )
                    { return false; }

                if( ( _poligono.Length % 2 ) != 0 )
                    { throw new ArgumentException("fora do padrao"); }
                

                bool resultado = false;
                int numero_pontos = _poligono.Length / 2;
                
            
                int j = _poligono.Length;
                int i = 0;
                int k = 1;
                                
                for(   int cont = 0 ; cont < numero_pontos - 1 ; cont ++){

                        if(    (  _ponto[1] < _poligono[k] )    !=     (_ponto[1]<(_poligono[k + 2]))    &&     (_ponto[0]<   ((_ponto[1]+( - _poligono[k] ))*(_poligono[i+2]-_poligono[i])/(   _poligono[k+2]  - _poligono[k]     ))+(_poligono[i]))       )  
                            { resultado =! resultado; }    
                        
                        i = i+ 2;
                        k = k + 2 ; 
                        continue;

                }

                return resultado;

        }





}