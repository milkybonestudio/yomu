using System;

public static class CONSTRUCTOR__controller_cities {


    public static CONTROLLER__cities Construct( Dados_sistema_cidade_essenciais[] _dados_sistema_cidades_essenciais , Dados_sistema_estado_atual _dados_sistema_estado_atual ) {


            CONTROLLER__cities controlador = new CONTROLLER__cities();
            CONTROLLER__cities.instance = controlador;

					
					controlador.leitor_de_arquivos = new MODULO__leitor_de_arquivos ( 
																						_gerenciador_nome : "" ,
																						_path_folder: null // pegar depois
																					);
            
            return controlador;

		}


}