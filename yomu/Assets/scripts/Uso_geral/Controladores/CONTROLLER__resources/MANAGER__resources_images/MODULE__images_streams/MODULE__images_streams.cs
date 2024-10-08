using System;
using System.Collections.Generic;
using System.IO;


public class MODULE__images_streams {


        public MODULE__images_streams( int _initial_capacity, int _buffer_cache ){

            files_streams = new Dictionary<string, FileStream>();
            files_streams.EnsureCapacity( _initial_capacity );

            buffer_cache = _buffer_cache;
            
        }

        private Dictionary<string, FileStream> files_streams;
        private int buffer_cache;


        public void Clean_streams(){

                foreach( FileStream file_stream in files_streams.Values )
                    { file_stream.Close(); }

                files_streams.Clear();

        }


        public byte[] Get_data( string _path, int _initial_pointer, int _length ){


                FileStream file_stream = null;
                
                if( !!!( files_streams.TryGetValue( _path, out file_stream ) ) )
                    { files_streams.Add( _path, FILE_STREAM.Criar_stream( _path, buffer_cache )); }


                file_stream.Seek( _initial_pointer, SeekOrigin.Begin );

                byte[] image = new byte[ _length ];

                file_stream.Read( image, 0, _length );
    
                return image;


        }


}