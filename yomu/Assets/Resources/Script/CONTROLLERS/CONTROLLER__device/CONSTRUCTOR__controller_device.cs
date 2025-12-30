using UnityEngine;

public static class CONSTRUCTOR__controller_device {

    public static CONTROLLER__device Construir(){

        CONTROLLER__device controlador = new CONTROLLER__device();
        controlador.type =  SystemInfo.deviceType;

        return controlador;

    }

}

