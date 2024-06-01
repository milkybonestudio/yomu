using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class Aes_teste {


        public static void Main() {


            string original = "Here is some data to encrypt!";

        }



        public static byte[] ativar_PNG(  string imagem_nome, byte[] iv  , byte[] key  ){

                string path = "C:\\Users\\User\\Desktop\\coisas\\site\\container\\" + imagem_nome ;

                string png_path = path + ".png";
                string png_dat = path + ".dat";


                
                // Debug.Log( "compactar: " );

                // foreach( byte by in iv ){
                //     Debug.Log( "byte: " + by );
                // }
                // Debug.Log("---------------");


                byte[] png = System.IO.File.ReadAllBytes( png_path );


                // Debug.Log( $"1: { png[ 0 ]}" );
                // Debug.Log( $"2: { png[ 1 ]}" );
                // Debug.Log( $"3: { png[ 2 ]}" );
                // Debug.Log( $"4: { png[ 3 ]}" );



                byte[] encrypted = new byte[ png.Length ];

                Aes aesAlg = Aes.Create();
                
                aesAlg.Key = key;
                aesAlg.IV = iv;

                Debug.LogError( key.Length );

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                MemoryStream msEncrypt = new MemoryStream();
                CryptoStream csEncrypt = new CryptoStream( msEncrypt, encryptor, CryptoStreamMode.Write );
                BinaryWriter bn_writer = new BinaryWriter( csEncrypt );

                int block = 0;

                for( int p = 0 ; p < png.Length; p++ ){

                    block = ( block + 1 ) % 16 ;
                    bn_writer.Write( png[ p ] );


                }

                if( block  != 0 ) {

                    
                    // byte byte_padding = ( byte ) block;

                    for( ; block < 32 ;block++ ){

                        bn_writer.Write( 0 );

                    }


                }


                byte[] retorno = msEncrypt.ToArray();

                Debug.Log( "lg png: " + png.Length );
                Debug.Log( "lg encriptado: " + retorno.Length );

                
                //csEncrypt.Read(  encrypted , 0 ,  ( ( int ) csEncrypt.Length)  );

                //System.IO.File.WriteAllBytes( png_dat ,  retorno );

                int lg =  retorno.Length;
                
                System.IO.File.WriteAllBytes( png_dat ,  retorno );



                //msEncrypt.Dispose();

                return msEncrypt.ToArray();


        }






        public static byte[] descompactar_PNG(  string imagem_nome, byte[] iv  , byte[] key  ){



            string path = "C:\\Users\\User\\Desktop\\coisas\\site\\container\\" + imagem_nome ;

            string png_path = path + ".png";
            string png_dat = path + ".dat";


            byte[] encrypted = System.IO.File.ReadAllBytes( png_dat );

            byte[] png_retorno  = new byte[ encrypted.Length ];

            //Debug.Log( "oque veio compact length: " + png.Length );

            Aes aesAlg = Aes.Create();
            
            aesAlg.Key = key;
            aesAlg.IV = iv;

            

            ICryptoTransform encryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            MemoryStream msEncrypt = new MemoryStream( encrypted );
            CryptoStream csEncrypt = new CryptoStream( msEncrypt, encryptor, CryptoStreamMode.Read );
            BinaryReader bn_writer = new BinaryReader( csEncrypt );


            // png[ 0 ] =  bn_writer.ReadByte();
            // Debug.Log( png[ 0 ] );

            //  bn_writer.Read( png, 0, (png.Length - 1) );
            


            int p = 0;

            
        try {



                //png = System.IO.File.ReadAllBytes( png_path );

                // acho que se copiar a mais nao vai dar em nada por conta dos chunkcs
                for( p = 0 ; p < png_retorno.Length ; p++ ){

                    png_retorno[ p ] =  bn_writer.ReadByte();

                }

        } catch( Exception err ){

            Debug.Log( "parou no " + p ) ;


        }







            System.IO.File.WriteAllBytes( ( path + "_teste.png" ) , png_retorno );

            return png_retorno;



        }


         





        public static byte[][] Get_key_AND_IV(){

                byte[][] retorno = new byte[ 2 ][];

                string path = Application.dataPath + "/AES_teste/dados.txt";

                string[] txt = System.IO.File.ReadAllLines( path );

                retorno [ 0 ]  =  Convert.FromBase64String (txt[ 0 ].Split( ": " )[ 1 ] );
                retorno [ 1 ]  =  Convert.FromBase64String (txt[ 1 ].Split( ": " )[ 1 ] );

                Debug.Log( "length em get: " + retorno[ 0 ].Length );

                return retorno;


        }


        public static  void Pegar_key_E_IV(){

                // ja tenho chave estatica
                return;

                string path = Application.dataPath + "/AES_teste";

                if( ! (System.IO.Directory.Exists( path )) ){

                        System.IO.Directory.CreateDirectory( path );

                }

                string path_arquivo = path + "/dados.txt";

                if( System.IO.File.Exists( path_arquivo ) ) { System.IO.File.Delete( path_arquivo ) ; }



                string[] texto = new string[ 2 ];

                Aes aesAlg = Aes.Create();

                byte[] IV_byte_arr = aesAlg.IV;
                Debug.Log( "Length em pegar: " + IV_byte_arr.Length );
                byte[] Key_byte_arr = aesAlg.Key;

                texto[ 0 ] = "IV : " + Convert.ToBase64String( IV_byte_arr );
                texto[ 1 ] = "key : " + Convert.ToBase64String( Key_byte_arr );


                System.IO.File.WriteAllLines( path_arquivo , texto );
                return;


        }




        }
    
