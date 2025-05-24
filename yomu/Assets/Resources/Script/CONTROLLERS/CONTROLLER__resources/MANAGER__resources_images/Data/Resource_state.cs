


//mark
// ** passar active -> full

// ** instanciate nao deveria ser um estado
// ** se um recurso precisa verificar se ele já tem algo precisa usar Actual_content 
// ** como todos os recursos usam instanciate vai dar um certo trabalho para mudar 

// ** passar para resources_state?
public enum Resource_state {

    nothing, // nada
    minimum, // data 
    active, // text + data


    // ** olhando agora instanciate não faz sentido nenhum para os recursos normais. poderia ser simplesmente ( ( resource.state == active ) && ( actual_resource == R.max ) )
    // ** structure
    instanciated,

}

//mark
// ** depois trocar de todos
// ** nao ter o not_give parece ser um erro
public enum Content_level {

    not_give, 
    
    nothing, // nada
    minimum, // data 
    full, // text + data


    // ** olhando agora instanciate não faz sentido nenhum para os recursos normais. poderia ser simplesmente ( ( resource.state == active ) && ( actual_resource == R.max ) )
    // ** structure
    instanciated,

}



