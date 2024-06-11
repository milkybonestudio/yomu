using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Controlador_personagens_{


    public static Controlador_personagens_ instancia; 
    public static Controlador_personagens_ Pegar_instancia( bool _forcar = false  ){if( instancia == null || _forcar ){ instancia = new Controlador_personagens_(); instancia.Iniciar();} return instancia;}

    public void Iniciar(){}

   
//     public Personagens personagens ;

//      public int[] personagens_apresentados = new int[50];

  

//     public void Iniciar(){

        

//          personagens = new Personagens();

         
 
//     }



//     public void Zerar_dados(){


//                personagens = new Personagens();
//                return;
               
 
//     }





//     public System.Object  Pegar_personagem(int _personagem_id){
           
//          switch(_personagem_id){
           
//            case 0: return personagens.lily;


//          }


//          throw new ArgumentException("a");
//     }











}