


//mark
// ** passar active -> full

// ** instanciate nao deveria ser um estado
// ** se um recurso precisa verificar se ele já tem algo precisa usar Actual_content 
// ** como todos os recursos usam instanciate vai dar um certo trabalho para mudar 

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


