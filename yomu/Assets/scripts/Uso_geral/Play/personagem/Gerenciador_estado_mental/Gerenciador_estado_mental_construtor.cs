using System;



public static class Gerenciador_estado_mental_construtor {

        public static Gerenciador_estado_mental Construir( Personagem personagem, byte[] _dados ){

                Gerenciador_estado_mental gerenciador = new Gerenciador_estado_mental( personagem );

                return  gerenciador;

        }

}
