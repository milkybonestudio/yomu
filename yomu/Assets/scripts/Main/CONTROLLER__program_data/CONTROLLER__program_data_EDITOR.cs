



using System.Runtime.InteropServices;

public unsafe class CONTROLLER__program_data_EDITOR : CONTROLLER__program_data {


        // ** no editor 99.9% das vezes vai ser usado em algum teste
        // ** o unico cenario que vale a pena salvar é quando tiver testes que precisem salvar em disco

        public override void Get_data(){

            intPtr_data = Marshal.AllocHGlobal( sizeof( Program_data ) );
            pointer = ( Program_data* ) intPtr_data.ToPointer();
            *pointer = default;
            Program_data.Construct( pointer );

        }


}
