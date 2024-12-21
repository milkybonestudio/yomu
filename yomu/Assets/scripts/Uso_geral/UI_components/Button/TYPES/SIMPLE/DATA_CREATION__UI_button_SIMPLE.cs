using System;
using UnityEngine;

public struct DATA_CREATION__UI_button_SIMPLE {

    // ** no simples não faz muito sentido separar em DATA_CREATION / DATA porque as coisas sao muito simples
    // ** vai fazer mais sentido no completo em diante onde certas coisas podem ser mais optimizadas 
    // ** como colocar a cor base de toda uma categoria como grey_90, ou ter um numero para ir de grey para black% 

    // ** mas para manter o padrao vai ser o mesmo no simples, todos os dados uteis tem que entrar no creation e ser usados no data


        public string name;

        // ** fica dificil de saber que é de uma imagem 
        public string main_folder;
        public Resource_context context;
        public Material material;

        public UI_button_activation_type tipo_ativacao;
        public DEVICE_button_transition_type_OFF_ON tipo_transicao;// default botao simples

        // --- RESOURCES
        
        public Resource_audio_content audio_resource_pre_allocation;
        public Resource_image_content image_resource_pre_allocation;


        // --- BLOQUEIOS 
        public bool bloquear_update_logico;
        public bool bloquear_update_visual;
        public bool update_visual_bloqueado;

        // --- TIMES
        public float tempo_transicao;
        public float time_transition_ON_to_OFF;
        public float time_transition_OFF_to_ON;


        // --- FUNCTIONS
        public Action Activate;

        
        // --- GENERAL
        public string text;
        public string text_on;
        public string text_off;

        public Color base_color;
        public Color base_OFF_color;
        public Color base_ON_color;

        // --- VISUAL 

            // --- SIMPLE
            public string image_path;
            public string image_path_OFF;
            public string image_path_ON;



}