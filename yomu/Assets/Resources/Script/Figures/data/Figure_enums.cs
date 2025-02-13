

public enum Figure_use_context {

        // ** this is used in a static field in the Figure class. every time that I need to use the field I need to remember to change later to not_give after
        // ** would be something like
        /*
            Figure.use_context = Figure_use_context.conversation;

            Figures.Add( Figure_1() )
            Figures.Add( Figure_2() )
            Figures.Add( Figure_3() )
            .
            .
            .
            Figures.Add( Figure_n() )

            Figure.use_context = Figure_use_context.conversation;

        
        */ 

        not_give,
        conversation, 
        visual_novel,

}




public enum Figure_mode_type {

    mad,

    END,

}





