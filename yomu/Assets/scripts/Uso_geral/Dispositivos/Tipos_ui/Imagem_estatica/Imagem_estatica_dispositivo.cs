using UnityEngine;
using UnityEngine.UI;

public class Imagem_estatica_dispositivo {


    public GameObject game_object;
    public Image image;
    

    public void Construir( Dados_imagem_estatica_dispositivo _dados, string _path_dispositivo ){

        string path_imagem = _path_dispositivo + "/" + _dados.nome;

        game_object = GameObject.Find( path_imagem );

        if( game_object == null )
            { throw new System.Exception( $"Nao foi achado a imagem estatica no path { path_imagem }" ); }

        image = game_object.GetComponent<Image>();


        if( image == null )
            { throw new System.Exception( $"A imagem estatica { _dados.nome } nao tinha o componente Image" ); }

        // --- COLCOAR IMAGEM
        
        image.sprite = _dados.imagem_sprite;
        image.color = _dados.cor;
        image.material = _dados.material_dispositivo;

        return;


    }


}
