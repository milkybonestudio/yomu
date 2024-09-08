

// ** colocar em MODULOs__algo_para_salvar
// ** o modulo implementa como vai colocar os dados no buffer e a interface só pega os dados

public interface INTERFACE_buffer {


        // ** salvar na stack 
        public Buffer_localizador Pegar_instrucoes_de_seguranca(){ throw new System.Exception( $"nao foi implementado Pegar_instrucoes_de_seguranca no controlador{ Pegar_nome() }" );  }

        // ** para salvar em disco( ** somente quando a stack ficar vazia )
        public Buffer_localizador[] Pegar_todos_os_dados_para_salvar(){ throw new System.Exception( $"nao foi implementado Pegar_todos_os_dados_para_salvar no controlador{ Pegar_nome() }" ); }

        // ** somente dados que não precisam mais estar na ram
        public Buffer_localizador[] Pegar_dados_para_salvar(){ throw new System.Exception( $"nao foi implementado Pegar_dados_para_salvar no controlador{ Pegar_nome() }" );}


}