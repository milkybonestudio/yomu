
using System.IO;
using System;
using System.Threading;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class CONTROLLER__saving {

    public static CONTROLLER__saving instancia;
    public static CONTROLLER__saving Pegar_instancia(){ return instancia; }
    


    public Saving_state state;
    
    public MANAGER__data_tracker data_tracker;
    



    public void Update( Control_flow _control_flow ){



    }


    public void Match_disc_to_real( File_to_save[] _dados_pedidos ){


        //Garantir_dados_para_salvar( _dados_pedidos ); // 0.2ms/file => 2ms 10 - files  => 10ms( 50 files )

        for( int pedido_index = 0 ; pedido_index < _dados_pedidos.Length ; pedido_index++ ){

            File_to_save dados_para_salvar = _dados_pedidos[ pedido_index ];

            string path = dados_para_salvar.path;
            byte[] dados = dados_para_salvar.dados;

            if( path == null )
                { continue; }

        
            string path_temp_arquivo_NOVO = ( path + ".temp" ) ;
            string path_temp_arquivo_ANTIGO = ( path + ".2.temp" );

            System.IO.File.WriteAllBytes( path_temp_arquivo_NOVO , dados  );

            Files.Flush( _path : path_temp_arquivo_NOVO );

            // muda o nome do antigo
            System.IO.File.Move(  path , path_temp_arquivo_ANTIGO );

            // coloca o nome correto 
            System.IO.File.Move(  path_temp_arquivo_NOVO, path  );

            // deleta o save
            System.IO.File.Delete( path_temp_arquivo_ANTIGO );

        }

        return;

    }

    public void Save(){



    }



}



