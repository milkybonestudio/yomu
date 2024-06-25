

public enum Estado_nome : short {

    San_sebastian,

}

public enum Reino_nome : byte {

    Human

}

public enum Continente_nome : byte {

    central,

}

// talvez Ponto_nome nao faça sentido pois ponto depende de local que depende de regiao [ ... ] 
// posicao pode ter somente coisas genericas. 



// public struct Posicao {

//     public  short  ponto;  // LILY_quarto
//     public  byte   local; // dormitorio 
//     public  byte   regiao; // catedral 
//     public  byte   cidade; // cidade da catedral
//     public  byte   estado; // conjunto de cidades 
//     public  byte   reino;  // conjuntod e estados 
//     public  byte   continenete; // conjunto de reinos


// }





public struct Posicao_perto {




    public  short  ponto;  // LILY_quarto
    public  byte   local; // dormitorio 
    public  byte   regiao; // catedral 
    
}



public struct Posicao_cidade {

    public  byte   cidade; // cidade da catedral
    public  byte   estado; // conjunto de cidades 
    public  byte   reino;  // conjuntod e estados 
    public  byte   continenete; // conjunto de reinos

}






//Dormitorio_ponto_nome



// public struct Posicao {

//     public Ponto_nome ponto; 
//     public Local_nome local; // dormitorio 
//     public Regiao_nome regiao; // catedral 
//     public Cidade_nome  cidade; // cidade da catedral
//     public Estado_nome estado; // conjunto de cidades 
//     public Reino_nome reino;  // conjuntod e estados 
//     public Continente_nome continenete; // conjunto de reinos


// }