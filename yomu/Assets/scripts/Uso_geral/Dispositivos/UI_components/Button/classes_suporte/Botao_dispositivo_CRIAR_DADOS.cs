using UnityEngine;

public static class TOOL__button_device_composed_decoration {


        public static void Create_simple( Dados_botao_dispositivo _dados, string[] _paths, Color _cor_off, Color _cor_on ){


                // ** so cria os arrays com as imagens compostas estaticas, nao faz animacao
                // ** nesse cenario em off e on tem que ser iguais

                DEVICE_button_static_image[] off_arr = new DEVICE_button_static_image[ _paths.Length ];
                DEVICE_button_static_image[] on_arr = new DEVICE_button_static_image[ _paths.Length ];

                for( int index = 0 ; index < _paths.Length ; index++ ){

                        off_arr[ index ].image_path = _paths[ index ];
                        off_arr[ index ].cor = _cor_off;

                        on_arr[ index ].image_path = _paths[ index ];
                        on_arr[ index ].cor = _cor_on;
                        
                        continue;

                }


                _dados.off.decoracao_composta = off_arr;
                _dados.on.decoracao_composta = on_arr;

                return;


        }




        static string b = "a";

        public static void Create_complex( Dados_botao_dispositivo _dados, string[,] _paths, Color _cor_off, Color _cor_on ){


                string[,] s = new string[,]{

                    { Get( "image_1" ), Get("image_2") },
                    { Get( "a" ), Get( "b" ) },

                };


                string Get( string _s ){

                        return ( b + _s );

                }

                // _paths[  ( numero de imagens por frame ),  ]



                // // ** so cria os arrays com as imagens compostas estaticas, nao faz animacao
                // // ** nesse cenario em off e on tem que ser iguais

                // DEVICE_button_static_image[] off_arr = new DEVICE_button_static_image[ _paths.Length ];
                // DEVICE_button_static_image[] on_arr = new DEVICE_button_static_image[ _paths.Length ];

                // for( int index = 0 ; index < _paths.Length ; index++ ){

                //         off_arr[ index ].image_path = _paths[ index ];
                //         off_arr[ index ].cor = _cor_off;

                //         on_arr[ index ].image_path = _paths[ index ];
                //         on_arr[ index ].cor = _cor_on;
                        
                //         continue;

                // }


                // _dados.off.decoracao_composta = off_arr;
                // _dados.on.decoracao_composta = on_arr;

                // return;


        }



}

