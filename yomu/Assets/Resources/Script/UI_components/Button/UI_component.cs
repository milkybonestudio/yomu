

using UnityEngine;

public enum UI_state {

        nothing,
        data_converted,
        instanciated,

}


public enum UI_visibility {

    visible, 
    invisible, // => set material to Hide -> can change position only when turn visible

}

public abstract class UI_component : Body {

        
        public UI_state state;
        public string path_to_UI;

        public virtual void Update( Control_flow _flow ){ base.Update( _flow ); }
        public abstract void Load();

            public abstract void Convert_creation_data_TO_resources();
            // ** vai ser chamado no device.Link_to_UI_game_object_in_structure()
            // ** antes de chamar no loop ele vai criar o body_container e em seguida linkar o game_object da UI com a structure_container
            public abstract void Link_to_UI_game_object_in_structure();
            public abstract void Start_UI();
        
        public void Instanciate_UI(){

                Convert_creation_data_TO_resources();
                Link_to_UI_game_object_in_structure();
                Start_UI();

        }



            // --- GENERAL

            public void Hide(){ body_container.SetActive( false ); }
            public void Show(){ body_container.SetActive( true ); }



            

}





