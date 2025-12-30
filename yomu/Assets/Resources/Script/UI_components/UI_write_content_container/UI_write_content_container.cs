


// ** text_container_buffado

using UnityEngine;

public class UI_write_content_container : UI_component {



    public override void Force_active(){ Console.Log( "tem que fazer" ); }
    public override void Force_inactive(){ Console.Log( "tem que fazer" ); }
    public override void Force_nothing(){ Console.Log( "tem que fazer" ); }
    
        protected override void Create_data_FROM_creation_data(){}
        protected override void Link_to_UI_game_object_in_structure( GameObject _UI_game_object ){}
        protected override void Destroy_abs(){

            resources_container.Delete_all_resources();
            // ** depois devolver container

        }

    protected override void Update_material(){}

    protected override void Update_phase(){

        throw new System.NotImplementedException();
    }


}