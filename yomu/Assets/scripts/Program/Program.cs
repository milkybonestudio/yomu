using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Numerics;
using System.Reflection;


unsafe public class Program : MonoBehaviour {


        public static Program Get_instance() { return instance; }
        public static Program instance;

        public Program_mode current_mode;

        public PROGRAM_MODE[] modes;
        public Control_flow control_flow;

        public Action<Control_flow> Update_development;
        
        

        public void Awake(){

                Console.Start();
                CONSTRUCTOR__program.Construir( this ); 
                Console.Update();

        }


        public void Update() {

                
                // --- ALWAYS
                TOOL__information_setter.Set();
                Controllers.input.Update();
                TOOL__cleaner_control_flow.Clean( control_flow );

                #if UNITY_EDITOR
                    Update_development( control_flow );
                #endif

                // --- 
                Controllers.canvas_spaces.Update( control_flow );
                Controllers.resources.Update( control_flow );
                Controllers.tasks.Update( control_flow );

                Controllers_program.program_transition.Update( control_flow );

                if( !!!( control_flow.program_mode_update_blocked ) )
                    { Current_mode().Update( control_flow ); }
                

                Console.Update(); // --- SEMPRE POR ULTIMO
                
            
        }


        private PROGRAM_MODE Current_mode(){ return modes[ ( int ) current_mode ]; }

        public void OnApplicationQuit(){ OnApplicationPause( true ); }

        public void OnApplicationPause( bool _pause ){

                // ** para mobile, nunca pausa no pc

                #if UNITY_EDITOR



                #endif
                

        }


        // ** somente editor
        public void OnDisable(){

                
                Dados_fundamentais_sistema.jogo_ativo = false;
                
                Program_modes.game?.Destroy();
                Program_modes.login?.Destroy();
                Program_modes.menu?.Destroy();
            
                MANAGER__textures_resources.Clean_all();

                Controllers_program.data?.Destroy();
                Controllers.saving?.Destroy();

                Console.Update();

                
        }

        

}


