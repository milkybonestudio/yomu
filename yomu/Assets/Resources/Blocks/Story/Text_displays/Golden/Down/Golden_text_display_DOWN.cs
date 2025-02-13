



public class Golden_text_display_DOWN : Story_text_display {



        public Golden_text_display_DOWN(){


                name = "Golden_text_display_DOWN";
                root = "Text_displays/Golden/Down";
                structure = CONTROLLER__resources.Get_instance().resources_structures.Get_structure_copy( Resource_context.Blocks, "Story", root + "/Text_display_golden", Resource_structure_content.game_object );



                MANAGER__resources_images images = CONTROLLER__resources.Get_instance().resources_images;

                back = images.Get_image_reference( Resource_context.Blocks, "Story", ( root + "/back" ), Resource_image_content.sprite );
                sword_left = images.Get_image_reference( Resource_context.Blocks, "Story", ( root + "/sword_left" ), Resource_image_content.sprite );
                sword_right = images.Get_image_reference( Resource_context.Blocks, "Story", ( root + "/sword_right" ), Resource_image_content.sprite );

                name_support = images.Get_image_reference( Resource_context.Blocks, "Story", ( root + "/name_support" ), Resource_image_content.sprite );
                inferior_support = images.Get_image_reference( Resource_context.Blocks, "Story", ( root + "/inferior_support" ), Resource_image_content.sprite );

        }


        public RESOURCE__image_ref back;
        public RESOURCE__image_ref sword_left;
        public RESOURCE__image_ref sword_right;

        public RESOURCE__image_ref name_support;
        public RESOURCE__image_ref inferior_support;
        





        public override void Update( Control_flow _control_flow ){

            base.Update( _control_flow );
        }


        public override void Put_effect(){

            throw new System.NotImplementedException();
        }

        public override void Hide(){

            throw new System.NotImplementedException();
        }

        public override void Show(){

            throw new System.NotImplementedException();
        }

        public override void Put_text(){
            
            throw new System.NotImplementedException();
        }


}