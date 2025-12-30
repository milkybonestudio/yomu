

unsafe public class Generic_in_game_test : In_game_test {

    // ** TESTES QUE NAO PRECISAM SER GUARDADOS

    // ** seta o programa login, menu, game
    public override void Set_program_environment(){

            Controllers.program_transition.Switch_program_mode( Editor_run.program_mode, new Transition_program_data() ); 

    }

    // ** com o programa setado vai mudar os dados e forçar algo
    public override void Create_state(){}

    // ** called everyframe
    public override void Update(){}





}
