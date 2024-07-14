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


        public static bool ativado = true;


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
               

               Ponto p = new Ponto();
               p.interativos_por_periodo_para_adicionar_PONTOS = new byte[][][]{

                         new byte[][]{

                              new byte[]{ 1 , 2, 0, 0 },
                              new byte[]{ 10 , 20, 0, 0 }

                         } 
                         
               };

               int a = 10;
               ( new Controlador_interativos() ).Acrescentar_interativos_para_adicionar( p , ( int ) Metodo_para_alocar_dados_periodo.todos_os_periodos, interativos_para_adicionar_TODOS  );
               a = 10;
     
               a = 11;

               return;






        }


        public static void Update(){



         


        }



}