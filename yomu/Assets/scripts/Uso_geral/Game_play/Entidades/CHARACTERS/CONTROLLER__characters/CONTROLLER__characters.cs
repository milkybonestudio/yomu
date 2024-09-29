using System;
using UnityEngine;


unsafe public class CONTROLLER__characters : INTERFACE__controlador_entidade {


		public static CONTROLLER__characters instance;
		public static CONTROLLER__characters Get_instance(){ return instance;}

        
        // --- INTERFACE

        

        public void Update(){ TOOL__generic_update_character.Update( this ); }
        public void Update_pass_time_frame(){ TOOL__update_time_frame_character.Update( this ); }
		public void Load_entity( Locator_entity[] _entidades ){ TOOL__loader_character.Load_entity_intern( this, _entidades ); } 
        public void Unload_entity( Locator_entity[] _entidades ){ TOOL__unloader_character.Unload_entity_intern( this,  _entidades ); }
        public float Prepare_to_save_files(){ return TOOL__prepare_to_save_character.Pass_unload_files_to_bin( this ); }


        // deal_talk ( character, character )

        // buying( character, seller )


        // character.Talk()


        public MODULE__controller_entities_data_manager data_manager;

        // --- INTERNAL

        public INTERFACE__character[] characters_logic = new INTERFACE__character[ 200 ];


		public MODULO__leitor_de_arquivos leitor_de_arquivos; // ** setado no folder dos personagens 

		
		public Character[] characters; // all the characters

        public Character* characters_p;


		public int[] characters_activated = new int[ 500 ]; // ** SORT
        public int characters_activated_pointer = 0;

		
		public Character Get_character ( int _personagem_id ){ return new Character(); }


}


public enum Stages_change_time_frame {

        start_load_resources,

}



/*


    personagens[ 5, 7 ]



    2 arquivos / personagem
        heap e dados_normais => 0,5ms + 2ms => 2,5ms => 3,75ms


    ** nunca tem logica no estagio data_flow
    ** mas pode ter visual
    carregar: 1
    descarregar: 5

    

    => iniciar carregar personagem 1
    => inicial transicao back 
    => esperar carregar_1
    => iniciar descarregar persoangem 5
    => iniciar transicao troca periodo
    => esperar descarregar 5

    => devolver controle fluxo
     

    





*/



