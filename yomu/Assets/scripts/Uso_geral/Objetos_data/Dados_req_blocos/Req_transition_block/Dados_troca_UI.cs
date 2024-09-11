


//** finalizar_UI => criar_novas_ui => iniciar_bloco




public class Req_change_interface {


    public System.Action Prepare_UI_data = () => {}; // ** vai iniciar o carregamento de novas UIs e pode modificar alguns dados
    public System.Action Change_UI_hide = () => {}; // ** esconde UI => Dispositivo.esconder()
    public System.Action Change_UI_down = () => {}; // ** coloca nova UI => Dispositivo.Mostrar()

    public System.Action Change_keybinders = null;  // ** null => nao muda, mas oque significa nao mudar? certos modos tem inputs simples, como esc => opcoes, mas eu acho que na realidade sempre vai precisar. Mas o interessante é que pode ser somente 1 funcao



}


public class Dados_troca_UI {

        

        public Localizador_UI[] UIs_para_criar;
        public object[] dados_UI;

        public Dispositivo[] UIs_para_manter;

        // ** isso pode ser dentro do dispositivo
        public bool ignorar_transicao_tirada_UI = false;
        public bool ignorar_transicao_colocada_UI = false;

}
