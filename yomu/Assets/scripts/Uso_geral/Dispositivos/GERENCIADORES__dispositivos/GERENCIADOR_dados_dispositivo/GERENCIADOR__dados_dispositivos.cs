using System;
using UnityEngine;
using UnityEngine.UI;



public struct Dados_para_criar_botao_localizador_imagens {


        public int sprite_id;
        public object sprite_id_geral;
        public int length; // ** imagens gerais => 0 == id de sequencia, nunca pode iniciar a busca em 0 
        public Tipo_pegar_sprite tipo_pegar_sprite; 


}



public class GERENCIADOR__dados_dispositivo {

        // ** garante que os dados estejam corretos


        public GERENCIADOR__dados_dispositivo( Dispositivo _dispositivo ){

            dispositivo = _dispositivo;

            int numero_inicial_de_slots = 5;
                
            // --- DADOS
            dados_imagens_estaticas_dispositivo = new Dados_imagem_estatica_dispositivo[ numero_inicial_de_slots ];
            dados_botoes_dispositivo = new Dados_botao_dispositivo[ numero_inicial_de_slots ];

            // --- OBJETOS

            imagens_estaticas_dispositivo = new Imagem_estatica_dispositivo[ numero_inicial_de_slots ];
            botoes_dispositivo = new Botao_dispositivo[ numero_inicial_de_slots ];



        }

        public Dispositivo dispositivo;


        public string path_para_o_pai;
        public string path_para_o_dispositivo;


        // --- BOTAO
        public int pointer_atual_botao;
        public Dados_botao_dispositivo[] dados_botoes_dispositivo;
        public Botao_dispositivo[] botoes_dispositivo;

        // --- IMAGEM ESTATICA
        public int pointer_atual_imagem_estatica;
        public Imagem_estatica_dispositivo[] imagens_estaticas_dispositivo;
        public Dados_imagem_estatica_dispositivo[] dados_imagens_estaticas_dispositivo;





        public Imagem_estatica_dispositivo Definir_imagem_estatica( Dados_imagem_estatica_dispositivo _dados ){


                Imagem_estatica_dispositivo imagem = new Imagem_estatica_dispositivo();

                dados_imagens_estaticas_dispositivo[ pointer_atual_imagem_estatica ] = _dados;
                imagens_estaticas_dispositivo[ pointer_atual_imagem_estatica ] = imagem;
                pointer_atual_imagem_estatica++;
                

                if( dados_imagens_estaticas_dispositivo.Length == pointer_atual_imagem_estatica )
                    { 
                        Array.Resize( ref dados_imagens_estaticas_dispositivo, ( pointer_atual_imagem_estatica + 5 ) ); 
                        Array.Resize( ref imagens_estaticas_dispositivo, ( pointer_atual_imagem_estatica + 5 ) ); 
                    }
                

                // --- VERIFICACOES

                GERENCIADOR__dados_dispositivos_SUPORTE.Verificar_nome( dispositivo.nome_dispositivo, _dados.nome );
                
                
                // --- MUDAR DADOS 

                _dados.tipo_pegar_sprite = GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples( dispositivo.nome_dispositivo, _dados.nome, _dados.imagem_id, _dados.chaves, true );
                _dados.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default(  _dados.tipo_pegar_sprite, _dados.cor, Cores.white );

                

                return imagem;

        }







        public Botao_dispositivo Definir_botao( Dados_botao_dispositivo _dados ){


                // definir => criar os blocos de dados necessarios para carregar e ler os dados


                Botao_dispositivo botao = new Botao_dispositivo();

                _dados.nome_dispositivo = dispositivo.nome_dispositivo;
                dados_botoes_dispositivo[ pointer_atual_botao ] = _dados;
                botoes_dispositivo[ pointer_atual_botao ] = botao;
                pointer_atual_botao++;

                // --- VERIFICA SE TEM QUE AUMENTAR
                if( dados_botoes_dispositivo.Length == pointer_atual_botao )
                    { 
                        Array.Resize( ref dados_botoes_dispositivo, ( pointer_atual_botao + 5 ) ); 
                        Array.Resize( ref botoes_dispositivo, ( pointer_atual_botao + 5 ) ); 
                    }


                // --- VERIFICACOES

                GERENCIADOR__dados_dispositivos_SUPORTE.Verificar_nome( dispositivo.nome_dispositivo, _dados.nome );

                string indentificador = null;
                string nome_default = ( dispositivo.nome_dispositivo + "_BOTAO_" + _dados.nome );



                if( _dados.animacao_botao == null )
                    { return GERENCIADOR__dados_dispositivos_BOTAO.Construir_botao_simples( dispositivo,  _dados, botao, nome_default ); } // --- BOTAO SIMPLES

                return GERENCIADOR__dados_dispositivos_BOTAO.Construir_botao_completo( dispositivo,  _dados, botao, nome_default );



        }








        public void Construir_objetos(){

            // --- CRIA IMAGENS ESTATICAS

            for( int imagem_estatica_index = 0 ; imagem_estatica_index < dados_imagens_estaticas_dispositivo.Length ; imagem_estatica_index++ ){

                    if( dados_imagens_estaticas_dispositivo[ imagem_estatica_index ] == null )
                        { continue; }

                     imagens_estaticas_dispositivo[ imagem_estatica_index ].Construir( dados_imagens_estaticas_dispositivo[ imagem_estatica_index ], path_para_o_dispositivo );

                    continue;

            }


            // --- CRIA BOTOES

            for( int botao_index = 0 ; botao_index < dados_botoes_dispositivo.Length ; botao_index++ ){

                    if( dados_botoes_dispositivo[ botao_index ] == null )
                        { continue; }

                     botoes_dispositivo[ botao_index ].Construir( dados_botoes_dispositivo[ botao_index ], path_para_o_dispositivo );

                    continue;

            }



        }





}