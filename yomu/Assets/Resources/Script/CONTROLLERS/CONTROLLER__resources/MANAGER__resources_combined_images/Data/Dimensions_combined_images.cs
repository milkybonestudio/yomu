


public struct Dimensions_combined_images {

    public int width;
    public int height;

    // ** caso um objeto tenha mais coisas para a direita precisa ajustar
    // ** se nao a camera vai ficar centralizada e vai cortar coisa a direita

    //    image_______________________Centro_camera__image
    //                  |                                              |
    // **               image________________|_____________________image
    // **                               ( width )

    // ** vai ser reajustado no QUAD com o negativo do da camera
    public float off_set_width; 
    public float off_set_height;

}