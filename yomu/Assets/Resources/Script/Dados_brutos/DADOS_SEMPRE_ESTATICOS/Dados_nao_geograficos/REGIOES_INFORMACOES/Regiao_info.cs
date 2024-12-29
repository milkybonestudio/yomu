


public class Regiao_info {

        // logica: 
        // cada regiao tem uma serie de recursos naturais que apresentam um limite maximo de extração 



        // cada regiao pode ter no maximo 5 trechos 

        public Regiao_info(){


                int numero_maximo_de_trechos_por_regiao = 5;
                int numero_maximo_de_regioes = 5;
                int numero_trecho_da_regiao = 5;
                
                int total_de_posibilidades = ( numero_maximo_de_trechos_por_regiao * numero_maximo_de_regioes * numero_trecho_da_regiao );

                distancias_entre_trechos = new short[ total_de_posibilidades ];

                //     1
                //   4 0 2
                //     3

                // ideia :   index  = ( regiao * ( 5 * 5) + ( trecho_centro * 5 )  +  trecho_destino  );

                // int trecho_base = 0;
                // int trecho_destino = 0;

                // distancias_entre_trechos[   ( Regiao_localizador.cima * ( 5 * 5 )  +  ( trecho_base * 5 )  +  trecho_destino ) ];

        }


        public Bioma bioma;

        public int[] depositos_minerios; 



    

        public short[] regioes_ids = new short[ 5 ]; // 0 => nada 

        // --- DISTANCIAS
        public short[] distancias_entre_trechos;




}

