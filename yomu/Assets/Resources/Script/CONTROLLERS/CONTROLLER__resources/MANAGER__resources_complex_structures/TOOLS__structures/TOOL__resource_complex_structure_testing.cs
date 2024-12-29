using UnityEngine;

public static class TOOL__resource_complex_structure_testing {



        public static void Start(){

            
                string path = "Tela/Container_teste";

                canvas = GameObject.Find( path );
                if( canvas == null )
                    { CONTROLLER__errors.Throw( $"Dond found the canvas for the RESOURCE__image test. Path:<Color=lightBlue> { path }</Color>" ); }

                structure_copy_test = CONTROLLER__resources.Get_instance().resources_complex_structures.Get_complex_structure_copy( Resource_context.Characters, "teste", "Teste", Resource_complex_structure_content.game_object );
            

        }

        public static RESOURCE__complex_structure_copy structure_copy_test;
        private static GameObject canvas;

    
        public static void Test(){


                Process_weight p = new (){ weight = 10 };
                CONTROLLER__resources.Get_instance().Update( ref p );
                CONTROLLER__tasks.Pegar_instancia().Update();


                int i = 0;

                // --- CHANGE PRE ALLOC

                if( Input.GetKeyDown( KeyCode.X ) )
                    { i++; }


                // --- UP

                if( Input.GetKeyDown( KeyCode.Q ) )
                    { i++; structure_copy_test.Load(); }

               if( Input.GetKeyDown( KeyCode.W ) )
                    { i++; structure_copy_test.Activate(); }

               if( Input.GetKeyDown( KeyCode.E ) )
                    { i++; structure_copy_test.Instanciate( canvas ); }


                // --- DOWN

                if( Input.GetKeyDown( KeyCode.A ) )
                    { i++; structure_copy_test.Unload(); }

               if( Input.GetKeyDown( KeyCode.S ) )
                    { i++; structure_copy_test.Deactivate(); }

               if( Input.GetKeyDown( KeyCode.D ) )
                    { i++; structure_copy_test.Deinstanciate(); }

                
                if( Input.GetKeyDown( KeyCode.F ) )
                    { i++; structure_copy_test.Delete( ref structure_copy_test );  }

                

                // --- CHANGE LEVEL PRE ALLOC
                if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                    { i++; structure_copy_test.Change_level_pre_allocation( Resource_complex_structure_content.nothing );  }

                if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                    { i++; structure_copy_test.Change_level_pre_allocation( Resource_complex_structure_content.structure_data );  }

                if( Input.GetKeyDown( KeyCode.Alpha3 ) )
                    { i++; structure_copy_test.Change_level_pre_allocation( Resource_complex_structure_content.game_object );  }




                if( i > 0 )
                    { Print_complex_structure_data( structure_copy_test ); }

                Console.Update();

        }


        public static void Print_complex_structure_data( RESOURCE__complex_structure_copy _complex_structure_copy ){

                if( _complex_structure_copy == null )
                    { return; }

                Console.Clear();

                Console.Log( "<Color=lightBlue>STRUCTURE</Color>" );

                if( _complex_structure_copy.structure != null )
                    {
                        RESOURCE__complex_structure structure = _complex_structure_copy.structure;
                
                        Console.Log( $"    structure.content_going_to: { structure.content_going_to }" );
                        Console.Log( $"    structure.actual_content: { structure.actual_content }" );

                        Console.Log( $"    structure.stage_getting_resource: { structure.stage_getting_resource }" );

                        Console.Log( $"  structure.module_complex_structures: { structure.module_complex_structures }" );
                        // Console.Log( $"  structure.context: { structure.context }" );
                        // Console.Log( $"  structure.main_folder: { structure.main_folder }" );
                        // Console.Log( $"  structure.structure: { structure.resource_path }" );
                        Console.Log( $"  structure.prefab: { structure.prefab }" );
                        //Console.Log( $"  structure.sub_complex_structures: { structure.sub_complex_structures }" );

                        Console.Log( $"   structure.count_places_being_used_nothing: { structure.count_places_being_used_nothing }" );
                        Console.Log( $"   structure.count_places_being_used_complex_structure_data: { structure.count_places_being_used_complex_structure_data }" );
                        Console.Log( $"   structure.count_places_being_used_game_object: { structure.count_places_being_used_game_object }" );   

                        Console.Log( $"   structure.copies: { structure.copies }" );
                        int n = 0; foreach(  Complex_structure_copy_reference s_ref in structure.copies ){ if( s_ref.need_to_get_instanciate ){ n++; } }; 
                        Console.Log( $"   structure.copies[ need_instanciate ]: { n }" );   
                        Console.Log( $"   structure.copies[ DONT_need_instanciate ]: { ( structure.copies.Length - n ) }" );   

                                  
                                    
                    }


                Console.Log( "<Color=lightBlue>    COPY</Color>" );

                
                Console.Log( $"        state: { _complex_structure_copy.state }" );
                Console.Log( $"        level_pre_allocation: { _complex_structure_copy.level_pre_allocation }" );
                Console.Log( $"        actual_need_content: { _complex_structure_copy.actual_need_content }" );

                Console.Log( $"      structure_game_object: { _complex_structure_copy.structure_game_object }" );

                Console.Log( $"      RESOURCE_index: { _complex_structure_copy.RESOURCE_index }" );
                Console.Log( $"      deleted: { _complex_structure_copy.deleted }" );
                Console.Log( $"      name: { _complex_structure_copy.name }" );
                Console.Log( $"      structure: { _complex_structure_copy.structure }" );



        }


}