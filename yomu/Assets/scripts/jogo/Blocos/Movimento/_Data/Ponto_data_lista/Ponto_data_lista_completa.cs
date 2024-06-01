




using UnityEngine;

public static class Pontos_data_lista_completa {




    public static Ponto_data[] Pegar_lista(){

        int numero_de_pontos = System.Enum.GetNames( typeof( Ponto_nome ) ).Length;
        Ponto_data[] lista_completa = new Ponto_data[ numero_de_pontos ];

        Pontos_data_lista_0.Colocar_interativos( lista_completa );

        return lista_completa;




    }





}

