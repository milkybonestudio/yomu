using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public static class SPRITE {

    public static Sprite Get_sprite( string _path ){

        Sprite sprite = Resources.Load<Sprite>( _path );

        if( sprite == null )
            { throw new System.Exception( $"Dont find image in path <Color=lightBlue>{ _path }</Color>" ); }

        return sprite;

    }

}



public static class Combat_character_container {

    public static Dictionary<string, Character_data> characters_data = new Dictionary<string, Character_data>();

    static Combat_character_container(){


        // ** DIA

        characters_data.Add( "Dia", new(){

                life = 15,
                skill_left = new(){

                    name = "punch",
                    image_name = "slash",
                    description = "Dia gives a punch",
                    number_casts = 1_000,
                    calculator = new(){
                        fix_damage = 2, 
                        max_slot_damage = 3,
                    }
                    
                },


                skill_up = new(){

                    name = "Fire ball",
                    image_name = "slash",
                    description = "a ball made of fire",
                    target_type = Skill_targt_type.close,
                    number_casts = 12,
                    calculator = new(){
                        fix_damage = 25,
                        max_slot_damage = 20,
                    },
                    
                },


                skill_right = new(){

                    name = "Eletric rain",
                    image_name = "slash",
                    description = "a ball made of fire",
                    target_type = Skill_targt_type.area,
                    number_casts = 5,
                    calculator = new(){
                        fix_damage = 35,
                        max_slot_damage = 20,
                    },
                    
                },


        });


        // ** ALEX

        characters_data.Add( "Alex", new(){
            life = 40,

            skill_left = new(){

                name = "slash",
                image_name = "slash",
                description = "",
                number_casts = 1_000,
                calculator = new(){
                    fix_damage = 5, 
                    max_slot_damage = 5,
                }
                
            },



            skill_up = new(){

                name = "a",
                image_name = "slash",
                description = "",
                number_casts = 20,
                target_type = Skill_targt_type.close,
                calculator = new(){
                    fix_damage = 15,
                    max_slot_damage = 5,
                }
                
            },


            skill_right = new(){

                name = "a",
                image_name = "slash",
                description = "",
                number_casts = 3,
                target_type = Skill_targt_type.close,
                calculator = new(){
                    fix_damage = 35,
                    max_slot_damage = 40,
                }
                
            },



        });


        // ** EDEN


        characters_data.Add( "Eden", new(){

            life = 55,

            skill_left = new(){

                name = "slash",
                image_name = "slash",
                description = "",
                number_casts = 1_000,
                calculator = new(){
                    fix_damage = 5, 
                    max_slot_damage = 10,
                }
                
            },


            skill_up = new(){

                name = "Super slash",
                image_name = "slash",
                description = "",
                number_casts = 30,
                calculator = new(){
                    fix_damage = 20, 
                    max_slot_damage = 10,
                }
                
            },

            skill_right = new(){

                name = "Final judgment",
                image_name = "slash",
                description = "",
                visual_attack_name = "jud",
                number_casts = 5,
                calculator = new(){
                    fix_damage = 75, 
                    max_slot_damage = 300,
                }
                
            },



        });


        // ** YUKI

        characters_data.Add( "Yuki", new(){
            life = 20,

            skill_left = new(){

                name = "slash",
                image_name = "slash",
                description = "",
                number_casts = 1_000,
                target_type = Skill_targt_type.close,
                calculator = new(){
                    fix_damage = 2, 
                    max_slot_damage = 7,
                }
                
            },


            skill_up = new(){

                name = "invisible daggers",
                image_name = "slash",
                description = "",
                number_casts = 10,
                target_type = Skill_targt_type.area,
                calculator = new(){
                    fix_damage = 10, 
                    max_slot_damage = 25,
                }
                
            },


            skill_right = new(){

                name = "backstab",
                image_name = "slash",
                description = "",
                number_casts = 1,
                target_type = Skill_targt_type.single,
                calculator = new(){
                    fix_damage = 1, 
                    max_slot_damage = 1000,
                }
                
            }


        });


    // *** JAYDEN


        characters_data.Add( "Jayden", new(){
                life = 25,

                skill_left = new(){

                    name = "arrow stab",
                    image_name = "slash",
                    description = "",
                    number_casts = 1_000,
                    calculator = new(){
                        fix_damage = 1, 
                        max_slot_damage = 15,
                    }
                    
                },
                


                skill_up = new(){

                    name = "shot",
                    image_name = "slash",
                    description = "",
                    number_casts = 15,
                    target_type = Skill_targt_type.close,
                    calculator = new(){
                        fix_damage = 1, 
                        max_slot_damage = 35,
                    }
                    
                },

                skill_right = new(){

                    name = "arrows rain",
                    image_name = "slash",
                    description = "",
                    number_casts = 3,
                    target_type = Skill_targt_type.area,
                    calculator = new(){
                        fix_damage = 1, 
                        max_slot_damage = 50,
                    }
                    
                },


        });


    // ** Extra

            characters_data.Add( "Maki", new(){
            life = 50,

            skill_left = new(){


                name = "Slash",
                image_name = "slash",
                description = "",
                number_casts = 1_000,
                calculator = new(){
                    fix_damage = 10, 
                    max_slot_damage = 20,
                }
                
            },

            skill_up = new(){


                name = "Fire torment",
                image_name = "slash",
                description = "",
                number_casts = 20,
                target_type = Skill_targt_type.close,
                calculator = new(){
                    fix_damage = 25, 
                    max_slot_damage = 25,
                }
                
            },


            skill_right = new(){


                name = "Star revolution",
                image_name = "slash",
                description = "",
                visual_attack_name = "jud",
                number_casts = 4,
                calculator = new(){
                    fix_damage = 35,
                    max_slot_damage = 500,
                }
                
            },


        });





    }

}