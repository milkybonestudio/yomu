using UnityEngine;

public static class Botao_dispositivo_CRIAR_DADOS {


        public static Imagem_estatica_botao_dispositivo_parte[] Pegar_decoracao_composta( int[] _ids, Color _cor ){

                Imagem_estatica_botao_dispositivo_parte[] retorno = new Imagem_estatica_botao_dispositivo_parte[ _ids.Length ];

                for( int index = 0 ; index < _ids.Length ; index++ ){

                    retorno[ index ]  = new Imagem_estatica_botao_dispositivo_parte();
                    retorno[ index ].sprite_id = _ids[ index ];
                    retorno[ index ].cor = _cor;
                    continue;

                }

                return retorno;


        }


        public static Imagem_estatica_botao_dispositivo_parte[] Pegar_decoracao_composta_GERAL( object[] _ids, Color _cor ){

                Imagem_estatica_botao_dispositivo_parte[] retorno = new Imagem_estatica_botao_dispositivo_parte[ _ids.Length ];

                for( int index = 0 ; index < _ids.Length ; index++ ){

                    retorno[ index ]  = new Imagem_estatica_botao_dispositivo_parte();
                    retorno[ index ].sprite_id_GERAL = _ids[ index ];
                    retorno[ index ].cor = _cor;
                    continue;

                }

                return retorno;


        }



        public static void Criar_decoracao_composta_simples( Dados_botao_dispositivo _dados, int[] _ids, Color _cor_off, Color _cor_on ){



                Imagem_estatica_botao_dispositivo_parte[] off_arr = new Imagem_estatica_botao_dispositivo_parte[ _ids.Length ];
                Imagem_estatica_botao_dispositivo_parte[] on_arr = new Imagem_estatica_botao_dispositivo_parte[ _ids.Length ];

                for( int index = 0 ; index < _ids.Length ; index++ ){

                    //off_arr[ index ]  = new Imagem_estatica_botao_dispositivo_parte();
                    off_arr[ index ].sprite_id = _ids[ index ];
                    off_arr[ index ].cor = _cor_off;


                    //off_arr[ index ]  = new Imagem_estatica_botao_dispositivo_parte();
                    on_arr[ index ].sprite_id = _ids[ index ];
                    on_arr[ index ].cor = _cor_on;
                    

                    continue;

                }

                _dados.off.decoracao_composta = off_arr;
                _dados.on.decoracao_composta = on_arr;

                return;


        }





}