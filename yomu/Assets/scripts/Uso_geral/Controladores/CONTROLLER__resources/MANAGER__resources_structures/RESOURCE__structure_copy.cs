

using UnityEngine;

public class RESOURCE__structure_copy {


        public RESOURCE__structure_copy( RESOURCE__structure _structure, Resource_structure_content _level_pre_allocation, int _RESOURCE_index ){

            structure = _structure;
            level_pre_allocation = _level_pre_allocation;
            actual_need_content = Resource_structure_content.nothing; // ** nothing / instanciate

            RESOURCE_index = _RESOURCE_index;

        }


        public int RESOURCE_index; 

        public RESOURCE__structure structure;

        public Resource_state state;


        public Resource_structure_content level_pre_allocation; // minimun 

        public Resource_structure_content actual_need_content;



        
        public GameObject structure_game_object; // proprio

        public void Instanciate(){

            if( structure_game_object != null )
                { return; }
            
            

        }

        public void Load(){ structure.module_images.Load( this ); }
        public void Unload(){ structure.module_images.Unload( this ); }
        public void Activate(){ structure.module_images.Activate( this ); }
        public void Deactivate(){ structure.module_images.Deactivate( this ); }

        public void Change_pre_alloc( Resource_structure_content _new_level ){  structure.module_images.Change_pre_alloc( this, _new_level );}


}