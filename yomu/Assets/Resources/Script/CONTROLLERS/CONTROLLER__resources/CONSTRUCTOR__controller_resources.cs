

using System.Collections.Generic;
using UnityEngine;
using System;

public static class CONSTRUCTOR__controller_resources {


        public static CONTROLLER__resources Construct(){


                CONTROLLER__resources controller = new CONTROLLER__resources();
                CONTROLLER__resources.instance = controller;

                    controller.managers = new Circular_list<MANAGER__RESOURCES>( "Resource managers", Circular_list_handle_no_element.error );

                        controller.resources_images = ( MANAGER__resources_images ) controller.managers.Add( new MANAGER__resources_images() );
                        controller.resources_images_sequences = ( MANAGER__resources_images_sequences ) controller.managers.Add( new MANAGER__resources_images_sequences() );

                        controller.resources_audios = ( MANAGER__resources_audios ) controller.managers.Add( new MANAGER__resources_audios() );

                        controller.resources_structures = ( MANAGER__resources_structures ) controller.managers.Add( new MANAGER__resources_structures() );
                        controller.resources_complex_structures = ( MANAGER__resources_complex_structures ) controller.managers.Add( new MANAGER__resources_complex_structures() );

                        controller.resources_logics = ( MANAGER__resources_logics ) controller.managers.Add( new MANAGER__resources_logics() );


                return controller;


        }

}


