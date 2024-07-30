using System;
using System.IO;
using System.Reflection;
using UnityEngine;



public class MODULO__desmembrador_de_arquivo {

        
        public MODULO__desmembrador_de_arquivo( string _gerenciador_nome, string _path_arquivo, int _numero_inicial_de_slots  ){ 


                gerenciador_nome = _gerenciador_nome;
                path_arquivo = _path_arquivo;

                localizadores_ids = new int[ _numero_inicial_de_slots ];
                pontos_iniciais = new int[ _numero_inicial_de_slots ];
                lengths = new int[ _numero_inicial_de_slots ];
                
                dados = new byte[ _numero_inicial_de_slots ][];
                
                return;

        }

        public string gerenciador_nome;
        public string path_arquivo;

        public int[] localizadores_ids;

        public int[] pontos_iniciais;
        public int[] lengths;

        public byte[][] dados;
        
            

        public void Excluir_dados(){


                localizadores_ids = new int[ 5 ];
                
                pontos_iniciais = new int[ 5 ];
                lengths = new int[ 5 ];

                dados = new byte[ 5 ][];
                return;

        }




        public byte[] Pegar_dados_por_localizador ( int _localizador_id ){

                // sempre tem que carregar primeiro. Em teste carrega primeiro para colocar o path e logo em sequencia já pega 


                // --- GARANTE QUE TEM
                int slot_index = INT.Pegar_index_valor( localizadores_ids, _localizador_id );

                if( slot_index == -1 )
                        { throw new Exception( $"Tentou pegar no gerenciador { gerenciador_nome } pelo id_localizador { _localizador_id } mas nao foi encontrado" ); }

                return dados[ slot_index ];

        }


        public byte[][] Pegar_multiplos_dados( int[] _localizadores_ids, int[] _pontos_iniciais, int[] _lengths ){

                byte[][] retorno = new byte[ _localizadores_ids.Length ][];

                for( int localizador_index = 0 ; localizador_index < _localizadores_ids.Length  ; localizador_index++  ){

                        int localizador_id = _localizadores_ids[ localizador_index ];
                        int length = _lengths[ localizador_index ];
                        int ponto_inicial = _pontos_iniciais[ localizador_index ];

                        retorno[ localizador_index ] = Pegar_dados( localizador_id, ponto_inicial, length );
                        continue;

                    
                }

                return retorno;

        }


        public byte[] Pegar_dados ( int _localizador_id, int _ponto_inicial, int _length ){

                // sempre tem que carregar primeiro. Em teste carrega primeiro para colocar o path e logo em sequencia já pega 


                // --- GARANTE QUE TEM
                int slot_index = INT.Pegar_index_valor( localizadores_ids, _localizador_id );

                if( slot_index != -1 )
                        { return dados[ slot_index ]; }
                
                slot_index = INT.Pegar_index_valor( localizadores_ids, 0 );
                if( slot_index != -1 )
                        { slot_index = Extender_slots(); }

                
                int length_dados = lengths[ slot_index ];


                FileMode file_mode = FileMode.Open;
                FileAccess file_accees = FileAccess.Read;
                FileShare file_share = FileShare.Read;
                FileOptions file_options = FileOptions.None; // talvez nao?


                FileStream file_stream = new FileStream( path_arquivo, file_mode, file_accees , file_share, _length , file_options );


                file_stream.Seek(  _ponto_inicial,  SeekOrigin.Begin );


                byte[] buffer  = new byte[ _length ];
                file_stream.Read( buffer, 0, _length );
                file_stream.Close();

                dados[ slot_index ] = buffer;
                lengths[ slot_index ] = _length;

                return buffer;

                

        }


        // --- retorna novo_primeiro slot
        public int Extender_slots(){

                localizadores_ids = INT.Aumentar_length_array( localizadores_ids, 5 );
                dados = BYTE.Aumentar_length_array_2d( dados, 5 );

                pontos_iniciais = INT.Aumentar_length_array( pontos_iniciais, 5 );
                lengths = INT.Aumentar_length_array( lengths, 5 );

                return ( localizadores_ids.Length - 5 );                

        }



}