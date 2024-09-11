using System.Collections.Generic;

public class MODULO__lixeira_entidades {

    public MODULO__lixeira_entidades( Tipo_entidade _tipo ){

        

    }

    public Dictionary<int, Dados_para_salvar> entidades_para_salvar = new Dictionary<int, Dados_para_salvar>();

    public void Adicionar_entidade( Localizador_entidade _entidade_localizador, Dados_para_salvar _dados ){

            if( entidades_para_salvar.ContainsKey( _entidade_localizador.indentificador ) )
                { throw new System.Exception(); }
            

    }

    public bool Verificar_entidade_na_lixeira( Localizador_entidade _entidade_localizador, ref Dados_para_salvar _dados ){

            bool tem_a_entidade = entidades_para_salvar.ContainsKey( _entidade_localizador.indentificador );
        
            if( tem_a_entidade )
                { _dados = entidades_para_salvar[ _entidade_localizador.indentificador ]; }

            return tem_a_entidade;

    }


}