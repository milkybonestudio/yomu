using UnityEngine;

// Contruir() => cria o objeto

public interface INTERFACE__bloco {



        public Bloco Pegar_bloco(){ throw new System.Exception( $"Nao foi definido o metodo para pegar o bloco");  }
        
    
        public void Finalizar(){ throw new System.Exception( $"Nao foi definido o metodo Finalizar no bloco { Pegar_bloco() }"); } // destroi os objetos que precisam ser destruido os dados do bloco, mas mantem o BLOCO_objeto ** destroy o container
        public void Iniciar(){ throw new System.Exception( $"Nao foi definido o metodo Iniciar no bloco { Pegar_bloco() }"); }     //  junto com os dados de Dados_blocos inicia o bloco sempre na transicao 
        public void Update(){ throw new System.Exception( $"Nao foi definido o metodo Update no bloco { Pegar_bloco() }"); }       // 

        // ** se null nao precisa carregar
        public Task_req Carregar_dados(){ throw new System.Exception( $"Nao foi definido o metodo Carregar_dados no bloco { Pegar_bloco() }"); }
        
        // ** destrui tudo e garante que a parte estatica vai ser destruida
        public void Destruir(){ throw new System.Exception( $"Nao foi definido o metodo Destruir no bloco { Pegar_bloco() }");  }

        // ** pega os dispositivos padroes
        public Dispositivo Pegar_dispositivo( int _id ){ throw new System.Exception( $"Nao foi definido o metodo Pegar_dispositivo no bloco { Pegar_bloco() }"); }



        // default
        public void Lidar_retorno(){ throw new System.Exception( $"Nao foi definido o metodo Lidar_retorno no bloco { Pegar_bloco() }"); } // ** fica responsavel por modificar os dados do player/mundo dependendo do BLOCO_( que saiu )_RETURN e da fn pre selecionada


    
}



