using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


public class RESOURCE__image_data {


        public RESOURCE__image image;

        public Type_image type;

        // ** LOCATOR
        public string image_path;


        // ** nao faz sentido ficar aqui?
        //mark
        // ** resources so trabalha com paths, mas os dados vão ser pedidos pelas figures. 
        // ** no script eles não vão pedir as imagens individualmente então não vai ficar muito grande nos scripts 
        // ** vai ser algo como ( id personagem 2 bytes )( acao_figure 1 byte )
        // ** e a figure vai transformar esse acao_figure em um path apropriado
        // public Image_localizers image_localizers;

        
        // --- ORIGINAL IMAGE

        public int height;
        public int width;

        // --- INFORMATION TO DEAL DIFFERENCES

        // ** add
        public float default_rotation = 0;
        public int width_margin;
        public int height_margin;
    

        // --- DATA
        public byte[] image_compress;
        public Texture_allocated texture_allocated;
        public Sprite sprite;




}




