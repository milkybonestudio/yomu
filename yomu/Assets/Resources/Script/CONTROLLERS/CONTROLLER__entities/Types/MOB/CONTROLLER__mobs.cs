using System;
using UnityEngine;


unsafe public class CONTROLLER__mobs : CONTROLLER__entities<Mob>{


		public static CONTROLLER__mobs instance;
		public static CONTROLLER__mobs Get_instance(){ return instance;}
        
        // --- INTERFACE    
        public void Update(){}
		
}



