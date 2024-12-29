


public class Dados_dinamicos {

    public Dados_dinamicos( int _numero_inicial_de_slots ){

            ids_pointers = new int[ _numero_inicial_de_slots ];
            dados = new byte[ _numero_inicial_de_slots ][];
            tempo_vida = new int[ _numero_inicial_de_slots ];
            reqs = new Task_req[ _numero_inicial_de_slots ];

    }

        public int tempo_de_vida_para_ignorar = 100;
        public int[] ids_pointers;
        public byte[][] dados;
        public int[] tempo_vida;
        public Task_req[] reqs;

    public void Verificar_dados_para_excluir(){

        for( int slot = 0; slot < ids_pointers.Length ;slot++ ){

                int id = ids_pointers[ slot ];

                // --- VERIFICA SE TEM ALGO
                if( id == -1 )
                    { continue; }

                int tempo = tempo_vida[ slot ];

                // --- VERIFICA SE TEM QUE MANTER INDEFINIDAMENTE 
                if( tempo == tempo_de_vida_para_ignorar )
                    { continue; }
                

                // --- VERIFICA SE VAI EXCLUIR
                if( tempo == 0 )
                    {
                        dados[ slot ] = null;
                        ids_pointers[ slot ] = -1;
                        tempo_vida[ slot ] = -1;
                        continue;

                    }

                tempo_vida[ slot ]--;
                continue;

            
        }

    }

    public void Adicionar( byte[] _dados , int _pointer ){


            for( int slot = 0 ; slot < ids_pointers.Length ; slot++ ){



            }


    }

    public void Pedir_dados( int _pointer, int _length, string _path_container ){





    }


}