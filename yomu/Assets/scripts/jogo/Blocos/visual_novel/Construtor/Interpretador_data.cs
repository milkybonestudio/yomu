using System;
using UnityEngine;


/*
sempreque passar int para char tem que  somar 48. nos caracteres anteriores tem caracteres de quebra de linha. nao é bom
*/



public class Interpretador_data {



        public char auto_atual_para_set = 'f';
        public bool bloquear_set_ja_foi_ativado = false;


        public bool personagens_foram_colocados = false;

        public int[] linhas_localizador_cenas = null;

        public int cena_em_analise = 0;

        //  para reduzir tamanho



        public string[][] personagens_images_nomes = null;
        public string[] nomes_personagens = null;
        public string[] apelidos = null;



        //  logica



        public string[] perguntas = new string[ 10 ];
        public string[][] possiveis_respostas_arr = new string[10][]; // arr[ pergunta ] [ possivel resposta ];



        public string[] pointer_id_str = new string[ 20 ];// uso interno
        public int[] pointer_id_cena_index_arr = new int [ 20 ]; // cria no final 




        public Interpretador_data( string _texto_raw  ){

        
            this.linhas_localizador_cenas = Pegar_linhas_localizador( _texto_raw );

        }


        public void Receber_personagens_set( string _line_set ){


                string[] linhas_itens =    Manipulador_texto.Trim_linha( _line_set );


                int index_final_personagens = 0;


                for(  int index = 0  ;  index < linhas_itens.Length   ;   index++  ){


                        char caracter_em_verificacao = linhas_itens[ index ][0];

                     //   Debug.Log("caracter_em_verificacao: " + caracter_em_verificacao);

                        if( caracter_em_verificacao == '/' ) {index_final_personagens = index - 1; break;}
                        if(index == (linhas_itens.Length - 1 )){index_final_personagens = index; break;}


                }

                // Debug.Log("index_final_personagens: " + index_final_personagens);


                string[] personagens_linhas = Manipulador_texto.Separar_linhas ( linhas: linhas_itens , index_inicial: 1 , index_final: index_final_personagens ) ;

                this.nomes_personagens = new string[ personagens_linhas.Length ]; 

                int numero_personagens = this.nomes_personagens.Length;
                string valor_que_vai_ser_ignorado_no_leitor = "0";
                this.personagens_images_nomes = new string[numero_personagens][];


                for( int i = 0 ; i < numero_personagens  ; i++ ){

                        this.nomes_personagens[ i ] = personagens_linhas[ i ].Split(":")[0].Trim();

                        this.personagens_images_nomes[ i ] = new string[ 20 ];
                        this.personagens_images_nomes[ i ] [0] = valor_que_vai_ser_ignorado_no_leitor;

                }

                
                return;


      // colocar_e criar_dados:
                
                


        }

        

        public int Pegar_pergunta_index( string _nome_pergunta ){

                for( int i = 0 ;  i < this.perguntas.Length ;i++ ){

                        if( this.perguntas[ i ] == _nome_pergunta ) {return i;}

                }

                throw new ArgumentException("Pergunta nao foi encontrada. Pergunta: " + _nome_pergunta);

        }


        public int Adicionar_pergunta( string _pergunta_nome  , int _numero_de_possiveis_resposta  ){

                int numero_perguntas_atuais_maxima = this.perguntas.Length;
                for(  int i = 0 ; i < numero_perguntas_atuais_maxima; i++ ){

                        if(   this.perguntas[ i ]  == null  ){

                                this.possiveis_respostas_arr[ i ] = new string[ _numero_de_possiveis_resposta ];
                                this.perguntas[ i ] = _pergunta_nome;
                                return i;

                        }

                        if( this.perguntas[ i ] == _pergunta_nome ){
                                throw new ArgumentException("veio 2 perguntas iguais. veio: " + _pergunta_nome );
                        }

                        continue;

                }

                throw new ArgumentException("numero de perguntas passou dos limites");

        }



        public void Adicionar_possivel_resposta(string _pergunta, string _possivel_resposta , int index_possivel_resposta = -1){

                int  index =  Pegar_pergunta_index( _pergunta );

                if( index_possivel_resposta == -1  ){

                        string[] str_arr = this.possiveis_respostas_arr[ index ];

                        for(int i = 0 ; i < str_arr.Length ;i++) {

                                if( str_arr[ i ] == null ) str_arr[ i ] = _possivel_resposta;
                        }


                        return;

                }

                this.possiveis_respostas_arr[ index ][ index_possivel_resposta ] = _possivel_resposta;
                return;

        }






        public int Pegar_index_possivel_resposta( string _pergunta   , string _possivel_resposta ){

                int pergunta_index =  Pegar_pergunta_index( _pergunta );


                string[] possiveis_respostas = this.possiveis_respostas_arr[ pergunta_index ];

                for( int possivel_resposta_index = 0 ;  possivel_resposta_index < possiveis_respostas.Length   ; possivel_resposta_index++ ){


                        if( possiveis_respostas[  possivel_resposta_index  ] == _possivel_resposta ) {return possivel_resposta_index; }


                }

                Debug.LogError("possivel resposta nao foi encontrada na pergunta " + _pergunta + " . Tentrou pegar a resposta: " + _possivel_resposta);
                throw new ArgumentException("");


        }



                public void Adicionar_pointer( string _pointer_nome ){

                int numero_maximo_atual = this.pointer_id_str.Length;

                for ( int i = 0;  i <  numero_maximo_atual ;i++){

                        if( this.pointer_id_str[ i ] == null ){  this.pointer_id_str[ i ] = _pointer_nome; return; }
                        if( this.pointer_id_str[ i ] == _pointer_nome ){ throw new ArgumentException("2 pointers com o mesmo nome"); }
                        

                }

                throw new ArgumentException("numero pointers passou dos limites");



        }


        public bool pointers_trancados = false;





        public void Colocar_pointer( string _pointer_nome ){

                
                for(int i = 0;  i < pointer_id_str.Length ;i++){

                        
                        if( pointer_id_str[ i ] == _pointer_nome ) { 

                                throw new ArgumentException("2 pointers com o mesmo nome : "  + _pointer_nome);

                        }
                        if( pointer_id_str[ i ] == null ){

                                pointer_id_str[ i ] = _pointer_nome;
                                return;

                        }

                        
                        continue;
                
                }

                int index_atual = pointer_id_str.Length; // vai ter que adicioanr mais espaço

                string[] novo_pointer_id_str = new string[ index_atual + 5 ];
                int[] novo_pointer_id_cena_index = new int[ index_atual + 5 ];

                for( int k = 0 ;  k < index_atual ; k++ ){
                        
                        novo_pointer_id_str[ k ] = pointer_id_str[ k ];

                }

                novo_pointer_id_str[ index_atual ]  = _pointer_nome;

                this.pointer_id_str =  novo_pointer_id_str;
                this.pointer_id_cena_index_arr = novo_pointer_id_cena_index;

                

                return;






        }


        public int Pegar_index_pointer ( string _nome_id ){

        
                for(int i = 0;  i < pointer_id_str.Length ;i++){

                        
                        if( pointer_id_str[ i ] == _nome_id ) { 
                                
                                return i; 

                        }
                        if( pointer_id_str[ i ] == null ){

                                throw new ArgumentException("pointer nao foi achado. pointer: " + _nome_id);
                        }

                        
                        continue;
                
                }

                throw new ArgumentException("pointer nao foi achado. pointer: " + _nome_id);

       

        }


        public int[] Pegar_linhas_localizador( string _texto_completo ) {



                    int[] retorno = new int[10000]; 
                    int cena_atual = 0;
                    int linha_atual = 1;
                    int numero_caracteres = _texto_completo.Length;
                    for( int index_char = 0 ; index_char < numero_caracteres ; index_char++     ){
                            char caracter = _texto_completo[ index_char ];
                            if(caracter == '[') {
                                retorno [ cena_atual ] = linha_atual;
                                cena_atual++;
                            } 
                            if( caracter == '\r' ){
                                index_char++;
                                caracter = _texto_completo[ index_char ];
                                if(caracter == '\n'){ linha_atual++;}
                            }
                    }
                    return  retorno;
            }





        public int Pegar_index_imagem_E_adicionar( string _nome_imagem , int  index_personagem  , string _personagem = null ){


                if( _personagem != null ){  index_personagem = this.Pegar_index_personagem( _personagem ); }
                
                string[] personagem_imagens_arr = this.personagens_images_nomes[ index_personagem ];


                string imagem_atual = null;
                int numero_imagens = personagem_imagens_arr.Length;
            
                for( int index_atual = 0 ; index_atual < numero_imagens; index_atual++){

                        imagem_atual = personagem_imagens_arr[ index_atual ];

                        bool precisa_adicionar = imagem_atual == null;

                        if( precisa_adicionar ) { 
                                
                                personagem_imagens_arr[ index_atual ] = _nome_imagem;

                                if( (personagem_imagens_arr.Length - 1) ==  index_atual ){

                                        string[] novo_arr = new string[ personagem_imagens_arr.Length + 10];

                                        for( int k = 0 ;  k < personagem_imagens_arr.Length ; k++ ) {

                                                novo_arr[k] = personagem_imagens_arr[k];
                                                
                                        }

                                        this.personagens_images_nomes[ index_personagem ] = novo_arr;

                                }
                                return index_atual ;

                        }
                    
                        if(  imagem_atual.Length == _nome_imagem.Length  ){

                                if( imagem_atual == _nome_imagem ){

                                      return index_atual;

                                }

                        }

                }

                throw new ArgumentException("iamgens no personagem: " + _personagem + "passou do limite. tem que fazer uma fn para aumentar o limite depois");

        }


        public int Pegar_index_personagem( string _personagem ){

            int numero_personagens = this.nomes_personagens.Length;
            string personagem = null;

            for( int index_atual = 0 ; index_atual < numero_personagens; index_atual++){

                    personagem = this.nomes_personagens[ index_atual ];

                
                    if(  personagem.Length == _personagem.Length  ){

                            if(personagem == _personagem){

                                return index_atual;

                            }

                    }

            }


            switch( _personagem ){

                
                case "god" : return ( int ) Visual_novel_extras.god;
                case "developer" : return ( int ) Visual_novel_extras.developer;
                case "game" : return ( int ) Visual_novel_extras.game;
                case "narrator" : return ( int ) Visual_novel_extras.narrator;
                

            }




            Debug.LogError("personagem nao encontrado: " + _personagem + ". na linha: " + this.linhas_localizador_cenas[ this.cena_em_analise ] + ". veio : " + _personagem );

            throw new ArgumentException("");
            

        }




///


}



