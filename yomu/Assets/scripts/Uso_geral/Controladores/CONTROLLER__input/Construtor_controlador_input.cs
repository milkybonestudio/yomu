using System;
using UnityEngine;

public static class CONSTRUCTOR__controller_input {


        public static CONTROLLER__input Construct(){

            CONTROLLER__input controlador = new CONTROLLER__input();
            CONTROLLER__input.instancia = controlador;



                controlador.interfaces_input = new INTERFACE__input_device[ Enum.GetValues( typeof( Input_device ) ).Length ];

                controlador.interfaces_input[ ( int ) Input_device.keyboard_AND_mouse ] = new MODULO__input_keyboard_AND_mouse();
                controlador.interfaces_input[ ( int ) Input_device.mobile ] = new MODULO__input_mobile();
                controlador.interfaces_input[ ( int ) Input_device.game_pad ] = new MODULO__input_game_pad();

                

                // controlador.modulo_input_mobile = Construtor_controlador_input_mobile.Construir(); 
                // controlador.modulo_input_game_pad = Construtor_controlador_input_game_pad.Construir(); 


            return controlador;

        }


}