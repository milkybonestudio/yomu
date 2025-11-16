

using UnityEngine;
using UnityEngine.UI;

public class Path {

    // ** cada path tem em torno de 10 rodadas de inimigos

    public string name;
    public Path pre;
    public Path[] pos;

    public int index;
    public LineRenderer[] lines = new LineRenderer[ 3 ];

    public Button button;

    public bool character_giver;
    public string character_name;

    public void Lock(){

        if( button == null )
            { throw new System.Exception( $"path { name } does not have a button" ); }

        button.interactable = false;

    }

    
    public void Liberate(){

        if( button == null )
            { throw new System.Exception( $"path { name } does not have a button" ); }

        button.interactable = true;

    }

    

    // ** info 

    public string[][] mobs;

    private bool set;
    private void Verify_set(){
        Mob_container.Verify_mobs( mobs );

        if( set )
            { throw new System.Exception( "already set POS PATHS in the path " + name ); }

        set = true;

    }

    public void Set( Path _path_1 ){ 


        Verify_set();
        pos = new Path[]{ _path_1 }; 
        _path_1.pre = this;
    } 
    public void Set( Path _path_1, Path _path_2  ){ 
        Verify_set();
        pos = new Path[]{ _path_1, _path_2 }; 
        _path_1.pre = this;
        _path_2.pre = this;
    } 
    public void Set( Path _path_1, Path _path_2, Path _path_3  ){ 
        Verify_set();
        pos = new Path[]{ _path_1, _path_2, _path_3 }; 
        _path_1.pre = this;
        _path_2.pre = this;
        _path_3.pre = this;
    } 

}

