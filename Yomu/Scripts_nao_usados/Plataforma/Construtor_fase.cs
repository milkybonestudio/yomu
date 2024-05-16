using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text.RegularExpressions;




public  static class Construtor_fase_plataforma{




        public static int trava_seguranca = 0;

        public static void Verificar_trava(){

            if(trava_seguranca > 5000) throw new ArgumentException("problema em construtor fase");
            trava_seguranca++;

        }
    
    
    

        public static void Construir(string path , BLOCO_plataforma _plataforma ){

                GameObject world = _plataforma.world;
                string cenas_raw = Resources.Load<TextAsset>("files/fases" + path).text;

                cenas_raw = Regex.Replace(cenas_raw, @"(\r\n)+", "\r\n").Trim();
                cenas_raw = Regex.Replace(cenas_raw, @"\r\n( )+\r\n", "\r\n");

                string[] lines = cenas_raw.Split("\r\n");

                int line = 0;

                while(  line < lines.Length  ){
                    
                    switch(lines[  line  ]){

                        case "//BACKGROUNDS" : Pegar_backgrounds( ref line, lines );break;
                        case "//MOBS" : Pegar_mobs( ref line, lines );break;
                        case "//TERRENOS" : Pegar_terrenos( ref line, lines );break;


                    }

                    line++;


                }


        }





        public static void Pegar_backgrounds(  ref int _line , string[] _lines ){

            trava_seguranca = 0;

            BLOCO_plataforma plataforma =  BLOCO_plataforma.Pegar_instancia();

            int linha_inicial = _line + 1;

            while(true){

                Verificar_trava();

                if( _lines[ _line ]  == "//END_BACKGROUNDS"){break;}
                     
                     
                
                    _line++; 

                
            }

            int linha_final = _line - 1 ;

            int total_linhas = linha_final - linha_inicial + 1;

            int numero_de_imagens = (total_linhas / 4);

            int resto = total_linhas % 4 ;

            if( resto != 0 ) throw new ArgumentException("Em Controlador_imagem_de_fundo veio o formato errado de linhas");


            Controlador_background_plataforma controlador_background_plataforma = new Controlador_background_plataforma();

            

            
            controlador_background_plataforma.nomes_imagens = new string[numero_de_imagens];
            controlador_background_plataforma.paths_imagens = new string[numero_de_imagens];
            controlador_background_plataforma.posicoes_referencia = new float[numero_de_imagens][];
            controlador_background_plataforma.distancias_para_ativar = new float[numero_de_imagens];
            controlador_background_plataforma.distancia_para_ativar_quadrado = new float[ numero_de_imagens ];

            int index = 0;

            for(   int linha = linha_inicial ;  linha < linha_final  ;  linha+= 4   ){
                
                
                    controlador_background_plataforma.nomes_imagens[index] = _lines[ linha ].Trim();
                    controlador_background_plataforma.paths_imagens[index] = _lines[ linha + 1 ].Trim();

                    controlador_background_plataforma.posicoes_referencia[index] = new float[]{0f,0f};

                    string[] posicao_referencia_str = _lines[ linha + 2 ].Trim().Split(",");
                    
                    controlador_background_plataforma.posicoes_referencia[index][0] = Convert.ToSingle( posicao_referencia_str[0].Trim()   );
                    controlador_background_plataforma.posicoes_referencia[index][1] = Convert.ToSingle( posicao_referencia_str[1].Trim()   );
                    
                    float distancia_para_ativar = Convert.ToSingle(    _lines[linha + 3].Trim()   );

                    controlador_background_plataforma.distancias_para_ativar[index] = distancia_para_ativar;
                    
                    controlador_background_plataforma.distancia_para_ativar_quadrado [ index ] = distancia_para_ativar * distancia_para_ativar;

                    index++;


            }

    
            plataforma.controlador_background_plataforma = controlador_background_plataforma;



        }


        public static  void Pegar_terrenos(  ref int _line , string[] _lines ){

            
            BLOCO_plataforma plataforma = BLOCO_plataforma.Pegar_instancia();


             _line++;

             trava_seguranca = 0;

                Terreno[] terrenos = new Terreno[200];

                int t = -1; 
                string terreno_name;
                string[] posicao = null;
                string args = null;
                float x = 0f;  
                float y = 0f;


                while( true ){

                        Verificar_trava();

                        if(_lines[_line] == "//END_TERRENOS"){break;}


                        terreno_name = _lines[_line];
                        t++;
                        _line++;

                        terrenos[t] = new Terreno(t);

                        posicao = _lines[_line].Split(",",3);
                        args = null;
                        if(posicao.Length > 2) args = posicao[2];

                        _line++;

                        x = Convert.ToSingle(posicao[0]);
                        y = Convert.ToSingle(posicao[1]);

                        Achar_terreno(  terreno_name , terrenos[t]  , ref x  , ref y, args);

                }


        
                plataforma.terrenos_in_world =  new Terreno[t + 1];
                Array.Copy(terrenos, plataforma.terrenos_in_world , t + 1 );



        }


        public static  void Pegar_mobs(  ref int _line , string[] _lines ){


                trava_seguranca = 0;

                BLOCO_plataforma plataforma = BLOCO_plataforma.Pegar_instancia();

                Mob[] mobs = new Mob[200]; 

                int i = -1; 
                string mob_name;
                string[] posicao = new string[2];
                float x = 0f;
                float y = 0f;

                _line++;

                while( true ){

                        Verificar_trava();


                        if(_lines[_line] == "//END_MOBS") {break;}

                        
                        mob_name = _lines[_line];
                        i++;
                        _line++;



                        mobs[i] = new Mob(i);
                        string[] args = _lines[ _line ].Split(",", 3);
                        
                        _line++;

                        x = Convert.ToSingle( args[0] );
                        y = Convert.ToSingle( args[1] );


                        Achar_mob(  mob_name , mobs[i]  , x  , y , args);

                }



                
                plataforma.mobs_in_world =  new Mob[i + 1 ];
                Array.Copy(mobs, plataforma.mobs_in_world , i + 1);

            


        }




        public static  void Achar_terreno( string _terreno_name , Terreno _terreno , ref float _x, ref float _y, string _args){

            

                switch(_terreno_name){

                
                        case "grama_01" :  TERRENO_grama.Grama_01(_terreno  ,  _x  ,  _y  ); break;
                        case "grama_02" :  TERRENO_grama.Grama_02(_terreno  ,  _x  ,  _y  ); break;

                        case "arvore_1" : TERRENO_arvores.Arvore_1(_terreno  ,  _x  ,  _y); break;

                        case "bloco": BLOCOS.bloco_simples(_terreno, _x, _y, _args);break;
                        
                        default: throw new ArgumentException("nao foi achado mob, veio: " + _terreno_name );



                }
                

                _terreno.terreno_game_object.transform.SetParent( BLOCO_plataforma.Pegar_instancia().meio_p_3.transform  ,false );

                _terreno.terreno_game_object.transform.localPosition = new Vector3( _terreno.fisica.position[0], _terreno.fisica.position[1], 0f);

                RectTransform rect = _terreno.terreno_game_object.GetComponent<RectTransform>();

                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal  ,   _terreno.fisica.image_dimensions[0]);
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical  ,   _terreno.fisica.image_dimensions[1]);

                _terreno.terreno_game_object.SetActive(false);

                return;


        }









        
        
        public static  void Achar_mob( string _mob_name , Mob _mob , float _x, float _y, string[] _args){

                

                switch(_mob_name){

                
                    case "albuin" :  MOB_albuin.Construir(_mob  ,  _x  ,  _y , _args); break;
                    default: throw new ArgumentException("nao foi achado mob, veio: " + _mob_name );


                }

                
                _mob.mob_game_object.transform.SetParent( BLOCO_plataforma.Pegar_instancia().meio_p_2.transform  ,false );

                _mob.mob_game_object.transform.localPosition = new Vector3( _mob.fisica.position[0], _mob.fisica.position[1], 0f);

                RectTransform rect = _mob.mob_game_object.GetComponent<RectTransform>();

                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal  ,   _mob.fisica.dimensions[0]);
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical  ,   _mob.fisica.dimensions[1]);

                _mob.mob_game_object.SetActive(false);

                return;


            }




}