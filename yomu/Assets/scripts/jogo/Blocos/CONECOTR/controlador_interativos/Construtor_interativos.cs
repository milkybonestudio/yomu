using System;
using UnityEngine;

public class Construtor_interativos {

        public Construtor_interativos( Controlador_interativos _controlador ){

            controlador_interativos = _controlador;

        }


        public Controlador_interativos controlador_interativos;

        // sempre vai ter todos os dados
        public byte[] localizador_dados_interativos;
        public byte[][] containers_dados_interativos;



        public Interativo_tela Criar_interativo_tela_DEVELOPMENT( Posicao_local _posicao, int _interativo_id ){


                int cidade = _posicao.cidade;
                int  regiao = _posicao.regiao;
                int  area = _posicao.area;
                int  ponto = _posicao.ponto;

                // pegar_interativo = Letor_interativos_SAINT_LAND_.Pegar()

                Interativo_tela interativo_tela = Leitor_interativos_tela_DESENVOLVIMENTO.Pegar( cidade , regiao, area, ponto,_interativo_id );
                

                return interativo_tela;



        }

        public Interativo_tela Criar_interativo_tela_DEVELOPMENT( Interativo_tela _interativo ){


        
                // isso vai ser no development?
                  
                string variante_periodo = "";

                if(_interativo.metodo_que_as_imagens_estao_salvas  == Metodo_que_as_imagens_estao_salvas.dia_E_noite)
                        {

                                if( Controlador_timer.Pegar_instancia().periodo_atual_id < 3 )
                                        { variante_periodo = "_d"; } 
                                        else
                                        { variante_periodo = "_n"; }

                        } 

                string _path = "";
        
        
                if(_interativo.tipo_mouse_hover == Interativo_tipo_mouse_hover.nada_E_nada )
                        {
                                        
                                _interativo.interativo_image_1 = null;
                                _interativo.cor_image_1 = Color.clear;
                                
                                _interativo.interativo_image_2 = null;
                                _interativo.cor_image_2 = Color.clear;
                                
                        
                        } 
                        else if(  _interativo.tipo_mouse_hover == Interativo_tipo_mouse_hover.nada_E_one)                
                        {

                                _interativo.interativo_image_1 = null;
                                _interativo.cor_image_1 = Color.clear;

                                _interativo.interativo_image_2 = Resources.Load<Sprite>( _path + _interativo.nome +  variante_periodo);

                                
                                if(_interativo.interativo_image_2 == null)
                                        { throw new ArgumentException("nao foia chado imagem no path: " + _path + _interativo.nome +  variante_periodo + ". Modelo: nada_E_one");}
                                _interativo.cor_image_2 = Color.white;
                                

                        }
                        else  if(_interativo.tipo_mouse_hover == Interativo_tipo_mouse_hover.one_E_one) 
                        {

                                _interativo.interativo_image_1 = Resources.Load<Sprite>( _path + _interativo.nome +  variante_periodo);

                                if(_interativo.interativo_image_1 == null)
                                        { throw new ArgumentException("nao foia chado imagem no path: " + _path + _interativo.nome +  variante_periodo + ". Modelo: one_E_one" );}
                                
                                _interativo.cor_image_1 = Color.white;
                                _interativo.interativo_image_2 = _interativo.interativo_image_1;
                                _interativo.cor_image_2 = Color.white;
                

                        } 
                        else if(_interativo.tipo_mouse_hover == Interativo_tipo_mouse_hover.one_E_two)
                        {

                                _interativo.interativo_image_1 = Resources.Load<Sprite>( _path + _interativo.nome +  "_1" + variante_periodo);
                                _interativo.cor_image_1 = Color.white;
                                _interativo.interativo_image_2 = Resources.Load<Sprite>( _path + _interativo.nome +  "_2" + variante_periodo);
                                _interativo.cor_image_1 = Color.white;


                                if( _interativo.interativo_image_1 == null )
                                        {throw new ArgumentException("nao foia chado imagem no path: " + _path + _interativo.nome + "_1" +   variante_periodo + ". Modelo: one_E_two");}
                                
                                if( _interativo.interativo_image_2 == null )
                                        {throw new ArgumentException("nao foia chado imagem no path: " + _path + _interativo.nome + "_2" +   variante_periodo +". Modelo: one_E_two");}

                                

                        } 
                        // else  if(_interativo.tipo_mouse_hover  ==  Interativo_tipo_mouse_hover.one_80_E_one_100  )
                        // {

                        //         _interativo.interativo_image_1 = Resources.Load<Sprite>( _path  + _interativo.nome  + variante_periodo);
                        //         _interativo.cor_image_1 = new Color(0.8f,0.8f,0.8f,1f);

                        //         _interativo.interativo_image_2 = _interativo.interativo_image_1;
                        //         _interativo.cor_image_2 = Color.white;
                                
                        //         if( _interativo.interativo_image_1 == null )
                        //                 { throw new ArgumentException( "nao foi achado imagem no path: " + _path + _interativo.nome +  variante_periodo + ". Modelo: one_80_E_one_100" ) ; }

                                


                        // }

                

                _interativo.image_slot.sprite = _interativo.interativo_image_1;
                _interativo.image_slot.color = _interativo.cor_image_1;

                return null;


        }


        //** faz depois
        public Interativo_personagem[] Criar_interativos_tipo_personagem( int[] _lista_ids ){ throw new Exception( "tem que fazer" ); }
        public Interativo_item[] Criar_interativos_tipo_item( int[] _lista_ids ){ throw new Exception( "tem que fazer" ); }


        // ** nao vai criar as imagens
        public Interativo_tela[] Criar_interativo_tipo_tela( int[] _lista_ids ){


                
                

                return null;

                // logica + imagens 


                // --- CHECKS DE SEGURANCA

                // if( _lista_ids == null )
                //     { throw new Exception( "lista ids veio null" ); }



                // int numero_interativos_tipo_tela = _lista_ids.Length;
                // int periodo =   Controlador_timer.Pegar_instancia().periodo_atual_id ;



                // string path =  "images/in_game/" +  _ponto.folder_path;


                // Interativo_tela[] interativos_retorno = new Interativo_tela[ numero_interativos_tipo_tela ];

                
                // for( int i = 0; i < numero_interativos  ;i++){

                    
                //         string name  = "Interativo_" + Convert.ToString( interativos_nomes[ i ] );


                // }

        }

}