using System;


public static class Leitor_interativos_tela_DESENVOLVIMENTO {



    public static Interativo_tela Pegar( int _cidade_id , int _regiao_id, int _area_id, int _interativo_id ){


        Cidade_nome cidade =  ( Cidade_nome ) _cidade_id;

        switch( cidade ){

            case Cidade_nome.saint_land: return Letor_interativos_SAINT_LAND.Pegar( _regiao_id, _area_id, _interativo_id );
            default: throw new Exception( $"nao foi achado o handler para a cidade { cidade } no Leitor_interativos_tela_DESENVOLVIMENTO" );

        }

        return;

    }



}