
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class Composed_structured_locators {

    public string main_struct;
    public string[] sub_structs;

}


public class MODULE__context_structures {


        public MODULE__context_structures( Resource_context _context, int _initial_capacity, int _buffer_cache ){


                context = _context;
                context_folder = _context.ToString();

                #if !!! UNITY_EDITOR
                    file_stream = FILE_STREAM.Criar_stream( _path, buffer_cache );
                #endif

                actives_structures_dictionary = new Dictionary<string, RESOURCE__structure>();
                actives_structures_dictionary.EnsureCapacity( _initial_capacity );


        }

        public int Get_bytes(){ return 0; }


        private string context_folder;
        private Resource_context context;

        public MANAGER__resources_images manager;

        private FileStream file_stream;

        
        public Dictionary<string, RESOURCE__structure> actives_structures_dictionary;
        public Dictionary<string, Resource_image_localizer> structures_locators_dictionary;


        
        public RESOURCE__structure_copy Get_structure_copy(  string _main_folder, Composed_structured_locators _locators  Resource_structure_content _level_pre_allocation  ){

                RESOURCE__structure structure = null;

                if( !!!( Get_dictionary( _main_folder ).TryGetValue( _locators.main_struct, out structure ) ) )
                    {
                        // --- NEED TO CREATE NEW STRUCTURE 
                        RESOURCE__structure new_structure = new RESOURCE__structure( this, context, _main_folder, _locators.main_struct );

                            if( _locators.sub_structs != null )
                                {
                                    // --- HAVE SUB STRUCTURES
                                    new_structure.sub_structures = new RESOURCE__structure[ _locators.sub_structs.Length ];

                                    for( int index = 0 ; index < _locators.sub_structs.Length ;  index++ ){

                                            string sub_struct = _locators.sub_structs[ index ];
                                            CONTROLLER__errors.Verify( ( sub_struct == null ), $"Sub_struct came null" );

                                            RESOURCE__structure new_sub_structure = null;

                                            if( !!! ( Get_dictionary( _main_folder ).TryGetValue( sub_struct, out new_sub_structure ) ) )
                                                { 
                                                    // --- NEED TO CREATE NEW SUB STRUCTURE
                                                    new_sub_structure = new RESOURCE__structure( this, context, _main_folder, sub_struct ); 

                                                }

                                            //mark
                                            // ** tem que ajustar o level_pre_allocation

                                            new_structure.sub_structures[ index ] = new_sub_structure;

                                    }
                                }

                        structure = new_structure;

                    }


                return null;
        }




        public void Delete( RESOURCE__image_ref _ref ){  return; } 

        // ** dados vao ser perdidos, mas a referencia da imagem volta 
        public void Unload( RESOURCE__image_ref _ref ){}

        // ** vai para o minimo
        public void Free( RESOURCE__image_ref _ref ){}



        // --- PEGAR RECURSOS

        // ** sinaliza que a imagem pode carregar o minimo 
        public void Load( RESOURCE__image_ref _ref ){}

        // ** sinaliza que pode começar a pegar a texture
        public void Get_ready( RESOURCE__image_ref _ref ){}





        // --- INTERNAL

        private Dictionary<string, RESOURCE__image> Get_dictionary( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return actives_structures_dictionary;

        }

        private Dictionary<string, Resource_image_localizer> Get_dictionary_locators( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return structures_locators_dictionary;

        }

        



        #if UNITY_EDITOR

            private string Get_path_file( string _main_folder, string _path ){

                    return Path.Combine( Application.dataPath, "Resources", context_folder, _main_folder,  ( _path + ".png") ) ;     

            }

            private string Get_folder_file( string _main_folder, string _path ){

                return Directory.GetParent( Get_path_file(_main_folder, _path) ).FullName;

            }


        #endif

    

        public byte[] Get_single_data( string _main_folder, string _path ){

                // ** o jogo nao vai usar webp na build então precisa do type
                // ** o webp vai ser path_low_quality

            
                byte[] image = null;

                    // **   pensar da  seguinte forma: ( path sistema(C:\\users\\user...) ) || ( container( Devices, Characters, ...  ) ) || ( chave ( "\\Lily\\normal_clothes\\arms_1.png" ) )
                    // **   no editor path systema vai dado por Application.DataPath + "\\Resources"
                    // **   na build vai ser Application.DataPath + "\\Static_data"

                    #if UNITY_EDITOR

                        string path_arquivo = Get_path_file( _main_folder, _path );

                        try{ return System.IO.File.ReadAllBytes( path_arquivo ); } catch( Exception e ){ Debug.LogError( $"Dont find the image <Color=lightBlue>{ path_arquivo }</Color>" ); throw e; }

                    
                    #elif !!!( UNITY_EDITOR ) && ( UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX)
                        
                        
                        thorw new Exception( "Ainda tem que fazer" );


                        // int _initial_pointer = _image.single_image.image_localizers.initial_pointer;
                        // int _length = _image.single_image.image_ocalizers.length;


                        FileStream file_stream = null;
                        
                        if( !!!( files_streams.TryGetValue( _path, out file_stream ) ) )
                            { files_streams.Add( _path, FILE_STREAM.Criar_stream( _path, buffer_cache )); }


                        file_stream.Seek( _initial_pointer, SeekOrigin.Begin );

                        byte[] image = new byte[ _length ];

                        file_stream.Read( image, 0, _length );
            
                        return image;

                    
                    #endif



                return image;
            
        }



        private void Increase_count( RESOURCE__image _image, Resource_image_content _state ){

                switch( _state ){

                    case Resource_image_content.nothing : _image.count_places_being_used_nothing++; break;
                    case Resource_image_content.compress_data : _image.count_places_being_used_compress_data++; break;
                    case Resource_image_content.texture : _image.count_places_being_used_texture++; break;
                }

        }

        private void Decrease_count( RESOURCE__image _image, Resource_image_content _state ){

                switch( _state ){

                    case Resource_image_content.nothing : _image.count_places_being_used_nothing--; break;
                    case Resource_image_content.compress_data : _image.count_places_being_used_compress_data--; break;
                    case Resource_image_content.texture : _image.count_places_being_used_texture--; break;
                }

        }



}