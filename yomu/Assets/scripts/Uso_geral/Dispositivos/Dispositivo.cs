
using UnityEngine;
using System;
using System.IO;


public class Dispositivo {

        // ** device vai ser mais usados para coisas do sistema
        // ** se algo for usado muito e especifico vai ter uma classe separada

        // --- DADOS

        public string nome_dispositivo;
        public string path_folder_prefab;

        // --- GERENCIADORES
        
        public GERENCIADOR__estados_dispositivo gerenciador_estados;

        public MANAGER__components_device  dados_dispositivo;

        public GERENCIADOR__imagens_dispositivo gerenciador_imagens;
        public GERENCIADOR__audios_dispositivo gerenciador_audios;

    
        // --- OBJETOS PRINCIPAIS

        public INTERFACE__dispositivo interface_dispositivo;

        public GameObject dispositivo_game_object;
        public GameObject dispositivo_prefab;


        public Dispositivo dispositivo_pai;
        public Dispositivo[] dispositivos_filhos;


        public bool ativou_carregar = false; // *** pode excluir quando Carregar() estiver pronto

        
        // --- FLUXO DE LOGICA

            private bool update_bloqueado;
            private bool movimento_bloqueado;


        // --- METODOS PUBLICOS


            // ** LOGIC
            public void Update(){ if( update_bloqueado ){ return; };interface_dispositivo.Update( this ); }

            
            public System.Object Receber_dados(){ return interface_dispositivo.Enviar_dados( this ); } 
            public void  Enviar_dados( System.Object _dados ){ interface_dispositivo.Receber_dados( this, _dados ); }
            public void Ativar_metodo( int _metodo_id,  object[] _argumentos ){  interface_dispositivo.Ativar_metodo( this,  _metodo_id,  _argumentos );  }


            public void Change_update_lock( bool _lock ){ update_bloqueado = _lock; }
            public void Change_moviment_lock( bool _lock ){ movimento_bloqueado = _lock; }


            public void Esconder_dispositivo(){}

            
            public void Finalizar_dispositivo(){ interface_dispositivo.Finalizar( this ); }
            public void Free_resources(){ /* fazer */ }



            // --- METODOS VISUAIS


                public void Set_device_parent( GameObject _pai ){ SUPPORT__device_parent.Mudar_pai_dispositivo( _pai, this ); return; }
                public void Move_device( float _quantidade_para_adicionar_X, float _quantidade_para_adicionar_Y ){if( movimento_bloqueado){ return; } SUPPORT__moviment_device.Mover_dispositivo( _quantidade_para_adicionar_X,  _quantidade_para_adicionar_Y, this ); }
                public void Set_device_position( float _quantidade_para_adicionar_X, float _quantidade_para_adicionar_Y ){if( movimento_bloqueado){ return; } SUPPORT__moviment_device.Mover_dispositivo( _quantidade_para_adicionar_X,  _quantidade_para_adicionar_Y, this ); }




        // --- METODOS UTILIDADES CONSTRUCTIONS

            // --- DECLARE UI
            public Dados_imagem_estatica_dispositivo Declare_image( ref Imagem_estatica_dispositivo imagem_estatica ){ return dados_dispositivo.Declare_image_container( ref imagem_estatica ); }
            public Dados_botao_dispositivo Declare_button( ref Botao_dispositivo _botao_slot ){ return dados_dispositivo.Declare_button( ref _botao_slot ); }
            

            // --- FLUXO DE CONSTRUCAO

            // ** Declare() é sempre automatico
            public void Define_all_components(){ dados_dispositivo.Define_all_components(); return; }
            public void Load_resources(){ dados_dispositivo.Load_resources(); return; }
            public void Instanciate_device( GameObject _local_para_anexar ){ TOOL__device.Instanciate_device( this, _local_para_anexar ); }


            //mark 
            // ** tem que fazer os metodos para o unload

            

       
    
}