using System;


public static class Lidar_retorno_blocos {

    //** lidar retorno precisa: 
    //      -> pegar os dados do bloco que vai voltar e fazer algo com eles
    //      -> garantir que a UI e o input voltem para o que precisam ser 

    // ** Lidar_retorno de blocos mais comuns vão simplesmente mudar algo interno, em story o retorno de um minigame pode mudar a rota por exemplo. Mas os dados do player só vão ser modificados quando o player voltar para bloco_interaction.
    // ** Lidar_retorno de story pode modificar dados story_RETURN que vai mudar algo quando voltar para bloco_interaction

    // ** qunaod um bloco inicia outro bloco o bloco que iniciou tem mais contexto sobre oque esperar de resposta. se uma funcao triggar um novo bloco ela precisa definir oque vai ser feito quando voltar para esse bloco.
    // ** logo os dados nao podem ser apagados, se eu setar UI => ob{} essa informacao precisaria ficar arquivada mesmo trocando blocos. Os dados_trocar_input/UI só são usados para invocar UI/input mas não são usados na volta
    // ** isso poderia ficar como responsabilidade de lidar retorno, mas deixaria propenso para erros caso fosse um lidar especial. É mais facil indicar que o normal não vai mais ser feito do que sempre indicar o default

    public static void Ativar( INTERFACE__bloco _interface_bloco, Localizador_lidar_retorno_bloco _localizador ){


            Localizador_lidar_retorno_bloco finalizar_localizador = Dados_blocos.localizador_lidar_retorno_story;

            // --- PEGA OS NOMES
            string nome_classs_tratar_dados = finalizar_localizador.nome_classe_tratar_dados;
            string nome_metodo_tratar_dados = finalizar_localizador.nome_metodo_tratar_dados;

            string nome_classe_pegar_dados_UI = finalizar_localizador.nome_classe_pegar_dados_UI;
            string nome_metodo_pegar_dados_UI = finalizar_localizador.nome_metodo_pegar_dados_UI;

            string nome_classe_pegar_dados_input = finalizar_localizador.nome_classe_pegar_dados_input;
            string nome_metodo_pegar_dados_input = finalizar_localizador.nome_metodo_pegar_dados_input;

            
            if( Verificar_chaves( _interface_bloco, nome_classs_tratar_dados, nome_metodo_tratar_dados  ) )
                { Dlls_collections.lidar_finalizar.Invoke_method( nome_classs_tratar_dados, nome_metodo_tratar_dados, null );} // ** o proprio metodo tem acesso ao USO_geral e vai saber como lidar com os dados

            if( Verificar_chaves( _interface_bloco, nome_classe_pegar_dados_input , nome_metodo_pegar_dados_input  ) )
                { Dlls_collections.lidar_finalizar.Invoke_method( nome_classe_pegar_dados_input, nome_metodo_pegar_dados_input, null );} 

            if( Verificar_chaves( _interface_bloco, nome_classe_pegar_dados_UI , nome_metodo_pegar_dados_UI  ) )
                { Dlls_collections.lidar_finalizar.Invoke_method( nome_classe_pegar_dados_UI, nome_metodo_pegar_dados_UI, null );} 


    }

    private static bool Verificar_chaves( INTERFACE__bloco _interface_bloco, string _nome_class, string _nome_metodo ){

        
        if( _nome_class == null && _nome_metodo == null )
            { return false; }

        if( _nome_class != null && _nome_metodo != null )
            { return true; }

        // --- FALTOU ALGUM DADO
        throw new Exception( $"Tentou Ativar lidar_retorno no bloco { _interface_bloco.Pegar_bloco().ToString() } mas o nome da class veio { _nome_class }. Nome do metodo: { _nome_metodo }" );

    }

}