using System;
using UnityEngine;

public class Construtor_interativos {

        

        public Construtor_interativos( Controlador_interativos _controlador ){

            controlador_interativos = _controlador;

        }


        public Controlador_interativos controlador_interativos;

        // sempre vai ter todos os dados
        public byte[] localizador_dados_interativos;
        public byte[][] containers_dados_interativos;



        //** faz depois
        public Interativo_personagem[] Criar_interativos_tipo_personagem( int[] _lista_ids ){ throw new Exception( "tem que fazer" ); }
        public Interativo_item[] Criar_interativos_tipo_item( int[] _lista_ids ){ throw new Exception( "tem que fazer" ); }


        // ** nao vai criar as imagens
        public Interativo_tela[] Criar_interativo_tipo_tela( int[] _lista_ids ){


                
        
                return null;

        }

}