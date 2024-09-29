

public static class TOOL__get_size_slot {


        public static int Get_slot_rect_internal( Dimension_higher_to_low dimensions ){


                // 1 / 3

                if( dimensions.lower < 20 && dimensions.higher < 60 )
                    { return ( int ) Texture_sizes._20_X_60; }
                
                if( dimensions.lower < 50 && dimensions.higher < 150 )
                    { return ( int ) Texture_sizes._50_X_150; }

                if( dimensions.lower < 100 && dimensions.higher < 300 )
                    { return ( int ) Texture_sizes._100_X_300; }

                if( dimensions.lower < 150 && dimensions.higher < 450 )
                    { return ( int ) Texture_sizes._150_X_450; }

                if( dimensions.lower < 200 && dimensions.higher < 600 )
                    { return ( int ) Texture_sizes._200_X_600; }
                

                // other


                if( dimensions.lower < 300 && dimensions.higher < 700 )
                    { return ( int ) Texture_sizes._300_X_700; }

                
                if( dimensions.lower < 400 && dimensions.higher < 900 )
                    { return ( int ) Texture_sizes._400_X_900; }

            
                if( dimensions.lower < 500 && dimensions.higher < 1100 )
                    { return ( int ) Texture_sizes._500_X_1100; }

                
                if( dimensions.lower < 600 && dimensions.higher < 1500 )
                    { return ( int ) Texture_sizes._600_X_1500; }
                

                throw new System.Exception();
                

        }


        public static int Get_slot_square_internal( int higher_dimension ){


                if( higher_dimension <= ( ( int ) Texture_sizes._250_X_250 ) - 1 )
                    {
                        // --- menor
                        if( higher_dimension <= 20 )
                            { return ( int ) Texture_sizes._20_X_20; }
                        
                        if( higher_dimension <= 50 )
                            { return ( int ) Texture_sizes._50_X_150; }

                        if( higher_dimension <= 100 )
                            { return ( int ) Texture_sizes._100_X_100; }
                            
                        if( higher_dimension <= 150 )
                            { return ( int ) Texture_sizes._150_X_150; }
                        
                    }

                
                if( higher_dimension <= 250 )
                    { return ( int ) Texture_sizes._250_X_250; }
                
                if( higher_dimension <= 500 )
                    { return ( int ) Texture_sizes._500_X_500; }

                if( higher_dimension <= 750 )
                    { return ( int ) Texture_sizes._750_X_750; }
        
                if( higher_dimension <= 1000 )
                    { return ( int ) Texture_sizes._1000_X_1000; }
                
                if( higher_dimension <= 1500 )
                    { return ( int ) Texture_sizes._1500_X_1500; }

                throw new System.Exception();
                    

        }





}