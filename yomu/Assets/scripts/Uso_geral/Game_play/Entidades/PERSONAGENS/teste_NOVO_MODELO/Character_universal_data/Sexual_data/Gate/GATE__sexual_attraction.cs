

unsafe public struct GATE__sexual_atraction_data {

        //  ** vai ser calculado periodicamente entre os personagens caso seja falso
        //  ** caso seja verdadeiro e retorno falso, vai lentamente perdendo a atraçao 

        // --- INFORMACOES PARA GATE
        // ** define se tem atracao ou nao
        // ** retorna no primeiro false

            // ** os dados que vao ser usados para verificacao são os dados que o personagem sabe sobre

                // --- ZERO
                // ** desvio de sistema
                // ** somente o sistema pode modificar essa categoria, provavelmente por plot
                // ** ele substitue completamente o formato da cascata e ignora como o personagem iria reagir
            public GATE__sexual_attraction_zero gate_sexual_attraction_zero;
             
                
                // --- PRIMEIRO
                // ** verifica coisas muito genericas
                // ** se um homem é gay e for verificar uma mulher vai sempre voltar false
            public GATE__sexual_attraction_first gate_sexual_attraction_first;


            
                // --- SEGUNDO
                // ** verifica coisas muito genericas
                // ** se um homem é gay e for verificar uma mulher vai sempre voltar false
            public GATE__sexual_attraction_second gate_sexual_attraction_second;
            

                // --- TERCEIRO
                // ** verifica coisas mais especificas que podem ser verificadas rapidamente
                // ** sempre vai verificar flags e status completos
                // ** fn comparar ( int  [ logica sobre assunto X do personagem Y] , int [ flags de bloqueio do personagem self ]){
                //         if ( [ logica sobre assunto X do personagem Y] & [ flags de bloqueio do personagem self ] != 0 ) => nao precisa bloquear                            
                // }
            public GATE__sexual_attraction_third gate_sexual_attraction_third;



                // --- QUARTO
                // ** vai ser muito mais especifico e pode usar logica estatica para verificar.
            public GATE__sexual_attraction_fourth gate_sexual_attraction_fourth;

}
