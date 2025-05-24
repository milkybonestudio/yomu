


public abstract class RESOURCE__ref {

        public string name;
    

        // ** DOWN
        public abstract void Unload();



        public abstract void Deactivate();
        public abstract void Deinstanciate();

        // ** UP

        public abstract void Load();
        public abstract void Activate();



        public abstract void Instanciate();
        public abstract void Delete();


        // ** VERIFICATIONS
        public abstract bool Got_to_minimum();
        public abstract bool Got_to_full();


        //mark
        // ** tem que tirar o instanciate como valor mas isso vai quebrar mais coisas 
        // ** Primeiro todos os lugares que usem state.instanciate vão quebrar e certas logicas para garantir content não vão ficar funcionais 
        // ** segundo se pensar em estados s1, s2, s3, s4 e s5
        // ** se o minimo for s3 e estiver em s4 vai continuar como minimo

        public Resource_state state;



        //mark
        // ** Got_content_level deveria voltar true se esta no nivel ou maior, tem que virar abstract e implementar em todos
        // ** esse não tem sentido nenhum
        public bool Got_content_level( Content_level _level ){

            // ** nao vai precisar depois quando Resource_state passar para Content_level

            Resource_state new_state = Resource_state.nothing;

            switch( _level ){

                case Content_level.full: new_state = Resource_state.active; break;
                case Content_level.minimum: new_state = Resource_state.minimum; break;
                case Content_level.nothing: new_state = Resource_state.nothing; break;

            }

            return ( new_state == state );

        }


        public void Go_to_content_level( Content_level _content_level ){

            // ** nao vai precisar depois quando Resource_state passar para Content_level

            Resource_state new_state = Resource_state.nothing;

            switch( _content_level ){

                case Content_level.full: new_state = Resource_state.active; break;
                case Content_level.minimum: new_state = Resource_state.minimum; break;
                case Content_level.nothing: new_state = Resource_state.nothing; break;

            }


            // --- LOGICA NORMAL

            if( new_state >= state )
                {
                    switch( new_state ){

                        case Resource_state.minimum: Load(); break;
                        case Resource_state.active: Activate(); break;
                        case Resource_state.instanciated: Instanciate(); break;
                        default: CONTROLLER__errors.Throw( $"Tryied to use Go_to_content_level in the resource { name }, but the new state is <Color=lightBlue>{ new_state }</Color> and the current state is <Color=lightBlue>{ state }</Color>" ) ;break;

                    }
                }
                else
                {
                    switch( new_state ){

                        case Resource_state.nothing: Unload(); break;
                        case Resource_state.minimum: Deactivate(); break;
                        case Resource_state.active:  break; // instanciate -> nao precisa de nada
                        default: CONTROLLER__errors.Throw( $"Tryied to use Go_to_content_level in the resource { name }, but the new state is <Color=lightBlue>{ new_state }</Color> and the current state is <Color=lightBlue>{ state }</Color>" ) ;break;

                    }
                }

            

        }
}
