



unsafe public struct City {

    
        public int city_id;

        public City_fundamental_data* fundamental_data;
        public City_universal_data* universal_data;
        public City_system_data* system_data;
        public City_specific_data* specific_data;

        public void* heap_pointer;


    
}

public struct City_fundamental_data {

    public int specific_data_length;
    
}

public struct City_universal_data {
    
}


public struct City_system_data {
    
}


public struct City_specific_data {
    
}