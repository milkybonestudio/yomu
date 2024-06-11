


using System.IO;
using System;







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


    public Action< Personagem > lidar_cumprir = ( Personagem per ) => { throw new Exception( "nao foi colocado fn evento personagem "  ); };
    public Action< Personagem > lidar_nao_cumprir = ( Personagem per ) => { throw new Exception( "nao foi colocado fn evento personagem "   ); };

    public Action< Personagem > lidar_ignorar = ( Personagem per ) => { throw new Exception( "nao foi colocado fn evento personagem "   ); };


}

// onde isso vai ficar?
public delegate int Del_personagem_TO_int ( Personagem _personagem );
public delegate bool Del_personagem_TO_bool ( Personagem _personagem );


// os containers vao apontar para os mesmos dados que save_personagem 










public class Gerenciador_compromisso {

        public Gerenciador_compromisso( Personagem _personagem ){ personagem = _personagem; }

        public Personagem personagem;

        public Compromisso[] deveres = new Compromisso[ 35 ];
        public Compromisso[] eventos_futuros = new Compromisso[ 5 ];
        public int[]  eventos_futuros_dias = new int[ 5 ];

        public bool Verificar_compromisso( Semana_periodo _semana_periodo ){

                // false => nao impede o update
                // true => impede o update 

                if( deveres[ ( int )_semana_periodo ] == null ){ return false; }

                return true;


        }

        public void Adicionar_compromisso( Semana_periodo _tempo , Compromisso _compromisso ){



            

        }
 
}



public class Gerenciador_pensamentos {




}

public class Gerenciador_estado_fisiologico {


}



public class Gerenciador_memorias {



}


public class Gerenciador_quests {




}


public class Gerenciador_relacionamentos {



}


public class Gerenciador_acontecimentos {



        public byte[] dados_internos_personagens; // pode / precisa ser convertido em um objeto 

        public byte[] lugares_dados; // vai ser oque o personagem acha do lugar + informacoes uteis. Lugares vai ter coisas como ruputação e motivos 
        public byte[] dados_plots;  
        public byte[] dados_quests; 


        // se algo de alguma tabela sair de padrão vai ser alterado aqui
        public byte[] variacoes_de_tabelas;





} 


public class Gerenciador_dados_sistema {
        // vai ficar responsavel por mudar os dados de sistema 
        // principalmente interesse e afeto



}


public class Gerenciador_updates {


        // talvez fique melhor ter osmente gerenciador_AI


        public enum Dados_bool {


            lily_comeu_biscoito,


        }



        public Estado_mental estado_mental = new Estado_mental();





        


        public Action Update_run_time;
        public Action Update_periodo;
        public Action Update_dia;
        public Action Update_semana;
        public Action Update_mes;


        // MES   SEMANA  DIA   periodo   run_time
        public System.Action[] Updates_movimento = new System.Action[ 5 ];

        public Action[] updates;






}


public class Gerenciador_desejos {



}



public class Gerenciador_memorias_outros_personagens {

}


public class Gerenciador_AI_personagem {

        public System.Object personagem_AI;


}


public class Personagem {

        public Personagem(  int _personagem_id,  Posicao_geral _posicao_geral, Atividade _atividade ){

                posicao = _posicao_geral ;
                atividade = _atividade ;
                personagem_id = _personagem_id ;


        }


        public int personagem_id;
        public Posicao_geral posicao;
        public Atividade atividade;

        public Plano plano = Plano.quarto;


        // parte interna 
        public Gerenciador_estado_mental gerenciador_estado_mental;
        public Gerenciador_estado_fisiologico gerenciador_estado_fisiologico;
        public Gerenciador_pensamentos gerenciador_pernsamentos;
        public Gerenciador_memorias gerenciador_memorias;
        public Gerenciador_desejos gerenciador_desejos;



        // outros persoangens

        public Gerenciador_relacionamentos gerenciador_relacionamentos;
        public Gerenciador_memorias_outros_personagens gerenciador_memorias_outros_personagens;


        // parte externa 

        public Gerenciador_compromisso gerenciador_compromisso;
        public Gerenciador_quests gerenciador_quests;


        // sistema 
        public Gerenciador_updates gerenciador_updates;
        public Gerenciador_acontecimentos gerenciador_acontecimentos;
        public Gerenciador_dados_sistema gerenciador_dados_sistema;
        public Gerenciador_containers_dados_personagem gerenciador_containers_dados; 
        public Gerenciador_AI_personagem gerenciador_AI_personagem;

        





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


        

}
