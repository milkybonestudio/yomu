using UnityEngine;
using System;


public struct DATA__UI_button_COMPLETE {



        // --- INTERNO


        public string main_folder;
        

        public Botao_dispositivo_tipo_ativacao tipo_ativacao;
        public GameObject botao_game_object;

        // --- LOGICA

        public bool bloquear_update_logico;
        public bool bloquear_update_visual;


        public Action<UI_button> update_para_substituir;
        public Action Update_secundario;
        public Action Ativar;
        public Action Construtor_personalizado;


        // --- RESOURCES 

        public Resource_context context;

        public Resource_audio_content audio_resource_pre_allocation;
        public Resource_image_content image_resource_pre_allocation;

        
        // --- BLOQUEIOS 
        public bool update_visual_bloqueado;


        // --- PARTE VISUAL
        
        public Material device_material;
        public DEVICE_button_transition_type_OFF_ON tipo_transicao;// default botao simples


        // --- GENERAL
        public string text_on;
        public string text_off;


        
        public RESOURCE__audio_ref audio_click;
        public RESOURCE__audio_ref audio_houver;


        // ** SIMPLE
        public float tempo_transicao;
        public float time_transition_ON_to_OFF_SIMPLE;
        public float time_transition_OFF_to_ON_SIMPLE;


        public Button_animation_frame simple_button_ON_frame;
        public Color simple_button_ON_text_color;

        public Button_animation_frame simple_button_OFF_frame;
        public Color simple_button_OFF_text_color;

        
        // ** COMPLETE

            public Button_animation_frame[] complete_button_ON_frames; //  = new Button_animation_frame[ 6 ];
            public Button_animation_frame[] complete_button_OFF_frames; //= new Button_animation_frame[ 6 ];


        // ** COMPLEX

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


        // ?? 
        // --- DECORACAO COMPOSTA SPRITES
        public Sprite[,] sprites_decoracao_composta;
        public Color[,] cores_decoracao_composta;
        public int[,] imagens_localizadores_decoracao_composta_NOVO;



 
        // ** botoes simples nao precisam de animacoes
        public Dados_botao_dispositivo_animacao animacao_botao;

        

}
