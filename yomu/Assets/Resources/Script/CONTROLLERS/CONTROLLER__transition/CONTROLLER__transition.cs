using System;
using System.Collections;
using UnityEngine;



//mark
// ** provavelmente vale a pena ter um trnasition_block e um transition_mode
public class CONTROLLER__transition {

        //** relacionado com a parte visual

        public static CONTROLLER__transition instancia;
        public static CONTROLLER__transition Pegar_instancia(){ return instancia; }

        public GameObject canvas;

        // --- REQUESTS
        public Transition_request transition_request;
        public INTERFACE__transition_request_visual transition_request_visual;



        public void Change_node( string _name, RESOURCE__structure_copy _content_structure ){

                // ** o unico que pode deletar a structure é o bloco que tem ela 

                if( _content_structure == null )
                    { CONTROLLER__errors.Throw( $"structure came null in { _name }" ); }

                if( _content_structure.state != Resource_state.instanciated )
                    { CONTROLLER__errors.Throw( $"structure<Color=lightBlue>{ _name }</Color> was not instanciated" ); }

                Space_switcher switching_cameras_data = Controllers.canvas_spaces.Switch_cameras( _name );
                

        }

        
        public void Put_transition_request_BLOCK( Transition_request _transition_request_block, INTERFACE__transition_request_visual _transition_request_visual ){

                if( _transition_request_block.tipo != Transition_type.block )
                    { CONTROLLER__errors.Throw( "Tentou colocar a transition req no BLOCK mas era tipo MODO" ); }

                Put_transition_request(  _transition_request_block,  _transition_request_visual );
                return;
        }



        public void Put_transition_request_MODE( Transition_request _transition_request_mode, INTERFACE__transition_request_visual _transition_request_visual ){

                if( _transition_request_mode.tipo != Transition_type.mode )
                    { CONTROLLER__errors.Throw( "Tentou colocar a transition req no MODO mas era tipo BLOCK" ); }

                Put_transition_request(  _transition_request_mode,  _transition_request_visual );
                return;

        }



        private void Put_transition_request( Transition_request _transition_request, INTERFACE__transition_request_visual _transition_request_visual ){


                if( transition_request != null )
                    { CONTROLLER__errors.Throw( "Tentou colocar 2 transicoes modo" ); }

                Requests_verifier.Verify_transition_request( _transition_request );

                transition_request = _transition_request;
                transition_request_visual = _transition_request_visual;
                
                return;


        }


        public IEnumerator Start_transition_BLOCK(){

                // ** garante que o jogo não vai aceitar updates para outros modos: 

                transition_request_visual.Set_transition_space();

                // transition_request.req_change_interface.Prepare_UI_data();
                // transition_request.req_change_interface.Change_UI_hide();

                // yield return Mono_instancia.Start_coroutine( transition_request_visual.Get_hide_IE() );

                // Coroutine wait_task_coroutine = Mono_instancia.Start_coroutine( transition_request_visual.Get_waiting_task_to_finish() );

                // Task_req task = transition_request.task_to_execute_on_hide;
                // task.prioridade = 1_000;
                // CONTROLLER__tasks.Pegar_instancia().Adicionar_task( task );
                // yield return CONTROLLER__tasks.Pegar_instancia().Wait_task_ends( _task_request: task, _max_time_ms: 10_000f ); 

                // // ** sdai loop 
                // Mono_instancia.Stop_coroutine( wait_task_coroutine );

                // // ** atualiza a logica do jogo
                // transition_request.Action_mid_transition();
                // transition_request.req_change_interface.Change_UI_down(); // ** get new ones
                
                // yield return Mono_instancia.Start_coroutine( transition_request_visual.Get_down_IE() );

                // transition_request.Action_end_transition();
                
                yield break; // --- TERMINOU TRANSICAO

        }

        

}


