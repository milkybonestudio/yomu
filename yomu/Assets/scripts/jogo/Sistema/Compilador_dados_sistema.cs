


public static class Compilador_dados_sistema {

    public static byte[] Compilar( Dados_sistema_estado_atual _dados_estado-atual ){

        // ** vai compilar tudo que precisa para criar os dados sistemas 
        Controlador_dados_sistema controlador = Controlador_dados_sistema.Pegar_instancia();

        // 

        // --- CRIA DADOS SISTEMA ATUAL
        Dados_sistema_estado_atual retorno = new Dados_sistema_estado_atual();

                        retorno.personagens_pentendes_para_adicionar = Controlador_personagens.Pegar_instancia().personagens_pentendes_para_adicionar;
                        retorno.personagens_pentendes_para_adicionar_local = Controlador_personagens.Pegar_instancia().personagens_pentendes_para_adicionar_local;
                        retorno.personagens_pentendes_para_adicionar_tempo = Controlador_personagens.Pegar_instancia().personagens_pentendes_para_adicionar_tempo;

                return retorno;


    }

}