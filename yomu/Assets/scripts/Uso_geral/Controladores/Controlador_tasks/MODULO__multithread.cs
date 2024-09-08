using System;
using System.Threading;
using UnityEngine;
using System.Collections.Concurrent;



public class MODULO__multithread {


        public string nome_modulo;
        public MODULO__multithread( string _nome_modulo, Controlador_tasks _controalador_tasks ){

                nome_modulo = _nome_modulo;
                controlador_tasks = _controalador_tasks;

        }

        public Controlador_tasks controlador_tasks;
        
        public Thread thread = null;
        public CancellationTokenSource token_para_cancelar = new CancellationTokenSource();


        public void Update(){}

        
        public bool finalizar_thread = false;

    
        public void Thread_secundaria_update ( ){

                while( true ){

                        if( !!! ( Dados_fundamentais_sistema.jogo_ativo ) || finalizar_thread )
                            { return; }

                        Task_req task = TASK_REQ.Pegar_task_com_maior_prioridade( controlador_tasks.tasks_em_espera_para_ativar_multithread );
                        controlador_tasks.tasks_em_espera_para_ativar_multithread[ task.slot_id ] = null;

                        if( task == null )
                            { Matar_thread(); return; }

                        if( task.task_bloqueada || !!!( task.pode_executar_parte_multithread ) )
                            { Console.Log( $"Nao deixou executar a task { task.nome } na multithread" ); continue; } // --- perde completamente a referencia

                        task.fn_multithread( task );
                            
                        TASK_REQ.Adicionar_task_em_array(  ref controlador_tasks.tasks_em_espera_para_ativar_single_thread, task );

                        continue;

                }

        }


        public void Garantir_thread() {    
    
                if( thread != null  )
                    { return; }


                Console.Log("vai criar a nova thread");
                finalizar_thread = false;
                thread = new Thread( Thread_secundaria_update ); 
                thread.Name = "Multithread";
                thread.Start();
                
                return;

        }

        public void Matar_thread(){

                Console.Log("veio mar thread");
                thread = null;
                finalizar_thread = true ;
                return;
                
        }










}