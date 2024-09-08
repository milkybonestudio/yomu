
#if UNITY_EDITOR

    public static class Verificador_navegacao_DEVELOPMENT{

            public static void Verificar_ponto_para_pegar( Ponto[][][][] _pontos, Locator_position _posicao ){
                    
                    Ponto_DADOS_DEVELOPMENT ponto_dados =  Leitor_pontos.Pegar_ponto( _posicao );

                    // --- CHECA LOCAIS NA ZONA
                    Ponto[][][] locais_na_zona = _pontos[ _posicao.zona_id ];
                    if( locais_na_zona == null )
                            {  throw new System.Exception( $"nao foi criado os locais na zona { ponto_dados.zona_nome } na cidade { ponto_dados.cidade_no_trecho_nome }" ); }
                    if( locais_na_zona.Length < _posicao.local_id  )
                            {  throw new System.Exception( $"nao tinha o index do local { ponto_dados.local_nome } na zona { ponto_dados.zona_nome}, cidade { ponto_dados.cidade_no_trecho_nome }" ); }
                            
                    // --- CHECA AREAS NO LOCAL
                    Ponto[][] area_no_local = locais_na_zona[ _posicao.local_id ];
                    if( area_no_local == null )
                            {  throw new System.Exception( $"nao foi criado as areas no local { ponto_dados.local_nome}, cidade { ponto_dados.cidade_no_trecho_nome }" ); } 
                    if( area_no_local.Length < _posicao.area_id  )
                            {  throw new System.Exception( $"nao tinha o index da area { ponto_dados.area_nome } no local { ponto_dados.local_nome } na zona { ponto_dados.zona_nome}, cidade{ ponto_dados.cidade_no_trecho_nome }" ); }
                            
                    // --- CHECA PONTOS NA AREA
                    Ponto[] pontos_na_area = area_no_local[ _posicao.local_id ];
                    if( pontos_na_area == null )
                            {  throw new System.Exception( $"nao foi criado o ponto na area { ponto_dados.area_nome}, local { ponto_dados.local_nome }, zona { ponto_dados.zona_nome } ,cidade { ponto_dados.cidade_no_trecho_nome }" ); } 
                    if( pontos_na_area.Length < _posicao.ponto_id  )
                            {  throw new System.Exception( $"nao tinha o index do ponto { ponto_dados.ponto_nome }, na area { ponto_dados.area_nome } no local { ponto_dados.local_nome } na zona { ponto_dados.zona_nome}, cidade{ ponto_dados.cidade_no_trecho_nome }" ); }

                    // -- CHECA PONTO
                    Ponto ponto = pontos_na_area[ _posicao.ponto_id ];
                    if( ponto == null )
                            {  throw new System.Exception( $"nao foi criado o ponto { ponto_dados.ponto_nome }, na area { ponto_dados.area_nome } no local { ponto_dados.local_nome } na zona { ponto_dados.zona_nome}, cidade{ ponto_dados.cidade_no_trecho_nome }" ); }

            }

    }

#endif