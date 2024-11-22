using UnityEngine;

public static class TOOL__resource_structure_testing {

    
        public static void Test( RESOURCE__structure_copy _structure_copy, GameObject _game_object ){



                CONTROLLER__resources.Get_instance().Update();
                CONTROLLER__tasks.Pegar_instancia().Update();


                int i = 0;

                // --- CHANGE PRE ALLOC

                if( Input.GetKeyDown( KeyCode.X ) )
                    { i++; }


                // --- UP

                if( Input.GetKeyDown( KeyCode.Q ) )
                    { i++; _structure_copy.Load(); }

               if( Input.GetKeyDown( KeyCode.W ) )
                    { i++; _structure_copy.Activate(); }

               if( Input.GetKeyDown( KeyCode.E ) )
                    { i++; _structure_copy.Instanciate( _game_object ); }


                // --- DOWN

                if( Input.GetKeyDown( KeyCode.A ) )
                    { i++; _structure_copy.Unload(); }

               if( Input.GetKeyDown( KeyCode.S ) )
                    { i++; _structure_copy.Deactivate(); }

               if( Input.GetKeyDown( KeyCode.D ) )
                    { i++; _structure_copy.Deinstanciate(); }

                
                if( Input.GetKeyDown( KeyCode.F ) )
                    { i++; _structure_copy.Delete( ref _structure_copy );  }

                

                // --- CHANGE LEVEL PRE ALLOC
                if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                    { i++; _structure_copy.Change_pre_alloc( Resource_structure_content.nothing );  }

                if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                    { i++; _structure_copy.Change_pre_alloc( Resource_structure_content.structure_data );  }

                if( Input.GetKeyDown( KeyCode.Alpha3 ) )
                    { i++; _structure_copy.Change_pre_alloc( Resource_structure_content.game_object );  }




                if( i > 0 )
                    { Print_structure_data( _structure_copy ); }



        }


        public static void Print_structure_data( RESOURCE__structure_copy _structure_copy ){

                if( _structure_copy == null )
                    { return; }

                Console.Clear();

                Console.Log( "<Color=lightBlue>STRUCTURE</Color>" );

                if( _structure_copy.structure != null )
                    {
                        RESOURCE__structure structure = _structure_copy.structure;
                
                        Console.Log( $"    structure.content_going_to: { structure.content_going_to }" );
                        Console.Log( $"    structure.actual_content: { structure.actual_content }" );

                        Console.Log( $"    structure.stage_getting_resource: { structure.stage_getting_resource }" );

                        Console.Log( $"  structure.module_structures: { structure.module_structures }" );
                        // Console.Log( $"  structure.context: { structure.context }" );
                        // Console.Log( $"  structure.main_folder: { structure.main_folder }" );
                        // Console.Log( $"  structure.structure: { structure.resource_path }" );
                        Console.Log( $"  structure.prefab: { structure.prefab }" );
                        //Console.Log( $"  structure.sub_structures: { structure.sub_structures }" );

                        Console.Log( $"   structure.count_places_being_used_nothing: { structure.count_places_being_used_nothing }" );
                        Console.Log( $"   structure.count_places_being_used_structure_data: { structure.count_places_being_used_structure_data }" );
                        Console.Log( $"   structure.count_places_being_used_game_object: { structure.count_places_being_used_game_object }" );   

                        Console.Log( $"   structure.copies: { structure.copies }" );
                        int n = 0; foreach(  Structure_copy_reference s_ref in structure.copies ){ if( s_ref.need_to_get_instanciate ){ n++; } }; 
                        Console.Log( $"   structure.copies[ need_instanciate ]: { n }" );   
                        Console.Log( $"   structure.copies[ DONT_need_instanciate ]: { ( structure.copies.Length - n ) }" );   

                                  
                                    
                    }


                Console.Log( "<Color=lightBlue>    COPY</Color>" );

                
                Console.Log( $"        state: { _structure_copy.state }" );
                Console.Log( $"        level_pre_allocation: { _structure_copy.level_pre_allocation }" );
                Console.Log( $"        actual_need_content: { _structure_copy.actual_need_content }" );

                Console.Log( $"      structure_game_object: { _structure_copy.structure_game_object }" );

                Console.Log( $"      RESOURCE_index: { _structure_copy.RESOURCE_index }" );
                Console.Log( $"      deleted: { _structure_copy.deleted }" );
                Console.Log( $"      name: { _structure_copy.name }" );
                Console.Log( $"      structure: { _structure_copy.structure }" );



        }


}