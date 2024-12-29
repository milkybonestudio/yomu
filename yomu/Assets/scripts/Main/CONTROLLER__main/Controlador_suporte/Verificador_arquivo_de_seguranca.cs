using System;
using UnityEngine;


public static class Verificador_arquivo_de_seguranca {


        public static byte[] Pegar_dados(){

                string path_folder_usuario = Application.persistentDataPath;
                string path_dado_de_seguranca = path_folder_usuario + "/dados_de_seguranca.dat";

                byte[] dados = System.IO.File.ReadAllBytes( path_dado_de_seguranca );

                return dados;

        }

        public static bool Programa_foi_encerrado_corretamente( byte[] _dados ){

                byte estado_em_jogo = 1;

                // false => sistea foi interrompido e precisa ser restaurado 
                return ( _dados[ 0 ] ==  estado_em_jogo );


        }

        public static int Pegar_save( byte[] _dados ){

            return  ( int ) _dados[ 1 ];

        }





}