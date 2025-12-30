

public static class Random {

    public static System.Random random =  new System.Random();
    
    public static float Pegar_chance(){

            return  ((float) (random.Next(  100001 ) ) ) / 100000f;

    }

}