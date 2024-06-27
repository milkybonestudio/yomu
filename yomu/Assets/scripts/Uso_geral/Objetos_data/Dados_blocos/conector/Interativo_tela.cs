using UnityEngine;
using UnityEngine.UI;





// [  info basica  ] [ force_1 , force_2 ]
// [ default_not_change ][ default ][ force ]


public class Interativo_tela {


        public Interativo_tela( int _index_id ){

                interativo_id = _index_id ;
        }


        public int interativo_id;
        public int tipo_interativo;
        public int ponto_id;


        // ** tudo vai ser descartado e reiniciado durante a troca de dias 


        #if UNITY_EDITOR

                /* <--- USADO SOMENTE NO EDITOR ---> */

                public Interativo_tipo_mouse_hover tipo_mouse_hover;


                // --- SUPORTE PARA ( IMAGEM / VISUAL )
                public Tipo_sufixo_para_pegar_imagem tipo_sufixo_para_pegar_imagem;
                public string[] nomes_imagens_especificas_periodos;
                

                        
                // -- !!  os nomes vão ser colocados na classe com os dados para nao ter 2 classes gigantes !! --
                // ** quando for criar colocar o nome 
                public string enum_nome_interativo_DESENVOLVIMENTO; // SAINT_LAND___CATHEDRAL__DORMITORIO_FEMININO__interativo
                public string nome_insterativo_DESENVOLVIMENTO; // NARA_ROOM__up__janela

                // vai acompanhar como as imagens funcionam:
                // todos_os_periodos => 5
                // dia_e_noite => 2 
                // nao_altera => 1

                public Cor_cursor[] cores_cursor;


        #endif



        /* <--- USADO SOMENTE NA BUILD ---> */

        // --- DEFAULT

                // --- SPRITES
                public int[][] sprites_imagem_1_ids_unicos_por_periodo; // sempre vai ter os 5 periodos
                public int[][] sprites_imagem_2_ids_unicos_por_periodo;

                // --- CORES
                public int[][] cores_imagem_1_ids_unicos_por_periodo;
                public int[][] cores_imagem_2_ids_unicos_por_periodo;

                // --- CURSORES
                public int[][] cores_cursores_ids_unicos_por_periodo;


        // --- FORCADO ( SISTEMA )

                public bool FOCADO_esta_ativado = false;

                // --- SPRITES
                public int[][] sprites_imagem_1_ids_unicos_por_periodo_FORCADO; // sempre vai ter os 5 periodos
                public int[][] sprites_imagem_2_ids_unicos_por_periodo_FORCADO;

                // --- CORES
                public int[][] cores_imagem_1_ids_unicos_por_periodo_FORCADO;
                public int[][] cores_imagem_2_ids_unicos_por_periodo_FORCADO;

                // --- CURSORES
                public int[][] cores_cursores_ids_unicos_por_periodo_FORCADO;




        // --- DADOS

        public Image image_slot;

        public int cor_cursor_id;

        public Sprite interativo_image_1;
        public Color cor_image_1;
        
        public Sprite interativo_image_2;
        public Color cor_image_2;

        public float[] posicao; // tem que cuidar pois é novo. Agora a imagem nao vai ser full hd
        public float[] area;



        // ??
        public bool hover_esta_ativo;


}