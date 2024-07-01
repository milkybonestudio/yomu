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



                public static bool forcar_tudo = true;
                
                public static Estado_nome[] estados_ativos = new Estado_nome[]{


                                Estado_nome.San_sebastian,


                };


                public static Cidade_nome[] cidades_ativas = new Cidade_nome[]{


                }; 

                static Controlador_directives(){


                                
                                // --- LIMPAR

                                var assembly = Assembly.GetAssembly( typeof( UnityEditor.Editor ) ) ;
                                var tipo = assembly.GetType( "UnityEditor.LogEntries" ) ;
                                tipo.GetMethod( "Clear" ).Invoke( null, null )  ;


                                string directives_atual = UnityEditor.PlayerSettings.GetScriptingDefineSymbolsForGroup( BuildTargetGroup.Standalone );

                                if( forcar_tudo )
                                        { 
                                                // --- FORCAR TUDO
                                                
                                                if( directives_atual == "FORCAR_TODOS_OS_ESTADOS" )
                                                        { return; }

                                                UnityEditor.PlayerSettings.SetScriptingDefineSymbolsForGroup( BuildTargetGroup.Standalone, "FORCAR_TODOS_OS_ESTADOS" );
                                                Debug.Log( $"directiva colocada: <color=lime><b> FORCAR_TODOS_OS_ESTADOS </b></color>" );

                                                return;
                                        }



                                // --- PEGAR NOVAS DIRECTIVAS

                                string texto = "";
                                texto = Gerenciador_cidades_directivas.Pegar_cidades_para_adicionar( estados_ativos, cidades_ativas, texto );


                                // --- VERIFICAR SE TEVE MUDANCA
                                if( directives_atual == texto )
                                        { return; }

                                
                                // --- ATUALIZAR 
                                UnityEditor.PlayerSettings.SetScriptingDefineSymbolsForGroup( BuildTargetGroup.Standalone, texto ) ;

                                return ;
                                
                                

                }







}
