using System;
using System.Threading;


public enum Task_req_state{

        normal, // ** go
        blocked, // ** wait
        delete, // ** will force to end

}

public class Task_req {

    public Task_req ( string _nome = "task_sem_nome", int _length_data = 2 ){

        nome = _nome;
        dados = new object[ _length_data ];
        unique_id = current_unique_id++;

    }

    public static void VOID( Task_req _req ){}

    // ** NEED TO BE THE SAME FOR ALL THREADS
    public static SpinLock spin_lock;
    public void Change_stage( Task_req_stage _new_stage ){

        bool lock_track = false;
        try{
            Task_req.spin_lock.Enter( ref lock_track );
            stage = _new_stage;
        }
        catch( Exception _e ){ Console.LogError( "Error in the spin lock" ); }
        finally{
            if( lock_track )
                { Task_req.spin_lock.Exit(); }
        }

        return;

    }

    public bool Can_execute(){

        switch( stage ){
            case Task_req_stage.single_start: return true ;

            case Task_req_stage.multithread_final: return ( multithread_final_situation != Task_req_stage_situation.force_wait ); 
            case Task_req_stage.multithread_sequencial: return ( multithread_sequencial_situation != Task_req_stage_situation.force_wait ); 
            case Task_req_stage.finished_multithread: return true;

            case Task_req_stage.single_sequencial: return ( single_sequencial_situation != Task_req_stage_situation.force_wait );
            case Task_req_stage.single_final: return ( single_final_situation != Task_req_stage_situation.force_wait );
            case Task_req_stage.finished: return true;
            default: CONTROLLER__errors.Throw( $"Can not handle stage <Color=lightBlue>{ stage }</Color>" ); return false;
        }

    }

    public int Get_length_sequencial_single(){ return sequencial_tasks_single.current_sequencial_slot; }
    public int Get_length_sequencial_multithread(){ return sequencial_tasks_multithread.current_sequencial_slot; }

    public string nome;
    private static int current_unique_id;
    public int unique_id;

    public System.Object object_to_lock;

    public void Give_lock_object( System.Object _object_to_lock, bool _enter = true ){

        if( _enter )
            { Monitor.Enter( _object_to_lock ); }
        object_to_lock = _object_to_lock;
        return;

    }

    public bool have_single_start; // ** ver depois
    public bool Is_finalized(){ return stage == Task_req_stage.finished; }
    public volatile Task_req_stage stage = Task_req_stage.single_start;

    public int Get_multithread_sequencial_number_of_calls_left(){ return ( sequencial_tasks_multithread.current_sequencial_slot - sequencial_tasks_multithread.sequencial_slot_already_casted ); }

    // --- MULTITHREAD 
        public Task_fracionada sequencial_tasks_multithread;
        public Task_req_stage_situation multithread_sequencial_situation;
        public bool have_multithread_sequencial;
        public void Give_multithread_sequencial_action( Action<Task_req> _fn ){

            if( sequencial_tasks_multithread == null )
                { 
                    sequencial_tasks_multithread = new Task_fracionada( nome + "__SEQUECIAL_MULTITHREAD" ); 
                    have_multithread_sequencial = true;
                    multithread_sequencial_situation = Task_req_stage_situation.ok;
                }
            sequencial_tasks_multithread.Adicionar_fn( _fn );

            return;
        }


        public Action<Task_req> fn_multithread = Task_req.VOID;
        public Task_req_stage_situation multithread_final_situation;
        public bool have_multithread_final;
        public void Give_multithread_final( Action<Task_req> _fn ){

            fn_multithread = _fn;
            have_multithread_final = true;
            multithread_final_situation = Task_req_stage_situation.ok;

            return;

        }

        public Task_req_stage_situation finish_multithread_situation;

    // --- SINGLE
        
        public Task_fracionada sequencial_tasks_single;
        public Task_req_stage_situation single_sequencial_situation;
        public bool have_single_sequencial;
        public int Get_single_sequencial_number_of_calls_left(){ return ( sequencial_tasks_single.current_sequencial_slot - sequencial_tasks_single.sequencial_slot_already_casted ); }
        public void Give_single_sequencial_action( Action<Task_req> _fn ){

            if( sequencial_tasks_single == null )
                { 
                    sequencial_tasks_single = new Task_fracionada( nome + "__SEQUECIAL_SINGLE" ); 
                    have_single_sequencial = true;
                    single_sequencial_situation = Task_req_stage_situation.ok;
                }

            sequencial_tasks_single.Adicionar_fn( _fn );

            return;
        }


        public Action<Task_req> fn_single = Task_req.VOID;
        public Task_req_stage_situation single_final_situation;
        public bool have_single_final;
        public void Give_single_final( Action<Task_req> _fn ){

            fn_single = _fn;
            have_single_final = true;
            single_final_situation = Task_req_stage_situation.ok;

            return;

        }

    

    public Action<Task_req> fn_forcar_finalizar  = Task_req.VOID; // --- vai ser usado quando a funcao precisa ser executada na main thread. Garante que tudo funcione mesmo sem 


    // ** passar depois para esses 2

    // DADOS 

    public int slot_id; // setado somente pelo controlador

    public void Change_priority( int _new_priority ){

        priority = _new_priority;

    }
    public int priority = 0 ;
    

    public Task_req_data data;
    public Task_req_data_managed managed_data;


    public System.Object[] dados;
    public System.Object[] dados_forcar; // --- para garantir que em hipotese nenhuma o mesmo array seja acessado na multi e na single. Mas ainda pode pegar/ler 

    public System.Object data_1;
    public System.Object data_2;
    public System.Object data_3;

    
    // public bool part_multithread_finished;
    // public bool part_single_finished;

    
    // public bool finalized = false; 
    public bool task_bloqueada = false;


    public void Reset(){
        // finalized = false;
        // part_multithread_finished = false;
    }
    

    public override string ToString(){ return nome; }


}

unsafe public struct Task_req_data {

    // ** ints 
    public fixed int int_values[ 10 ];
    public fixed byte byte_values[ 40 ];

}



public struct Task_req_data_managed {
    
    public string[] string_array;
    public int[] int_array;

}

