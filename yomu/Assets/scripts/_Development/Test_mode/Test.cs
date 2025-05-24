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
using System;

//test
// ** arquivo que controla como o jogo vai ser testado. 
// ** nao pode afetar a build




unsafe public partial class Test {

        
        public static Test instancia;

        
        // --- properties testing
        
            public Device device;
            public volatile int teste_interlocked;
            public int teste_interlocked_NO;
            

        // --- methods

        public GameObject container_test;

        Single_image image;

        Vector3 _vec;
        public void Construct (){


            
                Start_test_env();

                //--------------------
                            

                device = Example_devices_with_UIs.Construct( Example_devices_with_UIs_types.type_1 );
                
                device.Create(new(){

                    start_state = Device_state.active,
                    parent = container_test, 
                    body_set_data = new(){
                        set_new_transform = true,
                        position = new Vector3( 50,78,65 ),
                    },
                    change_state_data = new(){
                        force = true,
                    }
                });



                test_figures.Set();

                // image = Single_image.Construct( "arvore", Controllers.resources.images.Get_image_reference( Resource_context.images, "a", "arvore", Resource_image_content.compress_data ) );



                return;

        }


        
        public void Update( Control_flow _flow ){

                test_figures?.Update( _flow );

                if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                    { device.Change_state(new(){ new_state = Device_state.nothing, force = true }); }

                if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                    { device.Change_state(new(){ new_state = Device_state.inactive, force = true }); }


                if( Input.GetKeyDown( KeyCode.Alpha3 ) )
                    { device.Change_state(new(){ new_state = Device_state.active, force = true }); }

                if( Input.GetKeyDown( KeyCode.Alpha4 ) )
                    { device.Delete(); }


                device?.Update( _flow );

        }

        
        
        // --- INTERN

        private void Start_test_env(){

            container_test = GameObject.Find( "Container_teste" );
            
        }

}


