using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Botao_ {



        // --- IMAGEM 

        public GameObject OFF_game_object;
        public GameObject TRANS_game_object;
        public GameObject ON_game_object;

        public Image OFF_image;
        public Image TRANS_image;
        public Image ON_image;


        // --- TEXTO

        public GameObject OFF_texto_game_object;
        public GameObject ON_texto_game_object;

        public TextMeshPro OFF_texto;
        public TextMeshPro ON_texto;


        // --- INTERNO

        public float posicao_x;
        public float posicao_y;
        


        // --- IMAGENS

        public Sprite sprite_imagem_off;
        public Color cor_imagem_off;

        public Sprite sprite_imagem_on;
        public Color cor_imagem_on;

        public Sprite sprite_imagem_trans;
        public Color cor_imagem_trans;




        public AudioClip audio_click; 
        public AudioClip audio_houver; 


        public Dados_botao dados;
        public GameObject botao_game_object;




        public static Botao_ Construir( string _path_botao, Dados_botao _dados ){

                Botao_ botao = new Botao_();

                botao.botao_game_object = GameObject.Find( _path_botao );
                if( botao == null )
                    { throw new System.Exception( "Botao nao foi encontrado" ); }


                botao.OFF_game_object =  botao.botao_game_object.transform.GetChild( 0 ).gameObject;
                botao.TRANS_game_object =  botao.botao_game_object.transform.GetChild( 1 ).gameObject;
                botao.ON_game_object =  botao.botao_game_object.transform.GetChild( 2 ).gameObject;
                
                botao.OFF_image =  botao.OFF_game_object.GetComponent<Image>();
                botao.TRANS_image =  botao.TRANS_game_object.GetComponent<Image>();
                botao.ON_image =  botao.ON_game_object.GetComponent<Image>();
                
                
                botao.posicao_x =  botao.botao_game_object.transform.localPosition.x;
                botao.posicao_y =  botao.botao_game_object.transform.localPosition.y;

                return botao;


        }





        // --- AUDIOS



}
