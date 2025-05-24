using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class MANAGER__resources_combined_images : MANAGER__RESOURCES {

        public MANAGER__resources_combined_images(){

            
            manager_spaces = MANAGER__resources_combined_images_spaces.Construct();
            manager_render_rextures = MANAGER__resources_combined_images_render_textures.Construct();
            combined_images_dic = new();

        }


        public MANAGER__resources_combined_images_spaces manager_spaces;
        public MANAGER__resources_combined_images_render_textures manager_render_rextures;



        // --- UPDATE

        private const int weight_to_stop = 5;
        private int context_frame;
        public override void Update(){}


        public Dictionary<int,RESOURCE__combined_image> combined_images_dic;

        private int current_count;

        public RESOURCE__combined_image Get_combined_image( Material _material, Dimensions _dimensions ){


                //mark
                // ** por hora sempre vai instanciar com texture

                // ** assume que as imagens já foram carregadas
                RESOURCE__combined_image image = RESOURCE__combined_image.Construct( this, _dimensions, current_count++ );

                    combined_images_dic.Add( image.id, image );

                    // ** content 1 
                    image.key_space = manager_spaces.Get_space_key();
                    image.camera_setting = manager_spaces.Get_camera_setting( image.key_space, _dimensions );

                    // ** content 2
                    RenderTexture render_texture = manager_render_rextures.Get_render_texture( _dimensions );
                    image.camera_output = manager_spaces.Get_output( _material, render_texture, image.camera_setting );


                return image;

        }


        public void Remove_reference( RESOURCE__combined_image _image ){

            combined_images_dic.Remove( _image.id );

        }


        




        // --- EXTRA

        public override int Get_bytes_allocated(){

                 return manager_render_rextures.current_ram_usage;
            
        }

}
