


using UnityEngine;

public static class CONSTRUCTOR__controller_items {


        public static CONTROLLER__items Construct(){

                #if UNITY_EDITOR 
                    return Construct__EDITOR();
                #endif

                // switch( plat )
                throw new System.Exception( "Tem que fazer " );
        }

        private static CONTROLLER__items Construct__EDITOR(){

                if( CONTROLLER__items.instance != null )
                    { return CONTROLLER__items.instance; } // ** se nao deu reload -> o codigo esta o mesmo

                CONTROLLER__items controller = new CONTROLLER__items();
                CONTROLLER__items.instance = controller;

                controller.container_items = new CONTAINER__items_EDITOR();

                controller.operations_items = new OPERATIONS__items (
                                                                        _controller : controller,
                                                                        _saving: new OPERATIONS__items_SAVING__EDITOR(),
                                                                        _verifications : new OPERATIONS__items_VERIFICATIONS_EDITOR( null )
                                                                    );

                return controller;

        }


}

