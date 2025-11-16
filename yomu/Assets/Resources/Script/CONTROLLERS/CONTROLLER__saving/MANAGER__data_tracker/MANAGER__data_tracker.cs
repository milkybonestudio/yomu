using System.Collections.Generic;

unsafe public struct Data_tracker_file {

    public string path;
    public void* pointer;
    public int size;
    public int slot;

}



unsafe public class MANAGER__data_tracker {

    public MANAGER__data_tracker(){

        dic = new Dictionary<int, Data_tracker_file>( 100 );
        currrent_slot = -1;

    }

    public Dictionary<int, Data_tracker_file> dic = new Dictionary<int, Data_tracker_file>( 100 );

    public int currrent_slot = -1;
    public int Add( string _path, void* _pointer, int _size ){

        currrent_slot++;

        dic[ currrent_slot ] = new(){
            path = _path,
            pointer = _pointer,
            size = _size,
            slot = currrent_slot
        };

        // ** SALVAR_STACK_NEW_SLOT

        return currrent_slot;

    }

    
    public void Save_files(){

        foreach( Data_tracker_file data_tracker in  dic.Values ){            

        }


    }

}