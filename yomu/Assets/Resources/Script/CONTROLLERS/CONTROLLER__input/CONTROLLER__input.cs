using System;
using UnityEngine;
using UnityEngine.XR;



// device -> read to key_binds -> pass to Input_value[] -> actions( map )

// *


public struct Input_value {}



public class CONTROLLER__input {


        public static CONTROLLER__input instancia;
        public static CONTROLLER__input Pegar_instancia(){ return instancia; }

        public static Input_value Get_input_value( Input_code _code ){ return instancia._Get_input_value( _code ); }

        public  Input_value _Get_input_value( Input_code _code ){

            return  new Input_value();

        }

        public Input_value[] values;
        public int[] binds;

        //mark
        // ** depois pegar em config
        public Input_device_type input_device_atual = Input_device_type.keyboard_AND_mouse;

        public  Input_device[] interfaces_input; 

        public bool[] teclas_bloqueadas;

        public MANAGER__cursor manager_cursor;

                
        public Pointer_state pointer_state;
        public int click_count;
        public Vector2 pointer_position;


        

        // --- METODOS PRINCIPAIS

        public void Mudar_input_device( Input_device_type _novo_input ){

                Trocador_input_devices.Mudar_input_device( _novo_input );
                input_device_atual = _novo_input;
                return;
                
        }

        // ** mais importante 
        public void Atualizar_key_bind( KeyCode[] _binds ){ interfaces_input[ ( int ) input_device_atual ].Atualizar_key_bind( _binds ); } 


        public bool Get_action( int _acao ){ return interfaces_input[ ( int ) input_device_atual ].Get_action( _acao ); }
        public bool Get_action_down( int _acao ){ return interfaces_input[ ( int ) input_device_atual ].Get_action_down( _acao ); }
        public bool Get_action_up( int _acao ){ return interfaces_input[ ( int ) input_device_atual ].Get_action_up( _acao ); }

        public float Get_value_axis( int _axis ){ return interfaces_input[ ( int ) input_device_atual ].Get_value_axis( _axis ); }
        
        public void Update(){

            // --- POINTER

            // ** nao esta reajustado
            pointer_position = ( Vector2 ) Input.mousePosition;

            // ** move para o centro
            pointer_position.x -= ( Screen.width / 2f );
            pointer_position.y -= ( Screen.height / 2f );

            // ajust unit
            pointer_position.x *=  ( ( 1920f * PPU.value ) / Screen.width );
            pointer_position.y *=  ( ( 1080f * PPU.value )  / Screen.height );


            interfaces_input[ ( int ) input_device_atual ].Update(); 


        }

        public char[] Pegar_teclas(){ return interfaces_input[ ( int ) input_device_atual ].Pegar_teclas(); }



}