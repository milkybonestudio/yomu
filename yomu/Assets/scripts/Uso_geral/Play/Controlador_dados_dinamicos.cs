using UnityEngine;
using System;



public class Controlador_dados_dinamicos{


        public static Controlador_dados_dinamicos instancia;
        public static Controlador_dados_dinamicos Pegar_instancia(){ return instancia; }


        public static Controlador_dados_dinamicos Construir(){ 
                
                
                Controlador_dados_dinamicos controlador = new Controlador_dados_dinamicos(); 


                        controlador.dados_run_time = new Dados_run_time();
                        controlador.lista_navegacao = new Lista_navegacao();
                        controlador.tradutor_save_dinamico = new Tradutor_save_dinamico();


                instancia = controlador; 
                return instancia;}



    public Lista_navegacao lista_navegacao;
    public Dados_run_time dados_run_time;
    public Tradutor_save_dinamico tradutor_save_dinamico ;

    

    

    public void Zerar(){

        lista_navegacao.Zerar();

    }



    public static void Mudar_interativos_para_acrescentar(  Ponto_nome _ponto_nome , int[] _slots,  Interativo_nome[] _interativos  ){

            instancia.lista_navegacao.Mudar_interativos_para_acrescentar(_ponto_nome ,_slots, _interativos);
            return;
            
    }



}