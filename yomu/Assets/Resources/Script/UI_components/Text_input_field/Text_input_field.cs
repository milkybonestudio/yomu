


using UnityEngine;

public class Text_input_field : UI_component {

    protected override void Update_material(){}

    public override void Force_active(){ Console.Log( "tem que fazer" ); }
    public override void Force_inactive(){ Console.Log( "tem que fazer" ); }
    public override void Force_nothing(){ Console.Log( "tem que fazer" ); }

        protected override void Update_phase( Control_flow _control_flow ){}
        protected override void Create_data_FROM_creation_data(){ throw new System.NotImplementedException(); }
        protected override void Link_to_UI_game_object_in_structure( GameObject _UI_game_object ){ throw new System.NotImplementedException(); }
    


        protected override void Destroy_abs(){

            resources_container.Delete_all_resources();
            // ** depois devolver container

        }
        


}