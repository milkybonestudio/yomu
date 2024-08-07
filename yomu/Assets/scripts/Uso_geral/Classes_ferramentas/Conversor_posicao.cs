using UnityEngine;



public static class Conversor_posicao {

    public static Vector2 Ajustar_real_para_virtual( Vector2 _vec ){

        return _vec * ( 1080f / Screen.height );

    }

}