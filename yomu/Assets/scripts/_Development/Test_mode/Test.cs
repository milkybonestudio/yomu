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
                            

                // device = Example_devices_with_UIs.Construct( Example_devices_with_UIs_types.type_1 );
                
                // device.Create(new(){

                //     start_state = Device_state.active,
                //     parent = container_test, 
                //     body_set_data = new(){
                //         set_new_transform = true,
                //         position = new Vector3( 50,78,65 ),
                //     },
                //     change_state_data = new(){
                //         force = true,
                //     }
                // });



                // test_figures.Set();

                // image = Single_image.Construct( "arvore", Controllers.resources.images.Get_image_reference( Resource_context.images, "a", "arvore", Resource_image_content.compress_data ) );


                Console.Log( "WILL ACTIVATE TEST" );
                TO_DELETE_AFTER.Set();

                return;

        }
        
        void f(){
            
            
            

        }

        
        

        public void Update( Control_flow _flow ){


                TO_DELETE_AFTER.Update();

                // test_figures?.Update( _flow );

                // if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                //     { device.Change_state(new(){ new_state = Device_state.nothing, force = true }); }

                // if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                //     { device.Change_state(new(){ new_state = Device_state.inactive, force = true }); }


                // if( Input.GetKeyDown( KeyCode.Alpha3 ) )
                //     { device.Change_state(new(){ new_state = Device_state.active, force = true }); }

                // if( Input.GetKeyDown( KeyCode.Alpha4 ) )
                //     { device.Delete(); }


                // device?.Update( _flow );

        }

        
        
        // --- INTERN

        private void Start_test_env(){

            container_test = GameObject.Find( "Container_teste" );
            
        }



        public static void SHOULD_FAIL( string _test, Action _a ){

            string message = null;
            try { _a(); message = "<Color=red>{ SHOULD FAIL }</Color>"; } 
            catch{ message = "<Color=lime>{ FAIL }</Color>"; }

            Console.Log( $"-->> test: <Color=lightBlue>{ _test }</Color> || { message }" );
            

        }


        public static void SHOULD_PASS( string _test, Action _a ){

            string message = null;
            try { _a(); message = "<Color=lime>{ PASS }</Color>"; } 
            catch{ message = "<Color=red>{ FAIL }</Color>"; }

            Console.Log( $"-->> test: <Color=lightBlue>{ _test }</Color> || { message }"  );
            
        }


        public static void Assert( Assert_fn fn_1  ){

            if( fn_1 != null )
                {
                    Ressult_assert assert = fn_1();

                    string message = null;
                    if( assert.pass )
                        { message = ( $"<Color=lime>{{ PASS }}</Color>" ); }
                        else
                        { 
                                
                            message = ( $"<Color=red>{{ FAIL }}</Color>" ); 

                            if( assert.object_on_fail != null )
                                { message +=  $" || OBJECT FAIL: <Color=lightBlue>{ assert.object_on_fail.ToString() }</Color>";  }
                        }

                    Console.Log( $"-->> test: <Color=lightBlue>{ assert.test }</Color> || { message }" );
                }

            /*

                Test.Assert(()=>new(
                    "",
                    ( BOOL )
                ));
            */


        }

        public static void Assert( Assert_fn[] _fns ){

            foreach( Assert_fn _fn in _fns )
                { Assert( _fn ); }


            /*

                Test.Assert(new Assert_fn[]{

                    () => new ( "",( BOOL ) )

                });
            
            */


        }






}

public delegate Ressult_assert Assert_fn();

public class Ressult_assert{

    public Ressult_assert( string _test, bool _pass, object _object_on_fail = null ){
        test = _test;
        pass = _pass;
        object_on_fail = _object_on_fail;
    }

    public string test;
    public bool pass;
    public object object_on_fail;

}


