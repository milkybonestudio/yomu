


// ** CONTENT
using UnityEngine;

public abstract partial class Figure {


    // public Figure_contents_states contents_states;
    public Figure_content current_content;
    public Figure_content minimun_content;
    public Figure_content final_content;

    public Content_level current_content_level;

    public Content_level[] content_levels_modes = new Content_level[ ( int ) Figure_mode.END ];





    private int Update_content( Control_flow _flow ){

            int weight = 0;

            Console.Log( Figure.teste, $"----Update content figure:" );
            Console.Log( Figure.teste, $"--------Current_content: <Color=lightBlue>{ current_content }</Color>" );
            Console.Log( Figure.teste, $"--------Final_contet: <Color=lightBlue>{ final_content }</Color>" );

            // Console.Log( "Current content: " +  current_content );

            switch( current_content ){

                case Figure_content.nothing: Check_nothing( _flow ); break;
                    case Figure_content.construct_modes: Check_construct_modes( _flow ); break;
                        case Figure_content.create_body: Check_create_body( _flow ); break;
                            case Figure_content.modes_content: Check_modes_content( _flow ); break;
                                case Figure_content.start_mode_full_content: Check_start_mode_full_content( _flow ); break;
                                    case Figure_content.finished: break;
                                        default : CONTROLLER__errors.Throw( "State not accept: " + current_content ); return -1;

            }

            return weight;

    }


    private void Check_nothing( Control_flow _flow ){

        if( current_content < final_content  )
            {
                current_content = Figure_content.construct_modes;
            }


    }



    protected abstract void Construct_modes();
    private void Construct_modes_intern(){

                Construct_modes();

                #if UNITY_EDITOR

                    if( !!!( modes.Mode_exist( data.start_mode  ) ) )
                        { CONTROLLER__errors.Throw( $"The start mode is <Color=lightBlue>{ data.start_mode }</Color> in the figure <Color=lightBlue>{ name }</Color>. But it do not exist. Was not declared in the <Color=lightBlue>Contruct_modes()</Color>" ); }

                #endif

    }


    private void Check_construct_modes( Control_flow _flow ){

        if( current_content < final_content )
            {
                Construct_modes_intern();
                current_content = Figure_content.create_body;
                
            }

    }

    
    private void Check_create_body( Control_flow _flow ){

        if( current_content < final_content )
            {
                body.Set_body_constructor_data(new(){
                    put_in_container = true,
                });

                body.Create();
                current_content = Figure_content.modes_content;
            }

    }
    


    
    private void Check_modes_content( Control_flow _flow ){

        
        foreach( FIGURE_MODE mode in modes.Get_values() ){
            mode.Change_content_level( content_levels_modes[ ( int ) mode.visual_figure ] );
        }

        if( current_content < final_content )
            {
                foreach( FIGURE_MODE mode in modes.Get_values() ){
                    if( !!!( mode.Got_content_level( content_levels_modes[ ( int ) mode.visual_figure ] ) ) )
                        { return; }
                }

                current_content = Figure_content.start_mode_full_content;
                return;            
            }




    }



    private void Check_start_mode_full_content( Control_flow _flow ){

        FIGURE_MODE mode = modes.Get( data.start_mode );
        mode.Change_content_level( Content_level.full );

        // ** nao pode fazer content_levels_modes[ mode ] como full, pois quando der o down, ele vai ser usado para definir o final_content
        // ** ele só vai ser carregado porque é o primeiro
        if( current_content < final_content )
            {
                
                if( mode.Got_content_level( Content_level.full ) )
                    { current_content = Figure_content.finished; }

                return;            
            }

        // ** *

    }







    private void Instanciate_content(){

        
            current_content_level = Content_level.full;

            if( current_content == Figure_content.finished )
                { return; }


            if( current_content == Figure_content.nothing )
                {
                    current_content = Figure_content.construct_modes;
                }

            if( current_content == Figure_content.construct_modes )
                {
                    Construct_modes_intern();
                    current_content = Figure_content.create_body;
                }

            if( current_content == Figure_content.create_body )
                {
                    body.Create( null );
                    current_content = Figure_content.modes_content;
                }

            if( current_content == Figure_content.modes_content )
                {
                    modes.Change_content_levels( content_levels_modes );
                    current_content = Figure_content.start_mode_full_content;
                }                


            if( current_content == Figure_content.start_mode_full_content )
                {
                    modes.Get( data.start_mode ).Change_content_level(  Content_level.full );
                    current_content = Figure_content.finished;
                }

    }



}
