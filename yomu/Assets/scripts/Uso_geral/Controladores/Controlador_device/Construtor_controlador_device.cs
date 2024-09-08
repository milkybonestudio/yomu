using UnityEngine;

public static class Construtor_controlador_device {


        public static Controlador_device Construir(){

            Controlador_device controlador = new Controlador_device();
            Controlador_device.instancia = controlador;

                controlador.device = SystemInfo.deviceType;


            return controlador;

        }


}