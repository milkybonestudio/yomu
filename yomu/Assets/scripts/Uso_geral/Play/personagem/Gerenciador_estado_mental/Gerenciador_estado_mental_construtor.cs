using System;



public static class Gerenciador_estado_mental_construtor {

        public static Gerenciador_estado_mental Construir( Personagem personagem, byte[] _dados ){

                Gerenciador_estado_mental gerenciador = new Gerenciador_estado_mental( personagem );
                
                int numero_esperado_de_bytes = 10;

                
                // dados brutos 
                gerenciador.felicidade =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];
                gerenciador.tristeza =  ( int ) _dados[ ( int ) Emocao_base.tristeza ];
                
                gerenciador.coragem =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];
                gerenciador.medo =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];

                gerenciador.afeto =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];
                gerenciador.nojo =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];

                gerenciador.previsibilidade =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];
                gerenciador.instabilidade =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];

        
                return  gerenciador;

        }

}
