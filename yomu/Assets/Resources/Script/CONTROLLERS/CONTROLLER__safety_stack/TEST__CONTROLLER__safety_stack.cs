


using System.Runtime.CompilerServices;

unsafe public struct TEST__CONTROLLER__safety_stack {

    // ** não devia ficar esposto
    public void Save_data( byte[] _data, int _length ){ Controllers.stack.buffer.Save_data( _data, _length ); }
    public void Save_data( void* _data_pointer, int _length ){ Controllers.stack.buffer.Save_data_inline( _data_pointer, _length ); }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Save_data_inline( void* _data_pointer, int _length ){ Controllers.stack.buffer.Save_data_inline( _data_pointer, _length ); }

    public void Save_stack_in_disk_sync(){

        // ** never change state

        if( Controllers.stack.state != SAFETY_STACK__state.waiting_to_save_stack )
            { CONTROLLER__errors.Throw( "State need to be <Color=lightBlue>waiting_to_save_stack</Color>" ); }

        Task_req req = Controllers.stack.saver.Sinalize_to_save();
            req.fn_multithread( req );
            req.stage = Task_req_stage.finished;
        Controllers.stack.buffer.Return_pointer_to_pass_data_to_disk();

    }



}

