using System;
using UnityEngine;

public static class Construtor_controlador_input {


        public static Controlador_input Construir(){

            Controlador_input controlador = new Controlador_input();
            Controlador_input.instancia = controlador;



                controlador.interfaces_input = new INTERFACE__input_device[ Enum.GetValues( typeof( Input_device ) ).Length ];

                controlador.interfaces_input[ ( int ) Input_device.keyboard_AND_mouse ] = new MODULO__input_keyboard_AND_mouse();
                controlador.interfaces_input[ ( int ) Input_device.mobile ] = new MODULO__input_mobile();
                controlador.interfaces_input[ ( int ) Input_device.game_pad ] = new MODULO__input_game_pad();

                

                // controlador.modulo_input_mobile = Construtor_controlador_input_mobile.Construir(); 
                // controlador.modulo_input_game_pad = Construtor_controlador_input_game_pad.Construir(); 


            return controlador;

        }


}