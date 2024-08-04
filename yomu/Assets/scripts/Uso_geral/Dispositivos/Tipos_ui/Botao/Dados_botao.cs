using System;
using UnityEngine;
using UnityEngine.UI;



public class Dados_botao {


        // --- INTERNO

        public Botao_tipo_ativacao tipo_ativacao;
        public string nome;


        public System.Action update;
        public System.Action ativar;

        // ** se null => nao muda
        public float[] posicoes;
        public float[] dimensoes;
        
        // ** bloqueio de updates

        public bool update_visual_bloqueado;




        // --- PARTE VISUAL

            // --- IMAGEM OFF

                // ** PARTE ESTATICA

                    public Tipo_pegar_sprite tipo_pegar_sprite_off; 
                    public int sprite_off_id_final;
                    public int sprite_off_id;
                    public string[] chaves_imagem_off;
                    public Color cor_imagem_off  = Cores.clear;
                    public Sprite sprite_off;

                // ** PARTE ANIMADA

                    public bool tem_animacao_imagem_off;

                    public Tipo_pegar_sprite tipo_pegar_sprite_off_animacao; 
                    public int[] imagens_animacao_ids_imagem_off_final;

                    public int[] imagens_animacao_ids_imagem_off;
                    public string[][] chaves_imagens_animacao_ids_imagem_off;
                    public Color[] cores_animacao_imagem_off;
                    public Sprite[] animacao_sprites_off;

                // *** COMPORTAMENTO TRANSICAO
                
                    public Botao_imagem_estado estado_final_imagem_off;
                    public bool pega_transicao_imagem_off;



            // --- IMAGEM ON

                // ** PARTE ESTATICA

                    public Tipo_pegar_sprite tipo_pegar_sprite_on;
                    public int sprite_on_id_final;
                    public int sprite_on_id;
                    public string[] chaves_imagem_on;
                    public Color cor_imagem_on  = Cores.clear;
                    public Sprite sprite_on;

                // ** PARTE ANIMADA

                    public bool tem_animacao_imagem_on;

                    public Tipo_pegar_sprite tipo_pegar_sprite_on_animacao;
                    public int[] imagens_animacao_ids_imagem_on_final;

                    public int[] imagens_animacao_ids_imagem_on;
                    public string[][] chaves_imagens_animacao_ids_imagem_on;
                    public Color[] cores_animacao_imagem_on;
                    public Sprite[] animacao_sprites_on;

                // *** COMPORTAMENTO TRANSICAO
                
                    public Botao_imagem_estado estado_final_imagem_on;
                    public bool pega_transicao_imagem_on;



            // --- TRANSICAO OFF -> ON

                public bool tem_animacao_transicao;

                public Tipo_pegar_sprite tipo_pegar_sprite_transicao_animacao;
                public int[] imagens_animacao_ids_imagem_transicao_final;

                public int[] imagens_animacao_ids_imagem_transicao;
                public string[][] chaves_imagens_animacao_ids_imagem_transicao;
                public Color[] cores_animacao_imagem_transicao;
                public Sprite[] sprites_animacao_transicao;



        // --- AUDIOS

            public AudioClip audio_click; 
            public AudioClip audio_houver; 




}
