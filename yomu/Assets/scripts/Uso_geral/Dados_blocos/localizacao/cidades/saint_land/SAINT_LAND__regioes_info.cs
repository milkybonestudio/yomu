


public class Regiao_info {


    public string regiao_nome;
    public string regiao_descricao;

    
    // aparece quando o player passar o mouse
    public string[] regiao_comentarios;
    

    public Cidade_nome cidade_nome;
    public int[] regioes_ao_arredor_ids;
    public string[] regioes_ao_arredor_nomes;
    
    

    


}

    
#if ( UNITY_EDITOR && CIDADE_SAINT_LAND ) || FORCAR_TODOS_OS_ESTADOS || true

    public static class SAINT_LAND__regiao_info {


            


    }



#endif




