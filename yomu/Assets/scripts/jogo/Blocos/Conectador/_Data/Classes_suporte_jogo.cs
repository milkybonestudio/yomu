
    
using UnityEngine.UI;
using UnityEngine;
using System;







public enum Interativo_tipo_mouse_hover{
    
    nada_E_nada = -1,
    nada_E_one = 0, 
    one_E_one  = 1, 
    one_E_two =  2,
    one_80_E_one_100 = 3
    
}

public enum Tipo_interativo{

    movimento = 1,
    personagem = 2,
    item = 3,
    cenas = 4,
    utilidade = 5,

}





public enum Tipo_get_interativo{

    nao_altera = 0,
    dia_E_noite = 1,
    nome = 3,
    
}





public enum Jogo_update_tipo{

        NADA = -1,     

        movimento = 0,
        utilidades = 1,
        conversas = 2,


}



public class Jogo_TO_utilidades_data{

        // public Interativo_ui interativos_ui;
        // public Tipo_display_jogo_utilidades tipo_display;


}












public class Ponto_data {

        
        public int ponto_id;
        public string folder_path;

        public bool tem_flip = false;
        public int ponto_flip = -1;


        public Interativo_nome[][] interativos_default_2d;


        public Tipo_get_ponto_data tipo_get_interativos_default;


        public string background_default_name;
        public Tipo_get_ponto_data tipo_get_background;


        // ??
        //mark
        public static string Pegar_nome_background_por_script( Ponto_nome _ponto_nome ){ return Background_scripts_jogo.Pegar_nome( _ponto_nome );}
        public static Interativo_nome[] Pegar_interativos_por_script (Ponto_nome _ponto_nome){  return Interativos_script_jogo.Pegar_interativos( _ponto_nome );  }
        

    
}








public class Utilidade_data {


    public Imagem_simples_data imagem_simples_data = null;
    

}



  public class Imagem_simples_data {



          public string nome = "default";
          public float width = 0f ;
          public float height = 0f ;
          public string image_path = null ;
          public float position_x = 960f;
          public float position_y = 540f;
          public int clicks_para_ignorar = 0;
          public int frames_para_ignorar = 0;
          public Action fn_click = null;


  }














    
