using UnityEngine;


public static class Interativos_lista_completa {




    public static Interativo[] Pegar_lista(){

        int numero_de_interativos = System.Enum.GetNames( typeof( Interativo_nome ) ).Length;
        Interativo[] lista_completa = new Interativo[ numero_de_interativos ];

        Interativos_lista_0.Colocar_interativos( lista_completa );

        return lista_completa;





    }





}

