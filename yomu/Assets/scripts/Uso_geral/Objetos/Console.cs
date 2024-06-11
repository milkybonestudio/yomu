using System.Threading;
using UnityEngine;



// ** tem que direcionar referentes ao nomes das threads 




public static class Console {



        public static int index_atual = 0;
        public static string[] logs = new string[ 50 ];
        public static int[] logs_tipos = new int[ 50 ];

        public static int index_atual_m = 0;
        public static string[] logs_m = new string[ 50 ];
        public static int[] logs_tipos_m = new int[ 50 ];

        public static void Log( string _txt  ){

                
                string thread_name = Thread.CurrentThread.Name;

                if( thread_name == "Main" ){

                        if( index_atual == logs.Length )
                        { Aumentar_length_arr(); }

                        logs[ index_atual ] = _txt;
                        logs_tipos[ index_atual ] = 1;
                        index_atual++;
                        return;

                }

                // mult
                if( index_atual_m == logs_m.Length )
                { Aumentar_length_arr_m(); }

                logs_m[ index_atual ] = _txt;
                logs_tipos_m[ index_atual ] = 1;
                index_atual_m++;
                
                return;


        }

        public static void LogError( string _txt ){


                if( index_atual == logs.Length )
                    { Aumentar_length_arr(); }

                logs[ index_atual ] = _txt;
                logs_tipos[ index_atual ] = -1;
                index_atual++;

                return;


        }

        public static void Update(){

                for( int log_index = 0 ; log_index < logs.Length ; log_index++ ){
                    
                        string texto = logs[ log_index ];
                        int tipo = logs_tipos[ log_index ];
                        if( texto == null )
                            { break; }

                        logs[ log_index ] = null;
                        logs_tipos[ log_index ] = 0;
                        if(tipo == 1 )
                                {
                                        Debug.Log( texto );
                                }
                                else
                                {
                                        Debug.LogError( texto );
                                }
                        
                        continue;

                }

                index_atual = 0;

                return;
            
        }



        

        public static void Aumentar_length_arr_m(){


                string[] novo_arr_m = new string [ logs_m.Length + 10 ];
                int[] novo_arr_tipos_m = new int [ logs_m.Length + 10 ];

                for( int str = 0 ; str < logs_m.Length ; str ++ ){

                    novo_arr_m[ str ] = logs_m[ str ];
                    novo_arr_tipos_m[ str ] = logs_tipos_m[ str ];

                }

                logs_m = novo_arr_m;
                logs_tipos_m = novo_arr_tipos_m;

                return;

        }



        public static void Aumentar_length_arr(){


                string[] novo_arr = new string [ logs.Length + 10 ];
                int[] novo_arr_tipos = new int [ logs.Length + 10 ];

                for( int str = 0 ; str < logs.Length ; str ++ ){

                    novo_arr[ str ] = logs[ str ];
                    novo_arr_tipos[ str ] = logs_tipos[ str ];

                }

                logs = novo_arr;
                logs_tipos = novo_arr_tipos;

                return;

        }

        public static void Resetar(){

                index_atual = 0;
                logs = new string[ 50 ];
                return;

        }

}