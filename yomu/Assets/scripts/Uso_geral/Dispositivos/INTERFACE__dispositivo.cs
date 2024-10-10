


public interface INTERFACE__dispositivo {




        public void Declare_components( Dispositivo dispositivo );
        
  

        // --- METODOS INTERNOS
        public void Update( Dispositivo _dispositivo ){ throw new System.Exception($"Na INTERFACE__dispositivo { Get_name() } nao foi mudado o metodo Update() mas ele foi chamado"); }
        public System.Object Enviar_dados( Dispositivo _dispositivo ){ throw new System.Exception($"Na INTERFACE__dispositivo { Get_name() } nao foi mudado o metodo Enviar_dados() mas ele foi chamado"); }
        public void Receber_dados( Dispositivo _dispositivo, System.Object _dados ){ throw new System.Exception( "Na INTERFACE__dispositivo nao foi mudado o metodo Receber_dados() mas ele foi chamado" ); }
        public void Finalizar( Dispositivo _dispositivo ){ throw new System.Exception($"Na INTERFACE__dispositivo { Get_name() } nao foi mudado o metodo Finalizar() mas ele foi chamado"); }

        //public Dispositivo Construir( UnityEngine.GameObject _pai  /* args */  ){ throw new System.Exception($"Na INTERFACE__dispositivo { Get_name() } nao foi mudado o metodo Construir() mas ele foi chamado"); }

        public string Get_name(){ throw new System.Exception($"Na INTERFACE__dispositivo nao foi mudado o metodo Get_name() mas ele foi chamado"); }

        public string Get_main_folder(){ throw new System.Exception($"Na INTERFACE__dispositivo { Get_name() } nao foi mudado o metodo Get_main_folder() mas ele foi chamado"); }
        
        public System.Type Pegar_tipo_imagens(){ throw new System.Exception( "Na INTERFACE__dispositivo nao foi mudado o metodo Pegar_tipos_imagens() mas ele foi chamado" ); }
        public System.Type Pegar_tipo(){ throw new System.Exception( $"Na INTERFACE__dispositivo { Get_name() } nao foi mudado o metodo Pegar_tipo() mas ele foi chamado"); }


        public void Ativar_metodo( Dispositivo _dispositivo, int _metodo_id,  object[] _argumentos ){ throw new System.Exception( $"Na INTERFACE__dispositivo { Get_name() } nao foi mudado o metodo Ativar_metodo() mas ele foi chamado"); }
        public void Ativar_metodo_tipo( Dispositivo _dispositivo, int _metodo_id,  object[] _argumentos ){ throw new System.Exception( $"Na INTERFACE__dispositivo { Get_name() } nao foi mudado o metodo Ativar_metodo_tipo() mas ele foi chamado"); }
        public void Ativar_metodo_categoria( Dispositivo _dispositivo, int _metodo_id,  object[] _argumentos ){ throw new System.Exception( $"Na INTERFACE__dispositivo { Get_name() } nao foi mudado o metodo Ativar_metodo() mas ele foi chamado"); }


        public void Define_all_UI_components(){ throw new System.Exception( $"Na INTERFACE__dispositivo { Get_name() } nao foi mudado o metodo Define_all_UI_components() mas ele foi chamado"); }


}