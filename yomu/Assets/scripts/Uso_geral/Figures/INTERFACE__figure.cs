

using UnityEngine;

public interface INTERFACE__figure {


    public string Get_main_folder(){ return "NOT GIVE"; } 
    public string Get_figure_name(){ return "NOT GIVE"; }
    public Resource_context Get_context(){ CONTROLLER__errors.Throw( $"Context not give in the figure { Get_figure_name() }" ); return Resource_context.Characters; }


    public void Load_resources( Figure _figure, Figure_use_context _context_figure ){ CONTROLLER__errors.Throw( $"Load_images was not declared { Get_figure_name() }" ); return; }
    public Figure_resources_data Get_resources_data( Figure _figure, string _form ){ CONTROLLER__errors.Throw( $"Get_resources_data was not declared { Get_figure_name() }" ); return new Figure_resources_data(); }


    public void Change_form( Figure _figure, GameObject _new_form ){ CONTROLLER__errors.Throw( $"Change_form was not declared { Get_figure_name() }" ); return; }

    public void Update( Figure _figure ){ Console.Log( "Nao colocado Update()" ); }


    public void Blink( Figure _figure ){ Console.Log( "Nao colocado Blink()" ); }
    public void Speak( Figure _figure ){ Console.Log( "Nao colocado Speak()" ); }
    public void Change_emotion( Figure _figure, ulong _emotion ){ Console.Log( "Nao colocado Speak()" ); }


}