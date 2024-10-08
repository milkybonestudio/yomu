using UnityEngine;


// Imagem_estatica_botao_dispositivo_parte
public struct DEVICE_button_static_image{

        public string image_path; 
        public Color cor;

}

public struct Imagem_estatica_botao_dispositivo {


        public DEVICE_button_static_image animacao_back;
        public DEVICE_button_static_image animacao_base;
        public DEVICE_button_static_image animacao_atras_texto;
        public DEVICE_button_static_image animacao_decoracao;
        public DEVICE_button_static_image[] decoracao_composta;
        public DEVICE_button_static_image animacao_frente_texto;

        


        // ** texto
        public string texto;
        public Color texto_cor;
        public Sprite texto_sprite; // usado somente quando nao tiver animacao 
        public TMPro.TMP_FontAsset font;



}

