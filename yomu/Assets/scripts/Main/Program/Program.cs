using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Numerics;




unsafe public class Program : MonoBehaviour {


        // o editor sempre simula o jogo real, todo arquivo que precisa existir no jogo final vai ser criado antes?


        // ** only enditor
        public static bool _jogo_ativo = true;


        public static Program Pegar_instancia() { return instancia; }
        public static Program instancia;


        public Program_mode current_mode;

        public GameObject canvas; 
        public PROGRAM_MODE[] modes;
        public Control_flow control_flow = new Control_flow();

        public Action<Control_flow> Update_development = ( Control_flow _control )=>{};
        
        

        public void Awake(){

                Console.Start();
                Dados_fundamentais_sistema.jogo_ativo = true; 
                CONSTRUCTOR__program.Construir( this ); 
                Console.Update();

        }   




        public void Update() {


                Console.Log_slow( $"Modo atual: <Color=lightBlue>{ current_mode }</Color>" );

                // --- ALWAYS
                TOOL__information_setter.Set();
                Controllers.input.Update();
                TOOL__cleaner_control_flow.Clean( control_flow );

                #if UNITY_EDITOR
                    Update_development( control_flow );
                #endif

                // --- 
                Controllers.cameras.Update( control_flow );
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

                
        }

        

}


