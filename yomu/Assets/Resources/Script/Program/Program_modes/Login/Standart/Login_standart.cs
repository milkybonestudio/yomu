// using System.Collections;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using System.Collections.Generic;


// unsafe public class Login_standart : PROGRAM_MODE__INTERFACE {

        
//         private LOGIN_DATA__global* global;
//         private LOGIN_DATA__standart* standart;

//         public override void Construct(){

//             PROGRAM_DATA__login* data = Controllers_program.data.modes.Get_data__LOGIN();
            
//                 global = &( data->global );
//                 standart = &( data->standart );
            
//             // ** udar data

//             necessary_resouces.Add( image_login = Controllers.resources.images.Get_image_reference( Resource_context.login, "generic", "image_1", Resource_image_content.sprite ) );
//             necessary_resouces.Add( login_structure = Controllers.resources.structures.Get_structure_copy( Resource_context.login, "generic", "structure", Resource_structure_content.game_object ) );

//         }

//         public RESOURCE__image_ref image_login;
//         public RESOURCE__structure_copy login_structure;

//         public MANAGER__resources necessary_resouces = new MANAGER__resources();


//         public override Transition_program Construct_transition( Transition_program_data _data ){

//                 Transition_program transition = new Transition_program(); // default constructor?
                
//                 // --- RESOURCES
//                 transition.Add_resources_to_wait_finished( necessary_resouces );


//                 // --- TRANSITION

//                 transition.sections_actions.preparation = ()=>  {
                                                                    
//                                                                     transition.space_switcher.canvas_space_new.screen_view.material.SetFloat( "_opacity", 0f );
//                                                                     return true;
//                                                                 };


                


//                 transition.sections_actions.mode_set = () =>    {
                                                                    
//                                                                     transition.space_switcher.canvas_space_new.screen_view.material.SetFloat( "_opacity", 1f );
//                                                                     var v_1 = Controllers_program.canvas_spaces;
//                                                                     var v_2 = v_1.canvas_space_new;
//                                                                     var v_3 = v_2.content;
//                                                                     login_structure.Instanciate();
//                                                                     v_3.world.Add( login_structure );
//                                                                     login_structure.Get_component_sprite_render( "image" ).sprite = image_login.Get_sprite(); 

                                                                    
//                                                                     return true;
//                                                                 };



//                 transition.sections_actions.mode_start = () =>  {
                                                                    
//                                                                     transition.space_switcher.canvas_space_new.screen_view.material.SetFloat( "_opacity", 1f );
                                                                    
//                                                                     return true;
//                                                                 };

//                 return transition;

//         }


//         public override void Update( Control_flow _control_flow ){}



        

//         public override void Clean_resources(){}
//         public override void Destroy(){}



// }

