




public class Ponto {


      // tem que ter os interativos 
      // tem que ter as informacoes para construir um background imagem de background



      public Posicao_local posicao; // posicao.ponto_id => esse ponto

      public int ponto_anterior = -1;
      public int background_sprite_id; 
      public int[] background_imagens_suporte_ids;

      public int[] interativos_tipo_personagem_ids;
      public int[] interativos_tipo_item_ids;
      public int[] interativos_tipo_tela_ids;


      // precisa?
      public string background_name;
      public Interativo_nome[] interativos_nomes = new Interativo_nome[ 0 ] ;
      public Personagem_nome[] personagens_no_ponto = new Personagem_nome[ 0 ];







      public int script_entrada;


}
