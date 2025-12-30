using System.Runtime.CompilerServices;
using UnityEngine;



public unsafe abstract partial class Device {


        public Device_contents_states content_states;    
        public Device_content current_content = Device_content.nothing;
        public Device_content level_pre_allocation = Device_content.UIs;
                
        public Device_content content_going_to = Device_content.finished;
        


        // --- INTERFACE


        private int Update_content(){

            int weight = 0;

            switch( current_content ){

                case Device_content.nothing: Check_nothing(); break;
                    case Device_content.structure: Check_structure(); break;
                        case Device_content.UIs : Check_UIs(); break;
                            case Device_content.create_body : Check_create_body(); break;
                                case Device_content.finished: break;
                                    default : CONTROLLER__errors.Throw( "State not accept: " + current_content ); return -1;

            }

            return weight;
                
        }

        private void Check_nothing(){

            if( current_content < content_going_to )
                { current_content = Device_content.structure; }

        }

        private void Check_structure(){


            if( current_content < content_going_to )
                {
                    structure.Go_to_content_level( Content_level.full );

                    if( structure.Got_to_full() )
                        { current_content = Device_content.UIs; }
                    return;
                    
                }

            structure.Go_to_content_level( content_states.structure_state );

        }

        private void Check_UIs(){

        
            if( current_content < content_going_to )
                {
                    // ** isso não se refere aos recursos, mas ao level da UI
                    // ** full significa que ele vai ir no final do content da UI -> pega o minimo dos recursos
                    UIs_manager.Go_to_content_level_all_UIs( Content_level.full );

                    if( UIs_manager.Check_all_UIs_content_level( Content_level.full ) )
                        { current_content = Device_content.create_body; }

                    return;
                    
                }

            UIs_manager.Go_to_content_level_all_UIs( content_states.UIs );

            
        }


        private void Check_create_body(){

            // ** se o device precisar de um render externo ele precisa esperar as uis instanciarem para pegar o tamanho da camera?
            
            if( current_content < content_going_to )
                {
                    structure.Set( true );
                    body.Create( structure.Get_game_object() );
                    current_content = Device_content.finished;
                    return;   
                }

            UIs_manager.Go_to_content_level_all_UIs( content_states.UIs );

            
        }



        private void Instanciate_content(){


            if( current_content == Device_content.finished )
                { return; }                

            if( current_content == Device_content.nothing )
                {
                    current_content = Device_content.structure;
                }

            if( current_content == Device_content.structure )
                {
                    // ** O proprio device vai escolher o minimo de cada UI 
                    // ** ou seja se não precisa de um recurso na hora ele vai colocar o minimo do recurso como nada
                    structure.Instanciate();
                    current_content = Device_content.UIs;
                    // structure.Garanty_place_to_instanciate();
                }
            if( current_content == Device_content.UIs )
                {
                    // ** isso não se refere aos recursos, mas ao level da UI
                    // ** full significa que ele vai ir no final do content da UI -> pega o minimo dos recursos
                    UIs_manager.Instanciate_content_all_UIs();
                    current_content = Device_content.create_body;
                }

            if( current_content == Device_content.create_body )
                {
                    structure.Set( true );
                    body.Create( structure.Get_game_object() );
                    current_content = Device_content.finished;
                }                

        }


}