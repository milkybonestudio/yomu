public class Ponto_data {

        
        public int ponto_id;
        public string folder_path;

        public bool tem_flip = false;
        public int ponto_flip = -1;


        public Interativo_nome[][] interativos_default_2d;


        public Tipo_get_ponto_data tipo_get_interativos_default;


        public string background_default_name;
        public Tipo_get_ponto_data tipo_get_background;


        // ??
        //mark
        public static string Pegar_nome_background_por_script( Ponto_nome _ponto_nome ){ return null;}
        public static Interativo_nome[] Pegar_interativos_por_script (Ponto_nome _ponto_nome){  return null;  }
        

    
}


