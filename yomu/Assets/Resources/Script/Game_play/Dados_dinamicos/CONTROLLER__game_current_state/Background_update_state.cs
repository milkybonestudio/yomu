

unsafe public struct Background_update_state {

        public int current_kingdom;
        public int current_state;
        public int current_city;

        // 0 => bloco inativo 
        // 1 => bloco esperando udpate
        // 2 => bloco com update finalizado
        
        public fixed byte cities_update_grid[ DIC__background_update_state.max_city_per_state_number ];// max 100 


}


public class DIC__background_update_state {

    public const int max_city_per_state_number = 100;

}