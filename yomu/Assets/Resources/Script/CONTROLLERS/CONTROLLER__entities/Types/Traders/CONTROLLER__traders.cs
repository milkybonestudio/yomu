using System;
using UnityEngine;


unsafe public class CONTROLLER__traders : CONTROLLER__entities<Trader>{


		public static CONTROLLER__traders instance;
		public static CONTROLLER__traders Get_instance(){ return instance;}
        
        // --- INTERFACE    
        public void Update(){}
		
}



