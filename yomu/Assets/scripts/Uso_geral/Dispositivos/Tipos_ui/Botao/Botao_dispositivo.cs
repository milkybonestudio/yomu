using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Botao_dispositivo {



        public PolygonCollider2D OFF_collider;
        public PolygonCollider2D ON_collider;
        

        // --- IMAGEM 

        public GameObject OFF_game_object;
        public GameObject OFF_animacao_game_object;
        public GameObject TRANS_game_object;
        public GameObject ON_game_object;
        public GameObject ON_animacao_game_object;

        public Image OFF_image;
        public Image OFF_animacao_image;
        public Image TRANS_image;
        public Image ON_image;
        public Image ON_animacao_image;


        // --- TEXTO

        public GameObject OFF_texto_game_object;
        public GameObject ON_texto_game_object;

        public TextMeshPro OFF_texto;
        public TextMeshPro ON_texto;


        // --- INTERNO

        public float posicao_x;
        public float posicao_y;
        


        // // --- IMAGENS

        // public Sprite sprite_imagem_off;
        // public Color cor_imagem_off;

        // public Sprite sprite_imagem_on;
        // public Color cor_imagem_on;

        // public Sprite sprite_imagem_trans;
        // public Color cor_imagem_trans;




        public AudioClip audio_click; 
        public AudioClip audio_houver; 


        public Dados_botao_dispositivo dados;
        public GameObject botao_game_object;


        // --- LOGICA

        public bool esta_down = false; 
        public bool esta_houver = false;


        public float animacao_atual_tempo_ms = 0f;
        public float animacao_sprite_atual_tempo_ms = 0f;
        public int sprite_atual_index = 0;

    
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

                        // --- VERIFICA SE TEM TRANSICAO
                        if( dados.sprites_animacao_transicao_OFF_para_ON == null )
                            {   

                                // --- NAO TEM TRANSICAO OFF PARA ON
                                estado_visual_botao = Estado_visual_botao.on_estatico;
                                animacao_atual_tempo_ms = dados.animacao_on_tempo_espera_ms;
                                return;
                            }

                        // --- DEFINE ESTADO TRANSICAO
                        estado_visual_botao = Estado_visual_botao.transicao_animacao_OFF_para_ON;
                        return;

                    }


                OFF_image.sprite = dados.sprite_off;
                OFF_image.color = dados.cor_imagem_off;

                ON_image.sprite = null;
                ON_image.color = Cores.clear;


                // --- VERIFICAR SE VAI ANIMAR OFF
                if( dados.animacao_sprites_off == null )
                    { return; }
                // --- TEM ANIMACAO

                animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f );

                // --- VERIFICA SE PODE INICIAR ANIMACAO OFF
                if( animacao_atual_tempo_ms < 0f )
                    { estado_visual_botao = Estado_visual_botao.off_animacao; }

                return;
                
            
        }


        private void Lidar_off_animacao(){
            

            // --- CONTINUA ANIMACAO

            animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ;

            // --- VERIFICA SE TEM QUE SAIR DA ANIMACAO
            if( esta_down )
                {
                    // --- TEM QUE SAIR DA ANIMACAO 
                    // ** por hora nao vai m=voltar, vai seimplesmente acelerar

                    animacao_sprite_atual_tempo_ms -= 2f * ( Time.deltaTime * 1000f ) ;

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
            

            // --- VERIFICA SE TEM QUE ESPERAR
            if( animacao_sprite_atual_tempo_ms > 0f )
                { return; }

            

            // --- TEM QUE TROCAR FRAME

            animacao_sprite_atual_tempo_ms = dados.animacao_off_tempo_troca_sprite_ms;
            sprite_atual_index++;

            // --- VERIFICA SE ESSA ERA A ULTIMA SPRITE
            if( sprite_atual_index == dados.animacao_sprites_off.Length )
                {
                    // --- VOLTAR PARA STATIC 

                    estado_visual_botao = Estado_visual_botao.off_estatico;
                    animacao_atual_tempo_ms = dados.animacao_off_tempo_espera_ms;
                    return;

                }

            // ---TROCAR SPRITE
            OFF_image.sprite = dados.animacao_sprites_off[ sprite_atual_index ];
            OFF_image.color = dados.cores_animacao_imagem_off[ sprite_atual_index ];

            // --- REZETAR TEMPO
            animacao_atual_tempo_ms = dados.animacao_off_tempo_troca_sprite_ms;
            return;

            


        }




        // --- ON

        private void Lidar_on_estatico(){


                // --- VERIFICA SE TEM INTERACAO COM O MOUSE
                if(  !!!( esta_houver ) )
                    {
                        // --- TEM QUE IR PARA OFF

                        // --- VERIFICA SE TEM TRANSICAO
                        if( dados.sprites_animacao_transicao_ON_para_OFF == null )
                            {   
                                // --- NAO TEM TRANSICAO ON PARA OFF
                                estado_visual_botao = Estado_visual_botao.off_estatico;
                                animacao_atual_tempo_ms = dados.animacao_off_tempo_espera_ms;
                                return;
                            }

                        // --- DEFINE ESTADO TRANSICAO
                        estado_visual_botao = Estado_visual_botao.transicao_animacao_OFF_para_ON;
                        return;

                    }


                // --- COLOCA DADOS ESTATICOS

                OFF_image.sprite = null;
                OFF_image.color = Cores.clear;

                ON_image.sprite = dados.sprite_on;
                ON_image.color = dados.cor_imagem_on;


                // --- VERIFICAR SE VAI ANIMAR ON
                if( dados.animacao_sprites_on == null )
                    { return; }

                // --- TEM ANIMACAO

                animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f );

                // --- VERIFICA SE PODE INICIAR ANIMACAO On
                if( animacao_atual_tempo_ms < 0f )
                    { estado_visual_botao = Estado_visual_botao.on_animacao; }

                return;
                
            
        }


        private void Lidar_on_animacao(){
            

            // --- CONTINUA ANIMACAO

            animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ;

            // --- VERIFICA SE TEM QUE SAIR DA ANIMACAO
            if( esta_down )
                {
                    // --- TEM QUE SAIR DA ANIMACAO 
                    // ** por hora nao vai m=voltar, vai seimplesmente acelerar

                    animacao_sprite_atual_tempo_ms -= 2f * ( Time.deltaTime * 1000f ) ;

                }


            // --- VERIFICA SE TEM QUE MANTER A SPRITE ESTATICA DO ON

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
            

            // --- VERIFICA SE TEM QUE ESPERAR
            if( animacao_sprite_atual_tempo_ms > 0f )
                { return; }

            

            // --- TEM QUE TROCAR FRAME

            animacao_sprite_atual_tempo_ms = dados.animacao_on_tempo_troca_sprite_ms;
            sprite_atual_index++;

            // --- VERIFICA SE ESSA ERA A ULTIMA SPRITE
            if( sprite_atual_index == dados.animacao_sprites_on.Length )
                {
                    // --- VOLTAR PARA STATIC 

                    estado_visual_botao = Estado_visual_botao.on_estatico;
                    animacao_atual_tempo_ms = dados.animacao_on_tempo_espera_ms;
                    return;

                }

            // ---TROCAR SPRITE
            ON_image.sprite = dados.animacao_sprites_on[ sprite_atual_index ];
            ON_image.color = dados.cores_animacao_imagem_on[ sprite_atual_index ];

            // --- REZETAR TEMPO
            animacao_atual_tempo_ms = dados.animacao_on_tempo_troca_sprite_ms;
            return;

            


        }






        // --- TRANSICAO


        private void Lidar_transicao_animacao_ON_para_OFF(){
            

            if( dados.tipo_transicao == Tipo_transicao_botao_OFF_ON_dispositivo.nada )
                {
                    // --- VAI DIRETO PARA OFF

                    

                }

            



            if( dados.tipo_transicao == Tipo_transicao_botao_OFF_ON_dispositivo.cor )
                {
                    
                    if( esta_houver )
                        { animacao_atual_tempo_ms -= 3f * ( Time.deltaTime * 1000f ) ; }
                        else
                        { animacao_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ; }


                    if( animacao_atual_tempo_ms < 0f )
                        {
                            // --- ENCERRAR
                            estado_visual_botao = Estado_visual_botao.off_estatico;
                            animacao_atual_tempo_ms = dados.animacao_off_tempo_espera_ms;


                            // ---TROCAR SPRITE
                            OFF_image.sprite = dados.animacao_sprites_off[ sprite_atual_index ];
                            OFF_image.color = dados.cores_animacao_imagem_off[ sprite_atual_index ];

                            TRANS_image.sprite = null;
                            TRANS_image.color = Cores.clear;



                        }

                    Color cor_final = dados.cor_imagem_off;


                    TRANS_image.color  = new Color  (  
                                                        cor_final[ 0 ],
                                                        cor_final[ 1 ],
                                                        cor_final[ 2 ],
                                                        ( 1f / animacao_atual_tempo_ms )
                                                    );

                    if( animacao_atual_tempo_ms < 50f )
                        {
                            // *** VER SE FUNCIONA
                            OFF_image.color = new Color (  
                                                            OFF_image.color[ 0 ],
                                                            OFF_image.color[ 1 ],
                                                            OFF_image.color[ 2 ],
                                                            ( 1f - ( 1f / animacao_atual_tempo_ms ) )
                                                        );
                        }

                }

            

            

            if( dados.tipo_transicao == Tipo_transicao_botao_OFF_ON_dispositivo.animacao_individual )
                {
                    // --- TEM 1 ANIMACAO PARA CADA





                }

            if( dados.tipo_transicao == Tipo_transicao_botao_OFF_ON_dispositivo.animacao_vai_e_vem )
                {
                    // --- TEM SOMENTE O OFF => ON


                    Sprite[] sprites_animacao_transicao = dados.sprites_animacao_transicao_OFF_para_ON;
                    Color[]  cores_animacao_transicao = dados.cores_animacao_imagem_transicao_OFF_para_ON;


                }




            animacao_sprite_atual_tempo_ms -= ( Time.deltaTime * 1000f ) ;

            // --- VERIFICA SE TERMINOU SPRITE
            if( animacao_sprite_atual_tempo_ms < 0f )
                {
                    // --- VAI TROCAR SPRITE
                    sprite_atual_index++;
                    if( sprite_atual_index == dados.imagens_animacao_ids_imagem_transicao_final_ON_para_OFF.Length )
                        {
                            // --- ACABOU ANIMACAO

                                estado_visual_botao = Estado_visual_botao.off_estatico;
                                animacao_atual_tempo_ms = dados.animacao_off_tempo_espera_ms;
                        }
                    // --- TEM MAIS FRAMES

                    animacao_sprite_atual_tempo_ms = dados.animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms;

                }

            if( esta_houver )
                {
                    // --- ACELERAR
                    animacao_sprite_atual_tempo_ms -= 3f * ( Time.deltaTime * 1000f ) ;

                }


            TRANS_image.sprite = dados.sprites_animacao_transicao_ON_para_OFF[ sprite_atual_index ];
            TRANS_image.color = dados.cores_animacao_imagem_transicao_ON_para_OFF[ sprite_atual_index ];






            
        }
        private void Lidar_transicao_animacao_OFF_para_ON(){
            // --- MUDAR ANIMACAO
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
                        OFF_game_object =  botao_game_object.transform.GetChild( 0 ).gameObject;
                        OFF_animacao_game_object =  OFF_game_object.transform.GetChild( 1 ).gameObject;
                        TRANS_game_object =  botao_game_object.transform.GetChild( 1 ).gameObject;
                        ON_game_object =  botao_game_object.transform.GetChild( 2 ).gameObject;
                        ON_animacao_game_object =  ON_game_object.transform.GetChild( 1 ).gameObject;
                        
                        // --- PEGAR IMAGES
                        OFF_image =  OFF_game_object.GetComponent<Image>();
                        OFF_animacao_image =  OFF_animacao_game_object.GetComponent<Image>();
                        TRANS_image =  TRANS_game_object.GetComponent<Image>();
                        ON_animacao_image =  ON_animacao_game_object.GetComponent<Image>();
                        ON_image =  ON_game_object.GetComponent<Image>();

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

                ON_image.sprite = null;
                ON_image.color = Cores.clear;

                animacao_atual_tempo_ms = _dados.animacao_off_tempo_espera_ms;

            
                return;


        }





        // --- AUDIOS



}
