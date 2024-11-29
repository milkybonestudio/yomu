using UnityEngine;



public static class GAME_OBJECT {


        public static GameObject Find( string _path , string _message_on_not_find, bool _throw_exception ){

            GameObject game_object = GameObject.Find( _path );

            if( game_object == null )
                { 
                    if( _throw_exception )
                        { throw new System.Exception(_message_on_not_find ); }
                        else
                        { Console.LogError( _message_on_not_find ); }
                     
                }
            return game_object;

        }




        public static GameObject Criar_filho( string _nome, GameObject _pai ){

                GameObject retorno = new GameObject( _nome );
                retorno.transform.SetParent( _pai.transform, false );
                return retorno;

        }

        public static void Colocar_parent( GameObject _pai, GameObject _filho ){

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