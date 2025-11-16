

public class Single_image{

    
        public static Single_image Construct( string _name, RESOURCE__image_ref _image ){
            
            Single_image single_image = new();

                _image.Load();

                single_image.name = _name;
                single_image.structure = Controllers.resources.structures.Get_structure_copy( Resource_context.System, "Defaults", "Structures/unit_sprite_render", Resource_structure_content.game_object );
                single_image.image = _image;
                single_image.original_minimum = _image.level_pre_allocation;

            return single_image;

        }

        public Body body;
        public string name;

        public bool activate;
        public bool deleted;

        private Resource_image_content original_minimum;

        public void Update( Control_flow _flow ){

            if( deleted )
                { CONTROLLER__errors.Throw( $"Tried to update the single image <Color=lightBlue>{ name }</Color> but it was deletad" ); }

            // Console.Log( image.image.actual_content );

            if( !!!( activate ) )
                { return; }

            _flow.weight_frame_available -= body.Update();
            
        }


        public void Activate( Body_set_parent_data _data ){

                if( activate )
                    { Deactivate(); }

                if( body.state != Body_state.constructed )
                    { body.Create( structure.Get_game_object() ); }

                activate = true;

                body.Set_parent( _data );
                structure.Get_component_sprite_render( "sprite_render" ).sprite = image.Get_sprite(); // ** funciona??
                image.Change_level_pre_allocation( Resource_image_content.sprite ); // ** nao importa se esta full ou minimo

        }

        public void Deactivate(){

                if( !!!( activate ) )
                    { return; }

                activate = false;

                structure.Get_component_sprite_render( "sprite_render" ).sprite = null; // ** funciona??
                image.Change_level_pre_allocation( original_minimum );
                image.Deactivate();

        }




        public void Prepare(){ image.Go_to_content_level( Content_level.full ); }
        public void Free(){ image.Go_to_content_level( Content_level.minimum ); }
        public void Delete(){ image.Delete(); deleted = true; }


        private RESOURCE__image_ref image;
        private RESOURCE__structure_copy structure; // ** generico game_object{ sprite_render }

}