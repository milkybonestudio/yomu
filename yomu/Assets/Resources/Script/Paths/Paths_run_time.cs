

using System.IO;
using System.Runtime.CompilerServices;

public static class Paths_run_time {


    public static void Define_run_time_folder( string _path_to_run_time_folder ){

        run_time_path = _path_to_run_time_folder;


        saving_run_time_folder = Get_saving_run_time_folder();

            saving_files_folder = Get_saving_files_folder();
                saving_files_security_file = Get_saving_files_security_file();

            safety_stack_folder = Get_safety_stack_folder();

                context_new = Get_context_new();
                context_old = Get_context_old();
                context_path = Get_context_path();

                data_link_current_files_TEMP = Get_data_link_current_files_TEMP();
                new_paths_ids = Get_new_paths_ids();
                
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

                


                // => tem que passar para program, o arquivo sempre vai reimportar os arquivos
                public const string data_link_current_files_TEMP_NAME = "data_link_current_files_TEMP.txt";
                public static string data_link_current_files_TEMP;
                public static string Get_data_link_current_files_TEMP(){ return Combine( safety_stack_folder, data_link_current_files_TEMP_NAME ); }
                public static string Get_data_link_current_files_TEMP( string _path ){ return Combine( _path, data_link_current_files_TEMP_NAME ); }



                // => new_paths_ids
                // ** for when is saving, if it needs to recosntruct with the stack but the normal link files alredy have being changed
                public const string new_paths_ids_NAME = "new_paths_ids.txt";
                public static string new_paths_ids;
                public static string Get_new_paths_ids(){ return Combine( safety_stack_folder, new_paths_ids_NAME ); }
                public static string Get_new_paths_ids( string _path ){ return Combine( _path, new_paths_ids_NAME ); }


                public const string context_new_NAME = "context_new.txt";
                public static string context_new;
                public static string Get_context_new(){ return Combine( safety_stack_folder, context_new_NAME ); }
                public static string Get_context_new( string _path ){ return Combine( _path, context_new_NAME ); }


                public const string context_old_NAME = "context_old.txt";
                public static string context_old;
                public static string Get_context_old(){ return Combine( safety_stack_folder, context_old_NAME ); }
                public static string Get_context_old( string _path ){ return Combine( _path, context_old_NAME ); }

                public const string context_path_NAME = "context_path.txt";
                public static string context_path;
                public static string Get_context_path(){ return Combine( safety_stack_folder, context_path_NAME ); }
                public static string Get_context_path( string _path ){ return Combine( _path, context_path_NAME ); }


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