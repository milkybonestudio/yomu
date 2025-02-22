


using System;
using System.IO;
using System.Runtime.InteropServices;

public unsafe class CONTROLLER__program_data {


        public IntPtr intPtr_brute_data;
        public Program_brute_data* brute_data_pointer;
        
        //public IntPtr intPtr_data;
        public Program_data* program_data;
        public User_data* user_data;
        public Saves_data* saves_data;
        public Safety_files* safety_files_data;


        public FileStream program_brute_stream;



        public void Put_data(){

                program_data = &( brute_data_pointer->program );
                user_data = &( brute_data_pointer->user );
                saves_data = &( brute_data_pointer->saves_data );
                safety_files_data = &( brute_data_pointer->safety_files);

        }


        // ** sempre assume que os dados existem no path correto
        public void Destroy(){

            
            program_brute_stream?.Close();

            if( intPtr_brute_data != IntPtr.Zero )
                { 
                    Marshal.FreeHGlobal( intPtr_brute_data ); 
                    intPtr_brute_data = IntPtr.Zero;
                }

        }





}


