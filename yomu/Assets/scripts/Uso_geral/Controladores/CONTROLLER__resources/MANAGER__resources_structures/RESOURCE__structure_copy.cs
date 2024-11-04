

using UnityEngine;

public class RESOURCE__structure_copy {


        //mark
        // ** tem que ver o reajuste depois
        // ** e usar o delete do dic quando acabar as referencias 


        public RESOURCE__structure_copy( RESOURCE__structure _structure, Resource_structure_content _level_pre_allocation, int _RESOURCE_index ){

            structure = _structure;
            level_pre_allocation = _level_pre_allocation;
            actual_need_content = Resource_structure_content.nothing; // ** nothing / instanciate

            name = _structure.resource_path;

            RESOURCE_index = _RESOURCE_index;

        }


        public int RESOURCE_index; 
        public bool deleted;
        public string name;

        public RESOURCE__structure structure;


        public Resource_state state;

        public Resource_structure_content level_pre_allocation; // minimun 
        public Resource_structure_content actual_need_content;



        
        public GameObject structure_game_object; // proprio

        public void Instanciate(){

            if( structure_game_object != null )
                { return; }
            
            

        }


        /*
            //testes: 

            -> mudar minimo estando sem estar load: ok
            -> mudar minimo estando com load: ok


            testes saindo no nothing

            -> load: ok
            -> activate: ok
            -> instanciate: ok

            teste saindo instanciado :

                -> unload : ok
                -> deactivate : ok
                -> deinstanciate :  ok
                -> delete : ok


            teste saindo Active :

                -> unload : ok
                -> deinstanciate : ok
                -> deactivate : ok
                -> delete : ok

            
            teste saindo load :

                -> unload : ok
                -> deinstanciate : ok
                -> deactivate : ok
                -> delete : ok
        
        */

        



        // ** up resources

        private void Guaranty_copy(){ if( deleted ){ CONTROLLER__errors.Throw( $"Tried to use the structure copy <Color=white><b>${ name }</b></Color> but the copy was deleted" ); } }

        public void Load(){ Guaranty_copy(); structure.module_structures.Load( this ); }
        public void Activate(){ Guaranty_copy(); structure.module_structures.Activate( this ); }
        public void Instanciate( GameObject _container ){ structure.module_structures.Instanciate( this, _container ); }



        // ** down resources
        public void Delete(){ Guaranty_copy(); structure.module_structures.Delete( this ); }
        public void Delete( ref RESOURCE__structure_copy _copy_ref ){ Guaranty_copy(); structure.module_structures.Delete( this ); _copy_ref = null; }
        public void Unload(){ Guaranty_copy(); structure.module_structures.Unload( this ); }
        public void Deactivate(){ Guaranty_copy(); structure.module_structures.Deactivate( this ); }
        public void Deinstanciate(){ Guaranty_copy(); structure.module_structures.Deinstanciate( this ); }

        
        // ** suporte
        public void Change_pre_alloc( Resource_structure_content _new_level ){  Guaranty_copy(); structure.module_structures.Change_pre_alloc( this, _new_level );}


}