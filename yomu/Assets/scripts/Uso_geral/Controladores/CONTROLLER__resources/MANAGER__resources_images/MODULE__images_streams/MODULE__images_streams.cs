using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class MODULE__context_images {

        /*
                por hora todo o contexto vai estar em 1 grande container. Quando for precisar ter mais precisa fazer de um jeito para nao ficar criando e destruindo streams. 
                por hora pode ter sempre 1 em cada modelo.

        
        */

        //mark
        // por hora nao vai ser preocupar com os pointers, no final vai ter um arquivo  context_folder.txt na pasta com os pointers


        public MODULE__context_images( Resource_context _context, int buffer_cache ){

                context_folder = _context.ToString();

                #if !!! UNITY_EDITOR
                    file_stream = FILE_STREAM.Criar_stream( _path, buffer_cache );
                #endif



        }


        // ** 


        private string context_folder;

        private FileStream file_stream;
        private Dictionary<string, RESOURCE__image> images_dictionary;




        public RESOURCE__image_ref Get_image_ref(  string _main_folder, string _path, Level_pre_allocation_image _level_pre_allocation  ){

                // ** depois 


                RESOURCE__image image = null;
                Dictionary<string, RESOURCE__image> dic = Get_dictionary( _main_folder );

                string path = ( _main_folder + "\\" + _path ); // ** quando for expandir vai ser somente o _path

                dic.TryGetValue( path, out image );

                if( image != null )
                    { 
                        return image.Add_ref( _level_pre_allocation ) ; 
                    }

        }




        private Dictionary<string, RESOURCE__image> Get_dictionary( string _main_folder ){

                // ** por hora vai ter somentye 1 container então só vai ter 1 dicionario. 
                // ** depois cada _main_folder vai ter             

                return images_dictionary;

        }




        public byte[] Get_data( RESOURCE__image _image ){


                // **   pensar da  seguinte forma: ( path sistema(C:\\users\\user...) ) || ( container( Devices, Characters, ...  ) ) || ( chave ( "\\Lily\\normal_clothes\\arms_1.png" ) )
                // **   no editor path systema vai dado por Application.DataPath + "\\Resources"
                // **   na build vai ser Application.DataPath + "\\Static_data"

                #if UNITY_EDITOR

                    string path_arquivo = Path.Combine( Application.dataPath, "Resources", context_folder, ( _image.single_image.image_path + "." + _image.type.ToString()) ) ;

                    try{ return System.IO.File.ReadAllBytes( path_arquivo ); } catch( Exception e ){ Debug.LogError( $"Dont find the image { path_arquivo }" ); throw e; }

                
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




        }

        public byte[][] Get_multiple_data( RESOURCE__image _image ){

                throw new Exception("tem que fazerr");


        }


}