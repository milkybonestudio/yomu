using System;



public static class Gerenciador_estado_mental_construtor {

        public static Gerenciador_estado_mental Construir( Personagem personagem, byte[] _dados ){

                Gerenciador_estado_mental gerenciador = new Gerenciador_estado_mental( personagem );

                Estado_mental estado_mental = gerenciador.estado_mental;
                
                int numero_esperado_de_bytes = 10;

                
                // dados brutos 
                estado_mental.felicidade =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];
                estado_mental.tristeza =  ( int ) _dados[ ( int ) Emocao_base.tristeza ];
                
                estado_mental.coragem =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];
                estado_mental.medo =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];

                estado_mental.afeto =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];
                estado_mental.nojo =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];

                estado_mental.previsibilidade =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];
                estado_mental.instabilidade =  ( int ) _dados[ ( int ) Emocao_base.felicidade ];

        
                return  gerenciador;

        }

}
