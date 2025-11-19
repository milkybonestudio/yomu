using System;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime.CompilerServices;



public enum SAFETY_STACK__state {

    waiting_to_save_stack,
    saving_stack,

    waiting_files_to_end_saving,

}

unsafe public struct CONTROLLER__safety_stack {


    // MESSAGE:    [ type ] [ size ] [ body ]
    // first 8 bytes always used for the same thing 


    public void Destroy(){

        // saver.strem_stack?.Close();


        packet_storage.End();
        files.End();

    // --- MANAGER__stack_safety

        saver.End();
        buffer.End();
        

    }


    // ** TIME
    public float last_update_ms;
    public float minimun_time_to_save_ms;

    public const int THRESHOLD_TO_ACCEPT_LOOP = 200_000;


    public int safety_file_size;

    public Heap_key message_heap_key;
    public void* pointer_with_message;
    public int message_max_size;

    // --- MESSAGES UTILITY

    public MANAGER__safety_stack_packet_storage packet_storage;
    public MANAGER__safety_stack_files files;


    // --- MANAGER__stack_safety

    public MANAGER__safety_stack_saver saver;
    public MANAGER__safety_stack_buffer buffer;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Save_message( int _message_length ){ buffer.Save_data_inline( pointer_with_message, _message_length ); }

    unsafe public struct Teste{

        // ** não devia ficar esposto
        public void Save_data( byte[] _data, int _length ){ Controllers.stack.buffer.Save_data( _data, _length ); }
        public void Save_data( void* _data_pointer, int _length ){ Controllers.stack.buffer.Save_data_inline( _data_pointer, _length ); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Save_data_inline( void* _data_pointer, int _length ){ Controllers.stack.buffer.Save_data_inline( _data_pointer, _length ); }

    }

    public Teste test;




    public SAFETY_STACK__state state;
    public void Update( Control_flow _control_flow ){

        
        if( System_run.show_stack_messages_update  )
            { 
                Console.Log_slow( "update stack" );
                Console.Log_slow( "state: " + state );
            }

        
        if( !!!( System_run.activate_controller_safety_stack ) )
            { return; }

        if( System_run.max_security && ( minimun_time_to_save_ms < 100f ) )
            { CONTROLLER__errors.Throw( $"<Color=lightBlue>minimun_time_to_save_ms</Color> is just { minimun_time_to_save_ms }, should be no lower than 100ms" ); }


        switch( state ){
            case SAFETY_STACK__state.saving_stack: Handle_saving( _control_flow ); break;
            case SAFETY_STACK__state.waiting_to_save_stack : Handle_waiting_to_save_stack( _control_flow ); break;
            case SAFETY_STACK__state.waiting_files_to_end_saving: Handle_waiting_files_to_end_saving(); break;
            default: CONTROLLER__errors.Throw( "Can not handle type: " + state ); break;
        }

    }




    // ** SAVE FILES

    public Task_req Sinalize_will_save_files(){
        
        if( System_run.max_security && state != SAFETY_STACK__state.waiting_to_save_stack )
            { CONTROLLER__errors.Throw( $"Called Sinalize_saved_all_files but the state is { state }" ); }

        state = SAFETY_STACK__state.waiting_files_to_end_saving;

        return saver.Sinalize_to_save();

    }

    public void Sinalize_saved_all_files(){

        if( System_run.max_security && state != SAFETY_STACK__state.waiting_files_to_end_saving )
            { CONTROLLER__errors.Throw( $"Called Sinalize_saved_all_files but the state is { state }" ); }

        
        saver.Sinalize_saved_all_files();
        buffer.Sinalize_saved_all_files();

        state = SAFETY_STACK__state.waiting_to_save_stack;

        return;

    }



    // ** HANDLERS


    private void Handle_waiting_files_to_end_saving(){

        if( Controllers.files.state != Controller_data_files_state.saving_files )
            { CONTROLLER__errors.Throw( $"The state of Controller stack is { state } but the state in the controller_data_files is <Color=lightBlue>{ Controllers.files.state }</Color>" ); }

        return;

    }

    private void Handle_saving( Control_flow _control_flow ){

        if( System_run.show_stack_messages_update )
            { 
                Console.Log( "Call <Color=lightBlue>Saving()</Color>" );
                Console.Log( "is stack already saved: " + saver.req_saving.Is_finalized() );
            }
        
        if( saver.req_saving.Is_finalized() )
            { 
                //mark
                // ** mudei para ca, antes estava no final de Save_in_disk do saver
                // ** mas para reaproveirar quando estiver salvando os arquivos precisa estar aqui
                // ** porque no fluxo normal
                buffer.Return_pointer_to_pass_data_to_disk(); // ** BUFFER CAN REALOCATE DATA NOW
                Change_state( SAFETY_STACK__state.waiting_to_save_stack );
                last_update_ms = 0f;
            }
            
        return;

    }

    private void Handle_waiting_to_save_stack( Control_flow _control_flow  ){


        bool time_is_over = ( last_update_ms > minimun_time_to_save_ms );
        bool have_data = Have_data_to_save();

        if( System_run.show_stack_messages_update )
            {
                Console.Log( "Call <Color=lightBlue>Waiting_to_save_stack()</Color>" );
                Console.Log( "last_update_ms: " + last_update_ms ); 
                Console.Log( "time_is_over: " + time_is_over ); 
                Console.Log( "have_data: " + have_data ); 
            }

        
        if( buffer.Can_loop() )
            { 
                // ** here the pointer pass the line to save

                int number_of_bytes_still_used = buffer.Get_bytes_in_normal_buffer_still_not_saved();

                if( number_of_bytes_still_used < THRESHOLD_TO_ACCEPT_LOOP )
                    {
                        // ** if there is 400kb of data no save, and just 10 bytes "not being used"/ already saved
                        // ** why lose almost half a ms on moving it?
                        // ** just wait and maybe it will save the 400kb and after can move 0/almost 0 bytes
                        if( System_run.show_stack_messages_update )
                            { Console.Log( "Have a few bytes, will loop" ); }

                        int weight_of_loop = buffer.Loop();
                        _control_flow.Add_weight( weight_of_loop );

                    }
                    else
                    {
                        if( System_run.show_stack_messages_update )
                            { Console.Log( $"have <Color=lightBlue>{ number_of_bytes_still_used }</Color> that is more than the threshold <Color=lightBlue>{ THRESHOLD_TO_ACCEPT_LOOP }</Color>. So it can not loop" ); }
                    }

            }
        

        if( !!!( have_data ) )
            {
                if( System_run.show_stack_messages_update )
                    { Console.Log( "Didnt have any data to save in the stack. <Color=lightBlue>Will return</Color>" ); }

                return;
            }

        last_update_ms += ( Time_info.delta_time * 1_000f );

        if( !!!( time_is_over ) )
            { return; }


        Save_stack();

        return;

    }

    private void Save_stack(){

        if(  System_run.save_in_disk_controller_safety_stack )
            { 
                if( System_run.show_stack_messages )
                    { Debug.Log( "Sinalise to save data" ); }

                saver.Sinalize_to_save(); 
            }

        last_update_ms = 0f;
        Change_state(  SAFETY_STACK__state.saving_stack );

        return;

    }


    public void Change_state( SAFETY_STACK__state _state ){

        
        if( _state == SAFETY_STACK__state.waiting_files_to_end_saving )
            {
                if( state == SAFETY_STACK__state.saving_stack )
                    { CONTROLLER__errors.Throw( $"tried to change state of the stack to <Color=lightBlue>{ _state }</Color>, but the current one is <Color=lightBlue>{ state }</Color>. It can not save 2 at same time" ); }
            }

        if( _state == SAFETY_STACK__state.waiting_files_to_end_saving )
            {
                if( state == SAFETY_STACK__state.saving_stack )
                    { CONTROLLER__errors.Throw( $"tried to change state of the stack to <Color=lightBlue>{ _state }</Color>, but the current one is <Color=lightBlue>{ state }</Color>. it need to change to waiting" ); }
            }

        if( System_run.show_stack_messages_update )
            { Console.Log( $"Will change state to <Color=lightBlue>{ _state }</Color>" ); }
    
        state = _state;

        return;

    }

    // ** SUPPORT


    public bool Have_data_to_save(){

        return ( ( buffer.pointer_in_buffer - saver.pointer_buffer_already_saved - 1 ) > 0 );

    }

    public void Need_to_add_stack_function(){

        if( System_run.show_stack_messages )
            { Console.Log( "Need to add stack function" ); }

        return;

    }


    // --- TEST

    public void Print_data(){

        Console.Log( "--- WILL PRINT STACK DATA ---"  );

        Console.Log( "state: " + state );
        saver.Print_data();
        buffer.Print_data();

        return;

    }


    public void Force_change_state( SAFETY_STACK__state _state ){

        state = _state;
        return;

    }

    public void Force_try_to_save_stack(){

        if( System_run.show_stack_messages_update )
            { Console.Log( "Came Force_try_to_save_stack()" ); }

        if( !!!( Have_data_to_save() ) )
            {
                if( System_run.show_stack_messages_update )
                    { Console.Log( "have no data in the stack to save" ); }
                
                return;
            }


        if( state != SAFETY_STACK__state.waiting_to_save_stack )
            { 
                if( System_run.show_stack_messages_update )
                    { 
                        Console.Log( $"Came to Force_try_to_save_stack() but the state is <Color=lightBlue>{ state }</Color>" ); 
                        Console.Log( "Will set the last_update to necessary to save as soon as possible" );
                    }
                
                last_update_ms = ( 2 * minimun_time_to_save_ms );
                
                return; 
            }

        Save_stack();

        return;

    }

    public void Save_stack_in_disk_sync(){

        // ** never change state

        if( state != SAFETY_STACK__state.waiting_to_save_stack )
            { CONTROLLER__errors.Throw( "State need to be <Color=lightBlue>waiting_to_save_stack</Color>" ); }

        Task_req req = saver.Sinalize_to_save();
        req.fn_multithread( req );
        req.stage = Task_req_stage.finished;
        buffer.Return_pointer_to_pass_data_to_disk();

    }


}
