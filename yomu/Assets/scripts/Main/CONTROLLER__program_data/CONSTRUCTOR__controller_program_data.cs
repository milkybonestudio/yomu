using System.Runtime.InteropServices;



unsafe public static class CONSTRUCTOR__controller_program_data {


        public static CONTROLLER__program_data Construct(){

                CONTROLLER__program_data ret = new CONTROLLER__program_data();




                    // --- CREATE CONTAINERs
                    ret.intPtr_brute_data = Marshal.AllocHGlobal( sizeof( Program_brute_data ) );
                    ret.brute_data_pointer = ( Program_brute_data* ) ret.intPtr_brute_data.ToPointer();

                    ret.Put_data();

                    byte[] program_brute_data = System.IO.File.ReadAllBytes( Paths_files.program_brute_data );

                    if( program_brute_data.Length != sizeof( Program_brute_data ) )
                        { CONTROLLER__errors.Throw( $"The <Color=lightBlue>program_brute_data file</Color> have <Color=lightBlue>{ program_brute_data.Length }</Color> bytes, but the <Color=lightBlue>Program_brute_data</Color> type have <Color=lightBlue>{ sizeof( Program_brute_data ) }</Color>" ); }

                    fixed( byte* pointer_data = program_brute_data ){

                        System.Buffer.MemoryCopy( ( void* ) pointer_data, ( void* ) ret.brute_data_pointer, long.MaxValue, ( long ) ( program_brute_data.Length ) );

                    }


                    ret.program_brute_stream = FILE_STREAM.Criar_stream( Paths_files.safety_data_stack, 50_000 );


                // --- DEFINE POINTERS
                Program_data.pointer = ret.program_data;
                    
                    ret.program_data->login.pointer = &( ret.program_data->login );
                    ret.program_data->menu.pointer = &( ret.program_data->menu );
                    ret.program_data->game.pointer = &( ret.program_data->game );

                    
                return ret;

        }


}