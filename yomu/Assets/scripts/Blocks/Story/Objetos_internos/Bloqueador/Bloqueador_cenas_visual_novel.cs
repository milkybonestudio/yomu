using UnityEngine;


public class Bloqueador_cenas_visual_novel {


        public float milisegundos_para_esperar = 0f; // time
        public int clicks_em_espera = 0; // click
        
        public Tipo_bloqueio_visual_novel tipo_bloqueio_atual;


        public void Update(){


                // --- CONTA CLICKS

                if( Input.GetKeyDown( KeyCode.Space )  || Input.GetMouseButtonDown( 0 ) )
                    { clicks_em_espera--; }


                // --- PASSA TEMPO
                
                milisegundos_para_esperar -= ( Time.deltaTime * 1_000f );
                

                // --- CALCULO BOOLS 

                bool click_liberado = ( clicks_em_espera < 0 );
                bool tempo_liberado = ( milisegundos_para_esperar < 0 );


                // --- VERIFICA SE PODE DESBLOQUEAR

                if( ( tipo_bloqueio_atual == Tipo_bloqueio_visual_novel.click ) && ( click_liberado )  )
                    {
                        Liberar_bloqueio();
                        return;
                    }

                if( ( tipo_bloqueio_atual == Tipo_bloqueio_visual_novel.tempo ) && ( tempo_liberado ) )
                    {
                        Liberar_bloqueio(); 
                        return;
                    }

                    
                if( ( tipo_bloqueio_atual == Tipo_bloqueio_visual_novel.tempo_E_click ) && ( tempo_liberado && tempo_liberado ) )
                    {
                        Liberar_bloqueio();
                        return;
                    }
                   
                if( ( tipo_bloqueio_atual == Tipo_bloqueio_visual_novel.tempo_OU_click ) && ( tempo_liberado || tempo_liberado ) )
                    {
                        Liberar_bloqueio();
                        return;
                    }


                // --- AINDA ESTA BLOQUEADO
                return;


        }


        public void Bloquear(  Tipo_bloqueio_visual_novel _tipo , float _tempo_em_milisegundos, int _numero_clicks ){


                tipo_bloqueio_atual = _tipo;
                milisegundos_para_esperar = _tempo_em_milisegundos;
                clicks_em_espera = _numero_clicks;

                return;

        }

        public void Liberar_bloqueio(){

                tipo_bloqueio_atual = Tipo_bloqueio_visual_novel.sem_bloqueio;

                milisegundos_para_esperar = 0f;
                clicks_em_espera = 0;

                return;

        }



}

