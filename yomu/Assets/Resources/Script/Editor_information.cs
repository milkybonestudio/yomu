

public static class Editor_information{

    public static int play_count;

    public static void Pass_editor_run_count(){ play_count++; }

    public static bool Check_if_is_first_run(){ return ( play_count == 0 ); }

}