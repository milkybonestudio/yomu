using System;




unsafe public class CONTROLLER__entities { 


        public static CONTROLLER__entities instance;
        public static CONTROLLER__entities Get_instance(){ return instance; }

        public MODULO__buffer_entidade buffer_stack;

        public IntPtr pointer_data_fundamental_data;
        public Heap heap;
        public Entities_bin bin;
        public Fundamental_entities_data fundamental_data;


        // --- ENTITY 

        public MANAGER__background_entities background_entities;
        public MANAGER__player_current_environment player_current_environment;
        public MANAGER__global_environment global_environment;


        // ** PLAYER CURRENT FIX STATE
        // ** sempre mantem o minimo possivel de dados
        // ** vai ser muito dificil adicionar coisas aqui

        public City player_current_city;

        public Plot[] activated_plots;
        public int pointer_plots;

        public Character[] characters_player_current_city;
        public int characters_player_current_city_pointer;


        

        // ** cidades, estados e reinos nao faz sentido ter eles aqui, eles quase nao vao ser usados para nada

        public Character[] activated_characters;
        public int pointer_characters;

        public City[] activated_cities;
        public int pointer_cities;





        // // --- OPERATIONS


        // // ** GET ENTITY

        // public Character Get_character( int _character_id ){ return TOOL__get_entity_container.Get_character( this, _character_id ); }
        // public Plot Get_plot( int _plot_id ){ return TOOL__get_entity_container.Get_plot( this, _plot_id ); }
        // public City Get_city( int _city_id ){ return TOOL__get_entity_container.Get_city( this, _city_id ); }
        

        // // ** GET ENTITIES

        // public Character[] Get_characters( int[] _character_id ){ return TOOL__get_entities_container.Get_characters( this, _character_id ); }
        // public City[] Get_cities( int[] _city_id ){ return TOOL__get_entities_container.Get_cities( this, _city_id ); }
        // public Plot[] Get_plots( int[] _plot_id ){ return TOOL__get_entities_container.Get_plots( this, _plot_id ); }



        // // ** dificilmente vao ser chamados aqui
        // // ** o personagem teria que ser carregado na multithread fora do fluxo por algum motivo

        // // ** ADD ENTITIES

        // public void Add_characters( Character[] characters_add ){  TOOL__add_entities_container.Add_characters( this, characters_add );}
        // public void Add_cities( City[] cities_add ){  TOOL__add_entities_container.Add_cities( this, cities_add ); }
        // public void Add_plots( Plot[] plots_add ){  TOOL__add_entities_container.Add_plots( this, plots_add ); }


        // // ** REMOVE ENTITIES

        // public void Remove_characters( int[] characters_add ){  TOOL__remove_entities_container.Remove_characters( this, characters_add );}
        // public void Remove_cities( int[] cities_add ){  TOOL__remove_entities_container.Remove_cities( this, cities_add ); }
        // public void Remove_plots( int[] plots_add ){  TOOL__remove_entities_container.Remove_plots( this, plots_add ); }


}
