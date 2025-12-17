


using System.Runtime.CompilerServices;

public enum Task_req_handle_array_null {

    error, 
    _true,

}

public static class TASK_REQ {


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Verify_all_finalized( Task_req[] _reqs, Task_req_handle_array_null _handle = Task_req_handle_array_null._true ){

        if( ( _reqs == null ) && ( _handle == Task_req_handle_array_null._true ) )
            { return true; }
        
        foreach( Task_req req in _reqs ){

            if( !!!( req.Is_finalized() ) )
                { return false; }

        }



        return true;

    }


    public static void Cancel_task( ref Task_req _req_ref ){

        _req_ref.task_bloqueada = true;
        _req_ref = null;
            
    }


    public static void Add_single_data( Task_req _req, object _data ){

        if( _req.dados == null )
            { _req.dados = new object[ 1 ]; }

        _req.dados[ 0 ] = _data;
        return;

    }

    public static void Add_single_data( Task_req _req, byte[] _bytes ){

        if( _req.dados == null )
            { _req.dados = new object[ 1 ]; }

        _req.dados[ 0 ] = ( object ) _bytes; 
        return;

    }


    public static int Pegar_index_null( Task_req[] _array ){

        for( int index = 0 ; index < _array.Length ; index++ ){

            if( _array[ index ] == null )
                { return index; }

        }

        return -1;

    }


    public static Task_req[] Aumentar_length_array_2d( Task_req[] _arr, int _quantidade_para_aumentar ){

        
            int length_atual = _arr.Length;
            int length_novo = ( _arr.Length + _quantidade_para_aumentar );

            Task_req[] novo_array = new Task_req[ length_novo ];

            for( int index = 0; index < _arr.Length ; index++ ){

                novo_array[ index ] = _arr[ index ];

            }

            return novo_array;


    }


    public static Task_req Pegar_task_com_maior_prioridade( Task_req[] _arr  ){


        Task_req req_com_maior_prioridade = null;

        for( int task_index = 0 ; task_index < _arr.Length ; task_index++ ){

            Task_req task = _arr[ task_index ];
            
            if ( req_com_maior_prioridade == null )
                { req_com_maior_prioridade = task; }

            if( task == null )
                { continue; }

            if( task.priority > req_com_maior_prioridade.priority ) 
                { req_com_maior_prioridade = task; }

            continue;

        }

        return req_com_maior_prioridade;

    }



    public static void Adicionar_task_em_array( ref Task_req[] _arr, Task_req _task ){

        int index_livre = TASK_REQ.Pegar_index_null( _arr );

        if( System_run.max_security )
            {               
                for( int index = 0 ; index < _arr.Length ; index++ ){

                    Task_req task = _arr[ index ];
                    if( task == null )
                        { continue; }
                    if( task.unique_id == _task.unique_id )
                        { CONTROLLER__errors.Throw( "Tried to ADD a task in a array, but the task <Color=lightBlue>{ _task.name }</Color> was already in the array" ); }

                }
            }

        if( index_livre == -1 )
            {   
                // --- PRECISA REDIMENSIONAR
                index_livre = _arr.Length;
                _arr = TASK_REQ.Aumentar_length_array_2d( _arr, 20 );
            } 

        _arr[ index_livre ] = _task; 
        _task.slot_id = index_livre;
        return;

    }


}