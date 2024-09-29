
public static class Creat_locator_image {

        public static RESOURCE__image_data Craeate( int _data_container_id, int _image_id, int _height, int _width ){

            RESOURCE__image_data image_data = new RESOURCE__image_data();

                image_data.height = _height;
                image_data.width = _width;
                image_data.image_id = _image_id; 
                image_data.data_container_id = _data_container_id;

            return image_data;

        }

}
