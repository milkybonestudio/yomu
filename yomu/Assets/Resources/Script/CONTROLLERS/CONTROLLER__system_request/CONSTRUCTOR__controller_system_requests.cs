


using UnityEngine.Device;

public static class CONSTRUCTOR__controller_system {


        public static CONTROLLER__system Construir(){

            CONTROLLER__system controller = new CONTROLLER__system();
            CONTROLLER__system.instancia = controller;

                controller.ram_memory = SystemInfo.systemMemorySize;
                controller.graphic_memory = SystemInfo.graphicsMemorySize;

                controller.processor_frequency = SystemInfo.processorFrequency;
                controller.processor_cores = SystemInfo.processorCount;


            return controller;

        }


}