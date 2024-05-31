using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static  class Sara_room_scripts{

   

//      public GameObject UI_slot;
//      public bool UI_slot_atual_is_important = false;

//      public int[] porta_sara_room_nome_locais = new int[6];
    
  
     public static void Mostrar_opcoes_porta_sara(){


//        //  call contrutor_geral(data);


     
//       ///   nao tem mais 
//      // controlador.Mudar_modo_tela(Modo_tela.ui);

      
     
      
//         porta_sara_room_nome_locais =  Controlador_verificacoes.Pegar_instancia().ui_verificacoes.Pegar_opcoes_sara_room_door();

    
//          //if(UI_slot != null && !UI_slot_atual_is_important){ Mono_instancia.Destroy(UI_slot);}




//         controlador.interativos_ui = new Interativo_ui[7];


  
//         UI_slot = new GameObject("UI_opcoes_porta_sara");

//         UI_slot.AddComponent<Image>();

      
        
//         UI_slot.GetComponent<Image>().sprite = Resources.Load<Sprite>("images/in_game/ui/blocos/sara_room/door/sara_room_porta");

//         Vector3 one_scale = new Vector3(1f/108f, 1f/108f, 1f/108f);
        
//         UI_slot.transform.localScale = one_scale;


//         UI_slot.transform.GetComponent<RectTransform>().sizeDelta =  new Vector2(  1920f , 1080f  );
        
//         Vector2 op_size =  new Vector2(  260f , 155f  );


       
      
         

//         GameObject op_1 = new GameObject("op_1"); op_1.AddComponent<Image>();Image op_1_image =  op_1.GetComponent<Image>();op_1_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(0)   );op_1.transform.localScale = one_scale; op_1.transform.position = new Vector3(-372f/108f, 70f/108f , 0f) ;op_1.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_1.transform.SetParent (UI_slot.transform);
//         GameObject op_2 = new GameObject("op_2"); op_2.AddComponent<Image>();Image op_2_image =  op_2.GetComponent<Image>();op_2_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(1)   );op_2.transform.localScale = one_scale; op_2.transform.position = new Vector3(7f/108f, 70f/108f , 0f) ;op_2.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_2.transform.SetParent (UI_slot.transform);
//         GameObject op_3 = new GameObject("op_3"); op_3.AddComponent<Image>();Image op_3_image =  op_3.GetComponent<Image>();op_3_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(2)   );op_3.transform.localScale = one_scale; op_3.transform.position = new Vector3(385f/108f, 70f/108f , 0f) ;op_3.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_3.transform.SetParent (UI_slot.transform);
//         GameObject op_4 = new GameObject("op_4"); op_4.AddComponent<Image>();Image op_4_image =  op_4.GetComponent<Image>();op_4_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(3)   );op_4.transform.localScale = one_scale; op_4.transform.position = new Vector3(-372f/108f, -129f/108f , 0f) ;op_4.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_4.transform.SetParent (UI_slot.transform);
//         GameObject op_5 = new GameObject("op_5"); op_5.AddComponent<Image>();Image op_5_image =  op_5.GetComponent<Image>();op_5_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(4)   );op_5.transform.localScale = one_scale; op_5.transform.position = new Vector3(7f/108f, -129f/108f , 0f) ;op_5.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_5.transform.SetParent (UI_slot.transform);
//         GameObject op_6 = new GameObject("op_6"); op_6.AddComponent<Image>();Image op_6_image =  op_6.GetComponent<Image>();op_6_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(5)   );op_6.transform.localScale = one_scale; op_6.transform.position = new Vector3(385f/108f, -129f/108f , 0f) ;op_6.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_6.transform.SetParent (UI_slot.transform);
        
 
//          controlador.interativos_ui[0] =  new Interativo_ui();
//          controlador.interativos_ui[0].on_click = Receber_opcoes_porta_sara_sair;
//          controlador.interativos_ui[0].interativo_ui_image = op_1_image;
//          controlador.interativos_ui[0].Colocar_normal_color();
//          controlador.interativos_ui[0].area = new float[]{

//             444f, 308f,
//  1484f, 305f,
//  1553f, 289f,
//  1604f, 355f,
//  1552f, 410f,
//  1554f, 723f,
//  1604f, 773f,
//  1549f, 852f,
//  1479f, 825f,
//  443f, 825f,
//  378f, 848f,
//  323f, 768f,
//  372f, 723f,
//  373f, 409f,
//  324f, 365f,
//  378f, 283f,
//  444f, 308f,



//          };
         
          
//          controlador.interativos_ui[1] =  new Interativo_ui();
//          controlador.interativos_ui[1].on_click = Receber_opcoes_porta_sara_class_room;
//          controlador.interativos_ui[1].interativo_ui_image = op_1_image;
//          controlador.interativos_ui[1].Colocar_normal_color();
//          controlador.interativos_ui[1].area = new float[]{

//  446f, 385f,
//  736f, 387f,
//  736f, 558f,
//  444f, 558f,
//  446f, 385f,




//          };
         

//          controlador.interativos_ui[2] =  new Interativo_ui();
//          controlador.interativos_ui[2].on_click = Receber_opcoes_porta_sara_corridor;
//          controlador.interativos_ui[2].interativo_ui_image = op_2_image;
//          controlador.interativos_ui[2].Colocar_normal_color();
//          controlador.interativos_ui[2].area = new float[]{
//            823f, 387f,
//  1114f, 385f,
//  1114f, 556f,
//  822f, 556f,
//  823f, 387f,


//          };


//          controlador.interativos_ui[3] =  new Interativo_ui();
//          controlador.interativos_ui[3].on_click = Receber_opcoes_porta_sara_nursery;
//          controlador.interativos_ui[3].interativo_ui_image = op_3_image;
//          controlador.interativos_ui[3].Colocar_normal_color();
         
//          controlador.interativos_ui[3].area = new float[]{
//             1201f, 557f,
//  1199f, 385f,
//  1489f, 387f,
//  1492f, 558f,
//  1201f, 557f,


//          };
//          controlador.interativos_ui[4] =  new Interativo_ui();
//          controlador.interativos_ui[4].on_click = Receber_opcoes_porta_sara_bath;
//          controlador.interativos_ui[4].interativo_ui_image = op_4_image;
//          controlador.interativos_ui[4].Colocar_normal_color();
//          controlador.interativos_ui[4].area = new float[]{
//              446f, 584f,
//  733f, 583f,
//  736f, 755f,
//  443f, 756f,
//  446f, 584f,


//          };
//          controlador.interativos_ui[5] =  new Interativo_ui();
//          controlador.interativos_ui[5].on_click = Receber_opcoes_porta_sara_library;
//          controlador.interativos_ui[5].interativo_ui_image = op_5_image;
//          controlador.interativos_ui[5].Colocar_normal_color();
//          controlador.interativos_ui[5].area = new float[]{
//             823f, 584f,
//  1114f, 582f,
//  1114f, 757f,
//  827f, 756f,
//  823f, 584f,


//          };
//          controlador.interativos_ui[6] =  new Interativo_ui();
//          controlador.interativos_ui[6].on_click = Receber_opcoes_porta_sara_refectory;
//          controlador.interativos_ui[6].interativo_ui_image = op_6_image;
//          controlador.interativos_ui[6].Colocar_normal_color();
//          controlador.interativos_ui[6].area = new float[]{

//              1203f, 583f,
//  1489f, 586f,
//  1490f, 755f,
//  1201f, 753f,
//  1203f, 583f,


//          };


         

      




    
//         UI_slot.transform.SetParent (controlador.controlador_tela.UI.transform);






            












//  string Pegar_local_opcoes_porta_sara(  int _index){

//       switch(_index){

//         case 0 : return  pegar_0( porta_sara_room_nome_locais[0] );
//         case 1 : return  pegar_1( porta_sara_room_nome_locais[1] );
//         case 2 : return  pegar_2( porta_sara_room_nome_locais[2] );
//         case 3 : return  pegar_3( porta_sara_room_nome_locais[3] );
//         case 4 : return  pegar_4( porta_sara_room_nome_locais[4] );
//         case 5 : return  pegar_5( porta_sara_room_nome_locais[5] );
        
//       }

//       return "";


//       string pegar_0 (int _valor){

        
        
//          switch(_valor){
            
              
//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 122 : return  "images/in_game/ui/blocos/sara_room/door/op_1_normal_d";
 
//          }

//          return "";

//       }


//       string pegar_1 (int _valor){

//          switch(_valor){

//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 1 : return  "images/in_game/ui/blocos/sara_room/door/op_2_normal_d";
 

//          }

//          return "";

//       }
       
//       string pegar_2 (int _valor){

//          switch(_valor){

//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 1 : return  "images/in_game/ui/blocos/sara_room/door/op_3_normal_d";
 

//          }

//          return "";

//       }
       

//       string pegar_3 (int _valor){

//          switch(_valor){

//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 1 : return  "images/in_game/ui/blocos/sara_room/door/op_4_normal_d";
 

//          }

//          return "";

//       }

//        string pegar_4 (int _valor){

//          switch(_valor){

//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 1 : return  "images/in_game/ui/blocos/sara_room/door/op_5_normal_d";
 

//          }

//          return "";

//       }
       

//         string pegar_5 (int _valor){

//          switch(_valor){

//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 1 : return  "images/in_game/ui/blocos/sara_room/door/op_6_normal_d";
 

//          }

//          return "";

//       }
       
       
       
        




//      }

     
//        void Receber_opcoes_porta_sara_sair(){

//          controlador.Mudar_modo_tela(Modo_tela.in_game);
//          Controlador.Destroy( UI_slot.gameObject );
                   
//         return;


//      }


//       void Receber_opcoes_porta_sara_class_room(){

        
//         controlador.Mover_player(porta_sara_room_nome_locais[0]);

//         Receber_opcoes_porta_sara_sair();


//         Debug.Log("veio class");
//         return;


//      }

     
//       void Receber_opcoes_porta_sara_bath(){

//         Debug.Log("veio bath");
//         return;


//      }
     
//       void Receber_opcoes_porta_sara_corridor(){

//         Debug.Log("veio combat");
//         return;


//      }
     
//       void Receber_opcoes_porta_sara_nursery(){

//         Debug.Log("veio nursery");
//         return;


//      }
     
//       void Receber_opcoes_porta_sara_library(){

//         Debug.Log("veio library");
//         return;


//      }
     
//       void Receber_opcoes_porta_sara_refectory(){

//         Debug.Log("veio refectory");
//         return;


//      }




      
       return;    
}
















public static  void Mostrar_opcoes_closet(){




// controlador.Mudar_modo_tela(Modo_tela.ui);
      
//       porta_sara_room_nome_locais =  Controlador_verificacoes.Pegar_instancia().ui_verificacoes.Pegar_opcoes_sara_room_door();

    
//         if(UI_slot != null && !UI_slot_atual_is_important){ Controlador.Destroy(UI_slot);} 


//         controlador.interativos_ui = new Interativo_ui[7];


  
//         UI_slot = new GameObject("UI_opcoes_closet");

//         UI_slot.AddComponent<Image>();

       
        
//         UI_slot.GetComponent<Image>().sprite =Resources.Load<Sprite>("images/in_game/ui/blocos/sara_room/door/sara_room_porta");

//         Vector3 one_scale = new Vector3(1f/108f, 1f/108f, 1f/108f);
        
//         UI_slot.transform.localScale = one_scale;


//         UI_slot.transform.GetComponent<RectTransform>().sizeDelta =  new Vector2(  1920f , 1080f  );
        
//         Vector2 op_size =  new Vector2(  260f , 155f  );


       
      
         

//         GameObject op_1 = new GameObject("op_1"); op_1.AddComponent<Image>();Image op_1_image =  op_1.GetComponent<Image>();op_1_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(0)   );op_1.transform.localScale = one_scale; op_1.transform.position = new Vector3(-372f/108f, 70f/108f , 0f) ;op_1.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_1.transform.SetParent (UI_slot.transform);
//         GameObject op_2 = new GameObject("op_2"); op_2.AddComponent<Image>();Image op_2_image =  op_2.GetComponent<Image>();op_2_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(1)   );op_2.transform.localScale = one_scale; op_2.transform.position = new Vector3(7f/108f, 70f/108f , 0f) ;op_2.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_2.transform.SetParent (UI_slot.transform);
//         GameObject op_3 = new GameObject("op_3"); op_3.AddComponent<Image>();Image op_3_image =  op_3.GetComponent<Image>();op_3_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(2)   );op_3.transform.localScale = one_scale; op_3.transform.position = new Vector3(385f/108f, 70f/108f , 0f) ;op_3.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_3.transform.SetParent (UI_slot.transform);
//         GameObject op_4 = new GameObject("op_4"); op_4.AddComponent<Image>();Image op_4_image =  op_4.GetComponent<Image>();op_4_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(3)   );op_4.transform.localScale = one_scale; op_4.transform.position = new Vector3(-372f/108f, -129f/108f , 0f) ;op_4.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_4.transform.SetParent (UI_slot.transform);
//         GameObject op_5 = new GameObject("op_5"); op_5.AddComponent<Image>();Image op_5_image =  op_5.GetComponent<Image>();op_5_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(4)   );op_5.transform.localScale = one_scale; op_5.transform.position = new Vector3(7f/108f, -129f/108f , 0f) ;op_5.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_5.transform.SetParent (UI_slot.transform);
//         GameObject op_6 = new GameObject("op_6"); op_6.AddComponent<Image>();Image op_6_image =  op_6.GetComponent<Image>();op_6_image.sprite = Resources.Load<Sprite>(   Pegar_local_opcoes_porta_sara(5)   );op_6.transform.localScale = one_scale; op_6.transform.position = new Vector3(385f/108f, -129f/108f , 0f) ;op_6.transform.GetComponent<RectTransform>().sizeDelta = op_size;op_6.transform.SetParent (UI_slot.transform);
        
 
//          controlador.interativos_ui[0] =  new Interativo_ui();
//          controlador.interativos_ui[0].on_click = Receber_opcoes_porta_sara_sair;
//          controlador.interativos_ui[0].interativo_ui_image = op_1_image;
//          controlador.interativos_ui[0].Colocar_normal_color();
//          controlador.interativos_ui[0].area = new float[]{

//             444f, 308f,
//  1484f, 305f,
//  1553f, 289f,
//  1604f, 355f,
//  1552f, 410f,
//  1554f, 723f,
//  1604f, 773f,
//  1549f, 852f,
//  1479f, 825f,
//  443f, 825f,
//  378f, 848f,
//  323f, 768f,
//  372f, 723f,
//  373f, 409f,
//  324f, 365f,
//  378f, 283f,
//  444f, 308f,



//          };
         
          
//          controlador.interativos_ui[1] =  new Interativo_ui();
//          controlador.interativos_ui[1].on_click = Receber_opcoes_porta_sara_class_room;
//          controlador.interativos_ui[1].interativo_ui_image = op_1_image;
//          controlador.interativos_ui[1].Colocar_normal_color();
//          controlador.interativos_ui[1].area = new float[]{

//  446f, 385f,
//  736f, 387f,
//  736f, 558f,
//  444f, 558f,
//  446f, 385f,




//          };
         

//          controlador.interativos_ui[2] =  new Interativo_ui();
//          controlador.interativos_ui[2].on_click = Receber_opcoes_porta_sara_corridor;
//          controlador.interativos_ui[2].interativo_ui_image = op_2_image;
//          controlador.interativos_ui[2].Colocar_normal_color();
//          controlador.interativos_ui[2].area = new float[]{
//            823f, 387f,
//  1114f, 385f,
//  1114f, 556f,
//  822f, 556f,
//  823f, 387f,


//          };


//          controlador.interativos_ui[3] =  new Interativo_ui();
//          controlador.interativos_ui[3].on_click = Receber_opcoes_porta_sara_nursery;
//          controlador.interativos_ui[3].interativo_ui_image = op_3_image;
//          controlador.interativos_ui[3].Colocar_normal_color();
         
//          controlador.interativos_ui[3].area = new float[]{
//             1201f, 557f,
//  1199f, 385f,
//  1489f, 387f,
//  1492f, 558f,
//  1201f, 557f,


//          };
//          controlador.interativos_ui[4] =  new Interativo_ui();
//          controlador.interativos_ui[4].on_click = Receber_opcoes_porta_sara_bath;
//          controlador.interativos_ui[4].interativo_ui_image = op_4_image;
//          controlador.interativos_ui[4].Colocar_normal_color();
//          controlador.interativos_ui[4].area = new float[]{
//              446f, 584f,
//  733f, 583f,
//  736f, 755f,
//  443f, 756f,
//  446f, 584f,


//          };
//          controlador.interativos_ui[5] =  new Interativo_ui();
//          controlador.interativos_ui[5].on_click = Receber_opcoes_porta_sara_library;
//          controlador.interativos_ui[5].interativo_ui_image = op_5_image;
//          controlador.interativos_ui[5].Colocar_normal_color();
//          controlador.interativos_ui[5].area = new float[]{
//             823f, 584f,
//  1114f, 582f,
//  1114f, 757f,
//  827f, 756f,
//  823f, 584f,


//          };
//          controlador.interativos_ui[6] =  new Interativo_ui();
//          controlador.interativos_ui[6].on_click = Receber_opcoes_porta_sara_refectory;
//          controlador.interativos_ui[6].interativo_ui_image = op_6_image;
//          controlador.interativos_ui[6].Colocar_normal_color();
//          controlador.interativos_ui[6].area = new float[]{

//              1203f, 583f,
//  1489f, 586f,
//  1490f, 755f,
//  1201f, 753f,
//  1203f, 583f,


//          };


         

      




    
//         UI_slot.transform.SetParent (controlador.controlador_tela.UI.transform);






//             Debug.Log("Mostrar_opcoes_porta_sara");












//  string Pegar_local_opcoes_porta_sara(  int _index){

//       switch(_index){

//         case 0 : return  pegar_0( porta_sara_room_nome_locais[0] );
//         case 1 : return  pegar_1( porta_sara_room_nome_locais[1] );
//         case 2 : return  pegar_2( porta_sara_room_nome_locais[2] );
//         case 3 : return  pegar_3( porta_sara_room_nome_locais[3] );
//         case 4 : return  pegar_4( porta_sara_room_nome_locais[4] );
//         case 5 : return  pegar_5( porta_sara_room_nome_locais[5] );
        
//       }

//       return "";


//       string pegar_0 (int _valor){

//          switch(_valor){
              
//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 122 : return  "images/in_game/ui/blocos/sara_room/door/op_1_normal_d";
 
//          }

//          return "";

//       }


//       string pegar_1 (int _valor){

//          switch(_valor){

//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 1 : return  "images/in_game/ui/blocos/sara_room/door/op_2_normal_d";
 

//          }

//          return "";

//       }
       
//       string pegar_2 (int _valor){

//          switch(_valor){

//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 1 : return  "images/in_game/ui/blocos/sara_room/door/op_3_normal_d";
 

//          }

//          return "";

//       }
       

//       string pegar_3 (int _valor){

//          switch(_valor){

//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 1 : return  "images/in_game/ui/blocos/sara_room/door/op_4_normal_d";
 

//          }

//          return "";

//       }

//        string pegar_4 (int _valor){

//          switch(_valor){

//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 1 : return  "images/in_game/ui/blocos/sara_room/door/op_5_normal_d";
 

//          }

//          return "";

//       }
       

//         string pegar_5 (int _valor){

//          switch(_valor){

//              case 0 : return  "images/in_game/ui/blocos/sara_room/door/nada";
//              case 1 : return  "images/in_game/ui/blocos/sara_room/door/op_6_normal_d";
 

//          }

//          return "";

//       }
       
       
       
        




//      }

     
//        void Receber_opcoes_porta_sara_sair(){

//          controlador.Mudar_modo_tela(Modo_tela.in_game);
//          Controlador.Destroy( UI_slot.gameObject );
                   
//         return;


//      }


//       void Receber_opcoes_porta_sara_class_room(){

        
//         controlador.Mover_player(porta_sara_room_nome_locais[0]);

//         Receber_opcoes_porta_sara_sair();


//         Debug.Log("veio class");
//         return;


//      }

     
//       void Receber_opcoes_porta_sara_bath(){

//         Debug.Log("veio bath");
//         return;


//      }
     
//       void Receber_opcoes_porta_sara_corridor(){

//         Debug.Log("veio combat");
//         return;


//      }
     
//       void Receber_opcoes_porta_sara_nursery(){

//         Debug.Log("veio nursery");
//         return;


//      }
     
//       void Receber_opcoes_porta_sara_library(){

//         Debug.Log("veio library");
//         return;


//      }
     
//       void Receber_opcoes_porta_sara_refectory(){

//         Debug.Log("veio refectory");
//         return;


//      }




      
       return;    



















}


   

    

    




}