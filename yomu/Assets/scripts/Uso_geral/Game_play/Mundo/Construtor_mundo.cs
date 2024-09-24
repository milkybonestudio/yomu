

public static class Construtor_mundo {

        
        public static Mundo Construir( byte[] _dados ){

            // --- VAI SER INICIADO QUANDO O SAVE FOR INICIADO

            Mundo mundo = new Mundo();
            Mundo.instancia = mundo;

                

            return mundo;

        }

}