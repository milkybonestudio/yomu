using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;




public abstract class UI_button : UI_component {


        //public MANAGER__UI_button_resources manager_resources;

        //public DATA__UI_button data;


        // --- DADOS UNIVERSAIS


        public string main_folder;
        public Resource_context context;
        public Material material;


        public Action Activate;
        public UI_button_activation_type activation_type;
        public bool bloquear_update_logico;


        public GameObject IMAGE_container;
        public GameObject TRANSITION_container;

        public abstract void Change_text( string _text );



        // ** COLLIDERS

            public GameObject COLLIDERS_container;

                public GameObject OFF_collider_game_object;
                public PolygonCollider2D OFF_collider;

                public GameObject ON_collider_game_object;
                public PolygonCollider2D ON_collider;
            

        // --- INTERNO

        public Resource_state resource_state;


        // --- LOGICA

        public bool is_active;
        public Resource_use_state state;



        public UI_button_type type;


        public bool esta_down;
        public bool esta_houver;


        // nome ta meio merda
        public float animacao_atual_tempo_ms;
        public float animacao_sprite_atual_tempo_ms;
        public int sprite_atual_index;

    

        // --- PUBLIC 


        public virtual void Update( Control_flow _flow ){

                base.Update( _flow );
                
                if( !!!( is_active ) )
                    { return; }

                Update_parte_logica();
                Update_parte_visual();

                return;

        }



        //mark
        // ** faz parte do UI_component

        // public abstract void Convert_creation_data_TO_resources();
        // public abstract void Link_to_game_object( GameObject _button_game_object );
        // public abstract void Load();


        // ?

        public abstract void Deactivate_button();


        public virtual void Update_parte_logica(){ TOOL__UI_button_UPDATE.Update_logica( this ); }
        public abstract void Update_parte_visual();


        
}





