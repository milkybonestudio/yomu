using System;
using UnityEngine;
using UnityEngine.UI;



public class Dados_botao_dispositivo {


        public Dados_botao_dispositivo(){


                // --- DEFAULT MULTIPLICADOR 
                animacao_off_tempos.multiplicador_saida_padrao_animacao = 3f;
                animacao_on_tempos.multiplicador_saida_padrao_animacao = 3f;
                animacao_ON_para_OFF_tempos.multiplicador_saida_padrao_animacao = 3f;
                animacao_OFF_para_ON_tempos.multiplicador_saida_padrao_animacao = 3f;


        }


        public Resource_use_state state;

        // --- INTERNO

        public string nome_dispositivo;

        public string main_folder;
        public string nome;
        

        public Botao_dispositivo_tipo_ativacao tipo_ativacao;
        public GameObject botao_game_object;

        // --- LOGICA

        public bool bloquear_update_logico;
        public bool bloquear_update_visual;


        public Action<Botao_dispositivo> update_para_substituir;
        public Action Update_secundario;
        public Action Ativar = VOID.Metodo_nao_colocado;
        public Action Construtor_personalizado = VOID.Metodo_nao_colocado;

        
        // --- BLOQUEIOS 
        public bool update_visual_bloqueado;


        // --- EXCLUSIVO CRIACAO
        

        public bool sprites_OFF_e_ON_iguais;
        public float tempo_transicao = 75f;
        


        // --- PARTE VISUAL
        
        public Material device_material;
        public DEVICE_button_transition_type_OFF_ON tipo_transicao;// default botao simples


        // --- GENERAL

        public string text_on;
        public string text_off;


        // ** SIMPLE

        public Button_animation_frame simple_button_ON_frame;
        public Button_animation_frame simple_button_OFF_frame;

        
        // ** COMPLETE

        public Button_animation_frame[] complete_button_ON_frames = new Button_animation_frame[ 6 ];
        public Button_animation_frame[] complete_button_OFF_frames = new Button_animation_frame[ 6 ];


        // ** COMPLETE WITH ANIMATION

        // ** provavelmente vai usar multiplos para as transicoes ou todos de uma categoria vao ser. 
        // ** recisa esperar multiplos

        // [  fixo  , variavel ]
        public RESOURCE__image_ref[,]  images_refs_animacoes_completas;
        public Color[,] cores_animacoes_completas;



        //public string[,] imagens_localizadores_NOVO; // usado somente para construir



        public Botao_dispositivo_partes_pointers pointers;



        // ** no minimo imagem off e imagem on 
        public Imagem_estatica_botao_dispositivo off;
        public Imagem_estatica_botao_dispositivo on;



        // ** tempos
        public Tempos_animacao_botao_dispositivo animacao_off_tempos;
        public Tempos_animacao_botao_dispositivo animacao_on_tempos;
        public Tempos_animacao_botao_dispositivo animacao_ON_para_OFF_tempos;
        public Tempos_animacao_botao_dispositivo animacao_OFF_para_ON_tempos;



        // --- DECORACAO COMPOSTA SPRITES
        public Sprite[,] sprites_decoracao_composta;
        public Color[,] cores_decoracao_composta;
        public int[,] imagens_localizadores_decoracao_composta_NOVO;




        // ** botoes simples nao precisam de animacoes
        public Dados_botao_dispositivo_animacao animacao_botao;

        



        // --- AUDIOS

            public AudioClip audio_click;
            public AudioClip audio_houver;




}