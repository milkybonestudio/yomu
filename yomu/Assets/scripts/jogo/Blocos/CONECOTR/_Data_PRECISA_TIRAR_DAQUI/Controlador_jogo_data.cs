
using System;
using UnityEngine;



public class Controlador_jogo_data {



      
        public static Controlador_jogo_data instancia;
        public static Controlador_jogo_data Pegar_instancia(){ return instancia; }
        public static Controlador_jogo_data Construir(){ instancia = new Controlador_jogo_data(); return instancia;}



    //public Interativo[] lista_interativos;
    //public Pontos_data_lista pontos_data_lista;



    public void Iniciar(){


        // lista_interativos = Lista_interativos.Iniciar();
        // pontos_data_lista = Pontos_data_lista.Pegar_instancia( true );
   
    }




     public static Ponto Criar_ponto(  Ponto_nome _ponto_nome ){

        return null;


        // Ponto_data ponto_data =  Pontos_data_lista.Pegar_ponto_data( _ponto_nome );

        // Ponto ponto_retorno = new Ponto();
        // ponto_retorno.ponto_nome = _ponto_nome ;
        // ponto_retorno.folder_path = ponto_data.folder_path;

        // int _id  = (int) _ponto_nome;

        
        // Periodo_tempo periodo = ( Periodo_tempo ) Controlador_timer.Pegar_instancia().periodo_atual_id;

        // int periodo_int = (int) periodo;





        
        // if( ponto_data.tipo_get_background == Tipo_get_ponto_data.all ){

        //         string background_variante = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.Pegar_background_para_substituir(  _ponto_nome ,  periodo );


        //         if(background_variante != null) {

        //                 ponto_retorno.background_name = background_variante;

        //         } else {

        //                 ponto_retorno.background_name  =  ponto_data.background_default_name + "_" + Convert.ToString(   periodo );

        //         }
            

        // } else 

        // if( ponto_data.tipo_get_background == Tipo_get_ponto_data.dia_E_noite ){

        //         Periodo_tempo dia_ou_noite = Periodo_tempo.manha; // 0
        //         if( periodo_int > 2 ) { dia_ou_noite = Periodo_tempo.dia ; }// 1


        //         string background_variante = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.Pegar_background_para_substituir(  _ponto_nome,  dia_ou_noite);
                
        //         if(background_variante != null) {

        //                 ponto_retorno.background_name = background_variante;

        //         } else{
                        
        //                 if( dia_ou_noite == 0 ) {

        //                         ponto_retorno.background_name  =  ponto_data.background_default_name + "_d";

        //                 } else {

        //                         ponto_retorno.background_name  =  ponto_data.background_default_name + "_n";
        //                 }

        //         }
            

        // } else

        // if(ponto_data.tipo_get_background == Tipo_get_ponto_data.nao_altera) {
                

        //         string background_variante = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.Pegar_background_para_substituir(  _ponto_nome ,  Periodo_tempo.manha  );
        //         Debug.Log("background variante: " + background_variante);
                
        //         if(background_variante != null) {

        //                 ponto_retorno.background_name = background_variante;

        //         } else{

        //                 ponto_retorno.background_name  =  ponto_data.background_default_name;

        //         }

        // } 

        // else {

        //         string background_variante = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.Pegar_background_para_substituir(  _ponto_nome ,  0);
                
        //         if(background_variante != null) {

        //                 ponto_retorno.background_name = background_variante;

        //         } else{

        //                 ponto_retorno.background_name = Ponto_data.Pegar_nome_background_por_script( _ponto_nome );
        //                 //ponto_retorno.background_name = Ponto.Pegar_nome_background_por_script( _ponto_nome );

        //         }



        // }

          
        // Interativo_nome[] interativos_default = new Interativo_nome[0];
        // Interativo_nome[] acrescentar = new Interativo_nome[0];
        // Interativo_nome[] subtrair = new Interativo_nome[0];

        // Interativo_nome[] interativos_finais = null;

        // int MAX_SLOTS = 0;
        // int slot = 0;


        
        // if(  ponto_data.tipo_get_interativos_default == Tipo_get_ponto_data.all  ){
                                
        //         interativos_default =  ponto_data.interativos_default_2d[periodo_int];
        //         MAX_SLOTS = 5;

                
        // } else 

        // if(ponto_data.tipo_get_interativos_default == Tipo_get_ponto_data.dia_E_noite){

        //         MAX_SLOTS = 2;
        //         slot = 1;
        //         if( periodo_int  < 3 ) {  slot = 0; } 
                
        // } 

        // else if(ponto_data.tipo_get_interativos_default == Tipo_get_ponto_data.nao_altera) {

        //         MAX_SLOTS = 1;
        //         slot = 0;
        // } 
        


        // if(ponto_data.tipo_get_interativos_default == Tipo_get_ponto_data.script) {
            
        //     //  script
        //     // default vai retornar já os finais 

        //         interativos_finais = Ponto_data.Pegar_interativos_por_script( _ponto_nome );

        // }  else {

        //         interativos_default =  ponto_data.interativos_default_2d[ slot ];
        //         acrescentar = Controlador_dados_dinamicos.Pegar_instancia(). lista_navegacao.Pegar_interativos_para_acrescentar(_ponto_nome , slot, MAX_SLOTS);
                
        //         subtrair = Controlador_dados_dinamicos.Pegar_instancia(). lista_navegacao.Pegar_interativos_para_subtrair(_ponto_nome , slot , MAX_SLOTS);

        //         interativos_finais = Mat.Calcular_array_generico_enum<Interativo_nome>( interativos_default,subtrair, acrescentar );

        // }


        
        // ponto_retorno.interativos_nomes =  interativos_finais;


        // return ponto_retorno;
        

    }




}