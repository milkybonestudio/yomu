using UnityEngine;

public static class Construtor_tela_conector {


        public static void Criar_tela( Controlador_tela_conector controlador ){

                controlador.bloco_interacao = BLOCO_interacao.Pegar_instancia();


        
                // ---CRIAR TELA

                controlador.background_container = new GameObject( "Background_container" );
                controlador.background_container.transform.SetParent( controlador.container_conector.transform, false ) ;


                        //** main
                controlador.background_1 = new GameObject( "Background_1" );
                controlador.background_1_image  =  IMAGE.Criar_imagem(
                                                                                _game_object : controlador.background_1,
                                                                                _pai: controlador.background_container,
                                                                                _width : 1920f,
                                                                                _height: 1080f,
                                                                                _path: null, 
                                                                                _sprite: null, 
                                                                                _alpha: 1f
                                                                        );
                        //** suporte para transicao
                controlador.background_2 = new GameObject( "Background_2" );
                controlador.background_2_image  =  IMAGE.Criar_imagem(
                                                                                _game_object : controlador.background_2,
                                                                                _pai: controlador.background_container,
                                                                                _width : 1920f,
                                                                                _height: 1080f,
                                                                                _path: null, 
                                                                                _sprite: null, 
                                                                                _alpha: 1f
                                                                        );
                return;
                        
        }


}