


public class exemplo {}

public class CONTAINR_GENERICO_exemplo {


        private class Args {

            public int arg_1;

        }

        private void Put_data_args( int valor_arg ){

            args.arg_1 = valor_arg;

        }


        public static void Put_data( object _obj ){

            Args args = CONTAINR_GENERICO_exemplo.args;
            exemplo Exemplo = ( exemplo ) _obj;

            // ** change

        }

        public static void Remove_data( object _obj ){

            exemplo Exemplo = ( exemplo ) _obj;
            // ** change

        }


        private static Args args = new Args();

        public CONTAINER__generic container_generic = new CONTAINER__generic( typeof( exemplo ), 300, Put_data, Remove_data );

        public exemplo Get_exemplo( int valor_arg ){ Put_data_args( valor_arg ); return ( exemplo ) container_generic.Get(); }
        public void Return_exemplo( exemplo exemplo ){ container_generic.Return_object( exemplo ); }
        public int Update( int _weight_to_stop, int _current_weight  ){ return container_generic.Update( _weight_to_stop, _current_weight ); }




}