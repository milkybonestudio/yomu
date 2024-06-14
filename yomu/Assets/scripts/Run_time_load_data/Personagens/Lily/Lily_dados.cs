using UnityEngine;
using System;



public class Lily_dados {


        // Updates

        public Lily_construtor_update_run_time construtor_update_run_time = new Lily_construtor_update_run_time();
        public Lily_construtor_update_periodo construtor_update_periodo = new Lily_construtor_update_periodo();
        public Lily_construtor_update_dia construtor_update_dia = new Lily_construtor_update_dia();
        public Lily_construtor_update_semana construtor_update_semana = new Lily_construtor_update_semana();
        public Lily_construtor_update_mes construtor_update_mes = new Lily_construtor_update_mes();

        // run_time => opcional => move personagem 
        //                      => tenta encontrar personagens => busca em certos lugares 

        // periodo => principalmente movimento 


        // dia => mudancas de estado mental 
        //     => compras / troca de itens 

        // semana => thoughts 
        // mensal => thoughts 




        

        public void Pegar_dados(){

                // esse metodo vai ser responsavel por pegar todos os dados

                
                Personagem lily = Controlador_personagens.Pegar_instancia().Pegar_personagem( ( int ) Personagem_nome.Lily );

                // pensar depois : lily.dados_updates



                // ----- Updates

                  
                byte[] dados_para_iniciar = new byte[] { 0,0,0,0,0 };

                Lily_update_run_time update_run_time = ( Lily_update_run_time ) dados_para_iniciar[ ( int ) Index_updates.run_time ];
                lily.gerenciador_updates.Update_run_time = construtor_update_run_time.Pegar( update_run_time );

                
                Lily_update_periodo update_periodo = ( Lily_update_periodo ) dados_para_iniciar[ ( int ) Index_updates.periodo ];
                lily.gerenciador_updates.Update_periodo = construtor_update_periodo.Pegar( update_periodo );



                Lily_update_dia update_dia = ( Lily_update_dia ) dados_para_iniciar[ ( int ) Index_updates.periodo ];
                lily.gerenciador_updates.Update_dia = construtor_update_dia.Pegar( update_dia );


                Lily_update_semana update_semana = ( Lily_update_semana ) dados_para_iniciar[ ( int ) Index_updates.periodo ];
                lily.gerenciador_updates.Update_semana = construtor_update_semana.Pegar( update_semana );
                
                // mensal vai ser responsvel por personagens que nao estao em foco ou estao longe 

                Lily_update_mes update_mes = ( Lily_update_mes ) dados_para_iniciar[ ( int ) Index_updates.periodo ];
                lily.gerenciador_updates.Update_mes = construtor_update_mes.Pegar( update_mes );



                byte update = ( byte ) 0;
                
                
                return;

        }

}







