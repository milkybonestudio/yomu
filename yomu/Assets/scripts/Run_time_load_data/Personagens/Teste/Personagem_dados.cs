using System;


public enum Update {

    catedral

}

public class Personagem_dados {

    public System.Action[][] updates = new System.Action[ 5 ][];

    public void Pegar_dados( Character personagem ){

        // Update update = Update.catedral;


        // personagem.updates = Pegar_updates( update );

    }


        public Action[] Pegar_updates( Update update ){


            int index = ( int ) update;


            switch( update ) {

                case Update.catedral: if( updates[ index ] == null ){ updates[ index ] = new Lily_update_catedral().Pegar_updates(); } return updates[ index ]; 

            }

            return null;

        }



}


public class Lily_update_catedral {

    public System.Action[] Pegar_updates(){

        return new System.Action[]{ null, null, null, null, null };

    }





}