


using System.Runtime.InteropServices;

public unsafe class CONTROLLER__program_data_BUILD : CONTROLLER__program_data {

        // ** mobile nao deu problema
        // ** talvez html de 

        public override void Get_data(){

            //performance
            // ** por hora vai primeiro carregar como byte[] e depois vai passar para o espaço correto
            // ** aparentemente tem como usar MemoryMappedFile para passar direto para o pointer


            // --- CREATE CONTAINERs
            intPtr_data = Marshal.AllocHGlobal( sizeof( Program_data ) );
            pointer = ( Program_data* ) intPtr_data.ToPointer();
            
            if( System.IO.File.Exists( Paths_system.path_file__program_data ) )
                { Create_new(); }
                else
                { Get_file(); }
                    
            return;
        }


        private void Get_file(){

            byte[] program_data_disc = System.IO.File.ReadAllBytes( Paths_system.path_file__program_data );

                                        // ** PASSADO POR VALUE
            Pointers_data_transfer.Transfer( ( byte* ) pointer, program_data_disc, program_data_disc.Length );

        }

        private void Create_new(){

            CONTROLLER__errors.Throw( "tem que ver depois, nao foi testado" );

            byte[] data = new byte[ sizeof( Program_data ) ];

            Program_data.Construct( pointer );
            Pointers_data_transfer.Transfer( data, ( byte* ) pointer , data.Length );

            System.IO.File.WriteAllBytes( Paths_system.path_file__program_data, data );

            return;

        }


}