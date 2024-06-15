


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


