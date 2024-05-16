

using UnityEngine;
using System;




public class Drop_objeto{

    
    public Itens_localizador[] drops_lista;
    public float[] drop_chances;



     public void Pegar_drop(){


        for(  int drop_index = 0;  drop_index  < drops_lista.Length   ; drop_index++ ){

                 float chance = Mat.Pegar_chance();

                if(  chance   <=   drop_chances[drop_index]  )  {
                    //Debug.Log("chance: " + chance);

                        Itens_localizador item = drops_lista[drop_index] ;

                        int loot_length = BLOCO_plataforma.Pegar_instancia().loot_atual.Length;

                        Itens_localizador[] loot_atual =  BLOCO_plataforma.Pegar_instancia().loot_atual;
                        int[] loot_quantidade =   BLOCO_plataforma.Pegar_instancia().loot_quantidade;

                        
                        for(int _i = 0 ;  _i <  loot_length  ; _i++ ){

                                if (loot_atual[_i] ==  item ){

                                        loot_quantidade[_i] += 1;
                                        break;

                                }

                                if(loot_atual[_i]  == Itens_localizador.VAZIO ){
                                  

                                        loot_atual[_i] =  item;
                                        loot_quantidade[_i] += 1;
                                        break;

                                }

                                if(_i == loot_length - 1){

                                  Debug.Log(loot_length);

                                  // chegou no limite e precisa de mais espaço


                                   Itens_localizador[] novo_loot_atual = new Itens_localizador[loot_length + 10];
                                   int[] novo_loot_quantidade =   new int[loot_length + 10];

                                   Array.Copy(loot_atual , novo_loot_atual, loot_length);
                                   Array.Copy(loot_quantidade , novo_loot_quantidade, loot_length);


                                   novo_loot_atual[loot_length] = item;
                                   novo_loot_quantidade[loot_length] = 1;
                                   break;

                                }
                        }
                }
        }

      
    }
    


}