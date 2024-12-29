


using System;

public enum ITEM__MATERIAL {
    

        START = ( Item_type.material - 1 ),

            food, 
            herbs = ITEM__MATERIAL__FOOD.END,
            metals = ITEM__MATERIAL__HERBS.END,
            mob,
            
        END = ITEM__MATERIAL__METALS.END,

}





public enum ITEM__MATERIAL__MOB {
    

        START = ( ITEM__MATERIAL.mob - 1 ),

            food, 
            herbs = ITEM__MATERIAL__FOOD.END,
            metals = ITEM__MATERIAL__HERBS.END,
            mob,
            
        END = ITEM__MATERIAL__METALS.END,

}







