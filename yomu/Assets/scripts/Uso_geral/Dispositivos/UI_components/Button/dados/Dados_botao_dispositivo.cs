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



        // --- INTERNO

        public string nome_dispositivo;
        public Botao_dispositivo_tipo_ativacao tipo_ativacao;
        public string nome;
        public GameObject botao_game_object;

        // --- LOGICA

        public bool bloquear_update_logico;
        public bool bloquear_update_visual;


        public Action<Botao_dispositivo> update_para_substituir;
        public Action Update_secundario;
        public Action Ativar = VOID.Metodo_nao_colocado;
        public Action Construtor_personalizado = VOID.Metodo_nao_colocado;

        
        // ** bloqueio de updates
        public bool update_visual_bloqueado;

        // --- EXCLUSIVO CRIACAO
        
            public bool sprites_OFF_e_ON_iguais;
            public float tempo_transicao = 75f;  // ** USADO SOMENTE QUANDO NAO TEM "ANIMACAO BOTAO"
            

        //mark
        // ANTIGO

        // --- PARTE VISUAL


        // public Material material_dispositivo;
        public Material device_material;

        public DEVICE_button_transition_type_OFF_ON tipo_transicao;// default botao simples

        // [  fixo  , variavel ]

        public Sprite[,] sprites_animacoes_completas;
        public Color[,] cores_animacoes_completas;





        public Dados_para_criar_botao_localizador_imagens[,] imagens_localizadores; // usado somente para construir
        public string[,] imagens_localizadores_NOVO; // usado somente para construir




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
        public Dados_para_criar_botao_localizador_imagens[,] imagens_localizadores_decoracao_composta;
        public int[,] imagens_localizadores_decoracao_composta_NOVO;



        // ** botoes simples nao precisam de animacoes
        public Dados_botao_dispositivo_animacao animacao_botao;

        



        // --- AUDIOS

            public AudioClip audio_click;
            public AudioClip audio_houver;




}