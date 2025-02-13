

public class CONTROLLER__switcher_program_modes {


        public static CONTROLLER__switcher_program_modes instance;
        public static CONTROLLER__switcher_program_modes Get_instance(){ return instance; }


        public void Change_mode( Program_mode _new_mode, Switch_program_mode _switch ){}
        


}

public enum Switch_program_mode_type {

        // ** somente quando pode garantir que vai ser rapido/ nao importa
        instant,

        // ** pode travar se não tiver os dados
        fade,

        // ** tem os estagios para carregar
        black_to_normal,

        drapery,


}



public struct Switch_program_mode {

        //mark
        // ** somente program_modes

        // ** o fluxo continua sendo up -> prepare -> down
        // ** isso pode ser por conta da UI estar trocando ou por estar pegando os dados 

        public Switch_program_mode_type type;

        public float time_ms;
        public float time_up_ms;
        public float time_down_ms;

        public Resources_container container;

        public RESOURCE__image_ref[] images_dreapery;

}

