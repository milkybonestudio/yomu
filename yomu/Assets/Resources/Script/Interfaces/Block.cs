using UnityEngine;

// Contruir() => cria o objeto

public abstract class BLOCK {


        public Block_type block_type;
        public GameObject container;

        //mark
        // ** depois fazer abstract
        public virtual void Create_camera_stuff(){}
        
    
        public abstract void Finalizar(); // destroi os objetos que precisam ser destruido os dados do bloco, mas mantem o BLOCO_objeto ** destroy o container
        public abstract void Iniciar();   //  junto com os dados de Dados_blocos inicia o bloco sempre na transicao 
        public abstract void Update( Control_flow _control_flow );


        // ** se null nao precisa carregar
        public abstract Task_req Carregar_dados();
        
        // ** destrui tudo e garante que a parte estatica vai ser destruida
        public abstract void Destruir();

        // ** pega os dispositivos padroes
        // public Dispositivo Pegar_dispositivo( int _id ){ throw new System.Exception( $"Nao foi definido o metodo Pegar_dispositivo no bloco { Pegar_bloco() }"); }



        // ** se um bloco precisar fazer algo mais especifico ele pode criar um outro metodo
        public string class_name;
        public string method_name;
        public virtual void Lidar_retorno(){

        }


    
}



