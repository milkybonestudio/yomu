using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Png_decoder;
using Unity.Collections;
using UnityEngine.SceneManagement;


public static class Teste_escopo {


        public static bool ativado = false;


        public static GameObject teste_body;
        public static Image imagem;
        public static Rigidbody2D   body ;

        public static Animator anim ;

        public static int  run_1_HASH = 0;



        public static void Testar(){

                if( ! ( ativado ) ){ return; }
                // iniciar 


               /*

                    testes: 


                    - dia e noite( com slot extras  + 1 tem ja no array + 1 item novo  ): 
                         - acrescentar adicionar 
                         - acrescentar subtrair
                         - remover adicionar 
                         - remover subtrair
                    
                    - dia e noite( com slot extras  + 1 tem ja no array + 0 item novo  ): 
                         - acrescentar adicionar 
                         - acrescentar subtrair
                         - remover adicionar 
                         - remover subtrair

                    - dia e noite( com slot extras  + 0 tem ja no array + 1 item novo  ): 
                         - acrescentar adicionar 
                         - acrescentar subtrair
                         - remover adicionar 
                         - remover subtrair

                    - dia e noite( com slot extras  + 0 tem ja no array + 0 item novo  ): 
                         - acrescentar adicionar  
                         - acrescentar subtrair
                         - remover adicionar 
                         - remover subtrair

                    - dia e noite( com slot extras  + 2 tem ja no array + 2 item novo  ): 
                         - acrescentar adicionar 
                         - acrescentar subtrair
                         - remover adicionar 
                         - remover subtrair



                    - dia e noite( sem slot extras  + 1 tem ja no array + 1 item novo  ): 
                         - acrescentar adicionar ( - !!!OK!!! - )
                         - acrescentar subtrair
                                   ( sem slot extras  + 1 tem no array + 1 nao tem  ): 
                         - remover adicionar (  )
                         - remover subtrair
                    
                    - dia e noite( sem slot extras  + 1 tem ja no array + 0 item novo  ): 
                         - acrescentar adicionar ( - !!!OK!!! - )
                         - acrescentar subtrair

                                 ( sem slot extras  + 1 tem no array + 0 nao tem  ): 
                         - remover adicionar ( - !!!OK!!! - )
                         - remover subtrair

                    - dia e noite( sem slot extras  + 0 tem ja no array + 1 item novo  ): 
                         - acrescentar adicionar ( - !!!OK!!! - )
                         - acrescentar subtrair 

                                   ( sem slot extras  + 0 tem no array + 1 nao tem  ): 
                         - remover adicionar ( - !!!OK!!! - )
                         - remover subtrair

                    - dia e noite( sem slot extras  + 0 tem ja no array + 0 item novo  ): 
                         - acrescentar adicionar ( - !!!OK!!! - )
                         - acrescentar subtrair

                                   ( sem slot extras  + 0 tem no array + 0 nao tem  ): 
                         - remover adicionar ( - !!!OK!!! - )
                         - remover subtrair

                    - dia e noite( sem slot extras  + 2 tem ja no array + 2 item novo  ): 
                         - acrescentar adicionar ( - !!!OK!!! - )
                         - acrescentar subtrair

                                   ( sem slot extras  + 2 tem no array + 2 nao tem  ): 
                         - remover adicionar ( - !!!OK!!! - )
                         - remover subtrair



               */




               byte[][] interativos_para_remover = new byte[ 2 ][]{

                    new byte[]{ 5 },
                    new byte[]{ 4 }

               };

               byte[][] interativos_para_remover_1_E_0 = new byte[ 2 ][]{

                    new byte[]{ 1 },
                    new byte[]{ 10 }

               };

               byte[][] interativos_para_remover_0_E_0 = new byte[ 2 ][]{

                    new byte[]{  },
                    new byte[]{  }

               };

               byte[][] interativos_para_remover_1_E_1 = new byte[ 2 ][]{

                    new byte[]{ 1, 200 },
                    new byte[]{ 10, 200 }

               };


               byte[][] interativos_para_remover_0_E_1 = new byte[ 2 ][]{

                    new byte[]{ 150 },
                    new byte[]{ 150 }

               };


               byte[][] interativos_para_adicionar_2_E_2 = new byte[ 2 ][]{

                    new byte[]{ 3,2,6,7, 8 },
                    new byte[]{ 10,20,123,244 }

               };

               byte[][] interativos_para_adicionar_TODOS = new byte[ 5 ][]{

                    new byte[]{ 69 },
                    new byte[]{ 69 },
                    new byte[]{ 69 },
                    new byte[]{ 69 },
                    new byte[]{ 69 }
                    

               };

               // dia e noite

               // ** AINDA TEM QUE TESTAR: 
               // passar de unitario => dia e noite 

               // *** VER SE REDUZIR FUNCIONA
               

               Ponto ponto = new Ponto();
               ponto.ponto_ativo.interativos_por_periodo_para_adicionar = new byte[][]{

               
                         new byte[]{ 1  ,  2, 0, 0  },
                         new byte[]{ 10 , 20, 0, 0  }

                         
               };

               // int a = 10;
               // ( new Controlador_interativos() ).Acrescentar_interativos_para_adicionar( p , ( int ) Metodo_para_alocar_dados_periodo.todos_os_periodos, interativos_para_adicionar_TODOS  );
               // a = 10;
     

               // a = 11;

               // 99 => 10 milhoes

               int valor_final = 0;

               int[] levels_xp = new int[  99 ];
               string[] txtS = new string[ 99 ];



               for( int level = 1 ; level < 99 ; level++ ){
                    

                    // switch( (level / 10 ) ) {

                    //      case 0 : 

                    // }


                    int valor = 0;

                    int level_quadrado = level * level;
                    int valor_fixo = 176;

                    valor += ( 8 * ( level_quadrado )  )  +  ( level * 7 )  + valor_fixo ; 
                    valor += ( 4 * ( level_quadrado )  - ( 4 *20 *20)   )  * ( level / 20 )  ; 
                    
                    valor += ( 15  * ( level_quadrado )  - ( 15 *50 * 50 )  )  *  ( level / 50 )  ; 
                    valor += ( 40  * ( level_quadrado )  - ( 40 *60 * 60 )  )  *  ( level / 60 )  ; 
                    valor += ( 45  * ( level_quadrado )  - ( 45 *70 * 70 )  )  *  ( level / 70 )  ; 
                    valor += ( 280 * ( level_quadrado )  - ( 275 *85 *85 )  )  *  ( level / 85 )  ; 
                    valor += ( 375 * ( level_quadrado )  - ( 375 *90 *90 )  )  *  ( level / 90 )  ; 

                    valor += ( 600 * ( level_quadrado )  - ( 600 *94 *94 )  )  *  ( level / 94 )  ; 
                    valor += ( 15_000 * ( (level - 94 ) * ( level - 94 ) * ( level - 94 ) * ( level - 94 )  ) * ( level / 94 ) ) ; 
                    valor += (  73_999  )  * ( level / 98 )  ;

                    levels_xp[ level ] = valor;


                    valor_final += valor;

                    txtS[ level ] = $"level { level }: { valor_final.ToString( "#,0" ).Replace( ".", "_" ) }";


               }

               Geral.Salvar_string( txtS );

               Debug.Log( $" valor final : { valor_final.ToString( "#,0" ).Replace( ".", "_" )}" );




               return;






        }


        public static void Update(){



         


        }



}