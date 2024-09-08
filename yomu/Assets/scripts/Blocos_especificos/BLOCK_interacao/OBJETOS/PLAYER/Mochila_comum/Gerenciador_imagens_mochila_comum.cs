using UnityEngine;


public enum Mochila_comum_imagem {

    parte_de_tras, 
    parte_da_frente, 


}


public class Gerenciador_imagens_mochila_comum {


    public Sprite[] imagens;
    public byte[][] pngs;

    public MODULO__desmembrador_de_arquivo desmembrador_de_arquivo;

    public Gerenciador_imagens_mochila_comum(){

        desmembrador_de_arquivo  =  new MODULO__desmembrador_de_arquivo (
                                                                            "",
                                                                            "",
                                                                            50
                                                                        );
        return;                                                                    

    }

    public void Carregar(){

            string[] nomes = System.Enum.GetNames( typeof( Mochila_comum_imagem ) );

            pngs = new byte[ nomes.Length ][];
            imagens = new Sprite[ nomes.Length ];


    }



}