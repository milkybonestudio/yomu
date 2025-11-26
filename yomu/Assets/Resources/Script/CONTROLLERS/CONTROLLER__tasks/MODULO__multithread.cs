using System;
using System.Threading;
using UnityEngine;
using System.Collections.Concurrent;


public class MODULO__multithread {

    public enum State{

        // ** adicionar um off?

        down,
        waiting_to_down, 
        up, 

    }
    public string nome_modulo;
    public MODULO__multithread( string _nome_modulo, CONTROLLER__tasks _controalador_tasks ){

        if( ( MODULO__multithread.thread != null ) )
            { CONTROLLER__errors.Throw( "Multithread is not null" ); }
            

        nome_modulo = _nome_modulo;
        controlador_tasks = _controalador_tasks;

        // if( thread == null )
        //     { 
        //         Console.Log( System_run.tasks_show_messages, "Vai criar nova thread" );
        //         Console.Log( System_run.tasks_show_messages, "State: " + state );
        //     }
        //     else
        //     {
        //         Console.Log( System_run.tasks_show_messages, "Thread was not null" );
        //         Console.Log( System_run.tasks_show_messages, "Termonou: " + thread.IsAlive );
        //         // Creat_thread();
        //         // throw new Exception();
        //         // System_run.force_stop = true;
        //     }

        timer = System.Diagnostics.Stopwatch.StartNew();
        loop_timer = new System.Diagnostics.Stopwatch();

        Creat_thread();

    }

    public CONTROLLER__tasks controlador_tasks;
    public Exception exception;
    
    public static Thread thread;
    public static AutoResetEvent signal = new AutoResetEvent( false );
    public static volatile int force_stop = 0;
    public static volatile State state;
    
    public bool finalizar_thread = false;

    private void Creat_thread(){

        if( System_run.tasks_show_messages )
            { Console.Log( "Came Creat_thread()" ); }

        Change_state( State.up );
        signal = new AutoResetEvent( false );
        thread = new Thread( Thread_secundaria_update );
        thread.Start();
        // Set_signal();

    }


    

    public System.Diagnostics.Stopwatch timer;
    public long time_for_start_multithread_by_timer_milisecodns = 5_000L;

    public System.Diagnostics.Stopwatch loop_timer;
    public long time_for_stop_multithread_by_timer_milisecodns = 4_000L;

    public void Update(){

        if( ( State ) state == State.up )
            { 
                timer.Restart();
                return;
            }

        
        bool force_start_again = ( timer.ElapsedMilliseconds > time_for_start_multithread_by_timer_milisecodns );
        
        if( force_start_again )
            { 
                
                timer.Restart();

                if( controlador_tasks.multithread_tasks_collection.Get_best_task() != null )
                    { Start_thread_again();}
                    else
                    { Console.Log( System_run.tasks_show_messages, "would stasart again, but there arent any tasks to start" ); }
            }

    }

    public SpinLock spin_lock_change_state;

    private void Change_state( State _new_state ){

        bool lock_track = false;

        try{
            
            spin_lock_change_state.Enter( ref lock_track );
            state = _new_state;

        }
        catch( Exception _e ){ 

            Console.Log( System_run.tasks_show_messages, lock_track );
            if( lock_track )
                { spin_lock_change_state.Exit(); }
            throw _e; 
        }
        finally{
            if( lock_track )
                { spin_lock_change_state.Exit(); }
        }

        return;

    }

    public void Start_thread_again(){

        // claramente tem algo errado com a ordem

        if( System_run.tasks_show_messages )
            {
                Console.Log( "Veio Start thread" );
                Console.Log( "State: " + state );
            }

        if( thread == null )
            {
                Creat_thread();
                return;
            }

        if( state == State.up )
            { return; }

        if( state == State.waiting_to_down )
            {
                Console.Log( System_run.tasks_show_messages, "Estava esperando para terminar, vai resetar o relogio e mudar o estado" );
                Change_state( State.up );
                loop_timer.Reset();
                return;

            }
        if( state == State.down )
            { 
                Console.Log( System_run.tasks_show_messages, "Vai iniciar de novo" );
                Change_state( State.up );
                Set_signal();
                
            }

    }


    public Thread Sinalize_stop_multithread(){ 

        if( System_run.tasks_show_messages )
            { Console.Log( "Came Sinalize_stop_multithread() " ); }

        Set_signal();
        Interlocked.Exchange( ref MODULO__multithread.force_stop, 1 ); 
        // ** can lose in the Killthread, so is better to return it
        Thread multithread_ref = thread; 

        return multithread_ref;
    }

    private void Set_signal(){

        signal.Set();

    }

    // ** S;o chamado quando o jogo vai encerrar
    private void Kill_thread_safe(){

        Controllers.tasks.Liberate_spin_locks();

            // ** nunca perde a referencia da thread ?
            MODULO__multithread.thread = null;
            MODULO__multithread.signal = null;
            Interlocked.Exchange( ref force_stop, 0);
            MODULO__multithread.state = State.down;

        return;
    }


    public static int a;

    public void Thread_secundaria_update(){
                int a = 0;
                while( true ){

                    if( CONTROLLER__tasks.block_for_test )
                        {
                            Thread.Sleep( 500 );
                            continue;
                        }

                    if( !!! ( Dados_fundamentais_sistema.jogo_ativo ) || force_stop == 1 )
                        {
                            if( System_run.tasks_show_messages )
                                {
                                    Console.Log( $"<Color=lightBlue>VAI MATAR A THERAD</Color>>" );
                                    Console.Log( $"force_stop: " + force_stop );
                                    Console.Log( $"Dados_fundamentais_sistema.jogo_ativo: " + Dados_fundamentais_sistema.jogo_ativo );

                                }
                            Kill_thread_safe();
                            return;
                        }

                    if( state == State.down )
                        { 
                            Console.Log( System_run.tasks_show_messages,"Vai entrar no wait()");
                            signal.WaitOne();
                            continue; 
                        }

                    Task_req best_task = controlador_tasks.multithread_tasks_collection.Get_best_task();
                    
                    if( best_task == null )
                        { 

                            if( state == State.up )
                                {
                                    Change_state( State.waiting_to_down );
                                    Console.Log( System_run.tasks_show_messages, "Don't have more tasks to execute, will wait to sleep the thread" );
                                    loop_timer.Start();
                                    continue;
                                }
                            if( state == State.waiting_to_down )
                                {
                                    if( loop_timer.ElapsedMilliseconds > time_for_stop_multithread_by_timer_milisecodns )
                                        {
                                            loop_timer.Reset();
                                            timer.Start();
                                            Console.Log( System_run.tasks_show_messages, "não tem mais tasks e passou o tempo, vai ficar descançar" );
                                            Change_state( State.down );
                                            continue;
                                        }

                                    Console.Log( System_run.tasks_show_messages, "waiting..." );
                                    Thread.Sleep( 500 );
                                }

                            continue;
                        }

                            switch( best_task.stage ){
                                case Task_req_stage.multithread_sequencial: Multithread_sequecial( best_task ); break;
                                case Task_req_stage.multithread_final: Multithread_final( best_task ); break;
                                case Task_req_stage.finished_multithread: Finish_multithread( best_task ); break;
                                default: CONTROLLER__errors.Throw( $"Tried to update a task in the multithread, but the stage was: <Color=lightBlue>{ best_task.stage }</Color>" ); break;
                            }
                    
                    continue;

                }

        try 
            {
            } 
            catch( Exception e )
            {

                // CONTROLLER__errors.Throw_exception(e);
                controlador_tasks.multithread_tasks_collection.Liberte_locks_in_task();
                Console.LogError( e.Message );
                exception = e;
                Kill_thread_safe();
                return;

            }


    }


    private void Finish_multithread( Task_req best_task ){

        Console.Log( System_run.tasks_show_messages, "FINISH TASK MULTITHREAD: " + best_task.nome );

        if( best_task.finish_multithread_situation == Task_req_stage_situation.force_wait )
            { return; }

        if( best_task.finish_multithread_situation == Task_req_stage_situation.ignore )
            { CONTROLLER__errors.Throw( "Came to sinish_multitrhed, but the situation is <Color=lightBlue>ignore</Color>. And don't make sense" ); }

        // ** SWITCH
        controlador_tasks.multithread_tasks_collection.Remove_task( best_task );
        controlador_tasks.single_tasks_collection.Add_task( best_task );
        best_task.Change_stage( Task_req_stage.single_sequencial );

        if( best_task.object_to_lock != null && Monitor.IsEntered( best_task.object_to_lock ) )
            { 
                Monitor.Exit( best_task.object_to_lock );
                best_task.object_to_lock = null;
            }
        
        return;

    }

    private void Multithread_sequecial( Task_req task ){

        if( task.multithread_sequencial_situation == Task_req_stage_situation.force_wait )
            { return; }

        if( !!!( task.have_multithread_sequencial ) || ( task.Get_multithread_sequencial_number_of_calls_left() == 0 ) || ( task.multithread_sequencial_situation == Task_req_stage_situation.ignore ) || task.task_bloqueada )
            { task.Change_stage( Task_req_stage.multithread_final ); return; }

        if( System_run.multithread_show_messages )
            { 
                Console.Log( "WILL ACTIVATE MULTITHREAD SEQUENCIAL IN THE TASK: " + task.nome ); 
                Console.Log( " IN THE ACTION: " + task.sequencial_tasks_multithread.sequencial_slot_already_casted ); 
            }

        if( task.multithread_sequencial_situation == Task_req_stage_situation.ok )
            { task.sequencial_tasks_multithread.Ativar_fracionado( task ); }

    }

    private void Multithread_final( Task_req task ){

        Console.Log( System_run.tasks_show_messages, "WILL ACTIVATE MULTITHREAD FINAL IN THE TASK: " + task.nome );

        if( !!!( task.have_multithread_final ) || ( task.multithread_final_situation == Task_req_stage_situation.ignore ) || task.task_bloqueada )
            { task.Change_stage( Task_req_stage.finished_multithread ); return; }

        if( task.multithread_final_situation == Task_req_stage_situation.force_wait )
            { return; }

        if( task.multithread_final_situation == Task_req_stage_situation.ok )
            {
                task.stage = Task_req_stage.finished_multithread;
                task.fn_multithread( task ); 
                return;

            }
        
    }

    public void Garantir_thread() {    
        
        if( thread != null  )
            { return; }


        finalizar_thread = false;
        thread = new Thread( Thread_secundaria_update ); 
        thread.Name = "Multithread";
        thread.Start();
        
        return;

    }

    // public static int v = 0;

    public void Matar_thread(){

            thread = null;
            finalizar_thread = true ;
            return;
            
    }


}