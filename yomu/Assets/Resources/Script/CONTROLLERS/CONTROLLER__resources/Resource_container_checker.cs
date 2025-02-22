

public class Resource_container_checker { 


        // ** todos vao estar como minimo 

        // ** os recursos aqui nao são contatos como referencias
        // ** cada modo cria oque precisa e depois transfere para ca para verificar se ja terminou

        private int slot_intern;
        public RESOURCE__ref[] resource_refs = new RESOURCE__ref[ 200 ];

        public void Add( RESOURCE__ref _ref ){

                if( _ref == null )
                    { CONTROLLER__errors.Throw( "Tried to add a <Color=lightBlue>RESOURCE__ref</Color> in the container_checker, but it is null" ); }
            
                resource_refs[ slot_intern++ ] = _ref;

                if( resource_refs.Length == slot_intern )
                    { System.Array.Resize( ref resource_refs, ( resource_refs.Length + 50 ) ); }



        }

        public void Load_all_resources(){

                for( int slot = 0 ; slot < slot_intern ; slot++ )
                    { resource_refs[ slot ].Load(); }

        }

        public bool All_resources_loaded(){

                for( int slot = 0 ; slot < slot_intern ; slot++ ){

                        if( !!!( resource_refs[ slot ].Got_to_minimun() ) )
                            { 
                                //Console.Log( "Resource " + resource_refs[ slot ].name + " did not finished in index " + slot );
                                return false; 
                            }
                        
                }

                return true;

        }


}
