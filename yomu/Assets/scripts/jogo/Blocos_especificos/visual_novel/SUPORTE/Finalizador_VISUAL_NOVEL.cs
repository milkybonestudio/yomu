using System.Reflection;
using System;

public static class Finalizador_VISUAL_NOVEL {


        // --- DADOS

        // asm_finalizar__VISUAL_NOVEL__X => visual_novel vai finalizar e retornar para X
        public static Assembly asm_finalizar__VISUAL_NOVEL__CARTAS;
        public static Assembly asm_finalizar__VISUAL_NOVEL__MINIGAMES;
        public static Assembly asm_finalizar__VISUAL_NOVEL__UTILIDADES;
        public static Assembly asm_finalizar__VISUAL_NOVEL__CONECTOR;



        public static void Finalizar(){

                string[] finalizar_localizador = Dados_blocos.visual_novel_finalizar_localizador;

                if( finalizar_localizador != null)
                    { Finalizar_especifico( finalizar_localizador ); }
                

                // --- GENERICO
                BLOCO_visual_novel.instancia = null;

                Controlador_personagens_visual_novel.instancia = null;
                Controlador_tela_visual_novel.instancia = null;
                Leitor_visual_novel.instancia = null;
                
                return;

        }



        public static void Finalizar_especifico( string[] _finalizar_localizador ){   
            

                // --- TEM QUE EXECUTAR ALGUMA FUNCAO
                if( STRING.Verificar_se_array_2d_esta_preenchido_corretamente( _arr: _finalizar_localizador, _length: 3 ) )
                    { throw new System.Exception(  "finalizar_localizador em VISUAL NOVEL nao veio no formato correto"  ); }

                // --- PEGA OS NOMES
                string nome_asm = _finalizar_localizador[ 0 ];
                string nome_class = _finalizar_localizador[ 1 ];
                string nome_metodo = _finalizar_localizador[ 2 ];
                ref Assembly asm_ref = ref asm_finalizar__VISUAL_NOVEL__CONECTOR;

                switch( nome_asm ){

                    case "asm_finalizar__VISUAL_NOVEL__CONECTOR": asm_ref = ref asm_finalizar__VISUAL_NOVEL__CONECTOR; break; 
                    case "asm_finalizar__VISUAL_NOVEL__CARTAS": asm_ref = ref asm_finalizar__VISUAL_NOVEL__CARTAS; break; 
                    case "asm_finalizar__VISUAL_NOVEL__MINIGAMES": asm_ref = ref asm_finalizar__VISUAL_NOVEL__MINIGAMES; break; 
                    case "asm_finalizar__VISUAL_NOVEL__UTILIDADES": asm_ref = ref asm_finalizar__VISUAL_NOVEL__UTILIDADES; break; 


                    default: throw new Exception( $" nao tem o asm { nome_asm } em finalizar_suporte_VISUAL_NOVEL" );

                }

                // --- VERIFICA SE JA TINHA SIDO CRIADO
                if( asm_ref == null )
                    {
                        // --- PEGA ASM
                        #if UNITY_EDITOR

                            asm_ref = Assembly.Load( nome_asm );
                            if( asm_ref == null )
                                { throw new Exception( $"nao conseguiu carregar o asm { nome_asm }" ); }

                        #else

                            asm_ref = Assembly.LoadFile( Paths_gerais.Pegar_path_dados_dinamicos_dll( nome_asm ) ); 
                            if( asm_ref == null )
                                { throw new Exception( $"nao conseguiu carregar o asm { nome_asm }" ); }

                        #endif
                            
                    }

                ASSEMBLY.Ativar_metodo_classe_estatica( asm_ref, nome_class, nome_metodo );
                return;

        }




}