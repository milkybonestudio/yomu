using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Build.Content;
using UnityEngine;


[ InitializeOnLoad ]
public class Controlador_simbulos {

    public static bool resetar = true;


    public static Cidade_nome[] cidades_para_ativar_interativos = new Cidade_nome[]{

            // 

    }; 

    static Controlador_simbulos(){

            
        if( resetar )
            { 
                resetar = false;
                Colocar_simbulos_default();
                return;
            }

    }


    
    public static void Colocar_simbulos_default(){
    

            string text = Pegar_symbols_para_ativar();
            Debug.Log( text );

            if( text == UnityEditor.PlayerSettings.GetScriptingDefineSymbolsForGroup( BuildTargetGroup.Standalone ) )
                { return; }

            
            UnityEditor.PlayerSettings.SetScriptingDefineSymbolsForGroup( BuildTargetGroup.Standalone, text );
            return;

    }


    public static string Pegar_symbols_para_ativar() { 

        
            string[] texto_arr = new string[ cidades_para_ativar_interativos.Length ];

            for( int index = 0 ; index < cidades_para_ativar_interativos.Length ; index++ ){

                    char[] c_arr = cidades_para_ativar_interativos[ index ].ToString().ToCharArray();

                    for( int c = 0 ; c < c_arr.Length ; c++ ){

                            c_arr[ c ] = char.ToUpper( c_arr[ c ] );
                            continue;

                    }

                    texto_arr[ index ]  = "INTERATIVOS_" + new string( c_arr );
                    continue;

            }

            
            string text = string.Join( ';', simbulos_default );
            return text;

    }




}
