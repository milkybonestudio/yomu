using System;
using System.Threading;
using UnityEngine;
using System.Collections.Concurrent;
using System.Collections;


public class CONTROLLER__tasks {

    //mark
    // ** OQUE NAO FOI VERIFICADO:

    // --> stop/start da multithread funciona
    // --> inserir mais de 1 thread e funciona do mesmo jeito
    // --> alterar prioridade da thread no meio do caminho
    // --> cancelar toda uma task


    public static CONTROLLER__tasks instancia;
    public static CONTROLLER__tasks Pegar_instancia(){ return instancia; }


    public CONTROLLER__tasks() {

        
        relogio = new System.Diagnostics.Stopwatch();

            single_tasks_collection.Start( "single_tasks_collection" );
            multithread_tasks_collection.Start( "multithread_tasks_collection" );

        modulo_multithread = new MODULO__multithread( _nome_modulo: "Modulo_multithread_controlador_tasks", _controalador_tasks: this );

        tempo_maximo_em_single_thread_ms = 3L;
        block_for_test = false;

    }

    public void Block_multithread_TEST(){

        block_for_test = true;

    }

    public void Liberate_multithread_TEST(){

       block_for_test = false;
        
    }

    public static volatile bool block_for_test;

    public Task_req Get_task_request( string _name ){

        Task_req req = new Task_req( _name );
        Adicionar_task( req );
        return req;

    }

    public void Destroy(){

        Thread multithread_thread = modulo_multithread.Sinalize_stop_multithread();
        Liberate_spin_locks();

        // Thread.Sleep( 1000 );
        if( multithread_thread != null && multithread_thread.IsAlive )
            { 
                bool ended = multithread_thread.Join( 5_000 ); 
                if( !!!( ended ) )
                    { CONTROLLER__errors.Throw( "The multitrhead didn't end " ); }                    
            }
                            
    }

    public void Liberate_spin_locks(){

        single_tasks_collection.Liberate_spin_locks();
        multithread_tasks_collection.Liberate_spin_locks();
    
        multithread_tasks_collection.Liberte_locks_in_task();
        single_tasks_collection.Liberte_locks_in_task();

        if( modulo_multithread.spin_lock_change_state.IsHeldByCurrentThread )
            { multithread_tasks_collection.spin_lock_tasks.Exit(); }

        return;

    }

    public long tempo_maximo_em_single_thread_ms;

    
    public MODULO__multithread modulo_multithread;

    public const int INITIAL_SLOTS_SIZE = 100;
        public Task_thread_safe_collection single_tasks_collection;
        public Task_thread_safe_collection multithread_tasks_collection;
    




    private System.Diagnostics.Stopwatch relogio;
    

    public bool block_frame;

    public void Update( Control_flow _control_flow ){

        modulo_multithread.Update();

        if( block_frame )
            { block_frame = false; return; }

        relogio.Start();

        while ( true ){

            // ** SINGLE THREAD

            if( !!! ( Pode_continuar() ) ) 
                { return; } // --- NAO PODE CONTINUAR

            Task_req best_task =  single_tasks_collection.Get_best_task();

            if( best_task == null ) 
                {  relogio.Reset();  return; }  // --- NAO TEM NADA PARA FAZER

            switch( best_task.stage ){

                case Task_req_stage.single_start: Start( best_task ); break;
                case Task_req_stage.single_sequencial: Single_sequencial( best_task ); break;
                case Task_req_stage.single_final: Single_final( best_task ); break;
                case Task_req_stage.finished: Finished( best_task ); break;

            }

            
            if ( !!!( Pode_continuar() ) )
                { break; } // --- NAO PODE CONTINUAR

            continue;

        }


        if( modulo_multithread.exception != null )
            { CONTROLLER__errors.Throw_exception( modulo_multithread.exception ); }
        

    }


    private void Finished( Task_req task ){

        Console.Log( System_run.tasks_show_messages, ( "FINISH TASK: " + task.nome ) );
        single_tasks_collection.Remove_task( task );

        if( task.object_to_lock != null && Monitor.IsEntered( task.object_to_lock ) )
            { 
                Monitor.Exit( task.object_to_lock );
                task.object_to_lock = null;
            }

        return;

    }
    
    private void Start( Task_req task ){

        Console.Log( System_run.tasks_show_messages, "WILL START TASK: " + task.nome );
        task.Change_stage( Task_req_stage.multithread_sequencial );
        
        // ** SWITCH
        single_tasks_collection.Remove_task( task );
        multithread_tasks_collection.Add_task( task );

        // ** nesse ponto se a thread acabou de ser removida não vai iniciar novamente, vai só mudar as flags
        // ** fazer um if
        
        modulo_multithread.Start_thread_again();
        
        return;

    }


    public bool Have_any_task(){

        Task_req best_task_req_single = single_tasks_collection.Get_best_task();
        Task_req best_task_req_multithread = multithread_tasks_collection.Get_best_task();
        
        return ( best_task_req_single != null ) || ( best_task_req_multithread != null );

    }

    public bool Have_single_task(){ return single_tasks_collection.Get_best_task() != null; }
    public bool Have_multithread_task(){ return multithread_tasks_collection.Get_best_task() != null; }

    private void Single_sequencial( Task_req task ){

        Console.Log( System_run.tasks_show_messages, "veio single sequencial" );

        if( !!!( task.have_single_sequencial ) || ( task.single_sequencial_situation == Task_req_stage_situation.ignore ) || task.task_bloqueada || ( task.Get_single_sequencial_number_of_calls_left() == 0 ) )
            {
                task.Change_stage( Task_req_stage.single_final );
                return;
            }

        if( ( task.single_sequencial_situation == Task_req_stage_situation.force_wait ) )
            { return; }

        for( int  i = 0 ; i < task.Get_length_sequencial_single() ; i++ ){

            task.sequencial_tasks_single.Ativar_fracionado( task );
            return;

        }
        
    }

    private void Single_final( Task_req task ){

        Console.Log( System_run.tasks_show_messages, "SINGLE FINAL" );

        if( !!!( task.have_single_final ) || ( task.single_final_situation == Task_req_stage_situation.ignore ) || task.task_bloqueada )
            { 
                task.Change_stage( Task_req_stage.finished );
                // tasks_em_espera_para_ativar_single_thread[ task.slot_id ] = null;
                return;
            }
    

        if( task.single_final_situation == Task_req_stage_situation.force_wait )
            { return; }

        task.fn_single( task );
        task.Change_stage( Task_req_stage.finished );

        return;
        
    
    }


    public Coroutine Wait_task_ends( Task_req _task_request, float _max_time_ms ){

        return Mono_instancia.Start_coroutine( Wait() );

        IEnumerator Wait(){

            float time = 0f;

            while( true ){

                time += ( Time.deltaTime * 1000f );

                if( time > _max_time_ms )
                    { CONTROLLER__errors.Throw( $"Passou do tempo na task { _task_request.nome }" ); }

                if(  _task_request.Is_finalized() )
                    { break; }
                    
                yield return null; 

            }
            
            yield break;

        };

                                            

    }


    public void Block_frame_update(){ block_frame = true; }




    private bool Pode_continuar(){

        bool pode_continuar = ( relogio.ElapsedMilliseconds < tempo_maximo_em_single_thread_ms );
        
        if( !!!( pode_continuar ) )
            { relogio.Reset(); }

        return pode_continuar;

    }


    // ENTRY POINT
    public void Adicionar_task( Task_req _nova_task ) { 

        if( System_run.tasks_show_messages )
            { Console.Log( "WILL ADD TASK TO THE LIST: " + _nova_task.nome ); }

        single_tasks_collection.Add_task( _nova_task ); 

    }




}


