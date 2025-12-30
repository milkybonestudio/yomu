using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Numerics;
using System.Reflection;
using System.Threading;
using System.Collections.Generic;


unsafe public class Program : MonoBehaviour {

    public static Program Get_instance() { return instance; }
    public static Program instance;

    public Program_mode current_mode;

    public Dictionary<Program_mode,PROGRAM_MODE> modes;
    
    public Action Update_development;
    
    public Program_update_mode current_update_mode;

    public void Awake(){

        System_run.main_thread_id = Thread.CurrentThread.ManagedThreadId;

        Console.Start();
            CONSTRUCTOR__program.Construir( this );
        Console.Update();

    }


    public void Update() {

        if( System_run.force_stop )
            { return; }


    
        // --- ALWAYS
        SYSTEM.Update();
        Controllers.input.Update();
        Control_flow.Clean();


        #if UNITY_EDITOR
            Update_development();
        #endif

        Controllers.stack.Update();

        // --- 
        Controllers.canvas_spaces.Update();
        Controllers.resources.Update();
        Controllers.tasks.Update();

        Controllers.program_transition.Update();
        Controllers.files.Update();

        switch( current_update_mode ){
            case Program_update_mode.modes: Update_mode(); break;
            case Program_update_mode.nothing: break;
            case Program_update_mode.waiting_task: break;
            case Program_update_mode.transition: Controllers.program_transition.Update(); break;
        }
        
        Console.Update(); // --- SEMPRE POR ULTIMO
        
        return;
        
    }

    private void Update_mode(){

        if( Controllers.saving.Update() )
            { return; }

        if( Control_flow.program_mode_update_blocked )
            { return; }

        if( System_run.max_security )
            {
                if( current_mode >= Program_mode.END )
                    { CONTROLLER__errors.Throw( "tried to get the program mode: " + current_mode ); }

                if( !!!( modes.ContainsKey( current_mode ) ) )
                    { CONTROLLER__errors.Throw( $"tried to get the program mode <Color=lightBlue>{ current_mode }</Color> but the mode is null" ); }
            }

        modes[ current_mode ].Update();

        return;

    }



    public void OnApplicationQuit(){ OnApplicationPause( true ); }



    public void OnApplicationPause( bool _pause ){

        // ** para mobile, nunca pausa no pc
        // -> onApplicationQuit nunca é chamado, tem que ser feito em onApplicationPause
        // -> onApplicationPause é chamado quando a thread demora muito tempo para executar

        #if UNITY_EDITOR

        #endif
            

    }


    // ** somente editor
    public void OnDisable(){


        System_run.force_stop = false;
        System_run.game_on = false;
        
        
        Program_modes.game?.Destroy();
        Program_modes.menu?.Destroy();
    
        // ** NAO FAZ SENTIDO
        MANAGER__textures_resources.Clean_all();

        // ** structs type
        Controllers.saving.Destroy();
        Controllers.stack.Destroy();
        Controllers.packets.Destroy();
        Controllers.context.Destroy();
        Controllers.paths_ids.Destroy();

        Controllers.tasks?.Destroy();
        Controllers.heap?.Destroy();

        Controllers.resources.Destroy();


        Console.Update();

    }


}


