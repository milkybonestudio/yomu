


using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CONTROLLER__mobs {



        public CONTROLLER__mobs(){ 

            Controllers.mobs = this; 
            ball_target_mob = new GameObject( "mob_target_ball" );
            ball_target_mob_DAMAGE = new GameObject( "damage_target_ball" );
            ball_target_mob_DAMAGE.transform.SetParent( ball_target_mob.transform, false );
            ball_target_mob_DAMAGE.transform.localPosition += new Vector3( 0f, 110f, 0f );

            ball_target_damage_text = ball_target_mob_DAMAGE.AddComponent<TextMeshProUGUI>();
            ball_target_damage_text.alignment = TextAlignmentOptions.TopGeoAligned;
            ball_target_damage_text.color = Color.red;
            ball_target_damage_text.text = "";
            ball_target_damage_text.fontSize = 45f;
            

            ball_target_mob.AddComponent<Image>().sprite = Resources.Load<Sprite>( Paths_combate_modelo_1.Get_path( "target" ) );
            ball_target_mob.SetActive( false );


        }

        public int current_line;


        public Mob[][] mobs_in_path;

        public int current_mob_update;
        public Mob[] current_mobs;


        public GameObject ball_target_mob;
        public GameObject ball_target_mob_DAMAGE;
        public TextMeshProUGUI ball_target_damage_text;

        public void Stop_damages(){



        }

        public void Change_array_mobs( int _slot ){


            // Debug.Log( "Vai trocar mobs" );
            // Debug.Log( "Current target: " + Controllers.player.current_mob_target );
            // Debug.Log( "slot mob morto: " + _slot );


            // ** Mobs destruiu o gameObject


            if( Controllers.player.current_mob_target == _slot )
                {
                    // Debug.Log( "need t change target " + _slot );
                    // Debug.Log( "Current mobs length: " + current_mobs.Length );
                    for( int i = 2, sign = 1 ; i < ( 5 * 2 ) ; i++, sign *= -1 ){
                    
                        // ** positivo 
                        int current_analysed = ( ( _slot + ( ( i / 2 ) * sign ) ) );

                        if( current_analysed < 0 ||  current_analysed >= current_mobs.Length )
                            { continue; } // ** nao conta quando passa em nenhum sentido

                        if( !!!( current_mobs[ current_analysed ].died ) )
                            { 
                                if( sign > 0 )
                                    { current_analysed -= 1; }
                                Change_target( current_analysed ); 
                                break; 
                            } 

                     }


                    //  Controllers.player.current_mob_target = 0;

                    // ** se nao pegar nenhum -> todos mortos -> nao importa

                }



            int number_alive = 0;
            int index = 0;

            for( index = 0 ; index < current_mobs.Length ; index++ ){

                if( current_mobs[ index ].died )
                    { continue; }
                number_alive++;

            }

            // if( number_alive == 0 )
            //     { return; }

            Mob[] new_array = new Mob[ number_alive ];

            int acumulator = 0;
            for( index = 0 ; index < current_mobs.Length ; index++ ){

                if( current_mobs[ index ].died )
                    { continue; }

                new_array[ acumulator ] = current_mobs[ index ];
                new_array[ acumulator ].slot = acumulator;
                acumulator++;

            }  

            mobs_in_path[ current_line ] = new_array;
            current_mobs = new_array;
            Controllers.world.Change_mobs_position( new_array );

            if( Controllers.player.current_mob_target >= current_mobs.Length )
                { Controllers.player.current_mob_target = current_mobs.Length - 1; }

            




        }

        

        public void Set_ball_target_damage( int _damage ){

            if( _damage == -1  )
                {
                    ball_target_damage_text.text = "";
                    return;
                }

            ball_target_damage_text.text = _damage.ToString();

        }

        public void Destroy(){

            current_mob_update = 0;

            ball_target_mob.transform.SetParent( GameObject.Find( "Canvas" ).transform, false );
            ball_target_mob.SetActive( false );

            for( int line = 0 ; line < mobs_in_path.Length ; line++ ){
                Mob[] mobs_names =  mobs_in_path[ line ];
                for( int mob_index = 0 ; mob_index < mobs_names.Length ; mob_index++ ){
                    mobs_names[ mob_index ]?.Destroy();
                }
            }

        }


        public void Update_lifes(){

            foreach( Mob mob in current_mobs ){

                if( mob.died )
                    { continue; }

                mob.Update_life();

            }

        }


        public void End(){
            
        }

        public void Add_damage( int _damage, int _slot, Skill_targt_type _type  ){


            // Debug.Log( "vai add damage type " + _type );
            // Debug.Log( "vai add damage no slot " + _slot );


            // if( current_mobs.Length == 0 )
            //     { return; }


            if( _slot >= current_mobs.Length )
                {
                    _slot = Controllers.player.current_mob_target;
                }

            if( _slot < 0 || _slot > 4 )
                { 
                    // Debug.LogError( "veio slot: " + _slot ); 
                    return;
                }




            if( _type ==  Skill_targt_type.single )
                { current_mobs[ _slot ].Add_damage( _damage ); }

            if( _type ==  Skill_targt_type.close )
                {

                    if( ( _slot + 1 ) < Controllers.mobs.current_mobs.Length )
                        { 
                            current_mobs[ _slot + 1 ].Add_damage(  _damage  ); 
                        }

                    bool middle_die = current_mobs[ _slot ].Add_damage( _damage );

                    if( ( _slot - 1 ) >= 0 )
                        { 
                            current_mobs[ _slot - 1 ].Add_damage( _damage ); 
                        }

                }


            if( _type ==  Skill_targt_type.area )
                {
                    for( int i = 0 ; i < Controllers.mobs.current_mobs.Length ; i++ ){  

                        int start_length = Controllers.mobs.current_mobs.Length;
                        bool die = Controllers.mobs.current_mobs[ i ].Add_damage(  _damage );
                        if( die )
                            { 
                                i--; 
                                if( start_length - Controllers.mobs.current_mobs.Length != 1  )
                                    { 
                                        Debug.Log( "Starrt: " + start_length );
                                        Debug.Log( "Final: " + Controllers.mobs.current_mobs.Length );
                                        throw new System.Exception(); 
                                    }
                            }
                        

                    }

                }



            Update_lifes();
            Verify_end_line();
            Verify_target();
            

        }

        private void Verify_target(){}

        public void Change_target( int _new_target ){

            // Debug.Log( $"VAI MUDAR TARGET para <Color=lightBlue>{ _new_target }</Color>" );

            if( _new_target < 0 || _new_target > ( current_mobs.Length - 1 ) )
                { throw new System.Exception( $"tried to add the target in the index{ _new_target } but there are only current_mobs.Length" ); }

            current_mobs[ Controllers.player.current_mob_target ].Remove_target();
            current_mobs[ _new_target ].Give_target();

            Controllers.player.current_mob_target = _new_target;
            // Debug.Log( "Novo target: " + Controllers.player.current_mob_target );
    

        }

        public void Verify_end_line(){

            foreach( Mob mob in current_mobs ){

                if( !!!( mob.died ) )
                    { return; }

            }

            // ** acabou todos
            End_line();
            
            
        }


        // 
        public void Update(){

            if( current_mobs[ current_mob_update ].Update() )
                {
                    while( current_mob_update < current_mobs.Length ){

                        current_mob_update++;
                        if( current_mob_update >=  current_mobs.Length )
                            {
                                current_mob_update = 0;
                                ball_target_mob.SetActive( false );
                                Controllers.combat.Start_player_turn();
                                break;
                            }

                        if( !!!( current_mobs[ current_mob_update ].died ) )
                            { break; }
                        

                    }
                }


        }

        
        public void Start_turn(){

            try{

                current_mobs[ Controllers.player.current_mob_target ].Remove_target();

            } catch ( Exception e ){

                Debug.Log( "the current target is : " + Controllers.player.current_mob_target );
                Debug.Log( "The current length is : " + current_mobs.Length );
                throw new Exception();

            }


        }
        public void End_turn(){

            current_mobs[ Controllers.player.current_mob_target ].Give_target();

        }


        public void End_line(){

            current_line++;

            // ** REMOVER DEPOIS
            if( current_line > mobs_in_path.Length  )
                { return; } 

            if( current_line == mobs_in_path.Length  )
                {
                    // ** finalizou
                    // Debug.Log( "Finalizou" );
                    Controllers.combat.End_path(); 
                    return;
                }
            
            Controllers.world.Pass();
            current_mobs = mobs_in_path[ current_line ];

            foreach( Mob mob in current_mobs ){
                mob.Show_life();
            }

            Controllers.player.current_mob_target = ( current_mobs.Length / 2 );
            current_mobs[ Controllers.player.current_mob_target ].Give_target();

        }


        public void Start_fase(){

            Start_path( Controllers.path.current_path.mobs );
            

        }


        // ** inicia multiplas lines
        public void Start_path( string[][] _mobs ){

            mobs_in_path = new Mob[ _mobs.Length ][];

            for( int line = 0 ; line < _mobs.Length ; line++ ){

                string[] mobs_names =  _mobs[ line ];
                mobs_in_path[ line ] = new Mob[ mobs_names.Length ];

                for( int mob_index = 0 ; mob_index < mobs_names.Length ; mob_index++ ){

                    string mob_name = mobs_names[ mob_index ];
                    // Debug.Log( $"Vai criar mob <Color=lightBlue>{ mob_name }</Color>" );
                    mobs_in_path[ line ][ mob_index ] = new Mob( mob_name, mob_index );
                
                }

            }

            Controllers.world.Set_mobs( mobs_in_path );

            current_line = -1;
            Controllers.world.Return();
            End_line();

        }



}