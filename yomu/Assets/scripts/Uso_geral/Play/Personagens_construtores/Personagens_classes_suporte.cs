using System.Collections;
using System.Collections.Generic;
using UnityEngine;









public class Stats_relacionamento{

   public Stats_relacionamento(float  _tesao, float _amizade , float _amor , float _odio){

      this.tesao = _tesao;
      this.amizade = _amizade;
      this.amor = _amor;
      this.odio = _odio; 

   }

    public Stats_relacionamento(){

   }

   public float tesao = 100f;
   public float amizade = 100f;
   public float amor = 100f;
   public float odio = 100f;


}



public class Relacoes{

    public Stats_relacionamento sara;
    public Stats_relacionamento lily;
    public Stats_relacionamento jayden;
    public Stats_relacionamento eden;
    
}




public class Dados_combate{



    


}