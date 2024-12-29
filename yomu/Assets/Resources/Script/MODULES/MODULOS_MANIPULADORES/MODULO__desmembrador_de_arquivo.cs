using System;
using System.IO;
using System.Reflection;
using UnityEngine;



public class MODULO__desmembrador_de_arquivo {

        
        public MODULO__desmembrador_de_arquivo( string _gerenciador_nome, string _path_arquivo, int _numero_inicial_de_slots  ){ 

                #if UNITY_EDITOR
                    if( !!!( System.IO.File.Exists( _path_arquivo ) ) )
                        { throw new Exception( $"nao achou o arquivo { _path_arquivo }" ); }
                #endif

                gerenciador_nome = _gerenciador_nome;
                path_arquivo = _path_arquivo;                
                return;

        }

        public string gerenciador_nome;
        public string path_arquivo;

    
        // ** tem que optimizar depois para tentar pegar mais em 1 lida
        public byte[][] Pegar_multiplos_dados(  int[] _pontos_iniciais, int[] _lengths ){

                byte[][] retorno = new byte[ _pontos_iniciais.Length ][];

                for( int localizador_index = 0 ; localizador_index < _pontos_iniciais.Length  ; localizador_index++  ){

                        int ponto_inicial = _pontos_iniciais[ localizador_index ];
                        int length = _lengths[ localizador_index ];
                    
                        retorno[ localizador_index ] = Pegar_dados( ponto_inicial, length );
                        continue;

                    
                }

                return retorno;

        }


        public byte[] Pegar_dados ( int _ponto_inicial, int _length ){

                // sempre tem que carregar primeiro. Em teste carrega primeiro para colocar o path e logo em sequencia já pega 
                

                FileMode file_mode = FileMode.Open;
                FileAccess file_accees = FileAccess.Read;
                FileShare file_share = FileShare.Read;
                FileOptions file_options = FileOptions.None; // talvez nao?

                FileStream file_stream = new FileStream( path_arquivo, file_mode, file_accees , file_share, _length , file_options );

                file_stream.Seek(  _ponto_inicial,  SeekOrigin.Begin );


                byte[] buffer  = new byte[ _length ];
                file_stream.Read( buffer, 0, _length );
                file_stream.Close();

                return buffer;

                

        }


}