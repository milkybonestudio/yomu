using UnityEngine;

public static class Construtor_tela_jogo {

        public static void Criar_tela( Controlador_tela_conector _controlador ){

                
                        // ---CRIAR TELA

                        _controlador.background_container = new GameObject( "Background_container" );
                        _controlador.background_container.transform.SetParent( _controlador.bloco_conector.container_conector.transform, false ) ;


                            //** main
                        _controlador.background_1 = new GameObject( "Background_1" );
                        _controlador.background_1_image  =  IMAGE.Criar_imagem(
                                                                                    _game_object : _controlador.background_1,
                                                                                    _pai: _controlador.background_container,
                                                                                    _width : 1920f,
                                                                                    _height: 1080f,
                                                                                    _path: null, 
                                                                                    _sprite: null, 
                                                                                    _alpha: 1f
                                                                            );
                            //** suporte para transicao
                        _controlador.background_2 = new GameObject( "Background_2" );
                        _controlador.background_2_image  =  IMAGE.Criar_imagem(
                                                                                    _game_object : _controlador.background_2,
                                                                                    _pai: _controlador.background_container,
                                                                                    _width : 1920f,
                                                                                    _height: 1080f,
                                                                                    _path: null, 
                                                                                    _sprite: null, 
                                                                                    _alpha: 1f
                                                                            );
                        return;
                            
        }


}