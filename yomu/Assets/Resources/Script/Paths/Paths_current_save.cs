

using System.IO;

public static class Paths_current_save {


    public static void Start_save( int _save ){

        Paths_version.Guarantee_version_folder();

        if( _save > 7 )
            { CONTROLLER__errors.Throw( $"Can not handle save number <Color=lightBlue>{ _save }</Color>" ); }
        
        save_path = Paths_saves.Get_save_folder( _save );

            save_context = Get_save_context();
            save_death = Get_save_death( save_path );


            save_data = Get_save_data();
            save_image = Get_save_image();
            save_storage = Get_save_storage();

            brute_data = Get_save_brute_data();
            

            
        return;
            

    }


    public static string save_path;
    // public static string save_path_death;

    public const string save_data_name = "save_data.dat";
    public static string save_data;
    public static string Get_save_data(){ return Path.Combine( save_path, save_data_name ); }
    public static string Get_save_data( string _save_path ){ return Path.Combine( _save_path, save_data_name ); }


    
    public const string save_context_name = "save_context.dat";
    public static string save_context;
    public static string Get_save_context(){ return Path.Combine( save_path, save_context_name ); }


    //mark
    // ** acho que era o save.dat
    public const string brute_data_name = "brute_data.dat";
    public static string brute_data;
    public static string Get_save_brute_data(){ return Path.Combine( save_path, brute_data_name ); }
    public static string Get_save_brute_data( string _save_path ){ return Path.Combine( _save_path, brute_data_name ); }

    public const string storage_name = "storage.dat";
    public static string save_storage;
    public static string Get_save_storage(){ return Path.Combine( save_path, storage_name ); }
    public static string Get_save_storage( string _save_path ){ return Path.Combine( _save_path, storage_name ); }

    public const string storage_slot_prefix = "data_";
    public const string storage_slot_suffix = ".dat";
    public static string Get_save_storage_slot( int _slot ){  return Path.Combine( save_path, $"{ storage_slot_prefix }{ INT.ToString( _slot ) }{ storage_slot_suffix }");  }
    public static string Get_save_storage_slot( string _save_path, int _slot ){  return Path.Combine( _save_path, $"{ storage_slot_prefix }{ INT.ToString( _slot ) }{ storage_slot_suffix }");  }
    
    

    public const string save_image_name = "save_image";
    public static string save_image;
    public static string Get_save_image(){ return Path.Combine( save_path, save_image_name ); }
    public static string Get_save_image( string _save_path ){ return Path.Combine( _save_path, save_image_name ); }


    public const string save_death_name = "death";
    public static string save_death;
    public static string Get_save_death(){ return System.IO.Path.Combine( save_path, save_death_name ); }
    public static string Get_save_death( string _save_path ){ return System.IO.Path.Combine( _save_path, save_death_name ); }


}