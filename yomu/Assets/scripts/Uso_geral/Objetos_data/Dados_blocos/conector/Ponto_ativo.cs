

public class Ponto_ativo {

    
      public bool ponto_esta_sendo_monitorado;

      public Locator_position posicao;

      public byte[] background_sprite_base_id_por_periodo; 
      
      #if UNITY_EDITOR
            public string nome = "";
      #endif
      


      // --- INTERATIVOS 
 
      // *** se nao tivber personagem vai estar null
      public Interativo_tela[] interativos_tela;
      public Interativo_personagem[] interativos_personagens;
      public Interativo_item[] interativos_itens;



      // --- INTERATIVOS TELA

      // *** usados para pegar a logica 
      public byte[][] tipos_interativos_tela_por_periodo; 
      public byte[][][] dados_imagens_interativos_tela_por_periodo;
      public byte[][][] dados_logicas_interativos_tela_por_periodo;


      // *** usados para pegar os interativos atuais 
      public byte[][] interativos_tipo_tela_default_ids_por_periodo;      
      public byte[][] interativos_por_periodo_para_adicionar; 
      public byte[][] interativos_por_periodo_para_subtrair;  


      // --- INTERATIVOS ESTATICOS

      public Item_localizador[] itens_no_ponto;
      public short[] quantidade_itens;

      public Personagem_nome[] personagens_no_ponto;

      public Script_localizador[][] script_localizadores_por_periodo;

}