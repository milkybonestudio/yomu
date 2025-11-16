

using UnityEngine;
using UnityEngine.UI;

public class Actions_bar {

    public Actions_bar(){

        // massage

        container = GameObject.Find( "Canvas/Barras/Barra_message/Actions_container" );

        gifts_bar = GameObject.Find( "Canvas/Barras/Barra_message/Actions_container/Gifts_container" );
        gift_button = GameObject.Find( "Canvas/Barras/Barra_message/Actions_container/Buttons/Gifts_button" ).GetComponent<Button>();
        gift_button.onClick.AddListener( Go_to_gifts );

        physical_bar = GameObject.Find( "Canvas/Barras/Barra_message/Actions_container/Physical_container" );
        physical_button = GameObject.Find( "Canvas/Barras/Barra_message/Actions_container/Buttons/Physical_button" ).GetComponent<Button>();
        physical_button.onClick.AddListener( Go_to_physical );

        mental_bar = GameObject.Find( "Canvas/Barras/Barra_message/Actions_container/Mental_container" );
        mental_button = GameObject.Find( "Canvas/Barras/Barra_message/Actions_container/Buttons/Mental_button" ).GetComponent<Button>();
        mental_button.onClick.AddListener( Go_to_mental );


        Hide_all();
        Go_to_physical();

    }

    public void Update(){

        can_go = true;

    }

    public void Hide(){ container.SetActive( false ); }
    public void Show(){ container.SetActive( true ); }


    private bool can_go = true;
    private void Hide_all(){

        gifts_bar.SetActive( false );
        physical_bar.SetActive( false );
        mental_bar.SetActive( false );

    }
    public void Go_to_gifts(){
        if( !!!( can_go ) )
            { return; }

        Hide_all();
        can_go = false;
        gifts_bar.SetActive( true );
    }
    public void Go_to_physical(){
        if( !!!( can_go ) )
            { return; }
        Hide_all();
        can_go = false;
        physical_bar.SetActive( true );
    }
    public void Go_to_mental(){
        if( !!!( can_go ) )
            { return; }
        Hide_all();
        can_go = false;
        mental_bar.SetActive( true );
    }

    public GameObject container;

    public Button gift_button;
    public Button physical_button;
    public Button mental_button;

    public GameObject gifts_bar;
    public GameObject physical_bar;
    public GameObject mental_bar;


}