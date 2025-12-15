

using System.IO;
using System.Runtime.CompilerServices;

public static class Paths_run_time {


    public static void Define_run_time_folder( string _path_to_run_time_folder ){

        run_time_path = _path_to_run_time_folder;

            saving_run_time_folder = Get_saving_run_time_folder();

                // ** created only when nsaving 
                saving_files_folder = Get_saving_files_folder();
                safety_stack_folder = Get_safety_stack_folder();

                    // NEED:
                    safety_stack_file = Get_safety_stack_file(); 

                    path_to_file_with_context_path = Get_path_to_file_with_context_path();


                    // LOGIC TO CHANGE 
                    context_new = Get_context_new();
                    new_paths_ids = Get_new_paths_ids();
                    
                    // STAGES
                    logic_data_saved = Get_logic_data_saved();
                    data_files_saved_in_folder = Get_data_files_saved_in_folder();
                    data_files_actions_applied = Get_data_files_actions_applied();
                    saving_finished = Get_saving_finished();
                    

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


                // ** NEED
            
                public const string safety_stack_file_NAME = "safety_stack_file.dat";
                public static string safety_stack_file;
                public static string Get_safety_stack_file(){ return Combine( safety_stack_folder, safety_stack_file_NAME ); }
                public static string Get_safety_stack_file( string _path ){ return Combine( _path, safety_stack_file_NAME ); }

                public const string path_to_file_with_context_path_NAME = "path_to_file_with_context_path.txt";
                public static string path_to_file_with_context_path;
                public static string Get_path_to_file_with_context_path(){ return Combine( safety_stack_folder, path_to_file_with_context_path_NAME ); }
                public static string Get_path_to_file_with_context_path( string _path ){ return Combine( _path, path_to_file_with_context_path_NAME ); }

                


                // ** NEW LOGIC

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


                // ** SAVING STATE

                
                public const string logic_data_saved_NAME = "logic_data_saved.dat";
                public static string logic_data_saved;
                public static string Get_logic_data_saved(){ return Combine( safety_stack_folder, logic_data_saved_NAME ); }
                public static string Get_logic_data_saved( string _path ){ return Combine( _path, logic_data_saved_NAME ); }

                public const string data_files_saved_in_folder_NAME = "data_files_saved_in_folder.dat";
                public static string data_files_saved_in_folder;
                public static string Get_data_files_saved_in_folder(){ return Combine( safety_stack_folder, data_files_saved_in_folder_NAME ); }
                public static string Get_data_files_saved_in_folder( string _path ){ return Combine( _path, data_files_saved_in_folder_NAME ); }

                public const string data_files_actions_applied_NAME = "data_files_actions_applied.dat";
                public static string data_files_actions_applied;
                public static string Get_data_files_actions_applied(){ return Combine( safety_stack_folder, data_files_actions_applied_NAME ); }
                public static string Get_data_files_actions_applied( string _path ){ return Combine( _path, data_files_actions_applied_NAME ); }


                public const string saving_finished_NAME = "saving_finished.dat";
                public static string saving_finished;
                public static string Get_saving_finished(){ return Combine( safety_stack_folder, saving_finished_NAME ); }
                public static string Get_saving_finished( string _path ){ return Combine( _path, saving_finished_NAME ); }


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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string Combine( string _str_1, string _str_2 ){

            if( _str_1 == null )
                { return null; }

            return Path.Combine( _str_1, _str_2 );

        }




}