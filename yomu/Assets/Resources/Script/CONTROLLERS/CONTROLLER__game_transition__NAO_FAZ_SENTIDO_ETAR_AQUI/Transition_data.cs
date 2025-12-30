

public class Transition_data {

    // ** coisas que pode mudar na programação



    // --- UIS

    //mark
    // ** para simplificar as uis vao ser sempre no mesmo formato
    // ** se uma UI precisa para o proximo modo e ela já esta nesse ela nao se mexe
    // ** se nao precisa ela sai no up
    // ** novas entram no down ( já tem os recursos )

    // ** como default as UIs sempre vão ser colocadas no container_UI_above, vai dar o sentimento qeu UIs estão em um outro plano

    // ** posições podem mudar, como?
    // ** 


    // ** ordem vai ser position -> especifico
    // ** se uma UI estiver no new mode, mas for deixada no old e ela estiver no meio da tela em um fade -> o item vai desaparecer enquanto estiver tendo a animação mas quando o Down acabar todas as UIs vão ir para o plano do new

    // ** UIs que não estao no novo modo como default vão ser desligadas. Isso pode mudar?
    // ** Uma UI poderia estar ativa no old -> vai estar no new-> ficar no plano do old -> ser dado hide( instant ) quando terminar o down -> vai estar no segundo mas sem aparecer
    // ** eu nao tenho ideia de onde eu posso usar isso 
    // ** pensar nisso depois quando surgir algo

    public Transition_data_UI_position old_UI_position;
    public Transition_data_UI_position new_UI_position;

    public Transition_data_specific_UI_position[,] specific_UI_positions = new Transition_data_specific_UI_position[ 2, 10 ]; // old/new , thing

    
}

public struct Transition_data_specific_UI_position { 

        public int UI_id;
        public Transition_data_UI_position position;

}

