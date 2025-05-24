

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RESOURCE__structure_copy : RESOURCE__ref {


        //test

            // public static GameObject container_generic;

        //test

        public int RESOURCE_index; 

        // ** trocar por estado ( use, unused, waitign to delete )
        public bool deleted;

        public RESOURCE__structure structure;

        public Resource_use_state ref_state; // trocar nome

        //test
        public Resource_structure_content actual_content;
        

        public Resource_structure_content level_pre_allocation; // minimum 
        public Resource_structure_content actual_need_content;

        
        public GameObject structure_game_object; // proprio

        //teste
            // ** NAO NAO  vale mais a pena deixar onde tem que isntanciar aqui
            // ** structure é recurso, place_to_instanciate deveria ser quando o recurso fosse usado. Não faz sentido na hirarquia de content 
            // ** mesmo que eu tenha que tecnicamente mudar ele mais vezes ele já vai ser mudado mais quando for contruir o body 
            // ** uma structure sempre tem que ser instanciada no container padrão e movida quando necessario
            public GameObject place_to_instanciate;

            public void Garanty_place_to_instanciate(){

                #if UNITY_EDITOR

                    if( place_to_instanciate == structure.module_structures.manager.container_to_instanciate )
                        { CONTROLLER__errors.Throw( $"Tried to place the structure <Color=lightBlue>{ name }</Color> but the place to instanciate was not give" ); }

                #endif

            }


        //teste



        // ** precisa ficar aqui, cada image tem um pointer diferente
        public Dictionary<string,Unity_main_components> components_dic;



        
        //mark
        // ** 

        // --- SUPPORT
        
                private void Guaranty_copy(){ if( deleted ){ CONTROLLER__errors.Throw( $"Tried to use the structure copy <Color=white><b>{ name }</b></Color> but the copy was deleted" ); } }
                private void Guaranty_dic(){ if( actual_content < Resource_structure_content.game_object ){ CONTROLLER__errors.Throw( $"Tried to get a component in structure copy <Color=white><b>{ name }</b></Color> but the structure actual content is <Color=white><b>{ structure.actual_content }</b></Color>" ); } }
                private void Guaranty_instance(){ if( state < Resource_state.instanciated ){ CONTROLLER__errors.Throw( $"The structure copy <Color=white><b>{ name }</b></Color> was not instanciated" ); } }
                
                public void Return_to_container(){

                    Guaranty_instance();
                    Set_parent( Controllers.resources.structures.container_to_instanciate );

                }

        // --- RESOURCE

                // ** up resources
                public override void Load(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Load( this ); }
                public override void Activate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Activate( this ); }
                // ** tem que mudar o nome, instanciate nao faz sentido
                public override void Instanciate(){ TOOL__resource_structure_handler_ACTIONS.Instanciate( this, null ); structure_game_object.SetActive( true ); }

                // _container -> null -> continue no container structs
                // public RESOURCE__structure_copy Instanciate( GameObject _container = null, bool _set = true ){ TOOL__resource_structure_handler_ACTIONS.Instanciate( this, _container ); structure_game_object.SetActive( _set ); return this; }

                // ** down resources

                public override void Unload(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Unload( this ); }
                public override void Deactivate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Deactivate( this ); }
                public override void Deinstanciate(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Deinstanciate( this ); }

                public override void Delete(){ Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Delete( this ); }
                

                // ** support resource

                public GameObject Get_game_object(){ TOOL__resource_structure_handler_ACTIONS.Instanciate( this, null ); return structure_game_object; }
                public void Set_parent( GameObject _parent ){ Guaranty_copy(); Guaranty_instance(); structure_game_object.transform.SetParent( _parent.transform, false ); }
                public void Set( bool _set  ){ Guaranty_copy(); structure_game_object.SetActive( _set ); }
                public void Change_level_pre_allocation( Resource_structure_content _new_level ){  Guaranty_copy(); TOOL__resource_structure_handler_ACTIONS.Change_level_pre_allocation( this, _new_level );}
                public void Flag_need_to_instanciate( bool _value ){ structure.copies[ RESOURCE_index ].need_to_get_instanciate = _value; }



        // --- UTILITY

                public GameObject Get_component_game_object( string _component_key ){ Guaranty_copy(); Guaranty_dic(); return TOOL__resources_structures.Get_component_game_object( this, _component_key ); }
                public Image Get_component_image( string _component_key ){ Guaranty_copy(); Guaranty_dic(); return TOOL__resources_structures.Get_component_image( this, _component_key ); }
                public SpriteRenderer Get_component_sprite_render( string _component_key ){ Guaranty_copy(); Guaranty_dic(); return TOOL__resources_structures.Get_component_sprite_render( this, _component_key ); }

                public Unity_main_components Get_components( string _component_key ){ Guaranty_copy(); Guaranty_dic(); return TOOL__resources_structures.Get_components( this, _component_key ); }

                public override bool Got_to_minimum(){

                    // Console.Log( "actual_content: " + actual_content );
                    // Console.Log( "level_pre_allocation: " + level_pre_allocation );

                    return ( actual_content == level_pre_allocation );

                }


                public override bool Got_to_full(){

                    Debug.Log( "Veio Got_to_full" );
                    Debug.Log( actual_content );


                    return ( actual_content == Resource_structure_content.game_object );
                }






        


}