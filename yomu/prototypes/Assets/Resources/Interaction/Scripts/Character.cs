

using UnityEngine;

public abstract class Character{

    public string name;

    public Emotion emotion;

    public int affection;

    public abstract Sprite Get_sprite( Emotion _emotion );

    public Emotion Give_present( Present _present ){

        Give_present_ABS( _present );
        
        if( affection > 1_000 )
            { affection = 1_000; }

        if( affection < 0 )
            { affection = 0; }

        

        Debug.Log( "Current affection level: " + affection );

        if( affection < 300 )
            { 
                return Emotion.sad; 
            }

        if( affection < 700 )
            { return Emotion.happy; }

        return Emotion.horny;



    }

    protected abstract void Give_present_ABS( Present _present );

    public void Activate_physical( Physical_action _action ){

        Activate_physical_ABS( _action );

    }
    protected abstract void Activate_physical_ABS( Physical_action _action );

}
