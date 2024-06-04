using System;


public enum Update {

    continenteCentral_reinoHumano_santaMadalena_catedral

}

public class Personagem_dados {

    public System.Action[][] updates = new System.Action[ 5 ][];

    public void Pegar_dados( Personagem personagem ){

        Update update = Update.continenteCentral_reinoHumano_santaMadalena_catedral;


        personagem.updates = Pegar_updates( update );

    }


        public Action[] Pegar_updates( Update update ){


            int index = ( int ) update;

            switch( index ){

                case 0 : index++;break;
                case int.MaxValue : index++;break;

            }

            switch( update ) {

                case Update.continenteCentral_reinoHumano_santaMadalena_catedral: if( updates[ index ] == null ){ updates[ index ] = new Update_continenteCentral_reinoHumano_santaMadalena_catedral().Pegar_updates(); } return updates[ index ]; 

            }

            return null;

        }



}


public class Update_continenteCentral_reinoHumano_santaMadalena_catedral {

    public System.Action[] Pegar_updates(){

        return new System.Action[]{ null, null, null, null, null };

    }





}