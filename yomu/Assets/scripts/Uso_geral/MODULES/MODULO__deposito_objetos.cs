using System;



public class MODULO__deposito_objetos {


        public object[] objects;
        public Task_req[] task_reqs;
        public string nome_modulo;

        public MODULO__deposito_objetos(  string _nome_modulo, int _numero_inicial_de_slots ){

                objects = new object[ _numero_inicial_de_slots ];
                task_reqs = new Task_req[ _numero_inicial_de_slots ];
                nome_modulo = _nome_modulo;
                
                return;

        }


        public object Pegar_objeto( int _slot ){


            // --- VERIFICA SE O OBJETO ESTA CARREGADO
            if( objects[ _slot ] != null )
                { return objects[ _slot ]; } // --- ESTA CARREGADO


            // --- NAO TEM OBJETO
            if( task_reqs[ _slot ] == null )
                { throw new Exception( $"Tentou pegar um objeto no slot {_slot } no modulo { nome_modulo } mas o slot estava vazio" ); }

            if(  task_reqs[ _slot ].finalizado )
                {   
                    // --- TEM OS DADOS
                    objects[ _slot ] = task_reqs[ _slot ].dados;
                }
                else
                {
                    // --- NAO TEM OS DADOS NA TASK
                    if( task_reqs[ _slot ].fn_forcar_finalizar == null )
                        { throw new Exception( $"Precisou forcar para finalizar uma task mas a fn_forcar nao foi definida no { task_reqs[ _slot ].nome } no modulo { nome_modulo } mas o slot estava vazio" ); }

                        task_reqs[ _slot ].fn_forcar_finalizar( task_reqs[ _slot ] );
                        objects[ _slot ] = task_reqs[ _slot ].dados[ 0 ];
                }

            // --- TIRA A TASK
            task_reqs[ _slot ].task_bloqueada = true;
            task_reqs[ _slot ] = null;
            return objects[ _slot ];


        }


        public int Colocar_objeto( object _objeto ){

            int slot = Pegar_slot_livre();
            objects[ slot ] = _objeto;
            return slot;


        }

        
        public int Colocar_pedido_objeto( Task_req _task_req ){

                int slot = Pegar_slot_livre();
                task_reqs[ slot ] = _task_req;
                return slot;

        }



        public int Pegar_slot_livre(){


                for( int index_slot = 0; index_slot < objects.Length; index_slot++ ){

                        if( objects[ index_slot ] == null )
                            { return index_slot; }
                        continue;

                }

                return Extender_slots();


        }

        



        public void Remover_dados ( int _slot ){

            
                objects[ _slot ] = null;

                if( task_reqs[ _slot ] != null )
                        {
                                task_reqs[ _slot ].task_bloqueada = true;
                                task_reqs[ _slot ] = null;

                        }

                return;

        }


        public int Extender_slots(){


                // --- CRIA MAIS SLOTS

                int index_final_livre = objects.Length;

                int numero_para_aumentar = 20;

                Array.Resize( ref objects, ( objects.Length + numero_para_aumentar ) );
                Array.Resize( ref task_reqs, ( task_reqs.Length + numero_para_aumentar ) );

                return index_final_livre;


        }



        


}