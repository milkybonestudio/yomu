


using UnityEngine;
using UnityEngine.UI;

public class Menu {

    
    public Menu(){

        Controllers.menu = this;

        container = GameObject.Find( "Canvas/Menu" );
        new_game = GameObject.Find( "Canvas/Menu/New_game" ).GetComponent<Button>();
        new_game.onClick.AddListener(()=>{

            Controller.instance.Start_fase(new(){
                map_name = "map_1",
                world_model = "florest",
            });     

        });

    }

    public GameObject container;
    public Button new_game; 

    public void Update(){

    }
    public void Start(){

        Controllers.main.Change_stage( Stage.menu );

    }

}