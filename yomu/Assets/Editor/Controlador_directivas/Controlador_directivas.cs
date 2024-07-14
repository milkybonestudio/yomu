using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Build.Content;
using UnityEngine;



// ** mudar as directives tomam muito tempo, tentar nao mudar com frequencia


[ InitializeOnLoad ]
public class Controlador_directives : Editor {


                // por hora sempre carregar uma ou mais regioes interias 


                public static bool modo_build = false; // forca tudo


                //public static bool forcar_tudo = true;


                
                public static Regiao_nome[] regioes_ativas = new Regiao_nome[]{


                                Regiao_nome.regiao_1


                };




                static Controlador_directives(){


                                
                                // --- LIMPAR

                                var assembly = Assembly.GetAssembly( typeof( UnityEditor.Editor ) ) ;
                                var tipo = assembly.GetType( "UnityEditor.LogEntries" ) ;
                                tipo.GetMethod( "Clear" ).Invoke( null, null )  ;


                                string directives_atual = UnityEditor.PlayerSettings.GetScriptingDefineSymbolsForGroup( BuildTargetGroup.Standalone );

                                if( modo_build )
                                        { 
                                                // --- FORCAR TUDO

                                                Debug.Log("a");
                                                
                                                if( directives_atual == "FORCAR_TUDO" )
                                                        { return; }

                                                UnityEditor.PlayerSettings.SetScriptingDefineSymbolsForGroup( BuildTargetGroup.Standalone, "FORCAR_TUDO" );
                                                Debug.Log( $"directiva colocada: <color=lime><b> FORCAR_TUDO </b></color>" );

                                                return;
                                        }



                                // --- PEGAR NOVAS DIRECTIVAS

                                string texto = "";
                                texto = Gerenciador_regioes_directivas.Pegar_regioes_para_adicionar( regioes_ativas, texto );
                                texto += "FORCAR_TODOS_OS_ITENS;";

                                


                                // --- VERIFICAR SE TEVE MUDANCA
                                if( directives_atual == texto )
                                        { return; }

                                
                                // --- ATUALIZAR 
                                UnityEditor.PlayerSettings.SetScriptingDefineSymbolsForGroup( BuildTargetGroup.Standalone, texto ) ;

                                return ;
                                
                                

                }







}
