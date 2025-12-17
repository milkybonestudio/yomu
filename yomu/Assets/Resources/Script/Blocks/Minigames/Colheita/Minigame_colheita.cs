// using System;
// using UnityEngine; 



// public enum Vegetal_colheita {

//     alface,
//     alface_podre,
//     diamante,

// }

// public class MINIGAME_colheita {

 
//         public static MINIGAME_colheita instancia;
//         public static MINIGAME_colheita Pegar_instancia( bool _forcar = false  ){

//                 if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("MINIGAME_colheita")) { instancia = new MINIGAME_colheita();instancia.Iniciar();} return instancia;}
//                 if(  instancia == null) { instancia = new MINIGAME_colheita(); instancia.Iniciar(); }
//                 return instancia;

//         }

//         public void Iniciar(){

//             Lidar_retorno  = () => {};
//             Mudar_UI  = () => {};
//             Mudar_input  = () => {};

//         }


//         public Action  Lidar_retorno ;
//         public Action  Mudar_UI ;
//         public Action  Mudar_input ;

//         public GameObject canvas = null;

//         public GameObject background = null;
//         public Image background_image = null;

//         public GameObject[] slots_vegetais = null;
//         public Image[][] imagens_vegetais_2d = null;

//         public Vegetal_colheita[][] vegetais_2d = null;


//         public int numero_slots_vegetais = 5;
//         public int numero_vegetais_por_slot = 3;

//         public float width_vegetal = 250f;
//         public float height_vegetal = 250f;


//         public float espacamento_entre_vegetais = 400f;

//         public float[] espacamento_entre_slots = new float[]{

//                 400f,
//                 200f,
//                 0f,
//                 -350f,
//                 -650f

//         };

//         public float[] scale_slots = new float[]{
            
//                 0.2f,
//                 0.4f,
//                 0.7f,
//                 1f,
//                 1.35f
                
//         };


//         public void Iniciar_colheita(  Transform _transform_pai , info  ){

//             canvas = new GameObject("MINIGAME_colheita");


//         }
//         public void Zerar_dados(){

//             Mono_instancia.Destroy( canvas );
//             canvas = null ;

//             background_image = null ;



//         }

//         public void Update(){}


//         public Vegetal_colheita Pegar_vegetal(){

//             return Vegetal_colheita.alface;

//         }

//         public GameObject Criar_canvas(){


//                 background = Geral.Criar_imagem(
//                     _nome   : "colheita_background" , 
//                     _pai    : canvas,
//                     _width  : 1920f,
//                     _height : 1080f,
//                     _path_imagem : "",
//                     _alpha : 1f

//                 )

//                 background_image = Geral.ultima_imagem;

//                 GameObject area_touch = new GameObject("");

                

//                 slots_vegetais = new GameObject[ numero_slots_vegetais ] ;
//                 imagens_vegetais_2d = new Image[ numero_slots_vegetais ][];
//                 vegetais_2d = new Vegetal_colheita[ numero_slots_vegetais ][];
//                 for( int numero_slot = 0 ; numero_slot < numero_slots_vegetais ; numero_slot ){ 

//                     imagens_vegetais_2d [ numero_slot ] = new Image[ numero_vegetais_por_slot ];
//                     vegetais_2d [ numero_slot ] = new Vegetal_colheita[ numero_vegetais_por_slot ];

//                 }


//                 for( int slot_index = 0 ; slot_index < numero_slots_vegetais ; slot_index++ ) {


//                         GameObject slot = new GameObject( "slot_" + Convert.ToSingle( slot_index ) ) ;
//                         slots_vegetais[ slot_index ] = slot ;

//                         // como scale vai operar? 
//                         float scale_do_slot = scale_slots[ slot_index ];
//                         slot.transform.localScale = new Vector3( scale_do_slot , scale_do_slot, scale_do_slot );

//                         for( int vegetal_index = 0 ; vegetal_index < 3 ; vegetal_index  ){

//                                 string nome = "vegetal_" + Convert.ToSingle( vegetal_index ) ;

//                                 GameObject vegetal = Geral.Criar_imagem(
//                                     _nome   : nome , 
//                                     _pai    : slot,
//                                     _width  : width_vegetal,
//                                     _height : height_vegetal,
//                                     _path_imagem : "",
//                                     _alpha : 1f

//                                 )

//                                 imagens_vegetais_2d[ slot_index ][ vegetal_index ] = Geral.ultima_imagem ;

//                                 float espacamento_atual = espacamento_entre_vegetais * ( vegetal_index - 1 );

//                                 vegetal.transform.localPosition = new Vector3( espacamento_atual , 0f,0f );

//                                 vegetais_2d[ slot_index ][ vegetal_index ] = Pegar_vegetal();

//                         }



//                 }





                


//         }



// }





