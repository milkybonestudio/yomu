using System;
using UnityEngine;




public class Controlador_sistema {

        public static Controlador_sistema instancia;
        public static Controlador_sistema Pegar_instancia(){ return instancia; }


        // --- CONTROLADORES

        public Controlador_personagens controlador_personagens;
        public Controlador_cidades controlador_cidades;
        public Controlador_plots controlador_plots;


        // --- GERENCIADORES 

        public Gerenciador_sistema_estado_atual gerenciador_sistema_estado_atual;
        public Gerenciador_player gerenciador_player;
        public Gerenciador_save_dados_sistema gerenciador_save;


        // --- DADOS 

        // ** pega de todos
        public Dados_sistema_personagem_essenciais[] dados_personagens_essenciais;
        public Dados_sistema_cidade_essenciais[] dados_cidades_essenciais;
        public Dados_sistema_plot_essenciais[] dados_plots_essenciais;

        // ** pega somente dos personagens ativos 
        public Dados_sistema_personagem[] dados_personagens;
        public Dados_sistema_cidade[] dados_cidades;
        public Dados_sistema_plot[] dados_plots;



        // --- ENTIDADES_PARA_ADICIONAR


                // ** personagem
		public int[] personagens_pentendes_para_adicionar;
		public int[] personagens_pentendes_para_adicionar_local;
		public int[] personagens_pentendes_para_adicionar_tempo;

                // ** cidades        
                public int[] cidades_segundo_plano_pentendes_para_adicionar;
                public int[] cidades_segundo_plano_pentendes_para_adicionar_tempo;


                // ** plots 
                public int[] plots_pentendes_para_adicionar;
                public int[] plots_pentendes_para_adicionar_tempo;



        public static Controlador_sistema Construir( Dados_sistema_estado_atual _dados_sistema_estado_atual ){

                Controlador_sistema controlador  = new Controlador_sistema();

                        // --- CRIR CONTROLADORES 
                        controlador.controlador_personagens = Controlador_personagens.Pegar_instancia();
                        controlador.controlador_cidades = Controlador_cidades.Pegar_instancia();
                        controlador.controlador_plots = Controlador_plots.Pegar_instancia();

                        // --- CRIAR GERENCIADORES 

                        controlador.gerenciador_sistema_estado_atual = new Gerenciador_sistema_estado_atual( controlador );
                        controlador.gerenciador_player = new Gerenciador_player( _dados_sistema_estado_atual );
                        controlador.gerenciador_save = new Gerenciador_save_dados_sistema( controlador );


                        // --- PEGAR DADOS

                        controlador.dados_personagens_essenciais = Controlador_personagens.Pegar_instancia().dados_sistema_personagens_essenciais;
                        controlador.dados_cidades_essenciais = Controlador_cidades.Pegar_instancia().dados_sistema_cidades_essenciais;
                        controlador.dados_plots_essenciais = Controlador_plots.Pegar_instancia().dados_sistema_plots_essenciais;

                        controlador.dados_personagens = Controlador_personagens.Pegar_instancia().dados_sistema_personagens;
                        controlador.dados_cidades = Controlador_cidades.Pegar_instancia().dados_sistema_cidades;
                        controlador.dados_plots = Controlador_plots.Pegar_instancia().dados_sistema_plots;

                	controlador.personagens_pentendes_para_adicionar =  _dados_sistema_estado_atual.personagens_pentendes_para_adicionar;
			controlador.personagens_pentendes_para_adicionar_local =  _dados_sistema_estado_atual.personagens_pentendes_para_adicionar_local;
			controlador.personagens_pentendes_para_adicionar_tempo = _dados_sistema_estado_atual.personagens_pentendes_para_adicionar_tempo;


                        controlador.cidades_segundo_plano_pentendes_para_adicionar = _dados_sistema_estado_atual.cidades_segundo_plano_pentendes_para_adicionar;
                        controlador.cidades_segundo_plano_pentendes_para_adicionar_tempo = _dados_sistema_estado_atual.cidades_segundo_plano_pentendes_para_adicionar_tempo;

                        controlador.plots_pentendes_para_adicionar = _dados_sistema_estado_atual.plots_pentendes_para_adicionar;
                        controlador.plots_pentendes_para_adicionar_tempo = _dados_sistema_estado_atual.plots_pentendes_para_adicionar_tempo;



                instancia = controlador; 
                return controlador;

        }



        public byte[] Compilar_dados_sistema_atual(){
                        

                        Dados_sistema_estado_atual dados_estado_atual = gerenciador_sistema_estado_atual.Pegar_dados();
                        byte[] dados = Compilador_dados_sistema.Compilar( dados_estado_atual );
                        return dados;
        }


        public Dados_para_salvar Pegar_dados_para_salvar( Modo_save _modo ){

                // ** fazer 
                return null;

        }



        public void Preparar_plot_para_adicionar (  int _plano_id, int _plot_id , int _periodos_para_adicionar  ){

                controlador_plots.Carregar_dados_plot(  _plano_id,  _plot_id  );
        
                INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref plots_pentendes_para_adicionar , _plot_id );
                INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref plots_pentendes_para_adicionar_tempo , _periodos_para_adicionar );
                return;

        }
     


        public void Preparar_cidade_para_adicionar (  int _plano_id, int _cidade_id , int _periodos_para_adicionar  ){

                controlador_cidades.Carregar_dados_cidade(  _plano_id,  _cidade_id  );
        
                INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref cidades_segundo_plano_pentendes_para_adicionar , _cidade_id );
                INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref cidades_segundo_plano_pentendes_para_adicionar_tempo , _periodos_para_adicionar );
                return;

        }



        public void Preparar_personagem_para_adicionar (  int _plano_id, int _personagem_id, int _periodos_para_adicionar,  int _cidade_para_colocar ){

                controlador_personagens.Carregar_dados_personagem(  _plano_id,  _personagem_id,  _cidade_para_colocar );
        

                INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_pentendes_para_adicionar , _personagem_id );
                INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_pentendes_para_adicionar_local , _cidade_para_colocar );
                INT.Acrescentar_valor_COMPLETO_GARANTIDO( ref personagens_pentendes_para_adicionar_tempo , _periodos_para_adicionar );
                
                return;

        }
		





}