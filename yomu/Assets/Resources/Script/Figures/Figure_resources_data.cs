

using System;
using UnityEngine;


// generic?
public struct Figure_resources_data {

        // ** tem os recursos de uma forma em especifico

        public GameObject form_game_object;

        public Figure_image_component[] images;
        public Figure_audio_component[] audios;

        public static Figure_resources_data Create( GameObject _game_object_form, Action<Figure> _instanciate, Figure_image_component[] _images, Figure_audio_component[] _audios ){

                Figure_resources_data data = new Figure_resources_data();

                    data.audios = _audios;
                    data.images = _images;
                    data.form_game_object = _game_object_form;
                    
                return data;

        }

}

