







// public class a {



//         int paths_por_slot = 500;
    
//         public string[][] paths_array_2d;
        
//         public string Pegar_path( int numero ){

//                 int slot = numero / paths_por_slot;

//                 if( paths_array_2d[ slot ] == null ){

//                     string paths_para_carregar = "path_geral/"  + slot.ToString() + ".txt";
                    
//                     // ou Leitor_arquivo();
//                     paths_array_2d[ slot ] = System.IO.File.ReadAllLines( paths_para_carregar );
                
//                 }

//                 int linha_com_o_path = numero - ( paths_por_slot * slot  );
//                 string path = paths_array_2d[ slot ][ linha_com_o_path ];

//                 return path;


//                 string path = Dados.Pegar_path (  

//                     _paths_por_slot : 500,
//                     _paths_array_2d : null;
//                     _numero : 0
//                     _path_containers: "path/"
                    
//                 );
                                
//         }


//     public class sDados_gerais_carta{

//         public string descricao = "";
//         public Rank_carta rank = Rank_carta.G;
//         public 


//     }


//     public class Cartas_gerais_leitor {



//             public string pegar_path( int _numero ){




//                     switch( _numero ){

//                         case 1 : return "a";
//                         case 2 : return "b";
//                         default: return null;

//                     }











//             }


//             public string Pegar_path( int _paths_por_slot, string[][] _paths_array_2d  , int _numero , string _generic_path ){ 


//                         int slot = _numero / _paths_por_slot;

//                         if( paths_array_2d[ slot ] == null ){

//                             string paths_para_carregar = _generic_path  + slot.ToString() + ".txt";
                            
//                             // ou Leitor_arquivo();
//                             _paths_array_2d[ slot ] = System.IO.File.ReadAllLines( paths_para_carregar );
                        
//                         }


//                         int linha_com_o_path = numero - ( _paths_por_slot * slot  );
//                         string path = _paths_array_2d[ slot ][ linha_com_o_path ];

//                         return path;
                

//             }



//     }










//         public string Pegar_path(  int numero  ){


//                 switch( numero ){


//                     case 1 : return "";
//                     case 2 : return "";
//                     case 3 : return "";

//                 }

//                 return null;

//         }

        




// }