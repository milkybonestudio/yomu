

#if !UNITY_EDITOR 

        public static class Verificador_movimento_DEVELOPMENT{

            public static void Verificar_movimento_personagem_PONTO( Personagem _personagem, Posicao _nova_posicao ){

                    Posicao posicao_atual = _personagem.posicao;

                    // --- REGIAO
                    if( posicao_atual.regiao_id != _nova_posicao.regiao_id )
                        { throw new System.Exception( $"tentou mover o personagem { _personagem.nome_personagem } para o ponto { _nova_posicao.ponto_nome } mas a regiao estava diferente. Regiao do personagem: { posicao_atual.regiao_nome } e a cidade da nova posicao: { _nova_posicao.regiao_nome }" ); }

                    // --- TRECHO
                    if( posicao_atual.trecho_id != _nova_posicao.trecho_id )
                        { throw new System.Exception( $"tentou mover o personagem { _personagem.nome_personagem } para o ponto { _nova_posicao.ponto_nome } mas o trecho estava diferente. Trecho do personagem: { posicao_atual.trecho_nome } e a cidade da nova posicao: { _nova_posicao.trecho_nome }" ); }
                    
                    // --- CIDADE NO TRECHO
                    if( posicao_atual.cidade_no_trecho_id != _nova_posicao.cidade_no_trecho_id )
                        { throw new System.Exception( $"tentou mover o personagem { _personagem.nome_personagem } para o ponto { _nova_posicao.ponto_nome } mas a cidade estava diferente. Cidade do personagem: { posicao_atual.cidade_no_trecho_nome } e a cidade da nova posicao: { _nova_posicao.cidade_no_trecho_nome }" ); }

                    // --- ZONA
                    if( posicao_atual.zona_id != _nova_posicao.zona_id )
                        { throw new System.Exception( $"tentou mover o personagem { _personagem.nome_personagem } para o ponto { _nova_posicao.ponto_nome } mas a zona estava diferente. Zona do personagem: { posicao_atual.zona_nome } e a cidade da nova posicao: { _nova_posicao.zona_nome }" ); }

                    // --- LOCAL
                    if( posicao_atual.local_id != _nova_posicao.local_id )
                        { throw new System.Exception( $"tentou mover o personagem { _personagem.nome_personagem } para o ponto { _nova_posicao.ponto_nome } mas o local estava diferente. Zona do personagem: { posicao_atual.local_nome } e a cidade da nova posicao: { _nova_posicao.local_nome }" ); }

                    // --- AREA
                    if( posicao_atual.zona_id != _nova_posicao.zona_id )
                        { throw new System.Exception( $"tentou mover o personagem { _personagem.nome_personagem } para o ponto { _nova_posicao.ponto_nome } mas a area estava diferente. Zona do personagem: { posicao_atual.ponto_nome } e a cidade da nova posicao: { _nova_posicao.area_nome }" ); }
                        
                    
                    return;

            }

            public static void Verificar_movimento_personagem_LOCAL( Personagem _personagem, Posicao _nova_posicao ){

                    Posicao posicao_atual = _personagem.posicao;

                    // --- REGIAO
                    if( posicao_atual.regiao_id != _nova_posicao.regiao_id )
                        { throw new System.Exception( $"tentou mover o personagem { _personagem.nome_personagem } para o local { _nova_posicao.local_nome } mas a regiao estava diferente. Regiao do personagem: { posicao_atual.regiao_nome } e a cidade da nova posicao: { _nova_posicao.regiao_nome }" ); }

                    // --- TRECHO
                    if( posicao_atual.trecho_id != _nova_posicao.trecho_id )
                        { throw new System.Exception( $"tentou mover o personagem { _personagem.nome_personagem } para o local { _nova_posicao.local_nome } mas o trecho estava diferente. Trecho do personagem: { posicao_atual.trecho_nome } e a cidade da nova posicao: { _nova_posicao.trecho_nome }" ); }
                    
                    // --- CIDADE NO TRECHO
                    if( posicao_atual.cidade_no_trecho_id != _nova_posicao.cidade_no_trecho_id )
                        { throw new System.Exception( $"tentou mover o personagem { _personagem.nome_personagem } para o local { _nova_posicao.local_nome } mas a cidade estava diferente. Cidade do personagem: { posicao_atual.cidade_no_trecho_nome } e a cidade da nova posicao: { _nova_posicao.cidade_no_trecho_nome }" ); }

                    // --- ZONA
                    if( posicao_atual.zona_id != _nova_posicao.zona_id )
                        { throw new System.Exception( $"tentou mover o personagem { _personagem.nome_personagem } para o local { _nova_posicao.local_nome } mas a zona estava diferente. Zona do personagem: { posicao_atual.zona_id } e a cidade da nova posicao: { _nova_posicao.zona_id }" ); }

                    return;

            }

            public static void Verificar_movimento_personagem_CIDADE( Personagem _personagem, Posicao _nova_posicao ){

                    // regiao pode 

                    Posicao posicao_atual = _personagem.posicao;
                    // fazer depois: 

                    byte[] regioes_possiveis = REGIOES_INFO.regioes_ao_arredor[ posicao_atual.regiao_id ];

                    if( posicao_atual.cidade_no_trecho_id != _nova_posicao.cidade_no_trecho_id )
                        {  throw new System.Exception( $"tentou mover o personagem { ( Personagem_nome ) _personagem.personagem_id } para o ponto { _nova_posicao.posicao_id } mas a " ); }


            }

        }


        public static class REGIOES_INFO {

                public static short[][] regioes_ao_arredor = new short[][]{


                    new short[ 4 ]{ -1, -1, -1, -1 },  // 0
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 1 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 2
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 3 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 4 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 5 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 6 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 7
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 8 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 9
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 10
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 11 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 12
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 13 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 14 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 15 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 16 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 17
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 18 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 19
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 20
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 21 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 22
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 23 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 24 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 25 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 26 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 27
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 28 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 29
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 30
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 31 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 32
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 33 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 34 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 35 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 36 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 37
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 38 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 39
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 40
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 41 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 42
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 43 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 44 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 45 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 46 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 47
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 48 
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 49
                    new short[ 4 ]{ -1, -1, -1, -1 },  // 50


                }


        }


#endif