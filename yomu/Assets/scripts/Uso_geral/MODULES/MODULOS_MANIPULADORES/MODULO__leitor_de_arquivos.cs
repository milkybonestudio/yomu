using System;
using System.IO;
using System.Reflection;
using UnityEngine;



public class MODULO__leitor_de_arquivos {

        
        public MODULO__leitor_de_arquivos( string _gerenciador_nome, string _path_folder ){ 

                

                gerenciador_nome = _gerenciador_nome;
                path_folder = _path_folder;
                return;

        }

        public string gerenciador_nome;

        public string path_folder;


        public byte[][] Pegar_multiplos_dados( string[] _nomes_arquivos ){

                byte[][] retorno = new byte[ _nomes_arquivos.Length ][];

                for( int nome_index = 0 ; nome_index < _nomes_arquivos.Length  ; nome_index++  ){
                        
                        string nome = _nomes_arquivos[ nome_index ];
                        retorno[ nome_index ] = Pegar_dados( nome );
                        continue;

                }

                return retorno;

        }


        public byte[] Pegar_dados ( string _nome_arquivo ){


                string path_arquivo = System.IO.Path.Combine( path_folder, _nome_arquivo );

                Files.Guarantee_exists_editor( path_arquivo );
                
                byte[] dados = System.IO.File.ReadAllBytes( path_arquivo );

                return dados;
                

        }






}