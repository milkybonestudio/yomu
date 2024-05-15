using UnityEngine;
using System;









    public enum Itens_localizador{


        VAZIO = 0 ,

        albuin_meat = 1 ,
        
        albuin_skin =   2 ,
        albuin_bones =  3 ,
        albuin_eye =    4,
        female_albuin = 5 ,
        male_albuin =   6 ,

        
    }



    public class Item {


        public string icone_path;

        public string nome;

        public string descricao ;
        
        public Itens_localizador localizador;


        
    }





public class Itens {



    /*
        fazer normal dps
         
    */

    public  Item[] lista = new Item[100];

    public  void Iniciar() {


        lista[0] = new Item();
        lista[0].icone_path = "";
        lista[0].nome = "VAZIO";
        lista[0].descricao = "";
        lista[0].localizador = Itens_localizador.VAZIO ;


        lista[1] = new Item();
        lista[1].icone_path = "";
        lista[1].nome = "albuin meat";
        lista[1].descricao = "meat of a albuin, don't smell good but maybe if I cook?";
        lista[1].localizador = Itens_localizador.albuin_meat;


        lista[2] = new Item();
        lista[2].icone_path = "";
        lista[2].nome = "albuin skin";
        lista[2].descricao = "skin of a albuin, I don't know why I would need this";
        lista[2].localizador = Itens_localizador.albuin_skin ;


        lista[3] = new Item();
        lista[3].icone_path = "";
        lista[3].nome = "albuin bones";
        lista[3].descricao = "bones of a albuin";
        lista[3].localizador = Itens_localizador.albuin_bones ;

        lista[4] = new Item();
        lista[4].icone_path = "";
        lista[4].nome = "albuin eye";
        lista[4].descricao = "eye of a albuin, this seems pretty expansive for some reason";
        lista[4].localizador = Itens_localizador.albuin_eye ;


        lista[5] = new Item();
        lista[5].icone_path = "";
        lista[5].nome = "female albuin";
        lista[5].descricao = "a live albuin famele, maybe I can tame it?";
        lista[5].localizador = Itens_localizador.female_albuin;

        
        lista[6] = new Item();
        lista[6].icone_path = "";
        lista[6].nome = "male albuin";
        lista[6].descricao = "a live albuin male, maybe I can tame it?";
        lista[6].localizador = Itens_localizador.male_albuin;



     }









}