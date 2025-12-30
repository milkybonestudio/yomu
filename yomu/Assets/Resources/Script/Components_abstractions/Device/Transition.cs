

public struct Transition {

    public static Transition Construct(){

        Transition transition = default;

            transition.Finish = ()=>{};
            transition.Prepare = ()=>{};
            transition.Update = ()=>{ return true; };

        return transition;

    }

    // ** generico, pode tanto visual como logica

    public System.Action Prepare;
    public Update_del Update;
    public System.Action Finish;
    

}
