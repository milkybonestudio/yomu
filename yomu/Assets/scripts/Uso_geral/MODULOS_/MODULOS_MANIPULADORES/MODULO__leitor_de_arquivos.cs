using System;
using System.IO;
using System.Reflection;
using UnityEngine;



public class MODULO__leitor_de_arquivos {

        
        public MODULO__leitor_de_arquivos( string _gerenciador_nome, string _path_folder, int _numero_inicial_de_slots  ){ 


                gerenciador_nome = _gerenciador_nome;
                path_folder = _path_folder;

                localizadores_ids = new int[ _numero_inicial_de_slots ];
                nomes_arquivos = new string[ _numero_inicial_de_slots ];
                dados = new byte[ _numero_inicial_de_slots ][];
                
                return;

        }

        public string gerenciador_nome;

        public string path_folder;
        public int[] localizadores_ids;
        public string[] nomes_arquivos;
        public byte[][] dados;
        
            

        public void Excluir_dados(){

            localizadores_ids = new int[ 5 ];
            nomes_arquivos = new string[ 5 ];
            dados = new byte[ 5 ][];
            return;

        }




        public byte[] Pegar_dados_com_localizador ( int _localizador_id ){

                // sempre tem que carregar primeiro. Em teste carrega primeiro para colocar o path e logo em sequencia já pega 


                // --- GARANTE QUE TEM
                int slot_index = INT.Pegar_index_valor( localizadores_ids, _localizador_id );

                if( slot_index == -1 )
                        { throw new Exception( $"Tentou pegar no gerenciador { gerenciador_nome } pelo id_localizador { _localizador_id } mas nao foi encontrado" ); }

                return dados[ slot_index ];

        }


        public byte[][] Pegar_multiplos_dados( int[] _localizadores_ids, string[] _nomes_arquivos ){

                byte[][] retorno = new byte[ _localizadores_ids.Length ][];

                for( int localizador_index = 0 ; localizador_index < _localizadores_ids.Length  ; localizador_index++  ){

                        int localizador_id = _localizadores_ids[ localizador_index ];
                        string nome = _nomes_arquivos[ localizador_index ];

                        retorno[ localizador_index ] = Pegar_dados( localizador_id, nome );
                        continue;

                    
                }

                return retorno;

        }


        public byte[] Pegar_dados ( int _localizador_id, string _nome_arquivo ){

                // sempre tem que carregar primeiro. Em teste carrega primeiro para colocar o path e logo em sequencia já pega 


                // --- GARANTE QUE TEM
                int slot_index = INT.Pegar_index_valor( localizadores_ids, _localizador_id );

                if( slot_index != -1 )
                        { return dados[ slot_index ]; }
                
                slot_index = INT.Pegar_index_valor( localizadores_ids, 0 );
                if( slot_index != -1 )
                        { slot_index = Extender_slots(); }


                string path_arquivo = System.IO.Path.Combine( path_folder, _nome_arquivo );
                dados[ slot_index ] = System.IO.File.ReadAllBytes( path_arquivo );

                return dados[ slot_index ];
                

        }


        // --- retorna novo_primeiro slot
        public int Extender_slots(){

                nomes_arquivos = STRING.Aumentar_length_array( nomes_arquivos, 5 );
                dados = BYTE.Aumentar_length_array_2d( dados, 5 );
                localizadores_ids = INT.Aumentar_length_array( localizadores_ids, 5 );

                return ( localizadores_ids.Length - 5 );                

        }



}