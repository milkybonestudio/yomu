


public unsafe abstract class ENTITIES__manager_save_data {

        
        public abstract int Retake( Game_current_state* _game_current_state );
        public abstract void Force_save();

}



public abstract class ENTITIES__loader {

        public abstract void Load( int[] _entities );
        public abstract void Unload( int[] _entities );

}

public abstract class ENTITIES__run_time_saver {


        // ** save run time 
        public abstract void Save();

}


public abstract class ENTITIES__manager_fized_size_heap {

        // **  para os dados fixos, sempre na memoria

}


public abstract class ENTITIES__manager_heap {


        public abstract void Get_heap_space();


}

