

public class BIT_KEY__emotion {

         
                public const ulong neutral                        =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000;

        // --- PRIMARIO

            // ** alegria 
                public const ulong happyness_1                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0001;
                public const ulong happyness_2                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0010; 
                public const ulong happyness_3                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0100;

                public const ulong happyness                      =  ( happyness_1 | happyness_2 | happyness_3 );

            // ** afeto
                public const ulong affection_1                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_1000;
                public const ulong affection_2                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0001_0000;
                public const ulong affection_3                    =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0010_0000;

                public const ulong affection                      =  ( affection_1 | affection_2 | affection_3 );

            // ** medo
                public const ulong fear_1                         =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0100_0000;
                public const ulong fear_2                         =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__1000_0000;
                public const ulong fear_3                         =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0001__0000_0000;
                public const ulong fear                           =  ( fear_1 | fear_2 | fear_3 );

            // ** surpresa
                public const ulong surprise_1                     =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0010__0000_0000;
                public const ulong surprise_2                     =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0100__0000_0000;
                public const ulong surprise_3                     =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_1000__0000_0000;
                public const ulong surprise                       =  ( surprise_1 | surprise_2 | surprise_3 );

            // ** tristeza
                public const ulong sadness_1                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0001_0000__0000_0000;
                public const ulong sadness_2                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0010_0000__0000_0000; 
                public const ulong sadness_3                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0100_0000__0000_0000;
                public const ulong sadness                        =  ( sadness_1 | sadness_2 | sadness_3 );

            // ** desgosto
                public const ulong disgust_1                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__1000_0000__0000_0000;
                public const ulong disgust_2                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0001__0000_0000__0000_0000;
                public const ulong disgust_3                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0010__0000_0000__0000_0000;
                public const ulong disgust                        =  ( disgust_1 | disgust_2 | disgust_3 );

            // ** coragem
                public const ulong courage_1                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_0100__0000_0000__0000_0000;
                public const ulong courage_2                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0000_1000__0000_0000__0000_0000;
                public const ulong courage_3                      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0001_0000__0000_0000__0000_0000;
                public const ulong courage                        =  ( courage_1 | courage_2 | courage_3 );

            // ** previsibilidade
                public const ulong predictability_1               =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0010_0000__0000_0000__0000_0000;
                public const ulong predictability_2               =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__0100_0000__0000_0000__0000_0000; 
                public const ulong predictability_3               =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0000__1000_0000__0000_0000__0000_0000;
                public const ulong predictability                 =  ( predictability_1 | predictability_2 | predictability_3 );


        // --- SECUNDARIO

        
                public const ulong happyness_AND_affection_1      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0001__0000_0000__0000_0000__0000_0000;
                public const ulong happyness_AND_affection_2      =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0010__0000_0000__0000_0000__0000_0000;
                public const ulong happyness_AND_affection                 =  ( happyness_AND_affection_1 | happyness_AND_affection_2 );

                // ** mid afeto e medo

                public const ulong affection_AND_fear_1           =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_0100__0000_0000__0000_0000__0000_0000;
                public const ulong affection_AND_fear_2           =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0000_1000__0000_0000__0000_0000__0000_0000;
                public const ulong affection_AND_fear             =  ( affection_AND_fear_1 | affection_AND_fear_2 );

                // ** mid medo surpresa

                public const ulong fear_AND_surprise_1            =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0001_0000__0000_0000__0000_0000__0000_0000;
                public const ulong fear_AND_surprise_2            =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0010_0000__0000_0000__0000_0000__0000_0000;
                public const ulong fear_AND_surprise              =  ( fear_AND_surprise_1 | fear_AND_surprise_2 );
                
                // ** mid surpresa e tristeza

                public const ulong surprise_AND_sadness_1         =  0b_0000_0000__0000_0000__0000_0000__0000_0000__0100_0000__0000_0000__0000_0000__0000_0000; 
                public const ulong surprise_AND_sadness_2         =  0b_0000_0000__0000_0000__0000_0000__0000_0000__1000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong surprise_AND_sadness           =  ( surprise_AND_sadness_1 | surprise_AND_sadness_2 );

                // ** mid tristeza e desgosto

                public const ulong sadness_AND_disgust_1          =  0b_0000_0000__0000_0000__0000_0000__0000_0001__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong sadness_AND_disgust_2          =  0b_0000_0000__0000_0000__0000_0000__0000_0010__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong sadness_AND_disgust            =  ( sadness_AND_disgust_1 | sadness_AND_disgust_2 );

                // ** mid desgosto e coragem

                public const ulong disgust_AND_courage_1          =  0b_0000_0000__0000_0000__0000_0000__0000_0100__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong disgust_AND_courage_2          =  0b_0000_0000__0000_0000__0000_0000__0000_1000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong disgust_AND_courage            =  ( disgust_AND_courage_1 | disgust_AND_courage_2 );

            // ** mid coragem e previsibilidade

                public const ulong courage_AND_predictability_1   =  0b_0000_0000__0000_0000__0000_0000__0001_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong courage_AND_predictability_2   =  0b_0000_0000__0000_0000__0000_0000__0010_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong courage_AND_predictability     =  ( courage_AND_predictability_1 | courage_AND_predictability_2 );

            // ** mid previsibilidade e felicidade 
            
                public const ulong predictability_AND_happyness_1 =  0b_0000_0000__0000_0000__0000_0000__0100_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong predictability_AND_happyness_2 =  0b_0000_0000__0000_0000__0000_0000__1000_0000__0000_0000__0000_0000__0000_0000__0000_0000;
                public const ulong predictability_AND_happyness   =  ( predictability_AND_happyness_1 | predictability_AND_happyness_2 );




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

