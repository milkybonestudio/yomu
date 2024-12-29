

public enum ITEM__TOOL {

        START = ( Item_type.tool - 1 ),

                handcraft,
                herbology = ITEM__TOOL__HANDCRAFT.END,
                mining = ITEM__TOOL__HERBOLOGY.END,
                fishing = ITEM__TOOL__MINING.END,
                
        END = ITEM__TOOL__FISHING.END,

}

