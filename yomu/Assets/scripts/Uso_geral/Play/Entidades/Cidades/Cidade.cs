



public class Cidade {

    public Cidade( int _cidade_id ){
        cidade_id = _cidade_id;

    }

    public int cidade_id;
    public int plano_id; // primeiro  => cidade pla

    public Gerenciador_containers_dados_cidade gerenciador_containers_dados;
    public Gerenciador_dados_sistema_cidade gerenciador_dados_sistema;
    public Gerenciador_AI_cidade gerenciador_AI;

    


    public int[][][][] interativos_tela_para_adicionar_ids;
    public int[][][][] interativos_tela_para_subtrair_ids;

    public int[][][][] itens_ids_por_posicao;
    public int[][][][] personagens_ids_por_posicao;

    public int[][][][] interativos_tela_por_posicao;




    //public Cidadaos cidados;
    
    
}