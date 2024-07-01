


public static class Leitor_Info_cidades_reino_humano_DEVELOPMENT{


    public static Info_cidade Pegar_info_cidade( Posicao _posicao ){

        Cidade_nome  cidade = ( Cidade_nome ) _posicao.cidade_id;

        switch( cidade ){
            case Cidade_nome.saint_land: return Pegar_info_SAINT_LAND();
            default: throw new System.Exception();
        }

    }


    public static Info_cidade Pegar_info_SAINT_LAND(){

        return null;

    }


     


}