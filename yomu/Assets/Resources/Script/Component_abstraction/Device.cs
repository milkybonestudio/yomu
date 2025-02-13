using UnityEngine;




public abstract class Device : Body {

        private enum Device_resource_state {

            nothing,
            data_converted,
            linked,
            instanciated,

        }



        public List<UI_component> list_UIs = new List<UI_component>( 50 );
        public RESOURCE__structure_copy structure;

        private Device_resource_state state;


        public virtual void Update( Control_flow _flow ){


                base.Update( _flow );

                UI_component[] UIs = list_UIs.values;

                for( int UI_slot = 0 ; UI_slot < list_UIs.used_length ; UI_slot++ )
                    { 
                        UIs[ UI_slot ].Update( _flow ); 
                        //Console.Log( "deu update no " + UIs[ UI_slot ].name );
                    }

        }


        public virtual void Instanciate( GameObject _place_to_instanciate ){


                if( state == Device_resource_state.instanciated )
                    { return; }


                structure.Instanciate( _place_to_instanciate );
                Create_body( structure.structure_game_object );

                if( state < Device_resource_state.linked )
                    { Link_to_game_object_UIs(); }

                
                UI_component[] UIs = list_UIs.values;

                for( int UI_slot = 0 ; UI_slot < list_UIs.used_length ; UI_slot++ )
                    { UIs[ UI_slot ].Instanciate_UI(); }

                state = Device_resource_state.instanciated;

        }


        public void Load_UIs(){

                UI_component[] UIs = list_UIs.values;

                for( int UI_slot = 0 ; UI_slot < list_UIs.used_length ; UI_slot++ )
                    { UIs[ UI_slot ].Load(); }

        }

        public void Convert_creation_data_TO_resources_UIs(){


                if( state > Device_resource_state.data_converted )
                    { return; }

                UI_component[] UIs = list_UIs.values;

                for( int UI_slot = 0 ; UI_slot < list_UIs.used_length ; UI_slot++ )
                    { UIs[ UI_slot ].Convert_creation_data_TO_resources(); }

                state = Device_resource_state.data_converted;


        }


        public void Link_to_game_object_UIs(){

                if( state > Device_resource_state.linked )
                    { return; }

                if( state == Device_resource_state.nothing )
                    { Convert_creation_data_TO_resources_UIs(); }


                UI_component[] UIs = list_UIs.values;

                for( int UI_slot = 0 ; UI_slot < list_UIs.used_length ; UI_slot++ ){ 

                        UI_component UI = UIs[ UI_slot ];

                        if( UI.path_to_UI == null )
                            { CONTROLLER__errors.Throw( $"Did not put <Color=lightBlue>path_to_UI</Color> in the UI <Color=lightBlue>{ UI.name }</Color>" ); }
                        GameObject UI_game_object_in_structure = structure.Get_component_game_object( UI.path_to_UI );

                        if( UI_game_object_in_structure == null )
                            { CONTROLLER__errors.Throw( $"The UI <Color=lightBlue>{ UI.name }</Color> dont have the game object in the path <Color=lightBlue>{ UI.path_to_UI }</Color>" ); }


                        UI.Create_body( UI_game_object_in_structure );
                        UI.Link_to_UI_game_object_in_structure();

                        // UI.Create_body_containers( UI_game_object_in_structure.transform.parent.gameObject );
                        // UI.Link_structure( UI_game_object_in_structure );
                        // UI.Link_to_UI_game_object_in_structure(); 
                }

                state = Device_resource_state.linked;


        }


    

}
