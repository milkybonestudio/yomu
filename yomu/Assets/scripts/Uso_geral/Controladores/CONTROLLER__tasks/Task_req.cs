using System;


public class Task_req {

        public static void VOID( Task_req _req ){}
        public static object[] ARRAY_VOID = new object[ 1 ];

        public Task_req ( string _nome ){ 

                this.nome = _nome;

        }

        public Task_fracionada task_fracionada;
        public string nome = "task_sem_nome";


        public Action<Task_req> fn_multithread = Task_req.VOID;  
        public Action<Task_req> fn_single_thread = Task_req.VOID;  
        public Action<Task_req> fn_forcar_finalizar  = Task_req.VOID; // --- vai ser usado quando a funcao precisa ser executada na main thread. Garante que tudo funcione mesmo sem 
 

        // DADOS 

        public int slot_id; // setado somente pelo controlador


        public int prioridade = 0 ;
        public System.Object[] dados = Task_req.ARRAY_VOID;
        public System.Object[] dados_forcar = Task_req.ARRAY_VOID; // --- para garantir que em hipotese nenhuma o mesmo array seja acessado na multi e na single. Mas ainda pode pegar/ler 

        
        public bool part_multithread_finished;
        public bool part_single_finished;

        
        public bool pode_executar_parte_multithread = true;
        public bool pode_executar_single_thread = true;
        public bool pode_executar_parte_single_thread_fracionada = true; // precisa tambem da pode_executar_parte_single_thread

        public bool finalizado = false; 
        public bool task_bloqueada = false;
        


}

