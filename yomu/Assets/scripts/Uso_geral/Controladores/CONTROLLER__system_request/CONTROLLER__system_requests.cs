using System;



public class CONTROLLER__system_requests {


        public static CONTROLLER__system_requests instancia;
        public static CONTROLLER__system_requests Pegar_instancia(){ return instancia; }

        // *** pedidos
        public bool pediu_para_encerrar_jogo = false; // ** vai iniciar 

        // --- PEDIDO FINALIZAR

        public Pedido_para_finalizar pedido_para_finalizar;


        public Pedido_para_finalizar Create_new_finalize_req(){ return Finalize_req_support.Create_new_finalize_req(); }
        public Pedido_para_finalizar Get_finalize_req( bool _need_exist ){ return Finalize_req_support.Get_finalize_req( _need_exist ); }
        public Pedido_para_finalizar Take_finalize_req( bool _need_exist ){ return Finalize_req_support.Take_finalize_req( _need_exist ); }



        // --- REQ TRANSICAO
        public Req_transicao req_transicao;

        public Req_transicao Create_new_transition_req(){ return Transition_req_support.Create_new_transition_req(); }
        public Req_transicao Get_transition_req( bool _need_exist ){ return Transition_req_support.Get_transition_req( _need_exist ); }
        public Req_transicao Take_transition_req( bool _need_exist ){ return Transition_req_support.Take_transition_req( _need_exist ); }



}
