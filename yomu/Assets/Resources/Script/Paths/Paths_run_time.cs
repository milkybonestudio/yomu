

using System.IO;
using System.Runtime.CompilerServices;

public static class Paths_run_time {


    public static void Define_run_time_folder( string _path_to_run_time_folder ){

        run_time_path = _path_to_run_time_folder;


        saving_run_time_folder = Get_saving_run_time_folder();

            saving_files_folder = Get_saving_files_folder();
                saving_files_security_file = Get_saving_files_security_file();

            safety_stack_folder = Get_safety_stack_folder();
                stack_start_files = Get_stack_start_files();
                saving_link_file_to_path = Get_saving_link_file_to_path();
                
                safety_stack_file = Get_safety_stack_file(); 

                

        return;
        
    }

        
        public static string run_time_path;


        // ** SAVING RUN TIME


        
        public const string saving_run_time_folder_NAME = "saving_run_time";
        public static string saving_run_time_folder;
        public static string Get_saving_run_time_folder(){ return Combine( run_time_path, saving_run_time_folder_NAME ); }
        public static string Get_saving_run_time_folder( string _path ){ return Combine( _path, saving_run_time_folder_NAME ); }


            // ** STACK

            public const string safety_stack_folder_NAME = "safety_stack";
            public static string safety_stack_folder;
            public static string Get_safety_stack_folder(){ return Combine( saving_run_time_folder, safety_stack_folder_NAME ); }
            public static string Get_safety_stack_folder( string _path ){ return Combine( _path, safety_stack_folder_NAME ); }

            
                public const string safety_stack_file_NAME = "safety_stack_file.dat";
                public static string safety_stack_file;
                public static string Get_safety_stack_file(){ return Combine( safety_stack_folder, safety_stack_file_NAME ); }
                public static string Get_safety_stack_file( string _path ){ return Combine( _path, safety_stack_file_NAME ); }

                


                // => stack_start_files
                public const string stack_start_files_NAME = "stack_start_files.txt";
                public static string stack_start_files;
                public static string Get_stack_start_files(){ return Combine( safety_stack_folder, stack_start_files_NAME ); }
                public static string Get_stack_start_files( string _path ){ return Combine( _path, stack_start_files_NAME ); }



                // => saving_link_file_to_path
                // ** for when is saving, if it needs to recosntruct with the stack but the normal link files alredy have being changed
                public const string saving_link_file_to_path_NAME = "saving_link_file_to_path.txt";
                public static string saving_link_file_to_path;
                public static string Get_saving_link_file_to_path(){ return Combine( safety_stack_folder, saving_link_file_to_path_NAME ); }
                public static string Get_saving_link_file_to_path( string _path ){ return Combine( _path, saving_link_file_to_path_NAME ); }



            // ** SAVING FILES

            public const string saving_files_folder_NAME = "saving_files";
            public static string saving_files_folder;
            public static string Get_saving_files_folder(){ return Combine( saving_run_time_folder, saving_files_folder_NAME ); }
            public static string Get_saving_files_folder( string _path ){ return Combine( _path, saving_files_folder_NAME ); }

                /*
                    ordem: 
                        -> salvar lista com os paths para cada arquivo. Vao ser salvos como "1.dat" entao no arquivos seria "1.dat:path"
                        -> salvar todos os arquivos em disco
                        -> salvar SECURITY_FILE
                        -> começar mover os arquivos

                */

                public const string saving_files_security_file_NAME = "saving_files_security_file.txt";
                public static string saving_files_security_file;
                public static string Get_saving_files_security_file(){ return Combine( saving_files_folder, saving_files_security_file_NAME ); }
                public static string Get_saving_files_security_file( string _path ){ return Combine( _path, saving_files_security_file_NAME ); }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string Combine( string _str_1, string _str_2 ){

            if( _str_1 == null )
                { return null; }

            return Path.Combine( _str_1, _str_2 );

        }




}