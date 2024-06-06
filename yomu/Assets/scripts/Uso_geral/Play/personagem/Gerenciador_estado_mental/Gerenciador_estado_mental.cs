using System;
using Codice.Client.BaseCommands;
using UnityEngine;



public class Gerenciador_estado_mental {

        public Gerenciador_estado_mental( Personagem _personagem ){ personagem = _personagem; }
        public Personagem personagem;



        public Estado_mental estado_mental;
        public Action< Estado_mental, float >[] modificadores; 

        public Action <Estado_mental, float> Modificar_felicidade;
        public Action <Estado_mental, float> Modificar_afeto;
        public Action <Estado_mental, float> Modificar_coragem;
        public Action <Estado_mental, float> Modificar_previsibilidade;

        public Action <Estado_mental, Emocao_base ,float> Modificar_estado_mental;
        

        public void Mudar_estado_mental(   Emocao _estado, float _novo_valor  ){

                /*
                    processo para mudar: 
                     - mudar valor no jogo
                     - ver oque precisa mudar no container para atualizar o valor 
                     - mudar no buffer 
                     - enviar um byte[] de como mudar esses dados em caso de encerramento brisco
                */

                if ( Modificar_estado_mental == null )
                        {
                                throw new Exception( "nao foi colocado fn: Modificar_estado_mental" );
                        }
                
                // pode alterar 1, 2, ... , todos ou nenhum 
                Modificar_estado_mental( estado_mental, _estado, _novo_valor );

                // salvar todos faz mais sentido
                
                Salvar_novo_valor();

                return;



    
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


        public enum Tipo_funcao_salvar_geral {

                modificar_personagem,
                
        }

        public enum Funcao_especifico_modificar_personagem {

                modificar_estado_mental,
                
        }



        public void Salvar_novo_valor( ){

                // ** tem que salvar todos os stats 

                // o padrao vai ser [ tipo_geral , tipo_especifico, args (...) ]

                //         tipo       funcionalidade     personagem_id     valor_1      valor_2   ...
                // [    ( 2 byte )    (  2 bytes  )      (  2 bytes  )   ( 2 bytes )   ( 2 bytes )   +    ]

                int numero_bytes_necessarios = 0 ;

                numero_bytes_necessarios += 2 ; // tipo_funcao_geral => modificar_personagem
                numero_bytes_necessarios += 2 ; // tipo_modificar_personagem => funcionalidade : mudar estado emocional
                numero_bytes_necessarios += 2 ; // personagem_id
                numero_bytes_necessarios += 16 ; // numero de emocoes_base.

                
                

                byte[] dados_para_salvar = new byte[ numero_bytes_necessarios ];

                dados_para_salvar[ 0 ] = ( byte )( int ) Tipo_funcao_salvar_geral.modificar_personagem << 8;
                dados_para_salvar[ 1 ] = ( byte )( int ) Tipo_funcao_salvar_geral.modificar_personagem << 0;


                dados_para_salvar[ 2 ] = ( byte )( int ) Funcao_especifico_modificar_personagem.modificar_estado_mental << 8;
                dados_para_salvar[ 3 ] = ( byte )( int ) Funcao_especifico_modificar_personagem.modificar_estado_mental << 0;

                Personagem_nome personagem_nome =  personagem.dados_sistema.nome_personagem;

                dados_para_salvar[ 4 ] = ( byte )( int ) personagem_nome << 8;
                dados_para_salvar[ 5 ] = ( byte )( int ) personagem_nome << 0;

                
                int ponto_inicial = 6;
                int index_emocao = 0;
                        
                for( index_emocao = 0 ; index_emocao < 8 ; index_emocao++ ){

                        int emocao_valor = ( int ) estado_mental.Pegar_valor_emocao_base( ( Emocao_base ) index_emocao );
                        
                        dados_para_salvar[ ponto_inicial + ( index_emocao * 2) + 0 ] = emocao_valor << 8;
                        dados_para_salvar[ ponto_inicial + ( index_emocao * 2) + 1 ] = emocao_valor << 0;
                        
                        
                }

                Controlador_personagens.Pegar_instancia().Pedir_para_salvar_dados( dados_para_salvar );


                byte[] dados_para_salvar_buffer = new byte[ 8 * 3 ];

                for(  index_emocao = 0 ; index_emocao < 8 ; index_emocao++ ){

                        dados_para_salvar_buffer[ ( index_emocao * 2) + 0 ] = dados_para_salvar[ ponto_inicial + ( index_emocao * 2) + 0 ];
                        dados_para_salvar_buffer[ ( index_emocao * 3) + 1 ] = dados_para_salvar[ ponto_inicial + ( index_emocao * 2) + 1 ];
                        
                        
                } 

                Controlador_personagem.Pegar_instancia().Salvar_dados_buffer( personagem );

                public void Salvar_dados_buffer( Personagem _personagem ){
                
                                // muda o buffer
                                // mudar o buffer não vai mudar o valor, vai somente deixar o novo valor na ram 
                                // nao vale a pena iniciar uma gravação para somente alguns bytes. É melhor deixar eles acumularem 
                
                                int tipo_armazenamento = personagem.dados_sistema.tipo_armazenamento;
                
                                // tipo de armazenamento importa aqui? 
                                // sim => porque ele precisar salvar o buffer
                
                                int ponto_inicial_container = 0;
                                
                                // pegar o nome certo depois
                                int container_id = Container_dados.Container_es
                
                                if( tipo_armazenamento == 0 )
                                        {
                                                // compresso 
                                                int[] localizadores = personagem.dados_sistema.localizadores_container_geral;
                                                ponto_inicial_container= localizadores[ container_id ];
                                                       
                                        }
                
                                
                
                                // temq que fazer uma funcao para pegar o numero
                                // pegar o ponto de algum jeito e fazer o jump caso seja o compacto. 
                                // eu nao estou gostando que essa classe tenha que levar em conta como que os dados são armazenados
                                // mas 
                                int ponto_iniciao_para_gravar_dados =  ponto_inicial_container + 0;
                
                                // container dados_personagens
                                // eu preciso definir como os containers são estruturados
                                personagem.dados_sistema.streams[ container ].Seek(  start_point,  SeekOrigin.Begin ) ;
                                personagem.dados_sistema.streams[ container ].Write( dados_retorno, 0 , dados_retorno.Length ) ;
                                
                
                                // passa para controaldor personagens o byte que pode reconstruir esse dados se o sistema sair bruscamente 
                                

                        
                        
                }
                

                return;

            
        }
            


}



