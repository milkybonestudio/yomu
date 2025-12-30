using System;
using System.Runtime.InteropServices;

unsafe public class Game : PROGRAM_MODE{


    public Game(){  type = Program_mode.game; }


    public override void Destroy(){ Finalizador_UI.Finalizar(); }
    public override void Clean_resources(){}


    public BLOCK[] interfaces_blocos;

    // --- CONTROLADORES
    public CONTROLLER__system controlador_sistema;
    

    public override void Construct(){

        PROGRAM_DATA__game* data = &( Program_data.root->program_modes.game );

            controlador_sistema = CONSTRUCTOR__controller_system.Construct__STANDART();
        
    }


    public override Transition_program Construct_transition( Transition_program_data _data ){ return new Transition_program(); }

    
    
    // ** isso ficaria em controlador_sistema_estado_atual
    public Block_type bloco_atual = Block_type.nada;
    public Game_update_mode game_update_mode;


    public override void Update(){

        switch( game_update_mode ){

            case Game_update_mode.blocks: interfaces_blocos[ ( int ) bloco_atual ].Update(); break;
            case Game_update_mode.transition: break;

        }

        Verity_transition();

    }

    private void Verity_transition(){

        if( CONTROLLER__game_transition.instancia.transition_request_visual == null )
            { return; }

        // --- INCIA TRANSICAO
        game_update_mode = Game_update_mode.transition; 
        CONTROLLER__game_transition.instancia.Start_transition_BLOCK();

        return;

    }


}