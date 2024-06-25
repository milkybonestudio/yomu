using System;
using System.Reflection;

public class Gerenciador_interativos {

    	
        public byte[] interativos_comprimidos; // todas as cidades
        public int cidade_atual_id = 0;

        public Interativo Pegar_interativo(  int _regiao, int _area,  int _interativo_id ){


            #if UNITY_EDITOR

                return Leitor_interativos_TESTE.Pegar( cidade_atual_id, _regiao,  _area,  _interativo_id );

            #endif

            return null;
        
        }

        public void Mudar_cidade( Cidade_nome _nome ){

            return;

        }




}