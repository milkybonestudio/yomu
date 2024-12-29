

// ** 1 -> pegar o id
// ** 2 -> acrescentar referencia



// ** create all items 
// ** loop all and get names 
// ** create txt with the names


public class Hokushi : Item {


        public Hokushi(){


                id = ( int ) ITEM__NAMED__POSSESSED__PRIMORDIAL_WEAPONS.Hokushi;
                name = "Hokushi";
                path_data = "/Named/Possessed/Primordial_weapons/Hokushi"; 
                
                #if UNITY_EDITOR
                    DEVELOPMENT( "ITEM__NAMED__POSSESSED__PRIMORDIAL_WEAPONS" );
                #endif

        }

        


}
