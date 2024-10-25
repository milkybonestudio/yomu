using System;
using System.IO;
using System.Diagnostics;

public static class Images_encoder {

        public static string default_compress_name = "_COMPRESS";

        public static void Encode_iamge( string _folder_image, string _image_name ){

                
                string image_path = Path.Combine( _folder_image, _image_name + ".png" );

                if( !!!( System.IO.File.Exists( image_path ) ) )
                    { throw new Exception( $"File { _image_name } dosnt exists in the path { image_path }" ); }
                

                string compress_image_path = Path.Combine( _folder_image, ( _image_name + default_compress_name + ".webp" ) );
                

                // --- CREATE PROCESS

                Process process = new Process();

                    process.StartInfo.FileName = "ffmpeg"; 
                    process.StartInfo.Arguments = $"-i \"{ image_path }\" -quality 75 \"{ compress_image_path }\"";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;

                try {

                        process.Start();
                        // Wait for the process to finish
                        process.WaitForExit();


                }
                catch ( Exception e )
                {
                    Console.Log ( $"Error: { e.Message }" );
                }


        }

    
}
