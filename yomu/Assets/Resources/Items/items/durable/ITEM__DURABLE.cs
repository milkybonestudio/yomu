

public enum ITEM__DURABLE {
    

        START = ( Item_type.durable - 1 ),

            decoration,
            furniture = ITEM__DURABLE__DECORATION.END,
            information = ITEM__DURABLE__FURNITURE.END, 

        END = ITEM__DURABLE__INFORMATION.END,
        

}


