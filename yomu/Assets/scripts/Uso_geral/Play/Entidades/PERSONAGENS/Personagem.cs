using System.IO;
using System;






// onde isso vai ficar?
public delegate int Del_personagem_TO_int ( Personagem _personagem );
public delegate bool Del_personagem_TO_bool ( Personagem _personagem );


// os containers vao apontar para os mesmos dados que save_personagem 




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
        public Gerenciador_pensamentos gerenciador_pernsamentos;
        public Gerenciador_desejos_personagem gerenciador_desejos;

        public Gerenciador_estado_fisiologico gerenciador_estado_fisiologico;
        public Gerenciador_memorias gerenciador_memorias;


        // outros persoangens

        public Gerenciador_relacionamentos gerenciador_relacionamentos;
        public Gerenciador_memorias_outros_personagens gerenciador_memorias_outros_personagens;


        // parte externa 

        public Gerenciador_compromisso gerenciador_compromisso;
        public Gerenciador_quests gerenciador_quests;


        // sistema 
        public Gerenciador_acontecimentos_personagem gerenciador_acontecimentos;
        public Gerenciador_dados_sistema gerenciador_dados_sistema;
        public Gerenciador_containers_dados_personagem gerenciador_containers_dados; 
        public Gerenciador_AI_personagem gerenciador_AI;

        





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
