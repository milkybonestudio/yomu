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


        }


        public Assembly asm_cidades;



}

                