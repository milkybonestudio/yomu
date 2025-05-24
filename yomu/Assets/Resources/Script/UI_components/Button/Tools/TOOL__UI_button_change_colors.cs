using System;
using UnityEngine;



public static class TOOL__UI_button_change_colors {



        public static Color Guarantee_color( Color _cor_nos_dados, Color _cor_default ){


                if( _cor_nos_dados != Color.clear )
                    { return _cor_nos_dados; }

                // --- COLOCAR DEFAULT
                return _cor_default; 
                    
        }


        public static Color[] Mudar_cor_default_sequecia( Color[] _cor_nos_dados, int[] _ids, Color _cor_default, string _indentificador = "NAO INDENTIFICADO" ){

                // --- PEGAR IMAGENS


                if( _cor_nos_dados != null )
                    { 
                        // --- VERIFICAR SE CORES FAZEN SENTIDO

                        if( _cor_nos_dados.Length != _ids.Length )
                            { CONTROLLER__errors.Throw( $"Declarou cores no indentificador { _indentificador } mas tinham { _cor_nos_dados.Length } cores e a sequencia tinha { _ids.Length } imagens" ); }

                        return _cor_nos_dados; 
                        
                    }



                Color[] retorno =  new Color[ _ids.Length ];

                for( int index = 0 ; index < retorno.Length ; index++ )
                    { retorno[ index ] = _cor_default; }

                return retorno;

        }


        
} 

