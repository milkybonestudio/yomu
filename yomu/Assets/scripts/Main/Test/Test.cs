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
using Unity.Collections.LowLevel.Unsafe;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Management;
using System.IO;

//test
// ** arquivo que controla como o jogo vai ser testado. 
// ** nao pode afetar a build


unsafe public partial class Test : PROGRAM_MODE {

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

                Teste_transicao_program_mode();

        }

        public override void Clean_resources(){}
        public override void Destroy(){}
        public override Transition_program Construct_transition( Transition_program_data _data ){ return Transition_program.Get(); }
        
        // --- INTERN

        private void Start_test_env(){

            contianer_test = GameObject.Find( "Container_teste" );
            
        }

}


