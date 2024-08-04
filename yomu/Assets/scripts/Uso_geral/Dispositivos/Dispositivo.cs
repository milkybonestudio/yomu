
using UnityEngine;


        // Dispositivo faz a ponte entre a parte visual de um componente e a parte logica. 
        // fica resposnavel por carregar imagens, instanciar/destruir outros dispositivos e alterar dados do jogo.


public class Dispositivo {

        
        // --- MODULOS
        
        public MODULO__imagens_dispositivo modulo_imagens;
        public MODULO__estados_dispositivo modulo_estados;
        public MODULO__audios_dispositivo modulo_audios;
        public MODULO__dados_dispositivo  dados_dispositivo;

    
        // --- OBJETOS PRINCIPAIS

        public INTERFACE__dispositivo interface_dispositivo;

        public GameObject dispositivo_game_object;

        public GameObject dispositivo_prefab;

        public Dispositivo dispositivo_pai;
        public Dispositivo[] dispositivos_filhos;


        

        // --- METODOS LOGICA

            public void Update(){ if( update_bloqueado ){ return; };interface_dispositivo.Update( this ); }

            // ** a perspectiva do objeto é inversa: objeto.Enviar() => void Recebe_dados()
            public     void      Enviar_dados( System.Object _dados ){ interface_dispositivo.Receber_dados( this, _dados ); }
            public System.Object Receber_dados(){ return interface_dispositivo.Enviar_dados( this ); }


            // *** vai ser chamado quando o objeto for criado
            public void Definir_objetos_iniciais(){ interface_dispositivo.Definir_objetos_iniciais( this ); }


        // --- METODOS MODULOS

            // *** imagens
            
            public void Carregar_imagens(){ modulo_imagens.Carregar_imagens();}
            public void Criar_sprites(){ modulo_imagens.Criar_sprites();}
            public void Colocar_imagens(){  Colocar_imagens_interno(); }


            
            public void Carregar_audios(){ modulo_audios.Carregar_audios();}
            public void Colocar_audios(){ Colocar_audios_interno(); }


        // --- METODOS VISUAIS

            public void Anexar_dispositivo( GameObject _pai ){ Anexar_dispositivo_interno( _pai ); }
            public void Mover_dispositivo( float _quantidade_para_adicionar_X, float _quantidade_para_adicionar_Y ){if( movimento_bloqueado){ return; } Mover_dispositivo_interno(  _quantidade_para_adicionar_X,  _quantidade_para_adicionar_Y ); }
            public void Mudar_pai_dispositivo( GameObject _pai ){ Mudar_pai_dispositivo_interno( _pai ); }



        // --- FLUXO DE LOGICA

            private bool update_bloqueado;
            private bool movimento_bloqueado;
            
            public void Bloquear_update(){ update_bloqueado = true; }
            public void Liberar_update(){ update_bloqueado = false; }

            public void Bloquear_movimento(){ movimento_bloqueado = true; }
            public void Liberar_movimento(){ movimento_bloqueado = false; }



            //public void Esconder_dispositivo(){}








        public Dispositivo( INTERFACE__dispositivo _interface ){



                interface_dispositivo = _interface;

                string nome_dispositivo = _interface.Pegar_nome();
                string[] folders = _interface.Pegar_folders();

                // --- PEGAR PREFAB

                string prefab_path = System.IO.Path.Combine( folders );
                prefab_path = System.IO.Path.Combine( "Prefabs", prefab_path );
                prefab_path = System.IO.Path.Combine( prefab_path, nome_dispositivo);
                prefab_path += "_dispositivo" ;
                
                
                dispositivo_prefab =  Resources.Load<GameObject>( prefab_path );

                if( dispositivo_prefab == null )
                    { throw new System.Exception($"tentou carregar o prefab do dispositivo { nome_dispositivo } no path <color=white><b>{ prefab_path }</b></color> do resources mas nao foi encontrado"); }

            



                // --- CRIA MODULO IMAGENS 
                modulo_imagens = new MODULO__imagens_dispositivo( 
                                                                    _nome_dispositivo : nome_dispositivo,
                                                                    _folders: folders,
                                                                    _tipo_imagens : _interface.Pegar_tipo_imagens()
                                                                );




                // --- CRIA MODULO AUDIO
                modulo_audios = new MODULO__audios_dispositivo();

                // --- CRIA MODULO DADOS
                dados_dispositivo = new MODULO__dados_dispositivo();


                // *** Define os objetos iniciais
                _interface.Definir_objetos_iniciais( this );




        }


        // --- DEFINICOES OBJETOS

        public void Definir_imagem_estatica( Dados_imagem_estatica _dados ){

                modulo_imagens.Definir_imagem_estatica( _dados );

        }

        public void Definir_botao( Dados_botao _dados_botao ){

                modulo_imagens.Definir_imagem_botao( _dados_botao );
                modulo_audios.Definir_audios_botao( _dados_botao );

        }






        private void Anexar_dispositivo_interno( GameObject _pai ){

                // --- VERIFICACOES
                if( dispositivo_prefab == null )
                    { throw new System.Exception( $"Tentou Anexar o dipositivo { interface_dispositivo.Pegar_nome() } mas o prefab estava null"); }

                if( _pai == null )
                    { throw new System.Exception( $"Tentou Anexar o dipositivo { interface_dispositivo.Pegar_nome() } mas o game_object <color=red><b>pai</b></color> estava null"); }


                dispositivo_game_object = GameObject.Instantiate( dispositivo_prefab );
                dispositivo_game_object.name = dispositivo_prefab.name;

                if( dispositivo_game_object.name != ( interface_dispositivo.Pegar_nome() + "_dispositivo" ) )
                    { throw new System.Exception( $"Prefab estava com o nome errado no container. Estava: { dispositivo_game_object.name }" ); }

                dispositivo_game_object.transform.SetParent( _pai.transform, false );



                return;
            
        }

        private void Mudar_pai_dispositivo_interno( GameObject _pai ){

            // --- VERIFICACOES
            if( dispositivo_game_object == null )
                { throw new System.Exception( $"Em mudar pai do dispositivo { interface_dispositivo.Pegar_nome() } o game_pobject do dispositivo estava null"); }

            if( _pai == null )
                { throw new System.Exception( $"Em mudar pai do dispositivo { interface_dispositivo.Pegar_nome() } o pai estava null" ); }
            
            string path_pai = GAME_OBJECT.Pegar_path( _pai );
            string novo_path = ( path_pai + "/" + interface_dispositivo.Pegar_nome() );

            dados_dispositivo.path_para_o_dispositivo = novo_path;

            dispositivo_game_object.transform.SetParent( _pai.transform, false );

            return;

        }

        private void Mover_dispositivo_interno(  float _quantidade_para_adicionar_X,  float _quantidade_para_adicionar_Y ){

                // --- VERIFICACOES
                if( dispositivo_game_object == null )
                    { throw new System.Exception( $"Tentou mover o dipositivo { interface_dispositivo.Pegar_nome() } mas o game_object estava null"); }

                Vector3 posicao_atual = dispositivo_game_object.transform.localPosition;
                Vector3 nova_posicao = ( posicao_atual + new Vector3( _quantidade_para_adicionar_X, _quantidade_para_adicionar_Y, 0f ) );

                dispositivo_game_object.transform.localPosition = nova_posicao;
                return;

        }



        private void Colocar_imagens_interno(){


                // --- VERIFICACOES

                if( dispositivo_game_object == null )
                    { throw new System.Exception( $"tentou colocar as imagens no dispositivo { interface_dispositivo.Pegar_nome() } mas o dispositivo_game_object estava null. Provavelmente não foi colocado no jogo" ); }

                if( modulo_imagens.sprites_especificas == null )
                    { throw new System.Exception( "Nao foi dado o Carregar_imagens no modulo imagens dispositivos" ); }



                string path_dispositivo = dados_dispositivo.path_para_o_dispositivo;
                    
                modulo_imagens.Colocar_imagens_tipo_imagem_estatica( dados_dispositivo.dados_imagens_estaticas, path_dispositivo );
                modulo_imagens.Colocar_imagens_tipo_botao( dados_dispositivo.dados_botoes, path_dispositivo );

                return;

        }

        private void Colocar_audios_interno(){

            modulo_audios.Colocar_audios( dados_dispositivo );

        }






    
}