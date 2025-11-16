

using UnityEngine;
using UnityEngine.UI;


public enum Emotion{

    happy,
    sad, 
    horny,
    fear,
    neutral,
    rage,
    

}

public class Lily : Character{


    public Lily(){

        emotion = Emotion.happy;
        name = "Lily";

    }


    protected override void Activate_physical_ABS( Physical_action _action ){

        
        if( _action == Physical_action.kiss  )
            {
                if( affection < 500 )
                    { Controllers.text.Change_text( "eh... is too early for this" ); return; }
                
                if( affection >= 500 )
                    { Controllers.text.Change_text( "*chu*~" ); return; }
            }

        if(_action == Physical_action.hug )
            { Controllers.text.Change_text( "Someone is feeling a little lonely?" ); return; }


    }

    public override Sprite Get_sprite(Emotion _emotion){

        Sprite s = Resources.Load<Sprite>( Paths.Get_path( $"Characters/Lily/{ _emotion.ToString() }" ) );

        Debug.Log( "Vai pegar sprite da emotion " + _emotion );
        if( s == null )
            { throw new System.Exception( $"Did not find the sprite for the emotion { _emotion }" ); }

        return  s;
        
    }

    protected override void Give_present_ABS( Present _present ){

        switch( _present ){

            case Present.flor_azul: Controllers.text.Change_text( "Thanks my good fellow!" ); affection += 50; break;
            case Present.flor_vermelha: Controllers.text.Change_text( "yeh... thanks" ); affection -= 50; break;
            default: throw new System.Exception( $"Can not handle present {_present }" );

        }

    }

}



public class CONTROLLER__character {

    public CONTROLLER__character(){

        game_object = GameObject.Find( "Canvas/Character" );
        button_remove_scene_hide_game_object = GameObject.Find( "Canvas/Button_remove_scene_hide");
        button_remove_scene_hide = button_remove_scene_hide_game_object.GetComponent<Button>();

        button_remove_scene_hide_game_object.SetActive( false );

        button_remove_scene_hide.onClick.AddListener(()=>{

            button_remove_scene_hide_game_object.SetActive( false );
            image.color = Color.white;
            Controllers.text.Change_text( "..." );


        });

        rect = game_object.GetComponent<RectTransform>();
        image = game_object.GetComponent<Image>();
        game_object.transform.localScale = new Vector3( 1.5f,1.5f,1.5f );

    }


    public void Set_character( Character _character ){

        Debug.Log( "Veio set character" );
        current_character = _character;
        sprite = _character.Get_sprite( _character.emotion );
        image.sprite = sprite;
        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, sprite.rect.width );
        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, sprite.rect.height );

        Controllers.text.Change_character( _character.name );
        
    }

    public Button button_remove_scene_hide;
    public GameObject button_remove_scene_hide_game_object;

    public Image image;
    public GameObject game_object;
    public Sprite sprite;
    public RectTransform rect;
    public Character current_character;

    public void Change_emotion( Emotion _emotion ){

        sprite = current_character.Get_sprite( _emotion );
        image.sprite = sprite;
        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, sprite.rect.width );
        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, sprite.rect.height );

    }


    public void Physical_action( Physical_action _action ){

        // ** fazer tela ficar escura 
        image.color = Color.clear;
        button_remove_scene_hide_game_object.SetActive( true );

        current_character.Activate_physical( _action );

    }

    public void Give_present( Present _present ){

        Change_emotion( current_character.Give_present( _present ) );

    }

    public void Change_image( string _image ){

        sprite = Resources.Load<Sprite>( Paths.Get_path( _image ) );
        image.sprite = sprite;
        RectTransform rect = game_object.GetComponent<RectTransform>();
            rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, sprite.rect.width );
            rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, sprite.rect.height );
        

    }

}