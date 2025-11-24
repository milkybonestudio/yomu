using System;
using System.Threading;


public struct Task_thread_safe_collection {

    public void Start( string _name ){

        tasks = new Task_req[ CONTROLLER__tasks.INITIAL_SLOTS_SIZE ];
        name = _name;

        spin_lock_tasks = default;

        b = a++;

    }

    public static int a;
    public int b;

    public SpinLock spin_lock_tasks;
    public Task_req[] tasks;
    public string name;


    public void Liberte_locks_in_task(){

        foreach( Task_req req in tasks ){

            if( ( req == null ) || ( req.object_to_lock == null ) )
                { continue; }

            if( Monitor.IsEntered( req.object_to_lock ) )
                { Monitor.Exit( req.object_to_lock ); }

        }

    }

    private void Garantee_tasks(){

        if( tasks == null )
            { CONTROLLER__errors.Throw( $"Didn't start the task in <Color=lightBlue>{ name }</Color>" ); }

    }
    public void Add_task( Task_req _req ){

        Garantee_tasks();

        bool lock_track = false;
        try{
            spin_lock_tasks.Enter( ref lock_track );
            if( !!!( lock_track ) )
                { CONTROLLER__errors.Throw( "Error in the spin lock <Color=lightBlue>tasks_single_threds</Color> in the ADD TASK" ); }


            TASK_REQ.Adicionar_task_em_array( ref tasks, _req );
            
        }
        catch( Exception _e ){ 
            if( lock_track )
                { spin_lock_tasks.Exit(); }
            throw _e; 
        }
        finally{
            if( lock_track )
                { spin_lock_tasks.Exit(); }
        }


    }

    public void Remove_task( Task_req _req ){

        bool lock_track = false;
        try{
            spin_lock_tasks.Enter( ref lock_track );
            
            if( !!!( lock_track ) )
                { CONTROLLER__errors.Throw( "Error in the spin lock <Color=lightBlue>tasks_single_threds</Color> in the REMOVE TASK" ); }

            tasks[ _req.slot_id ] = null;
        }
        catch( Exception _e ){ 
            if( lock_track )
                { spin_lock_tasks.Exit(); }
            throw _e; 
        }
        finally{
            if( lock_track )
                { spin_lock_tasks.Exit(); }
        }

    }

    public Task_req Get_best_task(){

        bool lock_track = false;
        Task_req req_com_maior_prioridade = null;
        if( tasks == null )
            { CONTROLLER__errors.Throw( "Did not start the tasks" ); }

        try{
            
            spin_lock_tasks.Enter( ref lock_track );

            if( !!!( lock_track ) )
                { CONTROLLER__errors.Throw( "Error in the spin lock <Color=lightBlue>tasks_single_threds</Color> in the GET_BEST_TASK" ); }
            
            for( int task_index = 0 ; task_index < tasks.Length ; task_index++ ){

                Task_req task = tasks[ task_index ];
                
                if ( req_com_maior_prioridade == null )
                    { req_com_maior_prioridade = task;}
                    
                if( task == null )
                    { continue; }

                if( !!!( task.Can_execute() ) )
                    { continue; }

                if( task.priority > req_com_maior_prioridade.priority ) 
                    { req_com_maior_prioridade = task;}

                continue;

            }

        }
        catch( Exception _e ){ 

            Console.Log( lock_track );
            if( lock_track )
                { spin_lock_tasks.Exit(); }
            throw _e; 
        }
        finally{
            if( lock_track )
                { spin_lock_tasks.Exit(); }
        }

        return req_com_maior_prioridade;

    }

    public void Liberate_spin_locks(){

        if( spin_lock_tasks.IsHeldByCurrentThread )
            { spin_lock_tasks.Exit(); }

    }



}
