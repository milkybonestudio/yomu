


unsafe public struct Data_file_link {

    public enum Situation {
        
        clean, // ** not in sistem
        used,
        bin,
    }

    public Heap_key heap_key;
    public int size;

    // ** 0 is never used by a real file, 0 -> test
    public int id; // ** always go up
    public Situation situation;

    public void* Get_pointer(){

        return heap_key.Get_pointer();
        
    }

    public int Get_length(){

        return heap_key.Get_length();

    }


}
