using UnityEngine;


public enum Combined_images_type_render {

    not_give, 
    all_frames, // ** never turn off
    shots,
    
    // ** depois se precisar fazer com animacao com menos fps
    // ** as animacoes vão ser no maximo 24fps ou seja a maior parte dos frames são desnecessarios
    // ** foram 13ms vs 20ms nos testes basicos


}

public enum Switch{

    OFF,
    ON,

}

public enum Resource_combined_images_content{

    not_give,

        nothing, 
        camera_space, 
        render_texture,
        finished,


}

//mark
// ** coisas para ver:
// ** -> reduzir o quanto uma camera vai renderizar parece ser complicado. As dimensoes da camera dependem principalmente da texture, mas se 1 combined_image tem mais imagens 
// **    por hora vai sempre renderizard tudo, se algo estiver dividindo espaço vai aceitar qu pode renderizar espaço vazio desnecessario por hora
// **   
//



public class RESOURCE__combined_image : RESOURCE__ref {




        public static RESOURCE__combined_image Construct( MANAGER__resources_combined_images _manager_resources, Dimensions _dimensions, int _id ){

                RESOURCE__combined_image resource = new RESOURCE__combined_image();

                    resource.manager_resources = _manager_resources;
                    resource.id = _id;
                    resource.dimensions = _dimensions;
                    resource.render_type = Combined_images_type_render.all_frames;

                return resource;


        }



        // ** DOWN
        public override void Unload(){}



        public override void Deactivate(){}
        public override void Deinstanciate(){}

        // ** UP

        public override void Load(){}
        public override void Activate(){}


        public override void Instanciate(){}
        

        // ** VERIFICATIONS
        //mark
        // ** por hora sempre vai ficar com a texture
        public override bool Got_to_minimum(){ return true; }
        public override bool Got_to_full(){return true; }

        public RESOURCE__structure_copy current_structure;

        public Combined_images_type_render render_type;


        public void Render_update(){

            switch( render_type ){
                case Combined_images_type_render.all_frames: Turn_camera( Switch.ON ); return;
                case Combined_images_type_render.shots: Turn_camera( Switch.OFF ); return;
                default: CONTROLLER__errors.Throw( $"Tried to render the combined_image <Color=lightBlue>{ name }</Color>, but the render_type was <Color=lightBlue>{ render_type }</Color>" ); break;
            }
            
        }

        public void Set_type( Combined_images_type_render _render_type ){

            if( _render_type == Combined_images_type_render.not_give )
                { CONTROLLER__errors.Throw( $"Try to set combined images render type as <Color=lightBlue>{ _render_type }</Color>" ); }

            render_type = _render_type;

        }

        public void Turn_camera( Switch _bool ){ 


            bool state = ( _bool == Switch.ON );
            if( camera_setting.current_camera_game_object_set_active == state )
                { return; }

            camera_setting.current_camera_game_object_set_active = state;
            camera_setting.camera_game_object.SetActive( state ); 
        }



        public void Set_structure( RESOURCE__structure_copy _structure, Dimensions_combined_images _dimensions ){

                current_structure?.Return_to_container();
                current_structure = _structure;

                current_structure.Set_parent( camera_setting.container_to_place );

                float off_set_x = ( _dimensions.off_set_width * PPU.value_inverse );
                float off_set_y = ( _dimensions.off_set_height * PPU.value_inverse );

                float scale_x = ( ( float ) dimensions.width ) / 100f ;
                float scale_y = ( ( float ) dimensions.height ) / 100f ;

                // ** ADJUST STRUCTURE
                current_structure.Get_game_object().transform.localPosition = new Vector3( -off_set_x, -off_set_y, 0f );

                // ** ADJUST QUAD
                camera_output.quad_render.transform.localPosition = new Vector3( off_set_x, off_set_y, 0f );
                camera_output.quad_render.transform.localScale = new Vector3( scale_x, scale_y, 1f );

                // ** ADJUST CAMERA
                //mark
                // ** a camera é grande o suficiente para pegar todos os formatos 
                // ** reajustar ela desse jeito iria funcionar para 1, mas nao para 2 
                // ** se o formato nao for identico de proporção
                // camera_setting.camera.orthographicSize = scale_y / 2;


        }

        public int id;
        public Dimensions dimensions;
        public MANAGER__resources_combined_images manager_resources;

        public Camera_space_combined_images_key key_space;
        public Camera_space_combined_images_setting camera_setting;
        public Camera_space_combined_images_output camera_output;



        // public void Stop_camera(){
        //     Turn_camera( Switch.OFF );
        // }

        public void Return_quad_container(){

            camera_output.container_quad.transform.SetParent( camera_setting.main_container.transform , false );
            camera_output.container_quad.transform.localPosition = new Vector3( 0f,0f, -7f );

        }



        public override void Delete(){ 
            
                manager_resources.Remove_reference( this );
                GameObject.Destroy( camera_output.render_texture );
                GameObject.Destroy( camera_setting.main_container );
                manager_resources.manager_spaces.Free_space( key_space );


        }


        public void Print(){

            Turn_camera( Switch.ON );
            camera_setting.camera.Render();
            Turn_camera( Switch.OFF );
                
        }


    
}