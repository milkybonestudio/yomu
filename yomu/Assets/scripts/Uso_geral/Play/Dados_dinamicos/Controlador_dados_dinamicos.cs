using UnityEngine;
using System;



public class Controlador_dados_dinamicos{


        public static Controlador_dados_dinamicos instancia;
        public static Controlador_dados_dinamicos Pegar_instancia(){ return instancia; }


        public static Controlador_dados_dinamicos Construir(){ 
                
                
                Controlador_dados_dinamicos controlador = new Controlador_dados_dinamicos(); 


                        controlador.lista_navegacao = new Lista_navegacao();
                        controlador.tradutor_save_dinamico = new Tradutor_save_dinamico();

                        controlador.dados_dinamicos_personagens = new Dados_dinamicos_personagens();
                        // controlador.dados_dinamicos_cidades = new Dados_dinamicos_cidades();
                        // controlador.dados_dinamicos_plots = new Dados_dinamicos_plots();


                instancia = controlador; 
                return instancia;
                
        }



        public Lista_navegacao lista_navegacao;
        public Tradutor_save_dinamico tradutor_save_dinamico ;


        public Dados_dinamicos_personagens dados_dinamicos_personagens;
        // public Dados_dinamicos_cidades dados_dinamicos_cidades;
        // public Dados_dinamicos_plots dados_dinamicos_plots;
    
    

        public void Zerar(){

                instancia = null;
        }



    public static void Mudar_interativos_para_acrescentar(  Ponto_nome _ponto_nome , int[] _slots,  Interativo_nome[] _interativos  ){

            instancia.lista_navegacao.Mudar_interativos_para_acrescentar(_ponto_nome ,_slots, _interativos);
            return;
            
    }



}