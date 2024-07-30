


public static class Parser_enum_localizador {


        public static string[] Parse( System.Type _type, string _folder_inicial, string _extensao  ){

                if( !!!( System.IO.Directory.Exists( _folder_inicial ) ) )
                        { throw new System.Exception($"Nao foi achado o folder { _folder_inicial }"); }


                string nome = _type.Name;
                
                // --- COLOCA O FOLDER INICIAL
                nome = _folder_inicial + "__" + nome;

                string[] folders_separados = nome.Split( "__" );
                string[] nomes_imagens = System.Enum.GetNames( _type );

                // LOCALIZADOR__USO_PLAYER__CONECTOR__MINIGAMES_UI__parte_dispositivo
                // folders_separados[ 0 ] => "TIPO"
                // folders_separados[ ultimo ] => "parte_dispositivo" => nome da coisa



                string path_folder = System.IO.Path.Combine( folders_separados );

                STRING.Deixar_somente_a_primeira_letra_maiuscula_array( folders_separados );

                string[] paths_retorno = new string[ nomes_imagens.Length ];

                for( int nome_index = 1 ; nome_index < paths_retorno.Length  ; nome_index++ ){

                        folders_separados[ ( folders_separados.Length - 1 ) ] = nomes_imagens[ nome_index ] + _extensao;
                        paths_retorno[ nome_index ] = System.IO.Path.Combine( folders_separados );

                        if( !!!( System.IO.File.Exists( paths_retorno[ nome_index ] ) ) )
                            { throw new System.Exception( $"nao foi encontrado o arquivo no path: { paths_retorno[ nome_index ] }" ); }

                        continue;

                }




                return null;

            
        }



}
