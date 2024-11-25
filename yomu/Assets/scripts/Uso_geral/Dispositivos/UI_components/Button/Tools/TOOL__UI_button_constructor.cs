using System;
using UnityEngine;


public static class TOOL__UI_button_constructor {


        private static int numero_de_partes = Enum.GetNames( typeof( Device_button_animation_part ) ).Length;


        public static Botao_dispositivo Construir_botao_simples( Botao_dispositivo botao ){


                Dados_botao_dispositivo _dados = botao.data;

                string indentificador = null;


                //mark
                // ** 
                // ** 

                aaa
                
                // ponto princiapal => criar os 3 
                _dados.images_refs_animacoes_completas = new RESOURCE__image_ref[ numero_de_partes, 2 ];
                _dados.cores_animacoes_completas   = new Color[ numero_de_partes, 2 ]; // criar aqui

                _dados.imagens_localizadores_NOVO  = new string[ numero_de_partes, 2 ]; // criar aqui


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


                _dados.tipo_transicao = DEVICE_button_transition_type_OFF_ON.cor;
                

                // OFF 


                    _dados.off.texto_cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.off.texto_cor, Cores.black );


                    // ** back
                    indentificador = ( botao.button_name + "_OFF_back" );
                    
                        _dados.off.animacao_back.cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.off.animacao_back.cor, Cores.grey_90 );
                        _dados.imagens_localizadores_NOVO[ ( int ) Device_button_animation_part.animation_back , index_OFF ] = _dados.off.animacao_back.image_path;
                        _dados.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_back , index_OFF ] =    _dados.off.animacao_back.cor;


                    // ** base
                    indentificador = ( botao.button_name + "_OFF_base" );
                    
                        _dados.off.animacao_base.cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.off.texto_cor, Cores.white );
                        _dados.imagens_localizadores_NOVO[ ( int ) Device_button_animation_part.animation_base , index_OFF ] = _dados.off.animacao_base.image_path;
                        _dados.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_base , index_OFF ] = _dados.off.animacao_base.cor;


                    // ** atras-texto
                    indentificador = ( botao.button_name + "_OFF_atras_texto" );
                    
                        _dados.off.animacao_atras_texto.cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.off.animacao_atras_texto.cor, Cores.grey_90 );
                        _dados.imagens_localizadores_NOVO[ ( int ) Device_button_animation_part.animation_back_text , index_OFF ] = _dados.off.animacao_atras_texto.image_path;
                        _dados.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_back_text , index_OFF ] = _dados.off.animacao_atras_texto.cor;


                        
                    // ** decoracao
                    indentificador = ( botao.button_name + "_OFF_decoracao" );
                    
                        _dados.off.animacao_decoracao.cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.off.animacao_decoracao.cor, Cores.grey_90 );
                        _dados.imagens_localizadores_NOVO[ ( int ) Device_button_animation_part.animation_decoration , index_OFF ] = _dados.off.animacao_decoracao.image_path;
                        _dados.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_decoration , index_OFF ] = _dados.off.animacao_decoracao.cor;

                    

                    // ** frente-texto
                    indentificador = ( botao.button_name + "_OFF_frente_texto" );
                    
                        _dados.off.animacao_frente_texto.cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.off.animacao_frente_texto.cor, Cores.grey_90 );
                        _dados.imagens_localizadores_NOVO[ ( int ) Device_button_animation_part.animation_front_text , index_OFF ] = _dados.off.animacao_frente_texto.image_path;
                        _dados.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_front_text , index_OFF ] = _dados.off.animacao_frente_texto.cor;


                    
                // ON


                    _dados.on.texto_cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.on.texto_cor, Cores.black );


                    // ** back
                    indentificador = ( botao.button_name + "_ON_back" );
                    
                        _dados.on.animacao_back.cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.on.animacao_back.cor, Cores.grey_90 );                
                        _dados.imagens_localizadores_NOVO[ ( int ) Device_button_animation_part.animation_back , index_ON ] = _dados.on.animacao_back.image_path;
                        _dados.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_back , index_ON ] = _dados.on.animacao_back.cor;


                    // ** base
                    indentificador = ( botao.button_name + "_ON_base" );
                    
                        _dados.on.animacao_base.cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.on.animacao_base.cor, Cores.grey_90 );                    
                        _dados.imagens_localizadores_NOVO[ ( int ) Device_button_animation_part.animation_base , index_ON ] = _dados.on.animacao_base.image_path;
                        _dados.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_base , index_ON ] = _dados.on.animacao_base.cor;


                    // ** atras-texto
                    indentificador = ( botao.button_name + "_ON_atras_texto" );
            
                        _dados.on.animacao_atras_texto.cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.on.animacao_atras_texto.cor, Cores.grey_90 );                    
                        _dados.imagens_localizadores_NOVO[ ( int ) Device_button_animation_part.animation_back_text , index_ON ] = _dados.on.animacao_atras_texto.image_path;
                        _dados.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_back_text , index_ON ] = _dados.on.animacao_atras_texto.cor;

                    
                    // ** decoracao
                    indentificador = ( botao.button_name + "_ON_decoracao" );
                    _dados.on.animacao_decoracao.cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.on.animacao_decoracao.cor, Cores.grey_90 );


                    _dados.imagens_localizadores_NOVO[ ( int ) Device_button_animation_part.animation_decoration , index_ON ] = _dados.on.animacao_decoracao.image_path;
                    _dados.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_decoration , index_ON ] = _dados.on.animacao_decoracao.cor;

                    

                    // ** frente-texto
                    indentificador = ( botao.button_name + "_ON_frente_texto" );
                    
                    _dados.on.animacao_frente_texto.cor = TOOL__device_UI_SUPPORT.Mudar_cor_default(  _dados.on.animacao_frente_texto.cor, Cores.grey_90 );

                    _dados.imagens_localizadores_NOVO[ ( int ) Device_button_animation_part.animation_front_text , index_ON ] = _dados.on.animacao_frente_texto.image_path;
                    _dados.cores_animacoes_completas[ ( int ) Device_button_animation_part.animation_front_text , index_ON ] = _dados.on.animacao_frente_texto.cor;

                    



                    // --- DECORACAO COMPOSTA

                    if( _dados.off.decoracao_composta != null || _dados.off.decoracao_composta != null )
                        {  

                            // Criar_decoracao_composta_simples( _dados, _dispositivo, index_OFF, index_ON, botao.button_name );
            
                            // --- TEM DECORACAO COMPOSTA

                        }


                    return botao;

                    

        }


        public static Botao_dispositivo Construir_botao_completo( Botao_dispositivo botao ){

                    return botao;                    

        }






}