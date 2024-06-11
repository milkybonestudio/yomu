using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Personagens {


    public static Personagens instancia; 
    public static Personagens Pegar_instancia(){if(instancia == null){ instancia = new Personagens(); instancia.Iniciar();} return instancia;}

    public void Iniciar(){}

      

      public Sara   sara   =   new Sara();
      public Lily   lily   =   new Lily();
      public Dia    dia    =   new Dia();
      public Eden   eden   =   new Eden();
      public Jayden jayden =   new Jayden();

      




}



/*


    dados : 


    stats  => numeros 

    stats vao ser o resultado final de toda uma cadeia, tem variaveis como tesao, amor, amizade ou medo 
    ou pode ter variaveis de estado como relacao_atual: amizade. Parceiro_atual : Maki , Multiplos_parceiros : [ kuni, nia ] ...+ 





    acontecimentos => id + bool 
    acontecimentos podem ser publicos ou privados. privados 


     // o mundo vai ser um personagem que vai ter handlers de informacao publica, eu baixo somente 1 dll que vai difidir caso essa in

    acontecimentos :     


    Vai ter um objeto Mundo que vai lidar com casos que envolvam mais de 2 personagens.
    Cada personagem vai ter um objeto secundario que faz o handle de acontecimentos publicos. 
    

    Maki.Ativar_acontecimento_publico( id acontecimento  ){

          switch( acontecimento ){

            ...
            case Maki.nara_beijou_o_pe: Maki_1.dll => Nara_beijou_o_pe(); break;
            ...

          }

    }

    Maki_1 {

        void Nara_beijou_o_pe(){

          // tudo que precisar ser feito vai ser feito aqui. pode extender metodos tambem.


          oque pode dar um pouco de confusao é que para adicionar stats aqui nao vai ter acesso ao personagem em si porque a lista pode ser muito grande. 
          Para alteracoes pequenas pode nao ter diferenca mas ainda tem jeitos de modificar sem acesso as funcoes gerais. Por exemplo se nara beijou o pe de maki
          o quanto isso vai afetar a amizade dela com nia depende do nivel de amizade de nia com Nara. Talvez o tipo seja puramente estatico e seria facil de deixar carregado mesmo com muitos personagens 
          por exemplo: 

              logica: Nia vai perder mais amizade conforme mais a pessoa for amiga dela. 
              Poderia ter uma propriedade que definiria quais funcoes usar. 

              por exemplo


              tiipo.reta

              variaveis : alpha , x0


              |              o
              |            o
              |          o
              |        o
              |      o
              |    o
              |  o
              l______________________


              Tipo.exp positiva || negativca 


              |                    o              | o            
              |                    o              | o            
              |                   o               |  o           
              |                  o                |  o           
              |                oo                 |   o          
              |           oooo                    |     o         
              | o o o o o                         |       o o o o o o   
              l______________________             l______________________



              Tipo.log positiva


              |             oooooooo
              |       oooooo        
              |      o             
              |    oo              
              |   o             
              |  o          
              | o
              l______________________

              negativa

              | ooooooooo      
              |          ooooooo  
              |                 oo   
              |                   o 
              |                    o
              |                     o
              |                     o
              l______________________

              porem as funcoes simples vao sempre ser derivadas de  ( stat ) => stat


          tem 3 categorias que alguem personagem pode estar: 

          - isso é algo muito significativo => 
          - isso é algo significativo => pode gerar falas ou discordancias 
          - isso não é tão importante mas afeta alguns stats 
          - nao afeta / nao sabe 

          se nao aparece aqui é porque nao afeta ou porque o personagem nao sabe 
          se o personagem nao sabe mas é importante o modificador vai estar no handle proprio do persoangem, e quando nara contar para o persoangem o modificador é ativado 


          se nao afetar muito vai ser uma funcao simples como: 
          add( Nia, amizade : -20 , tesao : -10  )
          

          

          Add( Connor, amizade , -100 );



        }

    }

    cada personagem vai ter um bloco dentro do mundo. Porque nao fica especifico de cada personagem?

    

    acontecimentos com o personagem publicos
    acontecimentos terceiros publicos 




    acontecimentos com o personagem privados
    acontecimentos terceiros privados 





    kuni :


        dou um biscoito =>     +20 amizade => filtros kuni: || => cookie = [ doce ]; doce => +30 amizade || => 




    oque um personagem precisa fazer: 


      - adicionar acao personagem
      - adicionar acontecimento
      - dar presente 


     
      - atualizar dados internos. Add(  personagem , stat , numero  )


*/



// public class Personagem {


 
//     public float amizade = 500f;
//     public float tesao = 500f;




//   // todo personagem precisa ter a opiniao sobre a nara, mas poderia ter opinioes sobre outros personagens 



//       // quando o personagem inicia

//       public void Atualizar_entrada(){}

//       /*

//             connor => relativo com maki 

//               - Maki_nara_acontecimentos.nara_beijou_pe_de_maki ( privado )
//               - Maki_nara_acontecimentos.nara_desrespeitou_maki_em_publico ( publico )


//             conversa: connor x nara


//             updata() => connor tem que atualizar que nara beijou o pe de maki 

//                        op 1 : atualiza na interacao Maki x Nara quando teve a mudanca

//                                 => vai ter que fazer load das dlls com as informacoes de todos os personagens que tem ligacao com maki.Porem isso pode ser feito na multithread com baixa prioridade 
//                                 => o tempo seria numero_de_personagens * ( tempo / personagem ). 
//                                 => maki => [ minerva, cordelia, connor, ariel, rhead,   ]
//                                 => personagens importantes vao demorar muito para coisas publicas. Mas ao mesmo tempo eles vão ter poucas interacoes 
//                                 => na realidade personagens importantes vai ter que atualizar praticamente todo se for informacao publica 


//                        op 2 : atualiza na interacao Connor x Nara quando essa mudaca precisou realmente ser feita 



      
//       */


//       // run_time 

//       public void Sofrer_acao(){}
//       public void Causar_acao(){}


//       public void Falar(){}
//       public void Ouvir(){}


//       public void Dar(){}
//       public void Receber(){}


//       public void Entregar_relato(){}
//       public void Receber_relato(){}

//       // end 

//       public void Atualizar_saida(){}





// }


// public class Nia {

//   public Personagem generico;

// }