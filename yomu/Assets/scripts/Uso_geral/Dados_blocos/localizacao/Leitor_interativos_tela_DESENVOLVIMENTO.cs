using System;


public static class Leitor_interativos_tela_DESENVOLVIMENTO {



    public static Interativo_tela Pegar( Posicao_local _posicao, int _interativo_id ){


        Cidade_nome cidade =  ( Cidade_nome ) _posicao.cidade_id;

        switch( cidade ){

            case Cidade_nome.saint_land: return Leitor_interativos__SAINT_LAND.Pegar( _posicao, _interativo_id );
            default: throw new Exception( $"nao foi achado o handler para a cidade { cidade } no Leitor_interativos_tela_DESENVOLVIMENTO" );

        }

        return null;

    }



}