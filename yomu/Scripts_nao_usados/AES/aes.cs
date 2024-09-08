using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class Aes_teste {


        public static byte[] ativar_PNG(  string imagem_nome, byte[] iv  , byte[] key  ){

                string path = "C:\\Users\\User\\Desktop\\coisas\\site\\container\\" + imagem_nome ;

                string png_path = path + ".png";
                string png_dat = path + ".dat";


                byte[] png = System.IO.File.ReadAllBytes( png_path );


                byte[] encrypted = new byte[ png.Length ];

                Aes aesAlg = Aes.Create();
                
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor( aesAlg.Key, aesAlg.IV );

                MemoryStream msEncrypt = new MemoryStream();
                CryptoStream csEncrypt = new CryptoStream( msEncrypt, encryptor, CryptoStreamMode.Write );
                BinaryWriter bn_writer = new BinaryWriter( csEncrypt );

                int block = 0;

                for( int p = 0 ; p < png.Length; p++ ){

                    block = ( block + 1 ) % 16 ;
                    bn_writer.Write( png[ p ] );


                }

                if( block  != 0 )
                    {
                        for( ; block < 32 ; block++ ){
                            bn_writer.Write( 0 );
                        }
                    }


                byte[] retorno = msEncrypt.ToArray();
                int lg =  retorno.Length;
                
                System.IO.File.WriteAllBytes( png_dat ,  retorno );

                return msEncrypt.ToArray();


        }






        public static byte[] descompactar_PNG(  string imagem_nome, byte[] iv  , byte[] key  ){



            string path = "C:\\Users\\User\\Desktop\\coisas\\site\\container\\" + imagem_nome ;

            string png_path = path + ".png";
            string png_dat = path + ".dat";


            byte[] encrypted = System.IO.File.ReadAllBytes( png_dat );
            byte[] png_retorno  = new byte[ encrypted.Length ];

            Aes aesAlg = Aes.Create();
            
            aesAlg.Key = key;
            aesAlg.IV = iv;

            

            ICryptoTransform encryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            MemoryStream msEncrypt = new MemoryStream( encrypted );
            CryptoStream csEncrypt = new CryptoStream( msEncrypt, encryptor, CryptoStreamMode.Read );
            BinaryReader bn_writer = new BinaryReader( csEncrypt );

            int p = 0;

            
                // acho que se copiar a mais nao vai dar em nada por conta dos chunkcs
                for( p = 0 ; p < png_retorno.Length ; p++ ){

                    png_retorno[ p ] =  bn_writer.ReadByte();

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

                return retorno;


        }


        public static  void Pegar_key_E_IV(){


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
    
