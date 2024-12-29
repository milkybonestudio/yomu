

public class  Run_time_DEFAULT {

    




    public void fn() {

            // aqui vai estar a logica em sim
            Character lily = CONTROLLER__characters.Get_instance().Get( ( int ) Personagem_nome.Lily );
            Periodo_tempo periodo = ( Periodo_tempo ) Controlador_timer.Pegar_instancia().periodo_atual_id;


            


            switch( periodo ){

                case Periodo_tempo.manha:  Lidar_manha( lily )  ; break;
                case Periodo_tempo.dia:  Lidar_dia( lily )  ; break;
                case Periodo_tempo.tarde:  Lidar_tarde( lily )  ; break;
                case Periodo_tempo.noite:  Lidar_noite( lily )  ; break;
                case Periodo_tempo.madrugada:  Lidar_madrugada( lily )  ; break;

            }


    }







    public void Lidar_manha( Character lily ){





    }

    public void Lidar_dia( Character lily ){

        

    }

    public void Lidar_tarde( Character lily ){

        

    }

    public void Lidar_noite( Character lily ){

        

    }

    public void Lidar_madrugada ( Character lily ){

        

    }


        
}
