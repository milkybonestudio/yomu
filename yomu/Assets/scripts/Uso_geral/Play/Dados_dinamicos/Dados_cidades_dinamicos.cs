using System;
using System.Reflection;
using UnityEngine;


public class Dados_personagens_dinamicos {


        /*

            usando Assembly.LoadFrom() ele nao carrega a dll inteira, somente a classe/ function em uso. 

        
        */



        


        public static Dados_personagens_dinamicos instancia;
        public static Dados_personagens_dinamicos Pegar_instancia(){ return instancia; }



        public Dados_personagens_dinamicos(){
    
                #if UNITY_EDITOR

                        // o editor consegue pegar eles normalmente
                        asm_cidades= Assembly.Load( "World_run_time" );

                #endif

                #if !UNITY_EDITOR


                        asm_cidades= Assembly.LoadFrom( Application.dataPath + "/Run_time_dados/World_run_time.dll" );
                        

                #endif



        }


        public Assembly asm_cidades;
        public int[] cidades_ids = new int[ 50 ];
        public Chave_cache[] chaves_cidades = new Chave_cache[ 50 ];
        public Task_req[] requisicoes_cidades = new Task_req[ 50 ];
        // public System.Object[] cidades = new System.Object[ 50 ];





}

                