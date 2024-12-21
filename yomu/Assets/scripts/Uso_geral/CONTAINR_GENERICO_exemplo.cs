


public class exemplo {}

public class CONTAINR_GENERICO_exemplo : CONTAINER__generic {


        public CONTAINR_GENERICO_exemplo(){

                type = typeof( exemplo );
                Start( 100 ); // ** default number 

        }

        public override void Reset_data( object _obj ){

            exemplo Exemplo = ( exemplo ) _obj;
            // ** change

        }

        public exemplo Get_exemplo( int valor_arg ){ return ( exemplo ) Get(); }


}