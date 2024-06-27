using System;
using UnityEngine;

public class Construtor_interativos {

        public Construtor_interativos( Controlador_interativos _controlador ){

            controlador_interativos = _controlador;

        }


        public Controlador_interativos controlador_interativos;


        //** faz depois
        public Interativo_personagem[] Criar_interativos_tipo_personagem( int[] _lista_ids ){ throw new Exception( "tem que fazer" ); }
        public Interativo_item[] Criar_interativos_tipo_item( int[] _lista_ids ){ throw new Exception( "tem que fazer" ); }


        public Interativo_tela[] Criar_interativos_tipo_tela( int[] _lista_ids ){

                return null;

                // logica + imagens 


                // --- CHECKS DE SEGURANCA

                // if( _lista_ids == null )
                //     { throw new Exception( "lista ids veio null" ); }



                // int numero_interativos_tipo_tela = _lista_ids.Length;
                // int periodo =   Controlador_timer.Pegar_instancia().periodo_atual_id ;



                // string path =  "images/in_game/" +  _ponto.folder_path;


                // Interativo_tela[] interativos_retorno = new Interativo_tela[ numero_interativos_tipo_tela ];

                
                // for( int i = 0; i < numero_interativos  ;i++){

                    
                //         string name  = "Interativo_" + Convert.ToString( interativos_nomes[ i ] );


                // }

        }

}