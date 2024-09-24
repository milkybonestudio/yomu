

public interface INTERFACE__controlador_entidade {

        public string Pegar_nome(){ throw new System.Exception( "nao foi implementado Pegar_nome"); }
        public Tipo_entidade Pegar_tipo(){ throw new System.Exception( $"nao foi implementado Update no controlador { Pegar_nome() }"); }
        
        

        public void Update(){ throw new System.Exception( $"nao foi implementado Update no controlador{ Pegar_nome() }" );}
        public void Update_pass_time_frame(){ throw new System.Exception( $"nao foi implementado Update no controlador{ Pegar_nome() }" );}
        public void Load_entity( Locator_entidade[] _localizadores ){ throw new System.Exception( $"nao foi implementado Carregar_entidades no controlador{ Pegar_nome() }" );}
        public void Unload_entity( Locator_entidade[] _localizadores ){ throw new System.Exception( $"nao foi implementado Carregar_entidades no controlador{ Pegar_nome() }" );}

        // ** vai colocar os dados na lixeira
        public float Prepare_to_save_files(){ throw new System.Exception( $"nao foi implementado Update no controlador{ Pegar_nome() }" ); }
   
}




