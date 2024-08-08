using UnityEngine;


public static class COLOR {

    public static Color Pegar_cor_media( Color _cor_1, Color _cor_2, float _rate ){


        return new Color(

            ( _cor_1[ 0 ] * ( 1f -_rate ) + _cor_2[ 0 ] * _rate ),
            ( _cor_1[ 1 ] * ( 1f -_rate ) + _cor_2[ 1 ] * _rate ),
            ( _cor_1[ 2 ] * ( 1f -_rate ) + _cor_2[ 2 ] * _rate ),
            ( _cor_1[ 3 ] * ( 1f -_rate ) + _cor_2[ 3 ] * _rate )

        );

    }

}