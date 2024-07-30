using UnityEngine;


public static class Controlador_imagens_gerais {


    public static byte[] Pegar_png( string _path ){

        return  System.IO.File.ReadAllBytes( _path );
        
    }



}