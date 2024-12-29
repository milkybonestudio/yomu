using UnityEngine;


public static class COLOR {

    public static Color Blend_color_with_rate( Color _cor_1, Color _cor_2, float _rate ){

        return new Color(

            ( _cor_1.r * ( 1f -_rate ) + _cor_2.r * _rate ),
            ( _cor_1.g * ( 1f -_rate ) + _cor_2.g * _rate ),
            ( _cor_1.b * ( 1f -_rate ) + _cor_2.b * _rate ),
            ( _cor_1.a * ( 1f -_rate ) + _cor_2.a * _rate )

        );

    }

}