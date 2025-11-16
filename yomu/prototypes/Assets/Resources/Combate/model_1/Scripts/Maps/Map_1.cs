
public interface I_map {

    public abstract Path Get_paths();   
    public abstract string Get_map_name();

}

public class MAP_1 : I_map {

    public string Get_map_name(){ return "map_1"; }
    public Path Get_paths(){

        Path A1 = new(){
            name = "A1",
            mobs = new string[][]{
                new[]{ "Javali" },
                new[]{ "Javali", "Javali" },
                new[]{ "Javali", "Javali", "Javali" },
                new[]{ "Alce" },
            }
        };

        Path A2 = new(){
            name = "A2",
            mobs = new string[][]{
                new[]{ "Javali","Javali","Javali"  },
                new[]{ "Javali","Alce","Javali"  },
                new[]{ "Javali","Javali"  },
                new[]{ "Tartaruga" },
                new[]{ "Javali", "Tartaruga", "Javali" },
            }
        };

        Path B1 = new(){
            name = "B1",
            mobs = new string[][]{
                new[]{ "Javali" },
                new[]{ "Alce" },
            }
        };
        Path B2 = new(){
            name = "B2",
            mobs = new string[][]{
                new[]{ "Javali", "Javali", "Javali", "Javali", "Javali" },
                new[]{ "Javali", "Alce", "Mico"  },
                new[]{ "Alce"  },
            }
        };

        Path C1 = new(){
            name = "C1",
            mobs = new string[][]{
                new[]{ "Javali" },
                new[]{ "Javali" },
                new[]{ "Tartaruga" },
            }
        };

        Path D1 = new(){
            name = "D1",
            mobs = new string[][]{
                new[]{ "Bear" },
                new[]{ "Javali", "Javali", "Javali" },
                new[]{ "Mico" },
                new[]{ "Javali" },
                new[]{ "Javali", "Tartaruga", "Javali" },

            }
        };

        Path D2 = new(){
            name = "D2",

            mobs = new string[][]{
                new[]{ "Javali","Javali","Alce","Javali","Javali" },
                new[]{ "Mico","Javali","Mico" },
                new[]{ "Mico","Mico","Mico", "Mico", "Mico" },
                new[]{ "Mico","Mico","Mico", "Mico", "Mico" },
                new[]{ "Alce","Alce" },
            }
        };

        Path E1 = new(){
            name = "E1",
            mobs = new string[][]{
                new[]{ "Javali" },
                new[]{ "Javali", "Javali", "Javali" },
                new[]{ "Mico","Mico","Mico", "Mico", "Mico" },
                new[]{ "Bear" },
                new[]{ "Mico","Mico","Mico", "Mico", "Mico" },
            }
        };


        Path E2 = new(){
            name = "E2",
            mobs = new string[][]{
                new[]{ "Mico","Mico","Javali", "Mico", "Mico" },
                new[]{ "Mico","Mico","Alce", "Mico", "Mico" },
                new[]{ "Alce","Alce" },
            }
        };

        Path F1 = new(){
            name = "F1",
            mobs = new string[][]{
                new[]{ "Mico","Javali", "Mico" },
                new[]{ "Javali"},
                new[]{ "Mico" },
                new[]{ "Mico" },
                new[]{ "Mico" },
                new[]{ "Javali", "Javali", "Javali" },
                new[]{ "Alce" },
            }
        };

        Path F2 = new(){
            name = "F2",
            mobs = new string[][]{
                new[]{ "Mico", "Alce", "Mico" },
                new[]{ "Bear" },
                new[]{ "Javali" },
                new[]{ "Javali", "Javali" },
            }
        };



        Path H1 = new(){
            name = "H1",
            mobs = new string[][]{
                new[]{ "Javali", "Javali", "Javali" },
                new[]{ "Mico", "Javali", "Alce", "Javali", "Mico" },
                new[]{ "Mico", "Mico", "Mico" },
                new[]{ "Alce" },
                new[]{ "Mico" },

            }
        };


        Path H2 = new(){
            name = "H2",
            mobs = new string[][]{

                new[]{ "Javali", "Javali", "Javali" },
                new[]{ "Javali", "Javali", "Javali" },
                new[]{ "Alce", "Alce", "Alce" },
                new[]{ "Mico", "Mico" },
            }
        };

        Path H3 = new(){
            name = "H3",
            mobs = new string[][]{
                new[]{ "Javali"},
                new[]{ "Mico","Mico","Javali", "Mico", "Mico" },
                new[]{ "Javali","Javali","Javali", "Javali", "Javali" },
                new[]{ "Javali","Javali","Alce", "Javali", "Javali" },
            }
        };

        Path H4 = new(){
            name = "H4",
            mobs = new string[][]{
                new[]{ "Javali","Javali" },
                new[]{ "Javali","Javali","Javali", "Javali", "Javali" },
                new[]{ "Tartaruga","Javali","Javali", "Javali", "Tartaruga" },
            }
        };


        Path H5 = new(){
            name = "H5",
            mobs = new string[][]{

                new[]{ "Javali","Bear","Javali" },
                new[]{ "Javali","Mico","Javali" },
                new[]{ "Mico", "Mico" },
                new[]{ "Javali"},
                new[]{ "Mico","Mico","Mico" },
            }
        };

        Path I1 = new(){
            name = "I1",
            mobs = new string[][]{
                new[]{ "Javali"},
                new[]{ "Javali","Javali","Javali" },
                new[]{ "Javali","Tartaruga","Javali" },
            }
        };

        Path I2 = new(){
            name = "I2",
            mobs = new string[][]{
                new[]{ "Mico", "Bear", "Javali" },
                new[]{ "Mico", "Javali", "Mico" },
                new[]{ "Javali","Javali","Javali", "Javali", "Javali" },
                new[]{ "Javali" },
                new[]{ "Mico","Mico","Mico","Mico" },
            }
        };


        Path K1 = new(){
            name = "K1",
            mobs = new string[][]{
                new[]{ "Tartaruga", "Tartaruga","Tartaruga" },
                new[]{ "Javali","Javali"  },
                new[]{ "Alce"  },
                new[]{ "Mico","Mico","Mico" },
                new[]{ "Javali","Javali","Javali"  },
                
            }
        };

        Path K2 = new(){
            name = "K2",
            mobs = new string[][]{
                new[]{ "Bear", "Bear", "Bear", "Bear", "Bear" },
            }
        };

        Path J1 = new(){
            name = "J1",
            mobs = new string[][]{
                new[]{ "Javali"},
                new[]{ "Mico", "Javali", "Mico" },
                new[]{ "Alce" },
                new[]{ "Javali","Javali","Javali" },
                new[]{ "Mico","Mico","Javali", "Mico", "Mico" },
                
                
            }
        };




        Path G1 = new(){
            name = "G1",

            character_giver = true,
            character_name = "Maki",

            mobs = new string[][]{
                new[]{ "Javali"},                
            }
        };








        A1.Set( A2 ); A2.Set( B1, C1 );
            B1.Set( B2 ); B2.Set( D1 );
            C1.Set( D1 );
    
        D1.Set( D2 );
        D2.Set( E1, F1 );

        E1.Set( E2 );
        F1.Set( F2 );
        


        E2.Set( G1 );
        G1.Set( H1, I1 );
        F2.Set( G1 );



        H1.Set( H2 );
        H2.Set( H3 );
        H3.Set( H4 );
        H4.Set( H5 );
        H5.Set( K1 );

        I1.Set( I2 );
        I2.Set( J1 );

        J1.Set( K1 );
        K1.Set( K2 );



        

        return A1;

    }

}
