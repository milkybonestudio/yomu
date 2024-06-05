using System;
using Codice.Client.BaseCommands;
using UnityEngine;




public class Gerenciador_estado_mental {

        public Gerenciador_estado_mental( Personagem _personagem ){

                personagem = _personagem;

                // transformar dados bytes em dados

        }


        public Personagem personagem;






    public Estado_mental estado_mental;

        public void Mudar_estado_mental(   Emocao _estado, float _novo_valor  ){

                /*
                    processo para mudar: 
                     - mudar valor no jogo
                     - ver oque precisa mudar no container para atualizar o valor 
                     - mudar no buffer 
                     - enviar um byte[] de como mudar esses dados em caso de encerramento brisco
                */


                // // muda o dado em si 

                // switch( _estado ){

                //     case Emocao.felicidade: estado_mental.felicidade += _novo_valor; break;
                //     case Emocao.tristeza: estado_mental.tristeza += _novo_valor; break;

                // }

                // Salvar_novo_valor(  _estado , _novo_valor  );

                // return;



    
        }



        public void Agrupar_por_rank(){ 


                float[] valores_atuais = new float[]{
                     
                    
                        estado_mental.felicidade,
                        estado_mental.tristeza,
                        
                        estado_mental.coragem,
                        estado_mental.medo,
                        
                        estado_mental.afeto,
                        estado_mental.nojo,
                    
                        estado_mental.previsibilidade,
                        estado_mental.instabilidade

                        
                };



                float[] valores_crescentes = new float[ valores_atuais.Length ];
                Emocao_base[] emocoes_crescentes = new Emocao_base[ valores_atuais.Length ];



                for( int index = 0 ; index < valores_atuais.Length ; index++ ){

                        float valor_para_acrescentar = valores_atuais[ index ];
                        
                        for( int valores_crescentes_index = 0 ; valores_crescentes_index <= index ; valores_crescentes_index++ ){
        
                                float valor_em_analise = valores_crescentes[ valores_crescentes_index ];

                                if( valor_para_acrescentar > valor_em_analise ){
        
                                        valor_em_analise = valores_crescentes[ valores_crescentes_index ];
                                        valores_crescentes[ valores_crescentes_index ] = valor_para_acrescentar;
                                        valor_para_acrescentar  = valor_em_analise;
                                        
                                }
                        
                        }
                        
                }

                return;

        }





        public float Pegar_valor_emocao_base( Emocao_base _emocao_base ) {


                switch( _emocao_base ){


                        case Emocao_base.felicidade : return estado_mental.felicidade;
                        case Emocao_base.tristeza : return estado_mental.tristeza;

                        case Emocao_base.coragem : return estado_mental.coragem;
                        case Emocao_base.medo : return estado_mental.medo;

                        case Emocao_base.afeto : return estado_mental.afeto;
                        case Emocao_base.nojo : return estado_mental.nojo;

                        case Emocao_base.previsibilidade : return estado_mental.previsibilidade;
                        case Emocao_base.instabilidade : return estado_mental.instabilidade;
                        
            
                }

                return -1;

        }



        



        public Emocao Pegar_emocao( Emocao_base _emocao_1, float _valor_1 , Emocao_base _emocao_2, float _valor_2 ) {


                if( _emocao_1 == _emocao_2 ){ throw new Exception( "veio 2 emocoes_base iguais: " + _emocao_1 ); }


                float maior_valor = _valor_1;
                int maior_emocao = ( int ) _emocao_1;

                float menor_valor = _valor_2;
                int menor_emocao = ( int ) _emocao_2;
                
                if( maior_valor < menor_valor ){
                
                        maior_valor = _valor_2;
                        maior_emocao = ( int ) _emocao_2;

                        menor_valor = _valor_1;
                        maior_emocao = ( int ) _emocao_1;

                }


                // se uma emocao base for muito maior assume que só tem ela 
                if( ( maior_valor - menor_valor ) > 400f ){

                        return  ( Emocao ) maior_emocao;

                }


                int maior_emocao_index = maior_emocao;
                int menor_emocao_index = menor_emocao;

                if( maior_emocao_index < menor_emocao_index ){
                            
                        maior_emocao_index = menor_emocao;
                        menor_emocao_index = maior_emocao;

                }

                return ( Emocao )( maior_emocao_index * 10 + menor_emocao  );

                
            
        }



        public void Salvar_novo_valor( int _estado , float _novo_valor  ){



                // // ve oque precisa mudar nos containers
                // int byte_index = ( int ) _estado * 2;
                // int estado_mental_valor = ( int ) dados_internos_personagens[ byte_index ] ; 

                // // transform u => s
                // estado_mental_valor -= 128;

                // estado_mental_valor = estado_mental_valor << 8 ;
                // estado_mental_valor += ( int ) dados_internos_personagens[ byte_index + 1 ] ;

                // byte[] byte_estado_mental = new byte[ 3 ] ;

                // int container = 1;
                // int start_point = 1;
                // byte[] dados_retorno = new byte[ 10 ];

                // // muda o buffer
                // // mudar o buffer não vai mudar o valor, vai somente deixar o novo valor na ram 
                // // nao vale a pena iniciar uma gravação para somente alguns bytes. é melhor deixar eles acumularem 

                // dados_sistema.streams[ container ].Seek(  start_point,  SeekOrigin.Begin ) ;
                // dados_sistema.streams[ container ].Write( dados_retorno, 0 , dados_retorno.Length ) ;


                // // passa para controaldor personagens o byte que pode reconstruir esse dados se o sistema sair bruscamente 
                // Controlador_personagens.Pegar_instancia().Pedir_para_salvar_dados( dados_retorno );

                // return;

            
        }
            


}



