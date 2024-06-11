

public class Dados_sistema_estado_atual {

		// é uma copia do sistema atual
		// só vai ser criado quando for salvar ou ler dados

		// ** pensar sobre como os planos vao ter algum funcao aqui 

		// --- PERSONAGENS

		public int[] personagens_ativos;
		public int[] personagens_ativos_planos;

		public int[] personagens_pentendes_para_adicionar;
		public int[] personagens_pentendes_para_adicionar_local;
		public int[] personagens_pentendes_para_adicionar_tempo; 


		// --- CIDADES

		public int cidade_player_id;
		public int[] cidades_adjacentes_cidade_player_ids;
		public int[] cidades_relacionadas_cidade_player_ids;

		public int segundo_plano_cidade_foco_id;
		public int[] segundo_plano_cidades_adjacentes_ids;
		public int[] segundo_plano_cidades_relacionadas_ids;


		// --- PLOTS
		


}
		
