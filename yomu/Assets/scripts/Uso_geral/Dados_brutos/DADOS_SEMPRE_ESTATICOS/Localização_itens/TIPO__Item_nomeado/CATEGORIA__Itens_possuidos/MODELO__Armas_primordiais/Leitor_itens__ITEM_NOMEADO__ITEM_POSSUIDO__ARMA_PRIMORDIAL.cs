using Unity;
using System;


#if UNITY_EDITOR && ( ITENS_TIPO__ITENS_NOMEADOS || ITENS_CATEGORIA__ITENS_POSSUIDOS || ITENS_MODELO__ARMAS_PRIMORDIAIS || FORCAR_TODOS_OS_ITENS  ) || true

public static class Leitor_itens__ITEM_NOMEADO__ITEM_POSSUIDO__ARMA_PRIMORDIAL {

        public static Item_DADOS_DEVELOPMENT[] itens;

        public static Item_DADOS_DEVELOPMENT Pegar_item( Item_localizador _item_localizador ){


        int item_id = _item_localizador.item_id;

        if( itens == null )
                { 
                    Colocar_itens();
                     
                    Type tipo_item = typeof( ITEM__ITENS_NOMEADOS__ITENS_POSSUIDOS__ARMAS_PRIMORDIAIS__item );
                    // string nome_area = typeof( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__ponto ).Namespace;
                    Verificador_itens_DESENVOLVIMENTO.Verificar_itens(  ref itens );
                    Marcador_de_nomes_DEVELOPMENT.Colocar_nome_itens( tipo_item, itens );


                }

        if( itens[ item_id ] == null )
                { throw new Exception( $" o item { ( ITEM__ITENS_NOMEADOS__ITENS_POSSUIDOS__ARMAS_PRIMORDIAIS__item ) item_id } na nao foi criado" ); }


        return itens[ item_id ];

    }


    public static void Colocar_itens(){

            itens = new Item_DADOS_DEVELOPMENT[ 100 ];

            // --- ZERO

            int index = 0;

            // ------------------

            index = ( int ) ITEM__ITENS_NOMEADOS__ITENS_POSSUIDOS__ARMAS_PRIMORDIAIS__item.hokushi;
             


    }



}

#endif