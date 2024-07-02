


public static class Leitor_Info_cidades_reino_humano_DEVELOPMENT{


    public static Info_cidade Pegar_info_cidade( Posicao _posicao ){

        Cidade_nome  cidade = ( Cidade_nome ) _posicao.cidade_id;

        switch( cidade ){
            case Cidade_nome.san_sebastian: return Info_san_sebastian.Pegar();
            default: throw new System.Exception();
        }

    }



}