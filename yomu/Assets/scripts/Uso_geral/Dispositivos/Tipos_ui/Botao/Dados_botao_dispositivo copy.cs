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

        // --- LOGICA

        public bool bloquear_update_logico;
        public bool bloquear_update_visual;


        public Action<Botao_dispositivo> update_para_substituir;
        public Action update_secundario;
        public Action ativar = () => { Debug.Log( "nao foi colocado" ); };



        // ** se null => nao muda
        public float[] posicoes;
        public float[] dimensoes;
        
        // ** bloqueio de updates

        public bool update_visual_bloqueado;

        // --- DADOS ANIMACOES

        // ** off
        public float animacao_off_tempo_espera_ms = 2_000f;
        public float animacao_off_tempo_troca_sprite_ms = 250f;
        public float[] animacao_off_tempo_troca_sprite_ms_por_sprite;

        // ** on
        public float animacao_on_tempo_espera_ms = 2_000f;
        public float animacao_on_tempo_troca_sprite_ms = 250f;
        public float[] animacao_on_tempo_troca_sprite_ms_por_sprite;

        // ** transicao
        public float animacao_transicao_tempo_espera_ON_para_OFF_ms = 100f; // usado transicao cor
        public float animacao_transicao_tempo_troca_sprite_ON_para_OFF_ms = 1000f;
        public float[] animacao_transicao_tempo_troca_sprite_ON_para_OFF_ms_por_sprite;

        public float animacao_transicao_tempo_espera_OFF_para_ON_ms = 1000f; // usado transicao cor
        public float animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms = 250f;
        public float[] animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms_por_sprite;




        // --- EXCLUSIVO CRIACAO
        
            public bool sprites_OFF_e_ON_iguais;


        //public bool sprites_OFF_e_ON_iguais;



        // --- PARTE VISUAL

                    public Material material_dispositivo;

            // --- IMAGEM OFF

                // ** PARTE ESTATICA

                    // ** logica
                    public bool imagem_off_vazio;
                    public Botao_imagem_estado comportamento_imagem_off_animacao;
                    public Botao_imagem_estado comportamento_imagem_off_transicao_OFF_para_ON;
                    public Botao_imagem_estado comportamento_imagem_off_transicao_ON_para_OFF;

                    // ** criacao
                    public Tipo_pegar_sprite tipo_pegar_sprite_off; 
                    public int sprite_off_id_final;
                    public int sprite_off_id;
                    public object sprite_off_geral_id;

                    // ** dados
                    public Color cor_imagem_off  = Cores.cor_default_dispositivo;
                    public Sprite sprite_off;

                // ** PARTE ANIMADA

                    // ** logica
                    public bool manter_imagem_principal_OFF;
                    public bool manter_texto_animacao_OFF; 
                    public bool manter_primeira_sprite_aparente_animacao_OFF;


                    // ** criacao
                    public Tipo_pegar_sprite tipo_pegar_sprite_off_animacao; 
                    public int[] sprites_ids_animacao_off_final;
                    public int[] sprites_ids_animacao_off;
                    public object[] sprites_ids_animacao_off_geral;
                    
                    // ** dados
                    public Color[] cores_animacao_imagem_off;
                    public Sprite[] animacao_sprites_off;



            // --- IMAGEM ONN

                // ** PARTE ESTATICA

                    // ** logica
                    public bool imagem_on_vazio;
                    public Botao_imagem_estado comportamento_imagem_on_animacao;
                    public Botao_imagem_estado comportamento_imagem_on_transicao_OFF_para_ON;
                    public Botao_imagem_estado comportamento_imagem_on_transicao_ON_para_OFF;

                    // ** criacao
                    public Tipo_pegar_sprite tipo_pegar_sprite_on; 
                    public int sprite_on_id_final;
                    public int sprite_on_id;
                    public object sprite_on_geral_id;

                    // ** dados
                    public Color cor_imagem_on  = Cores.cor_default_dispositivo;
                    public Sprite sprite_on;

                // ** PARTE ANIMADA

                    // ** logica
                    public bool manter_imagem_principal_ON;
                    public bool manter_texto_animacao_ON; 
                    public bool manter_primeira_sprite_aparente_animacao_ON;


                    // ** criacao
                    public Tipo_pegar_sprite tipo_pegar_sprite_on_animacao; 
                    public int[] sprites_ids_animacao_on_final;
                    public int[] sprites_ids_animacao_on;
                    public object[] sprites_ids_animacao_on_geral;
                    
                    // ** dados
                    public Color[] cores_animacao_imagem_on;
                    public Sprite[] animacao_sprites_on;



            // --- TRANSICAO

                public Tipo_transicao_botao_OFF_ON_dispositivo tipo_transicao;
                public float tempo_transicao_cor_ms = 75f;


            // --- TRANSICAO OFF -> ON

                // ** logica
                public bool manter_texto_transicao_OFF_para_ON;

                // ** criacao
                public Tipo_pegar_sprite tipo_pegar_sprite_transicao_OFF_para_ON;
                public int[] sprites_ids_transicao_OFF_para_ON_final;
                public int[] sprites_ids_transicao_OFF_para_ON;
                public object[] sprites_ids_transicao_OFF_para_ON_geral;

                // ** dados
                public Color[] cores_transicao_OFF_para_ON;
                public Sprite[] sprites_transicao_OFF_para_ON;



            // --- TRANSICAO OFF -> ON

                public bool manter_texto_transicao_ON_para_OFF;

                public Tipo_pegar_sprite tipo_pegar_sprite_transicao_ON_para_OFF;
                public int[] sprites_ids_transicao_ON_para_OFF_final;
                public int[] sprites_ids_transicao_ON_para_OFF;

                public object[] sprites_ids_transicao_ON_para_OFF_geral;
                public Color[] cores_transicao_ON_para_OFF;
                public Sprite[] sprites_transicao_ON_para_OFF;




        // --- AUDIOS

            public AudioClip audio_click; 
            public AudioClip audio_houver; 




}
