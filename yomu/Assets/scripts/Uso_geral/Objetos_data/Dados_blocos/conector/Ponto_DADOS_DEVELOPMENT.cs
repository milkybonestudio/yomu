
#if UNITY_EDITOR 

    public class Ponto_DADOS_DEVELOPMENT {

            // aqui vao estar os dados default de cada ponto 

            public Ponto_DADOS_DEVELOPMENT( int _id ){

                ponto_id = _id;

            }

            public int ponto_id;

            public Posicao_local posicao_local;

            // usado para pegar 
            public string nome_ponto_DEVELOPMENT; 
            public string enum_nome_ponto_DEVELOPMENT;

            public string imagem_principal_nome;
            public int imagem_principal_id;

            public string[] background_imagens_suporte_nomes;
            public int[] background_imagens_suporte_ids;
            public int[][] posicoes_imagens_suporte; 
            

            // um imagem de backgroun pode ser pega pelo enum quem leva até o ponto 
            
            // ou é possivel pegar com uma Posicao_local


            /*

                geralmente vai ter "/" para separar e colocar em um folder 
                entao se tiver o gernerico "folder/folder/up/" com "/ursinho"=> "folder/folder/"

            */

            

            public string[] interativos_tipo_personagem_nomes;
            public string[] interativos_tipo_item_nomes;

            public string[] interativos_tipo_tela_nomes;


    }

#endif
