using System;


#if UNITY_EDITOR && ( REGIAO_1 || FORCAR_TUDO )

    public static class Leitor_interativos__CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO {

            public static Interativo_tela_DADOS_DESENVOLVIMENTO Pegar_interativo( Locator_position _posicao, int _interativo_id ){

                    CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__area area = ( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__area ) _posicao.local_position.zona_id;
                
                    switch( area ){

                        case CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__area.nara_room : return Leitor_interativos__CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM.Pegar_interativo( _posicao , _interativo_id  );
                    
                    }

                    throw new Exception( $"nao foi achado a area { area }" );   

                
            }

    }

#endif



//txt 

/*


    


*/