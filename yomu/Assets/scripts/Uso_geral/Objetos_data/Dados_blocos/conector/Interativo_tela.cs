using UnityEngine;
using UnityEngine.UI;




public class Interativo_tela {


        public Interativo_tela( int _index_id ){

                interativo_id = _index_id ;
        }


        
        public string nome = ""; // excluir depois


        public int interativo_id;
        public int tipo_interativo_id;
        public int ponto_id;


        // ** tudo vai ser descartado e reiniciado durante a troca de dias 

        // --- DEFAULT

                // --- SPRITES
                public int[] sprites_imagem_1_ids_unicos_por_periodo; // sempre vai ter os 5 periodos
                public int[] sprites_imagem_2_ids_unicos_por_periodo;

                // --- CORES
                public int[] cores_imagem_1_ids_unicos_por_periodo;
                public int[] cores_imagem_2_ids_unicos_por_periodo;

                // --- CURSORES
                public int[] cores_cursores_ids_unicos_por_periodo;


        // --- FORCADO ( SISTEMA )

                public bool FOCADO_esta_ativado = false;

                // --- SPRITES
                public int[] sprites_imagem_1_ids_unicos_por_periodo_FORCADO; // sempre vai ter os 5 periodos
                public int[] sprites_imagem_2_ids_unicos_por_periodo_FORCADO;

                // --- CORES
                public int[] cores_imagem_1_ids_unicos_por_periodo_FORCADO;
                public int[] cores_imagem_2_ids_unicos_por_periodo_FORCADO;

                // --- CURSORES
                public int[] cores_cursores_ids_unicos_por_periodo_FORCADO;




        // --- DADOS

        public Image image_slot;

        public int cor_cursor_id;

        
        public Sprite interativo_sprite_1;
        public Color cor_image_1;
        
        public Sprite interativo_sprite_2;
        public Color cor_image_2;

        public float[] posicao; // tem que cuidar pois é novo. Agora a imagem nao vai ser full hd
        public float[] area = new float[]{ 0f,0f } ;



        // ??
        public bool hover_esta_ativo;


}
