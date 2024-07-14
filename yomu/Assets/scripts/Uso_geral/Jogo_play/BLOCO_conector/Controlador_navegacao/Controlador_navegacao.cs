using System;
using UnityEngine;
using UnityEngine.Assertions.Must;

// criado quando o save é instanciado
public class Controlador_navegacao {

        // --- RESPONSAVEL SOMENTE PELA CIDADE DO PRIMEIRO PLANO 

        // ** todos os pontos de uma cidade vão ser calculados na troca de periodo 
        // vai ter uma breve momento que o ponteiro vai se movimentar 
        // talvez a tela vai ficar brevemente escura para resaltar o relogio e ele vai mover 
        // neeses 1000ms calcular todos os pontos assim como sprites dos pontos aos arredores 

        // nara e lala podem se mover para posicoes diferentes mas sempre tem que estar na mesma cidade 


        public static Controlador_navegacao instancia;
        public static Controlador_navegacao Pegar_instancia(){ return instancia; }


        public Cidade cidade_atual_player;
        public int cidade_atual_id; // ( regiao, trecho, id )


        public Ponto[ /*zona*/ ][ /*local*/ ][ /*area*/ ][ /*pontos*/ ] pontos_cidade_primaria;

        // o id do interativo aqui nao vai fazer muito sentido ser int. vai gastar muito espaço.

        public byte [ /*zona*/ ][ /*local*/ ][ /*area*/ ][ /*pontos*/ ][ /*periodos*/ ][/*interativos*/] interativos_para_acrescentar_ids_em_cada_posicao;
        public byte [ /*zona*/ ][ /*local*/ ][ /*area*/ ][ /*pontos*/ ][ /*periodos*/ ][ /*interativos*/ ] interativos_para_subtrair_ids_em_cada_posicao;


        public static Controlador_navegacao Construir( Dados_sistema_estado_atual _dados_sistema_estado_atual ){

                Controlador_navegacao controlador = new Controlador_navegacao();

                    controlador.interativos_para_acrescentar_ids_em_cada_posicao  = _dados_sistema_estado_atual.interativos_para_adicionar_ids;
                    controlador.interativos_para_subtrair_ids_em_cada_posicao  = _dados_sistema_estado_atual.interativos_para_subtrair_ids;
                    Manipulador_interativos.controlador_navegacao = controlador;

                instancia = controlador;
                return instancia;

        }

        public Ponto Pegar_ponto( Posicao _posicao ){

                // --- VERIFICAR
                
                #if UNITY_EDITOR && true
                        Verificador_navegacao_DEVELOPMENT.Verificar_ponto_para_pegar( pontos_cidade_primaria, _posicao );
                #endif

                return pontos_cidade_primaria[ _posicao.zona_id ][ _posicao.local_id ][ _posicao.area_id][ _posicao.ponto_id ];
                
        }





        public Ponto Modificar_interativos(  Tipo_modificar_interativo _tipo, Ponto _ponto,  int[][] _interativos_para_modificar ){


                // switch( _tipo ){

                //         case Tipo_modificar_interativo.acrescentar_para_adicionar:  

                // }


                return _ponto;

                // switch( _tipo ){

                //         //case Tipo_modificar_interativo.acrescentar_para_adicionar: Manipulador_interativos.Acrescentar_interativos_para_adicionar(  );

                // }

        }


}

public enum Tipo_modificar_interativo {

        acrescentar_para_adicionar,
        remover_para_adicionar,

        acrescentar_para_subtrair,
        remover_para_subtrair,

}


/*

        controlador_navegacao => auxilia na movimentacao e entrega dados para a AI
        controlador_movimento => movimenta personagens e verifca scripts 
        controlador_interativos => ativa interativos e cria interativos 

                                            => personagens 
                                            => tela 
                                            => itens 
        
*/


