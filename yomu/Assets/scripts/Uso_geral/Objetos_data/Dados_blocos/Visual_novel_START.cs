



public class Visual_novel_START {


    public Visual_novel_START( Nome_screen_play  _nome = Nome_screen_play.nada){

                this.nome_screen_play = _nome;

    }

    public Nome_screen_play nome_screen_play;

    public bool is_screen_play_sequencia = false;

    // ** o background do plot precisa ser definido no script. Se nao definir vai sempre usar o do jogo
    public string path_background_inicial = Player_estado_atual.Pegar_instancia().Pegar_path_imagem_background();

    // public int tipo_cena;


}
