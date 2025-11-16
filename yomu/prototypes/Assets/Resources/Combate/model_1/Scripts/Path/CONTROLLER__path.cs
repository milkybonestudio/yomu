

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CONTROLLER__path {

    private Material material;

    public CONTROLLER__path(){

        Controllers.path = this;
        paths_in_prefab = new Dictionary<string, GameObject>();
        container = GameObject.Find( "Canvas/Map" );
        material = new Material( Shader.Find( "Shader Graphs/Default_shader" ) );

    }

    public I_map current_map;
    public Path current_path;
    public GameObject container;
    public GameObject map;
    public Dictionary<string, GameObject> paths_in_prefab;
    private List<Path> list_to_render_lines = new List<Path>();

    public void Destroy(){

        GameObject.Destroy( map );
        paths_in_prefab.Clear();
        list_to_render_lines.Clear();

    }



    private void Start_path( Path _path ){

        // Debug.Log( "Veio Start_path " + _path.name );
        current_path = _path;        

        foreach( Path path_all in _path?.pre.pos ){
            // Debug.Log( "Vai dar lock no path " + path_all.name );
            path_all.Lock();
        }


        bool is_final = ( _path.pos == null );
        CONTROLLER__combat.instance.Start_path( _path.mobs, is_final );

        if( !!!( is_final ) )
            { Create_lines( _path ); }
        
        if( _path.character_giver )
            {
                Character_giver.Start( new Combat_character( _path.character_name )  );
            }
        
        

    }



    public void Update(){

        if( current_path.pos == null )
            // { throw new System.Exception( "tried to update the path controller but the current path is the last one. there is nothing to choose" ); }
            { Controllers.main.Finalise(); return; } // ** Vai cancelar no combat 


        float current_screen_rate = ( ( float ) Screen.width / 1920f );
        list_to_render_lines.ForEach(( Path p ) => { Render_lines( p, current_screen_rate ); });
        
    }

    public void Start_fase( Fase _fase ){

        current_path = _fase.map.Get_paths();
        string map_name = "Maps/" + _fase.map.Get_map_name();
        GameObject game_object = Resources.Load<GameObject>( Paths_combate_modelo_1.Get_path( map_name ) );

        if( game_object == null )
            { throw new System.Exception( $"Did not find the map in the path <Color=lightBlue>{ map_name }</Color>" ); }

        map = GameObject.Instantiate( game_object );

        map.transform.SetParent( container.transform, false );


        Transform map_transform = map.transform;
        int length = map_transform.childCount;
        for( int i = 0 ; i < length ; i++ ){

            GameObject game = map_transform.GetChild( i ).gameObject;
            game.transform.localPosition += new Vector3( 0f, 0f, -100f );
            paths_in_prefab.Add( game.name, game );
            game.SetActive( false );

        }

        GameObject current_game_object = paths_in_prefab[ current_path.name ];
        current_path.button = current_game_object.AddComponent<Button>();
        current_path.button.interactable = false;

        ColorBlock new_colors = current_path.button.colors;
            new_colors.pressedColor = new Color( 0.8f,0.8f,0.8f,1f );
            new_colors.normalColor = new Color( 0.5f,0.5f,0.5f,1f );
            new_colors.highlightedColor = new Color( 1f,1f,1f,1f );
            new_colors.selectedColor = new Color( 0.5f,0.5f,0.5f,1f );
            new_colors.disabledColor = new Color( 0.5f,0.5f,0.5f,1f );
        current_path.button.colors = new_colors;
        current_path.button.targetGraphic = current_game_object.GetComponent<Image>();


        current_game_object.SetActive( true );

        Create_lines( current_path );




    }

    public void Create_lines( Path _current_path ){

        list_to_render_lines.Add( _current_path );

        if( _current_path.pos == null )
            { throw new System.Exception( "tried to create more lines but the array was null" ); }

        GameObject current_game_object  = paths_in_prefab[ _current_path.name ];
        _current_path.button.interactable = false;


        foreach( Path path in _current_path.pos ){

            GameObject path_game_object = null;

            if( !!!( paths_in_prefab.TryGetValue( path.name, out path_game_object ) ) )
                { throw new System.Exception( $"The game object for the path name <Color=lightBlue>{ path.name }</Color> does not exist" ); }

            // ** create button 


            path.button = path_game_object.AddComponent<Button>();
        
            path.button.onClick.AddListener( ()=>{ Start_path( path ); } );

                path.button.targetGraphic = path_game_object.GetComponent<Image>();
                ColorBlock new_colors = path.button.colors;
                    new_colors.pressedColor = new Color( 0.8f,0.8f,0.8f,1f );
                    new_colors.normalColor = new Color( 0.5f,0.5f,0.5f,1f );
                    new_colors.selectedColor = new Color( 0.5f,0.5f,0.5f,1f );
                    new_colors.highlightedColor = new Color( 1f,1f,1f,1f );
                    new_colors.disabledColor = new Color( 0.5f,0.5f,0.5f,1f );
                path.button.colors = new_colors;
            
            path_game_object.SetActive( true );

            GameObject line_game_object = new GameObject( "line" );
            LineRenderer line_render = line_game_object.AddComponent<LineRenderer>();
            line_render.material = material;
            // Debug.Log( _current_path.index );
            _current_path.lines[ _current_path.index++ ] = line_render;
            line_render.widthMultiplier = 0.1f;
            line_game_object.transform.SetParent( current_game_object.transform, false );

            line_render.SetPositions(new[]{
                ( current_game_object.transform.position ) + new Vector3( 0f, 0f, 0.05f),
                path_game_object.transform.position + new Vector3( 0f, 0f, 0.05f) ,

            });
            path.Liberate();


        }

    }

    public void Render_lines( Path _current_path, float _current_screen_rate ){

        if( _current_path.pos == null )
            { throw new System.Exception( "tried to create more lines but the array was null" ); }

        GameObject current_game_object  = paths_in_prefab[ _current_path.name ];

        // Debug.Log( "vai criar lines no path "  + _current_path.name );
        
        for( int index_line = 0 ; index_line < _current_path.index; index_line++){

            // Debug.Log( "vai dar render no index " + index_line );
            GameObject path_game_object = null;
            if( !!!( paths_in_prefab.TryGetValue( _current_path.pos[ index_line ].name, out path_game_object ) ) )
                { throw new System.Exception( $"The game object for the path name <Color=lightBlue>{ _current_path.pos[ index_line ].name }</Color> does not exist" ); }
            
            path_game_object.SetActive( true );

            LineRenderer line_render = _current_path.lines[ index_line ];
            line_render.widthMultiplier = 0.80f * _current_screen_rate;
            line_render.SetPositions( new[]{
                ( current_game_object.transform.position ) + new Vector3( 0f, 0f, 0.05f),
                path_game_object.transform.position + new Vector3( 0f, 0f, 0.05f) ,

            });
        

        }


    }


    


}
