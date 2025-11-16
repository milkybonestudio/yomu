

using System.Collections;
using TMPro;
using UnityEngine;

public class Mob_handler : MonoBehaviour {

    public Mob mob;

}

public class Mob {


    // ** ray canst 

    public int slot;
    public GameObject game_object;
    public SpriteRenderer image;
    public TextMeshPro life;
    public GameObject life_points_game_object;
    public GameObject target_game_object_left;
    public GameObject target_game_object_right;
    public float max_life;
    public Material material;

    public Mob_data data;
    public bool died;

    public bool activated;


    public static Vector3 Get_current_mouse_position(){

        Vector3 mouse_position = Input.mousePosition;

            float width = ( float ) Screen.width;
            float height = ( float ) Screen.height;

            float width_on_screen;
            float height_on_screen;

            float alp = ( width / height ); 


            if( alp > 1.7777f )
                {
                    // ** tem mais width -> usar height
                    height_on_screen =  height;
                    width_on_screen  =  height * 1.7777f;
                }
                else
                {
                    // ** tem amis height -> usar width
                    width_on_screen  =  width;
                    height_on_screen =  width / 1.777f;

                }

            float dif_height = ( height - height_on_screen ) / 2f ;
            float dif_width = ( width - width_on_screen ) / 2f ;


            // if( ( mouse_position.x > dif_width + width_on_screen ) || ( mouse_position.x < dif_width ) )
            //     { return; } // ** nao esta dentro

            // if( ( mouse_position.y > dif_height + height_on_screen ) || ( mouse_position.y < dif_height ) )
            //     { return; } // ** nao esta dentro

            // Debug.Log( "<Color=lightBlue>--------------------</Color>" );
            // Debug.Log( "width: " +  width);
            // Debug.Log( "height: " + height );
            // Debug.Log( "width_on_screen: " + width_on_screen );
            // Debug.Log( "height_on_screen: " + height_on_screen );

            // Debug.Log( "dif_width: " + dif_width );
            // Debug.Log( "dif_height: " + dif_height );

            // Debug.Log( "width calculo: " + ( ( mouse_position.x - dif_width ) * (  1920f / width_on_screen ) ) );
            // Debug.Log( "height calculo: " + ( ( mouse_position.y - dif_height ) * (  1920f / width_on_screen ) ) );

            return new Vector3(
                ( mouse_position.x - dif_width ) * (  1920f / width_on_screen ),
                ( mouse_position.y - dif_height ) * (  1920f / width_on_screen ),
                mouse_position.z
            );




    }

    public static GameObject camera_game_object = GameObject.Find( "world/Camera/Camera" );
    public static Camera camera = GameObject.Find( "world/Camera/Camera" ).GetComponent<Camera>();
    public static void Touch(){


        if( !!!( Input.GetMouseButtonDown( 0 ) ) )
            { return; }

        Vector3 local_position_scene = Controllers.combat.scene_container.transform.localPosition;
        float width = Controllers.combat.quad.transform.localScale.x;
        float height = Controllers.combat.quad.transform.localScale.y;

        Vector3 mouse_position = Get_current_mouse_position();
        // Vector3 dir = mouse_position.normalized;


        mouse_position.x -= 960f;
        mouse_position.y -= 540f;

        // Debug.Log( mouse_position );

        // poixels -> PPU
        // Debug.Log( Controllers.combat.scene_container.transform.localPosition );
        mouse_position -= Controllers.combat.scene_container.transform.localPosition;
        mouse_position *= 1/100f;
        mouse_position *= 0.2f;



        mouse_position.z = 1.5f;

        // mouse_position += camera_game_object.transform.position;

        // Vector3 worldPoint = mouse_position;
        // Debug.Log( (mouse_position - camera_game_object.transform.position).normalized );

        Vector3 dir = ( camera_game_object.transform.rotation *  ( mouse_position ).normalized );
        // Debug.Log( dir );

        Vector3 click_position = ( mouse_position - local_position_scene );


        Ray ray = new Ray( camera_game_object.transform.position, dir  );
        
        if( !!!( Physics.Raycast( ray, out RaycastHit hit ) ) )
            { return;  }

        

        if( !!!( hit.transform.gameObject.TryGetComponent<Mob_handler>( out Mob_handler mob ) ) )
            { return; }

        if( !!!( mob.mob.activated ) )
            { Debug.Log( "Mob " + mob.name + " is not active" ); return; }

        if( mob.mob.slot == Controllers.player.current_mob_target )
            {  Debug.Log( "The mob is already on target" ); return; }

        Controllers.mobs.Change_target( mob.mob.slot );

    }


    // ** visual
    public void Remove_target(){

        material.SetInt( "_is_target", 0 );
        target_game_object_left.SetActive( false );
        target_game_object_right.SetActive( false );

    }

    public void Give_target(){

        material.SetInt( "_is_target", 1 );
        target_game_object_left.SetActive( true );
        target_game_object_right.SetActive( true );

    }


    private const float scale = 6f;
    
    public Mob( string _name, int _slot ){

        slot = _slot;
        data = Mob_container.Get_mob_data( _name );
        data.name = _name;

        game_object = new GameObject( _name );
        Mob_handler handler = game_object.AddComponent<Mob_handler>();
        handler.mob = this;

        game_object.transform.localScale = new Vector3( scale,scale,scale );


        
        image = game_object.AddComponent<SpriteRenderer>();
        image.sprite = Resources.Load<Sprite>( Paths_combate_modelo_1.Get_path( $"Mobs/images/{ _name }" ) ) ;
        material = new Material( Shader.Find( "Shader Graphs/mob_material" ) );
        image.material = material;

        BoxCollider box_collider = game_object.AddComponent<BoxCollider>();
        box_collider.size = new Vector3( ( image.sprite.rect.width / 100f ), ( image.sprite.rect.height / 100f ), 0f );
        
        max_life = data.life;
        life_points_game_object = new GameObject( "life points" );
        life_points_game_object.transform.localScale = new Vector3(  (1f/scale),(1f/scale),(1f/scale) );
        life_points_game_object.transform.SetParent( game_object.transform, false );


        // life_points_game_object.transform.localPosition = new Vector3( 0f, ( image.sprite.rect.height / ( scale * 2f * 100f) + 0.7f ), 0f );
        life_points_game_object.transform.localPosition = new Vector3( 0f, -(  (  image.sprite.rect.height / ( 2f * 100f ) - 0.2f)  ), -( 0.2f + ( image.sprite.rect.height / 400f )) );
        // life_points_game_object.transform.localPosition = new Vector3( 0f, -0.5f, -0.25f );


        life = life_points_game_object.AddComponent<TextMeshPro>();
        life.text = $"{ data.life } LP/ { data.life } LP";
        life.fontSize = 7f;
        life.alignment = TextAlignmentOptions.TopGeoAligned;
        RectTransform rect = life_points_game_object.GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Vertical, 1f );
        rect.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 8f );
        life_points_game_object.SetActive( false );
        
        target_game_object_left = new GameObject( "target_left" );
        target_game_object_left.transform.SetParent( game_object.transform, false );
        target_game_object_left.transform.localPosition = new Vector3(  -( ( image.sprite.rect.width / ( scale * 2f * 100f) + 0.7f ) ), 0f , 0f );
        target_game_object_left.transform.localScale = new Vector3(  (1f/scale),(1f/scale),(1f/scale) );
        target_game_object_left.transform.localRotation = Quaternion.Euler( 0f,0f,90f );
        target_game_object_left.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>( Paths_combate_modelo_1.Get_path( "Mobs/target" ) );
        target_game_object_left.SetActive( false );



        target_game_object_right = new GameObject( "target_right" );
        target_game_object_right.transform.SetParent( game_object.transform, false );
        target_game_object_right.transform.localPosition = new Vector3( ( image.sprite.rect.width / ( scale * 2f * 100f) + 0.7f ), 0f, 0f );
        target_game_object_right.transform.localScale = new Vector3(  (1f/scale),(1f/scale),(1f/scale) );
        target_game_object_right.transform.localRotation = Quaternion.Euler( 0f,0f,-90f );
        target_game_object_right.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>( Paths_combate_modelo_1.Get_path( "Mobs/target" ) );
        target_game_object_right.SetActive( false );



        

        if( image.sprite == null )
            { throw new System.Exception( $"Did not find the image { Paths_combate_modelo_1.Get_path( $"Mobs/images/{ _name }" ) }" ); }

        game_object.transform.localPosition = new Vector3( 0f, scale * ( image.sprite.rect.height / ( 2f * 100f) ) - 1.5f, 0f );

    }

    public void Show_life(){

        activated = true;

        life_points_game_object.SetActive( true );
        life.text = $"{ data.life } LP/ { max_life } LP";

    }

    public bool Add_damage( int _damage ){

        data.life -= _damage;
        if( data.life <= 0 )
            { 
                Die(); 
                return true;
            }

        return false;

    }

    public void Die(){

            // Debug.Log( "Vaio Die" );

            // if( died )
            //     { return; }

            data.life = 0; 
            died = true;
            game_object.SetActive( false );
            GameObject.Destroy( game_object );
            Controllers.mobs.Change_array_mobs( slot );

            


                
    }

    public void Update_life(){

        life.text = $"{ data.life } LP/ { max_life } LP";

    }

    public void Destroy(){

        GameObject.Destroy( game_object );
        if( update_coroutine != null )
            { Controllers.main.Stop_coroutine( update_coroutine ); }

    }
    
    public Coroutine update_coroutine;

    public static float time = 0.5f;

    public IEnumerator Update_intern(){

        // ** make mob be in solor?

        image.color = Color.red;

        if( time > 0.2f )
            { time -= 0.02f; }

        // ** SELECT TARGET

        material.SetInt( "_is_active", 1 );

        Combat_character character = null;


        if( data.taunt == Mob_type_taunt.less_life )
            { character = Controllers.characters.Get_lowest_health(); }

        if( data.taunt == Mob_type_taunt.random )
            { character = Controllers.characters.Get_randon(); }

        if( data.taunt == Mob_type_taunt.less_life_chance )
            {
                Random.InitState( ( int )(Time.deltaTime * 154_00 ) );

                float value = Random.value;
                
                if( value > 0.5f )
                    { Debug.Log( "vai pegar um randon" ); character = Controllers.characters.Get_randon(); }
                    else
                    { Debug.Log( "vai pegar o COM A MENOR VIDA" ); character = Controllers.characters.Get_lowest_health(); }

            }

        

        

        // Combat_character character = Controllers.characters.Get_lowest_health();
        Controllers.mobs.ball_target_mob.SetActive( true );
        Controllers.mobs.Set_ball_target_damage( -1 );
        Controllers.mobs.ball_target_mob.transform.SetParent( character.structure.transform, false );

        yield return new WaitForSeconds( time );

        // ** show damage

        int damage = data.damage == 0? 1: data.damage;

        Controllers.mobs.Set_ball_target_damage( damage );

        yield return new WaitForSeconds( time );

        character.Add_damage( damage );
        character.life.color = Color.red;

        yield return new WaitForSeconds( time );

        Controllers.mobs.Set_ball_target_damage( -1 );
        character.life.color = Color.white;
        image.color = Color.white;
        end_coroutine = true;
        material.SetInt( "_is_active", 0 );
        yield break;


    }

    public bool end_coroutine;

    public bool Update(){

        if( died )
            { return true; }

        if( update_coroutine == null )
            { update_coroutine = Controllers.main.Start_coroutine( Update_intern() ); }

        if( end_coroutine )
            {
                update_coroutine = null;
                end_coroutine = false;
                return true;
            }

        return end_coroutine;


    }


}