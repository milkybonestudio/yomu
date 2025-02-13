using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.Diagnostics;

//test
// ** arquivo que controla como o jogo vai ser testado. 
// ** nao pode afetar a build





unsafe public class Test : PROGRAM_MODE {

        public Test(){ 
            type = Program_mode.test; 
            instancia = this;
        }
        
        
        public static Test instancia;

        


        // --- properties testing
        
            public Figure figure;   
            public Device device;
            public volatile int teste_interlocked;
            public int teste_interlocked_NO;
            

        // --- methods

        public GameObject contianer_test;
        

        public override void Construct (){

                Start_test_env();
                //-------------------------------------
            
                // device = Example_devices_with_UIs.Construct( Example_devices_with_UIs_types.type_1 );
                // device.Instanciate( contianer_test );


                //--------------------
                return;


        }

        
        public override void Update( Control_flow _flow ){


                Console.Log( "a" );
                if( Input.GetKeyDown( KeyCode.B ) )
                    { 
                        
                        Lock_program_data* LOCK = Program_data.Get_lock( Program_mode.login );
                        LOCK->put_data = true;
                        Controllers_program.program_transition.Switch_program_mode( Program_mode.login, new Transition_data() );
                    }


                if( Input.GetKeyDown( KeyCode.N ) )
                    { Controllers_program.program_transition.Switch_program_mode( Program_mode.menu, new Transition_data() ); }


                if( Input.GetKeyDown( KeyCode.M ) )
                    { Controllers_program.program_transition.Switch_program_mode( Program_mode.jogo, new Transition_data() ); }



                    

                if( Input.GetKeyDown( KeyCode.J ) )
                    { figure.Activate_emoji( Figure_emoji.heart ); }


        }

        public override void Clean_resources(){}
        public override void Destroy(){}
        public override Transition Construct_transition( Transition_data _data ){ return new Transition(); }
        
        // --- INTERN

        private void Start_test_env(){

            contianer_test = GameObject.Find( "Container_teste" );
            
        }

}

