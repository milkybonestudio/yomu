
using UnityEngine;

public class Teclado_virtual {

        public Idioma idioma_teclado;

        public Teclado_virtual( Idioma _idioma ){

                idioma_teclado = _idioma;

        }

        
        public GameObject Construir(){
            
            
                string path_prefab = "Teclados/Generico/" + idioma_teclado.ToString();

                GameObject prefab = Prefab_loader.Pegar_prefab( path_prefab );

                GameObject teclado_game_object = GameObject.Instantiate( prefab );
                teclado_game_object.name = ( "keyboard_" + idioma_teclado.ToString() );

                return teclado_game_object;

        }

}