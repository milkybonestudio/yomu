using System; 
using UnityEngine;




public class Controlador_cache {


        public static Controlador_cache instancia;
        public static Controlador_cache Pegar_instancia(){ return instancia; }
        public static Controlador_cache Construir(){ instancia = new Controlador_cache(); return instancia;}




        public Controlador_cache(){

                dados = new System.Object[ numero_inicial ];                
                slots_locks = new bool [ numero_inicial ] ;
                slots_senhas = new int[ numero_inicial ] ;


        }


        public Gerador_senhas gerador_senhas = new Gerador_senhas();
        
        int quantidade_para_aumentar = 10 ;
        int numero_inicial = 10;


        public System.Object[] dados;
        public bool[]   slots_locks ;
        public int[]    slots_senhas ;


        public void Update(){

            /*  
                
                quando o item for bloqueado ele j'vai excluir a imagem então não precisa ficar checando. Mesmo se a segunda thread ler os dados antes de mudar. Pois mesmo que ela passe o pointer da sprite
                1 instrucao antes a instrucao vai ser alterada para null quando a main thread estive mudando. 
               
            */


        }




        public System.Object Pegar_dados( Chave_cache _chave ){


                int slot = _chave.slot;
                int senha = _chave.senha;
                                
                bool slot_liberado =  slots_locks [ slot ] ;

                if( !( slot_liberado ) ) { Debug.Log("slot " + slot + " nao estava liberado") ;return; }

                int senha_real = slots_senhas[ slot ] ;

                bool senha_aceita = ( senha == senha_real ) ;

                if( !( senha_aceita ) ) { Debug.Log("slot " + slot + " nao foi aceito senha" + senha + " | " + senha_real) ; return; }

                return dados[ slot ];





        }


        public void Adicionar_dados (  Chave_cache _chave, System.Object _objeto  ){




                int slot = _chave.slot;
                int senha = _chave.senha;

                bool slot_liberado =  slots_locks [ slot ] ;

                if( !( slot_liberado ) ) { Debug.Log("slot " + slot + " nao estava liberado") ;return; }

                int senha_real = slots_senhas[ slot ] ;

                bool senha_aceita = ( senha == senha_real ) ;

                if( !( senha_aceita ) ) { Debug.Log("slot " + slot + " nao foi aceito senha" + senha + " | " + senha_real) ; return; }


                Debug.Log("vai adicionar objeto no slot " + slot);

                dados[ slot ] = _objeto;
                return;


        }


        public void Excluir_dado( Chave_cache _chave ){

                int slot = _chave.slot;
                int senha = _chave.senha;

                if( slots_senhas[ slot ] != senha ) {
                    
                    Debug.Log("nao passou em senha no excluir dados. Senha que veio: " + senha + " senha que precisava : " + slots_senhas[ slot ] );
                    return;

                }

                    Debug.Log("vai excluir dados do slot: " + slot );

                    slots_locks[ slot ] = false;
                    slots_senhas[ slot ] = 0;
                    dados[ slot ] = null;

                return;

        }

        public void Excluir_dados( Chave_cache[] _chaves ){


                for( int chave_index = 0; chave_index < _chaves.Length ;chave_index++ ){

                        Chave_cache chave = _chaves[ chave_index ];

                        int slot = chave.slot;
                        int senha = chave.senha;

                        if( slots_senhas[ slot ] != senha ) {
                        
                        Debug.Log("nao passou em senha no excluir dados. Senha que veio: " + senha + " senha que precisava : " + slots_senhas[ slot ] );
                        return;

                        }

                        Debug.Log("vai excluir dados do slot: " + slot );

                        slots_locks[ slot ] = false;
                        slots_senhas[ slot ] = 0;
                        dados[ slot ] = null;
                }

                return;


        }

        public Chave_cache Pedir_slot (){


                Chave_cache chave_retorno = new Chave_cache();

                int index_lock_disponivel  = BOOL.Pegar_index_false( slots_locks );

                if( index_lock_disponivel == -1 ) { 

                        index_lock_disponivel = slots_locks.Length;

                        OBJECT.Aumentar_length_array( ref dados, quantidade_para_aumentar );
                        BOOL.Aumentar_length_array( ref slots_locks , quantidade_para_aumentar );
                        INT.Aumentar_length_array( ref slots_senhas , quantidade_para_aumentar );

                }

                int nova_senha  = gerador_senhas.Pegar_nova_senha();

                slots_locks[ index_lock_disponivel ] = true;
                slots_senhas[ index_lock_disponivel ] = nova_senha;

                chave_retorno.slot = index_lock_disponivel;
                chave_retorno.senha = nova_senha;


                return chave_retorno;

        }


}

