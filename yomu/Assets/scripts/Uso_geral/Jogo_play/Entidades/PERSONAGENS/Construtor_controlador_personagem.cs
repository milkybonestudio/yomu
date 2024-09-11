using System;

public static class Construtor_controlador_personagens {

    public static Controlador_personagens Construir( Dados_sistema_personagem_essenciais[] _dados_sistema_personagens_essenciais, Dados_sistema_estado_atual _dados_sistema_estado_atual ){

            Controlador_personagens construtor = new Controlador_personagens();
            Controlador_personagens.instancia = construtor;

				throw new Exception( "aind anao pode vir aqui porque eu nao defini como pegar os dados do save ainda " );

				Controlador_personagens controlador = new Controlador_personagens();

					// ---- DADOS
					
				
                    controlador.modulo_buffer_stack = new MODULO__buffer_entidade( Tipo_entidade.personagem );
                    controlador.modulo_buffer_dados_completos = new MODULO__buffer_entidade( Tipo_entidade.personagem );

                    controlador.modulo_leitor_dll = new MODULO__leitor_dll  (
                                                                                _nome_dll: "Personagens_run_time",
                                                                                _numero_inicial_de_slots: 50

                                                                            );
					controlador.leitor_de_arquivos = new MODULO__leitor_de_arquivos (
																						_gerenciador_nome : "" ,
																						_path_folder: Paths_sistema.path_folder__dados_save_personagens,
																						_numero_inicial_de_slots: ( _dados_sistema_personagens_essenciais.Length + 10 )
																					);

					controlador.dados_sistema_personagens_essenciais = _dados_sistema_personagens_essenciais;
					controlador.personagens = new Personagem[ _dados_sistema_personagens_essenciais.Length ];

					controlador.modificador_personagem_conversa = new Modificador_personagem_conversa();



					controlador.personagens_ativos_ids = _dados_sistema_estado_atual.personagens_ativos_ids ;
					int[] personagens_ativos_planos_ids = _dados_sistema_estado_atual.personagens_ativos_planos_ids ;

					controlador.dados_sistema_personagens = new Dados_sistema_personagem[ controlador.personagens_ativos_ids.Length ];


					for( int index_personagem_ativo = 0 ; index_personagem_ativo < personagens_ativos_planos_ids.Length ; index_personagem_ativo++){

							// --- PEGAR IDS
							int plano_id = personagens_ativos_planos_ids[ index_personagem_ativo ];
							int personagem_id = controlador.personagens_ativos_ids[ index_personagem_ativo ]; 

							Adicionar_personagem_INICIO_JOGO( plano_id , personagem_id, index_personagem_ativo );
							continue;

					}
				
				
            return construtor;

    }


    
		public static void Adicionar_personagem_INICIO_JOGO( int _plano_para_adicionar_id,  int _personagem_id, int _index_dados_sistema ){

				// // --- CRIA PERSONAGEM 
				// Dados_sistema_personagem_essenciais dados_sistema_personagem_essenciais = dados_sistema_personagens_essenciais[ _personagem_id ];

				// // --- PEGA AI
				// string personagem_nome = ( ( Personagem_nome ) _personagem_id).ToString();
				// string nome_objeto_classe = $"{personagem_nome}_classe" ;
				// modulo_leitor_dll.Carregar_objeto_NA_MULTITHREAD( /*_personagem_id, */ nome_objeto_classe );
				// System.Object personagem_AI = modulo_leitor_dll.Pegar_objeto( _personagem_id );

				// // --- PEGAR CONTAINER

				// string path_personagem_dados = $"PERSONAGEM_{ personagem_nome }_dados.dat";
				// //leitor_de_arquivos.Carregar_container_NA_MULTITHREAD( _personagem_id, path_personagem_dados );
				// byte[] dados_container_personagem_byte =  leitor_de_arquivos.Pegar_dados_com_localizador( _personagem_id );
				// Dados_containers_personagem dados_containers_personagens = Construtor_containers_personagens.Construir( dados_container_personagem_byte );

				// Personagem personagem_para_adicionar =  Construtor_personagem.Construir( _personagem_id,  _plano_para_adicionar_id, dados_sistema_personagem_essenciais,  dados_containers_personagens, personagem_AI );

				// // --- COLOCA DADOS CONTAINERS 
				// personagens [ _personagem_id ] = personagem_para_adicionar; 
				// dados_sistema_personagens[ _index_dados_sistema ] = personagem_para_adicionar.gerenciador_dados_sistema.Pegar_dados();

				// // ---- CRIA SLOT INSTRUCOES
				// gerenciador_save.instrucoes_personagens[ _personagem_id ]  = new byte[ 50 ][];

				return;

		}







}