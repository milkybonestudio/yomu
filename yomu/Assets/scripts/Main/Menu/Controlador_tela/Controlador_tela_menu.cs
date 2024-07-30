using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Controlador_tela_menu {


        // --- TELA

        public  Coroutine coroutine_atual;

        public  GameObject menu_background; 
        public  Transform menu_background_transform;
        public  RectTransform menu_background_rect_transform;
        


        public  GameObject canvas_menu;
        public  Image canvas_menu_image;
        public  RectTransform canvas_menu_rect;

        

        public  GameObject canvas_menu_movel;


        // --- BACKGROUND
        
        public GameObject container_backgrounds;

        public  GameObject[] canvas_individuais_menu_backgrounds;
        public  Image[] canvas_individuais_menu_imagens_backgrounds;
        public  RectTransform[] canvas_individuais_menu_rects_backgrounds;

        // --- INTERATIVOS MENU
        
        public GameObject container_blocos_menu;
        public GameObject[] containers_blocos_especificos;

        public  GameObject[][] canvas_individuais_interativos_menu_POR_BLOCO;
        public  Image[][] canvas_individuais_imagens_interativos_menu_POR_BLOCO;
        public  RectTransform[][] canvas_individuais_rects_interativos_menu_POR_BLOCO;


        // --- OBJETOS ESTATICOS

        public GameObject container_objetos_estaticos;

        public  GameObject[] canvas_individuais_menu_objetos_estaticos;
        public  Image[] canvas_individuais_menu_imagens_objetos_estaticos;
        public  RectTransform[] canvas_individuais_menu_rects_objetos_estaticos;



        public int[] posicoes_blocos;

        public int[] background_imagens_ids;
        public int[] background_imagens_posicoes;

    


        public void Update(){

            // ** talvez colocar animacoes aqui
            return;

        }



        public void Movimentar_tela( Menu_bloco _novo_bloco ){

            if( coroutine_atual != null ) 
                { Mono_instancia.Stop_coroutine( coroutine_atual ); }

            float nova_posicao_x = posicoes_blocos[ ( ( int ) _novo_bloco ) + 0 ];
            float nova_posicao_y = posicoes_blocos[ ( ( int ) _novo_bloco ) + 1 ];

            Menu.Pegar_instancia().estado_atual = Menu_bloco.transicao;
            coroutine_atual = Mono_instancia.Start_coroutine( Ir_coroutine( nova_posicao_x, nova_posicao_y, _novo_bloco ) ); 
            return;


        }



        private IEnumerator Ir_coroutine( float _nova_posicao_x, float _nova_posicao_y, Menu_bloco _novo_tipo ){

                // *** por hora pode deixar linear


                // --- PEGA X
                float posicao_inicial_x = canvas_menu_movel.transform.localPosition.x;
                float distancia_x =  ( posicao_inicial_x - _nova_posicao_x )  ;
                float sign_x = 1f;
                if( distancia_x < 0f )
                    { sign_x = -1; }

                float distancia_modulo_x = ( distancia_x * sign_x );


                // --- PEGA Y
                float posicao_inicial_y = canvas_menu_movel.transform.localPosition.y;
                float distancia_y =  ( posicao_inicial_y - _nova_posicao_y )  ;
                float sign_y = 1f;
                if( distancia_y < 0f )
                    { sign_y = -1; }

                float distancia_modulo_y = ( distancia_y * sign_y );

                    
                //mark
                // *** ver se deu certo 
                //float speed_ms = distancia > 6000f ? 600f : distancia > 4000f ?  500f  : distancia > 3000f ?  400f :  300f ;

                
                // --- PEGA VELOCIDADE

                float speed_ms_x = 300f;

                if( distancia_modulo_x > 3000f )
                    { speed_ms_x = 400f; }

                if( distancia_modulo_x > 4000f )
                    { speed_ms_x = 500f; }

                if( distancia_modulo_x > 6000f )
                    { speed_ms_x = 600f; }


                // --- PEGA VELOCIDADE

                float speed_ms_y = 300f;

                if( distancia_modulo_y > 3000f )
                    { speed_ms_y = 400f; }

                if( distancia_modulo_y > 4000f )
                    { speed_ms_y = 500f; }

                if( distancia_modulo_y > 6000f )
                    { speed_ms_y = 600f; }


                // --- PEGA A MAIOR VELOCIDADE

                float speed_ms = 300f;

                if( speed_ms_x < speed_ms_y )
                    { speed_ms_x = speed_ms_y; }
                


                float acumulador = 0f;
                float posicao_para_mover_x = posicao_inicial_x;
                float posicao_para_mover_y = posicao_inicial_y;

                // os dois vao chegar ao mesmo tempo ( ? )
                while(  ( posicao_para_mover_x - posicao_inicial_x ) < distancia_modulo_x  ){


                        Geral.Trava();

                        // count += 1f;
                        // posicao_inicial -= d_x;

                        // acumulador += Time.deltaTime * ( speed_ms/ 1000f );
                        // posicao_inicial += acumulador ;

                        float delta_tempo = Time.deltaTime * ( speed_ms / 1000f );
                        
                        posicao_para_mover_x += distancia_x * delta_tempo;
                        posicao_para_mover_y += distancia_y * delta_tempo;
                        
                        canvas_menu_movel.transform.localPosition = new Vector3( posicao_inicial_x , posicao_para_mover_y , 0f);
                        yield return null;


                }


                // --- FINALIZA MOVIMENTO NO MENU

                canvas_menu_movel.transform.localPosition = new Vector3( _nova_posicao_x, _nova_posicao_y, 0f);
                Menu.Pegar_instancia().estado_atual = _novo_tipo;


                // --- ENCERRA COROUTINE

                coroutine_atual = null;
                yield break;


        }



        //    360 /   1200  / 360 
        //      +- 1560



}