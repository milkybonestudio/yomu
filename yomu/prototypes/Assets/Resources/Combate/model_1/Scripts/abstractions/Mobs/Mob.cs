

using UnityEngine;
using UnityEngine.UI;

public class Mob {

    public GameObject game_object;
    public Image image;

    private Mob_data data;
    public Mob( string _name ){

        data = Mob_container.Get_mob_data( _name );
        data.name = _name;

        game_object = new GameObject( _name );
        image = game_object.AddComponent<Image>();
        image.sprite = Resources.Load<Sprite>( Paths_combate_modelo_1.Get_path( $"Mobs/images/{ _name }" ) ) ;

    }


}