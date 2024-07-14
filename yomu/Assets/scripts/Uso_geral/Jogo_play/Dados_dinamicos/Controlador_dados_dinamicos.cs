using UnityEngine;
using System;



public class Controlador_dados_dinamicos {

        // ** garante que as classes que tem dados dinamicos possam funcionar 


        public static Controlador_dados_dinamicos instancia;
        public static Controlador_dados_dinamicos Pegar_instancia(){ return instancia; }


        public static Controlador_dados_dinamicos Construir( Dados_sistema_estado_atual _dados_sistema_estado_atual ){ 
                
                
                Controlador_dados_dinamicos controlador = new Controlador_dados_dinamicos(); 

                // --- SO VAO SER USADOS NA BUILD

                
                instancia = controlador; 

                return instancia;

                
        }


        public void Pegar_localizadores(){

                #if !UNITY_EDITOR


                        string path_folder_localizadores = Paths_sistema.path_folder_localizadores;
                        
                        // --- CARTAS
                        string path_cartas_localizador = System.IO.Path.Combine( path_folder_localizadores, "cartas_dados.dat" );
                        Leitor_cartas.localizador = System.IO.File.ReadAllBytes( path_cartas_localizador );

                        // --- ITENS
                        string path_itens_localizador = System.IO.Path.Combine( path_folder_localizadores, "itens_dados.dat" );
                        Leitor_itens.localizador = System.IO.File.ReadAllBytes( path_cartas_localizador );

                        // --- PONTOS
                        string path_pontos_localizador = System.IO.Path.Combine( path_folder_localizadores, "pontos_dados.dat" );
                        Leitor_pontos.localizador = System.IO.File.ReadAllBytes( path_cartas_localizador );

                        // --- INTERATIVOS
                        string path_interativos_tela_localizador = System.IO.Path.Combine( path_folder_localizadores, "interativos_tela_dados.dat" );
                        Leitor_interativos_tela.localizador = System.IO.File.ReadAllBytes( path_cartas_localizador );

                        // --- ITENS
                        string path_itens_localizador = System.IO.Path.Combine( path_folder_localizadores, "itens_dados.dat" );
                        Leitor_itens.localizador = System.IO.File.ReadAllBytes( path_cartas_localizador );

                        return;


                #endif


        }



}