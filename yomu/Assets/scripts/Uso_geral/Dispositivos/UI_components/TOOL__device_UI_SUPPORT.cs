using System;
using UnityEngine;

public static class TOOL__device_UI_SUPPORT {




        public static void Verificar_tempos_sequencia( float[] _tempos, Color[] _cores, string _indentificador ){

            if( _cores == null )
                { 
                    if( _tempos != null )
                        { throw new Exception( $"Nao foi definido as cores no {_indentificador } mas foi definido os tempos" );}

                    return; 
                }

            if( _tempos == null )
                { return; }

            if( _tempos.Length != _cores.Length )
                { throw new Exception($"Foi declarado {_tempos.Length} tempos para a sequencia {_indentificador }, mas tinha { _cores.Length}"); }

            return;

        }

        public static void Verificar_nome( string nome_dispositivo, string _nome ){

               if( _nome == "" || _nome == null )
                    { throw new Exception( $"Nao foi colocado o nome da imagem estatica no dispositivo <Color=lighBlue><b>{ nome_dispositivo }</b></color>" ); }
                return;
        }


        public static Color Mudar_cor_default( Color _cor_nos_dados, Color _cor_default ){


                if( _cor_nos_dados != Cores.cor_default_dispositivo )
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
                            { throw new Exception( $"Declarou cores no indentificador { _indentificador } mas tinham { _cor_nos_dados.Length } cores e a sequencia tinha { _ids.Length } imagens" ); }

                        return _cor_nos_dados; 
                        
                    }



                Color[] retorno =  new Color[ _ids.Length ];

                for( int index = 0 ; index < retorno.Length ; index++ )
                    { retorno[ index ] = _cor_default; }

                return retorno;

        }


        
}