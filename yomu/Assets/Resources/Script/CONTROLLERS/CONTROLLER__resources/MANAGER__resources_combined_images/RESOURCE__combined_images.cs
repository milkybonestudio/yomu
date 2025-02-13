using UnityEngine;



public class RESOURCE__combined_image  {


        public GameObject images_game_object;
        public Image_link[] links;
        
        public Combined_image_render render;

        
        
        public void Retake_render(){

            render.render_texture.Create();

        }

        // ** tira um novo print 
        public void Change(){ render.Print(); }

        public void Delete(){

            render.Delete();

        }

        public void Free(){

            render.render_texture.Release();

        }


}