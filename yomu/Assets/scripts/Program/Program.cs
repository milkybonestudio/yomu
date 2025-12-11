using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Numerics;
using System.Reflection;
using System.Threading;


unsafe public class Program : MonoBehaviour {

    public static Program Get_instance() { return instance; }
    public static Program instance;

    public Program_mode current_mode;

    public PROGRAM_MODE[] modes;
    public Control_flow control_flow;

    public Action<Control_flow> Update_development;
    
    

    public void Awake(){

        System_information.main_thread_id = Thread.CurrentThread.ManagedThreadId;

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
        TOOL__cleaner_control_flow.Clean( control_flow );


        #if UNITY_EDITOR
            Update_development( control_flow );
        #endif

        Controllers.stack.Update( control_flow );

        // --- 
        Controllers_program.canvas_spaces.Update( control_flow );
        Controllers.resources.Update( control_flow );
        Controllers.tasks.Update( control_flow );

        Controllers_program.program_transition.Update( control_flow );
        Controllers.files.Update();

        if( Controllers.saving.Update() )
            { Console.Update(); return; }

        Update_mode( control_flow );
        
        Console.Update(); // --- SEMPRE POR ULTIMO
        
        return;
        
    }

    private void Update_mode( Control_flow _control_flow ){

        
        if( control_flow.program_mode_update_blocked )
            { return; }

        if( System_run.max_security )
            {
                if( current_mode >= Program_mode.END )
                    { CONTROLLER__errors.Throw( "tried to get the program mode: " + current_mode ); }

                if( modes[ ( int ) current_mode ] == null )
                    { CONTROLLER__errors.Throw( $"tried to get the program mode <Color=lightBlue>{ current_mode }</Color> but the mode is null" ); }
            }

        modes[ ( int ) current_mode ].Update( _control_flow );

        return;

    }


    public void OnApplicationQuit(){ OnApplicationPause( true ); }

    public void OnApplicationPause( bool _pause ){

        // ** para mobile, nunca pausa no pc
        #if UNITY_EDITOR

        #endif
            

    }


    // ** somente editor
    public void OnDisable(){


        System_run.force_stop = false;
        Dados_fundamentais_sistema.jogo_ativo = false;
        
        
        Program_modes.game?.Destroy();
        Program_modes.login?.Destroy();
        Program_modes.menu?.Destroy();
    
        // ** NAO FAZ SENTIDO
        MANAGER__textures_resources.Clean_all();

        // ** structs type
        Controllers.saving.Destroy();
        Controllers.stack.Destroy();
        Controllers.packets.Destroy();
        Controllers.context.Destroy();
        Controllers.paths_ids.Destroy();

        Controllers_program.data?.Destroy();
        Controllers.tasks?.Destroy();
        Controllers.heap?.Destroy();

        Controllers.resources.Destroy();


        Console.Update();

    }


    public static void Force_crash_program(){

        byte* p = (byte*)Marshal.AllocHGlobal( 1 );

        for( int index = 0 ; index < 10_000 ; index++ )
            { p[ index ] = 1; }

    }

    

        

}


