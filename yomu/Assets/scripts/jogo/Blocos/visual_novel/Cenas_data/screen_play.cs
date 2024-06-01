using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






public class Screen_play {



        // screen tem os dados referentes a um cena que vai acontecer no jogo 
        /*


            eu acho que Figure_dados tem que estar aqui 
        
        */


        public Screen_play( string[] _dados_compilados = null ) {



            if( _dados_compilados == null ) return;

            
            int numero_dados_compilados = _dados_compilados.Length;

            this.cenas = new Cena[ numero_dados_compilados ];

            for ( int cena_index = 0; cena_index < numero_dados_compilados  ; cena_index++ ){ 

                    string cena_str = _dados_compilados[ cena_index ] ;
                    this.cenas[ cena_index ] = new Cena( cena_str ) ;

            }

        }



        public bool set_foi_ativado = false;
        public bool esta_ativo = false;


  

        public int cena_atual = 0;
        public int pergunta_id_atual = -1;



        public string path_background_atual = null;
        public int background_cor_id = 2 ; // white


        public string audio_atual = "0";
    





        public int personagem_texto_atual = -1;
        public string texto_atual = "";
        public string nome_display = "";
        public int tipo_texto = 0;

        public int cor_texto_atual_id = 0;
        public int cor_pergaminho_id = 0 ;
        public int tipo_pergaminho_id = 0;

        public int posicao_pergaminho_atual_id = 0;


        public bool is_highlight_activate = true;
                    
        public bool is_sombras_activate = false;
        public bool is_tamanho_activate = false;

        public int foco_camera_personagens_atual_id = 0;
        public char foco_camera_personagens_instantaneo = '0';




        public void Aumentar_contador_cena(){ this.cena_atual++; }
        public void Diminuir_contador_cena(){ this.cena_atual--; }
        public void Setar_contador_cena(int _nova_cena){ cena_atual = _nova_cena; }


        


        public int[] linhas_localizador_cenas;


        public string[]  pointer_id_str;
        public int[]     pointers_cenas_ids;

        
        /*

            personagens_paths_imagens => figures      clothes@happy@esquerda => clothes@happy@esquerda&(1500)(1420)&&(00)(00)

        
        */


        public string[] nomes_personagens;
        public string[][] personagens_paths_imagens;



        public string[] perguntas;
        public string[][] possiveis_respostas;






        public int[] todas_as_respostas_dadas;





        public int[] personagens_POR_index ;



        public Cena[] cenas;

        public Cena Pegar( int _index ){

            return cenas[ _index ];
            
        }

        public Cena Pegar_cena_atual(){

            return cenas[ cena_atual ];

        }


        public int Pegar_cena_id_por_pointer( string _pointer , int script){

                for( int i = 0 ; i < _pointer.Length ; i++){

                        if( pointer_id_str[ i ] == _pointer ){

                              return pointers_cenas_ids[ i ];

                        }

                }

                throw new ArgumentException("nao foi achado pointer em run no script "  +  script    +  ". pointer: " + _pointer);

        }


        public string Pegar_cena_texto_anterior(){

            
            return this.cenas[ this.cena_atual - 1  ].cena_texto;

        }

        
        

}



