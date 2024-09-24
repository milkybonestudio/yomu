using UnityEngine;


public static class Construtor_controlador_interativos {

        public static Controlador_interativos Construir(){

                if( Controlador_interativos.instancia != null )
                    { throw new System.Exception(); }

                Controlador_interativos controlador = new Controlador_interativos(); 
                Controlador_interativos.instancia = controlador; 
                    

                    // --- CONTROLADORES

                    controlador.bloco_interacao = BLOCO_interacao.Pegar_instancia();

                    // --- CRIAR CANVAS 

                    controlador.interativos_container = new GameObject( "Interativos_container" );
                    controlador.interativos_container.transform.SetParent( Controlador_tela_conector.instancia.container_conector.transform, false );


                    controlador.interativos_tipo_tela_container = new GameObject( "Interativos_tipo_tela_container" );
                    controlador.interativos_tipo_tela_container.transform.SetParent( controlador.interativos_container.transform, false );

                    controlador.interativos_tipo_personagem_container = new GameObject( "Interativos_tipo_personagem_container" );
                    controlador.interativos_tipo_personagem_container.transform.SetParent( controlador.interativos_container.transform, false );

                    controlador.interativos_tipo_item_container = new GameObject( "Interativos_tipo_item_container" );
                    controlador.interativos_tipo_item_container.transform.SetParent( controlador.interativos_container.transform, false );

                    controlador.leitor_de_arquivos = new MODULO__leitor_de_arquivos ( 
                                                                                        _gerenciador_nome : "",
                                                                                        _path_folder: Paths_sistema.path_arquivo__dados_estaticos__uso_parcial__interativos_logica
                                                                                        
                                                                                    );

                    controlador.controlador_tela_conector = Controlador_tela_conector.Pegar_instancia();



                return controlador;
        

        }

}