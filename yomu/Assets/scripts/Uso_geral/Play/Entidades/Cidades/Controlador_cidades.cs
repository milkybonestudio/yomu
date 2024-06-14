




public class Controlador_cidades {

    public static Controlador_cidades instancia;
    public static Controlador_cidades Pegar_instancia(){ return instancia; }


    public Gerenciador_dados_dinamicos_cidades gerenciador_dados_dinamicos;
    public Gerenciador_save_cidades gerenciador_save;

    public Dados_sistema_cidade_essenciais[] dados_sistema_cidades_essenciais;

    // ** talvez elas se cruzem cruzem 
    public int player_cidade_id;
    public int[] cidades_adjacentes_cidade_player;
    public int[] cidades_relacionadas_cidade_player;


    public int cidade_segundo_plano_foco_id;
    public int[] segundo_plano_cidades_adjacentes_ids;
    public int[] segundo_plano_cidades_relacionadas_ids;

    public static Controlador_cidades Construir( Dados_sistema_cidade_essenciais[] _dados_sistema_cidades_essenciais , Dados_sistema_estado_atual _dados_sistema_estado_atual ) {

            Controlador_cidades controlador = new Controlador_cidades();


                controlador.gerenciador_save = new Gerenciador_save_cidades( controlador );
                controlador.gerenciador_dados_dinamicos = new Gerenciador_dados_dinamicos_cidades();

                controlador.dados_sistema_cidades_essenciais = _dados_sistema_cidades_essenciais;

                controlador.player_cidade_id = _dados_sistema_estado_atual.cidade_player_id;
                controlador.cidades_adjacentes_cidade_player = _dados_sistema_estado_atual.cidades_adjacentes_cidade_player_ids;
                controlador.cidades_relacionadas_cidade_player = _dados_sistema_estado_atual.cidades_relacionadas_cidade_player_ids;

                controlador.cidade_segundo_plano_foco_id = _dados_sistema_estado_atual.segundo_plano_cidade_foco_id;
                controlador.segundo_plano_cidades_relacionadas_ids = _dados_sistema_estado_atual.segundo_plano_cidades_relacionadas_ids;
                controlador.segundo_plano_cidades_adjacentes_ids = _dados_sistema_estado_atual.segundo_plano_cidades_adjacentes_ids;
                
                

            instancia = controlador;
            return controlador;


    }





}