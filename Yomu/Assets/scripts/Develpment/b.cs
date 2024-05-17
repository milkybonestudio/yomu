using UnityEngine;
using UnityEngine.UI;





/*


    movimento => clicar em coisas 
    conversas => clicar em coisas 


*/




// estaria no prefab
public class Container_teste : MonoBehaviour {

    public static Container_teste instancia;
    public Container_teste(){
        instancia = this;
    }

    public Button botao;




}



public class Teste_botao {

    public GameObject game_object;

    // public Botao botao = new Botao( 

    //         _parent_transform : game_object.transform,
    //         info 

    // )



}