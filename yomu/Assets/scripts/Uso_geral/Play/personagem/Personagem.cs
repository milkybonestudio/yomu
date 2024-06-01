



using System.IO;

public enum Tipo_dado_personagem {

    eventos_valores_fixos,
    eventos_valores_variados, 


    movimentos_mapa,


}




public enum Estado_mental {

    felicidade,
    depressao,

}


public class Estado_mental_personagem {

    public float felicidade;
    public float depressao;

}

public class Personagem_dados_internos {

    public Estado_mental_personagem estado_mental;

}




// os containers vao apontar para os mesmos dados que save_personagem 

public class Personagem {


        public Personagem(  ){




        }


        public int variavel_1 = 1;



        public Dados_sistema_personagem dados_sistema;

        // essa classe so vai ser criada se o personagem estiver ativo, poucos vão estar o tempo todo
        // vai ser instanciado sempre no Controlador_save

        // pensar que nara é somente outro personagem

        // ---- SELF



        public byte[] dados_internos_personagens; // pode / precisa ser convertido em um objeto 

        public byte[] lugares_dados; // vai ser oque o personagem acha do lugar + informacoes uteis. Lugares vai ter coisas como ruputação e motivos 
        public byte[] dados_plots;  
        public byte[] dados_quests; 


        // se algo de alguma tabela sair de padrão vai ser alterado aqui
        public byte[] variacoes_de_tabelas;

        public float Pegar_estado_mental( Estado_mental _estado_mental ){


                int byte_index = ( int ) _estado_mental * 2;
                int estado_mental_valor = ( int ) dados_internos_personagens[ byte_index ] ; 

                // transform u => s
                estado_mental_valor -= 128;

                estado_mental_valor = estado_mental_valor << 8 ;
                estado_mental_valor += ( int ) dados_internos_personagens[ byte_index + 1 ] ;

                return estado_mental_valor;


                
        }

        public enum Dados_bool {


            lily_comeu_biscoito,


        }

        // public int Pegar_bool_quests_dados( Dados_bool _dado ) {


        //         in index_inicio_bools = dados_quests[ 15 ];
        //         int index_inicio_dados = ( int ) _dado + index_inicio_bools;

        //         return ( bool ) dados_quests[ index_inicio_dados ];


        // }


        public Estado_mental_personagem estado_mental = new Estado_mental_personagem();


        public void Mudar_estado_mental(   Estado_mental _estado, float _novo_valor  ){

                /*

                    processo para mudar: 
                     - mudar valor no jogo
                     - ver oque precisa mudar no container para atualizar o valor 
                     - mudar no buffer 
                     - enviar um byte[] de como mudar esses dados em caso de encerramento brisco
                
                */


                // muda o dado em si 

                switch( _estado ){

                    case Estado_mental.felicidade: estado_mental.felicidade += _novo_valor; break;
                    case Estado_mental.depressao: estado_mental.depressao += _novo_valor; break;

                }



                // ** por hora nao vai salvar nada 
                return; 




                // ve oque precisa mudar nos containers
                int byte_index = ( int ) _estado * 2;
                int estado_mental_valor = ( int ) dados_internos_personagens[ byte_index ] ; 

                // transform u => s
                estado_mental_valor -= 128;

                estado_mental_valor = estado_mental_valor << 8 ;
                estado_mental_valor += ( int ) dados_internos_personagens[ byte_index + 1 ] ;

                byte[] byte_estado_mental = new byte[ 3 ] ;

                int container = 1;
                int start_point = 1;
                byte[] dados_retorno = new byte[ 10 ];

                // muda o buffer
                // mudar o buffer não vai mudar o valor, vai somente deixar o novo valor na ram 
                // nao vale a pena iniciar uma gravação para somente alguns bytes. é melhor deixar eles acumularem 

                dados_sistema.streams[ container ].Seek(  start_point,  SeekOrigin.Begin ) ;
                dados_sistema.streams[ container ].Write( dados_retorno, 0 , dados_retorno.Length ) ;


                // passa para controaldor personagens o byte que pode reconstruir esse dados se o sistema sair bruscamente 
                Controlador_personagens.Pegar_instancia().Pedir_para_salvar_dados( dados_retorno );

                return ;



        }


        public void Update_movimento( Personagem self ){


                // Estado_mental_personagem estado_mental = self.estado_mental;


                // if( periodo_atual == 5 ){


                //         if( self.Pegar_estado_mental( Estado_mental.felicidade ) > 500f ){


                //         }

                        
                //         if( estado_mental.felicidade > 500f ){


                //         }


                // }


        }





        // ----- OTHERS


        // personagens sempre vao ser tipo CV/**
        // porque eu não sei quais personagens vão conhecer uns aos outros 
        // a quantidade de personagens crescem em n2 tomar cuidado 

        // talvez cada personagem tenha um arquivo? 

        // dados_Dia.dat => impossivel escalar e manter buffers 
        
        // tudo vai estar em um só container 

        // dados sobre como o personagem se sente em relacao ao outro
        // links diretos para frases sobre oque esse personagem acha 
        // momentos mais importantes 
        //  guarda os 5 presentes mais importantes, os ultimos cinco e algumas informacoes fixas sobre presentes. 
        // tem dados sobre como um personagem se comporta na conversa. o jogo nao vai salvar toda resposta que o player der. Mas vai guardar dados sobre qual direção o personagem esta. 
        // acoes mais relevantes 
        public byte[] outros_personagens_dados; // CV/VF

        public byte[] personagens_respostas_conversas; // CV/VV => Vai ser acrescentado dinamicamente e os valores podem. 


        
        // MES   SEMANA  DIA   periodo   run_time
        public System.Action[] Updates_movimento = new System.Action[ 5 ];


  



}