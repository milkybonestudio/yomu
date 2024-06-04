

public class  Run_time_DEFAULT {

    




    public void fn() {

            // aqui vai estar a logica em sim
            Personagem lily = Controlador_personagens.Pegar_instancia().Pegar_personagem( Personagem_nome.Lily );
            Periodo_tempo periodo = Controlador_timer.Pegar_instancia().periodo_atual;


            


            switch( periodo ){

                case Periodo_tempo.manha:  Lidar_manha( lily )  ; break;
                case Periodo_tempo.dia:  Lidar_dia( lily )  ; break;
                case Periodo_tempo.tarde:  Lidar_tarde( lily )  ; break;
                case Periodo_tempo.noite:  Lidar_noite( lily )  ; break;
                case Periodo_tempo.madrugada:  Lidar_madrugada( lily )  ; break;

            }


    }







    public void Lidar_manha( Personagem lily ){





    }

    public void Lidar_dia( Personagem lily ){

        

    }

    public void Lidar_tarde( Personagem lily ){

        

    }

    public void Lidar_noite( Personagem lily ){

        

    }

    public void Lidar_madrugada ( Personagem lily ){

        

    }


        
}
