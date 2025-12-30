using System;
using UnityEngine;


// *** CONTENT ***

unsafe public abstract partial class UI_component{


        public UI_component_content current_content = UI_component_content.nothing;
        public UI_component_content content_going_to = UI_component_content.nothing;

        public UI_component_content level_pre_allocation;

        public UI_component_content current_content_level;

        public Content_level content_level_resources;


        public bool Got_content_level( Content_level _level ){

            switch( _level ){

                case Content_level.full: return ( current_content == UI_component_content.finished );
                case Content_level.minimum: return ( current_content == level_pre_allocation );
                default: CONTROLLER__errors.Throw( "nao faz sentido usar assim, veio level: " + _level ); return false;

            }

        }


        public GameObject UI_game_object_in_structure;


        public delegate bool Get_minimum_resources();



        private const int WEIGHT_DATA_CREATION = 1;
        private const int WEIGHT_ASK_MINIMUM_RESOURCES = 1;
        private const int WEIGHT_GETTING_MINIMUM_RESOURCES = 1;
        private const int WEIGHT_GAME_OBJECT = 1;
        private const int WEIGHT_LINK = 50;
        private const int WEIGHT_PREPARE_BODY = 150;
        
    
        private int Update_content(){

                int weight = 0;
                
                if( Control_flow.weight_frame_available <= 0 )
                    { return weight; }

                // Console.Log( $"UI {name } esta com o current { current_content } and is going to { content_going_to }" );

                if( current_content == content_going_to )
                    { return weight; }


                switch( current_content ){

                    case UI_component_content.nothing: Check_nothing(); break;
                        // ** CONTENT
                            case UI_component_content.data_creation: Check_data_creation(); break;
                                case UI_component_content.ask_minimum_resources: Check_ask_minimum_resources(); break;
                                    case UI_component_content.getting_minimum_resources: Check_Getting_minimum_resources(); break;
                                        // ** NEED STRUCTURE
                                            case UI_component_content.game_object: Check_game_object(); break;
                                                case UI_component_content.link: Check_link(); break;
                                                    case UI_component_content.prepare_body: Check_prepare_body(); break;
                                                        case UI_component_content.finished: break;

                }

                return weight;

        }


        private void Check_nothing(){
        
            if( current_content == content_going_to )
                { return; }

            current_content = UI_component_content.data_creation;

        }


        private void Check_data_creation(){

            if( current_content == content_going_to )
                { return; }

            if( current_content < content_going_to )
                {
                    Create_data_FROM_creation_data_UI();
                    current_content = UI_component_content.ask_minimum_resources;
                    return;
                }
                else
                {
                    CONTROLLER__errors.Throw( "tem que ver" );
                }

        }


        private void Check_ask_minimum_resources(){

            if( current_content == content_going_to )
                { return; }

        
            if( current_content < content_going_to )
                {
                    Ask_minimum_resources_UI();
                    current_content = UI_component_content.getting_minimum_resources;
                    return;
                }
                else
                {
                    CONTROLLER__errors.Throw( "tem que ver" );
                }

        }


        private void Check_Getting_minimum_resources(){

            if( current_content == content_going_to )
                { return; }

        
            if( current_content < content_going_to )
                {
                    Getting_minimum_resources_UI();
                    current_content = UI_component_content.game_object;
                    return;
                }
                else
                {
                    CONTROLLER__errors.Throw( "tem que ver" );
                }

        }




        private void Check_game_object(){

            // ** UI NAO TEM CAPACIDADE DE MUDAR CONTENT NA STRUCTURE

            if( current_content == content_going_to )
                { return; }
            
            if( current_content < content_going_to )
                {
                    if( structure.Got_to_full() )
                        { current_content = UI_component_content.link; }
                    return;
                }
                else
                {
                    current_content = UI_component_content.nothing;
                }

        }



        private void Check_link(){

            if( current_content == content_going_to )
                { return; }

            if( current_content < content_going_to )
                {
                    Link_to_UI_game_object_in_structure_UI();
                    current_content = UI_component_content.prepare_body;
                    return;
                }
                else
                {
                    CONTROLLER__errors.Throw( "tem que ver" );
                }

        }

        private void Check_prepare_body(){

            if( current_content == content_going_to )
                { return; }

            if( current_content < content_going_to )
                {
                    Prepare_body_UI();
                    current_content = UI_component_content.finished;
                    return;
                }
                else
                {
                    CONTROLLER__errors.Throw( "tem que ver" );
                }

        }




        public void Go_to_content_level( Content_level _level ){

                switch( _level ){

                    case Content_level.minimum: content_going_to = level_pre_allocation; break;
                    case Content_level.full: content_going_to = UI_component_content.finished; break;
                }

        }



        // ** --- CREATE DATA    
        
        public UI_component_type_method_activation create_data_FROM_creation_data_method_type = UI_component_type_method_activation.all;
        public Action Create_data_FROM_creation_data_unique = ()=>{};
        protected abstract void Create_data_FROM_creation_data();

        public void Create_data_FROM_creation_data_UI(){

            // ** sentido mudou, UI_component_content.data_creation é o STAGE para pegar os dados
            if( current_content != UI_component_content.data_creation )
                { CONTROLLER__errors.Throw( $"Tried to call <Color=lightBlue>Create_data_FROM_creation_data_UI()</Color> in the UI <Color=lightBlue>{ name }</Color> but the state is <Color=lightBlue>{ current_content }</Color>. Need to be <Color=lightBlue>data_creation</Color>" ); }

                if( ( create_data_FROM_creation_data_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                    { Create_data_FROM_creation_data_unique(); }

                if( ( create_data_FROM_creation_data_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                    { Create_data_FROM_creation_data(); }

                if( ( create_data_FROM_creation_data_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                    {}

            return;

        }




        // ** --- LINK

        public UI_component_type_method_activation link_to_UI_game_object_in_structure_method_type = UI_component_type_method_activation.all;
        public Action<GameObject> Link_to_UI_game_object_in_structure_unique = ( GameObject _UI_game_object )=>{};
        protected abstract void Link_to_UI_game_object_in_structure( GameObject _UI_game_object );
        private void Link_to_UI_game_object_in_structure_UI( GameObject ____UI_game_object = null ){


            UI_game_object_in_structure = structure.Get_component_game_object( _path_to_UI_in_structure );
            
            if( UI_game_object_in_structure == null )
                { CONTROLLER__errors.Throw( "nao achou game_object na structurestructure" ); }

            if( current_content != UI_component_content.link )
                { CONTROLLER__errors.Throw( $"Tried to call <Color=lightBlue>Link_to_UI_game_object_in_structure_UI()</Color> in the UI <Color=lightBlue>{ name }</Color> but the state is <Color=lightBlue>{ current_content }</Color>. Need to be <Color=lightBlue>data_creation</Color>" ); }


                if( ( link_to_UI_game_object_in_structure_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                    { Link_to_UI_game_object_in_structure_unique( UI_game_object_in_structure ); }

                if( ( link_to_UI_game_object_in_structure_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                    { Link_to_UI_game_object_in_structure( UI_game_object_in_structure ); }

                if( ( link_to_UI_game_object_in_structure_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                    {}

            current_content = UI_component_content.link;
            return;

        }


        // ** --- PREPARE BODY

        public UI_component_type_method_activation Prepare_body_method_type = UI_component_type_method_activation.all;
        public Action Prepare_body_unique = ()=>{};
        protected virtual void Prepare_body(){}
        public void Prepare_body_UI(){

            
            if( current_content != UI_component_content.prepare_body )
                { CONTROLLER__errors.Throw( $"Tried to call <Color=lightBlue>Link_to_UI_game_object_in_structure_UI()</Color> in the UI <Color=lightBlue>{ name }</Color> but the state is <Color=lightBlue>{ current_content }</Color>. Need to be <Color=lightBlue>data_creation</Color>" ); }


                if( ( Prepare_body_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                    { Prepare_body_unique(); }

                if( ( Prepare_body_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                    { Prepare_body(); }

                if( ( Prepare_body_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                    { body.Create( UI_game_object_in_structure ); }

            current_content = UI_component_content.link;
            return;

        }


        

        // ** ASK MINIMUm RESOURCES

        public UI_component_type_method_activation Ask_minimum_resources_method_type = UI_component_type_method_activation.all;
        public Action Ask_minimum_resources_unique = ()=>{};
        protected virtual void Ask_minimum_resources(){ resources_container.Go_to_content_level_all_resources( Content_level.minimum ); }
        public void Ask_minimum_resources_UI(){

            
            if( current_content != UI_component_content.ask_minimum_resources )
                { CONTROLLER__errors.Throw( $"Tried to call <Color=lightBlue>Link_to_UI_game_object_in_structure_UI()</Color> in the UI <Color=lightBlue>{ name }</Color> but the state is <Color=lightBlue>{ current_content }</Color>. Need to be <Color=lightBlue>data_creation</Color>" ); }


                if( ( Ask_minimum_resources_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                    { Ask_minimum_resources_unique(); }

                if( ( Ask_minimum_resources_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                    { Ask_minimum_resources(); }

                if( ( Ask_minimum_resources_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                    {}

            current_content = UI_component_content.getting_minimum_resources;
            return;

        }


        



        // ** GETTING MINIMUm RESOURCES

        public UI_component_type_method_activation Getting_minimum_resources_method_type = UI_component_type_method_activation.all;
        public Get_minimum_resources Getting_minimum_resources_unique = ()=>{ return true; };
        protected virtual bool Getting_minimum_resources(){ return resources_container.Got_to_content_level_all_resources( Content_level.minimum ); }
        public void Getting_minimum_resources_UI(){

            
            if( current_content != UI_component_content.getting_minimum_resources )
                { CONTROLLER__errors.Throw( $"Tried to call <Color=lightBlue>Link_to_UI_game_object_in_structure_UI()</Color> in the UI <Color=lightBlue>{ name }</Color> but the state is <Color=lightBlue>{ current_content }</Color>. Need to be <Color=lightBlue>data_creation</Color>" ); }


            bool finished = true;

                if( ( link_to_UI_game_object_in_structure_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                    { finished &= Getting_minimum_resources_unique(); }

                if( ( link_to_UI_game_object_in_structure_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                    { finished &= Getting_minimum_resources(); }

                if( ( link_to_UI_game_object_in_structure_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                    {}

            if( finished )
                { current_content = UI_component_content.finished; }

            
            return;

        }


        public void Instanciate_content(){


            // Console.Log( $"veio Instanciate_content UI { name }, current_content { current_content }" );


            if( current_content == UI_component_content.finished )
                { return; }

            if( current_content == UI_component_content.nothing )
                { 
                    current_content = UI_component_content.data_creation;
                }

            if( current_content == UI_component_content.data_creation )
                {
                    Create_data_FROM_creation_data_UI();
                    current_content = UI_component_content.ask_minimum_resources;
                }

            if( current_content == UI_component_content.ask_minimum_resources )
                {
                    Ask_minimum_resources_UI();
                    current_content = UI_component_content.getting_minimum_resources;
                }

            if( current_content == UI_component_content.getting_minimum_resources )
                {
                    Getting_minimum_resources_UI(); // ** se precisa sinalizar algo
                    resources_container.Force_all_fulls_to_instanciate();
                    current_content = UI_component_content.game_object;
                }

            if( current_content == UI_component_content.game_object )
                { 
                    structure.Instanciate(); 
                    current_content = UI_component_content.link;
                }

            if( current_content == UI_component_content.link )
                {
                    Link_to_UI_game_object_in_structure_UI();
                    current_content = UI_component_content.prepare_body;
                }

            if( current_content == UI_component_content.prepare_body )
                {
                    Prepare_body_UI();
                    current_content = UI_component_content.finished;
                }

            // Console.Log( $"veio Instanciate_content UI { name }, current_content { current_content }" );

        }



}
