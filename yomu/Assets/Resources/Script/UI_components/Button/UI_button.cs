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

        public string name;


        public Action Activate;
        public UI_button_activation_type activation_type;
        public bool bloquear_update_logico;


        public GameObject IMAGE_container;
        public GameObject TRANSITION_container;



        // ** COLLIDERS

            public GameObject COLLIDERS_container;

                public GameObject OFF_collider_game_object;
                public PolygonCollider2D OFF_collider;

                public GameObject ON_collider_game_object;
                public PolygonCollider2D ON_collider;
            

        // --- INTERNO

        public Resource_state resource_state;

        public string button_name;


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

    

        // ?? 
        // ---- VISUAL

        // public DEVICE_button_visual_state current_visual_state;
        // public DEVICE_button_visual_state visual_state_going_to;



        // public DEVICE_button_visual_state estado_visual_botao;
        // public DEVICE_button_visual_state ultimo_estado_visual_botao;



        // --- PUBLIC 


        public virtual void Update(){


                if( !!!( is_active ) )
                    { return; }

                Update_parte_logica();
                Update_parte_visual();

                return;

        }


        public abstract void Define_button();
        public abstract void Link_to_game_object( GameObject _button_game_object );
        public abstract void Load();
        public abstract void Activate_button();
        public abstract void Deactivate_button();


        public virtual void Update_parte_logica(){ TOOL__UI_button_UPDATE.Update_logica( this ); }
        public abstract void Update_parte_visual();


        
}





