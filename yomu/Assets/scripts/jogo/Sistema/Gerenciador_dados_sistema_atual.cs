



public class Gerenciador_sistema_estado_atual {

    public Gerenciador_sistema_estado_atual( Controlador_dados_sistema _controlador_dados_sistema ){

            controlador_dados_sistema = _controlador_dados_sistema;

    }


    public Controlador_dados_sistema  controlador_dados_sistema;


    public Dados_sistema_estado_atual Pegar_dados(){
        // ** fazer
        // os dados estado atual sempre tem ser pego no momento
        throw new System.Exception();

        Dados_sistema_estado_atual dados_retorno = new Dados_sistema_estado_atual();

        // --- PERSONAGENS 


        // --- CIDADES 
        // --- PLOTS 

        return dados_retorno;
    }

    public byte[] Compilar_dados(){
        // ** fazer
        return null;

    }



}