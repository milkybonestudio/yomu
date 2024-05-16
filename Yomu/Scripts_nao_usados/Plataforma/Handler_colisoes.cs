using System;
using UnityEngine;




public static class Handler_colisoes{


        public static BLOCO_plataforma plataforma;



        public static void Verificar_objetos(){



                //  optimizar depois
                /*
                *    nao precisa checar todos os objetos, somente aqueles que estao visiveis 
                */


                int numero_mobs = plataforma.mobs_in_world.Length;
                int numero_terreno = plataforma.terrenos_in_world.Length;
                int numero_projeteis = plataforma.projeteis_arr.Length;

                int ciclos = numero_mobs + numero_terreno + numero_projeteis + 1 ;



        
                for(  int  i = 0   ; i  < ciclos    ;  i++  ){

                        //     tipo       poligono    ||    retangulo     default(rect)


        
                        Fisica_objeto objeto_foco_fisica = null;
                        Stats_objeto  objeto_foco_stats = null;

                        /*
                        Fisica_objeto objeto_secundario_fisica = null;
                        Stats_objeto  objeto_secundario_stats = null;

                        */

            

                        if(i<1){  
                                
                                objeto_foco_fisica = plataforma.controlador_player.player_atual.fisica ; 
                                objeto_foco_stats = plataforma.controlador_player.player_atual.stats;
                                
                        } else

                        if(i< 1 + numero_mobs){  

                                if(plataforma.mobs_in_world[i-1].stats.is_inativo) {continue;}
                                if(plataforma.mobs_in_world[i-1].stats.is_destruido) {continue;}

                                objeto_foco_fisica = plataforma.mobs_in_world[i-1].fisica;
                                objeto_foco_stats = plataforma.mobs_in_world[i-1].stats;

                        } else

                        if(i< 1 + numero_terreno + numero_mobs){ 

                                
                                if(plataforma.terrenos_in_world[i-1-numero_mobs].stats.is_inativo) {continue;}
                                if(plataforma.terrenos_in_world[i-1-numero_mobs].stats.is_destruido) {continue;}
                                objeto_foco_fisica = plataforma.terrenos_in_world[i-1-numero_mobs].fisica ;
                                objeto_foco_stats = plataforma.terrenos_in_world[i-1-numero_mobs].stats;   
                                
                        } else 

                        if(i< 1 + numero_terreno + numero_mobs + numero_projeteis){ 

                                
                                if(plataforma.projeteis_arr[i-1-numero_mobs - numero_terreno] == null) continue;

                                objeto_foco_fisica = plataforma.projeteis_arr[i-1-numero_mobs - numero_terreno].fisica;

                                objeto_foco_stats = plataforma.projeteis_arr[i-1-numero_mobs-numero_terreno].stats;    

                        }


                       



                
                        for(  int m_ =  i ; m_  < numero_mobs ; m_ ++){ 

                                 

                                if(plataforma.mobs_in_world[m_].stats.is_inativo) {continue;}
                                if(plataforma.mobs_in_world[m_].stats.is_destruido) {continue;}
                                
                                

                
                                if(   Mat.Verificar_colisao_retangulos( objeto_foco_fisica.project_pontos , plataforma.mobs_in_world[m_].fisica.project_pontos )   ) {
                                    
                                        Verificar(objeto_foco_fisica,  objeto_foco_stats,  plataforma. mobs_in_world[m_].fisica  ,  plataforma.mobs_in_world[m_].stats);

                                }
                            
                        }
                                
                        int k = 0;

                        if(  numero_mobs  < i ){ k = i-numero_mobs;} 

                    
                        for(  int t_ =  k ; t_  < numero_terreno ; t_ ++){

                                if(plataforma.terrenos_in_world[t_].stats.is_inativo) {continue;}
                                if(plataforma.terrenos_in_world[t_].stats.is_destruido) {continue;}

                                

                        
                                if(   Mat.Verificar_colisao_retangulos( objeto_foco_fisica.project_pontos , plataforma.terrenos_in_world[t_].fisica.project_pontos )      ) {

                                        

                                        Verificar(objeto_foco_fisica,  objeto_foco_stats,  plataforma.terrenos_in_world[t_].fisica  , plataforma.terrenos_in_world[t_].stats);

                                }

                        }



                        int p = 0; 

                        if(  i > numero_mobs  + numero_terreno  ) {p = i-numero_mobs - numero_terreno; }

                    
                        for(  int p_ =  p ; p_ < numero_projeteis ; p_ ++){

                                if(plataforma.projeteis_arr[p_] == null) continue;
                        
                            
                                if(   Mat.Verificar_colisao_retangulos( objeto_foco_fisica.project_pontos , plataforma.projeteis_arr[p_].fisica.project_pontos )      ) {

                                        Verificar(objeto_foco_fisica,  objeto_foco_stats,  plataforma.projeteis_arr[p_].fisica  , plataforma.projeteis_arr[p_].stats);

                                }

                        }

                }

        }



















        public static  void Verificar_objeto_especifico(Fisica_objeto _fisica, Stats_objeto _stats){

                return;



                
                // int numero_mobs = plataforma.mobs_in_world.Length;
                // int numero_terreno = plataforma.terrenos_in_world.Length;
                // int numero_projeteis = plataforma.projeteis_arr.Length;



                             
                // if(_fisica.tipo == Tipo_objeto.mob){

                //         for(  int m_ =  0 ; m_  < numero_mobs; m_ ++){ 

                //                 if(m_ == _fisica.id){ continue;}

                //                 if(   Mat.Verificar_colisao_retangulos( _fisica , plataforma.mobs_in_world[m_].fisica )   ) {Verificar(_fisica,  _stats,  plataforma. mobs_in_world[m_].fisica  ,  plataforma.mobs_in_world[m_].stats);}
                            
                //         }

                // }


                // else {

                //         for(  int m_ =  0 ; m_  < numero_mobs ; m_ ++){ 

                //                 if(   Mat.Verificar_colisao_retangulos( _fisica , plataforma.mobs_in_world[m_].fisica )   ) {Verificar(_fisica,  _stats,  plataforma. mobs_in_world[m_].fisica  ,  plataforma.mobs_in_world[m_].stats);}
                            
                //         }
  
                // }


                // if(_fisica.tipo == Tipo_objeto.terreno){


                //         for(  int t_ =  0 ; t_  < numero_terreno ; t_ ++){

                //                 if( t_ == _fisica.id ) {continue;}
                
                //                 if(   Mat.Verificar_colisao_retangulos( _fisica , plataforma.terrenos_in_world[t_].fisica )      ) {

                //                         Verificar(_fisica,  _stats,  plataforma.terrenos_in_world[t_].fisica  , plataforma.terrenos_in_world[t_].stats);

                //                 }

                //         }


                // }

                // else{

                        
                //         for(  int t_ =  0 ; t_  < numero_terreno ; t_ ++){


                //                 if(   Mat.Verificar_colisao_retangulos( _fisica , plataforma.terrenos_in_world[t_].fisica )      ) {

                //                         Verificar(_fisica,  _stats,  plataforma.terrenos_in_world[t_].fisica  , plataforma.terrenos_in_world[t_].stats);

                //                 }

                //         }

                // }



                // if(_fisica.tipo == Tipo_objeto.projetil){


                //         for(  int p_ =  0 ; p_ < numero_projeteis ; p_ ++){

                //                 if(plataforma.projeteis_arr[p_] == null ||  _fisica.id == p_ ) continue;
                                        
                //                 if(   Mat.Verificar_colisao_retangulos( _fisica , plataforma.projeteis_arr[p_].fisica )      ) {

                //                         Verificar(_fisica,  _stats,  plataforma.projeteis_arr[p_].fisica  , plataforma.projeteis_arr[p_].stats);

                //                 }

                //         }

                // }

                // else {

                //          for(  int p_ =  0 ; p_ < numero_projeteis ; p_ ++){

                //                 if(plataforma.projeteis_arr[p_] == null) continue;
                                        
                //                 if(   Mat.Verificar_colisao_retangulos( _fisica , plataforma.projeteis_arr[p_].fisica )      ) {

                //                         Verificar(_fisica,  _stats,  plataforma.projeteis_arr[p_].fisica  , plataforma.projeteis_arr[p_].stats);

                //                 }

                //         }

                // }




}










    public static void Verificar(    Fisica_objeto _obj_1_fisica    ,   Stats_objeto _obj_1_stats  ,  Fisica_objeto _obj_2_fisica    ,   Stats_objeto _obj_2_stats   ){

          if( _obj_1_stats.efeito_contato != null)  _obj_1_stats.efeito_contato(_obj_2_fisica, _obj_2_stats);
          if( _obj_2_stats.efeito_contato != null)  _obj_2_stats.efeito_contato(_obj_1_fisica, _obj_1_stats);






            //     conteudo   solido      ||    fluido          
            //     mov_type    fixo       ||    movel 

            // conteudo:  1 =  fluido (nao passa solido) ,  2 = solido  , 3 = super_fluido (passa solido)
            
            // mov_type  1 = fixo  ,  2 = movel
 
     
            conteudo conteudo_1 = _obj_1_fisica.conteudo;
            conteudo conteudo_2 = _obj_2_fisica.conteudo;


            mov_type mov_type_1 = _obj_1_fisica.mov_type;
            mov_type mov_type_2 = _obj_2_fisica.mov_type;

      
           

           if(mov_type_1 ==  mov_type.fixo   &&  mov_type_2  ==  mov_type.fixo  ){return;}




            if(mov_type_1 ==  mov_type.movel &&  mov_type_2  ==  mov_type.movel ){


               

            
                    //             npc  +  player contato  ||  npc + npc 
                    
                    if(   conteudo_1 ==  conteudo.fluido   &&   conteudo_2 == conteudo.fluido  ){
                        

                            if(_obj_1_stats.efeito_contato != null) {

                                
                                
                             //   _obj_1_stats.efeito_contato(_obj_2_fisica, _obj_2_stats);
                                
                                };
                            if(_obj_2_stats.efeito_contato != null) {

                                
                               // _obj_2_stats.efeito_contato(_obj_1_fisica, _obj_1_stats);
                               
                               };

                    }
                
                    return;
                
            }














            



            if(  mov_type_1 == mov_type.movel &&  mov_type_2  ==  mov_type.fixo   ) {

                    Aplicar_movel_AND_fixo_retangulo(_obj_1_fisica   ,_obj_1_stats ,   _obj_2_fisica, _obj_2_stats);
                    return;
            }


            if(  mov_type_1 == mov_type.fixo &&  mov_type_2  ==  mov_type.movel    ) {

                    Aplicar_movel_AND_fixo_retangulo(_obj_2_fisica, _obj_2_stats ,   _obj_1_fisica ,  _obj_1_stats );
                    return;
            }


            return;
    }



        public static void Aplicar_movel_AND_fixo_retangulo(Fisica_objeto _movel_fisica, Stats_objeto _movel_stats , Fisica_objeto _fixo_fisica , Stats_objeto _fixo_stats ){


                /*
                1   2

                4   3       
                */

                int ponto =   Mat.Calcular_ponto_entrada_retangulo( _movel_fisica.project_pontos , _fixo_fisica.project_pontos );
                float[] pontos_reta_entrada  = new float[4];
                int ponto_entrada; 
                int lado_entrada;



                //Debug.Log("primeiro ponto: " + ponto );
            



    

                if(  ponto<0 ){

                        // _fixo tem ponto dentro movel

                        // Debug.Log("_fixo tem ponto dentro movel");

                        ponto *= -1;
                    
                        ponto_entrada = (ponto - 1) * 2;


                        pontos_reta_entrada[0] = _fixo_fisica.pontos[ponto_entrada];
                        pontos_reta_entrada[1] = _fixo_fisica.pontos[ponto_entrada + 1];
                        pontos_reta_entrada[2] = _fixo_fisica.pontos[ponto_entrada]  +   _movel_fisica.project_pontos[ponto_entrada] -  _movel_fisica.pontos[ponto_entrada]  ;
                        pontos_reta_entrada[3] = _fixo_fisica.project_pontos[ponto_entrada + 1]   +      _movel_fisica.project_pontos[ponto_entrada + 1] -  _movel_fisica.pontos[ponto_entrada + 1]  ;

                    

                        lado_entrada = Mat.Pegar_lado_colidido_retangulo  (   pontos_reta_entrada  ,  _movel_fisica.project_pontos, ponto);

                        if(ponto == 1){

                                if(lado_entrada == 0)  lado_entrada = 1;
                                if(lado_entrada == 3)   lado_entrada = 2;

                        } else

                        if(ponto == 2){

                                if(lado_entrada == 0)  lado_entrada = 3;
                                if(lado_entrada == 1)  lado_entrada = 2;

                        } else

                        if(ponto == 3){

                                if(lado_entrada == 1)  lado_entrada = 0;
                                if(lado_entrada == 2)  lado_entrada = 3;

                        } else
                        
                        if(ponto == 4){

                                if(lado_entrada == 2)  lado_entrada = 1;
                                if(lado_entrada == 3)  lado_entrada = 0;

                        } 

                        lado_entrada =  Mathf.Abs(lado_entrada+2)%4;


                }  

                        else {
                        
                                // _movel tem ponto dentro fixo

                                ponto_entrada = (ponto - 1) * 2;

                                pontos_reta_entrada[0] = _movel_fisica.pontos[ponto_entrada];
                                pontos_reta_entrada[1] = _movel_fisica.pontos[ponto_entrada + 1];
                                pontos_reta_entrada[2] = _movel_fisica.project_pontos[ponto_entrada];
                                pontos_reta_entrada[3] = _movel_fisica.project_pontos[ponto_entrada + 1];
                            

                                lado_entrada = Mat.Pegar_lado_colidido_retangulo  (   pontos_reta_entrada  ,  _fixo_fisica.project_pontos, ponto);

                                //Debug.Log("lado entrada pre : " + lado_entrada);
                            
                                if(ponto == 1){

                                        if(lado_entrada == 0)  lado_entrada = 1;
                                        if(lado_entrada == 3)  lado_entrada = 2;

                                } else

                                if(ponto == 2){

                                        if(lado_entrada == 0)  lado_entrada = 3;
                                        if(lado_entrada == 1)  lado_entrada = 2;

                                } else

                                if(ponto == 3){

                                        if(lado_entrada == 1)  lado_entrada = 0;
                                        if(lado_entrada == 2)  lado_entrada = 3;

                                } else
                                
                                if(ponto == 4){

                                        if(lado_entrada == 2)  lado_entrada = 1;
                                        if(lado_entrada == 3)  lado_entrada = 0;

                                } 



                           //     Debug.Log("lado entrada pos  : " + lado_entrada);
                                

                        }




                // Debug//.Log("tipo movel: " + _movel_fisica.tipo );


                if(lado_entrada == 0){

                        //Debug.Log("lado de entrada: lado 0");

                        float dif =    _movel_fisica.project_position[1]  -  _movel_fisica.position[1]   ;
                
                        if(  Mathf.Abs(dif) <= 0.5f){


                                _movel_fisica.vectors_speed[1] = 0f ;
                                _movel_fisica.project_position[1] = _movel_fisica.position[1]; 
                                _movel_fisica.project_pontos = Mat.Transformar_dados_em_pontos(_movel_fisica.project_position, _movel_fisica.dimensions);

                                _movel_stats.jumps_possiveis_atuais = _movel_stats.jumps_possiveis;  
                                _movel_fisica.speed_collision_multiplier[1] = 0f;
                                Handler_colisoes.Verificar_objeto_especifico(_movel_fisica, _movel_stats);

                                return ;
                        }


                        float dentro = _movel_fisica.project_position[1] ;
                        float fora = _movel_fisica.position[1];
                        float var_atual = 0.5f;
                        float acumulador = 0.5f;
                        float delta_x = _movel_fisica.project_position[0] -  _movel_fisica.position[0]  ;
                        int trava_seguranca = 0;
                        bool ver = false;

                        while(   Mathf.Abs(dentro - fora ) > 0.5f ){
                            
                                
                
                                if(trava_seguranca > 50) throw new ArgumentException("problema");

                                trava_seguranca++;
                                var_atual *= 0.5f;
                                ver = Mat.Verificar_colisao_retangulos_com_variacao_mov(  _movel_fisica.pontos,  delta_x  ,   ( dif *  acumulador)   ,_fixo_fisica.pontos );

                                
                                if( ver) {

                                        dentro = _movel_fisica.position[1]  + ( dif *  acumulador);
                                        acumulador -= var_atual;

                                } 
                                else {

                                        fora =  _movel_fisica.position[1]  + ( dif *  acumulador);
                                        acumulador += var_atual;

                                };

                                continue;

                        }
                        
                        _movel_fisica.vectors_speed[1] = 0f ;
                        _movel_fisica.project_position[1] = fora;
                        _movel_fisica.project_pontos = Mat.Transformar_dados_em_pontos(_movel_fisica.project_position, _movel_fisica.dimensions);
                        _movel_stats.jumps_possiveis_atuais = _movel_stats.jumps_possiveis;
                        _movel_fisica.speed_collision_multiplier[1] = 0f;
                        Handler_colisoes.Verificar_objeto_especifico(_movel_fisica, _movel_stats);
                        return;

                    }

                    if( lado_entrada == 1 ||  lado_entrada == 3  ) {

                                //Debug.Log( "lado de entrada: lado 1 ou 3" );

                                /// de algum jeito funcionou

                                //Debug.Log(  "K: " +   ( _movel_fisica.project_position[0]  * _movel_fisica.project_position[1] ) );


                        
                                if(     _movel_fisica.project_position[0]  * _movel_fisica.project_position[1]  != 0f    ) { 


                                        float speed_sq = _movel_fisica.project_position[0] * _movel_fisica.project_position[0] + _movel_fisica.project_position[1] * _movel_fisica.project_position[1];

                                        float max_speed = 10f;
                                
                                        float rat = _movel_fisica.project_position[0] / _movel_fisica.project_position[1];

                                        if(rat < 0f ) rat *= -1f;

                                        float MAX = 5f;

                                       // Debug.Log("rat: " + rat );

                                        if(rat > MAX){

                                                float dif_a = _movel_fisica.project_position[0] -  _movel_fisica.position[0];

                                                bool ainda_encosta = Mat.Verificar_colisao_retangulos_com_variacao_mov(  _movel_fisica.pontos,    dif_a   ,  0f   ,_fixo_fisica.pontos );

                                                // Mat.Verificar_colisao_retangulos_com_variacao_mov(  _movel_fisica.pontos,    0f   ,  0f   ,_fixo_fisica.pontos ) => encosta por definicao

                                                        // Debug.Log("--------------INICIO----------------");

                                                        // Debug.Log("movel: ");
                                                        // Debug.Log( "p1: " + _movel_fisica.pontos[ 0 ] + ", " + _movel_fisica.pontos[ 1 ]  );
                                                        // Debug.Log( "p2: " + _movel_fisica.pontos[ 2 ] + ", " + _movel_fisica.pontos[ 3 ]  );
                                                        // Debug.Log( "p3: " + _movel_fisica.pontos[ 4 ] + ", " + _movel_fisica.pontos[ 5 ]  );
                                                        // Debug.Log( "p4: " + _movel_fisica.pontos[ 6 ] + ", " + _movel_fisica.pontos[ 7 ]  );
                                                        
                                                        // Debug.Log("----------------");

                                                        // Debug.Log("fixo: ");
                                                        // Debug.Log( "p1: " + _fixo_fisica.pontos[ 0 ] + ", " + _fixo_fisica.pontos[ 1 ]  );
                                                        // Debug.Log( "p2: " + _fixo_fisica.pontos[ 2 ] + ", " + _fixo_fisica.pontos[ 3 ]  );
                                                        // Debug.Log( "p3: " + _fixo_fisica.pontos[ 4 ] + ", " + _fixo_fisica.pontos[ 5 ]  );
                                                        // Debug.Log( "p4: " + _fixo_fisica.pontos[ 6 ] + ", " + _fixo_fisica.pontos[ 7 ]  );

                                                        // Debug.Log("----------------");

                                                        // Debug.Log("dif: " + dif_a) ;
                                                        


                                                        // Debug.Log("--------------FINAL----------------");
                                                        // Debug.Log("ainda encosta: " + ainda_encosta );


                                                if(  !ainda_encosta  )  {



                                                        // Debug.Log("handler caso especifico");

                                                        _movel_fisica.project_position[1] = _movel_fisica.position[1];

                                                        _movel_fisica.project_pontos = Mat.Transformar_dados_em_pontos(_movel_fisica.project_position, _movel_fisica.dimensions);


                                                        return;

                                                }

                                                
                                        }


                                }
                        
                  



                    


                            float dif =  _movel_fisica.project_position[0] - _movel_fisica.position[0] ;
                    
                                

                            if(  Mathf.Abs(dif)  <= 0.5f ){


                                
                               
                                    _movel_fisica.vectors_speed[0] *= 0.78f ;
                                    _movel_fisica.speed_collision_multiplier[0] = 0f;
                                    Handler_colisoes.Verificar_objeto_especifico(_movel_fisica, _movel_stats);



                                    _movel_fisica.project_position[0] =  _movel_fisica.position[0];
                                    _movel_fisica.project_pontos = Mat.Transformar_dados_em_pontos(_movel_fisica.project_position, _movel_fisica.dimensions);
                                    

                                    // precisa mudar project



                                    //_movel_fisica.project_pontos = Mat.Transformar_dados_em_pontos(_movel_fisica.project_position, _movel_fisica.dimensions);

                                    
                        // if(_movel_fisica.tipo == Tipo_objeto.mob){
                                
                        //         Debug.Log("mob position final: " + _movel_fisica.position[0]);

                        // }

                                    return ;
                            }


                            float dentro = _movel_fisica.project_position[0];
                            float fora = _movel_fisica.position[0];
                            float var_atual = 0.5f;
                            float acumulador = 0.5f;
                            float delta_y = _movel_fisica.project_position[1]  -  _movel_fisica.position[1]  ;
                            int trava_seguranca = 0;
                            bool ver = false;

                            while(   Mathf.Abs(dentro - fora ) > 0.5f ){
                
                                    if(trava_seguranca > 50) throw new ArgumentException("problema");
                                    
                                    trava_seguranca++;
                                    var_atual *= 0.5f;
                                    ver = Mat.Verificar_colisao_retangulos_com_variacao_mov(  _movel_fisica.pontos,    dif *  acumulador   ,  delta_y   ,_fixo_fisica.pontos );

                                    if( ver) {

                                            dentro = _movel_fisica.position[0]  + (   dif *  acumulador);
                                            acumulador -= var_atual;

                                    } 

                                    else {

                                            fora =  _movel_fisica.position[0]  + (  dif *  acumulador);
                                            acumulador += var_atual;

                                    };

                                        // Debug.Log("trava_seguranca: " + trava_seguranca);
                                        // Debug.Log(  "delta_px: " +   (dentro - fora) );
                                        // Debug.Log("dentro: " + dentro);
                                        // Debug.Log("fora: " + fora);
                                        // Debug.Log("var_atual: " + var_atual);
                                        // Debug.Log("position: " + _movel_fisica.position[0]);
                                        // Debug.Log("valor calculado: " + ( _movel_fisica.position[0] +  (  dif *  acumulador ) ));              
                                        // Debug.Log("diferenca valor: " + ( dif *  acumulador ) );    
                                        
                                        // Debug.Log( "passou: " + ver);
                                        // Debug.Log("============");
                                        // Debug.Log( "ponto fixo: " + _fixo_fisica.pontos[1]);

                                    continue;

                        }

                        _movel_fisica.vectors_speed[0] = 0f ;
                        _movel_fisica.project_position[0] = fora; 
                        _movel_fisica.project_pontos = Mat.Transformar_dados_em_pontos(_movel_fisica.project_position, _movel_fisica.dimensions);
                        _movel_fisica.speed_collision_multiplier[0] = 0f;
                       // Handler_colisoes.Verificar_objeto_especifico(_movel_fisica, _movel_stats);
                        return;


                    }





                if( lado_entrada == 2 ){



                        /*   porque esta vindo aqui?  */



                         Debug.Log("lado de entrada: lado 2");

                        float dif =    _movel_fisica.project_position[1]  -  _movel_fisica.position[1]   ;
                
                        if(  Mathf.Abs(dif) <= 0.5f ) {


                                _movel_fisica.vectors_speed[1] = 0f ;
                                _movel_fisica.project_position[1] = _movel_fisica.position[1];
                           //     Debug.Log("dentro? : " + _movel_fisica.project_position[1]) ;
                                _movel_fisica.project_pontos = Mat.Transformar_dados_em_pontos(_movel_fisica.project_position, _movel_fisica.dimensions);
                                _movel_fisica.speed_collision_multiplier[1] = 0f;

                                Handler_colisoes.Verificar_objeto_especifico(_movel_fisica, _movel_stats);
                                return ;


                        }


                        float dentro = _movel_fisica.project_position[1] ;
                        float fora = _movel_fisica.position[1];
                        float var_atual = 0.5f;
                        float acumulador = 0.5f;
                        float delta_x = _movel_fisica.project_position[0] -  _movel_fisica.position[0]  ;
                        int trava_seguranca = 0;
                        bool ver = false;

                        while(   Mathf.Abs(dentro - fora ) > 0.5f ){
                        
                                if(trava_seguranca > 50) throw new ArgumentException("problema");

                                trava_seguranca++;
                                var_atual *= 0.5f;
                                ver = Mat.Verificar_colisao_retangulos_com_variacao_mov(  _movel_fisica.pontos,  delta_x  ,   ( dif *  acumulador)   ,_fixo_fisica.pontos );

                                if( ver) {

                                    dentro = _movel_fisica.position[1]  + ( dif *  acumulador);
                                    acumulador -= var_atual;

                                } 
                                else {

                                        fora =  _movel_fisica.position[1]  + ( dif *  acumulador);
                                        acumulador += var_atual;

                                };

                                continue;

                        }



                        
                        _movel_fisica.vectors_speed[1] = 0f ;
                        _movel_fisica.project_position[1] = fora;

                        Debug.Log("fora: " + fora ) ;

                        _movel_fisica.project_pontos = Mat.Transformar_dados_em_pontos(_movel_fisica.project_position, _movel_fisica.dimensions);
                        _movel_fisica.speed_collision_multiplier[1] = 0f;

                        Handler_colisoes.Verificar_objeto_especifico(_movel_fisica, _movel_stats);
                        return;

                    }


                    return;
                        
                    }






        public static void Verificar_objetos_perto_player(){


                float distancia = 4000f;
                float distancia_quadrado = distancia * distancia;    

                float px_1 = plataforma.controlador_player.player_atual.fisica.position[0];
                float py_1 = plataforma.controlador_player.player_atual.fisica.position[1];

                float px_f;
                float py_f;

                float[] arr;


                
                for(int m = 0;  m < plataforma.mobs_in_world.Length  ;m++){



                        if(plataforma.mobs_in_world[m].stats.is_destruido) continue;


                        //   depois fazer um arr de bool para nao ir até o SetActive toda vez


                        arr = plataforma.mobs_in_world[m].fisica.position;
                        px_f = arr[0] - px_1;
                        py_f = arr[1] - py_1;
                                                                
                        if ( (px_f * px_f ) + (py_f * py_f)  < distancia_quadrado ) {

                                if(plataforma.mobs_in_world[m].stats.is_inativo) continue;
                                
                                plataforma.mobs_in_world[m].stats.is_inativo = false;

                                plataforma.mobs_in_world[m].mob_game_object.SetActive(true);

                        } else {

                                if(!plataforma.mobs_in_world[m].stats.is_inativo) continue;

                                plataforma.mobs_in_world[m].stats.is_inativo = true;

                                plataforma.mobs_in_world[m].mob_game_object.SetActive(false);

                        }


                }




                for(int t = 0;  t < plataforma.terrenos_in_world.Length  ;t++){


                        if(plataforma.terrenos_in_world[t].stats.is_destruido) continue;

                        

                        arr = plataforma.terrenos_in_world[t].fisica.position;
                        px_f = arr[0] - px_1;
                        py_f = arr[1] - py_1;


                                                            
                        if ( (px_f * px_f ) + (py_f * py_f)  < distancia_quadrado  ) {
                        
                                   if(plataforma.terrenos_in_world[t].stats.is_inativo) continue;

                                plataforma.terrenos_in_world[t].stats.is_inativo = false;

                                

                                plataforma.terrenos_in_world[t].terreno_game_object.SetActive(true);


                        } else {

                               if(!plataforma.terrenos_in_world[t].stats.is_inativo) continue;

                                plataforma.terrenos_in_world[t].stats.is_inativo = true;

                                plataforma.terrenos_in_world[t].terreno_game_object.SetActive(false);

                        }


                }



        }





























}