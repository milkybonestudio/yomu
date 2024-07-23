

public class Dados_menu {

    // *** Tem que ser criado quando o login for criado
    // *** usar para pegar as imagens com antecedencia

    public Tipo_menu_background tipo_menu_background;


    // *** base onde os objetos dos blocos vao ser colocados
    public float[] posicoes_blocos;


    // ** [ ... id, p_x, py ... ]
    public int[] background_imagens_ids_E_posicoes;
    //public int numero_imagens_background;
    //public float[] background_imagens_posicoes;


    // --- INTERATIVOS MENU
    public int[][] interativos_menu_imagens_por_bloco;
    public int[][] posicoes_interativos_menu_por_bloco;
    
    // *** pode ser null
    public int[][][] interativos_menu_animacoes_por_bloco;
    

    
    // --- OBJETOS ESTATICO
    public bool[] objetos_estaticos_liberados;
    public int[] objetos_estaticos_posicoes;



}
