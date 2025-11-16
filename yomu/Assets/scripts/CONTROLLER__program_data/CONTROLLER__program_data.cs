


using System;
using System.IO;
using System.Runtime.InteropServices;

unsafe public class CONTROLLER__program_data {


        public IntPtr intPtr_brute_data;
        public Program_data* brute_data_pointer;
        
        
        public CONTROLLER__program_data__MODES modes;
        public CONTROLLER__program_data__SAVES saves;


        public FileStream program_brute_stream;


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


