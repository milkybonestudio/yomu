




public static class Visual_novel_paths {


        public static string Pegar_nome_path_screen_play( Nome_screen_play _nome ){


                switch( _nome ){

                case Nome_screen_play.NARA_INTRODUCAO_dia_introducao_carruagem : return "cenas_obrigatorias/1/nara_introducao/parte_1/dia_introducao_carruagem";



                case Nome_screen_play.NARA_INTRODUCAO_nara_olhando_espelho : return "cenas_obrigatorias/1/nara_introducao/parte_1/espelho";
                case Nome_screen_play.NARA_INTRODUCAO_carta_dia : return "cenas_obrigatorias/1/nara_introducao/parte_1/bilhete";
                case Nome_screen_play.NARA_INTRODUCAO_nara_olhando_buraco : return "cenas_obrigatorias/1/nara_introducao/parte_1/hole";
                case Nome_screen_play.NARA_INTRODUCAO_corredor : return "cenas_obrigatorias/1/nara_introducao/parte_1/corredor";


                case Nome_screen_play.NARA_INTRODUCAO_riku_introducao : return "cenas_obrigatorias/1/nara_introducao/parte_1/riku_introducao_castelo";  
                case Nome_screen_play.NARA_INTRODUCAO_wake_up : return "cenas_obrigatorias/1/nara_introducao/parte_1/wake_up";  

                case Nome_screen_play.teste: return  "cenas_obrigatorias/0/teste";  

                default :  throw new System.ArgumentException("nao foi achado path para o Nome_screen_play: " + _nome);
                }

        
    }




        public static string Tirar_extensao_path( string _path  ){

                string path_sem_ext = System.IO.Path.ChangeExtension( _path, "" );
                return path_sem_ext;

        }


        

        public static string Pegar_nome_do_file_por_path( string _path  ){

                string nome = System.IO.Path.GetFileNameWithoutExtension( _path );
                return nome;

        }

        




        public static string Pegar_path_file_producao( string _nome_file_path , bool _retirar_extensao = false ){ 

                string path_file_producao = System.IO.Directory.GetCurrentDirectory() + "\\Assets\\Editor\\files_em_producao\\visual_novel\\" + _nome_file_path + ".txt";

                if( _retirar_extensao ) {System.IO.Path.ChangeExtension( path_file_producao, "" );}

                return path_file_producao;

        }

        


        public static string Pegar_path_file_compilado ( string _nome_file_path , bool _retirar_extensao = false  ){

                string path_file_compilado = System.IO.Directory.GetCurrentDirectory() + "\\Assets\\Resources\\files\\cenas\\" + _nome_file_path + ".txt";

                if( _retirar_extensao ) {System.IO.Path.ChangeExtension( path_file_compilado, "" );}

                return path_file_compilado;

        }
        


        public static string Pegar_path_backup_versoes_dir ( string _nome_file_path , bool _retirar_extensao = false  ){


                // como nao tem .txt vai ser considerado um folder
                string path_backup_versoes_dir = System.IO.Directory.GetCurrentDirectory() +  "\\Assets\\Editor\\files_em_producao\\visual_novel\\backup\\" + _nome_file_path ;
                return path_backup_versoes_dir;

        }










}