

public class BIT_KEY__emotion {

         
                public const ulong neutral                        =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;

        // --- PRIMARIO

            // ** alegria 
                public const ulong happyness_1                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0001;
                public const ulong happyness_2                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0010; 
                public const ulong happyness_3                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0100;

            // ** afeto
                public const ulong affection_1                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_1000;
                public const ulong affection_2                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0001_0000;
                public const ulong affection_3                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0010_0000;

            // ** medo
                public const ulong fear_1                         =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0100_0000;
                public const ulong fear_2                         =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__1000_0000;
                public const ulong fear_3                         =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0001__0000_0000;

            // ** surpresa
                public const ulong surprise_1                     =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0010__0000_0000;
                public const ulong surprise_2                     =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0100__0000_0000;
                public const ulong surprise_3                     =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_1000__0000_0000;

            // ** tristeza
                public const ulong sadness_1                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0001_0000__0000_0000;
                public const ulong sadness_2                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0010_0000__0000_0000; 
                public const ulong sadness_3                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0100_0000__0000_0000;

            // ** desgosto
                public const ulong disgust_1                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__1000_0000__0000_0000;
                public const ulong disgust_2                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0001__0000_0000__0000_0000;
                public const ulong disgust_3                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0010__0000_0000__0000_0000;

            // ** coragem
                public const ulong courage_1                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0100__0000_0000__0000_0000;
                public const ulong courage_2                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_1000__0000_0000__0000_0000;
                public const ulong courage_3                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0001_0000__0000_0000__0000_0000;

            // ** previsibilidade
                public const ulong predictability_1               =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0010_0000__0000_0000__0000_0000;
                public const ulong predictability_2               =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0100_0000__0000_0000__0000_0000; 
                public const ulong predictability_3               =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__1000_0000__0000_0000__0000_0000;


        // --- SECUNDARIO

        
                public const ulong happyness_AND_affection_1      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0001__0000_0000__0000_0000__0000_0000;
                public const ulong happyness_AND_affection_2      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0010__0000_0000__0000_0000__0000_0000;

                // ** mid afeto e medo

                public const ulong affection_AND_fear_1           =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0100__0000_0000__0000_0000__0000_0000;
                public const ulong affection_AND_fear_2           =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_1000__0000_0000__0000_0000__0000_0000;

                // ** mid medo surpresa

                public const ulong fear_AND_surprise_1            =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0001_0000__0000_0000__0000_0000__0000_0000;
                public const ulong fear_AND_surprise_2            =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0010_0000__0000_0000__0000_0000__0000_0000;
                
                // ** mid surpresa e tristeza

                public const ulong surprise_AND_sadness_1         =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0100_0000__0000_0000__0000_0000__0000_0000; 
                public const ulong surprise_AND_sadness_2         =  0b_0000_0000__0000_0000__0000_0000__0000_0000__1000_0000__0000_0000__0000_0000__0000_0000;

                // ** mid tristeza e desgosto

                public const ulong sadness_AND_disgust_1          =  0b_0000_0000__0000_0000__0000_0000__0000_0001__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong sadness_AND_disgust_2          =  0b_0000_0000__0000_0000__0000_0000__0000_0010__0000_0000__0000_0000__0000_0000__0000_0000;

                // ** mid desgosto e coragem

                public const ulong disgust_AND_courage_1          =  0b_0000_0000__0000_0000__0000_0000__0000_0100__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong disgust_AND_courage_2          =  0b_0000_0000__0000_0000__0000_0000__0000_1000__0000_0000__0000_0000__0000_0000__0000_0000;

            // ** mid coragem e previsibilidade

                public const ulong courage_AND_predictability_1   =  0b_0000_0000__0000_0000__0000_0000__0001_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong courage_AND_predictability_2   =  0b_0000_0000__0000_0000__0000_0000__0010_0000__0000_0000__0000_0000__0000_0000__0000_0000;

            // ** mid previsibilidade e felicidade 
            
                public const ulong predictability_AND_happyness_1 =  0b_0000_0000__0000_0000__0000_0000__0100_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong predictability_AND_happyness_2 =  0b_0000_0000__0000_0000__0000_0000__1000_0000__0000_0000__0000_0000__0000_0000__0000_0000;


        // --- TERCIARIO

                public const ulong happyness_AND_fear             =  0b_0000_0000__0000_0000__0000_0001__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong happyness_AND_surprise         =  0b_0000_0000__0000_0000__0000_0010__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong happyness_AND_disgust          =  0b_0000_0000__0000_0000__0000_0100__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong happyness_AND_courage          =  0b_0000_0000__0000_0000__0000_1000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;

                public const ulong sadness_AND_courage            =  0b_0000_0000__0000_0000__0001_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong sadness_AND_predictability     =  0b_0000_0000__0000_0000__0010_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong sadness_AND_fear               =  0b_0000_0000__0000_0000__0100_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong sadness_AND_affection          =  0b_0000_0000__0000_0000__1000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;

                public const ulong predictability_AND_disgust     =  0b_0000_0000__0000_0001__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong predictability_AND_affection   =  0b_0000_0000__0000_0010__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong predictability_AND_fear        =  0b_0000_0000__0000_0100__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;


                public const ulong surprise_AND_affection         =  0b_0000_0000__0000_1000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong surprise_AND_disgust           =  0b_0000_0000__0001_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong surprise_AND_courage           =  0b_0000_0000__0010_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;


                public const ulong courage_AND_affection          =  0b_0000_0000__0100_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong fear_AND_disgust               =  0b_0000_0000__1000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
            

}
