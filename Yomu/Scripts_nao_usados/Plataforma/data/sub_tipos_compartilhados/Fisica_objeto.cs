using UnityEngine;
using System;



public class Fisica_objeto{

     
     // 0 => poligono
     // 1 => retangulo

     // obj_1.type  *  obj_2.type => tipo verificacao


     public Fisica_objeto(int _id,  Tipo_objeto _tipo  ){

          id = _id;
          tipo = _tipo;
          
     }
     
     public int id;
     public Tipo_objeto tipo;


     
     public int shape_type = 1;
     
     public mov_type mov_type = mov_type.fixo;

     public conteudo conteudo = conteudo.solido;


     public float[] position = new float[2]{   0f,0f  };
  
     //   hit box
     public float[] dimensions = new float[2] {  128f , 128f  };

     public float[] image_dimensions = new float[2]{ -1, -1};

     public float[] vectors_acc = new float[2];

     public float[] vectors_speed = new float[2];

     public float[] pontos = new float[8]{   -64f,64f,      64f,64f,     64f,-64f,    -64f,-64f     }; 



     public float[] project_pontos = new float[8]{   -64f,64f,      64f,64f,     64f,-64f,    -64f,-64f     }; 

    
     public float[] project_position = new float[2];

     public float[] speed_collision_multiplier = new float[2]{1f,1f};

     public bool[]  lados_com_suporte = new bool[4];

     



     public void Setar_size_AND_position(  float px, float py , float width  , float height, float width_image= -1f, float height_image = -1f){




          this.position = new float[2] {  px, py  };
          this.dimensions = new float[]{  width  , height  };

          if(width_image < 0) width_image = width;
          if(height_image < 0) height_image = height;

          this.image_dimensions = new float[]{  width_image  , height_image };


          this.project_position = new float[2] {  px, py  };

          this.pontos = new float[8]{
       
               px   - width/2   ,     py  + height /2,

               px   + width/2   ,     py  + height /2,

               px   + width/2   ,     py  - height /2,

               px   - width/2   ,     py  - height /2

          };

          this.project_pontos = new float[8]{
       
               px   - width/2   ,     py  + height /2,

               px   + width/2   ,     py  + height /2,

               px   + width/2   ,     py  - height /2,

               px   - width/2   ,     py  - height /2

          };

          return;

     }


     





       public void Aplicar_velocidade(Transform _thing){
   
            this.position[0] =  this.position[0] +      (this.speed_collision_multiplier[0]  *   this.vectors_speed[0] ) ;
            this.position[1] =  this.position[1] +  (this.speed_collision_multiplier[1]  *   this.vectors_speed[1] ) ;

            this.pontos = Mat.Transformar_dados_em_pontos(this.position,  this.dimensions);

            //this.transform.localPosition = new Vector3(   this.position[0], this.position[1], 0f);
            _thing.localPosition = new Vector3(   this.position[0], this.position[1], 0f);

            

            this.speed_collision_multiplier[0] = 1f;
            this.speed_collision_multiplier[1] = 1f;
    
            return;

      }










}


