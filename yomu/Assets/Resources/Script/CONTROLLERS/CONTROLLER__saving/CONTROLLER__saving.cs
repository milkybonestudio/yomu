
using System.IO;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class CONTROLLER__saving {

    public static CONTROLLER__saving instancia;
    public static CONTROLLER__saving Pegar_instancia(){ return instancia; }

    public MANAGER__controller_saving_saver saver;
    
    public Saving_state state;
    

    public bool Update(){

        switch( state ){

            case Saving_state.waiting_to_save_files: return Handle_waiting_to_save_files();
            case Saving_state.saving_files: return Handle_saving_files();
            default: CONTROLLER__errors.Throw( "can not handle type: " + state ); return false;

        }
        
    }

    private const bool BLOCK_UPDATE = true;
    private const bool LIBERATE_UPDATE = true;

    private bool Handle_saving_files(){

        if( saver.Finish_saving_files() )
            {
                Controllers.stack.Sinalize_saved_all_files();
                state = Saving_state.waiting_to_save_files;
            }

        return BLOCK_UPDATE;

    }

    private bool Handle_waiting_to_save_files(){


        if(  Controllers.stack.saver.Stack_file_is_close_to_end() && ( Controllers.stack.state == SAFETY_STACK__state.waiting_to_save_stack ) )
            { 
                Console.Log( "will save files" );
                state = Saving_state.saving_files;
                saver.Start_saving_files();
                return BLOCK_UPDATE;
            }

        return LIBERATE_UPDATE;
        
    }


}



