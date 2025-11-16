

using System;
using UnityEngine;


// ** UI COMPONENT IS ALWAYS IN SOME STRUCTURE
    

unsafe public abstract partial class UI_component {

        public UI_component(){

            resources_container = new MANAGER__resources();

                transitions = UI_component_state__TRANSITIONS.Construct();
                
                transitions.nothing__TO__inactive.Finish = Create_finish;
                transitions.inactive__TO__nothing.Finish = Destroy_finish;

                transitions.inactive__TO__active.Finish = Activate_finish;
                transitions.active__TO__inactive.Finish = Deactivate_finish;

                                
        }

        //mark
        // ver depois qual
        public UI_use_state use_state;
        public bool deleted;
        public RESOURCE__structure_copy structure;

        public string name;
        public MANAGER__resources resources_container;
        public Body body;
        
    
        public UI_component_state current_state = UI_component_state.nothing;
        public UI_component_state final_state = UI_component_state.nothing;


        public UI_component_state__TRANSITIONS transitions;


        public string _path_to_UI_in_structure;

        // --- MAIN CONTROL

            // --- UPDATE

            protected abstract void Update_phase( Control_flow _flow );
            protected virtual void Update_waiting_phase( Control_flow _flow ){}
            public virtual void Update( Control_flow _flow ){ 


                // Console.Log( $"UI {name} is with state <Color=lightBlue>{ current_state }</Color> and final state: <Color=lightBlue>{ final_state }</Color>" );


                if( use_state == UI_use_state.waiting_to_delete )
                    { CONTROLLER__errors.Throw( $"Is trying to acces UI <Color=lightBlue>{ name }</Color> but it was deleted" ); }

                if( ( final_state == UI_component_state.nothing ) && ( current_state == UI_component_state.nothing ) )
                    { 
                        Update_content( _flow );
                        return; 
                    }

                if( current_state == UI_component_state.nothing )
                    {
                        Instanciate_content();
                        TOOL__UI_component_TRANSITIONS.Update_nothing( _flow, this, Force_nothing );
                    }


                
                Instanciate_content();

                if( material_manager_is_specific )
                    { Specific_material_update(); }
                    else
                    { Update_material(); }


                bool re_do = true;

                Look_safer locker = new(){ times = 100 };

                while( re_do ){

                    locker.Check();
                    re_do = false;

                    switch( current_state ){

                        case UI_component_state.active: Update_phase( _flow ); break;
                        case UI_component_state.inactive: Update_waiting_phase( _flow ); break;

                        case UI_component_state.transition_nothing_TO_inactive: re_do = TOOL__UI_component_TRANSITIONS.Update_transition_nothing_TO_inactive( _flow, this ); break;
                        case UI_component_state.transition_active_TO_inactive: re_do = TOOL__UI_component_TRANSITIONS.Update_transition_active_TO_inactive( _flow, this ); break;
                        case UI_component_state.transition_inactive_TO_active: re_do = TOOL__UI_component_TRANSITIONS.Update_transition_inactive_TO_active( _flow, this ); break;
                        case UI_component_state.transition_inactive_TO_nothing: re_do = TOOL__UI_component_TRANSITIONS.Update_transition_inactive_TO_nothing( _flow, this ); break;
                    }

                }
                
                
                _flow.weight_frame_available -= body.Update();

            }


}

