

public enum ITEM__LIVING_BEING {
    

        START = ( Item_type.living_being - 1 ),

            mob, 
            people = ITEM__LIVING_BEING__MOB.END, 
            inteligent = ITEM__LIVING_BEING__PEOPLE.END, 
            animal = ITEM__LIVING_BEING__INTELIGENT.END, 

        END = ITEM__LIVING_BEING__ANIMAL.END,

}


