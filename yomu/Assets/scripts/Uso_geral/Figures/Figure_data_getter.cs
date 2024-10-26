

public struct Figure_data_getter {

        public Resource_context context;
        public string main_folder;
        public string path_root;
        public Resource_image_content level_pre_alloc;
        public MANAGER__resources_images resources_images;


        public void Get_level_pre_alloc(  Figure_use_context _context_figure ){

                level_pre_alloc = Resource_image_content.nothing;

                if( _context_figure == Figure_use_context.conversation )
                    { level_pre_alloc = Resource_image_content.compress_data; }
                    
        }


        public void Put_data( Resource_context _context, string _main_folder, Figure_use_context _context_figure ){

            
                main_folder = _main_folder;
                context = _context;
                
                path_root = ( context.ToString() + "/" + main_folder + "/" );
                Get_level_pre_alloc( _context_figure );

                resources_images = CONTROLLER__resources.Get_instance().resources_images;

        }

        public RESOURCE__image_ref Get_image_reference( string _name ){

                return resources_images.Get_image_reference( context, main_folder, ( path_root + _name ), level_pre_alloc );

        }


}