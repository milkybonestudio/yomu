using Unity.Collections;
using UnityEngine;


public struct Texture_allocated {

        // ** just destroy when free
        public int texture_size_slot; 
        public int texture_id;


        public bool exclusive_texture;
        public int exclusive_texture_id;
        
        public bool texture_active;
        

        // ** texture onde esta alocado
        // ** width e height nao importa mais, como varias iamgens vao ser colocadas em uma unica texture eu só preciso ter uma referencia de onde começa na texture para por os pixels e criar a sprite


        // ** se for usar aqui o sistema garante que tem espeço na texture
        // ** quando a imagem quiser quebrar a linha o ponto para começar vai ser tex[ ponto_antigo + p_x + 1  ]
        // ** ele só ignora o espaço em branco
        public int pointer_x;
        public int pointer_y;

        public int texture_width;
        public int texture_height;

        public NativeArray<Color32> native_array; // somente? 

        public Texture2D texture; // ** ref do container grande , tomar cuidado


}
