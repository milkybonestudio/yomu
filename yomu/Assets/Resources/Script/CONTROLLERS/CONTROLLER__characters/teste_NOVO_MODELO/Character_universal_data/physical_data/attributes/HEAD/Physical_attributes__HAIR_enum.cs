



// ** assumindo que coisas tenham ids quando for modificar alguma coisa iria precisar verificar se existe outra coisa com o mesmo sentido:
        // ** => mudar de cachos para solto teria que deletar cachos

public enum Physical_attributes__HAIR {

        //type_value = Physical_traits_type.small_traits,   // ??
        start_point = ( ( Physical_attributes_type.hair << 8 ) - 1 ) , // (( Physical_traits_type.small_traits << 8 ) | 0b_0000_0000__1111_1111 ),

        // --- STYLE
        START_HAIR_STYLE,

                bangs_hair, 
                bun_hair, 
                braid_hair, 
                loose_hair,
                ponytail_hair,
                bob_cut_hair,
                wavy_hair,
                straight_hair,
                mohawk_hair,
                dreadlocks_hair, 
                afro_hair,
                curly_hair, 
                twisted_hair,
                shag_hair,

        END_HAIR_STYLE,

        // --- LENGTH

        START_HAIR_LENGTH,

                bald, //rip
                short_hair, 
                medium_hair, 
                long_hair,
                super_long_hair,

        END_HAIR_LENGTH,

        // --- QUALITIES

        START_HAIR_QUALITIES,

                // ** positivo
                soft_hair,
                silky_hair,
                healthy_hair,
                moisturized_hair,
                strong_hair, 
                voluminous_hair,
                fragrant_hair,

                // ** negativo
                dry_hair, 
                brittle_hair,
                lifeless_hair,
                frizz_hair,
                oily_hair, 
                damaged_hair,
                tangled_hair,
                thin_hair, 
                dull_hair,
                smelly_hair,

        END_HAIR_QUALITIES,

}




