using System.IO;
using System;


public class Personagem {

        public Personagem(  int _personagem_id,  Locator_position _posicao, int _atividade_id ){

                posicao = _posicao ;
                atividade_id = _atividade_id ;
                personagem_id = _personagem_id ;

                personagem_nome = ( ( Personagem_nome ) _personagem_id ).ToString();

        }

        #if UNITY_EDITOR 

                public string personagem_nome;

        #endif


        public Locator_position posicao;
        public int personagem_id;
        public int atividade_id;

        public int plano_id = ( int ) Plano.quarto;


        // ** tem o container universal + dados descomprimidos. alem de funcoes para achar pointers 
        public MODULO__personagem_dados modulo_dados;


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

        public Dados_para_salvar Pegar_dados_para_salvar(){ return new Dados_para_salvar(); }

        
}