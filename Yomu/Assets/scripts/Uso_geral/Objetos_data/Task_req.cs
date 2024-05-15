using System;






public class Task_req {

        /*

                fn_iniciar sempre vai acontecer na thread secundaria, e vai ser o que mais consume cpu
                            => vai colocar coisas no cache
                 
                fn_finalizar sempre acontece na main thread e pode ser interrompida 
        
                ex:  se visual novel pedir 10 pngs para serem carregados com antecedencia esses 10 reqs vão ter senha n que vai estar ativada. 
                se por acaso visual novel encerre ele pode simplesmente apagar a senha, e as funcoes retorno não vão ser ativadas. e pelo jeito que esta o update vai ser:
                
                controlador => visual novel => multithread
                se uma task pode ser ativada é porque nenhum outro bloco impediu 
        
        */




        // quando uma task for criada as fns tem que ser colocadas quando for criada na sequencia. 
        // a chave é essencial então tem que ser tada quando criar 
        public Task_req (  Chave_cache _chave_cache , string _nome ){ 

                this.chave_cache = _chave_cache;
                this.nome = _nome;
                
        }


        public void Colocar_fracionado( Action<Task_req>[] _fn_fracionados ) {

                tasks_fracionadas = _fn_fracionados;
                tem_fracionado = true;

        }

        public Task_req self  = null;


        public string nome = "task";


        public Action<Task_req> fn_iniciar = ( Task_req _req ) => {return;} ;  
        public Action<Task_req> fn_finalizar  = ( Task_req _req ) => {return;} ;  



        // Parte fracionada => se a task precisa ser na main thread ela pode ser dividida em partes mas ainda tendo a mesma chave 
        // o objeto vai ser mantido vivo até que todas as partes sejam terminadas

        // isso em sprites vai precisar ter um preparo um pouco maior. Depois de testes eu percebi que não seria bom interar sobre uma texture por conta de ser 300x mais lento. 
        // então caso tenha uma imagem que somente colocar o pixel passe de 5ms precisa ser separado em 2 ou mais imagens e criar 2 sprites 

        // dado pode ser compactado como um Sprite[], entao cada loop ele cria um necessario

        public Action<Task_req>[] tasks_fracionadas = null;

        public bool tem_fracionado = false;

        public int parte_fracionado_atual = 0;
        
        public void Ativar_fracionado() {  


                if( tasks_fracionadas[ parte_fracionado_atual ] != null ){ tasks_fracionadas[ parte_fracionado_atual ]( self ); }

                parte_fracionado_atual++;

                int quantidade_de_partes = tasks_fracionadas.Length;

                if( parte_fracionado_atual >= quantidade_de_partes ) { tem_fracionado = false;}
                return;

        }


        // DADOS 


        public int prioridade = 0 ;
        
        public System.Object dados = null ;
        public System.Object dados_suporte_1 = null;
        public Chave_cache chave_cache = new Chave_cache() ;
        public bool pode_executar = true ;
        public bool finalizado = false;


}

