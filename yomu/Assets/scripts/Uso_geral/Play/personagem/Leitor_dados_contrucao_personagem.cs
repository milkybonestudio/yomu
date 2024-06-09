






public static class Leitor_dados_personagem {

        


    public static Containers_dados_personagem Pegar( string _path_folder_dados_personagem, int _personagem_id ){

                // ISSO SIMPLESMENTE CORTA O CONTAINER_RAW


                Containers_dados_personagem dados_retorno = new Containers_dados_personagem();

                string personagem_nome =  ( ( Personagem_nome ) _personagem_id ).ToString();


                string path_dados = _path_folder_dados_personagem + "/" + personagem_nome + "_dados.dat";
                byte[] dados_raw = System.IO.File.ReadAllBytes( path_dados );



                // [  header  ][ file_1 ][ file_2 ][ file_2 ]


                
                return dados_retorno;




    }



}