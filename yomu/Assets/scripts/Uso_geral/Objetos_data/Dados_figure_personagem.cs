



public class Dados_figure_personagem {


    /*

       regras: 
        - mesmo chamando funcoes ba() , piscar() ou qualquer outra o width e height nunca mudam.
        - as referencias para imagens nunca podem vir para os dados_figura   
        - um novo objeto sempre é criado quando pede a figura, ele junta as partes 
    
    */


    /*
        sempre tem 1 imagem obrigatoria base 
        pode ter 1 imagem opcional 
        se tiver alguma animacao vai ter ids. caso nao tenha vai ficar como null;
    
    */


    public int width;
    public int height;



    public Personagem_nome personagem_nome;
    public string figura_nome;
    public int figura_id;

    // se o id for 0 => nao tem

    public int imagem_base_id;
    public int imagem_secundaria_id;

    public float posicao_imagem_secundaria_x;
    public float posicao_imagem_secundaria_y;
    
    


    // coisas que sao opcionais 

    
    public int[] boca_imagens_ids_animacao; 
    public float boca_posicao_x_animacao;
    public float boca_posicao_y_animacao;


    public int[] olhos_imagens_ids_animacao; 
    public float olhos_posicao_x_animacao;
    public float olhos_posicao_y_animacao;

    public int[] animacao_completa_imagens_ids_animacao; 
    public float animacao_completa_posicao_x_animacao;
    public float animacao_completa_posicao_y_animacao;





    // so vai ser usado em teste, reconstruir o geral.dat pode demorar muito
    // eles so vai ter algum valor se figure fo criado em Pegar_figure_em_producao()

    public string imagem_base_path;
    public string imagem_secundaria_sting;
    public string boca_imagens_paths_animacao;
    public string olhos_imagens_paths_animacao;
    public string animacao_completa_imagens_paths_animacao;


    // so vai ser usado em teste 

    
   
}
