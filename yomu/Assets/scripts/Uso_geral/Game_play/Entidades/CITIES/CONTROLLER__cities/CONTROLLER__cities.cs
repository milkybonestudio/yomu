using System;
using UnityEngine;



unsafe public class CONTROLLER__cities : INTERFACE__controlador_entidade {


		public static CONTROLLER__cities instance;
		public static CONTROLLER__cities Get_instance(){ return instance;}

        
        // --- INTERFACE

        public void Update(){ TOOL__generic_update_cities.Update( this ); }
        public void Update_pass_time_frame(){ TOOL__update_time_frame_cities.Update( this ); }
		public void Load_entity( Locator_entity[] _entidades ){ TOOL__loader_cities.Load_entity_intern( this, _entidades ); } 
        public void Unload_entity( Locator_entity[] _entidades ){ TOOL__unloader_cities.Unload_entity_intern( this,  _entidades ); }
        public float Prepare_to_save_files(){ return TOOL__prepare_to_save_cities.Prepare_to_save_files_intern( this ); }


        // --- PUBLIC

        public MODULO__buffer_entidade modulo_buffer_stack;
        
        // --- LIXEIRA
        public Bin bin; // ** tem os dados para excluir no frame, mas nao necessariamente os dados completos
        public Slot_entities_to_unload slot_entidades_para_excluir; // vai guardar os ids


        // --- INTERNAL

        public INTERFACE__city[] characters_logic = new INTERFACE__city[ 200 ];
		public Character[] characters; // all the characters

		public MODULO__leitor_de_arquivos leitor_de_arquivos; // ** setado no folder dos personagens 
		
		public int[] cities_activated = new int[ 500 ]; // ** SORT
        public int cities_activated_pointer = 0;
		
		public Character Get_city ( Locator_entity _city_id ){ return new Character(); }


}




