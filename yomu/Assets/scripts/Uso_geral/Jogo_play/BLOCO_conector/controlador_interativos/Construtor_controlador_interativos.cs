using UnityEngine;


public static class Construtor_controlador_interativos {

    public static Controlador_interativos Construir(){

                    if( Controlador_interativos.instancia != null )
                        { throw new System.Exception(); }

                  Controlador_interativos controlador = new Controlador_interativos(); 
                  Controlador_interativos.instancia = controlador; 
                        

                        // --- CONTROLADORES

                        controlador.bloco_conector = BLOCO_conector.Pegar_instancia();

                        // --- CRIAR CANVAS 

                        controlador.interativos_container = new GameObject( "Interativos_container" );
                        controlador.interativos_container.transform.SetParent( controlador.bloco_conector.container_conector.transform, false );


                        controlador.interativos_tipo_tela_container = new GameObject( "Interativos_tipo_tela_container" );
                        controlador.interativos_tipo_tela_container.transform.SetParent( controlador.interativos_container.transform, false );

                        controlador.interativos_tipo_personagem_container = new GameObject( "Interativos_tipo_personagem_container" );
                        controlador.interativos_tipo_personagem_container.transform.SetParent( controlador.interativos_container.transform, false );

                        controlador.interativos_tipo_item_container = new GameObject( "Interativos_tipo_item_container" );
                        controlador.interativos_tipo_item_container.transform.SetParent( controlador.interativos_container.transform, false );

                        controlador.gerenciador_dados_interativos = new Gerenciador_containers_dinamicos_parciais( Paths_sistema.path_arquivo__dados_estaticos__uso_parcial__interativos_logica, 50 );

                        controlador.controlador_tela_conector = Controlador_tela_conector.Pegar_instancia();



                  return controlador;
        



    }

}