using UnityEngine;

public class Player_inputs {

    public Options options;

    public int Check(){

        if( options.click_auto )
            { return Auto(); }

        if( options.click_pass_turn )
            { return Pass_turn(); }

        return 0;

    }

    
    public void Update(){

        Check();
        options = default;

    }


    public int Auto(){

        return 0;

    }

    public int Pass_turn(){

        return 0;

    }



}