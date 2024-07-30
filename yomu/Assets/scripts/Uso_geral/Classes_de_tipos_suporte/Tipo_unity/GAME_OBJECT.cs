using UnityEngine;



public static class GAME_OBJECT {


        public static GameObject Criar_filho( string _nome, GameObject _pai ){

                GameObject retorno = new GameObject( _nome );
                retorno.transform.SetParent( _pai.transform, false );
                return retorno;

        }

        public static void Colocar_parent( GameObject _pai, GameObject _filho ){



        }


        public static void  Deletar_todos_os_filhos( GameObject _obj ) {


                // isso nao deveria estar aqui, deveria estar em finalizar de cada bloco

                int numero_de_filhos = _obj.transform.childCount;
                
                for( int game_object_index = 0 ; game_object_index < numero_de_filhos ; game_object_index++ ){

                        GameObject obj_para_destruir = _obj.transform.GetChild( game_object_index ).gameObject;
                        GameObject.Destroy( obj_para_destruir );

                }                
        
        }

}