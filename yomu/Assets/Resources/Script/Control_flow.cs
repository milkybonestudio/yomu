

public enum Control_flow_state {

    blocked, // tudo pausa

    locked, // algum bloco esta usando ele

    liberated, // ** pode dar lock

}

public class Control_flow {

    public Control_flow_state state;

    

}


