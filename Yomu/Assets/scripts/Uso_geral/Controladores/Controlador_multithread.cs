using System;
using System.Threading;
using UnityEngine;



public class Controlador_multithread  {


        public static Controlador_multithread instancia;
        public static Controlador_multithread Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Controlador_multithread")) { instancia = new Controlador_multithread(); instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Controlador_multithread(); instancia.Iniciar(); }
            return instancia;

        } 


        public void Iniciar(){}

        public int quantidade_para_adicionar = 10;
        public long tempo_maximo_em_songle_thread_ms = 2L;
        public int numero_maximo_de_fracionamento = 15;

        public Thread thread = null;
        public CancellationTokenSource token_para_cancelar = new CancellationTokenSource();

        public Task_req[] tasks_em_espera_iniciar = new Task_req [ 20 ];
        public Task_req[] tasks_prontas_para_finalizar = new Task_req [ 20 ];


        System.Diagnostics.Stopwatch relogio = new System.Diagnostics.Stopwatch();



        public void Criar_thread() {    
            
                Debug.Log("vai criar a nova thread");
                if( thread == null  ){ 

                    finalizar_thread = false;
                    thread = new Thread( Thread_secundaria_update ); 
                    thread.Start();

                }
                return;

        }


        public void Matar_thread(){

            Debug.Log("veio mar thread");
            thread = null;
            finalizar_thread = true ;
            return;
        }

        public static bool jogo_ativo = false;
        public bool finalizar_thread = false;


        public void Update(){


                relogio.Start();



                while ( true ){


                        int index_com_maior_prioridade = Pegar_index_maior_prioridade( tasks_prontas_para_finalizar );

                        if( index_com_maior_prioridade == -1 ) {
                                
                                relogio.Reset();
                                return;
                        }


                        Task_req task = tasks_prontas_para_finalizar[ index_com_maior_prioridade ];
                        
                        if( ! ( task.pode_executar ) ){ tasks_prontas_para_finalizar[ index_com_maior_prioridade ] = null; continue;} 

                        if( task.tem_fracionado ){

                                for( int  i = 0 ; i < numero_maximo_de_fracionamento ; i++ ){

                                        task.Ativar_fracionado();
                                        if( ! ( Pode_continuar() ) ) { return; }
                                        if( ! ( task.tem_fracionado ) ) { break;}

                                }

                        }

                        task.fn_finalizar( task ); 
                        tasks_prontas_para_finalizar[ index_com_maior_prioridade ] = null;

                        if( ! ( Pode_continuar() ) ) { return; }
                
                }
                





                bool Pode_continuar(){

                        long tempo =  relogio.ElapsedMilliseconds ;

                        if( tempo > tempo_maximo_em_songle_thread_ms ){

                                Debug.Log("passou do tempo");

                                relogio.Reset();
                                return false;

                        }

                        return true;


                }


        }



        

        public void Thread_secundaria_update ( ){





                //  esse update não se importa com a ordem ele só chama a funcao 

                // se a funcao não for iniciada e a senha da task estiver bloqueada pode só excluir o objeto



                while( true ){

                        Debug.Log("veio");

                        if( (!jogo_ativo ) || finalizar_thread ){ return;}


                        int index_com_maior_prioridade = Pegar_index_maior_prioridade( tasks_em_espera_iniciar );

                        if( index_com_maior_prioridade == -1 ){ Matar_thread(); return; }

                        Task_req task_atual = tasks_em_espera_iniciar [ index_com_maior_prioridade ];
                        
                        bool pode_executar = task_atual.pode_executar;

                        if( pode_executar ){

                                Debug.Log("vai executar na thread secundaria a task " + task_atual.nome);
                                task_atual.fn_iniciar( task_atual ) ;
                                tasks_prontas_para_finalizar [ index_com_maior_prioridade ] = task_atual;
                                

                        }

                        tasks_em_espera_iniciar [ index_com_maior_prioridade ] = null;

                }





        }

        public int Pegar_index_maior_prioridade( Task_req[] _arr  ){

                // TODOS NULL
                int retorno = -1;

                for( int task_index = 0 ; task_index < _arr.Length ; task_index++ ){

                        Task_req task = _arr[ task_index ];

                        if( task == null ){ continue; }

                        int prioridade_task = task.prioridade;

                        #if UNITY_EDITOR 

                        if( prioridade_task < 0 ){ throw new ArgumentException("prioridade de task negativa");}

                        #endif 

                        // se tiver [ 2 ,  2  ] ele vai sempre carregar em ordem

                        if( prioridade_task > retorno ) { retorno = task_index; }


                }

                return retorno;

        }

        public void Adicionar_task( Task_req _nova_task ) {


                // se encontrar vira false 
                bool precisa_aumentar = true;
                // se nao achar o index fica como length
                int task_index = 0;

                for( task_index = 0 ; task_index < tasks_em_espera_iniciar.Length  ; task_index++ ){


                        if( tasks_em_espera_iniciar[ task_index ] == null ){

                                precisa_aumentar = false;
                                break;
                
                        }

                }

                if( precisa_aumentar ) { Aumentar_task_lista(); }

                tasks_em_espera_iniciar[ task_index ] = _nova_task;

                Debug.Log("task foi adicionada no index: " + task_index.ToString());


                Criar_thread();

                return;

        }


        public void Aumentar_task_lista(){


                int quantidade_antiga = tasks_em_espera_iniciar.Length;
                int nova_quantidade = ( quantidade_antiga + quantidade_para_adicionar );
                Task_req[] novo_tasks_prontos_para_finalizar = new Task_req[ nova_quantidade ];
                Task_req[] novo_tasks_em_espera_iniciar = new Task_req[ nova_quantidade ];

                for( int i = 0 ; i < quantidade_antiga ; i++ ){

                        novo_tasks_prontos_para_finalizar[ i ] = tasks_prontas_para_finalizar[ i ];
                        novo_tasks_em_espera_iniciar[ i ] =  tasks_em_espera_iniciar[ i ] ;

                }

                tasks_em_espera_iniciar = novo_tasks_em_espera_iniciar;
                tasks_prontas_para_finalizar = novo_tasks_prontos_para_finalizar;
                Debug.Log("foi aumentado o numero de tasks de " + quantidade_antiga.ToString() + " para " + nova_quantidade.ToString() );

                return;

        }







}

