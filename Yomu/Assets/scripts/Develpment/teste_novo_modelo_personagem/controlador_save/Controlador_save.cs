using System;
using UnityEngine;


public class Controlador_save_ {

    public static Controlador_save_ instancia;
    public static Controlador_save_ Pegar_instancia(){ return instancia; }
    public static void Construir( int _save, bool _new_game ){ instancia = new Controlador_save_( _save, _new_game );return; }


    // ** funcao 
    /*

         => salvar run time 
         => salvar caso morte 
         
    
    */


    // controlador_save também só é iniciado quando o jogo for iniciado

    // quem verifica se é new game é controlador_configuracao
    // controlador save vai assumir que oque vier aqui faz sentido 
    // ** controlador_save tem que sempre ser o primeiro a iniciar para se caso for new game criar os folders 

    public Controlador_save_( int _save , bool _new_game ){

            Controlador_save_.instancia = this;


            if( _new_game ){ 

                string folder_save_path = Paths_gerais.Pegar_path_folder_dados_save( _save );
                System.IO.Directory.CreateDirectory( folder_save_path );
                
                // se acrescentar coisas colocar aqui 
                Criar_dados_iniciais_personagens( _save );


            }

            Controlador_personagens.Construir( _save );

            



    }




    public void Criar_dados_iniciais_personagens( int _save ){

            /*
                a unica coisa de dados_sistema que precisa ter realmente dados fixos é onde que o personagem começa 
                talvez eu faça uma lista com os dados e o resto é criado tudo por default 

            */



            // onde vai ser salvo
            string path_folder_dados_personagens = Paths_gerais.Pegar_path_folder_dados_save( _save ) + "/Personagens";
            string path_folder_dados_personagens_morte = Paths_gerais.Pegar_path_folder_dados_save( _save )  + "save_morte/Personagens";
            
            string path_folder_save_default = Paths_gerais.Pegar_path_folder_dados_save_default() + "/Personagens";

            // normal
            Copiar_pasta_inteira(  

                _local_para_salvar: path_folder_dados_personagens ,
                _local_para_copiar : path_folder_save_default
            );

            // morte 
            Copiar_pasta_inteira(  

                _local_para_salvar: path_folder_dados_personagens_morte ,
                _local_para_copiar : path_folder_save_default
            );








    }



        // assume que a pasta já existe 
        // testei e já funciona corretamente
        public void Copiar_pasta_inteira(  string _local_para_salvar,  string _local_para_copiar ){

                    Debug.Log( $"pasta para salvar: { _local_para_salvar }" );

                
                
                // Sempre assume que o folder nao foi criado
                System.IO.Directory.CreateDirectory( _local_para_salvar );

                // vem como path completo
                string[] folders = System.IO.Directory.GetDirectories( _local_para_copiar );

                for( int folder_id = 0 ; folder_id < folders.Length ; folder_id++ ){
                                                                           //   ta certo, vai pegar somente o nome do diretory
                    string folder_path_para_salvar = _local_para_salvar + "/" + System.IO.Path.GetFileName( folders[ folder_id ] );
                    string folder_path_para_copiar = folders[ folder_id ] ;
                    Copiar_pasta_inteira( folder_path_para_salvar , folder_path_para_copiar );

                }
                /// vem com o path completo
                string[] nomes_arquivos = System.IO.Directory.GetFiles( _local_para_copiar );

                for( int arquivo_id = 0 ; arquivo_id < nomes_arquivos.Length ; arquivo_id++ ){

                    
                    string path_arquivo_para_salvar = _local_para_salvar + "/" + System.IO.Path.GetFileName( nomes_arquivos[ arquivo_id ] );
                    string path_arquivo_para_copiar =  nomes_arquivos[ arquivo_id ];
                    System.IO.File.Copy(  path_arquivo_para_copiar,  path_arquivo_para_salvar  );

                }

                return;

            }







}