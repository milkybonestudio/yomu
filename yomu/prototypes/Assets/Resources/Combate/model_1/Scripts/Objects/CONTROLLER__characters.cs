

using System;
using UnityEngine;

public class CONTROLLER__characters {

        public CONTROLLER__characters(){

            Controllers.characters = this;

            characters_bar = new Combat_characters_bar();
            support_character_bar = new Support_character_bar();

            randon = new System.Random( ( int ) ( DateTime.Now.Second * 145_099 ) );



        }

        public void Destroy(){


            characters_bar.Destroy();


        }

        public void Give_life_characters(){

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){


                if( characters_in_combat[ i ].die )
                    { continue; }

                characters_in_combat[ i ].current_life += 3;
                characters_in_combat[ i ].Update_life();

                
            }            

        }


        public void Change_character( Combat_character _character, int _slot  ){


            characters_bar.Change_character( _character, _slot );


        }

        public void Verify_still_1_alive(){

            // Debug.Log( "VEIO" );

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){
                if( !!!( characters_in_combat[ i ].die ) )
                    { return; }
            }

            Controllers.main.Finalise_lose();


        }

        public System.Random randon;


        public Combat_character Get_randon(){

            int number = randon.Next( 5 );

            for( int i = 0 ; i < 5 ; i++ ){

                number = ( number + 1 ) % 5;
                if( !!!( characters_bar.characters_in_combat[ number ].die ) )
                    { break; }


            }


            return characters_bar.characters_in_combat[ number ];

        }



        public Combat_character Get_max_health(){

            int lowest = 0;
            float health = 0f;

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){

                if( characters_in_combat[ i ].die )
                    { continue; }

                if( characters_in_combat[ i ].current_life > health )
                    { 
                        health = characters_in_combat[ i ].current_life;
                        lowest = i;
                    }
                
            }   

            Debug.Log( "Life: " + health );
            Debug.Log( "index: " + lowest );
            return characters_in_combat[ lowest ];

        }

        public Combat_character Get_lowest_health(){

            int lowest = 0;
            float health = 10_000f;

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){

                if( characters_in_combat[ i ].die )
                    { continue; }

                if( characters_in_combat[ i ].current_life < health )
                    { 
                        health = characters_in_combat[ i ].current_life;
                        lowest = i;
                    }
                
            }   

            return characters_in_combat[ lowest ];

        }

        public void Start_fase( Combat_character[] _main_charactes, Combat_character[] _bench_characters ){

            // ** _bench_characters max 6

            characters_in_combat = new Combat_character[]{
                new Combat_character( "Yuki" ),
                new Combat_character( "Alex" ),
                new Combat_character( "Eden" ),
                new Combat_character( "Dia" ),
                new Combat_character( "Jayden" )   
            };

            characters_bar.Set_characters( characters_in_combat );


        }

        private const int NUMBER_COMBAT_CHARACTERS = 5;

        public Combat_characters_bar characters_bar;
        public Support_character_bar support_character_bar;

        public Combat_character[] characters_in_combat = new Combat_character[ NUMBER_COMBAT_CHARACTERS ];


        public void Block_cast(){

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){
                characters_in_combat[ i ].Block_cast();
            }

        }

        public void Liberate_cast(){

            for( int i = 0 ; i < NUMBER_COMBAT_CHARACTERS ; i++ ){
                characters_in_combat[ i ].Liberat_cast();
            }

        }






}