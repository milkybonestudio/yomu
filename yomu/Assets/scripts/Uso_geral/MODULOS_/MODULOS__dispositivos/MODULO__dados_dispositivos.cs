using System;
using UnityEngine;
using UnityEngine.UI;



public class MODULO__dados_dispositivo {

        // ** garante que os dados estejam corretos


        public MODULO__dados_dispositivo( Dispositivo _dispositivo ){

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





        private void Verificar_tempos_sequencia( float[] _tempos, Color[] _cores, string _indentificador ){

            if( _cores == null )
                { 
                    if( _tempos != null )
                        { throw new Exception( $"Nao foi definido as cores no {_indentificador } mas foi definido os tempos" );}

                    return; 
                }

            if( _tempos == null )
                { return; }

            if( _tempos.Length != _cores.Length )
                { throw new Exception($"Foi declarado {_tempos.Length} tempos para a sequencia {_indentificador }, mas tinha { _cores.Length}"); }

            return;

        }

        private void Verificar_nome( string _nome ){

               if( _nome == "" || _nome == null )
                    { throw new Exception( $"Nao foi colocado o nome da imagem estatica no dispositivo <Color=lighBlue><b>{ dispositivo.nome_dispositivo }</b></color>" ); }
                return;
        }

        private Color Mudar_cor_default( Tipo_pegar_sprite _tipo, Color _cor_nos_dados, Color _cor_default ){


                if( _cor_nos_dados != Cores.cor_default_dispositivo )
                    { return _cor_nos_dados; }


                // --- COLOCAR DEFAULT
                if( _tipo != Tipo_pegar_sprite.nada )
                    { return _cor_default; } // ALGO 
                    else 
                    { return Cores.clear; } // NADA

                    
        }


        private Color[] Mudar_cor_default_sequecia( Tipo_pegar_sprite _tipo, Color[] _cor_nos_dados, int[] _ids, object[] chaves, Color _cor_default, string _indentificador = "NAO INDENTIFICADO" ){

                // --- PEGAR IMAGENS

                int numero_de_imagens = -1;

                if( _tipo == Tipo_pegar_sprite.nada )
                    { return null; }

                if( _tipo == Tipo_pegar_sprite.imagem_especifica )
                    { numero_de_imagens = _ids.Length; }

                if( _tipo == Tipo_pegar_sprite.imagem_geral )
                    { numero_de_imagens = chaves.Length; }



                if( _cor_nos_dados != null )
                    { 
                        // --- VERIFICAR SE CORES FAZEN SENTIDO

                        if( _cor_nos_dados.Length != numero_de_imagens )
                            { throw new Exception( $"Declarou cores no indentificador { _indentificador } mas tinham { _cor_nos_dados.Length } cores e a sequencia tinha { numero_de_imagens } imagens" ); }

                        return _cor_nos_dados; 
                        
                    }



                Color[] retorno =  new Color[ numero_de_imagens ];

                for( int index = 0 ; index < retorno.Length ; index++ )
                    { retorno[ index ] = _cor_default; }

                return retorno;

        }



        private Tipo_pegar_sprite Pegar_tipo_pegar_imagem_simples( string _nome_parte, int _imagem_id, object _chaves, bool _imagem_vazia, bool _precisa_definir ){


                bool tem_especifico = ( _imagem_id > -1 );
                bool tem_geral = ( _chaves != null );

                // --- VERIFICA

                        
                if( tem_especifico && _imagem_vazia )
                    { throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ dispositivo.nome_dispositivo }</b></color> foi colocado tanto um id valido (<Color=lightBlue><b>{ _imagem_id }</b></color>) quando foi indicado que era uma <Color=lightBlue><b>imagem vazia</b></color>"); }

                if( tem_geral && _imagem_vazia )
                    { throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ dispositivo.nome_dispositivo }</b></color> foi colocado tanto chaves validas (chave 1: <Color=lightBlue><b>{ _chaves.GetType().Name.Split( "__" )[ 0 ] }</b></color>, chave 2: <Color=lightBlue><b>{ _chaves.ToString() }</b></color>) quando foi indicado que era uma <Color=lightBlue><b>imagem vazia</b></color>"); }

                if ( tem_especifico && tem_geral  )
                    {  throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ dispositivo.nome_dispositivo }</b></color> foi colocado tanto chaves validas (chave 1: <Color=lightBlue><b>{ _chaves.GetType().Name.Split( "__" )[ 0 ] }</b></color>, chave 2: <Color=lightBlue><b>{ _chaves.ToString() }</b></color>) quando foi colocado um id (<Color=lightBlue><b>{ _imagem_id }</b></color>)"); }


                if( tem_especifico )
                    { return Tipo_pegar_sprite.imagem_especifica; }


                if( tem_geral )
                    { return Tipo_pegar_sprite.imagem_geral; }


                if( _imagem_vazia ) 
                    { return Tipo_pegar_sprite.nada; }

                if( _precisa_definir )
                    { throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ dispositivo.nome_dispositivo }</b></color> nao foi colocado dados para definir qual o tipo de imagem") ; }


                return Tipo_pegar_sprite.nada; 

                

        }

        
        public Tipo_pegar_sprite Pegar_tipo_pegar_imagem_sequencia( string _nome_parte, int[] _ids, object[] _chaves, bool _imagem_vazia, bool _precisa_definir ){



                bool tem_especifico = ( _ids != null );
                bool tem_geral = ( _chaves != null );

                // --- VERIFICA

                if( tem_especifico && _imagem_vazia )
                    { throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ dispositivo.nome_dispositivo }</b></color> foi colocado tanto um ids validos quando foi indicado que era uma <Color=lightBlue><b>imagem vazia</b></color>"); }

                if( tem_geral && _imagem_vazia )
                    { throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ dispositivo.nome_dispositivo }</b></color> foi colocado tanto chaves validas quando foi indicado que era uma <Color=lightBlue><b>imagem vazia</b></color>"); }

                if ( tem_especifico && tem_geral )
                    {  throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ dispositivo.nome_dispositivo }</b></color> foi colocado tanto chaves validas quando foi colocado ids validos"); }


                if( tem_especifico )
                    { return Tipo_pegar_sprite.imagem_especifica; }


                if( tem_geral )
                    { return Tipo_pegar_sprite.imagem_geral; }


                if( _imagem_vazia ) 
                    { return Tipo_pegar_sprite.nada; }

                if( _precisa_definir )
                    { throw new Exception($"No <Color=lightBlue><b>{ _nome_parte }</b></color> do dispositivo <Color=lightBlue><b>{ dispositivo.nome_dispositivo }</b></color> nao foi colocado dados para definir qual o tipo de imagem");  }

                return Tipo_pegar_sprite.nada; 

                


                

        }
        


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

                Verificar_nome( _dados.nome );
                
                
                // --- MUDAR DADOS 

                _dados.tipo_pegar_sprite = Pegar_tipo_pegar_imagem_simples( _dados.nome, _dados.imagem_id, _dados.chaves, _dados.imagem_vazia, true );
                _dados.cor = Mudar_cor_default( _dados.tipo_pegar_sprite, _dados.cor, Cores.white );

                

                return imagem;

        }



        public Botao_dispositivo Definir_botao( Dados_botao_dispositivo _dados ){


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

                Verificar_nome( _dados.nome );
                

                string indentificador = null;
                string nome_default = ( dispositivo.nome_dispositivo + "_BOTAO_" + _dados.nome );


                // --- MUDAR DADOS

                // --- OFF

                    indentificador = ( nome_default + "_static_ON" );
                    _dados.tipo_pegar_sprite_off = Pegar_tipo_pegar_imagem_simples( _dados.nome, _dados.sprite_off_id, _dados.sprites_ids_animacao_off_geral , _dados.imagem_off_vazio, true );
                    _dados.cor_imagem_off = Mudar_cor_default( _dados.tipo_pegar_sprite_off, _dados.cor_imagem_off, Cores.grey_90 );

                    // ** animacao
                    indentificador = indentificador = ( nome_default + "_animacao_ON" );
                    _dados.tipo_pegar_sprite_off_animacao = Pegar_tipo_pegar_imagem_sequencia( _dados.nome, _dados.sprites_ids_animacao_off, _dados.sprites_ids_animacao_off_geral, false, false );
                    _dados.cores_animacao_imagem_off = Mudar_cor_default_sequecia( _dados.tipo_pegar_sprite_off_animacao, _dados.cores_animacao_imagem_off, _dados.sprites_ids_animacao_off, _dados.sprites_ids_animacao_off_geral, Cores.white, indentificador );
                    Verificar_tempos_sequencia( _dados.animacao_off_tempo_troca_sprite_ms_por_sprite, _dados.cores_animacao_imagem_off, indentificador );



                // --- ON

                    indentificador = indentificador = ( nome_default + "_static_ON" );
                    _dados.tipo_pegar_sprite_on = Pegar_tipo_pegar_imagem_simples( _dados.nome, _dados.sprite_on_id, _dados.sprite_on_geral_id, _dados.imagem_on_vazio, true );
                    _dados.cor_imagem_on = Mudar_cor_default( _dados.tipo_pegar_sprite_on, _dados.cor_imagem_on, Cores.white );
                    Debug.Log( Cores.white );

                    // ** animacao
                    indentificador = indentificador = ( nome_default + "_animacao_ON" );
                    _dados.tipo_pegar_sprite_on_animacao = Pegar_tipo_pegar_imagem_sequencia( _dados.nome, _dados.sprites_ids_animacao_on, _dados.sprites_ids_animacao_on_geral, false, false );
                    _dados.cores_animacao_imagem_on = Mudar_cor_default_sequecia( _dados.tipo_pegar_sprite_on_animacao, _dados.cores_animacao_imagem_on, _dados.sprites_ids_animacao_on, _dados.sprites_ids_animacao_on_geral,  Cores.white, indentificador );
                    Verificar_tempos_sequencia( _dados.animacao_on_tempo_troca_sprite_ms_por_sprite, _dados.cores_animacao_imagem_on, indentificador );


                // --- TRANSICAO

                    // ** OFF -> ON
                    indentificador = ( nome_default + "_transicao_ON_para_OFF" );
                    _dados.tipo_pegar_sprite_transicao_OFF_para_ON = Pegar_tipo_pegar_imagem_sequencia( _dados.nome, _dados.sprites_ids_transicao_OFF_para_ON, _dados.sprites_ids_transicao_OFF_para_ON_geral, false, false );
                    _dados.cores_transicao_OFF_para_ON = Mudar_cor_default_sequecia( _dados.tipo_pegar_sprite_transicao_OFF_para_ON, _dados.cores_transicao_OFF_para_ON, _dados.sprites_ids_transicao_OFF_para_ON, _dados.sprites_ids_transicao_OFF_para_ON_geral, Cores.white, ( dispositivo.nome_dispositivo + "_BOTAO_" + _dados.nome + "_cores_animacao_imagem_transicao_OFF_para_ON") );
                    Verificar_tempos_sequencia( _dados.animacao_transicao_tempo_troca_sprite_OFF_para_ON_ms_por_sprite, _dados.cores_transicao_OFF_para_ON, indentificador );

                    // ** ON -> OFF
                    indentificador = ( nome_default + "_transicao_OFF_para_ON" );
                    _dados.tipo_pegar_sprite_transicao_ON_para_OFF = Pegar_tipo_pegar_imagem_sequencia( _dados.nome, _dados.sprites_ids_transicao_ON_para_OFF, _dados.sprites_ids_transicao_ON_para_OFF_geral, false, false );
                    _dados.cores_transicao_ON_para_OFF = Mudar_cor_default_sequecia( _dados.tipo_pegar_sprite_transicao_ON_para_OFF, _dados.cores_transicao_ON_para_OFF, _dados.sprites_ids_transicao_ON_para_OFF, _dados.sprites_ids_transicao_ON_para_OFF_geral, Cores.white, ( dispositivo.nome_dispositivo + "_BOTAO_" + _dados.nome + "_cores_animacao_imagem_transicao_ON_para_OFF") );
                    Verificar_tempos_sequencia( _dados.animacao_transicao_tempo_troca_sprite_ON_para_OFF_ms_por_sprite, _dados.cores_transicao_ON_para_OFF, indentificador );

                
                return botao;

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