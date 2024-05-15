using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//  precisa mudar para ser mais generico

public enum Tipo_construcao_texto {

   config_default = 0,
   fade =  1,
   typewrite = 2,
   instant = 3,


}



public class Display_texto {


 //                  nao precisa?
    public         TextMeshProUGUI              text_container;
    public         GameObject                   game_object;
    public         TMP_Text                     caixa_texto;
    public         Tipo_construcao_texto        tipo_texto                =    Tipo_construcao_texto.fade;

    public         float                        speed                    =   5f;
    public         float                        base_speed = 1;
    public         float                        speed_multiplier = 1;

    public         int                          characters_per_cycle {   get{return speed<=2f? characters_multiplier:speed<=2.5f? characters_multiplier * 2 : characters_multiplier *3;}   }
    public         int                          characters_multiplier = 1;    
    public         Coroutine                    texto_coroutine = null;
    
    
    public   Display_texto( string _nome , float _width, float _height, float _font_size = 5f ) {


            game_object = new GameObject("Display_texto_" + _nome);

            text_container = game_object.AddComponent<TextMeshProUGUI>();

            caixa_texto = text_container;

            text_container.fontSize = _font_size;

            RectTransform text_rect = text_container.GetComponent<RectTransform>();

            text_rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal  ,  _width );
            text_rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical  ,  _height );



            TMP_FontAsset font_default = Resources.Load< TMP_FontAsset >( "fonts/Font_1" );
            caixa_texto.font = font_default;

    }



    public void Limpar_texto(){

      if( texto_coroutine != null){
         
         Mono_instancia.Stop_coroutine( texto_coroutine );
         texto_coroutine = null;

      }

      caixa_texto.text = "";


    }


    public void Mudar_tamanho(float _width, float _height ){

            RectTransform text_rect = text_container.GetComponent<RectTransform>();

            text_rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Horizontal  ,  _width );
            text_rect.SetSizeWithCurrentAnchors(  RectTransform.Axis.Vertical  ,  _height );


    }


    public void Setar_display( Transform _transform_pai, float _x_position = 0f, float _y_position = 0f ){

   
        this.game_object.transform.SetParent(_transform_pai, false);
        this.game_object.transform.localPosition = new Vector3(_x_position, _y_position, 0f);
        return;

    }




    

      public void Colocar_texto( string _text , int _tipo_texto , Color _cor_texto ,   Tipo_construcao_texto _tipo_construcao  ){

               caixa_texto.color = _cor_texto;

               //caixa_texto.ForceMeshUpdate();
                
               if(_tipo_construcao == Tipo_construcao_texto.config_default){  _tipo_construcao = Controlador_configuration.Pegar_instancia().tipo_texto;}

               string pre_text = "";
               string target_text = _text;
               
               switch( _tipo_texto ){
               
                     case 0 :pre_text = "  ";break; // reseta
                     case 1 :pre_text = caixa_texto.text + " "; break; // mesmo bloco
                     case 2 :pre_text = caixa_texto.text + "\n  " ;break;   // novo bloco
                  
               }


               Stop();

               texto_coroutine =  caixa_texto.StartCoroutine(       Building(  _tipo_construcao,  target_text ,  pre_text  )     );

               return ;

      }


      public IEnumerator Building(  Tipo_construcao_texto _tipo_build  , string _target_text ,string _pre_texto  ){


            switch(_tipo_build){
               
                  case Tipo_construcao_texto.instant:  Build_instant(_pre_texto ,  _target_text) ; break;
                  case Tipo_construcao_texto.typewrite: yield return Build_typewriter(_pre_texto ,  _target_text);break;
                  case Tipo_construcao_texto.fade: yield return Build_fade(_pre_texto ,  _target_text); break;

            }

            Stop();
         
      }




      public void Force_complete (){

         switch(  tipo_texto  ){

            case Tipo_construcao_texto.typewrite:  caixa_texto.maxVisibleCharacters = caixa_texto.textInfo.characterCount;break;
            case Tipo_construcao_texto.fade:  caixa_texto.ForceMeshUpdate(); break;
         }

         Stop();

      }



      public void Stop(){

            if(texto_coroutine != null){ 
                  Mono_instancia.Stop_coroutine(texto_coroutine);
                  texto_coroutine = null;
                  
            }
      
            return;
      }




      public void Build_instant(string _pre_text , string _target_text){

            caixa_texto.color = caixa_texto.color;
            caixa_texto.text = _pre_text + _target_text;
            caixa_texto.ForceMeshUpdate();
            caixa_texto.maxVisibleCharacters = caixa_texto.textInfo.characterCount;
            return;
            
      }




      public IEnumerator Build_typewriter(string _pre_text , string _target_text){
             
            caixa_texto.color = caixa_texto.color;
            caixa_texto.maxVisibleCharacters = 0;
            caixa_texto.text = _pre_text;


            if(_pre_text != ""){

                  caixa_texto.ForceMeshUpdate();
                  caixa_texto.maxVisibleCharacters = caixa_texto.textInfo.characterCount;
                  
            }

            caixa_texto.text += _target_text;
            caixa_texto.ForceMeshUpdate();





            while(caixa_texto.maxVisibleCharacters < caixa_texto.textInfo.characterCount){
                  
                  caixa_texto.maxVisibleCharacters +=  characters_per_cycle;

                  yield return new WaitForSeconds(0.015f / speed);

            }

      }







      public IEnumerator Build_fade(string _pre_text , string _target_text){

            Color text_color = caixa_texto.color;


            caixa_texto.text = _pre_text;

            int pre_text_length = 0;


            if(_pre_text != ""){
         
               caixa_texto.ForceMeshUpdate();
               pre_text_length = caixa_texto.textInfo.characterCount;

            }


            caixa_texto.text += _target_text;

            caixa_texto.maxVisibleCharacters = int.MaxValue;
            caixa_texto.ForceMeshUpdate();

            

            
            


            TMP_TextInfo text_info = caixa_texto.textInfo;

            Color color_visible = new Color(text_color.r, text_color.g, text_color.b, 1);
            Color color_hidden = new Color(text_color.r, text_color.g, text_color.b, 0);

            Color32[] vertex_colors = text_info.meshInfo[text_info.characterInfo[0].materialReferenceIndex].colors32;

               
               for(int i = 0 ; i< text_info.characterCount ;i++){


                  TMP_CharacterInfo char_info = text_info.characterInfo[i];
                     if(!char_info.isVisible) continue;
                  if(i<pre_text_length){
                     vertex_colors[char_info.vertexIndex]= color_visible;
                     vertex_colors[char_info.vertexIndex+1] = color_visible;
                     vertex_colors[char_info.vertexIndex+2] = color_visible;
                     vertex_colors[char_info.vertexIndex+3] = color_visible;

                  } else {

                     vertex_colors[char_info.vertexIndex] = color_hidden;
                     vertex_colors[char_info.vertexIndex+1] = color_hidden;
                     vertex_colors[char_info.vertexIndex+2] = color_hidden;
                     vertex_colors[char_info.vertexIndex+3] = color_hidden;

                  }
                     

               }
               
               caixa_texto.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);



               int minRange = pre_text_length;
               int maxRange = minRange + 1 ;   

               byte alphaThreshold = 40;

               text_info = caixa_texto.textInfo;

               vertex_colors = text_info.meshInfo[text_info.characterInfo[0].materialReferenceIndex].colors32;

               float[] alphas = new float[text_info.characterCount + 1];


            

               while(true){

               

                  for(int i = minRange; i<maxRange  ;i++){

                        float fade_speed = characters_per_cycle  * speed  * 4f;
               

                        TMP_CharacterInfo char_info = text_info.characterInfo[i];



            
                        if(!char_info.isVisible) continue;

                        alphas[i] = Mathf.MoveTowards(alphas[i], 255, fade_speed);


                        vertex_colors[char_info.vertexIndex].a = (byte)alphas[i];
                        vertex_colors[char_info.vertexIndex+1].a = (byte)alphas[i];
                        vertex_colors[char_info.vertexIndex+2].a = (byte)alphas[i];
                        vertex_colors[char_info.vertexIndex+3].a = (byte)alphas[i];


                           //if(alphas[i]>=255) minRange++;
                           if(alphas[i]>=255) minRange++;

                     }



                  caixa_texto.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

                  bool lastCharacterIsInvisible = !text_info.characterInfo [maxRange-1].isVisible;



                  if(alphas[maxRange-1]> alphaThreshold || lastCharacterIsInvisible) {
            
               //   todo texto tem um character invisible no final, entao o padrao seria - 1 para descontar esse char. com isso maxRange => numero de elementos array => index do ultimo elemento maxRange -1  
            
                  if(maxRange<text_info.characterCount) {

                     maxRange++;
                        if(maxRange<text_info.characterCount) maxRange++;


                  } else if(alphas[maxRange-1] >= 255) {
                  
                  break;
                  
               }


            }
               
               

               // yield break;
               yield return null;

               


               }

      }

}