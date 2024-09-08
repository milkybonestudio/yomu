using UnityEngine;


public struct Imagem_estatica_botao_dispositivo_parte {


        public Tipo_pegar_sprite tipo_pegar_sprite; 
        public Visibilidade visibilidade_durante_animacao;
        public Visibilidade visibilidade_durante_transicao;
        public int sprite_id_final;
        public int sprite_id;
        public object sprite_id_GERAL;
        public Color cor;
        public Sprite sprite; // usado somente quando nao tiver animacao     



}

public struct Imagem_estatica_botao_dispositivo {


        public Imagem_estatica_botao_dispositivo_parte animacao_back;
        public Imagem_estatica_botao_dispositivo_parte animacao_base;
        public Imagem_estatica_botao_dispositivo_parte animacao_atras_texto;
        public Imagem_estatica_botao_dispositivo_parte animacao_decoracao;
        public Imagem_estatica_botao_dispositivo_parte[] decoracao_composta;
        public Imagem_estatica_botao_dispositivo_parte animacao_frente_texto;

        


        // ** texto
        public string texto;
        public Color texto_cor;
        public Sprite texto_sprite; // usado somente quando nao tiver animacao 
        public TMPro.TMP_FontAsset font;




        // // ** animacao back
        // public Tipo_pegar_sprite animacao_back_tipo_pegar_sprite; 
        // public Visibilidade animacao_back_visibilidade_durante_animacao;
        // public Visibilidade animacao_back_visibilidade_durante_transicao;
        // public int animacao_back_sprite_id_final;
        // public int animacao_back_sprite_id;
        // public object animacao_back_sprite_id_GERAL;
        // public Color animacao_back_cor;
        // public Sprite animacao_back_sprite; // usado somente quando nao tiver animacao 
        


        // // ** base
        // public Tipo_pegar_sprite animacao_base_tipo_pegar_sprite; 
        // public Visibilidade animacao_base_visibilidade_durante_animacao;
        // public Visibilidade animacao_base_visibilidade_durante_transicao;
        // public int animacao_base_sprite_id_final;
        // public int animacao_base_sprite_id;
        // public object animacao_base_sprite_id_GERAL;
        // public Color animacao_base_cor;
        // public Sprite animacao_base_sprite; // usado somente quando nao tiver animacao 
    

        // // ** animacao atras texto
        // public Tipo_pegar_sprite animacao_atras_texto_tipo_pegar_sprite; 
        // public Visibilidade animacao_atras_texto_visibilidade_durante_animacao;
        // public Visibilidade animacao_atras_texto_visibilidade_durante_transicao;
        // public int animacao_atras_texto_sprite_id_final;
        // public int animacao_atras_texto_sprite_id;
        // public object animacao_atras_texto_sprite_id_GERAL;
        // public Color animacao_atras_texto_cor;
        // public Sprite animacao_atras_texto_sprite; // usado somente quando nao tiver animacao 



        // // ** decoracao
        // public Tipo_pegar_sprite animacao_decoracao_tipo_pegar_sprite;
        // public Visibilidade animacao_decoracao_visibilidade_durante_animacao;
        // public Visibilidade animacao_decoracao_visibilidade_durante_transicao;
        // public int animacao_decoracao_sprite_id_final;
        // public int animacao_decoracao_sprite_id;
        // public object animacao_decoracao_sprite_id_GERAL;
        // public Color animacao_decoracao_cor;
        // public Sprite animacao_decoracao_sprite; // usado somente quando nao tiver animacao 


        // // ** decoracao_composta
        // public Tipo_pegar_sprite decoracao_composta_tipo_pegar_sprite;

        // public int animacao_decoracao_sprite_id_final;
        // public int animacao_decoracao_sprite_id;
        // public object animacao_decoracao_sprite_id_GERAL;
        // public Color animacao_decoracao_cor;
        // public Sprite[] sprites_decoracao_composta;






        // // ** animacao frente texto
        // public Tipo_pegar_sprite animacao_frente_texto_tipo_pegar_sprite; 
        // public Visibilidade animacao_frente_texto_visibilidade_durante_animacao;
        // public Visibilidade animacao_frente_texto_visibilidade_durante_transicao;
        // public int animacao_frente_texto_sprite_id_final;
        // public int animacao_frente_texto_sprite_id;
        // public object animacao_frente_texto_sprite_id_GERAL;
        // public Color animacao_frente_texto_cor;
        // public Sprite animacao_frente_texto_sprite; // usado somente quando nao tiver animacao 


}

