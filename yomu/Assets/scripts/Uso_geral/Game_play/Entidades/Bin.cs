

unsafe public class Bin {


        // ** se os dados vao continuar na ram não vai fazer sentido virtualmente excluir os dados só por capricho
        // ** se tiver problemas de ter muitos dados vale mais a pena esperar alguns ms quando for trocar o periodo e salvar tudo que der. 
        // ** o sistema consegue salvar +- 2k de arquivos por segundo,m eu acho que nunca vai dar problema

        public Bin( int _number_slots ){

            files_to_save = new File_to_save[ _number_slots ];

        }

        
        public bool Have_files(){

            return pointer > 0;

        }


        
        public File_to_save[] files_to_save;
        public int pointer;

        public float Add_file( File_to_save _file ){

                if( pointer == files_to_save.Length )
                    { System.Array.Resize( ref files_to_save, ( files_to_save.Length + 5 ) ); }

                files_to_save[ pointer ] = _file;
                pointer++;

                return 0.2f + ( ( _file.length ) * 25_000f );

        }


        public float Add_files( File_to_save[] _files ){


                if( pointer >= ( files_to_save.Length - _files.Length ) )
                    { System.Array.Resize( ref files_to_save, ( files_to_save.Length + 5 + _files.Length ) ); }

                float tempo = 0f;

                for( int file_index = 0 ; file_index < _files.Length ; file_index++ ){

                    File_to_save file = _files[ file_index ];
                    files_to_save[ pointer ] = file;
                    pointer++;

                    tempo += 0.2f + ( ( file.length ) * 25_000f );

                }

                return tempo;

        }

        public void Clean(){ 

                pointer = 0; 
                return;

        }


}