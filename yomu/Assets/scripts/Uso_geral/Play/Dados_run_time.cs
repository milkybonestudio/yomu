using System;
using System.Reflection;
using UnityEngine;


public class Dados_run_time {


        /*

            usando Assembly.LoadFrom() ele nao carrega a dll inteira, somente a classe/ function em uso. 

        
        */


        public static Dados_run_time instancia;
        public static Dados_run_time Pegar_instancia(){ return instancia; }



        public Dados_run_time(){ 

                

                #if UNITY_EDITOR

                        // o editor consegue pegar eles normalmente

                        asm_world= Assembly.Load( "World_run_time" );
                        asm_personagens = Assembly.Load( "Personagens_run_time" );

                #endif

                #if !UNITY_EDITOR


                        asm_world= Assembly.LoadFrom( Application.dataPath + "/Run_time_dados/World_run_time.dll" );
                        asm_personagens = Assembly.LoadFrom( Application.dataPath + "/Run_time_dados/Personagens_run_time.dll" );

                #endif

            
        }


        public Assembly asm_personagens;
        public Assembly asm_world;



        public void Carregar_personagem( Personagem _personagem ){

                

                // sempre assume que ele nao foi carregado 
                if ( _personagem.dados_personagem_run_time != null ){
                        throw new Exception( "tentou carregar personagem 2 vezes" );
                }

                                                
                string personagem_metodo_nome =  _personagem.dados_sistema.nome_personagem.ToString() + "_dados";
                        
                System.Object personagem_objeto_generico =  asm_personagens.CreateInstance( personagem_metodo_nome );

                if( personagem_objeto_generico == null ){

                        Debug.LogError( $"nao foi achado persoangem { _personagem.dados_sistema.nome_personagem.ToString() } nos dados run time" );
                        throw new Exception();

                }

                _personagem.dados_personagem_run_time = personagem_objeto_generico;

                MethodInfo metodo_info = asm_personagens.GetType( personagem_metodo_nome ).GetMethod("Pegar_dados");

                // opcao 1 => entregar Personagem e o metodo coloca actions e delegados 
                // opcao 2 => o metodo devolve um objeto que tem os delegados e action
                
                metodo_info.Invoke(   personagem_objeto_generico , new System.Object[]{ _personagem }  );

                return;


        }


               




}