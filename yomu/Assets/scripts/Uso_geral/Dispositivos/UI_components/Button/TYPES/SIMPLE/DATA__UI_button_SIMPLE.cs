using UnityEngine;
using System;

public struct DATA__UI_button_SIMPLE {


        // precisa sair
        public string name;
        public string main_folder;
        public Resource_context context;
        public Material device_material;

        public Botao_dispositivo_tipo_ativacao tipo_ativacao;
        public DEVICE_button_transition_type_OFF_ON tipo_transicao;// default botao simples

        // --- RESOURCES
        
        public Resource_audio_content audio_resource_pre_allocation;
        public Resource_image_content image_resource_pre_allocation;


        // --- BLOQUEIOS 
        public bool bloquear_update_logico;
        public bool bloquear_update_visual;
        public bool update_visual_bloqueado;
        

        // --- TIMES
        public float time_transition_ON_to_OFF;
        public float time_transition_OFF_to_ON;


        // --- FUNCTIONS
        public Action Activate;

        
        // --- GENERAL
        public string text_on;
        public string text_off;

        
        public Color base_OFF_color;
        public Color base_ON_color;

        // --- VISUAL 

            // --- SIMPLE
            public string image_path_OFF;
            public string image_path_ON;



        public Action<UI_button> update_para_substituir;
        public Action Ativar;
        


        // // --- RESOURCES 
        
        public RESOURCE__audio_ref audio_click;
        public RESOURCE__audio_ref audio_houver;



        public Button_animation_frame button_ON_frame;
        public Color button_ON_text_color;

        public Button_animation_frame button_OFF_frame;
        public Color button_OFF_text_color;


}


