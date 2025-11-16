
using System.IO;


// **save_1
//     ** save_morte
//         ...
//     ** data_heap
//         heap_data.dat
//         data_1.dat
//         data_2.dat
//         .
//         .
//         .
//     ** brute_data.dat
//         {
//             blocks_data.dat
//             characters.dat
//             places.dat
//             plot.dat
//             .
//             .
//             .
//         }
//     ** save_image.png

public struct Save_paths{

    // ** para duplicar o normal e o de morte

    public string save_data;
    public string save_image;
    public string save_heap_data;
    
}

public static class Paths_save {

    public static void Start_save( int _save ){

        Paths_version.Guarantee_version_folder();

        if( _save > 7 )
            { CONTROLLER__errors.Throw( $"Can not handle save number <Color=lightBlue>{ _save }</Color>" ); }
        
        save_path = Paths_version.Get_save_folder( _save );

            normal.save_data = Get_save_data();
            normal.save_image = Get_save_image();
            normal.save_heap_data = Get_save_heap_data(); 

        save_path = Get_save_death( save_path );

            death.save_data = Get_save_data();
            death.save_image = Get_save_image();
            death.save_heap_data = Get_save_heap_data(); 
            

        save_path = Paths_version.Get_save_folder( _save );
        return;
            

    }

    public static Save_paths normal;
    public static Save_paths death;

    public static string save_path;
    public static string save_path_death;

    public const string save_data_name = "save_data.dat";
    public static string save_data;
    public static string Get_save_data(){ return Path.Combine( save_path, save_data_name ); }
    public static string Get_save_data( string _save_path ){ return Path.Combine( _save_path, save_data_name ); }


    //mark
    // ** acho que era o save.dat
    public const string brute_data_name = "brute_data.dat";
    public static string brute_data;
    public static string Get_save_brute_data(){ return Path.Combine( save_path, brute_data_name ); }
    public static string Get_save_brute_data( string _save_path ){ return Path.Combine( _save_path, brute_data_name ); }

    public const string heap_data_name = "heap_data.dat";
    public static string heap_data;
    public static string Get_save_heap_data(){ return Path.Combine( save_path, heap_data_name ); }
    public static string Get_save_heap_data( string _save_path ){ return Path.Combine( _save_path, heap_data_name ); }

    public const string heap_data_slot_prefix = "data_";
    public const string heap_data_slot_suffix = ".dat";
    public static string Get_save_heap_data_slot( int _slot ){  return Path.Combine( save_path, $"{ heap_data_slot_prefix }{ INT.ToString( _slot ) }{ heap_data_slot_suffix }");  }
    public static string Get_save_heap_data_slot( string _save_path, int _slot ){  return Path.Combine( _save_path, $"{ heap_data_slot_prefix }{ INT.ToString( _slot ) }{ heap_data_slot_suffix }");  }
    
    


    public const string save_image_name = "save_image";
    public static string save_image;
    public static string Get_save_image(){ return Path.Combine( save_path, save_image_name ); }
    public static string Get_save_image( string _save_path ){ return Path.Combine( _save_path, save_image_name ); }


    public const string save_death_name = "death";
    public static string save_death;
    public static string Get_save_death(){ return System.IO.Path.Combine( save_path, save_death_name ); }
    public static string Get_save_death( string _save_path ){ return System.IO.Path.Combine( _save_path, save_death_name ); }




}

