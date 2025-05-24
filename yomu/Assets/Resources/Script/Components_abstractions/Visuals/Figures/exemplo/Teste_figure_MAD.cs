

public class Teste_figure_MAD : Figure_type<Teste_figure> {


    protected override Figure_mode_direction Get_default_direction(){ return Figure_mode_direction.left; }

    protected override void Link_left(){

        Link( "body", figure.body_1 );
        Link( "arms", figure.arms_1 );
        Link( "head", figure.head_1 );
        Link( "top", figure.top_1 );


        Link_mouth( "exp", figure.exp_1_mouth, Frame_rate._8 );
        // Link_emoji();

    }


    protected override void Link_right(){

        Link( "body", figure.body_1 );
        Link( "arms", figure.arms_1 );
        Link( "head", figure.head_1 );
        Link( "top", figure.top_1 );


        Link_mouth( "exp", figure.exp_1_mouth, Frame_rate._8 );
        // Link_emoji();

    }



        
}
