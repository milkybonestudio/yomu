

using UnityEngine;

public class CONTROLLER__world {


    public CONTROLLER__world(){
        
        Controllers.world = this;
        container_world = GameObject.Find( "world/Container_world" );
        mob_container = GameObject.Find( "world/Container_world/Mobs" );
        GameObject.Destroy( container_world.transform.GetChild( 0 ).gameObject );
        

    }

    public GameObject container_world;
    public GameObject current_world;
    public GameObject mob_container;

    private float distancia_inicial_container = 10f;

    public void Set_world( Fase _fase ){

        current_world = Resources.Load<GameObject>( Paths_combate_modelo_1.Get_path( $"World/{_fase.world_model}" ) );
        if( current_world == null )
            { throw new System.Exception(); }

        current_world = GameObject.Instantiate( current_world );
        current_world.transform.SetParent( container_world.transform, false );
        

    }

    public float current_position = 0f;
    
    public float final_position = 0f;

    public void Update(){

        // Debug.Log( "current_position: " + current_position );
        // Debug.Log( "frame_delocation: " + frame_delocation );
        // Debug.Log( "frame_delocation: " + final_position );
        // Debug.Log( "----------------------");

        if( current_position == final_position  )
            { return; }
        

        float frame_delocation = ( 15f + ( 10f* (current_position - 1) / (final_position + 1)  ))* Time.deltaTime ;
        if( ( current_position - frame_delocation ) <= final_position )
            { 
                container_world.transform.localPosition = new Vector3( 0f,0f, final_position ); 
                current_position = final_position;
            }
            else
            { 
                container_world.transform.localPosition -= new Vector3( 0f,0f, frame_delocation ); 
                current_position -= frame_delocation;
            }
        


    }

    public void Pass(){ final_position -= distance;}
    public void Return(){ final_position += distance; }


    public void destroy(){

        if( current_world != null )
            { GameObject.Destroy( current_world ); }


        if( mob_container != null )
            { GameObject.Destroy( mob_container ); }



    }


    public void Change_mobs_position( Mob[] mobs_line, float _line_position = -10_000f ){

            if( mobs_line.Length == 0 )
                { return; }

            if( _line_position == -10_000 )
                { _line_position = mobs_line[ 0 ].game_object.transform.localPosition.z; }

            float max_length = 32f;
            float espacamento = max_length / ( mobs_line.Length + 1 );
            float current_espacamento = -( max_length / 2f );

            for( int mob_index = 0 ; mob_index < mobs_line.Length ; mob_index++ ){

                Mob mob = mobs_line[ mob_index ];
                current_espacamento += espacamento;
                mob.game_object.transform.SetParent( mob_container.transform, false );
                Vector3 vec = mob.game_object.transform.localPosition;
                vec.x = current_espacamento;
                vec.z = _line_position;
                mob.game_object.transform.localPosition = vec;
                
            }



    }


    public const float distance = 20f;
    public void Set_mobs( Mob[][] _mobs ){


        current_position = 0f;
        final_position = 0f;
        container_world.transform.localPosition = new Vector3( container_world.transform.localPosition.x, container_world.transform.localPosition.y, 0f );

        GameObject.Destroy( mob_container );
        mob_container = new GameObject( "Mob_container" );
        mob_container.transform.SetParent( container_world.transform, false );

        float current_line = 0f;

        for( int line = 0 ; line < _mobs.Length ; line++ ){

            current_line += distance;
            Mob[] mobs_line =  _mobs[ line ];
            Change_mobs_position( mobs_line, current_line );

            // float max_length = 32f;
            // float espacamento = max_length / ( mobs_line.Length + 1 );
            // float current_espacamento = -( max_length / 2f );

            // for( int mob_index = 0 ; mob_index < mobs_line.Length ; mob_index++ ){

            //     Mob mob = mobs_line[ mob_index ];
            //     current_espacamento += espacamento;
            //     mob.game_object.transform.SetParent( mob_container.transform, false );
            //     mob.game_object.transform.localPosition += new Vector3( current_espacamento, 0f, current_line );
                
            // }

        }


    }



}
