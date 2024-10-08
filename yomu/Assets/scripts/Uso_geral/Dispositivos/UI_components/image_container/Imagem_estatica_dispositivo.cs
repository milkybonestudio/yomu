using UnityEngine;
using UnityEngine.UI;

public class Imagem_estatica_dispositivo {


        public Imagem_estatica_dispositivo( Dados_imagem_estatica_dispositivo _dados ){

                data = _dados;

        }


        // --- DATA

        public Dados_imagem_estatica_dispositivo data; 
        public GameObject game_object;
        public Image image;
        

        // ??
        public void Get_data_from_prefab( Dados_imagem_estatica_dispositivo _dados, string _path_dispositivo ){


                string path_imagem = ( _path_dispositivo + "/" + _dados.nome );

                game_object = GAME_OBJECT.Find( _path: path_imagem, _message_on_not_find: $"Nao foi achado a imagem estatica no path { path_imagem }", _throw_exception: true );
                image = IMAGE.Get_component( _game_object: game_object, _message_on_not_find: $"A imagem estatica { _dados.nome } nao tinha o componente Image", _throw_exception: true );

                
                // --- COLCOAR IMAGEM
                image.sprite = _dados.imagem_sprite;
                image.color = _dados.cor;
                image.material = _dados.material_dispositivo;

                return;


        }


}
