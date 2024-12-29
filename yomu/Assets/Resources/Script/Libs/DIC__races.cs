
public class DIC__races {

    static DIC__races(){

        if( number_of_races <= races.Length )
            { throw new System.Exception( "number pass number_of_races" ); }

    }

    public static Race[] races = ( Race[] ) System.Enum.GetValues( typeof( Race ) );

    public const int number_of_races = 15;

}