


using System;
using System.Runtime.InteropServices;

public abstract unsafe class CONTROLLER__program_data {


        
        public IntPtr intPtr_data;
        public Program_data* pointer;

        public abstract void Get_data();
        public void Destroy(){

            if( intPtr_data != IntPtr.Zero )
                { 
                    Marshal.FreeHGlobal( intPtr_data ); 
                    intPtr_data = IntPtr.Zero;
                }

        }


}


