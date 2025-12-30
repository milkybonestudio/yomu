// using System;
// using System.Collections;


// public interface INTERFACE__transition_request {



//         // ** o objeto vai iniciar o canvas com tudo que ele precisa, mas não vai ficar resposnavel por destruir nada. O controlador transicao sempre vai limpar





//         // ** parte visual
//         public void Set_transition_space(){ throw new System.Exception( $"Nao foi implementado o metodo Set_transition_space no request { Get_name() }" ); }

        

//         public string Get_name(){ return "Nao foi colocado"; }
//         public IEnumerator Get_hide_IE(){ yield break; }
//         public IEnumerator Get_waiting_task_to_finish(){ yield break; }
//         public IEnumerator Get_down_IE(){ yield break; }


//         // --- logica

        
//         public Transition_request_type Get_transition_request_type(){ throw new System.Exception( $"Nao foi implementado o metodo Get_transition_request_type() no request { Get_name() }" ); }
//         public Transition_request_logic Get_transition_request_logic(){ throw new System.Exception( $"Nao foi implementado o metodo Get_transition_request_logic() no request { Get_name() }" ); }
    
//         public Task_req Get_task_to_execute_on_hide(){ return Get_transition_request_logic().task_to_execute_on_hide; }
//         public Transition_plane Get_transition_plane(){ return Get_transition_request_logic().transition_plane; }
//         public Req_change_interface Get_req_change_interface(){ return Get_transition_request_logic().req_change_interface; }
//         public Action Get_action_end_transition(){ return Get_transition_request_logic().Action_end_transition; }


// }
