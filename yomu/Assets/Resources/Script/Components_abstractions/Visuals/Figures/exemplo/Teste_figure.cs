using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public struct Figure_creation_data {

    public Figure_mode start_mode;

    public Content_level content_level_modes_default;

    public Body_data_creation body_data_creation;

}


public struct Resource_image_find_data {

    public string path_root;
    public string path;

    public string main;

}

public struct Resource_image_find_data_array {

    public string main;

    public string path;
    public string path_root;
    
    public int number_images;

}


public class Teste_figure : Figure {


        /*
            logica: 
                    -> static Construct()
                    -> classe static Suport.Put_data()
                    -> fields instanciate 
                        -> Abstraction_figure.Get_something()
                            -> classe static Suport.Data
                    -> class Constructor
        
        */

        public static Figure Construct( Figure_creation_data _data = default ){ return new Teste_figure().Construct( _data, _main_folder: "Lily", _root_path: "Clothes", _context: Resource_context.Characters ); }


        protected override void Construct_modes(){

            modes.Add( new Teste_figure_MAD().Construct( this, new(){ visual_figure = Figure_mode.mad, images_links_length = 10, resources_length = 10 } ) );
            
        }


        public override void Update_support(){

            // ** something

        }


        protected override Figure_mode Get_default_mode(){ return Figure_mode.mad; }

        public Resource_image_find_data head_1 = new() { path_root = "Clothes/head_1" };

        public Resource_image_find_data_array exp_1_mouth = new(){ path = "exp_1", number_images = 3 };
        
    
        public Resource_image_find_data body_1 = new(){ path = "body_1" };
        public Resource_image_find_data boots_1 = new(){ path_root = ( "Clothes/boots_1" ) };
        public Resource_image_find_data top_1 = new(){ path_root = ( "Clothes/top_1" ) };
        public Resource_image_find_data arms_1 = new(){ path_root = ( "Clothes/arms_1" ) };
        public Resource_image_find_data arms_2 = new(){ path_root = ( "Clothes/arms_2" ) };

        public Resource_image_find_data arms_3 = new(){ path = "Clothes/arms_2" };

        


        
}
