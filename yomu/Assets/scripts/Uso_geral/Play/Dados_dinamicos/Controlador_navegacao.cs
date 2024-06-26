

public class Controlador_navegacao {

        public static Controlador_navegacao instancia;
        public static Controlador_navegacao Pegar_instancia(){ return instancia; }


        public int cidade_atual_id;
        public int[][][][] interativos_para_subtrair_ids;
        public int[][][][] interativos_para_acrescentar_ids;

        public int[][] posicoes_personagens 

        public int

        public static Controlador_navegacao Construir( Dados_sistema_estado_atual _dados_sistema_estado_atual ){

            Controlador_navegacao controlador = new Controlador_navegacao();

                controlador.interativos_para_acrescentar_ids  = _dados_sistema_estado_atual.interativos_para_adicionar_ids;
                controlador.interativos_para_subtrair_ids  = _dados_sistema_estado_atual.interativos_para_subtrair_ids;
                
            instancia = controlador;
            return controlador;


        }

    



}