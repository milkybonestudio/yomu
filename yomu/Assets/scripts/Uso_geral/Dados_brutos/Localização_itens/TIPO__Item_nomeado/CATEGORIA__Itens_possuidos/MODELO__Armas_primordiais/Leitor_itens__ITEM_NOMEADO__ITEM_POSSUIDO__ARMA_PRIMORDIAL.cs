using Unity;
using System;


#if UNITY_EDITOR && ( ITENS_TIPO__ITENS_NOMEADOS || ITENS_CATEGORIA__ITENS_POSSUIDOS || ITENS_MODELO__ARMAS_PRIMORDIAIS || FORCAR_TODOS_OS_ITENS  ) || true

public static class Leitor_itens__ITEM_NOMEADO__ITEM_POSSUIDO__ARMA_PRIMORDIAL {

        public static Item[] itens;

        public static Item Pegar_item( Item_localizador _item_localizador ){


        int item_id = _item_localizador.item_id;

        if( itens == null )
                { 
                    Colocar_itens();
                     
                    // ** ver depois
                    // Type tipo_item = typeof( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__UP__interativo );
                    // string nome_area = typeof( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__ponto ).Namespace;

                    // Verificador_itens_DESENVOLVIMENTO.Verificar_itens( tipo_item, nome_area, ref dados );
                }

        if( itens[ item_id ] == null )
                { throw new Exception( $" o interativo { ( CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM__UP__interativo ) item_id } na nao foi criado" ); }


        return itens[ item_id ];

    }


    public static void Colocar_itens(){

            itens = new Item[ 100 ];

            // --- ZERO

            int index = 0;

            // ------------------
             


    }



}

#endif