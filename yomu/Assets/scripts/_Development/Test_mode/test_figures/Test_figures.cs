


using UnityEngine;

unsafe public partial class Test {


    public TEST__figures test_figures = new TEST__figures();
    public class TEST__figures {

        public Figure figure;

        
        public void Set(){

                figure = Teste_figure.Construct(new(){
                    body_data_creation = new(){
                        need_anchour = true,
                        anchour_position = new Vector3( 100f, 0f, 0f ),
                        
                        transform_in_parent = new(){
                            position = new( 1000f, 0f, 0f ),
                        }
                    }
                });
            
        }

        public void Update(){


                figure?.Update();

                // ** CONTENT

                    // ** figure 
                        if( Input.GetKeyDown( KeyCode.A ) )
                            { figure.Change_content_level( Content_level.nothing ); }

                        if( Input.GetKeyDown( KeyCode.S ) )
                            { figure.Change_content_level( Content_level.minimum ); }

                        if( Input.GetKeyDown( KeyCode.D ) )
                            { figure.Change_content_level( Content_level.full ); }

                    // ** modes

                        if( Input.GetKeyDown( KeyCode.Q ) )
                                { figure.Change_content_level_MODE( Figure_mode.mad, Content_level.minimum ); }

                        if( Input.GetKeyDown( KeyCode.W ) )
                                { figure.Change_content_level_MODE( Figure_mode.sad, Content_level.minimum ); }



                        if( Input.GetKeyDown( KeyCode.E ) )
                                { figure.Change_content_level_MODE( Figure_mode.mad, Content_level.full ); }

                        if( Input.GetKeyDown( KeyCode.R ) )
                                { figure.Change_content_level_MODE( Figure_mode.sad, Content_level.full ); }


                        if( Input.GetKeyDown( KeyCode.Delete ) )
                                { 
                                    figure.Delete(); 
                                    figure = null;
                                }



                        if( Input.GetKeyDown( KeyCode.H ) )
                                { Console.Log( Controllers.resources.images.Get_number_images() ); }





                // ** actions


                    if( Input.GetKeyDown( KeyCode.B ) )
                            { figure.Speak( new(){ loops = 2 } ); }

                    if( Input.GetKeyDown( KeyCode.V ) )
                            { figure.Blick( new(){ loops = 2 } ); }



                    if( Input.GetKeyDown( KeyCode.Alpha1 ) )
                        { figure.Change_direction( Figure_mode_direction.right ); }

                        
                    if( Input.GetKeyDown( KeyCode.Alpha2 ) )
                        { figure.Change_direction( Figure_mode_direction.left ); }



                        




                // body

                if( Input.GetKeyDown( KeyCode.R ) )
                    { figure.body.rotation.Add( 0f, 90f, 0f ); }

                if( Input.GetKeyDown( KeyCode.T ) )
                    { figure.body.anchour_rotation.Add( 0f, 90f, 0f ); }


                if( Input.GetKeyDown( KeyCode.Y ) )
                    { figure.body.anchour_position.Add( 20f, 0f, 0f ); }


                if( Input.GetKeyDown( KeyCode.Alpha9 ) )
                    { 
                        figure.body.Set_transform(new(){

                            position = new( -1000f,-1000f, -1000f ),

                        });
                    }

                if( Input.GetKeyDown( KeyCode.Alpha8 ) )
                    { 
                        figure.body.Set_transform(new(){
                            position = new( -700f,-700f, -700f ),
                        });
                    }





                // ** position 
                if( Input.GetKeyDown( KeyCode.LeftArrow ) )
                    { figure.body.position.Add( -10000f, 0f, 0f ); }

                if( Input.GetKeyDown( KeyCode.RightArrow ) )
                    { figure.body.position.Add( 10000f, 0f, 0f ); }

                if( Input.GetKeyDown( KeyCode.UpArrow ) )
                    { figure.body.position.Add( 0f, 10000f,  0f ); }

                if( Input.GetKeyDown( KeyCode.DownArrow ) )
                    { figure.body.position.Add( 0f,-10000f,  0f ); }

                // ** scale


                if( Input.GetKeyDown( KeyCode.Z ) )
                    { figure.body.scale.Add( 1f ); }

                if( Input.GetKeyDown( KeyCode.X ) )
                    { figure.body.scale.Add( -1f ); }

                

                if( Input.GetKeyDown( KeyCode.I ) )
                    { 
                        figure.Activate(new(){
                            parent = GameObject.Find( "Container_teste" ),
                            set_body_data = new(){
                                set_new_transform = true,    
                                self_transform = new(){
                                    rotation = Quaternion.Euler( 90f,0f,0f ),
                                },
                            }

                        });
                    }

                if( Input.GetKeyDown( KeyCode.O ) )
                    { 
                        figure.Deactivate();
                    }


            


        }

        

    }



}
