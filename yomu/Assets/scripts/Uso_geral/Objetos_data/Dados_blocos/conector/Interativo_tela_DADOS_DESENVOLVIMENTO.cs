
#if UNITY_EDITOR




        public class Interativo_tela_DADOS_DESENVOLVIMENTO {


                public Interativo_tela_DADOS_DESENVOLVIMENTO( int _index_id_int ){

                        interativo_id = ( byte ) _index_id_int ;
                }

                        
                public string nome = ""; // excluir depois


                public byte interativo_id;
                
                public int ponto_id;

                public Locator_position posicao;


                        
                // -- !!  os nomes vão ser colocados na classe com os dados para nao ter 2 classes gigantes !! --
                // ** quando for criar colocar o nome 
                public string enum_nome_interativo_DESENVOLVIMENTO; // SAINT_LAND___CATHEDRAL__DORMITORIO_FEMININO__interativo
                public string nome_insterativo_DESENVOLVIMENTO; // NARA_ROOM__up__janela

                public string nome_unico_para_imagem_DESENVOLVIMENTO;

                public string path_imagem; // vai faltar o _modelo + _numero + .png


                

                // vai ser usado para construir 

                public Tipo_interativo_tela tipo_interativo;
                public Interativo_funcao[] interativo_funcoes;
                public Dados_interativo_funcoes_DEVELOPMENT dados_interativo_funcoes_DEVELOPMENT = new Dados_interativo_funcoes_DEVELOPMENT();





                // --- SUPORTE PARA A IMAGEM DO INTERATIVO

                public Metodo_FOLDER_que_as_imagens_estao_salvas metodo_FOLDER_que_as_imagens_estao_salvas; // default => contexto ponto
                public Metodo_que_as_imagens_estao_salvas metodo_que_as_imagens_estao_salvas;
                public string[] nomes_imagens_especificas_periodos = new string[]{  "", "", "", "", ""  };

                public Metodo_IMAGENS_DISPONIVEIS_no_mouse_hover metodo_IMAGENS_DISPONIVEIS_no_mouse_hover;
                public Metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover metodo_das_CORES_IMAGENS_disponiveis_no_mouse_hover;

                // so vai ser usado dependendo do Metodo_que_as_imagens_lidam_com_mouse_hover
                public Nome_cor cor_primeira_imagem;
                public Nome_cor cor_segunda_imagem;
                public Nome_cor cor_imagens;


                // --- SUPORTE PARA O CURSOR
                
                public Metodo_para_mudar_cursor metodo_para_mudar_cursor;

                public Cor_cursor[] cores_cursor;
                public Cor_cursor cor_cursor;

                // --- SUPORTE PARA SOM



                public float[] area;
                




        }

#endif