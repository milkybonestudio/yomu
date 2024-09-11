using System;

public static class Construtor_controlador_armazenamento_disco {


        public static Controlador_armazenamento_disco Construir( Dados_sistema_estado_atual _dados_sistema_estado_atual, int _save, bool _novo_jogo  ){


                // --- por hora nao deixa
                return null;

                Controlador_armazenamento_disco controlador = new Controlador_armazenamento_disco(); 
                Controlador_armazenamento_disco.instancia = controlador;

                    // --- USO GERAL 

                    Paths_sistema.Colocar_save( _save );

                    controlador.encoder = new System.Text.UTF8Encoding( true );


                    // --- VERIFICACOES DE SEGURANCA
                
                    if( _save > 5 ) 
                            { throw new Exception( "tentou carregar save " + _save.ToString() ); }

                    if( _novo_jogo )
                            { controlador.Criar_arquivos_novo_jogo( _save ); }

                    if( !!! ( System.IO.File.Exists( Paths_sistema.path_arquivo__dados_dinamicos__uso_completo__dados_sistema ) ) )
                            { throw new Exception( $"dados_programa.dat nao foi encontrado no path { Paths_sistema.path_arquivo__dados_dinamicos__uso_completo__dados_sistema }"); }

                    
                    

                    // --- USAO EXCLUSIVO SAVE
                    controlador.modulo_gerenciador_instrucoes_de_seguranca = new MODULO__gerenciador_instrucoes_de_seguranca();


                    // --- DADOS SISTEMA

                    // dados_sistema => dados essencias entidades, estado atual 
                    byte[] dados_sistema = System.IO.File.ReadAllBytes( Paths_sistema.path_arquivo__dados_dinamicos__uso_completo__dados_sistema );
                    Dados_sistema_estado_atual dados_sistema_estado_atual = Tradutor_dados_sistema.Descompactar_dados_sistema_estado_atual( dados_sistema );



                    
                    

                return controlador;


        }
}