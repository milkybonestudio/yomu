using System;
using UnityEngine;


unsafe public class CONTROLLER__kingdoms : CONTROLLER__entities<Kingdom>{


		public static CONTROLLER__kingdoms instance;
		public static CONTROLLER__kingdoms Get_instance(){ return instance;}
        
        // --- INTERFACE    
        public void Update(){}
		
}



