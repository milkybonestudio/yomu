using UnityEngine;

// ** conteiner que vai ser entregue para o controlador_UI 
public class Cameras_switching_data {


    // --- GIVE TO THE CONTROLLER UI
    public GameObject unique_UI_container_main;
    public GameObject unique_UI_container_transition;
    public GameObject UI_above;


    // --- CONTAINERS
    public GameObject main_world_container;
    public GameObject transition_world_container;


    // --- GIVE TO THE CONTROLLER TRANSITION 
    public Material material_mode_main;
    public Material material_mode_transition;

    public void Annex_structure( RESOURCE__structure_copy _structure ){

        Console.Log( "AAAAAAAAAAA" );

        _structure.Instanciate();
        _structure.Set_parent( transition_world_container );
        _structure.Set( true );

    }

}