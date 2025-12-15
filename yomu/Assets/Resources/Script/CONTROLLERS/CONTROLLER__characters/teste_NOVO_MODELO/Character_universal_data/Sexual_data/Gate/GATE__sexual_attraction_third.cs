using System.Runtime.InteropServices;

unsafe public struct GATE__sexual_attraction_third {


            // ** o secundario pode ser facilmente testado pois é possivel verificar igualdades de multiplas flags 


            // ** fisico
            public byte have_character_physical_trait_to_block_flags; // ** verificar vai ser complicado e geralmente ninguem vai ter 
            public fixed short character_physical_traits_to_block_flags[ 5 ]; // ** isso vai ser coisas como : se o personagem tiver cabelo curto bloqueia, se o personagem nao tiver algum membro bloqueia e etc 

            // ** psicologico
            public byte have_character_psychological_trait_to_block_flags;
            public fixed byte character_psychological_trait_to_block_flags[ 5 ];


            // ** social 
            public byte have_no_friends;
            public byte are_part_of_harem;
            public byte have_a_harem;
            public byte have_someone_that_like;

            // ** romantic
            public byte have_partner;
            public byte dont_have_partner;

            public int character_knowlodge_about_other_character_sexual_data_flags;


}


unsafe public class A {



        //mark
        //** provavelmente vaivaler mais a pena entrgar todo o personagem
        // public bool Check( GATE__sexual_attraction_second* _character_data_pointer, GATE__sexual_attraction_second* _data_to_block_pointer ){

        //     if ( ( (*_character_data_pointer).character_knowlodge_about_other_character_sexual_data_flags & ( *_data_to_block_pointer ).value) > 0   )
        //         { return false; }

        // }



        // public bool Check( Character_knowlodge_about_other_character_sexual_data_flags* _character_data_pointer, Character_knowlodge_about_other_character_sexual_data_flags* _data_to_block_pointer ){

        //     if ( ( (*_character_data_pointer).value & ( *_data_to_block_pointer ).value) > 0   )
        //         { return false; }

        // }

}



// [ StructLayout( LayoutKind.Explicit,  Size = 4 )]
// unsafe public struct Character_knowlodge_about_other_character_sexual_data_flags {


//             [ FieldOffset( 0 ) ]
//             public int value;
//             //mark 
//             //** tem que colocar depois

//             // ** normal 
            
//             [ FieldOffset( 0 ) ] public byte virgem;
//             [ FieldOffset( 0 ) ] public byte not_virgem;
//             [ FieldOffset( 0 ) ] public byte not_sexual_expecienced;
//             [ FieldOffset( 0 ) ] public byte sexual_expecienced;

//             [ FieldOffset( 0 ) ] public byte have_done_multiple_people_same_time;
//             [ FieldOffset( 0 ) ] public byte dont_have_done_multiple_people_same_time;

//             [ FieldOffset( 0 ) ] public byte have_done_multiples_genders;
//             [ FieldOffset( 0 ) ] public byte dont_have_done_multiples_genders;



//             [ FieldOffset( 0 ) ] public byte sadistic;
//             [ FieldOffset( 0 ) ] public byte submisive;

//             // ** not normal

//             [ FieldOffset( 0 ) ] public byte have_depravities_fetishes;
//             [ FieldOffset( 0 ) ] public byte dont_have_depravities_fetishes;

//             [ FieldOffset( 0 ) ] public byte have_raped_someone;
//             [ FieldOffset( 0 ) ] public byte dont_have_raped_someone;

//             [ FieldOffset( 0 ) ] public byte have_sex_with_someone_you_like;
//             [ FieldOffset( 0 ) ] public byte have_sex_with_someone_you_hate;

//             [ FieldOffset( 0 ) ] public byte have_sex_with_your_current_partner;
//             [ FieldOffset( 0 ) ] public byte have_sex_with_your_ex_partner;



// }




unsafe public class Character_knowlodge_about_other_character_sexual_data_flags {

            // ** sobre vida sexual em si, kinks vao ficar em outra parte


            // ** normal 
            
            public const int virgem                                    = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int not_sexual_expecienced                    = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int had_done_multiple_people_same_time        = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int had_done_multiples_genders                = 0b_0000_0000__0000_0000__0000_0000__0000_0000;

            

            // ** not normal
            public const int had_raped_someone_you_like                = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int had_raped_someone_you_dont_care           = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int had_raped_someone_you_hate                = 0b_0000_0000__0000_0000__0000_0000__0000_0000;

            public const int had_raped_a_young_boy                     = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int had_raped_a_young_girl                    = 0b_0000_0000__0000_0000__0000_0000__0000_0000;

            public const int had_sex_with_someone_you_like             = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int had_sex_with_someone_you_hate             = 0b_0000_0000__0000_0000__0000_0000__0000_0000;

            public const int had_sex_with_your_current_partner         = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int had_sex_with_your_ex_partner              = 0b_0000_0000__0000_0000__0000_0000__0000_0000;

            public const int had_sex_with_an_animal                    = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int had_sex_with_other_races                  = 0b_0000_0000__0000_0000__0000_0000__0000_0000;





            public const int have_depravities_fetishes                 = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int sadistic                                  = 0b_0000_0000__0000_0000__0000_0000__0000_0000;
            public const int submisive                                 = 0b_0000_0000__0000_0000__0000_0000__0000_0000;

}