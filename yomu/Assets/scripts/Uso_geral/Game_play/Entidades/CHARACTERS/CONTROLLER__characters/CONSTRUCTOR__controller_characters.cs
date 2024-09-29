using System;

public static class CONSTRUCTOR__controller_characters {

    public static CONTROLLER__characters Construir( Character[] _characters, Dados_sistema_estado_atual _dados_sistema_estado_atual ){

            CONTROLLER__characters construtor = new CONTROLLER__characters();
            CONTROLLER__characters.instance = construtor;

				throw new Exception( "aind anao pode vir aqui porque eu nao defini como pegar os dados do save ainda " );

				CONTROLLER__characters controlador = new CONTROLLER__characters();

					// ---- DADOS
					
				
                    controlador.data_manager = new MODULE__controller_entities_data_manager( Entity_type.character, _number_slots : 20 );

					controlador.leitor_de_arquivos = new MODULO__leitor_de_arquivos (
																						_gerenciador_nome : "" ,
																						_path_folder: Paths_sistema.path_folder__dados_save_personagens
																					);

					
					controlador.characters = _characters;

				

					controlador.characters_activated = _dados_sistema_estado_atual.personagens_ativos_ids ;
					int[] personagens_ativos_planos_ids = _dados_sistema_estado_atual.personagens_ativos_planos_ids ;
				
            return construtor;

    }


}