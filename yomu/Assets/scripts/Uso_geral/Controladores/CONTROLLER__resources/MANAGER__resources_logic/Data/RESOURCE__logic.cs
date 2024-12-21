
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


unsafe public class RESOURCE__logic {


        // *** dll -> context -> class 

        public MODULE__context_logics module_logics;

        public MethodInfo method_info;

        public Resource_use_state logic_state;
        public Resource_context logic_context;


        public string class_name;
        public string method_name;

        public string logic_key; // class + method



        public int request_id;
        
        public string name = "NAO_COLOCOU";

        
        
        // --- DATA FOR GETTING RESOURCES    

        public Resources_getting_logic_stage stage_getting_resource; // ** precess of getting the resource

        public Resource_logic_content content_going_to; // se estiver em uma transicao de recursos é o ponto final 
        public Resource_logic_content actual_content; // ** o recurso atual

        
        
        // public RESOURCE__image_data[] multiples_image



        // --- REFERENCES

        public RESOURCE__logic_ref[] refs = new RESOURCE__logic_ref[ 100 ];
        public int refs_pointer;
        public bool need_reajust;
                   
        public int count_places_being_used_nothing; 
        public int count_places_being_used_method_info; 


        


}


