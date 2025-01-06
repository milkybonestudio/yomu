


//mark
// ** passar active -> full
public enum Resource_state {

    nothing, // nada
        going_to_minimun,
    minimun, // data 
        going_to_active,
    active, // text + data


    // ** olhando agora instanciate não faz sentido nenhum para os recursos normais. poderia ser simplesmente ( ( resource.state == active ) && ( actual_resource == R.max ) )
    // ** structure
    instanciated,

}


