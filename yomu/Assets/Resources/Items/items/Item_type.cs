


public enum Item_type {


        START,

                not_give = 0,

                named, 
            
                quest = ITEM__NAMED.END,
                
                living_being = ITEM__QUEST.END,

                consumable = ITEM__LIVING_BEING.END,

                durable = ITEM__CONSUMABLE.END,

                material = ITEM__DURABLE.END,

                tool = ITEM__MATERIAL.END,

                combat = ITEM__TOOL.END,



        END = ITEM__COMBAT.END,

}


