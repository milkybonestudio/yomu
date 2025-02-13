using System;
using System.IO;
using UnityEngine;


public static class Images_container_creator {


        public static Images_container_result Construct( string _folder_path ){

                if( !!!( Directory.Exists( _folder_path ) ) )
                    { throw new Exception( $"Nao achou o folder { _folder_path }" ); }

                Images_container_result images_container = new Images_container_result();

                // --- GET FILES INFO
                FileInfo[] images_info = new FileInfo[ 10_000 ];
                int file_info_index = Get_info_images( _folder_path, images_info, 0 );

                // --- CREATE LOCALIZERS
                images_container.localizadores = new string[ file_info_index ];


                // --- GET TOTAL LENGTH CONTAINER
                long total_bytes = 0;
                for( int index_file_info_get_size = 0 ; index_file_info_get_size < file_info_index; index_file_info_get_size++ ){

                    if( images_info[ index_file_info_get_size ] == null )
                        { break; } 
                    total_bytes +=  images_info[ index_file_info_get_size ].Length; 

                }

                // --- CREATE CONTAINER
                images_container.container_png = new byte[ total_bytes ];

                Transfer_images_to_container( _folder_path.Length, _folder_path, images_container,images_info, 0 );

                return images_container;

        }

        public static int Get_info_images( string _folder, FileInfo[] _files_info, int index_files_info  ){

                string[] files_in_folder = Directory.GetFiles( _folder );
                string[] directories_in_folder = Directory.GetDirectories( _folder );

                // --- PEGA FILES
                for( int file_index = 0 ; file_index < files_in_folder.Length; file_index++ )
                    { _files_info[ index_files_info + file_index ] = new FileInfo( files_in_folder[ file_index ] ); }

                index_files_info += files_in_folder.Length;
                
                // --- PEGA DIRECTORIES
                for( int index_directory = 0 ; index_directory < directories_in_folder.Length ; index_directory++ )
                    { index_files_info = Get_info_images( directories_in_folder[ index_directory ], _files_info, index_files_info ); }

                
                return index_files_info;

        }


        public static int Transfer_images_to_container( int _initial_folder_length, string _folder, Images_container_result _images_container, FileInfo[] files_infos,  int _file_info_index  ){


                string[] files_in_folder = Directory.GetFiles( _folder );
                string[] directories_in_folder = Directory.GetDirectories( _folder );

                // ** primeiro vai nos files 
                for( int file_index = 0 ; file_index < files_in_folder.Length; file_index++ ){

                        byte[] png = File.ReadAllBytes( files_in_folder[ file_index ] );

                        if( _images_container.container_png.Length <= _images_container.pointer_atual + png.Length )
                            { Array.Resize( ref _images_container.container_png, _images_container.container_png.Length + png.Length + 5_000_000 ); }

                        // --- TRANSFER PNG
                        System.Buffer.BlockCopy( _images_container.container_png, _images_container.pointer_atual, png, 0, png.Length );

                    
                        string path_local = files_in_folder[ file_index ].Substring( ( _initial_folder_length + 1 ) );
                        string time_creation = files_infos[ ( _file_info_index + file_index ) ].CreationTime.ToString();
                        
                        _images_container.localizadores[ _images_container.image_index ] = $"{ path_local },{ time_creation },{ _images_container.pointer_atual },{ png.Length }";

                        // --- ADVANCE POINTERS
                        _images_container.image_index++;
                        _images_container.pointer_atual += png.Length;

                }

                _file_info_index += files_in_folder.Length;


                // ** depois entra em cada folder
                for( int index_directory = 0 ; index_directory < directories_in_folder.Length ; index_directory++ )
                    { _file_info_index += Transfer_images_to_container( _initial_folder_length, directories_in_folder[ index_directory ], _images_container, files_infos,  _file_info_index   ); }

                return _file_info_index;

        }


}


