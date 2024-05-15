


public class Bloqueador {

    public bool true_block = false;

    public int numero_frames_para_esperar = 0; // time
    public int clicks_em_espera = 0; // click

    public bool tem_click = false;



    public bool Esta_bloqueado(){


        if(  true_block ){

            if(     ( numero_frames_para_esperar == 0 ) &&  ( clicks_em_espera == 0 )  ) {  true_block = false; return false; }
            return true;

        } else {

            if(     ( numero_frames_para_esperar == 0 ) ||  ( clicks_em_espera == 0 )  ) {   return false; }
            return true;

        }

    }

    public void Update(){


            if( this.clicks_em_espera > 0 ) { if( Controlador_input.Get_down( Key_code.space ) ||  Controlador_input.Get_down( Key_code.mouse_left ) ) { this.clicks_em_espera--; } }
            if( this.numero_frames_para_esperar > 0 ) { this.numero_frames_para_esperar--; }
            
            return;
            
    }



}

