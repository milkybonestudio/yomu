

public struct Look_safer {

    public bool re_do;

    public int times;
    private int times_full;
    private bool get;

    public void Check(){

        if( !!!( get ) )
            { times_full = times; }

        if( times-- < 0 )
            { CONTROLLER__errors.Throw( $"check out <Color=lightBlue>{ times_full }</Color>" ); }

        re_do = false;

    }


}