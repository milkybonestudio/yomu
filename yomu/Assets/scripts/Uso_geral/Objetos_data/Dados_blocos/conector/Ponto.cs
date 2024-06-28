




public class Ponto {


      public Posicao_local posicao; // posicao.ponto_id => esse ponto

      
      
      public int ponto_anterior;
      public string background_name;

      public Interativo_nome[] interativos_nomes = new Interativo_nome[ 0 ] ;
      public Personagem_nome[] personagens_no_ponto = new Personagem_nome[ 0 ];


      public int[] interativos_tipo_personagem_ids;
      public int[] interativos_tipo_item_ids;
      public int[] interativos_tipo_tela_ids;

      #if UNITY_EDITOR 

            // --- DESENVOLVIMENTO

            public string[] interativos_tipo_personagem_nomes;
            public string[] interativos_tipo_item_nomes;

            public string[] interativos_tipo_tela_nomes;


      #endif


      public int script_entrada;


}
