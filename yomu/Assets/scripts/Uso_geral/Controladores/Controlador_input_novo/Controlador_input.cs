using System;
using UnityEngine;
using UnityEngine.XR;


public class Controlador_input {


        public static Controlador_input instancia;
        public static Controlador_input Pegar_instancia(){ return instancia; }

        public Input_device input_device_atual;

        public  INTERFACE__input_device[] interfaces_input; 

        public bool[] teclas_bloqueadas;
        

        // --- METODOS PRINCIPAIS

        public void Mudar_input_device( Input_device _novo_input ){

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
        
        public void Update(){ interfaces_input[ ( int ) input_device_atual ].Update(); }

        public char[] Pegar_teclas(){ return interfaces_input[ ( int ) input_device_atual ].Pegar_teclas(); }



}