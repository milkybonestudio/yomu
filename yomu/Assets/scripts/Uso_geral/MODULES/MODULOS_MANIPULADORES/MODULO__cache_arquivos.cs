using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public struct Cache_key {

    public int slot;
    public int senha;

}

public struct Cache_data {

    public int key;
    public byte[] data;

}

public class MODULO__cache_arquivos {

        
        public MODULO__cache_arquivos( string _gerenciador_nome, int _numero_inicial_de_slots  ){ 


                gerenciador_nome = _gerenciador_nome;
                dic.EnsureCapacity( _numero_inicial_de_slots );
                
                return;

        }

        public string gerenciador_nome;

        public int senha_atual;
        public int slot_atual;

        
        public Dictionary<int,Cache_data> dic = new Dictionary<int, Cache_data>() ;

        public void Excluir_dados(){

                dic.Clear();
                return;

        }

        public void Delete_data( Chave_cache _chave ){

            if( !!!( dic.ContainsKey( _chave.slot ) ) )
                { throw new Exception( $"nao tinha o slot { _chave.slot }" ); }

            // --- TEM DADOS
            Cache_data data = dic[ _chave.slot ];

            if( data.key != _chave.senha )
                { throw new Exception( "tentou pegar um slot mas estava com a senha errada" ); }

            dic.Remove( _chave.slot );

            return ;
                

        }

        public byte[] Get_data( Chave_cache _chave ){

            if( !!!( dic.ContainsKey( _chave.slot ) ) )
                { throw new Exception( $"nao tinha o slot { _chave.slot }" ); }

            // --- TEM DADOS
            Cache_data data = dic[ _chave.slot ];

            if( data.key != _chave.senha )
                { throw new Exception( "tentou pegar um slot mas estava com a senha errada" ); }

            return data.data;
                

        }



        public Cache_key Add_file( int _localizador, byte[] _dados ){

                Cache_key retorno = new Cache_key();
                retorno.senha = senha_atual ;
                retorno.slot = slot_atual ;

                Cache_data data = new Cache_data();
                data.key = senha_atual;
                data.data = _dados;
                dic.Add( slot_atual, data );

                senha_atual++;
                slot_atual++;

                return retorno ;  
            
        }


}