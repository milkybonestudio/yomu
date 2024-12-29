

// ** no editor pode ser o normal?
// ** nao, tem que ver quais vao ser instanciados

public class CONTAINER__items_EDITOR : CONTAINER__entities<Item>  {


        public CONTAINER__items_EDITOR() : base( ( int ) Item_type.END ) {

                // ** talvez depois teste pode influenciar em oque vai ser carregado ou fazerr alguma modificacao
                DATA__constructor_controller_items__TYPE_NAMED.Create( entities );

        }


}
