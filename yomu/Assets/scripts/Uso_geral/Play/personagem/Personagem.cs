


using System.IO;
using System;




public enum Emocao_base {



}

public enum Emocao {

         // ver os valores certos 
         // https://en.wikipedia.org/wiki/Emotion#/media/File:Plutchik_Dyads.svg

         // base 

         felicidade = 0 ,
         tristeza   = 1 ,
        
         coragem    = 2 ,
         medo       = 3 ,
        
         atracao    = 4 ,
         nojo       = 5 ,
    
         previsibilidade = 6 ,
         instabilidade = 7


         //-----------
    
        agressividade,
        otimismo,
        amor = ( 4 + 0 ),
        submissao = (  50 + 4 ),

    
        terror = ( 70 + 3 ),
        desaprovamento,
        remorso,
        desprezo,
        
        orgulho,
        esperanca,
        culpa,

        curiosidade,
        
        desespero, 
        incredulidade,
        inveja, 
        
        cinismo,

        

        dominancia, 
        anciedade,
        deleito,

        sentimentalismo,
        vergonha,
        indignação,
        pessimismo,
        morbio
        
}

public Emocao_secundaria Pegar_emocao( Emocao _emocao_1 , Emocao _emocao_2 ){

         int emocao_1_int = ( int ) _emocao_1;
         int emocao_2_int = ( int ) _emocao_2;

         if( emocao_1_int == emocao_2_int ){ throw new Exception( "What?" ); }
         

         int maior = emocao_1_int;
         int menor = emocao_2_int;
         
         if( maior < menor ){
         
                  int maior = emocao_2_int;
                  int menor = emocao_1_int;
         }
         

         
         
         
}


public class Estado_mental_personagem {

    
        // variavis emocionais 
        // momento 
        public float alegria;         // felicidade : 500+ sadness 500-
        public float iniciativa;      // raiva : 500+ medo : 500-
        public float atratividade;    // 
        public float previsibilidade; // 
        
        
        
        
        public float felicidade; // 700      +20 
        public float tristeza;
        
        public float coragem;      // raiva : 500+ medo : 500-
        public float medo;
        
        public float atracao;    
        public float nojo;
        
        public float previsibilidade;
        public float instabilidade; 

        // dentro do personagem em run_time.dll

        
        public void Modificar_felicidade( float valor ){
        
        
        
        }
        
        
        public void Modificar_medo( float valor ){
        
                Modificar_felicidade( - valor );
                medo = 1000 - felicidade;
            
        }



    


    public int Pegar_emocao_atual(){

            float[] emocoes_axis = new float[]{
                
                 felicidade,
                 tristeza,
                
                 coragem,
                 medo,
                
                 atracao,
                 nojo,
            
                 previsibilidade,
                 instabilidade

            };

        // talvez de problema quando for felicidade 500 e tristeza 500
        // nesse caso nao é mais axis MUDAR DEPOIS
            // esta errado isso vai devolver algo como [ 750, 725, 650 ... ] tem que voltar [ 5, 1 , 0 ]
            // e depois fazer  float valor_mais_alto =  arr[ rank[ 0 ] ]
            float[] emocoes_axis_crescentes = new float[ emocoes_axis.Length ];

            for( int emocao_axis = 0, int index_maximo ; emocao_axis < emocoes_axis.Length ; emocao_axis++ ){

                    float valor_para_acrescentar = emocoes_axis[ emocao_axis ];
                    
                    for( int emocao_axis_crescente = 0 ; emocao_axis_crescente =< emocao_axis ; emocao_axis_crescente++ ){
    
                            float emocao_acrecentar_em_analise = emocoes_axis_crescentes[ emocao_axis_crescente ];
                            if( valor_para_acrescentar > emocao_acrecentar_em_analise ){
    
                                    emocao_acrecentar_em_analise = emocoes_axis_crescentes[ emocao_axis_crescente ];
                                    emocoes_axis_crescentes[ emocao_axis_crescente ] = valor_para_acrescentar;
                                    valor_para_acrescentar  = emocao_acrecentar_em_analise;
                                    
                            }
                    
                    }
                    
            }

            float maior = arr[ 0 ];
            float segundo = arr[ 0 ];

            

        
    }


    

    

    
    // public int Pegar_emocao_atual(){

    //         float[] emocoes_axis = new float[ 4 ]{
                
    //                 alegria, 
    //                 iniciativa, 
    //                 atratividade, 
    //                 previsibilidade
                    
    //         };

    //         float[] emocoes_axis_crescentes = new float[ emocoes_axis.Length ];

    //         for( int emocao_axis = 0, int index_maximo ; emocao_axis < emocoes_axis.Length ; emocao_axis++ ){

    //                 float valor_para_acrescentar = emocoes_axis[ emocao_axis ];
                    
    //                 for( int emocao_axis_crescente = 0 ; emocao_axis_crescente =< emocao_axis ; emocao_axis_crescente++ ){
    
    //                         float emocao_acrecentar_em_analise = emocoes_axis_crescentes[ emocao_axis_crescente ];
    //                         if( valor_para_acrescentar > emocao_acrecentar_em_analise ){
    
    //                                 emocao_acrecentar_em_analise = emocoes_axis_crescentes[ emocao_axis_crescente ];
    //                                 emocoes_axis_crescentes[ emocao_axis_crescente ] = valor_para_acrescentar;
    //                                 valor_para_acrescentar  = emocao_acrecentar_em_analise;
                                    
    //                         }
                    
    //                 }
                    
    //         }

        
    // }

    public void Calcular_guily(){


        float guilty =    alegria   -  iniciativa 

        
    }

}

public class Personagem_dados_internos {

    public Estado_mental_personagem estado_mental;

}



public enum Evento_caracteristica {

    evento_em_grupo, 

}


public class Evento {

    public string nome = "regar_flores";
    public Personagem_nome[] personagens_envolvidos;
    public Evento_caracteristica[] compromisso_caracteristicas; 

}



public class Compromisso {


    public Evento evento;
    // quando colocar em um personagem cada um vai ter um proprio. 
    // quando for colocar um evento o personagem tem lidar se ele vai ou nao 

    // 0  => ignora => nao acha importante 
    // 1  => cumpre  => vai 
    // -1 =>  nao cumpre => nao vai por algum motivo e é importante 
    public Del_personagem_TO_int verificar_ida;


    public Action< Personagem > lidar_cumprir = ( Personagem per ) => { throw new Exception( "nao foi colocado fn evento personagem " +  ) };
    public Action< Personagem > lidar_nao_cumprir = ( Personagem per ) => { throw new Exception( "nao foi colocado fn evento personagem " +  ) };

    public Action< Personagem > lidar_ignorar = ( Personagem per ) => { throw new Exception( "nao foi colocado fn evento personagem " +  ) };


}

// onde isso vai ficar?
public delegate int Del_personagem_TO_int ( Personagem _personagem );
public delegate bool Del_personagem_TO_bool ( Personagem _personagem );


// os containers vao apontar para os mesmos dados que save_personagem 


public class Gerenciador_estado_mental {

    public Estado_mental_personagem estado_mental;

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

                Salvar_novo_valor(  _estado , _novo_valor  );

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


    public void Salvar_novo_valor(  _estado , _novo_valor  ){


        


        
    }
        



    



}

public class Gerenciador_compromisso {

        public Gerenciador_compromisso( Personagem _personagem ){ personagem = _personagem; }

        public Personagem personagem;

        public Compromisso[] deveres = new Evento[ 35 ];
        public Compromisso[] eventos_futuros = new Evento[ 5 ];
        public int[]  eventos_futuros_dias = new int[ 5 ];

        public bool Verificar_compromisso( Semana_periodo _semana_periodo ){

                // false => nao impede o update
                // true => impede o update 

                if( deveres[ _semana_periodo ] == null ){ return false; }


        }

        public void Adicionar_compromisso( Semana_periodo _tempo , Compromisso _compromisso ){



            

        }
 



}


public class Gerenciador_quests {




}


public class Personagem {


        // gerenciadores fazem mais sentido 
        public Gerenciador_estado_mental gerenciador_estado_mental;
        public Gerenciador_compromisso gerenciador_compromisso;

        public Gerenciador_quests gerenciador_quests;



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



        public Estado_mental_personagem estado_mental = new Estado_mental_personagem();





        public System.Object dados_personagem_run_time;


        public Action Update_run_time;
        public Action Update_periodo;
        public Action Update_dia;
        public Action Update_semana;
        public Action Update_mes;





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

        public Action[] updates;


  



}
