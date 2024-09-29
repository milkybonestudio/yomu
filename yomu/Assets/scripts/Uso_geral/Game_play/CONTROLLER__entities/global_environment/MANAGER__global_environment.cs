using System;


public class MANAGER__global_environment {

        public MANAGER__global_environment(){}

        // ** SEMPRE CARREGADOS
        public Kingdom[] kingdoms; 
        public State[] estados_do_reino_atual;

        // ** carregados somente os necessarios, mas dificilmente sao modificados
        // ** como vão ter muitos vale a pena deixar com pointer
        public Plot[] plots;
        public int plot_pointer;

        public void Update(){}

}
