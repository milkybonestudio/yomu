using System;



public class GERENCIADOR__save_dados_sistema : INTERFACE__coletor_dados_save {

        
        public byte[] buffer = new byte[ 10_000 ] ;
        public int pointer_buffer;

        // ** quando for salvar em disco
        public Dados_para_salvar Pegar_dados_sistema_para_salvar( Modo_save _modo ){

                Dados_para_salvar dados = new Dados_para_salvar();
                dados.path = Paths_sistema.path_arquivo__dados_dinamicos__uso_completo__dados_sistema;
                dados.dados = buffer;

                return dados;
        }


        // ** pensar depois 
        public void Colocar_instrucoes_de_seguranca_dados_sistema (  int _coisa_id ,  byte[] _dados_seguranca  ){


                buffer[ ( pointer_buffer + 0 ) ] = ( byte )( _coisa_id >> 8 );
                pointer_buffer++;
                buffer[ ( pointer_buffer + 1 ) ] = ( byte )( _coisa_id >> 0 );
                pointer_buffer++;
                BYTE.Copiar_elementos_de_array( buffer, pointer_buffer, _dados_seguranca, _dados_seguranca.Length );
                pointer_buffer += _dados_seguranca.Length;
                return;

        }


        public Instrucoes_de_seguranca Pegar_instrucoes_de_seguranca(){ 

                Instrucoes_de_seguranca intrucoes = new Instrucoes_de_seguranca();

                intrucoes.instrucoes = buffer;
                intrucoes.pointer = pointer_buffer;

                return intrucoes;

        }


}

