using UnityEngine;
using System;



    public class Stats_objeto{


     


        public Tipo_objeto tipo;
        public int id;

        public string id_unico = "";


        public bool is_inativo = false;
        public bool is_destruido = false;

        public bool tem_update = true;

        
        public bool tem_efeito_contato = false;

    
          
        public Action<Fisica_objeto, Stats_objeto> efeito_contato;
        




        public int jumps_possiveis = 0;
        public int jumps_possiveis_atuais = 0;
        public float jump_altura = 10f;



        public float movimentation_speed = 10f;



        public float vida = 100f;
        public float armadura;
        public float mana = 100;


        public float regeneracao_vida;
        public float regeneracao_mana;



        public float estamina;
        public float adrenalina;

        public float perda_estamina;
        public float perda_adrenalina;

        public Action<Stats_objeto> bonus_adrenalina;
        public Action<Stats_objeto> bonus_estamina;

           public Stats_objeto(int _id = -1 , Tipo_objeto _tipo = Tipo_objeto.NENHUM ){

            tipo = _tipo;
            id = _id;

        }


        public void Update(){


            
            if(vida <= 0f ){

                BLOCO_plataforma.Pegar_instancia().Destruir_objeto(this.id, this.tipo);

            }

            return;


        }



}




