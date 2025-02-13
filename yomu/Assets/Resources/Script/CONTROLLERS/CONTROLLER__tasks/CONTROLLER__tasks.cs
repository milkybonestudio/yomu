using System;
using System.Threading;
using UnityEngine;
using System.Collections.Concurrent;
using System.Collections;



public class CONTROLLER__tasks  {


        public static CONTROLLER__tasks instancia;
        public static CONTROLLER__tasks Pegar_instancia(){ return instancia; }
    

        public CONTROLLER__tasks() {

                modulo_multithread = new MODULO__multithread( _nome_modulo: "Modulo_multithread_controlador_tasks", _controalador_tasks: this );
                relogio = new System.Diagnostics.Stopwatch();

                int numero_inicial_de_slots = 2;

                tasks_em_espera_iniciar = new Task_req [ numero_inicial_de_slots ];
                tasks_em_espera_para_ativar_multithread = new Task_req [ numero_inicial_de_slots ];
                tasks_em_espera_para_ativar_single_thread = new Task_req [ numero_inicial_de_slots ];

                tempo_maximo_em_single_thread_ms = 3L;

        }

        public Task_req Get_task_request( string _name ){

                Task_req req = new Task_req( _name );
                Adicionar_task( req );
                return req;

        }

        public long tempo_maximo_em_single_thread_ms;

        public MODULO__multithread modulo_multithread;

        public Task_req[] tasks_em_espera_iniciar;
        public Task_req[] tasks_em_espera_para_ativar_multithread;// somente multithread deleta e somente single thread adiciona.
        public Task_req[] tasks_em_espera_para_ativar_single_thread;

        private System.Diagnostics.Stopwatch relogio;

        public bool block_frame;

        public void Update( Control_flow _control_flow ){


                if( block_frame )
                    { block_frame = false; return; }
                

                relogio.Start();

                Allocat_waiting_tasks();
                Verify_multithread_task();
                Guarantee_second_thread();

                while ( true ){

                        if( !!! ( Pode_continuar() ) ) 
                            { return; } // --- NAO PODE CONTINUAR

                        Task_req task = TASK_REQ.Pegar_task_com_maior_prioridade( tasks_em_espera_para_ativar_single_thread ); // --- VERIFICA SE TEM TASKS

                        if( task == null ) 
                            { relogio.Reset(); return; }  // --- NAO TEM NADA PARA FAZER

                    
                        if( !!! ( task.pode_executar_single_thread ) || task.task_bloqueada )
                            { 
                                // --- NAO PODE EXECUTAR
                                task.finalizado = true; 
                                tasks_em_espera_para_ativar_single_thread[ task.slot_id ] = null; 
                                continue; 
                            }  
                            

                        if( ( task.task_fracionada != null ) && ( task.pode_executar_parte_single_thread_fracionada ) )
                            { Executar_fracionado( task ); } // --- VAI EXECUTAR FRACIONADO


                        if ( !!!( Pode_continuar() ) )
                            { return; } // --- NAO PODE CONTINUAR

                    
                        task.fn_single_thread( task ); 
                        task.finalizado = true;
                        tasks_em_espera_para_ativar_single_thread[ task.slot_id ] = null;
                
                }

            

                if( modulo_multithread.exception != null )
                    { CONTROLLER__errors.Throw_exception( modulo_multithread.exception ); }
                

        }

        private void Guarantee_second_thread(){

                foreach( Task_req req in tasks_em_espera_para_ativar_multithread ){

                        if( req != null )
                            { modulo_multithread.Garantir_thread(); return; }
                            
                }

        }


        private void Verify_multithread_task(){


                for(  int index_multithread = 0 ; index_multithread < tasks_em_espera_para_ativar_multithread.Length; index_multithread++  ){

                        Task_req req = tasks_em_espera_para_ativar_multithread[ index_multithread ];

                        if( req == null )
                            { continue; }

                        if( req.part_multithread_finished )
                            { tasks_em_espera_para_ativar_multithread[ index_multithread ] = null; }

                        continue;
                }

        }

        

        public Coroutine Wait_task_ends( Task_req _task_request, float _max_time_ms ){

                return Mono_instancia.Start_coroutine( Wait() );

                IEnumerator Wait(){

                        float time = 0f;

                        while( true ){

                            time += ( Time.deltaTime * 1000f );

                            if( time > _max_time_ms )
                                { CONTROLLER__errors.Throw( $"Passou do tempo na task { _task_request.nome }" ); }

                            if(  _task_request.finalizado )
                                { break; }
                                
                            yield return null; 

                        }
                        
                        yield break;

                };

                                                    

        }


        public void Block_frame_update(){

            block_frame = true;

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

                bool pode_continuar = ( relogio.ElapsedMilliseconds < tempo_maximo_em_single_thread_ms );
                
                if( !!!( pode_continuar ) )
                    { relogio.Reset(); }

                return pode_continuar;

        }

        private void Allocat_waiting_tasks(){

            // ** previne que inicie a segunda thread por nada

            for( int index = 0 ; index < tasks_em_espera_iniciar.Length ; index++ ){


                    Task_req task = tasks_em_espera_iniciar[ index ];

                    if( task == null )
                        { continue; }

                    tasks_em_espera_iniciar[ index ] = null;

                    // --- VERIFICAR MULTI THREAD

                    if( task.pode_executar_parte_multithread )
                        { modulo_multithread.Garantir_thread();     TASK_REQ.Adicionar_task_em_array( ref tasks_em_espera_para_ativar_multithread, task );     continue; } // --- COLOCA MULTITHREAD

                    // ---NAO TEM NADA NA MULTITRHEAD

                    if( task.pode_executar_single_thread )
                        { TASK_REQ.Adicionar_task_em_array( ref tasks_em_espera_para_ativar_single_thread, task );     continue; } // --- COLOCA SINGLETHREAD
                    
                    // --- NADA È FEITO
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

                return;

        }

}

