using System.Collections;
using UnityEngine;

public interface INTERFACE__transition_request_visual {

        // ** parte visual
        public void Set_transition_space();
        public string Get_name();
        public Transition_plane Get_transition_plane();


        public IEnumerator Get_hide_IE(){ yield break; }
        public IEnumerator Get_waiting_task_to_finish(){ yield break; }
        public IEnumerator Get_down_IE(){ yield break; }


}
