using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Save{

        public int  periodo;
        public int  dia_semana ;

        public Player_estado_atual player_estado_atual = new Player_estado_atual();
        //public Perguntas_respostas perguntas_respostas = new Perguntas_respostas();
        public Lista_personagens_save personagens = new Lista_personagens_save();



        public Save( bool _have_save ){


                if(_have_save){ return ; }

                periodo = 0;
                dia_semana = 0;

                //   aqui vai ser carregado o default

                // personagens

                // lily
                personagens.lily.sara.stats_relacionamento.tesao = 150f; 
                personagens.lily.sara.stats_relacionamento.amizade = 500f; 
                personagens.lily.sara.stats_relacionamento.amor = 100f ;
                personagens.lily.sara.stats_relacionamento.odio = 20f;


                // eden
                personagens.eden.sara.stats_relacionamento.tesao = 50f; 
                personagens.eden.sara.stats_relacionamento.amizade = 50f; 
                personagens.eden.sara.stats_relacionamento.amor = 10f ;
                personagens.eden.sara.stats_relacionamento.odio = 10f;

                // jayden
                personagens.jayden.sara.stats_relacionamento.tesao = 10f; 
                personagens.jayden.sara.stats_relacionamento.amizade = 350f; 
                personagens.jayden.sara.stats_relacionamento.amor = 200f ;
                personagens.jayden.sara.stats_relacionamento.odio = 10f;



                // dia
                personagens.dia.sara.stats_relacionamento.tesao = 500f; 
                personagens.dia.sara.stats_relacionamento.amizade = 550f; 
                personagens.dia.sara.stats_relacionamento.amor = 100f ;
                personagens.dia.sara.stats_relacionamento.odio = 10f;



        }








}

