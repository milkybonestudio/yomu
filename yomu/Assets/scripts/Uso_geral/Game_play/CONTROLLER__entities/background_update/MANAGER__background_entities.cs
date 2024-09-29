using System;

/*

    update BACKGROUND: 

        => update kingdoms
            => UPDATE CADA ESTADO DE CADA REINO
                => UPDATE CADA CIDADE DE CADA ESTADO
                    => CARREGA E SIMULA PERSOANGENS NA CIDADE 
                        => UPDATE PLOT DEPENDENDO DE CADA PERSONAGEM/CIDADE 
                            => UNLOAD PERSONAGENS 

        a cidade que o player esta vai ser uma exceção. 
        normalmente cada cidade no background vai rodar passar frame 5 vezes em sequencia. a cidade do player vai esperar

*/

/*

        todos os reinos e estados vão estar sempre carregados

        no update o jogo vai fixar 1 reino e finalizar ele 
        cada reino vai pegar 1 estado e finalizar ele 
        cada estado vai pegar 1 cidade e finalizar 
        cada cidade vai pgar todos os personagens e finalizar 

        a logica é que cada bloco n precisa ter os dados dos subblocos[ n-1 ]
        para nao usar muita memoria o jogo nao vai carregar todas as cidades mas somente as necessarias para completar 1 estado
        como cidades de estados diferentes nao influenciam umas as outras elas não estão conectadas
        assim eu aidna vou poder carregar somente o necessario ( pouca memoria ) e vou deixar o processo bem padronizado ( pouca complexidade )



*/


public class MANAGER__background_entities {


    public MANAGER__background_entities(){



    }

    public MODULE__kingdoms_background_update kingdom_background_update;
    public MODULE__states_background_update states_background_update;
    public MODULE__characters_background_update characters_background_update;
    public MODULE__cities_background_update cities_background_update;


    // ** SEMPRE CARREGADOS ( do estado atual )
    public City[] cities;


    public Kingdom current_kingdom_update;
    public State current_state_update;
    public City current_city_update;
    public Character[] characters;


    
    public Background_entities_update_state state;
    public Background_entities_update_stage stage_update;


    public void Update(){

        switch( state ){

            case Background_entities_update_state.nothing_to_do: return;
            case Background_entities_update_state.waiting_data: Check_data(); return;
            case Background_entities_update_state.ready_for_check: Check_update(); return;

        }

    }

    private void Check_update() {



    }

    private void Check_data(){



    }




    // --- OPERATIONS


    // ** GET ENTITY

    public Character Get_character( int _character_id ){ return TOOL__get_entity_container.Get_character( characters, _character_id ); }
    public City Get_city( int _city_id ){ return TOOL__get_entity_container.Get_city( cities, _city_id ); }
    

    // ** GET ENTITIES

    public Character[] Get_characters( int[] _character_id ){ return TOOL__get_entities_container.Get_characters( characters, _character_id ); }
    public City[] Get_cities( int[] _city_id ){ return TOOL__get_entities_container.Get_cities( cities, _city_id ); }


}

public enum Background_entities_update_state{

    nothing_to_do, // quando mudar o periodo vais sempre forçar para ready_for_checks
    ready_for_check,
    waiting_data,

}


public enum Background_entities_update_stage{


        nothing, 
        update_kingdom,
        update_state,
        update_city, 
        update_characters, // personagens atualizam os plots também 

}


unsafe public struct Kingdom{}
unsafe public struct State{}