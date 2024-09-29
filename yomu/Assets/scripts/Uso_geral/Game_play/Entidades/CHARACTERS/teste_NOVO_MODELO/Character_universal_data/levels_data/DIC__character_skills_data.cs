
public class DIC__character_skills_data {

        #if UNITY_EDITOR

            static DIC__character_skills_data(){

                    if( level_numbers <= System.Enum.GetValues( typeof( Habilidade ) ).Length )
                        { throw new System.Exception(); }

            }

        #endif

        public const int level_numbers = 40;


}

