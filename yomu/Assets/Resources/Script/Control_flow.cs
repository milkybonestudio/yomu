


public class Control_flow {


        // --- UI

        public bool UI_blocked;
        public void Block_UI(){ UI_blocked = true; }
        public void Unblock_UI(){ UI_blocked = false; }
        public void Set_UI( bool _value ){ UI_blocked = _value; }        
        
        // --- PROGRAM

        public bool program_mode_update_blocked;
        public void Block_program_mode_update(){ program_mode_update_blocked = true; }
        public void Unblock_program_mode_update(){ program_mode_update_blocked = false; }
        public void Set_program_mode_update( bool _value ){ program_mode_update_blocked = _value; }

        // --- cpu consuming stuff
        private const int WEIGHT_MS = 10_000;
        private const int pegar_do_user = 10;

        public static int Get_weight( int _number_operations_per_second, int _operations ){

            unchecked{

                long operations_per_miliseconds = (long)_number_operations_per_second / 1_000l;
                // Console.Log( "operations_per_miliseconds: " + operations_per_miliseconds );

                // Console.Log( "operations: " + _operations );
                // Console.Log( "WEIGHT_MS: " + WEIGHT_MS );
                

                int weight_to_operations =  ( int )( ( (long)_operations * (long) WEIGHT_MS ) / operations_per_miliseconds );
                // Console.Log( "weight_to_operations: " + weight_to_operations );

                return weight_to_operations ;

            }

        }

        public int weight_per_frame = ( WEIGHT_MS * pegar_do_user );
        public int weight_frame_available = ( WEIGHT_MS * pegar_do_user );

        public void Add_weight( int _weight ){ 

            weight_frame_available -= _weight;

        }

        public bool cpu_consuming_operation_blocked;
        public float block_cpu_consuming_operation_time_ms;
        public void Block_cpu_consuming_operation( float _time ){ cpu_consuming_operation_blocked = true; block_cpu_consuming_operation_time_ms += _time; }
        public void Unblock_cpu_consuming_operation(){ cpu_consuming_operation_blocked = false; block_cpu_consuming_operation_time_ms = 0f; }


        public bool resources_blocked;
        public float resources_blocked_time_ms;
        public void Block_resources( float _time ){ resources_blocked = true; resources_blocked_time_ms += _time; }
        public void Unblock_resources(){ resources_blocked = false; resources_blocked_time_ms = 0f; }


        public bool saving_blocked; 
        public float saving_blocked_time_ms; 
        public void Block_saving( float _time ){ saving_blocked = true; saving_blocked_time_ms += _time; }
        public void Unblock_saving(){ saving_blocked = false; saving_blocked_time_ms = 0f; }


        
}


