



using System;
using UnityEngine;



// ** UI COMPONENT IS ALWAYS IN SOME STRUCTURE

        
   

unsafe public abstract partial class UI_component{



        public abstract void Force_active();
        public abstract void Force_inactive();
        public abstract void Force_nothing();


    //mark
    // As funcoes abstratas/virtuais de estado server para informar o sistema que algo especifico precisa ser feito
    // Geralmente carregar mais recursos, tradar dados ou qualquer outra coisa
    // mesmo se forçar ele precisa ser chamado para informar o sistema, nao chamar vai fazer o sistema travar quando for precisar
    // tudo que é importante na transicao nothin, inactive, active deve ser feito ou na transição no Force_thing. 



        // --- CREATE

            public UI_component_type_method_activation create_method_type = UI_component_type_method_activation.all;
            protected virtual void Create_abs(){}
            public Action Create_unique = ()=>{};
            private void Create_GENERIC_UI(){}

            public void Create( UI_component_state_changing_options _options = default ){

                    final_state = UI_component_state.inactive;

                    if( _options.force )
                        {
                            Instanciate_content();
                            Force_inactive();
                            current_state = UI_component_state.inactive;
                        }

            }

            private void Create_finish(){


                    Force_inactive();
                    if( ( create_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                        { Create_unique(); }

                    if( ( create_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                        { Create_abs(); }

                    if( ( create_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                        { Create_GENERIC_UI(); }
                        
            }



        // --- DESTROY

            public UI_component_type_method_activation destroy_method_type = UI_component_type_method_activation.all;
            protected abstract void Destroy_abs();
            public Action Destroy_unique = ()=>{};
            private void Destroy_GENERIC_UI(){

                    final_state = UI_component_state.nothing;
                
            }

            public void Destroy( UI_component_state_changing_options _options = default ){


                    if( ( destroy_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                        { Destroy_unique(); }

                    if( ( destroy_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                        { Destroy_abs(); }

                    if( ( destroy_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                        { Destroy_GENERIC_UI(); }
                        

                    if( _options.force )
                        {
                            Force_nothing();
                            current_state = UI_component_state.nothing;
                        }

            }


            private void Destroy_finish(){


                    Force_nothing();
                    if( ( destroy_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                        { Destroy_unique(); }

                    if( ( destroy_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                        { Destroy_abs(); }

                    if( ( destroy_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                        { Destroy_GENERIC_UI(); }
                        
            }






        // --- ACTIVATE

            public UI_component_type_method_activation activate_method_type = UI_component_type_method_activation.all;

            public Action Activate_unique = ()=>{};
            protected virtual void Activate_abs(){}
            private void Activate_GENERIC_UI(){}

            public void Activate( UI_component_state_changing_options _options = default ){

                    // Console.Log( $"veio activate UI { name }" );

                    final_state = UI_component_state.active;                        

                    if( _options.force )
                        {
                            Instanciate_content();
                            Activate_finish();
                            current_state = UI_component_state.active;
                        }

            }

            private void Activate_finish(){

                    Force_active();

                    if( ( activate_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                        { Activate_unique(); }

                    if( ( activate_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                        { Activate_abs(); }

                    if( ( activate_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                        { Activate_GENERIC_UI(); }
                        
            }


        // --- DEACTIVATE

            public UI_component_type_method_activation deactivate_method_type = UI_component_type_method_activation.all;
            protected virtual void Deactivate_abs(){}
            public Action Deactivate_unique = ()=>{};
            private void Deactivate_GENERIC_UI(){}

            public void Deactivate( UI_component_state_changing_options _options = default ){

                    final_state = UI_component_state.inactive;

                    if( _options.force )
                        {
                            Instanciate_content();
                            Deactivate_finish();
                            current_state = UI_component_state.inactive;
                        }

            }


            private void Deactivate_finish(){

                    Force_inactive();

                    if( ( deactivate_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                        { Deactivate_unique(); }

                    if( ( deactivate_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                        { Deactivate_abs(); }

                    if( ( deactivate_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                        { Deactivate_GENERIC_UI(); }
                        

            }



        // --- DELETE

            public UI_component_type_method_activation delete_method_type = UI_component_type_method_activation.all;
            protected virtual void Delete_abs(){} // depois passar abstract?
            public Action Delete_unique = ()=>{};
            private void Delete_GENERIC_UI(){

                    body.Destroy( ref body );
                    deleted = true;
                    use_state = UI_use_state.waiting_to_delete;
                    current_state = UI_component_state.nothing;
                    
            }

            public void Delete( UI_component_state_changing_options _options = default ){

                    final_state = UI_component_state.nothing;


                    if( ( destroy_method_type & UI_component_type_method_activation.unique ) > UI_component_type_method_activation.pass )
                        { Delete_unique(); }

                    if( ( destroy_method_type & UI_component_type_method_activation.specific ) > UI_component_type_method_activation.pass )
                        { Delete_abs(); }

                    if( ( destroy_method_type & UI_component_type_method_activation.generic ) > UI_component_type_method_activation.pass )
                        { Delete_GENERIC_UI(); }
                        

            }



}