using System;



public class GERENCIADOR__save_dados_sistema {

        
        public Buffer buffer =  new Buffer( 10_000 );

        public byte[] buffer_interno = new byte[ 2_000 ] ;
        public int pointer_buffer_interno;




        // ** pensar depois 
        public void Colocar_instrucoes_de_seguranca_dados_sistema (  int _coisa_id ,  byte[] _dados_seguranca  ){


                buffer_interno[ ( pointer_buffer_interno + 0 ) ] = ( byte )( _coisa_id >> 8 );
                pointer_buffer_interno++;
                buffer_interno[ ( pointer_buffer_interno + 1 ) ] = ( byte )( _coisa_id >> 0 );
                pointer_buffer_interno++;

                BYTE.Copiar_elementos_de_array( buffer_interno, pointer_buffer_interno, _dados_seguranca, _dados_seguranca.Length );
                pointer_buffer_interno += _dados_seguranca.Length;

                buffer.Add_data( buffer_interno, pointer_buffer_interno );
                return;
        }




        // ** quando for salvar em disco
        public File_to_save Pegar_dados_sistema_para_salvar( Modo_save _modo ){

                // ** isso nao faz sentido nenhum 
                // ** isso teria que voltar um byte* da struct e a length
                File_to_save dados = new File_to_save();
                dados.path = Paths_system.path_file__complete_use__system_data;
                dados.dados = buffer.data;
                dados.length = buffer.pointer;

                return dados;
        }

        public Instrucoes_de_seguranca Pegar_instrucoes_de_seguranca(){ 

                Instrucoes_de_seguranca intrucoes = new Instrucoes_de_seguranca();

                intrucoes.instrucoes = buffer.data;
                intrucoes.pointer = buffer.pointer;

                return intrucoes;

        }


}

