



public class Controlador_AI {

        public static Controlador_AI instancia;
        public static Controlador_AI Pegar_instancia(){ return instancia; }

        /* vai controlar o mundo */
        // player demonstrou interesse em personagens com cabelo verde? 
        // checar persoangens com cabelo verde => introduzir 
        // player precisa de algum item? talvez diminuir a quantidade em estoque para fazer ele ir atras do item 

        // As coisas vão ter a tentencia de ser autogerenciadas. Personagens e lugares vão te updates especificos. Mas tem que ter algo em um nivel superior para dizer 
        // oque vai atualizar e quando trocar 

        // A AI vai ser como se fosse um update do player, tentar adaptar o jogo conforme o player joga 

        public static Controlador_AI Construir(){ 
                
                instancia = new Controlador_AI(); 

                        

                
                return instancia;
                
        }

        public static Controlador_AI Construir_teste(){ 
                
                instancia = new Controlador_AI(); 

                        

                
                return instancia;
                
        }





}