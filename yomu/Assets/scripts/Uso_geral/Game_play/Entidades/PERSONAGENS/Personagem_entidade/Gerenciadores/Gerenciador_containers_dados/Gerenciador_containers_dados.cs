using System;
using UnityEngine;




public class Gerenciador_containers_dados_personagem {

        public Gerenciador_containers_dados_personagem( Character _personagem ){ personagem = _personagem; }
        public Character personagem;
        public byte[] dados;


        public byte[][] containers;


        public bool containers_alterados = false;

        public byte[] Compilar_dados(){ 

                // só vai ser chamado quando o personagem estiver pronto para ser salvo
                return null;

         }

        public byte[] Pegar_buffer( Container_dados_personagem _container ){    

                // vai ser usado para ver quais personagens precisam ser salvos 
                containers_alterados = true;    

                switch( _container ){

                    case Container_dados_personagem.dados_internos : return containers [ ( int ) Container_dados_personagem.dados_internos ]; 

                }

                return null;


        }
   

}

