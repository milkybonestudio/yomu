

public struct Figure_data_getter {

        // ** normal system
        public Resource_context context;
        public string main_folder;

        // ** generic part
        public string path_root; // ** root + name -> final path

    
        public Resource_image_content level_pre_alloc;
        public MANAGER__resources_images resources_images;
        public MANAGER__resources_structures resources_structures;



        private const bool show_who = false;

        public void Put_data( Resource_context _context, string _main_folder, string _root, Figure_use_context _context_figure ){


                if( show_who )
                    { Console.Log( $"put data on { _main_folder }" ); }
                

                // --- PUT DATA
                main_folder = _main_folder;
                context = _context;
                path_root = _root;

                // --- GET PRE ALLOC
                level_pre_alloc = Resource_image_content.compress_low_quality_data;

                if( _context_figure == Figure_use_context.conversation )
                    { level_pre_alloc = Resource_image_content.compress_data; }

                
                CONTROLLER__resources controller = CONTROLLER__resources.Get_instance();

                resources_images = controller.resources_images;
                resources_structures = controller.resources_structures;


        }


        public RESOURCE__structure_copy Get_structure_copy( string _path, Resource_structure_content _level_pre_allocation ){

                return resources_structures.Get_structure_copy( context, main_folder, _path, _level_pre_allocation );
        }


        public RESOURCE__image_ref Get_image_reference( string _name ){ Verify(); return resources_images.Get_image_reference( context, main_folder, ( path_root + "/" + _name  ), level_pre_alloc ); }
        public RESOURCE__image_ref Get_image_reference_not_root( string _name ){ Verify(); return resources_images.Get_image_reference( context, main_folder,  _name , level_pre_alloc ); }

        public RESOURCE__image_ref[] Get_images_reference( string _name, int _number_images ){ Verify(); return resources_images.Get_images_reference( context, main_folder, ( path_root + "/" + _name ), level_pre_alloc, _number_images );}
        public RESOURCE__image_ref[] Get_images_reference_not_root( string _name, int _number_images ){ Verify(); return resources_images.Get_images_reference( context, main_folder,  _name, level_pre_alloc, _number_images ); }


        private void Verify(){ if( ( main_folder == null ) || ( path_root == null) ){ CONTROLLER__errors.Throw( "forgot to put <Color=lightBlue>static constructor</Color> in some figure" ); }}


}