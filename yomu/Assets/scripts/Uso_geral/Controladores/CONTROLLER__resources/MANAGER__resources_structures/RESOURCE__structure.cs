using UnityEngine;

public class RESOURCE__structure {


        public RESOURCE__structure( MODULE__context_structures _module_structures,  Resource_context _context,  string _main_folder, Structure_locators _locator ){

                module_images = _module_structures;
                context = _context;
                main_folder = _main_folder;

        }

        public MODULE__context_structures module_images;
        public Resource_context context;
        public string main_folder;




        // --- DATA 
        public GameObject prefab; // ** se depois fizer pegando um .dat vai ser feito outro field





        // --- COMPLEX STRUCTURES
        public RESOURCE__structure_copy[] sub_structures;



        public Resource_structure_content level_preallocation;
        public Resource_structure_content actual_content;


        public Resources_getting_structure_stage stage_getting_resource;


        // --- COPIES

            public bool copies_need_to_get_instanciated;

            public RESOURCE__structure_copy[] copies = new RESOURCE__structure_copy[ 10 ];
            public int copies_pointer;
            public bool need_reajust;
                        
            public int count_places_being_used_nothing; // precisa de nada
            public int count_places_being_used_structure_data; // precisa do minimo
            public int count_places_being_used_instance; // precisa de tudo

}