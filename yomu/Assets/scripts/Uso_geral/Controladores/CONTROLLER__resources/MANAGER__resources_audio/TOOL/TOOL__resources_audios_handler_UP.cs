using System;
using UnityEngine;


public static class TOOL__resources_audios_handler_UP {


        public static int Handle_waiting_to_start( MANAGER__resources_audios _manager, RESOURCE__audio _image ){


                TOOL__resource_audio.Verify_audio( _image );

                CONTROLLER__errors.Verify( ( _image.actual_content != Resource_audio_content.nothing ), $"the image { _image.name } came to the Handle_waiting_to_start() but the actual content is { _image.actual_content }" );

                int weight = 0;

                return weight;

        }


}