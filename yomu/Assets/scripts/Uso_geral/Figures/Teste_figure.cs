using UnityEngine;
using UnityEngine.UI;



public static class FIGURE {

    public static Figure_image_component Get_image( GameObject _mode, string _name_component, RESOURCE__image_ref _image ){

            Figure_image_component image_component = new Figure_image_component();

                    image_component.game_object = _mode.transform.Find( _name_component );
                    CONTROLLER__errors.Verify( ( image_component.game_object == null ) , $"Tried to get the component { _name_component } in the game object { _mode.name } but was not find" );
                    image_component.image = image_component.game_object.GameComponent<Image>();
                    image_component.image_ref = _image;

            return image_component;
        
    }

}


public class Teste_figure : INTERFACE__figure {

        // ** somente a parte visual

        public static Figure Construct(){ return CONSTRUCTOR__figure.Construct( new Teste_figure() ); }

        // ** todo path inicia no começo do contexto/main_folder
        // ** isso faz com que coisas que são muito reutilizavais possam ficar em pastas especificas


        // ** lista imagens 

        public RESOURCE__image_ref body_1;
        public RESOURCE__image_ref body_2;

    

        public void Load_images( Context_figure _context_figure ){


                MANAGER__resources_images resources_images = CONTROLLER__resources.Get_instance().resources_images;

                Resource_context context = Get_context();
                string main_folder = Get_main_folder();

                string path_root = ( context.ToString() + "/" + main_folder + "/" );
            
                Resource_image_content level_pre_alloc = Resource_image_content.nothing;

                if( _context_figure == Context_figure.conversation )
                    { level_pre_alloc = Resource_image_content.compress_data; }
                
                
                body_1 = resources_images.Get_image_reference( context, main_folder, ( path_root + "Clothes/body_1" ) , level_pre_alloc );
                body_2 = resources_images.Get_image_reference( context, main_folder, ( path_root + "Clothes/body_2" ) , level_pre_alloc );
                

        }

        public string figure_path;
        public GameObject current_prefab;
        public GameObject figure_container;

        // ** MAD
        public GameObject mad_prefab;
        public GameObject mad_container;

            // ** os dados vao ser colocados quando o prefab for isntanciado
            public Figure_image_component mad_body;
            public Figure_image_component mad_head;
            public Figure_image_component mad_top;
            public Figure_image_component mad_arms;
            public Figure_image_component mad_exp; // ** complemento
            public Figure_image_component mad_eyes;
            public Figure_image_component mad_mouth;

            public void Intanciate_mad(){

                    if( mad_prefab == null )
                        { /*LOAD*/ }        

                    if( mad_container == null )
                        {

                            mad_container  = GameObject.Instantiate( mad_prefab );
                            mad_container.name = mad_prefab.name;
                            mad_container.transform.SetParent( figure_container.transform, false );

                            // *** INSTANCIATE
                            mad_body = FIGURE.Get_image( mad_container, "mad_body", body_1 );
                            mad_head = FIGURE.Get_image(  mad_container, "mad_body", body_1 );
                            mad_top = FIGURE.Get_image(  mad_container, "mad_body", body_1 );
                            mad_arms = FIGURE.Get_image(  mad_container, "mad_body", body_1 );

                            mad_exp = FIGURE.Get_image(  mad_container, "mad_body", body_1 ); // ** complemento
                            mad_eyes = FIGURE.Get_image(  mad_container, "mad_body", body_1 );
                            mad_mouth = FIGURE.Get_image(  mad_container, "mad_body", body_1 );

                        }

            
                    current_prefab.SetActive( false );
                    mad_container.SetActive( true );
                    current_prefab = mad_container;
                    return;

            }
            

        // ** sad 
        public GameObject sad_prefab;
        public GameObject sad_container;




        public Resource_context Get_context(){ return Resource_context.Characters; }
        public string Get_main_folder(){ return "Lily"; }
        public string Get_figure_name(){ return "Clothes"; }


        public void Update( Figure _figure  ){  }


        public void Blink( Figure _figure ){  }
        public void Speak( Figure _figure ){  }


        


        public void Change_emotion( Figure _figure, ulong _emotion ){

            switch( _emotion ){

                case BIT_KEY__emotion.sadness: 

            }

        }
        public void Active_action( Figure _figure, string _action ){  }
        public void Set_special( Figure _figure, string _special ){  }


}