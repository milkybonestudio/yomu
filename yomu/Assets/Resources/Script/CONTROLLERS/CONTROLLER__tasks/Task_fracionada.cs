using System;
using System.Collections.Generic;


public class Task_fracionada {

    public Task_fracionada( string _name = "name not give" ){ name = _name; }

    
    public void Adicionar_fn( Action<Task_req> _fn ){

        if( current_sequencial_slot > 50 )
            { CONTROLLER__errors.Throw( $"Tried to add and action in sequencial <Color=lightBlue>{ name }</Color> but there is already <Color=lightBlue>50</Color> actions" ); }

        sequecial_tasks[ current_sequencial_slot++ ] =  _fn;
        return;

    }

    public string name;

    
    public Action<Task_req>[] sequecial_tasks = new Action<Task_req>[ 50 ];

    public int current_sequencial_slot;

    public bool Have_tasks_to_execute(){ return ( sequencial_slot_already_casted >= current_sequencial_slot ); }

    public int sequencial_slot_already_casted;
    
    public void Ativar_fracionado( Task_req _task_req ) {

        if( sequecial_tasks[ sequencial_slot_already_casted ] != null )
            { sequecial_tasks[ sequencial_slot_already_casted ]( _task_req ); }

        sequencial_slot_already_casted++;

        return;

    }



}