using UnityEngine;


public static class Shaders {


    public static Shader normal = Shader.Find( "Teste" );
    public static Shader teste_shader = Shader.Find( "Shader Graphs/Teste_shader" );
    public static Shader figure = Shader.Find( "Shader Graphs/Figure" );
    public static Shader screen_view = Shader.Find( "Shader Graphs/Screen_shader" );

    public static Shader individual_components = Shader.Find( "Shader Graphs/Individual_component" );

        // ** MASK SELF
        public const string individual_components_mask_is_active = "_rect_mask_is_active";
        public const string individual_components_mask_dimensions = "_rect_mask_dimensions";


        // ** MASK POSITION
        public const string individual_components_mask_position_is_active = "_rect_mask_position_is_active";
        public const string individual_components_mask_position_variables = "_rect_mask_position_variables";


    public static Shader _DEFAULT = Shader.Find( "Shader Graphs/Default" );



}