

public struct Position {

    public float x;
    public float y;

    public static Position Unitary() {

        return new Position(){ x = 1f, y = 1f };
    }   

    public static Position operator +( Position a, Position b ) {

        a.x += b.x;
        a.y += b.y;
        return a;

    }
    public static Position operator -( Position a, Position b ) {

        a.x -= b.x;
        a.y -= b.y;
        return a;

    }
    public static Position operator *( Position a, float b ) {

        a.x *= b;
        a.y *= b;
        return a;

    }



}
