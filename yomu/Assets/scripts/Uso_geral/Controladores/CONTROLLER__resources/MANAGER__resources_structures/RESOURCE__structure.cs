using UnityEngine;

public class RESOURCE__structure {


        public RESOURCE__structure( MODULE__context_structures _module_structures,  Resource_context _context,  string _main_folder, Structure_locators _locator ){

                module_images = _module_structures;
                context = _context;
                main_folder = _main_folder;
                locators = _locator;

                actual_content = Resource_structure_content.nothing;
                content_going_to = Resource_structure_content.nothing;

                stage_getting_resource = Resources_getting_structure_stage.finished;


                current_state = Resource_state.nothing;
                current_final_state = Resource_state.nothing;


                resource_path = ( context.ToString() + "/" + main_folder + "/" + locators.main_struct_name );

        }

        public MODULE__context_structures module_images;
        public Resource_context context;
        public string main_folder;
        public Structure_locators locators;

        public string resource_path;



        // --- DATA 
        public GameObject prefab; // ** se depois fizer pegando um .dat vai ser feito outro field



        // --- COMPLEX STRUCTURES
        public RESOURCE__structure_copy[] sub_structures;



        // --- IMAGE DATA 

        public Resource_state current_final_state; // ** can not have going_to 
        public Resource_state current_state;
        

        //public Resource_structure_content level_pre_allocation;


                public Resource_structure_content content_going_to;
                public Resource_structure_content actual_content;

                public Resources_getting_structure_stage stage_getting_resource;




        // --- COPIES

            public int number_copies_need_to_get_instanciated;

            public RESOURCE__structure_copy[] copies = new RESOURCE__structure_copy[ 10 ];
            public int copies_pointer;
            //public bool need_reajust;
            public int copies_deleted; 
                        
            public int count_places_being_used_nothing; // precisa de nada
            public int count_places_being_used_structure_data; // precisa do minimo
            public int count_places_being_used_instance; // precisa de tudo

}