

using UnityEngine;

public class RESOURCE__structure_copy {


        //mark
        // ** tem que ver o reajuste depois
        // ** e usar o delete do dic quando acabar as referencias 




        public int RESOURCE_index; 

        public string name;

        // ** trocar por estado ( use, unused, waitign to delete )
        public bool deleted;

        public RESOURCE__structure structure;

        public Resource_use_state ref_state; // trocar nome


        public Resource_state state;

        public Resource_structure_content level_pre_allocation; // minimun 
        public Resource_structure_content actual_need_content;

        
        public GameObject structure_game_object; // proprio

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
        private void Guaranty_field( ref RESOURCE__structure_copy _copy_ref ){ if( _copy_ref == null ){ CONTROLLER__errors.Throw( $"Tried to use the structure copy <Color=white><b>${ name }</b></Color> but the field was null" ); } }

        public void Load(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Load( this ); }
        public void Activate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Activate( this ); }
        public void Instanciate( GameObject _container ){ TOOL__resource_structure_handler_ACTIONS.Instanciate( this, _container ); }



        // ** down resources
        //public void Delete(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Delete( this ); }
        public void Delete( ref RESOURCE__structure_copy _copy_ref ){ Guaranty_field( ref _copy_ref ); Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Delete( this ); _copy_ref = null; }

        public void Unload(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Unload( this ); }
        public void Deactivate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Deactivate( this ); }
        public void Deinstanciate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Deinstanciate( this ); }

        
        // ** suporte
        public void Change_level_pre_allocation( Resource_structure_content _new_level ){  Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Change_level_pre_allocation( this, _new_level );}
        public void Flag_need_to_instanciate( bool _value ){ structure.copies[ RESOURCE_index ].need_to_get_instanciate = _value; }


}