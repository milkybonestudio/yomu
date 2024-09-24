using System;
using System.Collections.Generic;


public class Task_fracionada {

        public Task_fracionada( Task_req _task ){
                
                // * task que contem a task fracionada
                task_req = _task;

        }

        public Task_req task_req;

        public int pointer;
        public Action<Task_req>[] fn_fracionadas = new Action<Task_req>[ 10 ];


        public void Adicionar_fn( Action<Task_req> _fn ){

                fn_fracionadas[ pointer++ ] =  _fn ;

                if( pointer == fn_fracionadas.Length )
                    { Array.Resize( ref fn_fracionadas, ( fn_fracionadas.Length + 10 ) ); }

        }


        // Parte fracionada => se a task precisa ser na main thread ela pode ser dividida em partes mas ainda tendo a mesma chave 
        // o objeto vai ser mantido vivo até que todas as partes sejam terminadas

        // dado pode ser compactado como um Sprite[], entao cada loop ele cria um necessario

        public Action<Task_req>[] tasks_fracionadas = null;

        public bool tem_fracionado = false;

        public int parte_fracionado_atual = 0;
        
        public void Ativar_fracionado() {  


                if( tasks_fracionadas[ parte_fracionado_atual ] != null ){ tasks_fracionadas[ parte_fracionado_atual ]( task_req ); }

                parte_fracionado_atual++;

                int quantidade_de_partes = tasks_fracionadas.Length;

                if( parte_fracionado_atual >= quantidade_de_partes ) { tem_fracionado = false;}
                return;

        }





}