

using UnityEngine;
using UnityEngine.UI;


public class Bars_message {

    public Bars_message(){

        // massage

        container = GameObject.Find( "Canvas/Barras/Barra_message" );

        actions_bar = new Actions_bar();
        actions_button = GameObject.Find( "Canvas/Barras/Barra_message/Buttons/Actions_button" ).GetComponent<Button>();
        actions_button.onClick.AddListener( Go_to_actions );

        topics_bar = GameObject.Find( "Canvas/Barras/Barra_message/Topics_container" );
        topics_button = GameObject.Find( "Canvas/Barras/Barra_message/Buttons/Topics_button" ).GetComponent<Button>();
        topics_button.onClick.AddListener( Go_to_topics );

        debate_bar = GameObject.Find( "Canvas/Barras/Barra_message/Debate_container" );
        debate_button = GameObject.Find( "Canvas/Barras/Barra_message/Buttons/Debate_button" ).GetComponent<Button>();
        debate_button.onClick.AddListener( Go_to_debate );


        Hide_all();
        Go_to_actions();

    }


    public void Update(){

        actions_bar.Update();

        can_go = true;

    }

    private bool can_go = true;
    private void Hide_all(){

        actions_bar.Hide();
        topics_bar.SetActive( false );
        debate_bar.SetActive( false );

    }
    public void Go_to_actions(){
        if( !!!( can_go ) )
            { return; }

        Hide_all();
        can_go = false;
        actions_bar.Show();
    }

    public void Go_to_topics(){
        if( !!!( can_go ) )
            { return; }
        Hide_all();
        can_go = false;
        topics_bar.SetActive( true );
    }

    public void Go_to_debate(){
        if( !!!( can_go ) )
            { return; }
        Hide_all();
        can_go = false;
        debate_bar.SetActive( true );
    }

    public GameObject container;

    public Button actions_button;
    public Button topics_button;
    public Button debate_button;

    
    public Actions_bar actions_bar;
    public GameObject topics_bar;
    public GameObject debate_bar;



}