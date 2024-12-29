

public enum Tipo_instrucao {

    adicionar_interativo,

}


public class Instrucao {


        public Tipo_instrucao tipo;

        public Locator_position[] posicoes;
        public int[] interativos_ids;

        //public Item_localizador[] itens_localizadores;
        public Carta_localizador[] cartas_localizadores;
        public Minigame_localizador[] minigames_localizadores;


}

public class a {

    public static Locator_position Pegar_posicao(){



        if( true )
            {

                Script_localizador l = new Script_localizador();

                


                // Posicao nova_posicao = new Posicao();


                // Posicao nova_posicao = Pegar_nova_posicao( ( int ) CATEDRAL__ZONA__LOCAL__AREA__ponto.ponto  );

                // Posicao nova_posicao = Leitor__CATEDRAL_DO_SUL__.Pegar_posicao( "ponto" );
                // Posicao nova_posicao = new Posicao(); nova_posicao.cidade_no_trecho_id = 5;nova_posicao.trecho_id = 2; ( "ponto" );
                
                //   ( class 1 ) => ( class 2 )  => ( class 3 ) 

                 
                return new Locator_position();


            }
        



    }

    public static Instrucao[] b(){

            Instrucao[] instrucoes = new Instrucao[ 1 ]{ new Instrucao() };

            //instrucoes[ 0 ].posicoes[ 0 ] =  Leitor_interativos__CATEDRAL_DO_SUL__ZONA_LESTE__DORMITORIO_FEMININO__NARA_ROOM;

            return instrucoes;


    }

}