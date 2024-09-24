

unsafe public struct GATE__sexual_attraction_first {

            // ** trigga a funcao que estiver com o maior valor 
            // ** essas funcoes vao ficar no proprio personagem ou no sistema, ele vai fazer um grande swithc para pegar essas funcoes. Eu nao quero depender muito delas 

            // ** funcoes basicas: algo pode colocar uma funcao generica ou pode ser do proprio personagem. colcoar flag?

            
            // --- PRIMARIO 
                public byte have_scripts;
                public fixed short locator_scripts[ 5 ]; // ( 1 bit => 0: sistema, 1: personagem ) ( 1 bit bloqueia => 0: nao, 1: sim ) ( 14 bits valor? => 15k possibilidades/parte )
                public fixed byte valor[ 5 ];  // 0 => nao tem

                // pode fazer um ( valor & 0b_0011_1111__1111_1111 ) para remover os 2 primeiros
                // ** os valores sempre vao estar de forma crescente e sempre que for adicionar/remover precisa reorganizar os valores 
                


}
