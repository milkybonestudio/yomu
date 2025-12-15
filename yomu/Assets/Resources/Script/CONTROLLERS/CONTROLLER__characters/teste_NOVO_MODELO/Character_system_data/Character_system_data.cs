

unsafe public struct Character_system_data {

        // ** usado para garantir que fois alvo corretamente. quando o player estiver no dia N se o personagem estiver em n-1 ele ainda nao foi atualizado
        // ** quando for salvar os personagens em disco precisa tomar cuidado. 
        //  eles precisam ser salvos em conjunto para fazer:
        //                                                   salvar arquivos_temp[]
        //                                                   mover arquivos[]( deletar )
        // ** se os istema for interrompido no meio ele consegue reconstruir
        

        public int day_background_update; // ** tem que atualizar mesmo que esteja no main


        // ** logica

        public byte core_logic_id;
        public byte script_stable_id_1; // 0=> nada 
        public byte script_stable_id_2; // 0=> nada 


        // ** plots
    
        // ** blocks 

        // ** triggers 


}




