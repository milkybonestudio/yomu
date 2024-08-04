using UnityEngine;


public static class Controlador_imagens_gerais {

    // *** por hora as imagens vao ser copiadas para um folder na build. 
    // mas se eu precisar compilar por qualquer motivo o chave vai precisar continuar sendo a string


    public static byte[] Pegar_png( string _path ){

        return  System.IO.File.ReadAllBytes( _path );
        
    }



}