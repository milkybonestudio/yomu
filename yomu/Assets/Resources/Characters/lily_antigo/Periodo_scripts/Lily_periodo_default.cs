

public class Lily_periodo_DEFAULT {

    




    public void fn() {

                // aqui vai estar a logica em si
                Character lily = CONTROLLER__characters.Get_instance().Get( ( int ) Personagem_nome.Lily );
                Periodo_tempo periodo = ( Periodo_tempo ) Controlador_timer.Pegar_instancia().periodo_atual_id;
                Dia_semana semana = Controlador_timer.Pegar_instancia().dia_semana;

                Semana_periodo semana_periodo = ( Semana_periodo )   (  (( int ) semana + 1 )  *  ( int ) periodo  );

                


    
            switch( periodo ){

                case Periodo_tempo.manha:  Lidar_manha( lily )  ; break;
                case Periodo_tempo.dia:  Lidar_dia( lily )  ; break;
                case Periodo_tempo.tarde:  Lidar_tarde( lily )  ; break;
                case Periodo_tempo.noite:  Lidar_noite( lily )  ; break;
                case Periodo_tempo.madrugada:  Lidar_madrugada( lily )  ; break;

            }

            int dia_semana = 0;

            //Estado_mental estado_mental = lily.gerenciador_estado_mental.estado_mental;

            // switch( dia_semana ){

            //             case 0: {

            //                     switch( periodo ){

            //                             case Periodo_tempo.manha: {


            //                                     float vontade_de_regar_flores =    estado_mental.felicidade  / ( estado_mental.tristeza );

            //                                     if( vontade_de_regar_flores > 500f ){


            //                                             // regar_flores();


            //                                     }

            //                                     // code 

            //                                     // personagem.Move( nova_posicao ) 



            //                                     return;

            //                             };
            //                             case Periodo_tempo.dia:  Lidar_dia( lily )  ; break;
            //                             case Periodo_tempo.tarde:  Lidar_tarde( lily )  ; break;
            //                             case Periodo_tempo.noite:  Lidar_noite( lily )  ; break;
            //                             case Periodo_tempo.madrugada:  Lidar_madrugada( lily )  ; break;

            //                     }
                                
            //                     break;



            //             }
                        

            // }


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
