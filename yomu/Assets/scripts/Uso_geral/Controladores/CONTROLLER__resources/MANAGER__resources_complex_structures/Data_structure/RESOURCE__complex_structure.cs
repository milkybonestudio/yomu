using UnityEngine;

public class RESOURCE__complex_structure {



        public MODULE__context_complex_structures module_complex_structures;
        public Resource_context complex_structure_context;
        public string main_folder;
        public Complex_structure_locators locators;

        public string complex_structure_key;

        public string resource_path; // ** contex + main_folder + locator.lcoal_path

        public Resource_use_state complex_structure_state;



        // --- DATA 
        public GameObject prefab; // ** se depois fizer pegando um .dat vai ser feito outro field



        // --- COMPLEX complex_STRUCTURES
        
        public RESOURCE__complex_structure_copy[] sub_structures;



        // --- DATA

        public Resource_complex_structure_content content_going_to;
        public Resource_complex_structure_content actual_content;

        public Resources_getting_complex_structure_stage stage_getting_resource;




        // --- COPIES

            private int n = 0;

            // public RESOURCE__structure_copy[] copies = new RESOURCE__structure_copy[ 10 ];
            public Complex_structure_copy_reference[] copies = new Complex_structure_copy_reference[ 10 ];
            
            public int copies_pointer;
            //public bool need_reajust;
            // public int copies_deleted; 
                        
            public int count_places_being_used_nothing; // precisa de nada
            public int count_places_being_used_complex_structure_data; // precisa do minimo
            public int count_places_being_used_game_object; // precisa de tudo

}




