using UnityEngine;
using UnityEngine.UI;




public class Interativo_tela {


        public Interativo_tela( byte _interativo_id ){

                interativo_id = _interativo_id ;
        }


        #if UNITY_EDITOR
                public string nome = "";
        #endif
        

        // --- DADOS IMAGENS

                public short sprite_imagem_1_id_unico;
                public short sprite_imagem_2_id_unico;


                // --- CORES
                
                public short cor_imagem_1_id; 
                public short cor_imagem_2_id;


                // --- MOUSE 

                public int cor_cursor_id;
                public int som_click_id;
                public int som_houver_id;


                // --- MATERIAL

                public int material_id_imagem_1;
                public int material_id_imagem_2;


                public float[] posicao;
                public float[] area;



        // --- LOGICA

                public byte interativo_id;
                public Tipo_interativo_tela tipo_interativo_tela;
                public byte[] dados_logicas_interativos_tela; // vai interpretar na hora 

        



        // public Cartas_combate_localizador cartas_combate_localizador;
        // public Utilidade_localizador utilidade_localizador;
        // public Screen_play_localizador screen_play_localizador;
        // public Conversa_localizador conversa_localizador;
        // public Script_localizador script_localizador;
        // public Posicao posicao_destino; // movimento => ponto que vai
        // public Item_localizador item_localizador; 
        // public Plot_localizador plot_localizador;





}
