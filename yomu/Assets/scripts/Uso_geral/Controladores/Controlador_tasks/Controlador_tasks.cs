using System;
using System.Threading;
using UnityEngine;
using System.Collections.Concurrent;



public class Controlador_tasks  {


        public static Controlador_tasks instancia;
        public static Controlador_tasks Pegar_instancia(){ return instancia; }
        public static Controlador_tasks Construir(){ instancia = new Controlador_tasks(); return instancia;}

        public Controlador_tasks() {

                modulo_multithread = new MODULO__multithread( _nome_modulo: "Modulo_multithread_controlador_tasks", _controalador_tasks: this );
                relogio = new System.Diagnostics.Stopwatch();

                int numero_inicial_de_slots = 20;

                tasks_em_espera_iniciar = new Task_req [ numero_inicial_de_slots ];
                tasks_em_espera_para_ativar_multithread = new Task_req [ numero_inicial_de_slots ];
                tasks_em_espera_para_ativar_single_thread = new Task_req [ numero_inicial_de_slots ];

                tempo_maximo_em_single_thread_ms = 2L;

        }

        public long tempo_maximo_em_single_thread_ms;

        public MODULO__multithread modulo_multithread;

        public Task_req[] tasks_em_espera_iniciar;
        public Task_req[] tasks_em_espera_para_ativar_multithread;// somente multithread deleta e somente single thread adiciona.
        public Task_req[] tasks_em_espera_para_ativar_single_thread;

        System.Diagnostics.Stopwatch relogio;

        public void Update(){


                relogio.Start();

                Iniciar_tasks_em_espera();

                while ( true ){

                        if( !!! ( Pode_continuar() ) ) 
                            { return; } // --- NAO PODE CONTINUAR

                        // --- VERIFICA SE TEM TASKS
                        Task_req task = TASK_REQ.Pegar_task_com_maior_prioridade( tasks_em_espera_para_ativar_single_thread );

                        if( task == null ) 
                            { relogio.Reset(); return; }  // --- NAO TEM NADA PARA FAZER
                        
                        // --- VERIFICA SE PODE EXECUTAR
                        if( !!! ( task.pode_executar_single_thread ) || task.task_bloqueada )
                            { tasks_em_espera_para_ativar_single_thread[ task.slot_id ] = null; continue; }  // --- VAI PARA O PROXIMO
                        

                        // --- VERIFICA SE VAI EXECUTAR FRACIONADO)
                        if( task.task_fracionada != null && task.pode_executar_parte_single_thread_fracionada )
                            { Executar_fracionado( task ); }

                        if ( !!!( Pode_continuar() ) )
                            { return; } // --- NAO PODE CONTINUAR

                        task.fn_single_thread( task ); 
                        tasks_em_espera_para_ativar_single_thread[ task.slot_id ] = null;

                
                }
                

        }


        private void Executar_fracionado( Task_req task ){

                for( int  i = 0 ; i < task.task_fracionada.fn_fracionadas.Length ; i++ ){

                        task.task_fracionada.Ativar_fracionado();

                        if( ! ( Pode_continuar() ) ) 
                            { return; }

                        if( ! ( task.task_fracionada.tem_fracionado ) )
                            { break;}

                        continue;

                }
                
        }

        private bool Pode_continuar(){

                bool pode_continuar = ( relogio.ElapsedMilliseconds > tempo_maximo_em_single_thread_ms );

                if( pode_continuar )
                    { relogio.Reset(); }

                return pode_continuar;

        }

        public void Iniciar_tasks_em_espera(){

            // ** previne que inicie a segunda thread por nada

            for( int index = 0 ; index < tasks_em_espera_iniciar.Length ; index++ ){

                Task_req task = tasks_em_espera_iniciar[ index ];
                tasks_em_espera_iniciar[ index ] = null;

                if( task.pode_executar_parte_multithread )
                    {
                        // --- COLOCA MULTITHREAD
                        modulo_multithread.Garantir_thread();
                        TASK_REQ.Adicionar_task_em_array( ref tasks_em_espera_para_ativar_multithread, task );
                        continue;
                    }

                if( !!! ( task.pode_executar_single_thread ) )
                    { continue; } // --- NADA È FEITO

                // --- TEM SINGLE

                TASK_REQ.Adicionar_task_em_array( ref tasks_em_espera_para_ativar_single_thread, task );
                continue;

            }

        }


        public void Adicionar_task( Task_req _nova_task ) {

                
                int index = TASK_REQ.Pegar_index_null( tasks_em_espera_iniciar );
                if( index == -1 )
                    { 
                        // --- AUMENTAR
                        index = tasks_em_espera_iniciar.Length;
                        tasks_em_espera_iniciar = TASK_REQ.Aumentar_length_array_2d( tasks_em_espera_iniciar, 20 ); 
                    }


                tasks_em_espera_iniciar[ index ] = _nova_task;
                _nova_task.slot_id = index;

                Debug.Log("task foi adicionada no index: " + _nova_task.ToString());

                return;

        }



        //mark 
        // ver mutex para garantir que somente 1 thread possa pegar os recursos
        // Interlocked Class
        // vai realmente ter problema?
        



}

