using UnityEngine;
using UnityEngine.UI;

public struct Figure_image_component {

    
    public GameObject game_object;
    public Image image;
    public RESOURCE__image_ref image_ref;


    public void Put_image(){

        image.sprite = image_ref.Get_sprite();

    }

}
