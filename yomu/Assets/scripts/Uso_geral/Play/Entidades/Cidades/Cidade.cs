



public class Gerenciador_containers_dados_cidade{

    public byte[] Compilar_dados(){ return null;}
    public Dados_containers_cidade dados_containers;

}

public class Gerenciador_dados_sistema_cidade{

    public Dados_sistema_cidade Pegar_dados(){

        return dados;

    }

    public Dados_sistema_cidade dados;

}

public class Gerenciador_AI_cidade{

    public System.Object cidade_AI;
    
}

public class Cidade {

    public Cidade( int _cidade_id ){
        cidade_id = _cidade_id;

    }

    public int cidade_id;
    public Gerenciador_containers_dados_cidade gerenciador_containers_dados;
    public Gerenciador_dados_sistema_cidade gerenciador_dados_sistema;
    public Gerenciador_AI_cidade gerenciador_AI;
    
    
}