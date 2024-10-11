using System;
using System.Collections.Generic;
using System.IO;


public static class MODULE__characters_images_localizers {


        //public static Dictionary<string,Image_localizers> localizadores_por_personagens;
        public static Dictionary<int,Dictionary<string,Image_localizers>> localizadores_por_personagens;
        

        public static void Prepare_localizers( Personagem_nome[] personagens ){


                localizadores_por_personagens = new Dictionary<int,Dictionary<string,Image_localizers>>();
                localizadores_por_personagens.EnsureCapacity( personagens.Length );

                string path_folder = Paths_system.Get_path_folder__images_container_type( Images_container_type.Characters ); 

                for( int personagem_index = 0 ; personagem_index < personagens.Length ; personagem_index++ ){

                        Dictionary<string,Image_localizers> personagem_dicionario = new Dictionary<string,Image_localizers>();
                        localizadores_por_personagens.Add( ( int ) personagens[ personagem_index ], personagem_dicionario );

                        string[] file_with_localizers_lines = System.IO.File.ReadAllLines( Path.Combine( path_folder, ( personagens[ personagem_index ].ToString() + "_localizers.txt" ) ) );

                        for( int line_index = 0 ; line_index < file_with_localizers_lines.Length ; line_index++ ){

                                string[] line_split = file_with_localizers_lines[ line_index ].Split( "," );

                                if( line_split.Length != 3 )
                                    { throw new Exception(  $"iamge localizer dont came with the 3 parameter. came: { file_with_localizers_lines[ line_index ] }" ); }


                                string container_name = line_split[ 0 ];
                                Image_localizers localizers = new Image_localizers { initial_pointer = System.Convert.ToInt32( line_split[ 1 ] ), length = System.Convert.ToInt32( line_split[ 2 ] ) };

                                personagem_dicionario.Add( container_name, localizers );
                                return;
                            
                        }

                }


        }

        

}