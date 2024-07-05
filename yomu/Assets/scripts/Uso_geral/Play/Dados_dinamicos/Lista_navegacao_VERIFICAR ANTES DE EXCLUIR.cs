// using UnityEngine;
// using System;





// public  class Lista_navegacao {



//         public Lista_navegacao(){
                

//         }


//         public Ponto_nome ponto_cuidar = Ponto_nome.nada;
//         public int ponto_cuidar_para_ignorar = 10;
//         public void Checar_mudanca_interativo(Ponto_nome _nome){

//                 if(ponto_cuidar == Ponto_nome.nada) {return;}

//                 if( _nome != ponto_cuidar ) return;

//                 if( ponto_cuidar_para_ignorar != 0 ){

//                         ponto_cuidar_para_ignorar--;
//                         Debug.Log("click ignorado, restantes: " +  ponto_cuidar_para_ignorar);
//                         return;

//                 }

//                 Debug.LogError("*******************");
//                 Debug.LogError("aqui");
//                 Debug.LogError("*******************");
//                 throw new ArgumentException("aqui");



//         }

        
//         public  bool[] lista_interativos_bloqueados = new bool[100];


//         public  Interativo_nome[][][] lista_interativos_para_subtrair = new Interativo_nome[200][][];
//         public  Interativo_nome[][][] lista_interativos_para_acrescentar = new Interativo_nome[200][][];

//         public  Script_jogo_nome[] lista_scripts_por_interativo = new Script_jogo_nome[1000];
        


//         public  bool[] lista_personagens_bloqueados = new bool[50];
//         public  bool[] lista_itens_bloqueados = new bool[1000];



//         public  Script_jogo_nome[] lista_scripts_por_entrar_ponto = new Script_jogo_nome[1000];
//         public  Script_jogo_nome[] lista_scripts_por_pontos_bloqueados = new Script_jogo_nome[1000];



        

//         public string[][] lista_background_para_substituir = new string[100][];



        


//         public Interativo_nome[] Pegar_interativos_para_subtrair(  Ponto_nome _ponto_nome, int _slot, int _max_slots){

//                 return Pegar_interativos(lista_interativos_para_subtrair,  _ponto_nome ,  _slot,  _max_slots );
                

//         }

//         public Interativo_nome[] Pegar_interativos_para_acrescentar(  Ponto_nome _ponto_nome , int _slot, int _max_slots){


//                 return Pegar_interativos(lista_interativos_para_acrescentar,  _ponto_nome ,  _slot,  _max_slots );
                            
//         }

        
//         public Interativo_nome[] Pegar_interativos( Interativo_nome[][][] _lista,  Ponto_nome _ponto_nome , int _slot, int _max_slots){

//                  Checar_mudanca_interativo(_ponto_nome);


//                 int _id = (int) _ponto_nome;

                
//                 if( _lista [_id] == null) { return new Interativo_nome[0]; }



//                 if(  _lista [_id].Length != _max_slots  ){

//                         Debug.LogError("numero de slots não é igual ao que veio como valor esperado. estava: " + _lista [_id].Length + " e veio: " + _max_slots);
//                         Debug.LogError("nome do ponto: " + _ponto_nome);
//                         Debug.LogError( "provavelmente algo iniciou com o errado" );
//                         throw new ArgumentException("");

//                 }




//                 if( _lista [_id][ _slot ] == null) { return new Interativo_nome[0]; }

//                 Interativo_nome[] interativos = _lista [_id][ _slot ];


//                 int numero_de_interativos_nao_nulos = 0; 
//                 int  i = 0;

//                 for( i = 0 ; i < interativos.Length ; i++ ){

//                         if( interativos[ i ] != Interativo_nome.nada ){ numero_de_interativos_nao_nulos++; }
//                 }

//                 Interativo_nome[] retorno = new Interativo_nome[ numero_de_interativos_nao_nulos ];

//                 int  k = 0; 

//                 for( i = 0 ; i < interativos.Length; i++ ){
                        
//                         if( interativos[ i ] != Interativo_nome.nada )  {  retorno[ k ] = interativos[ i ]; k++; }

//                 }

//                 return retorno;


//         }





//     public void Mudar_background_para_substituir(  Ponto_nome _nome, Periodo_tempo _periodo_tempo , string _novo_background_nome  ){




//         int _id = (int) _nome;
//         int _periodo = (int) _periodo_tempo;

        
//             if( lista_background_para_substituir[ _id ] == null ){

//                     lista_background_para_substituir[ _id ] = new string[ _periodo + 1 ];
//             }



//             if ( lista_background_para_substituir[ _id ].Length - 1  < _periodo ){

//                     string[] novo_arr = new string[_periodo + 1];

//                     for(int i = 0;  i < lista_background_para_substituir[ _id ].Length  ;i++ ){

//                             novo_arr[i] = lista_background_para_substituir[ _id ][ i ];

//                     }

//                     lista_background_para_substituir[ _id ] = novo_arr;

//             }

//             lista_background_para_substituir[ _id ][_periodo] = _novo_background_nome;

//             return;

//     }





//     public string Pegar_background_para_substituir( Ponto_nome _nome , Periodo_tempo _periodo_tempo ){
                
                


//                 int _id = (int) _nome;
//                 int _periodo = (int) _periodo_tempo;


//                 if(lista_background_para_substituir[ _id ] == null) return null;
                
//                 if(lista_background_para_substituir[ _id ].Length - 1 < _periodo  ) return null;

//                 if(lista_background_para_substituir[ _id ][_periodo] == null) return null;


//                 return lista_background_para_substituir[ _id ][_periodo];



//     }



//     public Script_jogo_nome Pegar_script_interativo_em_espera(  Interativo_nome _interativo_nome  ){

//         int interativo_index = ( int ) _interativo_nome ;

//         return lista_scripts_por_interativo[ interativo_index ];


//     }



//     public void Adicionar_script_interativo_em_espera(  Interativo_nome _interativo_nome , Script_jogo_nome _novo_script  ){

                
//                 int interativo_index = ( int ) _interativo_nome ;

//                 if( lista_scripts_por_interativo[ interativo_index ] != Script_jogo_nome.nada ){

//                         Debug.Log("foi adicionado um script porem já tinha um. tinha: " + lista_scripts_por_interativo[ interativo_index ] );

//                 }

//                 // Posicao p = new Posicao();

//                 // p.regiao_id            =  ( int )  Regiao_nome.regiao_1 ;
//                 // p.trecho_id            =  ( int )  REGIAO_1__trecho.trecho_1 ;
//                 // p.cidade_no_trecho_id  =  ( int )  REGIAO_1__TRECHO_1__cidade_no_trecho.catedral_do_sul ;

//                 // p.zona_id              =  ( int )  CATEDRAL_DO_SUL__zona.zona_leste ;
//                 // p.local_id             =  ( int )  CATEDRAL_DO_SUL__ZONA_LESTE__local.dormitorio_feminino ;
//                 // p.area_id              =  ( int )  CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__area.nara_room;
//                 // p.ponto_id             =  ( int )  CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__ponto.corredor;

//                 lista_scripts_por_interativo[ interativo_index ] = _novo_script;

//                 return ;

//     }




















//         public void Remover_interativo_para_acrescentar( Ponto_nome _ponto_nome , int[] _slots ,  Interativo_nome _interativo  ){

//                 Modificar_interativos_REMOVER( lista_interativos_para_acrescentar, _ponto_nome ,  _slots ,  _interativo );
//                 return;

//         }

//         public void Remover_interativo_para_subtrair ( Ponto_nome _ponto_nome , int[] _slots ,  Interativo_nome _interativo  ){

//                 Modificar_interativos_REMOVER( lista_interativos_para_subtrair, _ponto_nome ,  _slots ,  _interativo );
//                 return;


                
//         }


//         public void Modificar_interativos_REMOVER ( Interativo_nome[][][] _lista,   Ponto_nome _ponto_nome , int[] _slots ,  Interativo_nome _interativo  ){


//                         if( _interativo == Interativo_nome.nada ){

//                                 Debug.LogError("nao era para vir aqui");
//                                 throw new ArgumentException("");

//                         }

//                         int index = (int) _ponto_nome;
//                         int numero_slots = _slots.Length;

                        
//                         if( _lista[ index ] == null ){ return ; }


//                         if(   numero_slots !=  _lista[ index ].Length ) {
                                
//                                 int slots_na_lista = _lista[ index ].Length;
//                                 throw new ArgumentException("Mudar_interativos_para_acrescentar teve slots diferentes, tinha: " + slots_na_lista + ". e veio para alterar como: " + numero_slots );
                                
//                         }


//                         for(  int slot = 0 ; slot < numero_slots ; slot++  ){

//                                 bool tem_que_modificar =  ( _slots[ slot ] == 1 ) ;

//                                 if(  tem_que_modificar ){   

//                                         Interativo_nome[] interativos = _lista[ index ][ slot ];

//                                         int numero_interativos = interativos.Length;

//                                         for(  int i = 0 ;  i < numero_interativos   ; i++){

//                                                 if  ( interativos [ i ] == _interativo ){ interativos [ i ] = Interativo_nome.nada ; break;}

//                                         } 



//                                 }

//                                 continue;

//                         }

//                         return;


//         }



//         public void Adicionar_interativo_para_acrescentar( Ponto_nome _ponto_nome , int[] _slots ,  Interativo_nome _interativo  ){

//                 Modificar_interativos_ADICIONAR( lista_interativos_para_acrescentar, _ponto_nome ,  _slots ,  _interativo );
//                 return;

//         }

//         public void Adicionar_interativo_para_subtrair ( Ponto_nome _ponto_nome , int[] _slots ,  Interativo_nome _interativo  ){

//                 Modificar_interativos_ADICIONAR( lista_interativos_para_subtrair, _ponto_nome ,  _slots ,  _interativo );
//                 return;


                
//         }


//         public void Modificar_interativos_ADICIONAR ( Interativo_nome[][][] _lista,   Ponto_nome _ponto_nome , int[] _slots ,  Interativo_nome _interativo  ){


//                         int index = (int) _ponto_nome;
//                         int numero_slots = _slots.Length;

                        
//                         if( _lista[ index ] == null ){

//                                 _lista[ index ] = new Interativo_nome[ _slots.Length ][];

//                                 for(   int n = 0 ;n < numero_slots ; n++ ){

//                                         bool tem_que_trocar_slot = ( _slots[n] == 1 );

//                                         if( tem_que_trocar_slot ){  

//                                                 _lista[ index ][ n ] = new Interativo_nome[]{

//                                                         _interativo,
//                                                         Interativo_nome.nada,
//                                                         Interativo_nome.nada,
//                                                         Interativo_nome.nada,
//                                                         Interativo_nome.nada

//                                                 }; 

//                                                 continue;

//                                         }

//                                         _lista[ index ][ n ] = new Interativo_nome[ 0 ]; 

//                                 }

//                                 return;
//                         }


//                         if(   numero_slots !=  _lista[ index ].Length ) {
                                
//                                 int slots_na_lista = _lista[ index ].Length;
//                                 throw new ArgumentException("Mudar_interativos_para_acrescentar teve slots diferentes, tinha: " + slots_na_lista + ". e veio para alterar como: " + numero_slots );
                                
//                         }



//                         for(  int slot = 0 ; slot < numero_slots ; slot++  ){

//                                 bool tem_que_modificar =  ( _slots[ slot ] == 1 ) ;

//                                 if(  tem_que_modificar ){   

//                                         Interativo_nome[] interativos = _lista[ index ][ slot ];

//                                         int numero_interativos = interativos.Length;

//                                         int i = 0;

//                                         for(  i = 0 ;  i < numero_interativos   ; i++){
//                                                                                                                         //           yes
//                                                 if  ( interativos [ i ] == Interativo_nome.nada ){ interativos [ i ] = _interativo ; i--; break;}

//                                         }


//                                         bool nao_tem_livre = ( i == interativos.Length ) ;

//                                         if(  nao_tem_livre  ) {

//                                                 Interativo_nome[] novo_interativos = new Interativo_nome[ numero_interativos + 5 ];

//                                                 for( i = 0 ; i < numero_interativos  ;i++){

//                                                         novo_interativos[ i ] = interativos[ i ];

//                                                 }

//                                                 novo_interativos[ i + 1 ] = _interativo;
//                                                 continue;

//                                         }

//                                         // vai ter que aumentar 



//                                 }

//                                 continue;

//                         }

//                         return;




//         }


//                 /*

//                 slots : [    x   ,    y     ]

//                 {  manha dia tarde noite madrugada  }


//                 a espada magica => [  0 , 0  , 1  ,  1  ,  0  ]   
//                 */



//         public void Mudar_interativos( Interativo_nome[][][] _lista,   Ponto_nome _ponto_nome , int[] _slots ,  Interativo_nome[] _interativos   ){


//                         int index = (int) _ponto_nome;
//                         int numero_slots = _slots.Length;

//                         if( _interativos == null  ){

//                                 _lista[ index ] = null;
//                                 return;

//                         }

                        
//                         if( _lista[ index ] == null ){

//                                 _lista[ index ] = new Interativo_nome[ _slots.Length ][];

//                                 for(   int n = 0 ;n < numero_slots ; n++ ){

//                                         bool tem_que_trocar_slot = ( _slots[n] == 1 );

//                                         if( tem_que_trocar_slot ){  _lista[ index ][ n ] = _interativos; continue;}

//                                         _lista[ index ][ n ] = new Interativo_nome[ 0 ]; 

//                                 }

//                                 return;
//                         }


//                         if(   numero_slots !=  _lista[ index ].Length ) {
                                
//                                 int slots_na_lista = _lista[ index ].Length;
//                                 throw new ArgumentException("Mudar_interativos_para_acrescentar teve slots diferentes, tinha: " + slots_na_lista + ". e veio para alterar como: " + numero_slots );
                                
//                         }



//                         for(  int i = 0 ; i < numero_slots ; i++  ){

//                                 if(  _slots[i] == 1 ){   _lista[ index ][ i ] = _interativos; continue; }
//                                 _lista[ index ][ i ]  = new Interativo_nome[0];

//                         }

//                         return;


//         }



//         public  void Mudar_interativos_para_acrescentar ( Ponto_nome _ponto_nome , int[] _slots ,  Interativo_nome[] _interativos ){

//                 Mudar_interativos(   lista_interativos_para_acrescentar,   _ponto_nome , _slots , _interativos   );
//                 return;

//         }


//         public  void Mudar_interativos_para_subtrair(  Ponto_nome _ponto_nome , int[] _slots ,  Interativo_nome[] _interativos){

//                 Mudar_interativos(   lista_interativos_para_subtrair,   _ponto_nome ,  _slots ,   _interativos   );
//                 return;

//         }










// public void Zerar(){

//         lista_interativos_para_subtrair = new Interativo_nome[2000][][] ;
//         lista_interativos_para_acrescentar = new Interativo_nome[2000][][] ;

        
//         lista_personagens_bloqueados = new bool[50];
//         lista_itens_bloqueados = new bool[1000];

//         lista_scripts_por_pontos_bloqueados = new Script_jogo_nome[1000];
//         lista_scripts_por_entrar_ponto = new Script_jogo_nome[1000];

//         return;
// }




        




// }