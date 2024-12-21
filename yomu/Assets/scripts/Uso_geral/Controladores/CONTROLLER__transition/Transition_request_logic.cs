


public class Transition_request {


        // --- blocks 
        public Block_type block_to_go; // nada => assume que é transicao entre modos
        public int modo = -1;
        public Transition_type tipo;


        public Req_change_interface req_change_interface;
        public Task_req task_to_execute_on_hide;

        public System.Action Action_mid_transition; // ** change block => executa depois de task for finalizada
        public System.Action Action_end_transition = ()=> {};

}



