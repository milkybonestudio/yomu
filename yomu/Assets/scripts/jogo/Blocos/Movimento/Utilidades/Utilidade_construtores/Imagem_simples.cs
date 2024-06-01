using UnityEngine;
using UnityEngine.UI;
using System;






public static class  Imagem_simples_utilidades {

          public static Action Construir(

                string _nome,
                string _path_imagem,
                int _clicks_para_ignorar,
                int _frames_para_ignorar,
                Action _fn_click, 

                float _width = 1920f,
                float _height = 1080f,

                float _position_x = 0f,
                float _position_y = 0f


          ){



            GameObject canvas = Controlador_utilidades.Pegar_instancia().canvas_utilidades;
            
              
            
            
            string path_completo =  "images/in_game/"  +  _path_imagem;
            float[] posicao_mouse = Controlador_dados.Pegar_instancia().posicao_mouse;


            
            
            Botao botao = new Botao(

                _nome: _nome,
                _width: _width, 
                _height: _height, 
                _x_position: _position_x, 
                _y_position: _position_y, 
                _parent_transform : canvas.transform,
                _on_click: null,
                _tipo_botao: Tipo_botao.estatico

            );


            botao.Colocar_imagem(path_completo);


            botao.click = () => {

            
                    if(_clicks_para_ignorar > 0) _clicks_para_ignorar--;

                    if(_frames_para_ignorar > 0) { return;}

                    
                    if(_clicks_para_ignorar == 0 ) {


                        if(_fn_click != null) _fn_click();

                        Controlador_utilidades.Pegar_instancia().Finalizar();

                    }
            
        
            };



              Action update = () => {

                    if(_frames_para_ignorar > 0){

                            _frames_para_ignorar--;
                            

                    } 

                    bool is_click = Input.GetMouseButtonDown(0);
                    botao.Update(is_click, posicao_mouse);

              };



              return update;


          }

          
       
  



}

