

public class MANAGER__devices {


    //** POR HORA DEVICES SEMPRE VAO PARA O MAXIMO DE RECURSOS
        // ** depois pensar em um jeito que não precise sempre ir para o final
        // ** a coisa mais pesada são os recursos
        // ** talvez fazer uma copia de todos os recursos e manter eles como minimo
        // ** mesmo se a structure for destruida a maior parte ainda vai ficar na ram


    private Device[] devices = new Device[ 25 ];
    private int slot_free;

    private bool deleted;


    public void Add( Device _device ){

        devices[ slot_free++ ] = _device;

        if( slot_free == devices.Length )
            { System.Array.Resize( ref devices, ( slot_free + 20 ) ); }

    }

    

    public virtual void Update_all_devices(){

        // if( deleted )
        //     { CONTROLLER__errors.Throw( "Tried to use the a manager devices that was deleted" ); }


        // for( int device_index = 0 ; device_index < slot_free ; device_index++ )
        //     { devices[ device_index ].Update_device( _flow ); }

    }


    // --- UP

    public void Load_all_devices(){

        // for( int device_index = 0 ; device_index < slot_free ; device_index++ )
        //     { devices[ device_index ].UIs_manager.Load_all_UIs_resources(); }

    }

    public void Activate_all_devices(){

        // for( int device_index = 0 ; device_index < slot_free ; device_index++ )
        //     { devices[ device_index ].UIs_manager.Activate_all_UIs_resources(); }

    }


    public void Instanciate_all_devices(){

        // for( int device_index = 0 ; device_index < slot_free ; device_index++ )
        //     { devices[ device_index ].UIs_manager.Load_all_UIs_resources(); }

    }




    // --- DOWN 


    public void Unload_all_devices(){

        // for( int device_index = 0 ; device_index < slot_free ; device_index++ )
        //     { devices[ device_index ].UIs_manager.Unload_all_UIs_resources(); }

    }

    public void Deactivate_all_devices(){

        // for( int device_index = 0 ; device_index < slot_free ; device_index++ )
        //     { devices[ device_index ].UIs_manager.Deactivate_all_UIs_resources(); }

    }


    public void Delete_all_devices(){

        // for( int device_index = 0 ; device_index < slot_free ; device_index++ )
        //     { devices[ device_index ].UIs_manager.Deactivate_all_UIs_resources(); }

    }






}
