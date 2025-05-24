using System.IO;


public static class FILE_STREAM {


        public static FileStream Criar_stream( string _path, int _tamanho_buffer ){


                FileMode file_mode = FileMode.Open;
                FileAccess file_accees = FileAccess.ReadWrite;
                FileShare file_share = FileShare.Read;
                FileOptions file_options = FileOptions.WriteThrough;

                return new FileStream( _path, file_mode, file_accees , file_share, _tamanho_buffer , file_options );
                

        }


}

                                        