using System;
using UnityEngine;


unsafe public class CONTROLLER__bosses : CONTROLLER__entities<Boss>{


		public static CONTROLLER__bosses instance;
		public static CONTROLLER__bosses Get_instance(){ return instance;}
        
        // --- INTERFACE    
        public void Update(){}
		
}



