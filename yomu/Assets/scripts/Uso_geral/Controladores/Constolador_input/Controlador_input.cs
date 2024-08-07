using UnityEngine;
using System;
using System.Runtime.InteropServices;



//   se trocar a strig do input para ter menos texto reduz o tempo em 50% com 1 char

/*
por hora vair ser usado somente para a ArrowUp e (X)
*/


public static class Controlador_input {

    // ** virtual
    public static Vector2 posicao_mouse;


    public static int[] analog_left_houver = new int[ 4 ] ;
    public static int[] analog_right_houver = new int[ 4 ] ;
    public static Tipo_teclado tipo_teclado  =  Tipo_teclado.normal;


    public static void Mudar_input ( ){

        Req_mudar_input _req_input = Dados_blocos.req_mudar_input;
        if(  _req_input == null ) { return ; }



        bool novo_ativar_movimentacao_mouse = _req_input.ativar_movimentacao_mouse ;
        Cor_cursor cor_cursor = _req_input.cor_cursor ;
        Tipo_teclado novo_tipo_teclado = _req_input.tipo_teclado ;


        tipo_teclado = novo_tipo_teclado ;
        ativar_movimentacao_mouse = novo_ativar_movimentacao_mouse;

        Controlador_cursor.Pegar_instancia().Mudar_cursor( cor_cursor ) ;


        Dados_blocos.req_mudar_input = null;


    }
    



    public static void Update(){


        Update_houver();
        Update_mouse();

        return;



    }

    public static bool ativar_movimentacao_mouse = true;

    public static void Update_mouse(){

        posicao_mouse = ( ( Vector2 ) Input.mousePosition ) * ( 1080f / Screen.height );

    }


    public static void _Update_mouse(){
        
        if( ativar_movimentacao_mouse ){


            float direcao_v = Input.GetAxis( "Left_analog Vertical" );
            float direcao_h = Input.GetAxis( "Left_analog Horizontal" );
            
            if( Input.GetKey(KeyCode.RightArrow) ) direcao_h +=  1f;
            if( Input.GetKey(KeyCode.LeftArrow) ) direcao_h -= 1f;

            if( Input.GetKey(KeyCode.UpArrow) ) direcao_v -= 1f;
            if( Input.GetKey(KeyCode.DownArrow) ) direcao_v +=  1f;


        


            float dir_sqrt = Mathf.Sqrt(  (direcao_h * direcao_h) + (direcao_v * direcao_v));

            if( dir_sqrt > 0 ) {

                    float speed = 15f;

                    float direcao_v_abs = direcao_v;
                    if(direcao_v_abs < 0) {direcao_v_abs = -direcao_v_abs;}

                    
                    float direcao_h_abs = direcao_h;
                    if(direcao_h_abs < 0){ direcao_h_abs = -direcao_h_abs;}

                    float mod_speed = direcao_h_abs;
                    if(direcao_h_abs < direcao_v_abs ) { mod_speed = direcao_v_abs;}

                    //Debug.Log("mov_pre: " + mod_speed);

                    mod_speed = mod_speed * mod_speed; 

                   // Debug.Log("mov_pos: " + mod_speed);

                    
                    float final_v_float =  (speed *  mod_speed )   *   (   direcao_v  /  dir_sqrt  );
                    float final_h_float =  (speed  *  mod_speed )   *   (   direcao_h  /  dir_sqrt  );
                
           

                    int final_h = (int) final_h_float;
                    int final_v = (int) final_v_float;


                    // Debug.Log("mod_speed:" + mod_speed);

                    // Debug.Log("float_v: " + final_v_float);
                    // Debug.Log("int_v: " + final_v);

                    // Debug.Log("float_h: " + final_h_float);
                    // Debug.Log("int_h: " + final_h);


                    Mover_mouse(  final_h ,  final_v );


            }


            


            // if(Get(Key_code.left_arrow)){

            //     Mover_mouse(-4, 0);
                
            //     Debug.Log("left");

            // }

            // if(Get(Key_code.right_arrow)){

            //     Mover_mouse(4, 0);
            //     Debug.Log("right");
                
            // }

            // if(Get(Key_code.up_arrow)){

            //     Mover_mouse(0, -4);
            //     Debug.Log("up");
                
            // }

            // if(Get(Key_code.down_arrow)){

            //     Mover_mouse(0, 4);
            //     Debug.Log("down");
                
            // }



        }


    }


    


    public static void Update_houver(){

        ///  tem que ser chamada antes das checagens, para ter o seguinte padrao:
        /*
        *     true + 0 => down = true
        *     true + 1 =>  houver = true
        *     false + 1 => up = true
        */
        // Debug.Log(analog_right_houver [ 2 ]);
        // Debug.Log(analog_right_houver [ 3 ]);
        
                // Debug.Log("Horizontal: " + Input.GetAxis("Right_analog Horizontal"));
                // Debug.Log("Vertical: " + Input.GetAxis("Right_analog Vertical"));


        if( Input.GetAxis("Left_analog Horizontal") == -1f ) { analog_left_houver [ 0 ] = 1;} else { analog_left_houver [ 0 ] = 0;}
        if( Input.GetAxis("Left_analog Horizontal") == 1f ) { analog_left_houver [ 1 ] = 1;} else { analog_left_houver [ 1 ] = 0;}
        if( Input.GetAxis("Left_analog Vertical") == -1f ) { analog_left_houver [ 2 ] = 1;} else { analog_left_houver [ 2 ] = 0;}
        if( Input.GetAxis("Left_analog Vertical") == 1f ) { analog_left_houver [ 3 ] = 1;} else { analog_left_houver [ 3 ] = 0;}

        if( Input.GetAxis("Right_analog Horizontal") == -1f ) { analog_right_houver [ 0 ] = 1;} else { analog_right_houver [ 0 ] = 0;}
        if( Input.GetAxis("Right_analog Horizontal") == 1f ) { analog_right_houver [ 1 ] = 1;} else { analog_right_houver [ 1 ] = 0;}
        if( Input.GetAxis("Right_analog Vertical") == -1f ) { analog_right_houver [ 2 ] = 1;}else { analog_right_houver [ 2 ] = 0;} 
        if( Input.GetAxis("Right_analog Vertical") == 1f ) { analog_right_houver [ 3 ] = 1;}else { analog_right_houver [ 3 ] = 0;} 



    }





    public static bool Get_down(Key_code _key){ return Verificar_key(Tipo_get_key.down, _key);}
    public static bool Get_up(Key_code _key){ return Verificar_key(Tipo_get_key.up, _key);}
    public static bool Get(Key_code _key){ return Verificar_key(Tipo_get_key.houver, _key);}


    public static bool Verificar_key(Tipo_get_key _tipo, Key_code _key){

        switch(_key){

            case Key_code.q: return Lidar_q(_tipo);
            case Key_code.w: return Lidar_w(_tipo);
            case Key_code.e: return Lidar_e(_tipo);
            case Key_code.r: return Lidar_r(_tipo);

            case Key_code.left_arrow: return Lidar_left_arrow(_tipo);
            case Key_code.right_arrow: return Lidar_right_arrow(_tipo);
            case Key_code.up_arrow: return Lidar_up_arrow(_tipo);
            case Key_code.down_arrow: return Lidar_down_arrow(_tipo);

            ///     numpad
            case Key_code.left_mov: return Lidar_left_mov(_tipo);
            case Key_code.right_mov: return Lidar_right_mov(_tipo);
            case Key_code.up_mov: return Lidar_up_mov(_tipo);
            case Key_code.down_mov: return Lidar_down_mov(_tipo);

            case Key_code.mouse_right: return Lidar_mouse_right(_tipo); 
            case Key_code.mouse_left: return Lidar_mouse_left(_tipo);

            ///  fn
            case Key_code.space: return Lidar_space(_tipo) ;
            case Key_code.esc: return Lidar_esc(_tipo) ;
            


        
        }

        return false;


    }


    
    public static bool Lidar_space(Tipo_get_key _tipo){

        
        if(_tipo == Tipo_get_key.up){

            if(Input.GetKeyUp(KeyCode.Space)){ return true;}
            if(Input.GetKeyUp(KeyCode.Joystick1Button3)){ return true;}

        } else
        if(_tipo == Tipo_get_key.down){


            if(Input.GetKeyDown(KeyCode.Space)){ return true;}
            if(Input.GetKeyDown(KeyCode.Joystick1Button3)){ return true;}

        } else 
        if(_tipo == Tipo_get_key.houver){

            if(Input.GetKey(KeyCode.Space)){ return true;}
            if(Input.GetKey(KeyCode.Joystick1Button3)){ return true;}

        }

        return false;



    }





    
    public static bool Lidar_esc ( Tipo_get_key _tipo ){

        
        if(_tipo == Tipo_get_key.up){

            if(Input.GetKeyUp( KeyCode.Escape )){ return true;}
            

        } else
        if(_tipo == Tipo_get_key.down){


            if(Input.GetKeyDown(KeyCode.Escape)){ return true;}
            

        } else 
        if(_tipo == Tipo_get_key.houver){

            if(Input.GetKey( KeyCode.Escape )){ return true;}

        }

        return false;



    }








    public static bool Lidar_mouse_right(Tipo_get_key _tipo){



        if(tipo_teclado == Tipo_teclado.normal){



        }


        
        if(_tipo == Tipo_get_key.up){

            if(Input.GetMouseButtonUp(1)) {return true;}
            if(Input.GetKeyUp(KeyCode.Joystick1Button3)){ return true;}

        } else 
        if(_tipo == Tipo_get_key.down){

            if(Input.GetMouseButtonDown(1)) {return true;}
            if(Input.GetKeyDown(KeyCode.Joystick1Button3)){ return true;}

        } else
        if(_tipo == Tipo_get_key.houver){

            if(Input.GetMouseButton(1)) {return true;}
            if(Input.GetKey(KeyCode.Joystick1Button3)){ return true;}
            
        }


        return false;



    }

    
    public static bool Lidar_mouse_left(Tipo_get_key _tipo){




        if(tipo_teclado == Tipo_teclado.normal){



        }

        
        if(_tipo == Tipo_get_key.up){

            

            if(Input.GetMouseButtonUp(0)) {return true;}
            if(Input.GetKeyUp(KeyCode.Joystick1Button2)){ return true;}

        } else
        if(_tipo == Tipo_get_key.down){



            

            if(Input.GetMouseButtonDown(0)) {return true;}
            if(Input.GetKeyDown(KeyCode.Joystick1Button2)){ return true;}

        } else
        if(_tipo == Tipo_get_key.houver){

            if(Input.GetMouseButton(0)) {return true;}
            if(Input.GetKey(KeyCode.Joystick1Button2)){ return true;}
            
        }

        return false;

    }


    public static bool Lidar_q (Tipo_get_key _tipo){

        if(_tipo == Tipo_get_key.up){}
        if(_tipo == Tipo_get_key.down){}
        if(_tipo == Tipo_get_key.houver){}

        if(Input.GetKeyDown(KeyCode.Q)) {return true;}
        if(Input.GetKeyDown(KeyCode.Joystick1Button3)){ return true;}
        
        return false;

    }


    
    public static bool Lidar_w (Tipo_get_key _tipo){

        if(_tipo == Tipo_get_key.up){}
        if(_tipo == Tipo_get_key.down){}
        if(_tipo == Tipo_get_key.houver){}

        if(Input.GetKeyDown(KeyCode.W)) {return true;}
        if(Input.GetKeyDown(KeyCode.Joystick1Button0)){ return true;}
        return false;


    }




    
    public static bool Lidar_e (Tipo_get_key _tipo){

        if(_tipo == Tipo_get_key.up){}
        if(_tipo == Tipo_get_key.down){}
        if(_tipo == Tipo_get_key.houver){}

        if(Input.GetKeyDown(KeyCode.E)) {return true;}
        if(Input.GetKeyDown(KeyCode.Joystick1Button1)){ return true;}
        return false;


    }




    
    public static bool Lidar_r (Tipo_get_key _tipo){

        if(_tipo == Tipo_get_key.up){}
        if(_tipo == Tipo_get_key.down){}
        if(_tipo == Tipo_get_key.houver){}

        if(Input.GetKeyDown(KeyCode.R)) {return true;}
        if(Input.GetKeyDown(KeyCode.Joystick1Button5)){ return true;}
        return false;


    }








   public static bool Lidar_left_arrow (Tipo_get_key _tipo){


    

        if(_tipo == Tipo_get_key.down){

            if(Input.GetKeyDown(KeyCode.LeftArrow)) {return true;}
            if(  Input.GetAxis("Left_analog Horizontal") < -0.8f && analog_left_houver[0] == 0 ){return true;}
            return false;
            
        } 
        if(_tipo == Tipo_get_key.houver){

            if(Input.GetKey(KeyCode.LeftArrow)) {return true;}
            if(  Input.GetAxis("Left_analog Horizontal") < -0.8f ){return true;}
            return false;

        } 
        if(_tipo == Tipo_get_key.up){

            if(Input.GetKeyDown(KeyCode.LeftArrow)) {return true;}
            if(  Input.GetAxis("Left_analog Horizontal") > 0.8f && analog_left_houver[0] == 1 ){return true;}
            return false;
        }

        
        return false;

    }


   public static bool Lidar_right_arrow (Tipo_get_key _tipo){

        if(_tipo == Tipo_get_key.down){

            if(Input.GetKeyDown(KeyCode.RightArrow)) {return true;}
            if(  Input.GetAxis("Left_analog Horizontal") > 0.8f && analog_left_houver[1] == 0 ){return true;}
            return false;
            
        } 
        if(_tipo == Tipo_get_key.houver){

            if(Input.GetKey(KeyCode.RightArrow)) {return true;}
            if(  Input.GetAxis("Left_analog Horizontal") > 0.8f){return true;}
            return false;

        } 
        if(_tipo == Tipo_get_key.up){

            if(Input.GetKeyDown(KeyCode.RightArrow)) {return true;}
            if(  Input.GetAxis("Left_analog Horizontal") < 0.8f && analog_left_houver[1] == 1 ){return true;}
            return false;
        }

        
        return false;



    }

   public static bool Lidar_up_arrow (Tipo_get_key _tipo){


         if(tipo_teclado == Tipo_teclado.normal){


                if(_tipo == Tipo_get_key.down){

                    if(Input.GetKeyDown(KeyCode.UpArrow)) {return true;}
                    if(  Input.GetAxis("Left_analog Vertical") < -0.8f && analog_left_houver[1] == 0 ){return true;}
                    return false;
                    
                } 
                if(_tipo == Tipo_get_key.houver){

                    if(Input.GetKey(KeyCode.UpArrow)) {return true;}
                    if(  Input.GetAxis("Left_analog Vertical") < -0.8f){return true;}
                    return false;

                } 
                if(_tipo == Tipo_get_key.up){

                    if(Input.GetKeyDown(KeyCode.UpArrow)) {return true;}
                    if(  Input.GetAxis("Left_analog Vertical") > -0.8f && analog_left_houver[1] == 1 ){return true;}
                    return false;
                }


                





                // if(_tipo == Tipo_get_key.down){
                        
                //     if(Input.GetKeyDown(KeyCode.UpArrow)) {return true;}
                //     if(Input.GetKeyDown(KeyCode.Joystick1Button2)){ return true;}

                // }

                // if(_tipo == Tipo_get_key.houver){
                        
                //     if(Input.GetKey(KeyCode.UpArrow)) {return true;}
                //     if(Input.GetKey(KeyCode.Joystick1Button2)){ return true;}

                // }

                // if(_tipo == Tipo_get_key.up){
                    
                //     if(Input.GetKeyUp(KeyCode.UpArrow)) {return true;}
                //     if(Input.GetKeyUp(KeyCode.Joystick1Button2)){ return true;}

                // }

            

         } else if(tipo_teclado == Tipo_teclado.plataforma){

                if(_tipo == Tipo_get_key.down){
    
                    if(Input.GetKeyDown(KeyCode.UpArrow)) {return true;}
                    if(Input.GetKeyDown(KeyCode.Joystick1Button2)){ return true;}

                }

                if(_tipo == Tipo_get_key.houver){
                        
                    if(Input.GetKey(KeyCode.UpArrow)) {return true;}
                    if(Input.GetKey(KeyCode.Joystick1Button2)){ return true;}

                }

                if(_tipo == Tipo_get_key.up){
                    
                    if(Input.GetKeyUp(KeyCode.UpArrow)) {return true;}
                    if(Input.GetKeyUp(KeyCode.Joystick1Button2)){ return true;}

                }


         }


    


        return false;

    



    }

    
   public static bool Lidar_down_arrow (Tipo_get_key _tipo){

        if(_tipo == Tipo_get_key.down){

            if(Input.GetKeyDown(KeyCode.DownArrow)) {return true;}
            if(  Input.GetAxis("Left_analog Vertical") > 0.8f && analog_left_houver[3] == 0 ){return true;}
            return false;
            
        } 

        if(_tipo == Tipo_get_key.houver){

            if(Input.GetKey(KeyCode.DownArrow)) {return true;}
            if(  Input.GetAxis("Left_analog Vertical") > 0.8f){return true;}
            return false;

        } 


        if(_tipo == Tipo_get_key.up){

            if(Input.GetKeyDown(KeyCode.DownArrow)) {return true;}
            if(  Input.GetAxis("Left_analog Vertical") < 0.8f && analog_left_houver[3] == 1 ){return true;}
            return false;
        }

        
        return false;



    }



















    
   public static bool Lidar_left_mov (Tipo_get_key _tipo){

    Debug.Log( Input.GetAxis("Right_analog Horizontal"));


        if(_tipo == Tipo_get_key.down){

            if(Input.GetKeyDown(KeyCode.Keypad4)) {return true;}
            if(  Input.GetAxis("Right_analog Horizontal") == -1f && analog_right_houver[0] == 0 ){return true;}

            return false;
            
        } 
        if(_tipo == Tipo_get_key.houver){

            if(Input.GetKey(KeyCode.Keypad4)) {return true;}
            if(  Input.GetAxis("Right_analog Horizontal") == -1f){return true;}
            return false;

        } 
        if(_tipo == Tipo_get_key.up){

            if(Input.GetKeyDown(KeyCode.Keypad4)) {return true;}
            if(  Input.GetAxis("Right_analog Horizontal") != -1f && analog_right_houver[0] == 1 ){return true;}
            return false;
        }

        
        return false;

    }


   public static bool Lidar_right_mov (Tipo_get_key _tipo){

        if(_tipo == Tipo_get_key.down){

            if(Input.GetKeyDown(KeyCode.Keypad6)) {return true;}
            if(  Input.GetAxis("Right_analog Horizontal") == 1f && analog_right_houver[1] == 0 ){return true;}
            return false;
            
        } 
        if(_tipo == Tipo_get_key.houver){

            if(Input.GetKey(KeyCode.Keypad6)) {return true;}
            if(  Input.GetAxis("Right_analog Horizontal") == 1f){return true;}
            return false;

        } 
        if(_tipo == Tipo_get_key.up){

            if(Input.GetKeyDown(KeyCode.Keypad6)) {return true;}
            if(  Input.GetAxis("Right_analog Horizontal") != 1f && analog_right_houver[1] == 1 ){return true;}
            return false;
        }

        
        return false;



    }






   public static bool Lidar_up_mov (Tipo_get_key _tipo){

        

        if(_tipo == Tipo_get_key.down){

            if(Input.GetKeyDown(KeyCode.Keypad8)) {return true;}
            if(  Input.GetAxis("Right_analog Vertical") == 1f && analog_right_houver[2] == 0 ){return true;}
            return false;
            
        } 
        if(_tipo == Tipo_get_key.houver){

            if(Input.GetKey(KeyCode.Keypad8)) {return true;}
            if(  Input.GetAxis("Right_analog Vertical") == 1f){return true;}
            return false;

        } 
        if(_tipo == Tipo_get_key.up){

            if(Input.GetKeyDown(KeyCode.Keypad8)) {return true;}
            if(  Input.GetAxis("Right_analog Vertical") != 1f && analog_right_houver[2] == 1 ){return true;}
            return false;
        }

        
        return false;



    }

    
   public static bool Lidar_down_mov (Tipo_get_key _tipo){

        if(_tipo == Tipo_get_key.down){

            if(Input.GetKeyDown(KeyCode.Keypad5)) {return true;}
            if(  Input.GetAxis("Right_analog Vertical") == 1f && analog_right_houver[3] == 0 ){return true;}
            return false;
            
        } 
        if(_tipo == Tipo_get_key.houver){

            if(Input.GetKey(KeyCode.Keypad5)) {return true;}
            if(  Input.GetAxis("Right_analog Vertical") == 1f){return true;}
            return false;

        } 
        if(_tipo == Tipo_get_key.up){

            if(Input.GetKeyDown(KeyCode.Keypad5)) {return true;}
            if(  Input.GetAxis("Right_analog Vertical") != 1f && analog_right_houver[3] == 1 ){return true;}
            return false;
        }

        
        return false;


    }



    
    public static void Mover_mouse(  int _pixel_mov_x , int _pixel_mov_y  ) {


                /// tirei para webgl
                // Win32.POINT pt = new Win32.POINT();
                // Win32.GetCursorPos(out pt);

                // int posicao_x_final = pt.X + _pixel_mov_x;
                // int posicao_y_final = pt.Y + _pixel_mov_y;

                // Win32.SetCursorPos(posicao_x_final, posicao_y_final);

                return;


    }




    public static string Pegar_teclas_presionadas(){

            string retorno = "";
            int index = 0;
            char[] retorno_char = new char[ 10 ];


            if( Input.GetKeyDown( KeyCode.A ) ){ retorno_char[ index ] += 'a' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.B ) ){ retorno_char[ index ] += 'b' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.C ) ){ retorno_char[ index ] += 'c' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.D ) ){ retorno_char[ index ] += 'd' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.E ) ){ retorno_char[ index ] += 'e' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.F ) ){ retorno_char[ index ] += 'f' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.G ) ){ retorno_char[ index ] += 'g' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.H ) ){ retorno_char[ index ] += 'h' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.I ) ){ retorno_char[ index ] += 'i' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.J ) ){ retorno_char[ index ] += 'j' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.K ) ){ retorno_char[ index ] += 'k' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.L ) ){ retorno_char[ index ] += 'l' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.M ) ){ retorno_char[ index ] += 'm' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.N ) ){ retorno_char[ index ] += 'n' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.O ) ){ retorno_char[ index ] += 'o' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.P ) ){ retorno_char[ index ] += 'p' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Q ) ){ retorno_char[ index ] += 'q' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.R ) ){ retorno_char[ index ] += 'r' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.S ) ){ retorno_char[ index ] += 's' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.T ) ){ retorno_char[ index ] += 't' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.U ) ){ retorno_char[ index ] += 'u' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.V ) ){ retorno_char[ index ] += 'v' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.W ) ){ retorno_char[ index ] += 'w' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.X ) ){ retorno_char[ index ] += 'x' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Y ) ){ retorno_char[ index ] += 'y' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Z ) ){ retorno_char[ index ] += 'z' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Alpha0 ) || Input.GetKeyDown( KeyCode.Keypad0 )  ){ retorno_char[ index ] += '0' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Alpha1 ) || Input.GetKeyDown( KeyCode.Keypad1 )  ){ retorno_char[ index ] += '1' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Alpha2 ) || Input.GetKeyDown( KeyCode.Keypad2 )  ){ retorno_char[ index ] += '2' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Alpha3 ) || Input.GetKeyDown( KeyCode.Keypad3 )  ){ retorno_char[ index ] += '3' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Alpha4 ) || Input.GetKeyDown( KeyCode.Keypad4 )  ){ retorno_char[ index ] += '4' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Alpha5 ) || Input.GetKeyDown( KeyCode.Keypad5 )  ){ retorno_char[ index ] += '5' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Alpha6 ) || Input.GetKeyDown( KeyCode.Keypad6 )  ){ retorno_char[ index ] += '6' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Alpha7 ) || Input.GetKeyDown( KeyCode.Keypad7 )  ){ retorno_char[ index ] += '7' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Alpha8 ) || Input.GetKeyDown( KeyCode.Keypad8 )  ){ retorno_char[ index ] += '8' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Alpha9 ) || Input.GetKeyDown( KeyCode.Keypad9 )  ){ retorno_char[ index ] += '9' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.RightCurlyBracket )  ){ retorno_char[ index ] += '}' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.LeftCurlyBracket )  ){ retorno_char[ index ] += '{' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Pipe )  ){ retorno_char[ index ] += '|' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.RightBracket )  ){ retorno_char[ index ] += ']' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.LeftBracket )  ){ retorno_char[ index ] += '[' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Backslash )  ){ retorno_char[ index ] += '\\' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Underscore )  ){ retorno_char[ index ] += '_' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.DoubleQuote )  ){ retorno_char[ index ] += '"' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.DoubleQuote )  ){ retorno_char[ index ] += '"' ; index++ ; }
            if( Input.GetKeyDown( KeyCode.Asterisk )  ){ retorno_char[ index ] += '"' ; index++ ; }
            
            
            

            return new string( retorno_char );
            
            






    }










}

//   testar


// mac
/*

  // Mac calculates global screen coordinates from top left corner of screen
    #if (UNITY_EDITOR && UNITY_EDITOR_OSX) || (!UNITY_EDITOR && UNITY_STANDALONE_OSX)
 
        [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
        public static extern int CGWarpMouseCursorPosition(CGPoint point);
 
        [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
        public static extern IntPtr CGEventCreate(IntPtr source);
 
        [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
        public static extern CGPoint CGEventGetLocation(IntPtr evt);
 
        [DllImport("/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics")]
        public static extern void CFRelease(IntPtr cf);
 
        public struct CGPoint
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
 
        Vector2 GetCursorPos ()
        {
            IntPtr ptr = CGEventCreate(IntPtr.Zero);
            CGPoint loc = CGEventGetLocation(ptr);
            CFRelease(ptr);
            return new Vector2((float)loc.X, (float)loc.Y);
        }
 
        void SetCursorPos(float x, float y)
        {
            CGPoint point = new CGPoint() {X = x, Y = y};
            CGWarpMouseCursorPosition(point);
        }
 
    #endif
 
    void Update()
    {
        if (Time.time < 12.0f) //test: mouse circular movement through 12 seconds
        {
            SetCursorPos((Mathf.Sin(Time.time) * 0.5f + 0.5f) * 500.0f, (Mathf.Cos(Time.time) * 0.5f + 0.5f) * 500.0f);
            Debug.Log(GetCursorPos());
        }
    }



*/


// win


#if UNITY_STANDALONE_WIN

public class Win32 {
    [DllImport("User32.Dll")]
    public static extern long SetCursorPos(int x, int y);
 
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetCursorPos(out POINT lpPoint);
 
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT {

        public int X;
        public int Y;
 
        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}




// // You can use like this:
// #if UNITY_STANDALONE_WIN
//                 Win32.POINT pt = new Win32.POINT();
//                 Win32.GetCursorPos(out pt);
//                 pos.x = pt.X;
//                 pos.y = pt.Y;
// #endif
// // and / or like this:
// #if UNITY_STANDALONE_WIN
//                 Win32.SetCursorPos((int)pos.x, (int)pos.y);

                
#endif
 






