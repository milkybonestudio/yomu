



public class Skill_info {

    public int xp = 0;
    public int cp_para_o_proximo_nivel;
    public int nivel = 0;

}


public static class Manipulador_niveis {


        public static bool Colocar_xp( Skill_info _skill,  int xp_atual, int _xp  ){

                int xp_para_o_proximo_nivel = SKILLS_DADOS.xp_para_o_proximo_nivel[ _skill.nivel ];

                _skill.xp += _xp;

                
                return ( _skill.xp >= xp_para_o_proximo_nivel );

            


        }



}