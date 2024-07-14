using UnityEngine;


unsafe public class Controlador_movimento {



        public static Controlador_movimento instancia;
        public static Controlador_movimento Pegar_instancia(){ return instancia; }

        public static Controlador_movimento Construir(){ 

                Controlador_movimento controlador = new Controlador_movimento(); 
                
                instancia = controlador;
                return instancia;
                
        }


        public void Mover_personagem( Personagem _personagem, Posicao _posicao ){

                if( _personagem.posicao.teste ==_posicao.teste )  
                        { return; }

        }

        public bool Posicoes_sao_iguais( Posicao _posicao_1, Posicao _posicao_2 ){

                fixed(  int* p_posicao = &( _posicao_1.regiao_id ) ){

                        return false;

                }

        }



       //   trocar para ponto_nome

        public void Mover_player( Posicao _ponto , bool _reset = false , bool _instantaneo = false ){



                // int _ponto_id  = (int) _ponto_nome;
                
                // Ponto ponto = Controlador_jogo_data.Criar_ponto( _ponto_nome );


                // controlador_interativos.Criar_interativos(  ponto );
                // controlador_interativos.Limpar_sprite_interativos( player_estado_atual.interativos );
                // player_estado_atual.Acrecentar_posicao( ponto , _reset );

                
                // // ** TEM QUE SER DENTO DO BLOCO MOVIMENTO 
                // // Script_jogo_nome script_entrada = Controlador_dados_dinamicos.Pegar_instancia().lista_navegacao.lista_scripts_por_entrar_ponto[_ponto_id];
                // // Scripts_jogo.Ativar_script( script_entrada );


                // controlador_interativos.interativo_atual_hover = -1;
                // Controlador_cursor.Pegar_instancia().Mudar_cursor( Cor_cursor.off );

                
                // //  usa player_estado_atual
                // controlador_tela_conector.Trocar_tela( player_estado_atual.Pegar_path_imagem_background() , _instantaneo);

                // return;

        }




        public void Voltar_player(){


                // Debug.Log( "veio voltar" );

                // Debug.Log("===============");

                // for( int i = 0 ; i < player_estado_atual.posicao_arr.Length ; i++  ){

                //         Debug.Log( "indice " + i + " com valor: " + player_estado_atual.posicao_arr[ i ]);

                // }




                // Ponto_nome novo_ponto_id =  player_estado_atual.Pegar_posicao_anterior();
                // Ponto_nome ponto_atual_id = player_estado_atual.Pegar_posicao_atual();

                // // Debug.Log("posicao atual: " + ponto_atual_id);

                // if( novo_ponto_id == ponto_atual_id ) { return;}


                // Ponto novo_ponto = Controlador_jogo_data.Criar_ponto( (Ponto_nome) novo_ponto_id);
                
                
                // player_estado_atual.Acrecentar_posicao( novo_ponto );
                

                // Controlador_cursor.Pegar_instancia().Mudar_cursor(Cor_cursor.off);
                // controlador_tela_conector.Trocar_tela(player_estado_atual.Pegar_path_imagem_background());
                // controlador_interativos.Criar_interativos(novo_ponto);

                
                // Debug.Log("===============");

                // for( int i = 0 ; i < player_estado_atual.posicao_arr.Length ; i++  ){

                //         Debug.Log( "indice " + i + " com valor: " + player_estado_atual.posicao_arr[ i ]);

                // }



        }


}