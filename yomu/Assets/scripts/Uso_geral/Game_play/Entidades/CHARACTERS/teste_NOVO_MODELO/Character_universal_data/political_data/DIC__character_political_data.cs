
public class DIC__character_political_data {


        #if UNITY_EDITOR 

            static DIC__character_political_data(){


                if( social_scores_kingdoms <= System.Enum.GetValues( typeof( Reino_nome ) ).Length )
                    { throw new System.Exception(); }

            }


        #endif


        public const int social_specific_attributes = 20;
        
        public const int social_scores_kingdoms = 20; // numero maximo de regioes com scores diferentes 
        

}

