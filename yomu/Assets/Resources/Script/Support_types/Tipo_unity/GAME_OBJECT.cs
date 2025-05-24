using UnityEngine;



public static class GAME_OBJECT {


        public static GameObject Get_game_object( GameObject _game_object_to_search, string _path ){

                string root_path = Pegar_path( _game_object_to_search );
                string path = ( root_path + "/" + _path );

                GameObject ret = GameObject.Find( path );

                if( ret == null )
                    { CONTROLLER__errors.Throw( $"Did not find the game_object in the path <Color=lightBlue>{ path }</Color>" ); }

                return ret;




        }


        public static GameObject Find( string _path , string _message_on_not_find = "not find" ){

            GameObject game_object = GameObject.Find( _path );

            if( game_object == null )
                { CONTROLLER__errors.Throw( _message_on_not_find + ". path: " + _path ); }

            return game_object;

        }




        public static GameObject Criar_filho( string _nome, GameObject _pai ){

                GameObject retorno = new GameObject( _nome );
                retorno.transform.SetParent( _pai.transform, false );
                return retorno;

        }

        public static void Colocar_parent( GameObject _pai, GameObject _filho ){


                if( _pai == null )
                    { CONTROLLER__errors.Throw( "Tried to change parente , but the <Color=lightBlue>_pai</Color> is null" ); }

                if( _filho == null )
                    { CONTROLLER__errors.Throw( "Tried to change parente , but the <Color=lightBlue>_filho</Color> is null" ); }

                _filho.transform.SetParent( _pai.transform, false );

        }


        public static void  Deletar_todos_os_filhos( GameObject _obj ) {


                // isso nao deveria estar aqui, deveria estar em finalizar de cada bloco

                int numero_de_filhos = _obj.transform.childCount;
                
                for( int game_object_index = 0 ; game_object_index < numero_de_filhos ; game_object_index++ ){

                        GameObject obj_para_destruir = _obj.transform.GetChild( game_object_index ).gameObject;
                        GameObject.Destroy( obj_para_destruir );

                }                
        
        }



        public static string Pegar_path( GameObject _game_object ){

            if( _game_object == null )
                { throw new System.Exception( $"Tentou pegar o path de um game object  mas ele estava null" ); }



            int index = 99;
            string[] nomes = new string[ 100 ];
            nomes[ index ] = _game_object.name;
            index--;            
            nomes[ index ] = "/";
            index--;


            Transform transform = _game_object.transform.parent;

            nomes[ index ] = transform.gameObject.name;
            index--;
            nomes[ index ] = "/";
            index--;


            int trava_de_seguranca = 0;
            int numero_maximo = 100;

            while( true ){

                    trava_de_seguranca++;
                    if( trava_de_seguranca > numero_maximo )
                        { CONTROLLER__errors.Throw( $"Em pegar o path _game_object a trava de seguranca foi ativada, teve { numero_maximo }" ); }

                    transform = transform.parent;

                    if( transform == null )
                        { 
                            // --- NAO COLOCA O ULTIMO "/"
                            nomes[ ( index + 1 )] = null;
                            break; 
                        }

                    nomes[ index ] = transform.gameObject.name;
                    index--;
                    nomes[ index ] = "/";
                    index--;
                    
                    continue;

            }

            string path__game_object = string.Concat( nomes );

            return path__game_object;

        }



}