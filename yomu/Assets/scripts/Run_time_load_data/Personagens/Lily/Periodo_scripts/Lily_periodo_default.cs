

public class Lily_periodo_DEFAULT {

    




    public void fn() {

                // aqui vai estar a logica em si
                Personagem lily = Controlador_personagens.Pegar_instancia().Pegar_personagem( Personagem_nome.Lily );
                Periodo_tempo periodo = Controlador_timer.Pegar_instancia().periodo_atual;
                Dia_semana semana = Controlador_timer.Pegar_instancia().dia_semana;

                Semana_periodo semana_periodo = ( Semana_periodo )   (  (( int ) semana + 1 )  *  ( int ) periodo  );

                
                if ( lily.gerenciador_compromisso.Verificar_compromisso( semana_periodo ) ){
                        
                        // 
                        return;

                }
                        

                Compromisso dever = lily.deveres[ ( int ) semana_periodo ];

                if( dever != null ){

                        bool vai_no_evento = dever.verificar_ida( lily );

                        if( vai_no_evento ){

                                // se vai no evento precisa ter essa funcao 
                                dever.lidar_cumprir( lily );
                                dever.lidar_nao_cumprir( lily );
                                
                        }

                        // verificar se vai fazer o dever 



                }


                                        

            

            


            switch( periodo ){

                case Periodo_tempo.manha:  Lidar_manha( lily )  ; break;
                case Periodo_tempo.dia:  Lidar_dia( lily )  ; break;
                case Periodo_tempo.tarde:  Lidar_tarde( lily )  ; break;
                case Periodo_tempo.noite:  Lidar_noite( lily )  ; break;
                case Periodo_tempo.madrugada:  Lidar_madrugada( lily )  ; break;

            }

            int dia_semana = 0;

            switch( dia_semana ){

                    case 0: {

                            switch( periodo ){

                                    case Periodo_tempo.manha: {



                                        float vontade_de_regar_flores =    lily.estado_mental.felicidade  / ( lily.estado_mental.depressao );

                                        if( vontade_de_regar_flores > 500f ){

                                            // regar_flores();

                                        }

                                            // code 

                                            // personagem.Move( nova_posicao ) 



                                            return;

                                    };
                                    case Periodo_tempo.dia:  Lidar_dia( lily )  ; break;
                                    case Periodo_tempo.tarde:  Lidar_tarde( lily )  ; break;
                                    case Periodo_tempo.noite:  Lidar_noite( lily )  ; break;
                                    case Periodo_tempo.madrugada:  Lidar_madrugada( lily )  ; break;

                            }



                    }

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
