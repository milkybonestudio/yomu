using UnityEngine;
using System;

public static class Conversor_imagens_dispositivos{

    public static byte[] Converter( System.Type _tipo_classe ){


        object ob = System.Activator.CreateInstance( _tipo_classe );
        string[] _folders = ( string[] ) _tipo_classe.GetField( "folders" ).GetValue( ob );
        string _nome_dispositivo = ( string ) _tipo_classe.GetField( "nome" ).GetValue( ob );
        System.Type _tipo = ( System.Type ) _tipo_classe.GetMethod( "Pegar_tipo_imagens" ).Invoke( ob, null );


        // ** usado para pegar as imagens

        string[] nomes = System.Enum.GetNames( _tipo );
        int[] localizadores = new int[ ( nomes.Length  + 1 ) ];

        localizadores[ 0 ] = ( localizadores.Length * 4 );

        byte[][] pngs = new byte[ nomes.Length][];


        string path_folder = GERENCIADOR__imagens_dispositivo.Pegar_path_imagens_DEVELOPMENT( _folders, _nome_dispositivo );

        for( int nome_index = 0 ; nome_index < nomes.Length ; nome_index++ ){

                string path = System.IO.Path.Combine( path_folder, ( nomes[ nome_index ] + ".png" ) );

                if( !!!( System.IO.File.Exists( path ) ) )
                    { throw new System.Exception( $"Tentou pegar a imagem no path { path }, mas ele nao existia" ); }

                // --- PEGA O PNG
                byte[] png = System.IO.File.ReadAllBytes( path );

                pngs[ nome_index ] = png;

                localizadores[ nome_index + 1 ] = ( localizadores[ nome_index ] + png.Length );

        }

        int quantidade_de_dados = localizadores[ ( localizadores.Length - 1 ) ] ;
        byte[] container_final = new byte[ quantidade_de_dados ];


        // --- PASSA OS LOCALIZADORES
        for( int localizador_index = 0 ; localizador_index < localizadores.Length ; localizador_index++ ){

                container_final[ ( localizador_index * 4 ) + 0  ] = ( byte ) ( localizadores[ localizador_index ] >> 24 );
                container_final[ ( localizador_index * 4 ) + 1  ] = ( byte ) ( localizadores[ localizador_index ] >> 16 );
                container_final[ ( localizador_index * 4 ) + 2  ] = ( byte ) ( localizadores[ localizador_index ] >>  8 );
                container_final[ ( localizador_index * 4 ) + 3  ] = ( byte ) ( localizadores[ localizador_index ] >>  0 );
            
        }

        int pointer = ( localizadores.Length * 4 ) ;

        for( int png_index = 0 ; png_index < pngs.Length ; png_index++ ){

                byte[] png = pngs[ png_index ];

                for( int b = 0 ; b < png.Length ; b++ ){

                        container_final[ pointer ] = png[ b ];
                        pointer++;
                        continue;

                }

                continue;

        }

        return container_final;




    }

}
