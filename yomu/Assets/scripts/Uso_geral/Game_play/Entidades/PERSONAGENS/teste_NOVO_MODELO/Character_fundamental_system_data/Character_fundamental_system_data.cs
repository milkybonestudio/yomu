unsafe public struct Character_fundamental_system_data {
    
    // ** dados que sempre vao estar na ram
    public int character_unique_id; // ** vai ser armazenado com sort


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

    public short regiao_id;
    public byte trecho_id;
    public byte cidade_no_trecho_id;
    public byte zona_id;
    public byte local_id;
    public byte area_id;
    public byte ponto_id;


    public int atividade_atual_id;


    public bool personagem_bloqueado;
    public bool personagem_ja_foi_apresentado_ao_player;



}