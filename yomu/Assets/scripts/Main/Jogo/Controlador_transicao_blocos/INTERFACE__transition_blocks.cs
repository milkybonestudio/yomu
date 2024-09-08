using System;
using System.Collections;
using UnityEngine;


public interface INTERFACE__transition_blocks {

        public Tipo_transicao Get_transition_type(){ throw new Exception("Nao foi implementado Get_transition_type"); }
        public IEnumerator Get_transition_IE( Req_transicao _req ){ throw new Exception("Nao foi implementado Get_transition_IE"); }


}