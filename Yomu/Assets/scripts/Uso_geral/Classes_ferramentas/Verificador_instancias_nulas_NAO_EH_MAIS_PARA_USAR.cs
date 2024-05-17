using  System;








//   ** o motivo que existia era para garantir que sempre que chamasse Class.Pegar_instancia() ele criasse um novo objeto entre as runs 
//      ele nao resetas as propriedades estaticas entre as runs, entao essa classe forçava semrpe a resetar. Mas era um jeito meio merda




// public static class Verificador_instancias_nulas {


//         public static  string[] nomes = null;
//         public static  void Ativar(){nomes = new string[200];}
//         public static  void Liberar(){nomes = null;}

//         public static  bool  Verificar_se_pode_criar_objetos(string _nome){

        
//             for(int i = 0  ;  i < nomes.Length ;  i++){

//                 if(nomes[i] == null){

//                     nomes[i] = _nome;
//                     return true;

//                 }
                
//                 if(nomes[i] == _nome) return false;

//             }

//             throw new ArgumentException("nomes em Verificador_instancias_nulas passou do limite. limite atual: " + nomes.Length);


//         }


// }

