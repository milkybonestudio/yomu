


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

        public int weight_frame_available = int.MaxValue;

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


