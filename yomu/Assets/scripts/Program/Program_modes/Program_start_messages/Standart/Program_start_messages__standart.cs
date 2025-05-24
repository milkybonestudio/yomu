using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


unsafe public class Program_start_messages__standart : PROGRAM_MODE__INTERFACE {



        // public static Login instancia;
        // public static Login Pegar_instancia(){ return instancia; }


        private PROGRAM_START_MESSAGES_DATA__global* global;
        private PROGRAM_START_MESSAGES_DATA__standart* standart;

        public override void Construct(){

            PROGRAM_DATA__program_start_messages* data = Controllers_program.data.modes.Get_data__PROGRAM_START_MESSAGES();
            
                global = &( data->global );
                standart = &( data->standart );
            
            // ** udar data

        }


        public override void Clean_resources(){}
        public override void Destroy(){}




        public override Transition_program Construct_transition( Transition_program_data _data ){

                Transition_program transition = new Transition_program(); // default constructor?
                
                return transition;

        }


        public override void Update( Control_flow _control_flow ){}



}
