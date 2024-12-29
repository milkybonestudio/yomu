using System;
using UnityEngine;


unsafe public class CONTROLLER__characters : CONTROLLER__entities<Character>{


		public static CONTROLLER__characters instance;
		public static CONTROLLER__characters Get_instance(){ return instance;}
        
        // --- INTERFACE    
        public void Update(){}
		
}



