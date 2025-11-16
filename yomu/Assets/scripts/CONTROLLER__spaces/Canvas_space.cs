using UnityEngine;


public class Canvas_space {

    public static Canvas_space Construct( string _path ){


            Canvas_space space = new Canvas_space();

                space.UI = Canvas_region.Construct( ( _path + "/UI" ) );
                space.content = Canvas_region.Construct( ( _path + "/Content" ) );

                space.container_canvas_space = GameObject.Find( _path );
                space.state = Canvas_space_state.rendering;

                space.name_space = _path;
                // space.container_canvas_space.SetActive( false );

            return space;

    }

    public string name;
    private string name_space;

    public Canvas_space_state state;

    public void Free(){

        content.Free();
        UI.Free();

    }


    public void Update(){

        if( screen_view == null )
            {
                content.camera.Stop_render(); 
                state = Canvas_space_state.not_rendering;
                return;
            }

        if( content.world.Have_things() || UI.world.Have_things() )
            { 
                content.camera.Start_render(); 
                state = Canvas_space_state.rendering;
                screen_view.Show();
            }
            else
            { 
                content.camera.Stop_render(); 
                state = Canvas_space_state.not_rendering;
                screen_view.Hide();
            }

    }

    public GameObject container_canvas_space;

    public Screen_view screen_view;
    public void Change_screen_view( Screen_view _screen ){

        screen_view = _screen;
        content.camera.Change_target( _screen );
        
    }

    public Canvas_region UI;
    public Canvas_region content;


}
