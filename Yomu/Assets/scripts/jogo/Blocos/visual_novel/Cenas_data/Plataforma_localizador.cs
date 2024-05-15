
using System;

public enum Nome_plataforma_visual_novel{

    dia_introducao_lutando_albuinos,

}


public static class Plataforma_localizador{


    public  static Plataforma_START Pegar_dados( Nome_plataforma_visual_novel _nome ){


        switch ( _nome ){

            case Nome_plataforma_visual_novel.dia_introducao_lutando_albuinos: return PEGAR_dia_introducao_lutando_albuinos();
            default: throw new ArgumentException("naoa chou ");


        }

        

    }


    public static  Plataforma_START PEGAR_dia_introducao_lutando_albuinos(){


        
        Plataforma_START plataforma_data_START = new Plataforma_START();

        plataforma_data_START.fase_to_load = "/catedral/floresta_01";
        plataforma_data_START.personagens_to_load = new string[] {  "dia" , "", ""    };
        plataforma_data_START.objetivo_fase = "matar_todos_os_mobs";



        return plataforma_data_START;




    }




}