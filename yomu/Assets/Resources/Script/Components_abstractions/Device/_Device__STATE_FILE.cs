using System;
using System.ComponentModel;
using UnityEngine;




public unsafe abstract partial class Device {


        public Device_state state = Device_state.nothing;
        public Device_state going_to_state = Device_state.nothing;
        public Device_state__TRANSITIONS transitions;



        protected virtual void Force_inactive(){}
        protected virtual void Force_active(){}
        protected virtual void Force_nothing(){}


        // ** chama somente quando ativo
        protected virtual void Update_phase( Control_flow _flow ){ /*Console.Log( $"Nao criou phase update no device <Color=lightBlue>{ name }</Color>" );*/ }
        protected virtual void Update_waiting_phase( Control_flow _flow ){ /*Console.Log( $"Nao criou Update_waiting_phase no device <Color=lightBlue>{ name }</Color>" );*/ }


        //mark
        // As funcoes abstratas/virtuais de estado server para informar o sistema que algo especifico precisa ser feito
        // Geralmente carregar mais recursos, tradar dados ou qualquer outra coisa
        // mesmo se forçar ele precisa ser chamado para informar o sistema, nao chamar vai fazer o sistema travar quando for precisar
        // tudo que é importante na transicao nothin, inactive, active deve ser feito ou na transição no Force_thing. 



        private GameObject place_to_instanciate;


        public bool created; // ** ver melhor depos

        protected virtual void Create_device_signal(){}
        public void Create( Device_activate_data _data ){

            if( created )
                { CONTROLLER__errors.Throw( $"Tried to Create the device <Color=lightBlue>{ name }</Color> but it was already created" ); }

            created = true;

            if( _data.start_state == Device_state.not_give )
                { _data.start_state = Device_state.nothing; }

            if( ( _data.start_state & Device_state.acceptable_states_to_start ) == Device_state.not_give )
                { CONTROLLER__errors.Throw( $"Tried to Create the device <Color=lightBlue>{ name }</Color> but the start state was <Color=lightBlue>{ _data.start_state }</Color>" ); }

            going_to_state = _data.start_state;


            Create_device_signal();

            Instanciate_content();


            _data.body_set_data.parent = ( _data.body_set_data.parent ?? _data.parent ?? place_to_instanciate );
            body.Set_parent( _data.body_set_data );



            if( _data.change_state_data.new_state == Device_state.not_give )
                { _data.change_state_data.new_state = _data.start_state; }

            Change_state( _data.change_state_data );

        }



        protected virtual void Destroy_device_signal(){}
        public void Destroy(){

            going_to_state = Device_state.nothing;
            Destroy_device_signal();

        }


        public void Change_state( Device_change_state_data _data ){

            if( !!!( created ) )
                { CONTROLLER__errors.Throw( $"Tried to change the state of the device <Color=lightBlue>{ name }</Color> but it was not created" ); }
 
            if( _data.new_state == Device_state.not_give )
                { _data.new_state = Device_state.nothing; }

            if( ( _data.new_state & Device_state.acceptable_states_to_start ) == Device_state.not_give )
                { CONTROLLER__errors.Throw( $"Tried to Create the device <Color=lightBlue>{ name }</Color> but the start state was <Color=lightBlue>{ _data.new_state }</Color>" ); }


            going_to_state = _data.new_state;


            if( _data.force )
                {
                    // ** EQUAL FINAL == JUST FORCE
                    if( state == going_to_state )
                        {
                            switch( state ){
                                case Device_state.nothing: Force_nothing(); break;
                                case Device_state.active: Force_active(); break;
                                case Device_state.inactive: Force_inactive(); break;
                                default: CONTROLLER__errors.Throw( $"Can not handle type <Color=lightBlue>{ state }</Color>" ); break;
                            }

                            state = going_to_state;
                        
                        }

                    if( state < going_to_state )
                        {
                            // **  NEED GO UP
                            if( ( state == Device_state.nothing ) && ( going_to_state < Device_state.nothing ) )
                                { Force_inactive(); state = Device_state.inactive; }

                            if( ( state == Device_state.inactive ) && ( going_to_state < Device_state.active ) )
                                { Force_nothing(); state = Device_state.active; }
                        }
                        else
                        {
                            // ** NEED GO DOWN
                            if( ( state == Device_state.active ) && ( going_to_state <= Device_state.inactive ) )
                                { Force_inactive(); state = Device_state.inactive; }

                            if( ( state == Device_state.inactive ) && ( going_to_state <= Device_state.nothing ) )
                                { Force_nothing(); state = Device_state.nothing; }
                        }


                }

        }




        // // --- ABSTRACTION

        protected virtual void Delete_device_signal(){}
        public virtual void Delete(){

            Delete_device_signal();
            UIs_manager.Delete_all_UIs();
            deleted = true;

        }


            
}
