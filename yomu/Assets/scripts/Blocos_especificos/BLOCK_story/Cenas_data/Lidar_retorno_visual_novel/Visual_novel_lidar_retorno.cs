using System;
using UnityEngine;



public static class Visual_novel_lidar_retorno {

        /* responsavel por fazer o handler dos dados */
        

        public static void Lidar_retorno( BLOCO_story bloco ){


                Localizador_simples localizador =  bloco.lidar_retorno_localizador;

                if( localizador.tipo != 0 )
                    {
                        // --- TEM ESPECIFICO

                        Action fn = ( Action ) Controlador_dados.instancia.modulo__leitor_dll_dados_blocos.Pegar_objeto( "Leitor_lidar_retorno_visual_novel", "Pegar",  new object[]{ ( object ) localizador });
                        if( fn == null )
                            { throw new Exception( $"Nao achou o localizador ${ localizador }" ); }

                    }
                    else
                    {
                        // --- DEFAULT



                    }


        }


}