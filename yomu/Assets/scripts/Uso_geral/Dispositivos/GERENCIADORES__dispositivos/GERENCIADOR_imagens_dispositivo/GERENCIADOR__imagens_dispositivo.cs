using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;



public class GERENCIADOR__imagens_dispositivo {

    
        public Extensao_imagem extensao_imagem_atual;
        public MODULO__desmembrador_de_arquivo desmembrador_de_arquivo;
    
        public Material material_dispositivo;
        

        // --- DADOS
        public Sprite[] sprites;
        public byte[][] pngs;
        public int pointer = -1;


        public Dictionary<string,int> paths_dic;
            
        public string nome_dispositivo;    
        public string path_folder__imagens_DEVELOPMENT = ""; // ** aponta para o folder que tem as imagens 


        public GERENCIADOR__imagens_dispositivo (  Dispositivo _dispositivo ){ 


                nome_dispositivo = _dispositivo.nome_dispositivo;
                material_dispositivo = new Material( Shaders.normal );

                paths_dic = new Dictionary<string, int>();

                
                int numero_inicial_slots = 25;
                                
                sprites = new Sprite[  numero_inicial_slots ];
                pngs = new byte[  numero_inicial_slots ][];
            
                

                return;


        }


        // ** return the index of the image
        public int Declare_image( string _path ){

            int id; 
            if ( paths_dic.TryGetValue( _path, out id ) )
                { return id; }

            // --- novo
            paths_dic.Add( _path, pointer++ );
            return pointer;

        }


        public void Definir_material( Shader _shader_material ){

                if( _shader_material == null )
                    { throw new Exception( $"Tentou criar o material no modulo imagem { nome_dispositivo } mas o shader estava null" ); }
                    
                material_dispositivo = new Material( _shader_material );
                return;


        }


        public void Load_resources(){

            // ** criar 
            throw new Exception("tem que fazer");

            //mark 

            // ** RESOURCE__image



        }






}





