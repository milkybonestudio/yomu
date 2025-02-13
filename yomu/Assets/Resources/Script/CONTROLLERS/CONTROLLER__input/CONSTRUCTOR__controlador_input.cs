using System;
using UnityEngine;

public static class CONSTRUCTOR__controller_input {


        public static CONTROLLER__input Construct(){

            CONTROLLER__input controlador = new CONTROLLER__input();
            CONTROLLER__input.instancia = controlador;


                controlador.interfaces_input = new Input_device[ ( int ) ( Input_device_type.END ) ];

                controlador.interfaces_input[ ( int ) Input_device_type.keyboard_AND_mouse ] = new INPUT_DEVICE__keyboard_and_mouse();
                controlador.interfaces_input[ ( int ) Input_device_type.mobile ] = new MODULO__input_MOBILE();
                controlador.interfaces_input[ ( int ) Input_device_type.game_pad ] = new MODULO__input_GAME_PAD();

                controlador.manager_cursor = new MANAGER__cursor();

                

                // controlador.modulo_input_mobile = Construtor_controlador_input_mobile.Construir(); 
                // controlador.modulo_input_game_pad = Construtor_controlador_input_game_pad.Construir(); 


            return controlador;

        }


}