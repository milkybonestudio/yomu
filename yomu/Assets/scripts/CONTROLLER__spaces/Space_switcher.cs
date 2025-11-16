using UnityEngine;

// ** conteiner que vai ser entregue para o controlador_UI 
public class Space_switcher {


    public static Space_switcher Construct( Canvas_space _current, Canvas_space _new, Canvas_space _transition  ){

        Space_switcher switcher = new Space_switcher();

            switcher.canvas_space_current = _current;
            switcher.canvas_space_new = _new;
            switcher.canvas_space_transition = _transition;

        return switcher;


    }

        public Canvas_space canvas_space_current;
        public Canvas_space canvas_space_new;
        public Canvas_space canvas_space_transition;



        public void Annex_structure( RESOURCE__structure_copy _structure ){

            // _structure.Instanciate();
            // _structure.Set_parent( transition_world_container );
            // _structure.Set( true );

        }

}