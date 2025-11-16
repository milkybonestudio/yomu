using System;
using System.ComponentModel;
using UnityEngine;


public unsafe abstract partial class Device {


        private static int class_id_static;

        // public Transition t;

        public Device( string _name ){

            body.name = _name;
            id = class_id_static++;

            UIs_manager = CONTAINER__UI_components.Construct( this );
        
            // ** TRANSITIONS
            transitions = Device_state__TRANSITIONS.Construct();
                
                transitions.inactive__TO__active.Finish = Force_active;

                transitions.active__TO__inactive.Finish = Force_inactive;
                transitions.nothing__TO__inactive.Finish = Force_inactive;

                transitions.inactive__TO__nothing.Finish = Force_nothing;


            content_states   =  new Device_contents_states(){
                                                                structure_state = Content_level.full,
                                                                UIs = Content_level.nothing
                                                            };


        }
        

        // ** --- DATA

        public string name;
        public Body body;

        public int id;
        public bool deleted;
        public RESOURCE__structure_copy structure;

        public CONTAINER__UI_components UIs_manager;
        

        // ** --- UPDATE



        // public void Set_place_to_instanciate( GameObject _place_to_instanciate ){ return;  structure.place_to_instanciate = _place_to_instanciate; }

        public void Update( Control_flow _flow ){


            if( deleted )
                { CONTROLLER__errors.Throw( $"Tried to update() the device <Color=lightBlue>{ name }</Color> but it was deleted" ); }

            if( structure == null )
                { CONTROLLER__errors.Throw( $"Did not give the structure in the device { name }. The structure need to be given in the constructor of the device itself ( not the abstraction )." ); };
            
            UIs_manager.Update( _flow ); 

            if( ( going_to_state == Device_state.nothing ) && ( state == Device_state.nothing ) )
                { Update_content( _flow ); return; }

            if( state == Device_state.nothing )
                { Instanciate_content(); }


            Look_safer locker = new(){ times = 100, re_do = true };

            while( locker.re_do ){

                locker.Check();
                
                switch( state ){

                    case Device_state.nothing: locker.re_do = TOOL__device__TRANSITION.Update_nothing( _flow, this, Force_nothing ); break;
                    case Device_state.transition_nothing_TO_inactive: locker.re_do = TOOL__device__TRANSITION.Update_transition_nothing_TO_inactive( _flow, this ); break;
                    case Device_state.inactive: Update_waiting_phase( _flow ); break;
                    case Device_state.transition_inactive_TO_active: locker.re_do = TOOL__device__TRANSITION.Update_transition_inactive_TO_active( _flow, this ); break;
                    case Device_state.active: Update_phase( _flow ); break;
                    case Device_state.transition_active_TO_inactive: locker.re_do = TOOL__device__TRANSITION.Update_transition_active_TO_inactive( _flow, this ); break;
                    case Device_state.transition_inactive_TO_nothing: locker.re_do = TOOL__device__TRANSITION.Update_transition_inactive_TO_nothing( _flow, this ); break;

                }

            }
            
            _flow.weight_frame_available -= body.Update();

        }

        
            
}
