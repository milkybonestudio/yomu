using System;
using System.Threading;
using UnityEngine;
using System.Collections.Concurrent;



public class MODULO__multithread {


        public string nome_modulo;
        public MODULO__multithread( string _nome_modulo, CONTROLLER__tasks _controalador_tasks ){

                nome_modulo = _nome_modulo;
                controlador_tasks = _controalador_tasks;

        }

        public CONTROLLER__tasks controlador_tasks;
        
        public Thread thread = null;
        public CancellationTokenSource token_para_cancelar = new CancellationTokenSource();
        public Exception exception;


        public void Update(){}

        
        public bool finalizar_thread = false;


    
        public void Thread_secundaria_update(){

                int i = 100;

                try {

                        while( true ){

                                //return;

                                if( !!! ( Dados_fundamentais_sistema.jogo_ativo ) || finalizar_thread )
                                    { return; }


                                Task_req task = TASK_REQ.Pegar_task_com_maior_prioridade( controlador_tasks.tasks_em_espera_para_ativar_multithread );


                                if( task == null )
                                    { Matar_thread(); return; }


                                controlador_tasks.tasks_em_espera_para_ativar_multithread[ task.slot_id ] = null;


                                if( task.task_bloqueada || !!!( task.pode_executar_parte_multithread ) )
                                    { continue; } // --- perde completamente a referencia

                                task.fn_multithread( task );
                                task.part_multithread_finished = true;
                                
                                TASK_REQ.Adicionar_task_em_array(  ref controlador_tasks.tasks_em_espera_para_ativar_single_thread, task );

                                continue;

                        }

                } catch( Exception e ){

                    CONTROLLER__errors.Throw_exception(e);
                    Console.LogError( e.Message );


                    exception = e;
                    Matar_thread();
                    return;

                }


        }


        public void Garantir_thread() {    
    
                
                if( thread != null  )
                    { return; }


                finalizar_thread = false;
                thread = new Thread( Thread_secundaria_update ); 
                thread.Name = "Multithread";
                thread.Start();
                
                return;

        }

        public static int v = 0;

        public void Matar_thread(){

                thread = null;
                finalizar_thread = true ;
                return;
                
        }


}