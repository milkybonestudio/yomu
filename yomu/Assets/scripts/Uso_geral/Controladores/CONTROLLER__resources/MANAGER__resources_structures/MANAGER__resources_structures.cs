using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class MANAGER__resources_structures {


        public MANAGER__resources_structures(){

                contexts = System_enums.resource_context;  // ( Resource_context[] ) System.Enum.GetValues( typeof( Resource_context ) );
                context_structures_modules = new MODULE__context_structures[ contexts.Length ];

                for( int context_index = 0 ; context_index < contexts.Length ; context_index++ )
                    { context_structures_modules[ context_index ] = new MODULE__context_structures( _context: contexts[ context_index ], _initial_capacity: 1_000, _buffer_cache: 2_000_000 ); }

                return;

        }
        
        public MODULE__context_structures[] context_structures_modules;

        private Resource_context[] contexts;


        // --- TASK REQUESTS
        public Task_req task;


        // --- PUBLIC METHODS
                                                        //  personagens          //     lily    //      chave
        public RESOURCE__structure_copy Get_structure_copy( Resource_context _context, string _main_folder, Structure_locators _locators, Resource_structure_content _level_pre_allocation ){ return context_structures_modules[ ( int ) _context ].Get_structure_copy( _main_folder, _locators, _level_pre_allocation ) ; }
        



        // --- UPDATE

        private const int weight_to_stop = 5;
        private int context_frame;

        private System.Diagnostics.Stopwatch relogio = new System.Diagnostics.Stopwatch();
        public void Update(){

                context_frame = ( context_frame + 1 ) % contexts.Length;

                int current_weight = 0;
                
                foreach(  RESOURCE__structure structure in  context_structures_modules[ context_frame ].actives_structures_dictionary.Values ){

                        current_weight += Updata_structure( structure );

                        if( structure.copies_need_to_get_instanciated )
                            {
                                if( structure.actual_content != Resource_structure_content.structure_data )
                                    { continue; } // ** NAO TEM OS RECURSOS

                                relogio.Start();

                                for( int index_structure = 0; index_structure < structure.copies_pointer ; index_structure++  ){

                                        current_weight += Instanciate( structure, structure.copies[ index_structure ] );

                                        if( current_weight >= weight_to_stop )
                                            { relogio.Reset(); return; } 

                                        continue;
                                    
                                }
                            }
        
                        if( current_weight >= weight_to_stop )
                            { return; } 
                }

        }


        private int Instanciate( RESOURCE__structure _structure, RESOURCE__structure_copy _copy ){

                if( _copy == null )
                    { return 0; }

                // ** intanciate 
                _copy.structure_game_object = GameObject.Instantiate( _structure.prefab );
                _copy.structure_game_object.SetActive( false );
                
                int time = ( int )( relogio.ElapsedMilliseconds + 1l );
                relogio.Restart();
                return time;

        }



        private int Updata_structure( RESOURCE__structure _structure ){

                // true => pegou uma acao, bloquear
                // ** se veio aqui tem coisa para fazer

                switch( _structure.stage_getting_resource ){

                    case Resources_getting_structure_stage.waiting_to_start: return Handle_waiting_to_start( _structure );
                        case Resources_getting_structure_stage.waiting_to_instanciate: return Handle_waiting_to_instanciate( _structure );
                            case Resources_getting_structure_stage.finished: return 0;
              
                }

                return 0;

        }



        private int Handle_waiting_to_start( RESOURCE__structure _image ){


            return 0;

        }

        
        private int Handle_waiting_to_instanciate( RESOURCE__structure _image ){

            


            return 0;

        }

        


        // --- EXTRA

        public int Get_bytes_allocated(){

                int accumulator = 0;

                // --- IMAGES COMPRESS
                for( int image_index = 0 ; image_index < context_structures_modules.Length ; image_index++){

                        accumulator += context_structures_modules[ image_index ].Get_bytes();

                        // RESOURCE__image image = requests[ image_index ];
                        // if( image == null )
                        //     { return accumulator; }
                        
                        // if( image.multiples_images != null )
                        //     {
                        //         for( int multiple_iamge_index = 0 ; multiple_iamge_index < image.multiples_images.Length ; multiple_iamge_index++ ){

                        //                 if( image.multiples_images[ multiple_iamge_index ].image_compress != null )
                        //                     { accumulator += image.multiples_images[ multiple_iamge_index ].image_compress.Length; } // --- have image
                        //                 continue;

                        //         }

                        //         continue;
                        //     }

                        // // -- SINGLE

                        // if( image.single_image.image_compress == null )
                        //     { continue; }

                        // accumulator += image.single_image.image_compress.Length;
                        // continue;
                    
                }



                return accumulator;
            

        }



    


}
