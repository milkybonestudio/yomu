


public interface INTERFACE__dispositivo {




        public void Definir_objetos_iniciais( Dispositivo dispositivo ){ throw new System.Exception( $"Na INTERFACE__dispositivo { Pegar_nome() } nao foi mudado o metodo Defini_imagens() mas ele foi chamado" ); }
        
  

        // --- METODOS INTERNOS
        public void Update( Dispositivo _dispositivo ){ throw new System.Exception($"Na INTERFACE__dispositivo { Pegar_nome() } nao foi mudado o metodo Update() mas ele foi chamado"); }
        public System.Object Enviar_dados( Dispositivo _dispositivo ){ throw new System.Exception($"Na INTERFACE__dispositivo { Pegar_nome() } nao foi mudado o metodo Enviar_dados() mas ele foi chamado"); }
        public void Receber_dados( Dispositivo _dispositivo, System.Object _dados ){ throw new System.Exception( "Na INTERFACE__dispositivo nao foi mudado o metodo Receber_dados() mas ele foi chamado" ); }
        public void Finalizar( Dispositivo _dispositivo ){ throw new System.Exception($"Na INTERFACE__dispositivo { Pegar_nome() } nao foi mudado o metodo Finalizar() mas ele foi chamado"); }

        //public Dispositivo Construir( UnityEngine.GameObject _pai  /* args */  ){ throw new System.Exception($"Na INTERFACE__dispositivo { Pegar_nome() } nao foi mudado o metodo Construir() mas ele foi chamado"); }

        public string Pegar_nome(){ throw new System.Exception($"Na INTERFACE__dispositivo nao foi mudado o metodo Pegar_nome() mas ele foi chamado"); }
        public string[] Pegar_folders(){ throw new System.Exception($"Na INTERFACE__dispositivo { Pegar_nome() } nao foi mudado o metodo Pegar_folders() mas ele foi chamado"); }
        public System.Type Pegar_tipo_imagens(){ throw new System.Exception( "Na INTERFACE__dispositivo nao foi mudado o metodo Pegar_tipos_imagens() mas ele foi chamado" ); }
        public System.Type Pegar_tipo(){ throw new System.Exception( $"Na INTERFACE__dispositivo { Pegar_nome() } nao foi mudado o metodo Pegar_tipo() mas ele foi chamado"); }


        public void Ativar_metodo( Dispositivo _dispositivo, int _metodo_id,  object[] _argumentos ){ throw new System.Exception( $"Na INTERFACE__dispositivo { Pegar_nome() } nao foi mudado o metodo Ativar_metodo() mas ele foi chamado"); }
        public void Ativar_metodo_tipo( Dispositivo _dispositivo, int _metodo_id,  object[] _argumentos ){ throw new System.Exception( $"Na INTERFACE__dispositivo { Pegar_nome() } nao foi mudado o metodo Ativar_metodo_tipo() mas ele foi chamado"); }
        public void Ativar_metodo_categoria( Dispositivo _dispositivo, int _metodo_id,  object[] _argumentos ){ throw new System.Exception( $"Na INTERFACE__dispositivo { Pegar_nome() } nao foi mudado o metodo Ativar_metodo() mas ele foi chamado"); }


}