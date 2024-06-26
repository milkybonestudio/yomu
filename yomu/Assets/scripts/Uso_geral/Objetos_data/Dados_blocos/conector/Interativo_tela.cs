




public class Interativo_tela {


        public Interativo( int _index_id ){

                interativo_nome = (  Interativo_nome ) _index_id ;
        }


        public int interativo_id;

        #if UNITY_EDITOR
            // ** quando for criar colocar o nome 
            public string nome_insterativo_DESENVOLVIMENTO;
        #endif

        public Tipo_interativo tipo;
        public Interativo_nome interativo_nome;
        public Ponto_nome ponto_nome;

        

        //   default 
        
        public float[] posicao; // tem que cuidar pois é novo. Agora a imagem nao vai ser full hd

        public Interativo_tipo_mouse_hover tipo_mouse_hover;
        public Tipo_get_interativo tipo_get;

        
        public Cor_cursor cor_cursor;

        public Image image_slot;

        public Sprite interativo_image_1;
        public Color cor_image_1;
        
        public Sprite interativo_image_2;
        public Color cor_image_2;

        public float[] area;
        public bool hover_esta_ativo;


}