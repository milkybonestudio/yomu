using System;
using System.IO;



unsafe public static class Files {


    public static void Try_delete( string _path ){

        if( File.Exists( _path ) )
            { File.Delete( _path ); }

        return;

    }


    public static void Try_override( string _path_with_data, string _final_path ){

        Console.Log( "EH OVERWRITE!!! mudar nome depois" );

        string temp = File_run_time_saving_operations.Get_run_time_path_TEMP( _final_path ); 

        File.Move( _path_with_data, temp );
        Files.Try_delete( _final_path );
        File.Move( temp, _final_path );
        return;

    }



    public static void Save_critical_file( string _path, string[] _array ){

        
        string combined_text = string.Join( Environment.NewLine , _array );
        byte[] data = System.Text.Encoding.UTF8.GetBytes( combined_text );

        FileMode file_mode = FileMode.Create;
        FileAccess file_accees = FileAccess.ReadWrite;
        FileShare file_share = FileShare.None;
        FileOptions file_options = FileOptions.WriteThrough;

        FileStream stream = new FileStream( _path, file_mode, file_accees , file_share, data.Length , file_options );
        

        stream.Write( data );
            stream.Flush( true );
        stream.Close();

        return;

    }


    public static void Save_critical_file( string _path, string combined_text ){

        byte[] data = System.Text.Encoding.UTF8.GetBytes( combined_text );

        FileMode file_mode = FileMode.Create;
        FileAccess file_accees = FileAccess.ReadWrite;
        FileShare file_share = FileShare.None;
        FileOptions file_options = FileOptions.WriteThrough;

        FileStream stream = new FileStream( _path, file_mode, file_accees , file_share, data.Length , file_options );
        

        stream.Write( data );
            stream.Flush( true );
        stream.Close();

        return;

    }





    public static void Save_critical_file( string _path, byte[] _array ){

        
        FileMode file_mode = FileMode.Create;
        FileAccess file_accees = FileAccess.ReadWrite;
        FileShare file_share = FileShare.None;
        FileOptions file_options = FileOptions.WriteThrough;

        FileStream stream = new FileStream( _path, file_mode, file_accees , file_share, _array.Length , file_options );

        stream.Write( _array );
            stream.Flush( true );
        stream.Close();

        return;

    }


    public static void Save_critical_file( string _path, void* _pointer_data, int _length ){

        
        FileMode file_mode = FileMode.Create;
        FileAccess file_accees = FileAccess.ReadWrite;
        FileShare file_share = FileShare.None;
        FileOptions file_options = FileOptions.WriteThrough;


            UnmanagedMemoryStream stream = new UnmanagedMemoryStream( (byte*)_pointer_data, _length );
            FileStream file = new FileStream( _path, file_mode, file_accees , file_share, _length , file_options );

            stream.CopyTo( file );
            file.Flush( true );

            stream.Close();
            file.Close();

        return;

    }

    public static void Save_critical_file( string _path, Data_file_link _data ){

        Heap_key key = _data.Get_heap_key();
        Save_critical_file( _path, key.Get_pointer(), key.Get_length() );

    }















    public static void Save_file( string _path, void* _pointer_data, int _length ){

        byte[] data = new byte[ _length ];

        fixed( byte* pointer_data = data )
            { System.Buffer.MemoryCopy( ( void* ) _pointer_data, ( void* ) pointer_data, long.MaxValue, ( long ) ( _length ) ); }
            
        System.IO.File.WriteAllBytes( _path, data );


    }






    public static void Flush( string _path ){

        FileStream str = FILE_STREAM.Criar_stream( _path: _path, _tamanho_buffer: 0 );

        str.Flush();
        str.Close();

    }



    // pastas só são criadas no save 
    // testei e já funciona corretamente
    // talvez possar ter o argumento para ver se pode ser com cache ou nao
    public static void Copiar_pasta_inteira(  string _local_para_salvar,  string _local_para_copiar ){

                            
        // Sempre assume que o folder nao foi criado
        System.IO.Directory.CreateDirectory( _local_para_salvar );

        // vem como path completo
        string[] folders = System.IO.Directory.GetDirectories( _local_para_copiar );

        for( int folder_id = 0 ; folder_id < folders.Length ; folder_id++ ){
                                                                //   ta certo, vai pegar somente o nome do diretory
            string folder_path_para_salvar = _local_para_salvar + "/" + System.IO.Path.GetFileName( folders[ folder_id ] );
            string folder_path_para_copiar = folders[ folder_id ] ;
            Copiar_pasta_inteira( folder_path_para_salvar , folder_path_para_copiar );

        }
        // vem com o path completo
        string[] nomes_arquivos = System.IO.Directory.GetFiles( _local_para_copiar );

        for( int arquivo_id = 0 ; arquivo_id < nomes_arquivos.Length ; arquivo_id++ ){

            
            string path_arquivo_para_salvar = _local_para_salvar + "/" + System.IO.Path.GetFileName( nomes_arquivos[ arquivo_id ] );
            string path_arquivo_para_copiar =  nomes_arquivos[ arquivo_id ];
            System.IO.File.Copy(  path_arquivo_para_copiar,  path_arquivo_para_salvar  );

        }

        return;

    }

    public static void Guarantee_exists_editor( string _path ){

            #if UNITY_EDITOR

                if( !!!( System.IO.File.Exists( _path ) ) )
                    { throw new Exception( $"Nao tinha o arquivo { _path }" ); }

            #endif



    }

    public static void Guarantee_exists( string _path ){

        if( !!!( System.IO.File.Exists( _path ) ) )
            { throw new Exception( $"Nao tinha o arquivo <Color=lightBlue>{ _path }</Color>" ); }

    }


    public static void Change_files_extension_in_folder( string _folder_para_mudar_as_extensoes, string _nova_extensao ){

        throw new System.Exception( "ainda tem que testar" );

        if( System.IO.Directory.Exists( _folder_para_mudar_as_extensoes ) )
                { throw new Exception($"O folder { _folder_para_mudar_as_extensoes } nao foi achado"); }


        // --- DADOS
        string[] folders = System.IO.Directory.GetDirectories( _folder_para_mudar_as_extensoes );
        string[] arquivos = System.IO.Directory.GetFiles( _folder_para_mudar_as_extensoes );


        // --- MUDA CADA ARQUIVO
        for( int arquivo_id = 0 ; arquivo_id < arquivos.Length ; arquivo_id++ ){

                string path_arquivo_com_ext_antiga = arquivos[ arquivo_id ];
                string path_arquivo_com_nova_extensao = System.IO.Path.ChangeExtension(  path_arquivo_com_ext_antiga,  _nova_extensao  );

                if( path_arquivo_com_ext_antiga == path_arquivo_com_nova_extensao )
                    { continue; }
                
                System.IO.File.Move( path_arquivo_com_ext_antiga, path_arquivo_com_nova_extensao );

                continue;

        }


        // --- VAI EM CADA FOLDER E APLICA A FUNCAO DENOVO
        for( int folder_id = 0 ; folder_id < folders.Length ; folder_id++ ){

                //   ta certo, vai pegar somente o nome do diretory
                string folder_path_para_mudar_as_extensoes = folders[ folder_id ];
                Change_files_extension_in_folder( folder_path_para_mudar_as_extensoes , _nova_extensao );

        }

        
        return;

    }

}