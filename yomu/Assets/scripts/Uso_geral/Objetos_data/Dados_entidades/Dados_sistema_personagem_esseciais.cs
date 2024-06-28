



public class Dados_sistema_personagem_essenciais {

        
        // projecoes 
        //  entre 0 e 100.  
        // se o personagem ainda nao foi apresentado vira projecao
        public byte interesse_player;
        public byte afetividade;

        public short periodo_ultimo_update;
        

        // info basica 
        // vai ser copiada para os personagens ativos para fazer persoangem.posicao_atual 
        // public Personagem_nome nome_personagem;


        public long posicao_atual_personagem_long;

        // Posicao 
        public byte continente_id;
        public byte reino_id;
        public byte estado_id;
        public short posicao_cidade_id;
        public short regiao_id;
        public short area_id;
        public short ponto_id;


        public int atividade_atual_id;


        public bool personagem_bloqueado = false;
        public bool personagem_ja_foi_apresentado_ao_player = false;

    
	
}