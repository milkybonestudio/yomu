




unsafe public class Ponto {


      // public Posicao_local posicao; // posicao.ponto_id => esse ponto

      public byte background_sprite_id; 
      public byte[] background_imagens_suporte_ids;


      // tem os finais
      // se for modificar algum ponto tem que modificar o ponto também 
      public byte[] interativos_tipo_tela_ids; // tem os finais 

      // vai usar para se locomover
      public byte ponto_id;

      // tudo precisa entrar com o id do ponto
      public byte[][][] interativos_por_periodo_para_adicionar_PONTOS;  // vale a pena?
      public byte[][][] interativos_por_periodo_para_subtrair_PONTOS;  // vale a pena?

      public Item_localizador[][] itens_no_ponto_PONTOS;
      public Personagem_nome[][] personagens_no_ponto_PONTOS;
      public Script_localizador[] script_entrada_PONTOS;


}
