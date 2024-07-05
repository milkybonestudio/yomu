
using UnityEngine.UI;
using UnityEngine;
using System;



/*

        nao tem problema ter varias coisas pois só vai ficar criados os interativos necessarios 

*/

/*

        interativo_tela 
        interativo_personagem
        interativo_item

*/


// excluir depois
public enum Tipo_get_interativo {
            nao_altera = 0, // ""
    dia_E_noite = 1, // "_d" ou "_n"
    todos_os_periodos, // "_0", "_1", "_2", "_3", "_4" 
    nome = 3, // "_especifico"

}

 public class Interativo {


        public Interativo( int _index_int ){

                interativo_id =  _index_int ;
        }



        public Tipo_interativo tipo;


        public int interativo_id;
        public int ponto_id;

 






        //   default 
        
        public float[] posicao; // tem que cuidar pois é novo. Agora a imagem nao vai ser full hd

        public Interativo_tipo_mouse_hover tipo_mouse_hover;

        public Tipo_get_interativo tipo_get;

        public string nome; 

        public Cor_cursor cor_cursor;

        public Image image_slot;

        public Sprite interativo_image_1;
        public Color cor_image_1;
        
        public Sprite interativo_image_2;
        public Color cor_image_2;

        public float[] area;
        public bool hover_esta_ativo;


        public Script_jogo_nome script_jogo_nome = Script_jogo_nome.nada; 


        //  especificos


        public Personagem_nome personagem;
        public string  conversa_nome = null ;



        public int item;

        
      //  public Utilidade_localizador utilidade_localizador;


        public Nome_screen_play nome_screen_play;
        
        
        //  script => cena




}

