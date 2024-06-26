





public class Req_mudar_UI {



        public Req_mudar_UI( Tipo_UI _novo_tipo = Tipo_UI.nada , bool[] _UI_partes = null , bool _instantaneo = false ){

                this.novo_tipo_UI = _novo_tipo ;
                this.UI_partes = _UI_partes ;
                this.instantaneo = _instantaneo ;
                
        }

        public Tipo_UI novo_tipo_UI;
        public bool[] UI_partes;
        public bool instantaneo = false;

}
