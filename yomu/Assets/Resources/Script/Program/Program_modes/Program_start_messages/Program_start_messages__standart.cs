using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


unsafe public class Program_start_messages : PROGRAM_MODE {

    
    public Program_start_messages(){ type = Program_mode.program_start_messages; }

    private PROGRAM_START_MESSAGES_DATA__global* global;
    
    public override void Construct(){

        PROGRAM_DATA__program_start_messages* data = default;
        
            global = &( data->global );
            
        // ** udar data

    }


    public override void Clean_resources(){}
    public override void Destroy(){}




    public override Transition_program Construct_transition( Transition_program_data _data ){

            Transition_program transition = new Transition_program(); // default constructor?
            
            return transition;

    }


    public override void Update(){}



}
