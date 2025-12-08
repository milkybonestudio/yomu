using System;
using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine;


unsafe public class CONTROLLER__development {


    // ** WILL BE CALLED BY REFLECTION

    public static CONTROLLER__development Pegar_instancia(){ return instancia; }
    public static CONTROLLER__development instancia;
    
    public CONTROLLER__development(){ instancia = CONSTRUCTOR__controller_development.Construct( this ); }

    public Development_tools development_tools;
    
    public Program program;

    public Test test;

    public In_game_test current_test;

    public Development_mode[] development_modes;
    

    public static void Apply_development_modifications_end(){ instancia._Apply_development_modifications_end(); }
    public static void Apply_development_modifications_start(){ instancia._Apply_development_modifications_start(); }
    public static Action<Control_flow> Get_update(){ return Update; }
    public static void Update( Control_flow _flow ){ instancia._Update( _flow ); }


    private void _Apply_development_modifications_start(){

        if( Editor_run.delete_version_folder )
            {
                if( System.IO.Directory.Exists( Paths_system.persistent_data ) )
                    { 
                        System.IO.Directory.Delete( Paths_system.persistent_data, true ); 
                        Directory.CreateDirectory( Paths_system.persistent_data );
                    }
                if( Editor_run.reset_version_folder )
                    { TOOL__version_folders_constructor.Construct(); }
                
            }

        return;

    }



    private void _Apply_development_modifications_end(){

        development_modes[ ( int ) Editor_run.type_testing ].Apply_development_modifications_end( this );

    }

        
    public void _Update( Control_flow _flow ){

        Simulate_others_pcs();
        development_modes[ ( int ) Editor_run.type_testing ].Update( program.control_flow, this );

        return;
        
    }
        


    int acc = 0;
    private void Simulate_others_pcs(){

        int times = 0;

        switch( Editor_run.level_machine ){

            case Level_machine.max: times = 0; break;
            case Level_machine.ok: times  = 1_500_000; break; // 3ms
            case Level_machine.mid: times = 4_000_000; break; // 8ms
            case Level_machine.bad: times = 8_000_000; break; // 16ms
            case Level_machine.potato: times = 16_000_000; break; // 32ms

        }

        // ** 500mil /s -> 500k/ms
        for( int time_to_lose = 0; time_to_lose < times ;time_to_lose++ )
            { acc += time_to_lose % 3; }
        
        return;

    }




}