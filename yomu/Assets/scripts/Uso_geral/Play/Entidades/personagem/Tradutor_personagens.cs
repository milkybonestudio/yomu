

public static class Tradutor_personagens_completo {



        public static void Traduzir(  Personagem _personagem , string _path_folder_dados ){

                // tem sempre os arquivos 
                // só vai ser usado para criar personagens 

                Construir_dados_internos( _personagem, _path_folder_dados );
                string path_lugares_dados = _path_folder_dados + "/lugares_dados.dat";
                string path_conversas_dados = _path_folder_dados + "/conversas_dados.dat";
                string path_dados_plots = _path_folder_dados + "/dados_plots.dat";
                string path_dados_quests = _path_folder_dados + "/dados_quests.dat";
                string path_outros_personagens_dados = _path_folder_dados + "/outros_personagens_dados.dat";
                string path_outros_personagens_conversas = _path_folder_dados + "/outros_personagens_conversas.dat";


                return;


        }


        public static void Construir_dados_internos ( Personagem _personagem , string _path_folder_dados ){

                string path_dados_internos = _path_folder_dados + "/dados_internos.dat";
                byte[] dados = System.IO.File.ReadAllBytes( path_dados_internos );

                // pensar formato
                return;



        }




}