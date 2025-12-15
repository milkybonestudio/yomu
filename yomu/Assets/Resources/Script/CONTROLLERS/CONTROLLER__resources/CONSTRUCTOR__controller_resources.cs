

using System.Collections.Generic;
using UnityEngine;
using System;

public static class CONSTRUCTOR__controller_resources {

    public static CONTROLLER__resources Construct(){

        CONTROLLER__resources controller = new CONTROLLER__resources();
        
            // --- IMAGES
                controller.images = new MANAGER__resources_images();
                controller.resources_images_sequences = new MANAGER__resources_images_sequences();
                controller.resources_combined_images = new MANAGER__resources_combined_images();

            // --- AUDIOS
                controller.resources_audios = new MANAGER__resources_audios();

            // --- STRUCTURES
                controller.structures = new MANAGER__resources_structures();
                controller.resources_complex_structures = new MANAGER__resources_complex_structures();

            // --- LOGICS
                controller.resources_logics = new MANAGER__resources_logics();


            controller.managers = new Circular_list<MANAGER__RESOURCES>( "Resource managers" );
            controller.managers.Add_elements(new MANAGER__RESOURCES[]{
                controller.images,
                controller.resources_images_sequences,
                controller.resources_combined_images,
                controller.resources_audios,
                controller.structures,
                controller.resources_complex_structures,
                controller.resources_logics
            });


        return controller;

    }

}


