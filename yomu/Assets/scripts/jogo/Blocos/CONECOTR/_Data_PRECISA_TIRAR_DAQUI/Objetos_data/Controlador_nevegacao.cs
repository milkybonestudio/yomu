using System;
using UnityEngine;


public class Controlador_navegacao {

        // ** todos os pontos de uma cidade vão ser calculados na troca de periodo 
        // vai ter uma breve momento que o ponteiro vai se movimentar 
        // talvez a tela vai ficar brevemente escura para resaltar o relogio e ele vai mover 
        // neeses 1000ms calcular todos os pontos assim como sprites dos pontos aos arredores 



        public static Controlador_navegacao instancia;
        public static Controlador_navegacao Pegar_instancia(){ return instancia; }


        public Cidade cidade_atual_player;

        

        public BLOCO_conector bloco_conector;

        public int cidade_atual_id;

        public int[][] posicoes_personagens; 

        // posicao 
        // public Ponto[ regiao ][ area ][ ponto ];
        public Ponto[][][] pontos_localizador;

        public int[] pontos_ids_dos_pontos_conectados;
        public Posicao_local[][] pontos_conectados;

        // nao sei quem vai ficar responsavel por eles ainda 
        // por hora nao alterar
        public int[][] posicoes_itens = new int[ 0 ][];


        public static Controlador_navegacao Construir( Dados_sistema_estado_atual _dados_sistema_estado_atual ){

                Controlador_navegacao controlador = new Controlador_navegacao();

                    controlador.bloco_conector = BLOCO_conector.Pegar_instancia();
                    // controlador.interativos_para_acrescentar_ids  = _dados_sistema_estado_atual.interativos_para_adicionar_ids;
                    // controlador.interativos_para_subtrair_ids  = _dados_sistema_estado_atual.interativos_para_subtrair_ids;

                instancia = controlador;
                return instancia;

        }




        public Ponto Mover_player( Posicao_local _posicao ){ return null; }

        public Ponto Criar_ponto(){ return null; }



}





/*


        controlador_navegacao => auxilia na movimentacao e entrega dados para a AI

        controlador_movimento => movimenta personagens e verifca scripts 

        controlador_interativos => ativa interativos e cria interativos 

                                            => personagens 
                                            => tela 
                                            => itens 
        



*/








