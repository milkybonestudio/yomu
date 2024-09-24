using System;


public static class Directories {

        public static void Guarantee_exists_editor( string _path ){

                
                #if UNITY_EDITOR

                    if( !!!( System.IO.Directory.Exists( _path ) ) )
                        { throw new Exception( $"Nao tinha o folder { _path }" ); }

                #endif


        }

}