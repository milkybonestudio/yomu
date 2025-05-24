

public class MANAGER__resources { 


        //mark
        // ** FAZER PARA PEGAR EM UM CONTAINER


        // ** todos vao estar como minimo 

        // ** os recursos aqui nao são contatos como referencias
        // ** cada modo cria oque precisa e depois transfere para ca para verificar se ja terminou

        private int slot_intern;
        public RESOURCE__ref[] resource_refs = new RESOURCE__ref[ 200 ];

        // public _Resources_container r;

        
        public int Add( RESOURCE__ref _ref ){

                if( _ref == null )
                    { CONTROLLER__errors.Throw( "Tried to add a <Color=lightBlue>RESOURCE__ref</Color> in the container_checker, but it is null" ); }
            
                resource_refs[ slot_intern++ ] = _ref;

                if( resource_refs.Length == slot_intern )
                    { System.Array.Resize( ref resource_refs, ( resource_refs.Length + 50 ) ); }

                return ( slot_intern - 1 );



        }

        public int Add( ref RESOURCE__ref _resource_field, RESOURCE__ref _resource_value ){

                _resource_field = _resource_value;

                if( _resource_value == null )
                    { CONTROLLER__errors.Throw( "Tried to add a <Color=lightBlue>RESOURCE__ref</Color> in the container_checker, but it is null" ); }
            
                resource_refs[ slot_intern++ ] = _resource_value;

                if( resource_refs.Length == slot_intern )
                    { System.Array.Resize( ref resource_refs, ( resource_refs.Length + 50 ) ); }

                return ( slot_intern - 1 );



        }


        public void Add_multiples( RESOURCE__ref[] _refs, int _number_to_ignor = 0 ){

            for( int slot = _number_to_ignor; slot < _refs.Length; slot++ ){ 
                    if( _refs[ slot ] == null )
                        { return; }
                        
                    Add( _refs[ slot ] ); 
            }


        }



        public void Go_to_content_level_all_resources( Content_level _level ){

                for( int slot = 0 ; slot < slot_intern ; slot++ )
                    { resource_refs[ slot ].Go_to_content_level( _level ); }

        }

        public bool Got_to_content_level_all_resources( Content_level _level ){

                for( int slot = 0 ; slot < slot_intern ; slot++ ){ 

                    if( resource_refs[ slot ].Got_content_level( _level ) )
                        { return false; }
                    
                }
                return true;

        }



        //mark
        // ** seria bom as REFs terem um metodo que é o instanciate até o current content.
        // ** ou forçar a irem para o minimo

        public void Force_all_fulls_to_instanciate(){

                for( int slot = 0 ; slot < slot_intern ; slot++ ){ 

                    RESOURCE__ref resource = resource_refs[ slot ];

                    if( resource.state == Resource_state.active ) 
                        { resource.Instanciate(); }
                    
                }

        }



        



        // --- UP


            public void Load_all_resources(){

                    for( int slot = 0 ; slot < slot_intern ; slot++ )
                        { resource_refs[ slot ].Load(); }

            }

            public void Activate_all_resources(){

                    for( int slot = 0 ; slot < slot_intern ; slot++ )
                        { resource_refs[ slot ].Activate(); }

            }



            public void Instanciate_all_resources(){

                    for( int slot = 0 ; slot < slot_intern ; slot++ )
                        { resource_refs[ slot ].Instanciate(); }

            }

        // --- DOWN

            //mark
            // ** maybe just delete?
            public void Delete_all_resources(){

                for( int slot = 0 ; slot < slot_intern ; slot++ )
                    { 
                        resource_refs[ slot ].Delete();
                        resource_refs[ slot ] = null; 
                    }

                slot_intern = default;

            }

            public void Unload_all_resources(){

                    for( int slot = 0 ; slot < slot_intern ; slot++ )
                        { resource_refs[ slot ].Unload(); }

            }

            public void Deactivate_all_resources(){

                    for( int slot = 0 ; slot < slot_intern ; slot++ )
                        { resource_refs[ slot ].Deactivate(); }

            }






        // --- CHECKERS

        public bool All_resources_loaded(){

                for( int slot = 0 ; slot < slot_intern ; slot++ ){

                        if( !!!( resource_refs[ slot ].Got_to_minimum() ) )
                            { 
                                //Console.Log( "Resource " + resource_refs[ slot ].name + " did not finished in index " + slot );
                                return false;
                            }
                        
                }

                return true;

        }

        
        public bool Check_all_resources_are_full(){

            //performance
            // ** could be cached 

                for( int slot = 0 ; slot < slot_intern ; slot++ ){

                        if( !!!( resource_refs[ slot ].Got_to_full() ) )
                            { return false; }
                        
                }

                return true;

        }



}
