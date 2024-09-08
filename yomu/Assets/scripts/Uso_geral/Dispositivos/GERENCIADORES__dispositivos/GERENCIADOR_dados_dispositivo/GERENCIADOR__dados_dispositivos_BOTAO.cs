using System;
using UnityEngine;

public static class GERENCIADOR__dados_dispositivos_BOTAO {



        private static int numero_de_partes = Enum.GetNames( typeof( Botao_dispositivo_animacao_parte ) ).Length;

        private static void Criar_decoracao_composta_simples( Dados_botao_dispositivo _dados, Dispositivo _dispositivo, int index_OFF, int index_ON, string nome_default ){


                string indentificador = null;
                

                int numeros_sprites_composta_off = 0;
                int numeros_sprites_composta_on = 0;


                if( _dados.off.decoracao_composta != null )
                    { numeros_sprites_composta_off = _dados.off.decoracao_composta.Length; }

                if( _dados.on.decoracao_composta != null )
                    { numeros_sprites_composta_on = _dados.off.decoracao_composta.Length; }


                int numero_sprites_decoracao = -1;

                if( numeros_sprites_composta_off > numeros_sprites_composta_on )
                    { numero_sprites_decoracao = numeros_sprites_composta_off; }
                    else
                    { numero_sprites_decoracao = numeros_sprites_composta_on; }


                _dados.sprites_decoracao_composta = new Sprite[ numero_sprites_decoracao, 2 ]; 
                _dados.cores_decoracao_composta = new Color[ numero_sprites_decoracao, 2 ];
                _dados.imagens_localizadores_decoracao_composta = new Dados_para_criar_botao_localizador_imagens[ numero_sprites_decoracao, 2 ];



                if( _dados.off.decoracao_composta != null )
                    {
                        // --- TEM OFF

                        // --- OFF
                        for( int index_decoracao_composta_off = 0  ; index_decoracao_composta_off < numero_sprites_decoracao ; index_decoracao_composta_off++ ){


                                // ** frente-texto
                                indentificador = ( nome_default + "_OF_frente_texto" );
                                _dados.off.decoracao_composta[ index_decoracao_composta_off ].tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.off.decoracao_composta[ index_decoracao_composta_off].sprite_id, _dados.off.decoracao_composta[ index_decoracao_composta_off].sprite_id_GERAL, false );
                                _dados.off.decoracao_composta[ index_decoracao_composta_off ].cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.off.decoracao_composta[ index_decoracao_composta_off].tipo_pegar_sprite, _dados.off.decoracao_composta[ index_decoracao_composta_off].cor, Cores.grey_90 );


                                _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_off, index_OFF ].tipo_pegar_sprite = _dados.off.decoracao_composta[ index_decoracao_composta_off ].tipo_pegar_sprite;
                                _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_off, index_OFF ].sprite_id = _dados.off.decoracao_composta[ index_decoracao_composta_off].sprite_id;
                                _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_off, index_OFF ].sprite_id_geral = _dados.off.decoracao_composta[ index_decoracao_composta_off].sprite_id_GERAL;
                                _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_off, index_OFF ].length = 1;

                                _dados.cores_decoracao_composta[ index_decoracao_composta_off, index_OFF ] = _dados.off.decoracao_composta[ index_decoracao_composta_off].cor;

                                continue;



                        }

                    }
                    else 
                    {
                        // --- NAO TEM OFF
                        // ???

                    }



                // --- CHECA SE TEM ON 
                if( _dados.on.decoracao_composta != null )
                    {

                        // --- TEM ON ESPECIFICO

                        // --- ON
                        for( int index_decoracao_composta_on = 0  ; index_decoracao_composta_on < numero_sprites_decoracao ; index_decoracao_composta_on++ ){


                                indentificador = ( nome_default + "_ON_frente_texto" );
                                _dados.on.decoracao_composta[ index_decoracao_composta_on].tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.on.decoracao_composta[ index_decoracao_composta_on].sprite_id, _dados.on.decoracao_composta[ index_decoracao_composta_on].sprite_id_GERAL, false );
                                _dados.on.decoracao_composta[ index_decoracao_composta_on].cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.on.decoracao_composta[ index_decoracao_composta_on].tipo_pegar_sprite, _dados.on.decoracao_composta[ index_decoracao_composta_on].cor, Cores.grey_90 );


                                _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_ON ].tipo_pegar_sprite = _dados.on.decoracao_composta[ index_decoracao_composta_on].tipo_pegar_sprite;
                                _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_ON ].sprite_id = _dados.on.decoracao_composta[ index_decoracao_composta_on].sprite_id;
                                _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_ON ].sprite_id_geral = _dados.on.decoracao_composta[ index_decoracao_composta_on].sprite_id_GERAL;
                                _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_ON ].length = 1;

                                _dados.cores_decoracao_composta[ index_decoracao_composta_on, index_ON ] = _dados.on.decoracao_composta[ index_decoracao_composta_on].cor;

                                continue;

                        }


                    }

                    else
                    {
                        // --- NAO TEM ON 
                        //??
                    }

                    // else
                    // {
                    //     // --- NAO TEM ON ( DUPLICAR OFF ) 

                    //     // --- ON
                    //     for( int index_decoracao_composta_on = 0  ; index_decoracao_composta_on < numero_sprites_decoracao ; index_decoracao_composta_on++ ){


                    //             _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_ON ].tipo_pegar_sprite = _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_OFF ].tipo_pegar_sprite;
                    //             _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_ON ].sprite_id = _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_OFF ].sprite_id ;
                    //             _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_ON ].sprite_id_geral = _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_OFF ].sprite_id_geral ;
                    //             _dados.imagens_localizadores_decoracao_composta[ index_decoracao_composta_on, index_ON ].length = 1;


                    //             _dados.cores_decoracao_composta[ index_decoracao_composta_on, index_ON ] = _dados.cores_decoracao_composta[ index_decoracao_composta_on, index_OFF ] ;
                    //             continue;


                    //     }


                    // }





                return;
                    
 
        }


        public static Botao_dispositivo Construir_botao_simples( Dispositivo _dispositivo, Dados_botao_dispositivo _dados, Botao_dispositivo botao, string nome_default ){


                string indentificador = null;

                //int numero_de_partes = Enum.GetNames( typeof( Botao_dispositivo_animacao_parte ) ).Length;
                
                

                // ponto princiapal => criar os 3 
                _dados.sprites_animacoes_completas = new Sprite[ numero_de_partes, 2 ];
                _dados.cores_animacoes_completas   = new Color[ numero_de_partes, 2 ]; // criar aqui
                _dados.imagens_localizadores  = new Dados_para_criar_botao_localizador_imagens[ numero_de_partes, 2 ]; // criar aqui




                int index_OFF = 0;
                int index_ON = 1;

                _dados.pointers.pointer_imagem_estatica_OFF = index_OFF;
                _dados.pointers.pointer_imagem_estatica_ON = index_ON; 


                // ** seta tempos
                _dados.animacao_on_tempos.tempo_espera_para_ativar_ms = float.MaxValue;
                _dados.animacao_off_tempos.tempo_espera_para_ativar_ms = float.MaxValue;

                _dados.animacao_on_tempos.tempo_troca_sprite_ms = 0f;
                _dados.animacao_off_tempos.tempo_troca_sprite_ms = 0f;
                

                // --- transicao cor
                _dados.animacao_ON_para_OFF_tempos.tempo_espera_para_ativar_ms = _dados.tempo_transicao;
                _dados.animacao_OFF_para_ON_tempos.tempo_espera_para_ativar_ms = _dados.tempo_transicao;


                _dados.tipo_transicao = Tipo_transicao_botao_OFF_ON_dispositivo.cor;
                

                // OFF 

                    // ** back
                    indentificador = ( nome_default + "_OFF_back" );
                    _dados.off.animacao_back.tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.off.animacao_back.sprite_id, _dados.off.animacao_back.sprite_id_GERAL, false ); 
                    _dados.off.animacao_back.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.off.animacao_back.tipo_pegar_sprite, _dados.off.animacao_back.cor, Cores.grey_90 );


                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_back , index_OFF ].tipo_pegar_sprite = _dados.off.animacao_back.tipo_pegar_sprite;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_back , index_OFF ].sprite_id = _dados.off.animacao_back.sprite_id;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_back , index_OFF ].sprite_id_geral = _dados.off.animacao_back.sprite_id_GERAL;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_back , index_OFF ].length = 1;
                    

                    _dados.cores_animacoes_completas[ ( int ) Botao_dispositivo_animacao_parte.animacao_back , index_OFF ] =    _dados.off.animacao_back.cor;


                    // ** base
                    indentificador = ( nome_default + "_OFF_base" );
                    _dados.off.animacao_base.tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.off.animacao_base.sprite_id, _dados.off.animacao_base.sprite_id_GERAL, true ); 
                    _dados.off.animacao_base.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.off.animacao_base.tipo_pegar_sprite, _dados.off.texto_cor, Cores.white );


                    _dados.off.texto_cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.off.animacao_base.tipo_pegar_sprite, _dados.off.texto_cor, Cores.black );




                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_base , index_OFF ].tipo_pegar_sprite = _dados.off.animacao_base.tipo_pegar_sprite;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_base , index_OFF ].sprite_id = _dados.off.animacao_base.sprite_id;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_base , index_OFF ].sprite_id_geral = _dados.off.animacao_base.sprite_id_GERAL;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_base , index_OFF ].length = 1;

                    _dados.cores_animacoes_completas[ ( int ) Botao_dispositivo_animacao_parte.animacao_base , index_OFF ] = _dados.off.animacao_base.cor;


                    // ** atras-texto
                    indentificador = ( nome_default + "_OFF_atras_texto" );
                    _dados.off.animacao_atras_texto.tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.off.animacao_atras_texto.sprite_id, _dados.off.animacao_atras_texto.sprite_id_GERAL, false ); 
                    _dados.off.animacao_atras_texto.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.off.animacao_atras_texto.tipo_pegar_sprite, _dados.off.animacao_atras_texto.cor, Cores.grey_90 );


                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , index_OFF ].tipo_pegar_sprite = _dados.off.animacao_atras_texto.tipo_pegar_sprite;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , index_OFF ].sprite_id = _dados.off.animacao_atras_texto.sprite_id;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , index_OFF ].sprite_id_geral = _dados.off.animacao_atras_texto.sprite_id_GERAL;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , index_OFF ].length = 1;

                    _dados.cores_animacoes_completas[ ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , index_OFF ] = _dados.off.animacao_atras_texto.cor;


                    
                    // ** NAO PEGA O TEXTO
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_texto, index_OFF ].tipo_pegar_sprite = Tipo_pegar_sprite.nada;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_texto, index_OFF ].length = 1;


                    
                    
                    // ** decoracao
                    indentificador = ( nome_default + "_OFF_decoracao" );
                    _dados.off.animacao_decoracao.tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.off.animacao_decoracao.sprite_id, _dados.off.animacao_decoracao.sprite_id_GERAL, false ); 
                    _dados.off.animacao_decoracao.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.off.animacao_decoracao.tipo_pegar_sprite, _dados.off.animacao_decoracao.cor, Cores.grey_90 );


                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , index_OFF ].tipo_pegar_sprite = _dados.off.animacao_decoracao.tipo_pegar_sprite;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , index_OFF ].sprite_id = _dados.off.animacao_decoracao.sprite_id;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , index_OFF ].sprite_id_geral = _dados.off.animacao_decoracao.sprite_id_GERAL;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , index_OFF ].length = 1;
                    

                    _dados.cores_animacoes_completas[ ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , index_OFF ] = _dados.off.animacao_decoracao.cor;

                    

                    // ** frente-texto
                    indentificador = ( nome_default + "_OFF_frente_texto" );
                    _dados.off.animacao_frente_texto.tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.off.animacao_frente_texto.sprite_id, _dados.off.animacao_frente_texto.sprite_id_GERAL, false ); 
                    _dados.off.animacao_frente_texto.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.off.animacao_frente_texto.tipo_pegar_sprite, _dados.off.animacao_frente_texto.cor, Cores.grey_90 );


                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , index_OFF ].tipo_pegar_sprite = _dados.off.animacao_frente_texto.tipo_pegar_sprite;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , index_OFF ].sprite_id = _dados.off.animacao_frente_texto.sprite_id;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , index_OFF ].sprite_id_geral = _dados.off.animacao_frente_texto.sprite_id_GERAL;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , index_OFF ].length = 1;

                    _dados.cores_animacoes_completas[ ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , index_OFF ] = _dados.off.animacao_frente_texto.cor;

                    
                // ON

                    // ** back
                    indentificador = ( nome_default + "_ON_back" );
                    _dados.on.animacao_back.tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.on.animacao_back.sprite_id, _dados.on.animacao_back.sprite_id_GERAL, false ); 
                    _dados.on.animacao_back.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.on.animacao_back.tipo_pegar_sprite, _dados.on.animacao_back.cor, Cores.grey_90 );
                

                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_back , index_ON ].tipo_pegar_sprite = _dados.on.animacao_back.tipo_pegar_sprite;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_back , index_ON ].sprite_id = _dados.on.animacao_back.sprite_id;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_back , index_ON ].sprite_id_geral = _dados.on.animacao_back.sprite_id_GERAL;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_back , index_ON ].length = 1;

                    _dados.cores_animacoes_completas[ ( int ) Botao_dispositivo_animacao_parte.animacao_back , index_ON ] = _dados.on.animacao_back.cor;


                    // ** base
                    indentificador = ( nome_default + "_ON_base" );
                    _dados.on.animacao_base.tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.on.animacao_base.sprite_id, _dados.on.animacao_base.sprite_id_GERAL, true ); 
                    _dados.on.animacao_base.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.on.animacao_base.tipo_pegar_sprite, _dados.on.animacao_base.cor, Cores.grey_90 );


                    _dados.on.texto_cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.on.animacao_base.tipo_pegar_sprite, _dados.on.texto_cor, Cores.black );


                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_base , index_ON ].tipo_pegar_sprite = _dados.on.animacao_base.tipo_pegar_sprite;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_base , index_ON ].sprite_id = _dados.on.animacao_base.sprite_id;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_base , index_ON ].sprite_id_geral = _dados.on.animacao_base.sprite_id_GERAL;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_base , index_ON ].length = 1;

                    _dados.cores_animacoes_completas[ ( int ) Botao_dispositivo_animacao_parte.animacao_base , index_ON ] = _dados.on.animacao_base.cor;


                    // ** atras-texto
                    indentificador = ( nome_default + "_ON_atras_texto" );
                    _dados.on.animacao_atras_texto.tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.on.animacao_atras_texto.sprite_id, _dados.on.animacao_atras_texto.sprite_id_GERAL, false ); 
                    _dados.on.animacao_atras_texto.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.on.animacao_atras_texto.tipo_pegar_sprite, _dados.on.animacao_atras_texto.cor, Cores.grey_90 );


                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , index_ON ].tipo_pegar_sprite = _dados.on.animacao_atras_texto.tipo_pegar_sprite;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , index_ON ].sprite_id = _dados.on.animacao_atras_texto.sprite_id;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , index_ON ].sprite_id_geral = _dados.on.animacao_atras_texto.sprite_id_GERAL;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , index_ON ].length = 1;

                    _dados.cores_animacoes_completas[ ( int ) Botao_dispositivo_animacao_parte.animacao_atras_texto , index_ON ] = _dados.on.animacao_atras_texto.cor;


                    // ** NAO PEGA O TEXTO
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_texto, index_ON ].tipo_pegar_sprite = Tipo_pegar_sprite.nada;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_texto, index_ON ].length = 1;


                    
                    // ** decoracao
                    indentificador = ( nome_default + "_ON_decoracao" );
                    _dados.on.animacao_decoracao.tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.on.animacao_decoracao.sprite_id, _dados.on.animacao_decoracao.sprite_id_GERAL, false ); 
                    _dados.on.animacao_decoracao.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.on.animacao_decoracao.tipo_pegar_sprite, _dados.on.animacao_decoracao.cor, Cores.grey_90 );


                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , index_ON ].tipo_pegar_sprite = _dados.on.animacao_decoracao.tipo_pegar_sprite;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , index_ON ].sprite_id = _dados.on.animacao_decoracao.sprite_id;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , index_ON ].sprite_id_geral = _dados.on.animacao_decoracao.sprite_id_GERAL;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , index_ON ].length = 1;

                    _dados.cores_animacoes_completas[ ( int ) Botao_dispositivo_animacao_parte.animacao_decoracao , index_ON ] = _dados.on.animacao_decoracao.cor;

                    

                    // ** frente-texto
                    indentificador = ( nome_default + "_ON_frente_texto" );
                    _dados.on.animacao_frente_texto.tipo_pegar_sprite =  GERENCIADOR__dados_dispositivos_SUPORTE.Pegar_tipo_pegar_imagem_simples(  _dispositivo.nome_dispositivo , indentificador, _dados.on.animacao_frente_texto.sprite_id, _dados.on.animacao_frente_texto.sprite_id_GERAL, false );
                    _dados.on.animacao_frente_texto.cor = GERENCIADOR__dados_dispositivos_SUPORTE.Mudar_cor_default( _dados.on.animacao_frente_texto.tipo_pegar_sprite, _dados.on.animacao_frente_texto.cor, Cores.grey_90 );


                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , index_ON ].tipo_pegar_sprite = _dados.on.animacao_frente_texto.tipo_pegar_sprite;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , index_ON ].sprite_id = _dados.on.animacao_frente_texto.sprite_id;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , index_ON ].sprite_id_geral = _dados.on.animacao_frente_texto.sprite_id_GERAL;
                    _dados.imagens_localizadores[ ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , index_ON ].length = 1;

                    _dados.cores_animacoes_completas[ ( int ) Botao_dispositivo_animacao_parte.animacao_frente_texto , index_ON ] = _dados.on.animacao_frente_texto.cor;

                    



                    // --- DECORACAO COMPOSTA

                    if( _dados.off.decoracao_composta != null || _dados.off.decoracao_composta != null )
                        {  

                            Criar_decoracao_composta_simples( _dados, _dispositivo, index_OFF, index_ON, nome_default );
            
                            // --- TEM DECORACAO COMPOSTA



                        }




                    return botao;

                    

        }





        public static Botao_dispositivo Construir_botao_completo( Dispositivo _dispositivo, Dados_botao_dispositivo _dados, Botao_dispositivo botao, string nome_default ){


                /*
                    -> quando for fazer: 




                */




                    return botao;
                    

        }



    

}