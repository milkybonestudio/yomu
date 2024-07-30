using System;
using System.IO;
using System.Reflection;
using UnityEngine;



public class MODULO__escritor_de_arquivos {

        // ** nao mantem nenhum dado

        
        public MODULO__escritor_de_arquivos( string _gerenciador_nome, string _path_arquivo, int _numero_inicial_de_slots  ){ 
                
                gerenciador_nome = _gerenciador_nome;
                return;

        }

        public string gerenciador_nome;


        public void Trocar_arquivo( string _path_arquivo, byte[] _dados ){

                string path_arquivo_temporario = System.IO.Path.Combine( _path_arquivo, ".temp" );

                //System.IO.File.Create(  path_temp , dados.Length, FileOptions.WriteThrough );
                System.IO.File.WriteAllBytes( path_arquivo_temporario , _dados  );

                FileMode file_mode = FileMode.Open;
                FileAccess file_accees = FileAccess.ReadWrite;
                FileShare file_share = FileShare.Read;
                FileOptions file_options = FileOptions.WriteThrough;

                FileStream str = new FileStream(  path_arquivo_temporario,  file_mode, file_accees , file_share, 0 , file_options );

                str.Flush();
                str.Close();


                // muda o nome do antigo
                System.IO.File.Move(  path_arquivo_temporario , _path_arquivo );


            
                return;   


        }

        public void Trocar_parte_de_arquivo(){
            // **fazer depois
        }

 

}