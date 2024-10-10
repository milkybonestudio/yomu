


public static class TASK_REQ {







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

                for( int task_index = 1 ; task_index < _arr.Length ; task_index++ ){

                        Task_req task = _arr[ task_index ];
                        
                        if ( req_com_maior_prioridade == null )
                            { req_com_maior_prioridade = task; }

                        if( task == null )
                            { continue; }
            
                        if( task.prioridade > req_com_maior_prioridade.prioridade ) 
                            { req_com_maior_prioridade = task; }

                        continue;

                }

                return req_com_maior_prioridade;

        }


        public static void Adicionar_task_em_array( ref Task_req[] _arr, Task_req _task ){

                int index_livre = TASK_REQ.Pegar_index_null( _arr );

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