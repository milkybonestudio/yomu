using TMPro;
using UnityEngine;


public struct DATA_CREATION__UI_text_container {
    

        public Type_writing_construction tipo_texto;


        public Resource_context context;
        public string main_folder;
        

        public string initial_text;
        public int characters_per_frame;


        // ** vai preferir pegar do gameObject. Mas se o sistema quiser sobrepor, pode ser

        public Material material;
        public TMP_FontAsset font;

        public float font_size;
        public Color font_color;

        public bool has_over_flow;
        public TextOverflowModes over_flow;
        public void Put_over_flow( TextOverflowModes _over_flow ){ over_flow = _over_flow; }

        public bool has_aligment;
        public TextAlignmentOptions aligment;
        public void Put_over_flow( TextAlignmentOptions _aligment ){ aligment = _aligment; }

        public bool has_font_style;
        public FontStyles font_style;
        public void Put_over_flow( FontStyles _font_style ){ font_style = _font_style; }





        


}