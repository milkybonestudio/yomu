using System;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;

unsafe public static class TEST__stack {

    /*

        --> crash tests:
            --> understand the state that stoped and switches to the right handler ( OK )
            --> find edge cases where the files where already all saved ( OK )
            --> find edge cases where the files got corrupted
                    --> temp file duplicated ( OK )
                    --> old file deleted befor correct move ( OK )
            --> handlers: 
                --> data was already saved ( OK )
                --> will reconstruct from the stack (  )
                --> all data in saving_files/already moved ( OK )
            --> expected:
                1_save_stack ( OK )
                2_save_new_slot_file_link ( OK )
                3_create_saving_files_folders ( OK )
                4_add_slots_files_half ( OK )
                5_add_slots_files_full ( OK )
                6_create_saving_files_security_file ( OK )
                7_move_files_half ( OK )
                71_move_files_full ( OK )
                72_switch_files_half ( OK )
                73_switch_files_full ( OK )
                8_reset_stack ( OK )
                9_delete_saving_files_security_file ( OK )
                91_delete_saving_files_folder ( OK )
        finish,

            
            

        --> update funciona 1 vez (OK)
        --> add data generic (OK)
        --> ciclo do update renova 
        --> save data in disk

        --> saver:
            --> normal
                --> save in file ( OK )
            

        --> buffer: 
            --> normal
                -> add data single (OK)
                -> add data multiples (OK)
                -> block negative length (OK)
                -> call loop from update when it can (OK)
                -> weight makes sense (OK)
                -> can call expand from update ()

            --> expansion:
                -> works (OK)
                    * expand -> save data -> disk == save in disk
                    * save data -> expand -> disk == save in disk
                -> checks if makes sense to expand (OK)
                -> prevent add too little or too much (OK)
                -> stop if buffer pass the limit (OK)
                -> checks if can really expand (OK)


            --> working with NO SPACE
                -> Start works (OK)
                -> add data (OK)
                -> handle weird sizes (OK)

                -> End works
                    --> pass NO SPACE to buffer ( most common )( OK )
                    --> pass buffer to no space and switches (OK)
                    --> create a new space (OK)

                -> clean all data when finish ( OK )
                -> auto reajust size ( OK )




            --> buffer loop:
                --> loop:
                    --> loop works
                    --> don't loop when is in 0 (OK)
                    --> protect when can't loop (OK)

                --> when things go right:
                    --> buffer add data ( OK )
                    --> see if the system needs to expand
                    --> when there is no space more try to handle
                    
                --> when things go wrong:
                    --> block invalid lengths (negative or too big )
                    --> check if is_passing_data makes sense
                    --> expands the buffer when there is no space
                    --> create small expansion when dont have space and is saving
                    --> switchs from methods dependind if is saving or not

    
    */


    static string test = 
        // "normal";
        "crash";

    public static void Set(){

        switch( test ) {

            case "crash": Test_stack_crash.Set(); break;
            case "normal": Test_stack__normal_behaviour.Set(); break;

        }
        
    }

    public static void Update(){

        switch( test ) {

            case "crash": Test_stack_crash.Update(); break;
            case "normal": Test_stack__normal_behaviour.Update(); break;

        }
        
    }







    public static void Testing_crash_handler_update(){




    }









}