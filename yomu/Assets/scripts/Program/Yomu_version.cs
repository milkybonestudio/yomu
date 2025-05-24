

using UnityEngine;

public static class CONTROLLER__yomu_version {

        public const byte EDITION = 3;
        public const byte MINOR = 0;
        public const byte PATH = 0;

        public static void Verify(){

                if( !!!( System.IO.File.Exists( Paths_files.persistent_data_version ) ) )
                    { CONTROLLER__errors.Throw( $"The version file do not exist in { Paths_files.persistent_data_version }" ); }

                byte[] version = System.IO.File.ReadAllBytes( Paths_files.persistent_data_version );

                bool is_equal = true;

                if( version[ 0 ] != EDITION )
                    { is_equal = false; }

                if( version[ 1 ] != MINOR )
                    { is_equal = false; }

                if( version[ 2 ] != PATH )
                    { is_equal = false; }


                if( !!!( is_equal ) )
                    { 
                        Console.Log( $"<Color=lightBlue>version</Color> Was diferente" );


                        #if UNITY_EDITOR

                            Console.Log( "The version of the saved data is not the current one" );

                            if( !!!( Paths_system.persistent_data_path.Contains( Application.dataPath ) ) )
                                    { CONTROLLER__errors.Throw( $"Tried to handle version changes, but the path { Paths_system.persistent_data_path } dont contain the path { Application.dataPath }" ); return; }
                                    

                                System.IO.Directory.Delete( Paths_system.persistent_data_path, true );
                                
                        #else

                            if( !!!( Paths_system.persistent_data_path.Contains( Application.persistentDataPath ) ) )
                                { CONTROLLER__errors.Throw( $"Tried to handle version changes, but the path { Paths_system.persistent_data_path } dont contain the path { Application.dataPath }" ); return; }

                            Console.Log( Paths_system.persistent_data_path );

                            string path_persistent_old_version = Paths_system.persistent_data_path + $"_{ version[ 0 ].ToString() }__{ version[ 1 ].ToString() }__{ version[ 2 ].ToString() }";

                            if( System.IO.Directory.Exists( path_persistent_old_version )  )
                                { System.IO.Directory.Delete( path_persistent_old_version, true ); }

                            // *** MUDA O NOME 
                            System.IO.Directory.Move( Paths_system.persistent_data_path, path_persistent_old_version);
                            
                        #endif

                        // *** CRIA NOVO
                        Console.Log( "<Color=lightBlue>Updated</Color>" );
                        TOOL__folders_constructor.Construct_new_persistent_data_path();

                    }

        }

        public static string Get_path_persistent(){

            return System.IO.Path.Combine( Paths_system.persistent_data_path, $"{ EDITION.ToString() }__{ MINOR.ToString() }__{ PATH.ToString() }" );

        }

        public static  byte[] Get_verion(){

            return new byte[]{

                EDITION, 
                MINOR, 
                PATH

            };

        }



}