
using UnityEngine.UI;
using UnityEngine;
using System;



/*

        nao tem problema ter varias coisas pois só vai ficar criados os interativos necessarios 

*/

 public class Interativo {



        public Interativo( int _index_int ){

                this.interativo_nome = (  Interativo_nome ) _index_int ;
        }



        public Tipo_interativo tipo;

   
        public Interativo_nome interativo_nome;
        public Ponto_nome ponto_nome;

        public int id_arr = 0;

 

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

        public Ponto_nome ponto_destino;

        public Personagem_nome personagem;
        public string  conversa_nome = null ;



        public int item;

        
      //  public Utilidade_localizador utilidade_localizador;


        public Nome_screen_play nome_screen_play;
        
        
        //  script => cena




}

