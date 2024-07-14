

using UnityEngine;


public class Container_itens {

        public Item_localizador[] itens;
        public int[] quantidade_itens;
        public int numero_maximo_slots;
        // public item_info[] itens_info;

}

public static class Manipulador_itens {


        public static void Trocar_itens_containers( Container_itens _container_1, Item_localizador[] _itens_1, Container_itens _container_2, Item_localizador[] _itens_2 ){}
        public static int Pegar_quantidade_do_mesmo_item_no_container( Container_itens _container_1, Item_localizador _item_localizador ){ return 0; }


        public static void Trocar_itens_personagens( Personagem _personagem_1, Item_localizador[] _itens_1,  Personagem _personagem_2, Item_localizador[] _itens_2 ){}
        public static void Adicionar_itens_personagem( Personagem _personagem, Item_localizador[] _itens ){}
        public static void Remover_itens_personagem( Personagem _personagem, Item_localizador[] _itens ){}
        


}