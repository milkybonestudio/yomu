


using UnityEngine.Device;

public static class CONSTRUCTOR__controller_system_information {


        public static CONTROLLER__system_information Construct(){

            CONTROLLER__system_information controller = new CONTROLLER__system_information();
            CONTROLLER__system_information.instancia = controller;

                controller.ram_memory = SystemInfo.systemMemorySize;
                controller.graphic_memory = SystemInfo.graphicsMemorySize;

                controller.processor_frequency = SystemInfo.processorFrequency;
                controller.processor_cores = SystemInfo.processorCount;


            return controller;

        }


}