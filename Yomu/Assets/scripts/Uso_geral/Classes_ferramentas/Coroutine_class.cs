using System ;
using System.Collections;
using UnityEngine ;
using UnityEngine.UI ;


public static class Coroutine_ferramentas {


        public static IEnumerator Mudar_position_generico(  float tempo_ms  , Transform  transform  ,  Vector3 _nova_posicao  ){


                yield return null;

                float count = 0;

            

                float position_x_inicial =   transform.localPosition.x;
                float position_x_final =   _nova_posicao.x ;
                float variacao_x = position_x_final - position_x_inicial;

                
                float position_y_inicial =   transform.localPosition.y;
                float position_y_final =   _nova_posicao.y ;
                float variacao_y = position_y_final - position_y_inicial;


                float x_atual = position_x_inicial;
                float y_atual = position_y_inicial;

                float numero_ciclos =  60f * ( tempo_ms / 1000f) ;



                while( count < numero_ciclos ){


                        count += 1f;

                        x_atual += variacao_x / numero_ciclos;
                        y_atual += variacao_y / numero_ciclos;

                        transform.localPosition =  new Vector3( x_atual , y_atual ,  0f );

                        yield return null;
                        

                }
            
                transform.localPosition =  _nova_posicao;
                

                yield break;
                

        }






        public static IEnumerator Transicionar_cor(  Color _cor_inicial , Color _cor_final, float _tempo_ms, Image[] _locais ) {



                int numero_ciclos = (int) ((_tempo_ms / 1000f) * 60f);

                float v_i_1 = _cor_inicial[0];
                float v_i_2 = _cor_inicial[1];
                float v_i_3 = _cor_inicial[2];
                float v_i_4 = _cor_inicial[3];

                float v_f_1 = _cor_final[0];
                float v_f_2 = _cor_final[1];
                float v_f_3 = _cor_final[2];
                float v_f_4 = _cor_final[3];

                float d_1 = (v_f_1 - v_i_1) / (float) numero_ciclos ;
                float d_2 = (v_f_2 - v_i_2) / (float) numero_ciclos ;
                float d_3 = (v_f_3 - v_i_3) / (float) numero_ciclos ;
                float d_4 = (v_f_4 - v_i_4) / (float) numero_ciclos ;

                int i = 0;

                while(i < numero_ciclos){
                        i++;

                        v_i_1 += d_1;
                        v_i_2 += d_2;
                        v_i_3 += d_3;
                        v_i_4 += d_4;

                        for(int local = 0 ;  local < _locais.Length  ; local++){

                        _locais [ local ] .color = new Color(v_i_1, v_i_2 , v_i_3, v_i_4);

                        }
                        

                        yield return null;

                }

                for(int local_ = 0 ;  local_ < _locais.Length  ; local_++){

                _locais [ local_ ] .color = _cor_final;

                }

                
                yield break;





        }

        




        public static IEnumerator Mudar_scale_generico (  float tempo_ms  , Transform  transform  ,  float _valor ){



                yield return null;

                float count = 0;

                float scale_inicial =   transform.localScale.x;
                float scale_final =   _valor ;

                float variacao =  scale_final - scale_inicial  ;

                float scale_atual = scale_inicial ;

                float numero_ciclos =  60f * ( tempo_ms / 1000f) ;

                float variacao_por_ciclo = variacao / ( float ) numero_ciclos;

               // throw new ArgumentException("");


                while( count < numero_ciclos ){

                        count += 1f;

                        scale_atual += variacao_por_ciclo;

                        transform.localScale =  new Vector3( scale_atual , scale_atual ,  scale_atual );

                        yield return null;

                }
            
                transform.localScale =  new Vector3( _valor, _valor , _valor );
                

                yield break;
                

        }


        





}