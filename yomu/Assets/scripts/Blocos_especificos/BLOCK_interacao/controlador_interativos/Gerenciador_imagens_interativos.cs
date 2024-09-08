using System;
using UnityEngine;
using UnityEngine.UI;


public class Gerenciador_imagens_interativos {


    public Gerenciador_imagens_interativos(){

            // ** so vai ser criado no inicio de um novo save

            #if !UNITY_EDITOR

                byte[] localizador_interativos_imagens = System.IO.File.ReadAllBytes( Paths_sistema.path_arquivo__localizador__interativos_logica );

                leitor_de_arquivos  =  new MODULO__leitor_de_arquivos  ( 
                                                                            _gerenciador_nome   :  "Manipulador_imagens_interativos" , 
                                                                            _path_folder  :  Paths_sistema.path_arquivo__dados_estaticos__uso_parcial__interativos_imagens, 
                                                                            _numero_inicial_de_slots  :  50
                                                                        );
                return;

            #endif

    }


    public MODULO__leitor_de_arquivos leitor_de_arquivos;


    #if UNITY_EDITOR

        // *** no editor tem o path absoluto para as imagens como é definido no construtor_DEVELOPMENT
        // *** contrutor vai modificar esses campos
        // *** imagens sao sempre descartadas e recriadas no editor
        public static string[] paths_imagens_DEVELOPMENT;
        public static int poiner_imagem = -1;
        

        public Sprite Pegar_sprite_interativo(  Locator_position _posicao, int _interativo_sprite_id ){

                // ** id => index 

                if( paths_imagens_DEVELOPMENT.Length >= _interativo_sprite_id )
                    { throw new Exception( $"tentou carregar o id { _interativo_sprite_id } mas os paths tinham length { paths_imagens_DEVELOPMENT.Length }" ); }


                string path_imagem = paths_imagens_DEVELOPMENT[ _interativo_sprite_id ];

                if( !( System.IO.File.Exists( path_imagem ) ) )
                    { throw new Exception( $" nao existia imagem no path { path_imagem }" );}


                byte[] png = System.IO.File.ReadAllBytes( path_imagem );
                Sprite sprite = SPRITE.Transformar_png_TO_sprite( png );
                
                return sprite;


        }


        public void Carregar_sprite( Locator_position _posicao, int _interativo_id ){

            // --- NA BUILD SEMPRE VAI CARREGAR TUDO NA MAIN THREAD
            return;
        
        }


    #endif







}
