

public class Dados_sistema_estado_atual {

		// é uma copia do sistema atual
		// só vai ser criado quando for salvar ou ler dados

		// ** pensar sobre como os planos vao ter algum funcao aqui 


		// --- TEMPO
		public int tempo_atual_em_periodos;

		// principal 
		// ** todo mes tem 28 dias 
		public int periodo_atual_id ;
		public int dia_semana_atual_id ;
		public int semana_mes_atual_id ;
		public int mes_ano_atual_id ;
		public int ano_atual_id ;




		// --- PLAYER

		public int personagem_atual_id;
		public int segundo_plano_cidade_id;



		// --- PERSONAGENS

		public int[] personagens_ativos_ids;
		public int[] personagens_ativos_planos_ids;

		public int[] personagens_pentendes_para_adicionar;
		public int[] personagens_pentendes_para_adicionar_local;
		public int[] personagens_pentendes_para_adicionar_tempo; 


		// --- CIDADES

		public int cidade_player_id;
		// public int[] cidades_adjacentes_cidade_player_ids;
		// public int[] cidades_relacionadas_cidade_player_ids;

		public int segundo_plano_cidade_foco_id;
		// public int[] segundo_plano_cidades_adjacentes_ids;
		// public int[] segundo_plano_cidades_relacionadas_ids;

		public int[] cidades_segundo_plano_ativas;

		public int[] cidades_segundo_plano_pentendes_para_adicionar;
		public int[] cidades_segundo_plano_pentendes_para_adicionar_tempo;


		// --- PLOTS

		public int[] plots_ativos_ids;
		public int[] plots_ativos_planos;
		public int[] plots_pentendes_para_adicionar;
		public int[] plots_pentendes_para_adicionar_tempo;


		// --- 

		public byte[][][][][][] interativos_para_adicionar_ids;
		public byte[][][][][][] interativos_para_subtrair_ids;
		


}
		
