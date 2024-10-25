

public interface INTERFACE__figure {



    public string Get_main_folder(){ return "NOT GIVE"; } 

    public string Get_figure_name(){ return "NOT GIVE"; }


    public Resource_context Get_context(){ CONTROLLER__errors.Throw( $"Context not give in the figure { Get_figure_name() }" ); return Resource_context.Characters; }



    public void Update( Figure _figure ){ Console.Log( "Nao colocado Update()" ); }


    public void Blink( Figure _figure ){ Console.Log( "Nao colocado Blink()" ); }
    public void Speak( Figure _figure ){ Console.Log( "Nao colocado Speak()" ); }
    public void Change_emotion( Figure _figure, ulong _emotion ){ Console.Log( "Nao colocado Speak()" ); }


}