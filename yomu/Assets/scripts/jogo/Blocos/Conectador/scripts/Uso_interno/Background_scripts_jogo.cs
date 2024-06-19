using UnityEngine;
using System;



public static class Background_scripts_jogo {



    public static string Pegar_nome(  Ponto_nome _ponto_nome){




        switch(  _ponto_nome  ){

            //case Ponto_nome.nome:  return Pegar_espelho_sara_room();

            //default: throw new ArgumentException("naoo foi achado _nome_ponto em Pegar_nome_background_por_script");
            default: throw new ArgumentException("nao usar por hora");

        }

    }


    public static string Pegar_espelho_sara_room(){

        float sadismo = Player_estado_atual.Pegar_instancia().sadismo;

        int  periodo =   Controlador_timer.Pegar_instancia().periodo_atual_id;

        string dia_ou_noite = "_d";

        if(periodo > 3 ) dia_ou_noite = "_n";

        int nivel_sadismo =   (int) (sadismo / 100f);

        return  "m" +  Convert.ToString(nivel_sadismo) + dia_ou_noite;


    }




}