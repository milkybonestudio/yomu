using System;


#if UNITY_EDITOR 

    public static class Leitor_interativos_tela {

        // !!! DEVLOPMENT
        
        public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar( Posicao _posicao, int _interativo_id ){


                Regiao_nome regiao =  ( Regiao_nome ) _posicao.regiao_id;
                
                switch( regiao ){

                    case Regiao_nome.regiao_1: return Leitor_interativos__REGIAO_1.Pegar( _posicao, _interativo_id );
                    default: throw new Exception( $"nao foi achado o handler para a cidade { regiao } no Leitor_interativos_tela_DESENVOLVIMENTO" );

                }

                

                return null;

        }

    }

#else

    public static class Leitor_interativos_tela {


        // --- INICIADO NO CONTROLADOR_DADOS_DINAMICOS
        public static Gerenciador_containers_dinamicos_parciais gerenciador_dados_parciais_interativos;
        public static byte[] localizador;
        
        
        public static byte[] Pegar_interativo( Posicao _posicao, int _interativo_id ){

                // para ler aqui o sistema tem que garantir que os valores funcionam 
                // 

                return null;
            
                // int pointer = -1;
                // pointer = localizador[ _posicao.regiao_id ];

                // gerenciador_dados_parciais.Pegar_dados(  )

        }



    }


#endif