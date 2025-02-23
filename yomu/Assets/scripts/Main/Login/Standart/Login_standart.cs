using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


unsafe public class Login_standart : PROGRAM_MODE {



        public static Login instancia;
        public static Login Pegar_instancia(){ return instancia; }

        public override void Construct(){

            PROGRAM_DATA__login* data = Program_data.Get_data__LOGIN();
            
                LOGIN_DATA__global* global = &(data->global);

                LOGIN_DATA_STANDART__persistent* standart = &(data->persistent.standart);
                LOGIN_DATA_STANDART__temporary* temporary = &(data->temporary.standart);
                LOGIN_DATA_STANDART__creation* creation = &(data->creation.standart);

            
            // ** udar data

            necessary_resouces.Add( image_login = Controllers.resources.resources_images.Get_image_reference( Resource_context.login, "generic", "image_1", Resource_image_content.sprite ) );

        }


        public override void Clean_resources(){}
        public override void Destroy(){}




        public RESOURCE__image_ref image_login;

        public Resource_container_checker necessary_resouces = new Resource_container_checker();

        public override Transition_program Construct_transition( Transition_program_data _data ){

                Transition_program transition = Transition_program.Get(); // default constructor?
                
                // --- RESOURCES
                transition.resource_container_checker = necessary_resouces;


                // --- TRANSITION

                transition.sections_actions.preparation = ()=>  {
                                                                    transition.cameras_data.material_mode_transition.SetFloat( "_opacity", 0f );
                                                                    transition.cameras_data.material_mode_main.SetFloat( "_opacity", 0f );
                                                                    return true;
                                                                };



                transition.sections_actions.mode_start = () =>  {
                                                                    transition.cameras_data.material_mode_transition.SetFloat( "_opacity", 1f );
                                                                    transition.cameras_data.material_mode_main.SetFloat( "_opacity", 1f );
                                                                    GameObject.Find( "Container_teste/teste_sprite" ).GetComponent<SpriteRenderer>().sprite = image_login.Get_sprite();
                                                                    return true;
                                                                };

                return transition;

        }


        public override void Update( Control_flow _control_flow ){}



}
