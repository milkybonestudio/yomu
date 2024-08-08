using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Botao_dispositivo {


        /*

            ** COMPORTAMENTOS DEFAULT

                transicao: 
                    - mostrar o texto 
                    


            -> 
        
        */


        // ** 
        //mark
        // ** tem que mudar a cor do texto quando atualizar também 



        // --- GAME OBEJCTS

            // ** OFF 
                public GameObject OFF_game_object;
                public GameObject OFF_animacao_mostrar_texto_game_object;
                public GameObject OFF_animacao_esconder_texto_game_object;
                public GameObject OFF_animacao_game_object_final; // interno
                public GameObject OFF_texto_game_object;


            // ** ON
                public GameObject ON_game_object;
                public GameObject ON_animacao_mostrar_texto_game_object;
                public GameObject ON_animacao_esconder_texto_game_object;
                public GameObject ON_animacao_game_object_final; // interno 
                public GameObject ON_texto_game_object;


            // ** TRANSICAO
                public GameObject TRANS_game_object;
                public GameObject TRANS_texto_game_object;


        // --- IMAGES

            // ** OFF 
                public Image OFF_image;
                public Image OFF_animacao_mostrar_texto_image;
                public Image OFF_animacao_esconder_texto_image;
                public Image OFF_animacao_image_final; // interno

            // ** ON

                public Image ON_image;
                public Image ON_animacao_mostrar_texto_image;
                public Image ON_animacao_esconder_texto_image;
                public Image ON_animacao_image_final; //interno

            // ** TRANSICAO
                public Image TRANS_image;


        // --- TEXTO

            public TextMeshPro OFF_texto;
            public TextMeshPro ON_texto;
            public TextMeshPro TRANS_texto;

        // --- COLLIDERS


            public PolygonCollider2D OFF_collider;
            public PolygonCollider2D ON_collider;
        

        // --- INTERNO

        public float posicao_x;
        public float posicao_y;





        public AudioClip audio_click; 
        public AudioClip audio_houver; 
        //public AudioClip audio_houver;


        public Dados_botao_dispositivo dados;
        public GameObject botao_game_object;


        // --- LOGICA


        public bool esta_down = false; 
        public bool esta_houver = false;


        public float animacao_atual_tempo_ms = 0f;
        public float animacao_sprite_atual_tempo_ms = 0f;
        public int sprite_atual_index = -1;

    
        public Estado_visual_botao estado_visual_botao;


        // ---- SUPORTE INTERNO

        public Estado_visual_botao ultimo_estado_visual_botao;


        public void Update(){

        
                if( dados.update_para_substituir != null )
                    {
                        dados.update_para_substituir( this );
                        return;
                    }
        
                Update_logica(); 
                Update_parte_visual(); 


                if( dados.update_secundario != null )
                    { dados.update_secundario(); }

                return;

        }


        public void Update_logica(){


                if( dados.bloquear_update_logico )
                    { return; }


                // --- VERIFICAR HOUVER
                if( esta_houver )
                    {
                        // --- VERIFICA SE MOUSE CONTINUA NO BOTAO
                        esta_houver = Mat.Verificar_ponto_dentro_poligono( ON_collider.points, ( Vector2 ) ON_game_object.transform.position , Controlador_input.posicao_mouse );
                        if( !!!( esta_houver ) )
                            { 
                                // --- SAIU
                                esta_down = false;
                                return; 
                            }
                    }
                    else
                    { 
                        // --- VERIFICA SE ENTROU
                        esta_houver = Mat.Verificar_ponto_dentro_poligono( OFF_collider.points, ( Vector2 ) OFF_game_object.transform.position , Controlador_input.posicao_mouse ); 
                        if( !!!( esta_houver ) )
                            { 
                                // --- NAO ENTROU
                                return;

                            }
                            
                        // --- VERIFICA SE EH TIPO ENTRADA
                        if( dados.tipo_ativacao == Botao_dispositivo_tipo_ativacao.entrar_no_botao )
                            {
                                // --- ATIVAR BOTAO
                                dados.ativar(); 
                                return;

                            }
            
                    } 


                // --- VERIFICAR DOWN

                if( Controlador_input.Get_down( Key_code.mouse_left ) )
                    { 

                        esta_down = true; 
                        if( dados.tipo_ativacao == Botao_dispositivo_tipo_ativacao.clicar )
                            { 
                                // --- ATIVAR BOTAO
                                dados.ativar(); 
                            }
                        
                    }


                if( Controlador_input.Get_up( Key_code.mouse_left ) && esta_down )
                    { 
                        // --- ATIVA SOMENTE QUANDO DEU DOWN ANTERIORMENTE
                        if( dados.tipo_ativacao == Botao_dispositivo_tipo_ativacao.clicar_e_soltar && esta_down )
                            { 
                                // --- ATIVAR BOTAO
                                dados.ativar(); 
                            }

                    }


                if( !!!( Controlador_input.Get( Key_code.mouse_left ) ) )
                    { esta_down = false; }


        }


        public void Update_parte_visual(){


                if( dados.bloquear_update_visual )
                    { return; }


                if( estado_visual_botao != ultimo_estado_visual_botao )
                    {
                        Debug.Log( $"Novo estado_visual_botao: { estado_visual_botao }" );
                        ultimo_estado_visual_botao = estado_visual_botao;
                    }


                switch( estado_visual_botao ){

                        case Estado_visual_botao.off_estatico: Lidar_off_estatico(); break;
                        case Estado_visual_botao.off_animacao: Lidar_off_animacao(); break;
                        case Estado_visual_botao.on_estatico: Lidar_on_estatico(); break;
                        case Estado_visual_botao.on_animacao: Lidar_on_animacao(); break;

                        case Estado_visual_botao.transicao_animacao_OFF_para_ON: Lidar_transicao_animacao_OFF_para_ON(); break;
                        case Estado_visual_botao.transicao_animacao_ON_para_OFF: Lidar_transicao_animacao_ON_para_OFF(); break;

                }


        }
        

        
        // --- OFF

        private void Lidar_off_estatico(){


                // --- VERIFICA SE TEM INTERACAO COM O MOUSE
                if(  esta_houver )
                    {

                        // --- TEM QUE IR PARA ON


                        if( dados.comportamento_imagem_on_transicao_OFF_para_ON == Botao_imagem_estado.visivel )
                            {
                                // --- DEIXAR VISIVEL

                            
                                OFF_image.sprite = dados.sprite_off;
                                OFF_image.color = dados.cor_imagem_off;
                            }
                            else 
                            {
                                // --- DEIXAR INVISIVEL
                                OFF_image.sprite = null;
                                OFF_image.color = Cores.clear;
                            }

                        
                        TRANS_image.sprite = dados.sprite_on;
                        TRANS_image.color = dados.cor_imagem_on;
                        // ** se for com sprites ele vai resetar no primeiro frame
                        animacao_sprite_atual_tempo_ms = 0f;
                        animacao_atual_tempo_ms = dados.animacao_transicao_tempo_espera_OFF_para_ON_ms;


                        // --- DEFINE ESTADO TRANSICAO
                        estado_visual_botao = Estado_visual_botao.transicao_animacao_OFF_para_ON;
                        Update_parte_visual();
                        return;

                    }


                // --- VERIFICAR SE TEM ANIMAR OFF
                if( dados.animacao_sprites_off == null )
                    { return; }

                // --- TEM ANIMACAO
                animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f );

                // --- VERIFICA SE PODE INICIAR ANIMACAO OFF
                if( animacao_atual_tempo_ms < 0f )
                    { 
                        // --- VAI INICIAR ANIMACAO


                        // *** DEFINIR QUAL GAMEOBJECT
                        if( dados.manter_texto_animacao_OFF )
                            { 
                                // --- VAI MOSTRAR O TEXTO 
                                OFF_animacao_game_object_final = OFF_animacao_mostrar_texto_game_object;
                                OFF_animacao_image_final = OFF_animacao_mostrar_texto_image;

                                OFF_animacao_esconder_texto_image.sprite = null;
                                OFF_animacao_esconder_texto_image.color = Cores.clear;

                            } 
                            else
                            {
                                // --- NAO VAI MOSTRAR O TEXTO

                                OFF_animacao_game_object_final = OFF_animacao_esconder_texto_game_object;
                                OFF_animacao_image_final = OFF_animacao_esconder_texto_image;

                                OFF_animacao_mostrar_texto_image.sprite = null;
                                OFF_animacao_mostrar_texto_image.color = Cores.clear;

                            }

                        
                        // --- VERIFICA SE TEM QUE MANTER A SPRITE ESTATICA DO OFF
                        if( dados.manter_imagem_principal_OFF )
                            {
                                // --- TEM QUE DEIXAR 
                                OFF_image.sprite = dados.sprite_off;
                                OFF_image.color = dados.cor_imagem_off;
                            }
                            else
                            {
                                // --- ESCONDER
                                OFF_image.sprite = null;
                                OFF_image.color = Cores.clear;
                            }


                        // *** vai forcar mudar para a primeira sprite
                        animacao_sprite_atual_tempo_ms = 0f; 
                        estado_visual_botao = Estado_visual_botao.off_animacao;
                        Update_parte_visual();
                        
                    }

                return;
                
            
        }


        private void Lidar_off_animacao(){
            

            // --- PASSAR TEMPO
            if( esta_houver )
                { animacao_sprite_atual_tempo_ms -= 3f * ( Time.deltaTime * 1000f ) ;}// --- PRECISA ACELERAR PARA FINALIZAR RAPIOD
                else
                { animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL


            
            // --- VERIFICA SE TEM QUE ESPERAR
            if( animacao_sprite_atual_tempo_ms > 0f )
                { return; }

            

            // --- TEM QUE TROCAR FRAME
            sprite_atual_index++;


            // --- VERIFICA SE ESSA ERA A ULTIMA SPRITE
            if( sprite_atual_index == dados.animacao_sprites_off.Length )
                {
                    // --- VOLTAR PARA STATIC 

                    OFF_image.sprite = dados.sprite_off;
                    OFF_image.color = dados.cor_imagem_off;

                    // --- ESCONDER
                    OFF_animacao_image_final.sprite = null;
                    OFF_animacao_image_final.color = Cores.clear;

                    // --- RESETA DADOS

                    OFF_animacao_game_object_final = null;
                    OFF_animacao_image_final = null;

                    animacao_atual_tempo_ms = dados.animacao_off_tempo_espera_ms;
                    sprite_atual_index = -1;

                    estado_visual_botao = Estado_visual_botao.off_estatico;
                    Update_parte_visual();

                    return;

                }

            // --- AINDA TEM SPRITE

            // ---TROCAR SPRITE
            OFF_animacao_image_final.sprite = dados.animacao_sprites_off[ sprite_atual_index ];
            OFF_animacao_image_final.color = dados.cores_animacao_imagem_off[ sprite_atual_index ];

            // RENOVA TEMPO
            if( dados.animacao_off_tempo_troca_sprite_ms_por_sprite != null )
                { animacao_sprite_atual_tempo_ms = dados.animacao_off_tempo_troca_sprite_ms_por_sprite[ sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                else
                { animacao_sprite_atual_tempo_ms = dados.animacao_off_tempo_troca_sprite_ms; } // --- TEMPO UNICO


            return;


        }






        // --- ON

        private void Lidar_on_estatico(){


                // --- VERIFICA SE O MAUSE SAIU
                if( !!!( esta_houver ) )
                        {

                                // --- INICIAR TRANSICAO ON => OFF


                                // --- VERIFICAR TEXTO
                                if( dados.manter_texto_transicao_ON_para_OFF )
                                    { 
                                        // --- VAI MOSTRAR O TEXTO
                                        // ** depois tem que copiar o texto que esta no ON e por no slot da transicao
                                        // no default ele sempre vai esconder o texto

                                    } 
 
                                // --- VERIFICAR VISIBILIDADE BOTAO ON
                                if( dados.comportamento_imagem_on_transicao_ON_para_OFF == Botao_imagem_estado.visivel )
                                    {
                                        // --- DEIXAR VISIVEL
                                                
                                        ON_image.sprite = dados.sprite_on;
                                        ON_image.color = dados.cor_imagem_on;
                                    }
                                    else 
                                    {
                                        // --- DEIXAR INVISIVEL
                                        ON_image.sprite = null;
                                        ON_image.color = Cores.clear;
                                    }

                                
                                // ** se for com sprites ele vai resetar no primeiro frame
                                // ** se for cor vai precisar da sprite
                                TRANS_image.sprite = dados.sprite_off;
                                TRANS_image.color = dados.cor_imagem_off;

                                // ** ajusta o tempo caso seja da formato cor
                                animacao_atual_tempo_ms = dados.animacao_transicao_tempo_espera_ON_para_OFF_ms;
                                animacao_sprite_atual_tempo_ms = 0f;
                                sprite_atual_index = -1;


                                // --- DEFINE ESTADO TRANSICAO
                                estado_visual_botao = Estado_visual_botao.transicao_animacao_ON_para_OFF;
                                Update_parte_visual();
                                return;

                        }


                // --- VERIFICAR SE TEM ANIMAR OFF
                if( dados.animacao_sprites_on == null )
                    { return; }

                // --- TEM ANIMACAO
                animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f );


                // --- VERIFICA SE PODE INICIAR ANIMACAO ON
                if( animacao_atual_tempo_ms > 0f )
                    { return; } // --- NAO TEM 


                // --- TEM ANIMACAO ON ESTATICA
                        

                // *** DEFINIR QUAL GAMEOBJECT
                if( dados.manter_texto_animacao_ON )
                    { 
                        // --- VAI MOSTRAR O TEXTO 
                        ON_animacao_game_object_final = ON_animacao_mostrar_texto_game_object;
                        ON_animacao_image_final = ON_animacao_mostrar_texto_image;

                        ON_animacao_esconder_texto_image.sprite = null;
                        ON_animacao_esconder_texto_image.color = Cores.clear;

                    } 
                    else
                    {
                        // --- NAO VAI MOSTRAR O TEXTO

                        ON_animacao_game_object_final = ON_animacao_esconder_texto_game_object;
                        ON_animacao_image_final = ON_animacao_esconder_texto_image;

                        ON_animacao_mostrar_texto_image.sprite = null;
                        ON_animacao_mostrar_texto_image.color = Cores.clear;

                    }
                
                // --- VERIFICA SE TEM QUE MANTER A SPRITE ESTATICA DO ON
                if( dados.comportamento_imagem_off_animacao == Botao_imagem_estado.visivel )
                    {
                        // --- TEM QUE DEIXAR 
                        ON_image.sprite = dados.sprite_on;
                        ON_image.color = dados.cor_imagem_on;
                    }
                    else
                    {
                        // --- ESCONDER

                        ON_image.sprite = null;
                        ON_image.color = Cores.clear;
                    }


                    animacao_sprite_atual_tempo_ms = 0f; // *** vai forcar mudar para a primeira sprite

                    // --- MUDA ESTADO
                    estado_visual_botao = Estado_visual_botao.on_animacao;
                    Lidar_on_animacao();
                    
            

                return;
                
            
        }


        private void Lidar_on_animacao(){
            

            // --- PASSAR TEMPO
            if( esta_houver )
                { animacao_sprite_atual_tempo_ms -= 3f * ( Time.deltaTime * 1000f ) ;}// --- PRECISA ACELERAR PARA FINALIZAR RAPIOD
                else
                { animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL


            
            // --- VERIFICA SE TEM QUE ESPERAR
            if( animacao_sprite_atual_tempo_ms > 0f )
                { return; }

            

            // --- TEM QUE TROCAR FRAME
            sprite_atual_index++;


            // --- VERIFICA SE ESSA ERA A ULTIMA SPRITE
            if( sprite_atual_index == dados.animacao_sprites_off.Length )
                {
                    // --- VOLTAR PARA STATIC 


                    ON_image.sprite = dados.sprite_on;
                    ON_image.color = dados.cor_imagem_on;

                    // --- ESCONDER
                    ON_animacao_image_final.sprite = null;
                    ON_animacao_image_final.color = Cores.clear;

                    // --- RESETAR DADOS
                    animacao_atual_tempo_ms = dados.animacao_off_tempo_espera_ms;
                    sprite_atual_index = -1;
                    ON_animacao_image_final = null;
                    ON_animacao_game_object_final = null;

                    // --- TROCA MODO
                    estado_visual_botao = Estado_visual_botao.on_estatico;
                    Update_parte_visual();

                    return;

                }

            // --- AINDA TEM SPRITE

            // ---TROCAR SPRITE
            ON_animacao_image_final.sprite = dados.animacao_sprites_off[ sprite_atual_index ];
            ON_animacao_image_final.color = dados.cores_animacao_imagem_off[ sprite_atual_index ];

            // RENOVA TEMPO
            if( dados.animacao_off_tempo_troca_sprite_ms_por_sprite != null )
                { animacao_sprite_atual_tempo_ms = dados.animacao_off_tempo_troca_sprite_ms_por_sprite[ sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                else
                { animacao_sprite_atual_tempo_ms = dados.animacao_off_tempo_troca_sprite_ms; } // --- TEMPO UNICO


            return;


        }












        // --- TRANSICAO


        private void Lidar_transicao_animacao_OFF_para_ON(){


            switch( dados.tipo_transicao ){

                case Tipo_transicao_botao_OFF_ON_dispositivo.nada : Finalizar_transicao_OFF_para_ON(); break;
                case Tipo_transicao_botao_OFF_ON_dispositivo.cor : Lidar_transicao_animacao_OFF_para_ON_cor(); break;
                case Tipo_transicao_botao_OFF_ON_dispositivo.animacao_vai_e_vem : Lidar_transicao_animacao_OFF_para_ON_animacao_vai_e_vem(); break;
                case Tipo_transicao_botao_OFF_ON_dispositivo.animacao_individual : Lidar_transicao_animacao_OFF_para_ON_animacao_individual(); break;
            
            }

            
        }



        private void Finalizar_transicao_OFF_para_ON(){

                // --- VAI DIRETO PARA ON

                // ** remvoer transicao
                TRANS_image.sprite = null;
                TRANS_image.color = Cores.clear;

                // ** finaliza imagem off
                OFF_image.sprite = null;
                OFF_image.color = Cores.clear;

                
                // ** remvoer ON
                ON_image.sprite = dados.sprite_on;
                ON_image.color = dados.cor_imagem_on;

                // ** coloca tempo animacao
                animacao_atual_tempo_ms = dados.animacao_on_tempo_espera_ms;
                sprite_atual_index = -1;

                estado_visual_botao = Estado_visual_botao.on_estatico;
                Lidar_on_estatico();
                return;


        }




    
        private void Lidar_transicao_animacao_OFF_para_ON_cor(){


                
                if( !!!(esta_houver) )
                    { animacao_atual_tempo_ms -= 3f * ( Time.deltaTime * 1000f ) ; }
                    else
                    { animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; }


                if( animacao_atual_tempo_ms < 0.1f )
                    {
                        // --- FINALIZAR
                        Finalizar_transicao_OFF_para_ON();
                        return;

                    }

                // ** VERIFICAR COMO VAI FICAR NO FINAL

                Color cor_final = dados.cor_imagem_off;

                float rate = ( ( dados.animacao_transicao_tempo_espera_OFF_para_ON_ms - animacao_atual_tempo_ms ) / dados.animacao_transicao_tempo_espera_OFF_para_ON_ms );
                

                // menos vai ser alterada, manter alpha estatico até perto do final
                Color cor_atual = COLOR.Pegar_cor_media( dados.cor_imagem_off ,dados.cor_imagem_on , rate );
                
                
                cor_atual[ 3 ] = rate;
                

                TRANS_image.color = cor_atual;

                

                if( rate > 0.95f )
                    { cor_atual[ 3 ] =   ( 1.2f - rate ); } // --- QUASE NO FINAL => tem que alterar alpha 
                    else
                    { cor_atual[ 3 ] = 1f; } // --- AINDA NO INICIO

                OFF_image.color = cor_atual;

                return;


        }

        

        

        private void Lidar_transicao_animacao_OFF_para_ON_animacao_individual(){
                // --- TEM 1 ANIMACAO PARA CADA

                //Debug.Log( "veio individual");


                if( dados.sprites_transicao_OFF_para_ON == null )
                    {
                        // --- NAO TEM TRANSICAO INDIVIDUAL
                        Finalizar_transicao_OFF_para_ON();
                        return;
                    }

                    
                // --- TEM ANIMACAO


                // --- PASSA TEMPO                
                if( !!!(esta_houver) )
                    { animacao_sprite_atual_tempo_ms -= 3f * ( Time.deltaTime * 1000f ); }// --- ACELERAR
                    else
                    { animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL


                // --- VERIFICA SE TEM QUE ESPERAR
                if( animacao_sprite_atual_tempo_ms > 0f )
                    { return; } 



                // --- VAI TROCAR SPRITE
                sprite_atual_index++;
                if( sprite_atual_index == dados.sprites_transicao_OFF_para_ON.Length )
                    {
                    
                        // --- ACABOU ANIMACAO
                        Finalizar_transicao_OFF_para_ON();
                        return;

                    }


                // --- TEM MAIS FRAMES

                animacao_sprite_atual_tempo_ms = dados.animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms;

                // RENOVA TEMPO
                if( dados.animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms_por_sprite != null )
                    { animacao_sprite_atual_tempo_ms = dados.animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms_por_sprite[ sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                    else
                    { animacao_sprite_atual_tempo_ms = dados.animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms; } // --- TEMPO UNICO


                TRANS_image.sprite = dados.sprites_transicao_OFF_para_ON[ sprite_atual_index ];
                TRANS_image.color = dados.cores_transicao_OFF_para_ON[ sprite_atual_index ];
                return;




        }





        private void Lidar_transicao_animacao_OFF_para_ON_animacao_vai_e_vem (){
                // --- TEM SOMENTE O OFF => ON

                if( dados.sprites_transicao_OFF_para_ON == null )
                    {
                        // --- NAO TEM TRANSICAO INDIVIDUAL
                        Finalizar_transicao_ON_para_OFF();
                        return;
                    }

                
                if( esta_houver )
                    { animacao_sprite_atual_tempo_ms -= 3f * ( Time.deltaTime * 1000f ); }// --- ACELERAR
                    else
                    { animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; } // --- TEMPO NORMAL


        
                // --- VERIFICA SE TERMINOU SPRITE
                if( animacao_sprite_atual_tempo_ms < 0f )
                    {
                        // --- VAI TROCAR SPRITE
                        sprite_atual_index--;
                        if( sprite_atual_index < 0 )
                            {
                                // --- ACABOU ANIMACAO
                                Finalizar_transicao_ON_para_OFF();
                                return;

                            }

                    }

                // --- TEM MAIS FRAMES

                animacao_sprite_atual_tempo_ms = dados.animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms;

                // RENOVA TEMPO
                if( dados.animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms_por_sprite != null )
                    { animacao_sprite_atual_tempo_ms = dados.animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms_por_sprite[ sprite_atual_index ]; }// --- TEM TEMPO DIFERENTE PARA CADA SPRITE
                    else
                    { animacao_sprite_atual_tempo_ms = dados.animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms; } // --- TEMPO UNICO



                TRANS_image.sprite = dados.sprites_transicao_ON_para_OFF[ sprite_atual_index ];
                TRANS_image.color = dados.cores_transicao_ON_para_OFF[ sprite_atual_index ];

                return;


        }








        // --- ON -> OFF


        private void Lidar_transicao_animacao_ON_para_OFF(){
            
                Finalizar_transicao_ON_para_OFF();

        }







        private void Finalizar_transicao_ON_para_OFF(){

                // --- VAI DIRETO PARA OFF

                // ** remvoer transicao
                TRANS_image.sprite = null;
                TRANS_image.color = Cores.clear;

                // ** coloca imagem off
                OFF_image.sprite = dados.sprite_off;
                OFF_image.color = dados.cor_imagem_off;

                
                // ** remvoer ON
                ON_image.sprite = null;
                ON_image.color = Cores.clear;

                // ** coloca tempo animacao
                animacao_atual_tempo_ms = dados.animacao_off_tempo_espera_ms;

                estado_visual_botao = Estado_visual_botao.off_estatico;
                Lidar_off_estatico();
                return;


        }



















        public void Construir( Dados_botao_dispositivo _dados, string _path_dispositivo  ){

                // ** vai colocar os dados

                dados = _dados;

                string path_botao = _path_dispositivo + "/" + _dados.nome;

                botao_game_object = GameObject.Find( path_botao );
                if( botao_game_object == null )
                    { throw new System.Exception( $"Botao nao foi encontrado no path { path_botao }" ); }

                    // --- ACHOU O PONTO DE ENTRADA

                try {


                        // --- PEGAR GAMEOBJECTS

                            // ** OFF
                                OFF_game_object =  botao_game_object.transform.GetChild( 0 ).gameObject;
                                OFF_animacao_mostrar_texto_game_object  =  OFF_game_object.transform.GetChild( 0 ).gameObject;
                                OFF_texto_game_object                   =  OFF_game_object.transform.GetChild( 1 ).gameObject;
                                OFF_animacao_esconder_texto_game_object =  OFF_game_object.transform.GetChild( 2 ).gameObject;

                            // ** ON
                                ON_game_object =  botao_game_object.transform.GetChild( 1 ).gameObject;
                                ON_animacao_mostrar_texto_game_object  =  ON_game_object.transform.GetChild( 0 ).gameObject;
                                ON_texto_game_object                   =  ON_game_object.transform.GetChild( 1 ).gameObject;
                                ON_animacao_esconder_texto_game_object =  ON_game_object.transform.GetChild( 2 ).gameObject;

                            // ** TRANSICAO
                                TRANS_game_object =  botao_game_object.transform.GetChild( 2 ).gameObject;
                                TRANS_texto_game_object = TRANS_game_object.transform.GetChild( 0 ).gameObject;
                                
                        // --- PEGAR IMAGES

                            // ** OFF 

                                OFF_image =  OFF_game_object.GetComponent<Image>();
                                OFF_animacao_mostrar_texto_image =  OFF_animacao_mostrar_texto_game_object.GetComponent<Image>();
                                OFF_animacao_esconder_texto_image =  OFF_animacao_esconder_texto_game_object.GetComponent<Image>();

                            // ** ON

                                ON_image =  ON_game_object.GetComponent<Image>();
                                ON_animacao_mostrar_texto_image =  ON_animacao_mostrar_texto_game_object.GetComponent<Image>();
                                ON_animacao_esconder_texto_image =  ON_animacao_esconder_texto_game_object.GetComponent<Image>();

                            // ** transicao

                                TRANS_image =  TRANS_game_object.GetComponent<Image>();
                                TRANS_image =  TRANS_game_object.GetComponent<Image>();

                        // --- PEGAR TEXTO

                            OFF_texto = OFF_game_object.GetComponent<TextMeshPro>();
                            ON_texto = ON_game_object.GetComponent<TextMeshPro>();
                            TRANS_texto = TRANS_texto_game_object.GetComponent<TextMeshPro>();


                        // --- COLIDERS
                            ON_collider = ON_game_object.GetComponent<PolygonCollider2D>();
                            OFF_collider = OFF_game_object.GetComponent<PolygonCollider2D>();
                        
                        
                        posicao_x =  botao_game_object.transform.localPosition.x;
                        posicao_y =  botao_game_object.transform.localPosition.y;


                }
                catch ( System.Exception exc )
                {
                    Debug.LogError( $"Nao conseguiu pegar os dados do botao <color=lightBlue><b>{ _dados.nome}</b></color> no dispositivo <color=lightBlue><b>{ _dados.nome_dispositivo }</b></color>." );
                    throw exc;

                }

                OFF_image.sprite = _dados.sprite_off;
                OFF_image.color = _dados.cor_imagem_off;

                OFF_animacao_mostrar_texto_image.sprite = null;
                OFF_animacao_mostrar_texto_image.color = Cores.clear;
                
                OFF_animacao_esconder_texto_image.sprite = null;
                OFF_animacao_esconder_texto_image.color = Cores.clear;



                ON_image.sprite = null;
                ON_image.color = Cores.clear;

                ON_animacao_mostrar_texto_image.sprite = null;
                ON_animacao_mostrar_texto_image.color = Cores.clear;
                
                ON_animacao_esconder_texto_image.sprite = null;
                ON_animacao_esconder_texto_image.color = Cores.clear;



        
                TRANS_image.sprite = null;
                TRANS_image.color = Cores.clear;

                animacao_atual_tempo_ms = _dados.animacao_off_tempo_espera_ms;

            
                return;


        }





        // --- AUDIOS



}
