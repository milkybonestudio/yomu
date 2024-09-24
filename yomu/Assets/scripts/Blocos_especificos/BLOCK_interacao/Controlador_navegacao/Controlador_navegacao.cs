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


        // ** logica : local sempre carrega todas as areas
        //           movimento tem 2 tipos: movimento interno e movimento externo
        //           movimento interno esta na mesma area 
        //           movimento externo tem que carregar o local em que o player vai ir




        public Ponto[ /*zona*/ ][ /*local*/ ][ /*area*/ ][ /*pontos*/ ] pontos_cidade_primaria;

        public Gerenciador_dados_pontos gerenciador_dados_pontos;

        

        public static Controlador_navegacao Construir( Dados_sistema_estado_atual _dados_sistema_estado_atual ){

                Controlador_navegacao controlador = new Controlador_navegacao();

                        controlador.gerenciador_dados_pontos = new Gerenciador_dados_pontos();
                        controlador.pontos_cidade_primaria = Tradutor_pontos_estado_atual.Descompactar_pontos( _dados_sistema_estado_atual.dados_pontos_compactados, controlador.gerenciador_dados_pontos );

                        //Controlador_interativos.Pegar_instancia().Pegar_interativos_tela_pontos_iniciais( pontos_cidade_primaria. controlador. );
                        
                instancia = controlador;
                return instancia;

        }


        public Ponto Construir_ponto( Locator_position _posicao ){

                Ponto ponto = new Ponto();

                return ponto;

                //ponto.

                // *** o Leitor_interativos sempre tem que ter os interativos que o sistema pode precisar

                // dados_pontos_brutos  =>   interativos default/sub/add
                //                      =>   imagens_forcadas 
                //                      =>   scripts 


                // ** pegar dados dinamicos 

                // gerenciador imagens + leitor 
                // leitor => carrega todos os dados previamente e entrega conforme é pedido 
                // gerenciador => cerrega dados e pode modificar os dados

        }







        public Ponto Pegar_ponto( Locator_position _posicao ){

                // --- VERIFICAR
                
                #if UNITY_EDITOR && true
                        Verificador_navegacao_DEVELOPMENT.Verificar_ponto_para_pegar( pontos_cidade_primaria, _posicao );
                #endif

                return null;

                //return pontos_cidade_primaria[ _posicao.zona_id ][ _posicao.local_id ][ _posicao.area_id][ _posicao.ponto_id ];
                
        }




}

