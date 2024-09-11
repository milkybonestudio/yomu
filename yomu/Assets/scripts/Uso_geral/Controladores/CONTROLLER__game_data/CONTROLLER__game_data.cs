using System;


/*
    tem os dados que vão precisar ser usado em todos os blocos. 
    se algo estiver no main mas precisar ser ativado por um bloco ou no geral o main vai ter que criar 

*/


public class CONTROLLER__game_data {


        public static CONTROLLER__game_data instancia;
        public static CONTROLLER__game_data Pegar_instancia(){ return instancia; }

        // --- DADOS QUE VAO SER COLCOADOS QUANDO O JOGO INICIAR
        public INTERFACE__bloco[] blocos;

        public Game_current_state game_current_state;

        


}