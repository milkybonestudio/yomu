using System.Reflection;
using System;

public static class Finalizador_VISUAL_NOVEL {


        // --- DADOS

        public static void Finalizar(){

                // Localizador_lidar_retorno_bloco finalizar_localizador = Dados_blocos.localizador_lidar_retorno_story;

                // // --- PEGA OS NOMES                
                // string nome_class = finalizar_localizador.nome_classe;
                // string nome_metodo = finalizar_localizador.nome_metodo;

                // if( nome_class != null )
                //     { Dlls_collections.lidar_finalizar.Invoke_method( nome_class, nome_metodo, new object[]{ ( object ) Dados_blocos.story_RETURN } ); }
                

                // --- GENERICO
                BLOCO_story.instancia = null;

                Controlador_personagens_visual_novel.instancia = null;
                Controlador_tela_story.instancia = null;
                Leitor_visual_novel.instancia = null;
                
                return;

        }


        public static void Finalizar_especifico( Localizador_lidar_retorno_bloco _finalizar_localizador ){   
            

                // ativa o metodo
                

                return;

        }




}