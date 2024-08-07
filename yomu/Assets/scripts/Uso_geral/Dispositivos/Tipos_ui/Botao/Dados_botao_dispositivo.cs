using System;
using UnityEngine;
using UnityEngine.UI;




public class Dados_botao_dispositivo {


        // --- SUPORTE 

        public string nome_dispositivo;

        // --- INTERNO

        public Botao_dispositivo_tipo_ativacao tipo_ativacao;
        public string nome;
        public GameObject botao_game_object;


        public Action<Botao_dispositivo> update_para_substituir;
        public Action update_secundario;
        public Action ativar = ()=> { Debug.Log( "nao foi colocado" ); };

        // ** se null => nao muda
        public float[] posicoes;
        public float[] dimensoes;
        
        // ** bloqueio de updates

        public bool update_visual_bloqueado;

        public float animacao_off_tempo_espera_ms = 2_000f;
        public float animacao_off_tempo_troca_sprite_ms = 50f;
        public float animacao_on_tempo_espera_ms = 2_000f;
        public float animacao_on_tempo_troca_sprite_ms = 50f;

        public float animacao_transicao_tempo_troca_sprite_ON_para_OFF_ms = 50f;
        public float animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms = 50f;

        public bool bloquear_update_logico;
        public bool bloquear_update_visual;



        // --- dados para criar pre feitos
        
        public bool sprites_OFF_e_ON_iguais;

        //public bool sprites_OFF_e_ON_iguais;



        // --- PARTE VISUAL

                    public Material material_dispositivo;

            // --- IMAGEM OFF

                // ** PARTE ESTATICA

                    public Tipo_pegar_sprite tipo_pegar_sprite_off; 
                    public int sprite_off_id_final;

                    public bool imagem_off_vazio;
                    public int sprite_off_id;
                    public string[] chaves_imagem_off;

                    public Color cor_imagem_off  = Cores.cor_default_dispositivo;
                    public Sprite sprite_off;

                // ** PARTE ANIMADA

                    

                    public bool manter_imagem_principal_OFF;

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

                    public bool imagem_on_vazio;
                    public Tipo_pegar_sprite tipo_pegar_sprite_on;
                    public int sprite_on_id_final;
                    public int sprite_on_id;
                    public string[] chaves_imagem_on;
                    public Color cor_imagem_on  = Cores.cor_default_dispositivo;
                    public Sprite sprite_on;

                // ** PARTE ANIMADA

                    
                    public bool manter_imagem_principal_ON;

                    public Tipo_pegar_sprite tipo_pegar_sprite_on_animacao;
                    public int[] imagens_animacao_ids_imagem_on_final;

                    public int[] imagens_animacao_ids_imagem_on;
                    public string[][] chaves_imagens_animacao_ids_imagem_on;
                    public Color[] cores_animacao_imagem_on;
                    public Sprite[] animacao_sprites_on;

                // *** COMPORTAMENTO TRANSICAO
                
                    public Botao_imagem_estado estado_final_imagem_on;
                    public bool pega_transicao_imagem_on;



            // --- TRANSICAO

                public Tipo_transicao_botao_OFF_ON_dispositivo tipo_transicao;
                public float tempo_transicao_cor_ms = 75f;


            // --- TRANSICAO OFF -> ON

                public Tipo_pegar_sprite tipo_pegar_sprite_transicao_animacao_OFF_para_ON;
                public int[] imagens_animacao_ids_imagem_transicao_final_OFF_para_ON;

                public int[] imagens_animacao_ids_imagem_transicao_OFF_para_ON;
                public string[][] chaves_imagens_animacao_ids_imagem_transicao_OFF_para_ON;
                public Color[] cores_animacao_imagem_transicao_OFF_para_ON;
                public Sprite[] sprites_animacao_transicao_OFF_para_ON;



            // --- TRANSICAO OFF -> ON

                public Tipo_pegar_sprite tipo_pegar_sprite_transicao_animacao_ON_para_OFF;
                public int[] imagens_animacao_ids_imagem_transicao_final_ON_para_OFF;

                public int[] imagens_animacao_ids_imagem_transicao_ON_para_OFF;
                public string[][] chaves_imagens_animacao_ids_imagem_transicao_ON_para_OFF;
                public Color[] cores_animacao_imagem_transicao_ON_para_OFF;
                public Sprite[] sprites_animacao_transicao_ON_para_OFF;




        // --- AUDIOS

            public AudioClip audio_click; 
            public AudioClip audio_houver; 




}
