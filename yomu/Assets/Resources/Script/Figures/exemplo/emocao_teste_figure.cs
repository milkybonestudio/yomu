

public class Teste_figure_MAD : Figure_type<Teste_figure> {
        

        public override void Link_resources_main(){

                Link( "body", figure.body_1 );
                Link( "arms", figure.arms_1 );
                Link( "top", figure.top_1 );
                Link( "head", figure.head_1 );


                Link_mouth( "exp", figure.exp_1_mouth, Frame_rate._8 );
                Link_emoji();

        }

        


}






