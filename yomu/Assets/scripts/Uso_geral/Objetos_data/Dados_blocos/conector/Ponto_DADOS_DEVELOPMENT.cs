
#if UNITY_EDITOR 

    public class Ponto_DADOS_DEVELOPMENT {

            // aqui vao estar os dados default de cada ponto 

            public Ponto_DADOS_DEVELOPMENT( int _id ){

                ponto_id = _id;

            }

            public int ponto_id;

            //public Posicao_local posicao_local;

            public Posicao posicao;
            public string regiao_nome;
            public string trecho_nome;
            public string cidade_no_trecho_nome;
            public string zona_nome;
            public string local_nome;
            public string area_nome;
            public string ponto_nome;
            



            // usado para pegar 
            public string nome_ponto_DEVELOPMENT; 
            public string enum_nome_ponto_DEVELOPMENT;

            public string imagem_principal_nome;
            public int imagem_principal_id;

            public string[] background_imagens_suporte_nomes;
            public int[] background_imagens_suporte_ids;
            public int[][] posicoes_imagens_suporte; 


            public Metodo_interativos_default metodo_interativos_default;
            public int[][] interativos_ids;
            


            public string[] interativos_tipo_item_nomes; // Precisa?

            public string[] interativos_tipo_tela_nomes;


    }

#endif
