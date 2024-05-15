using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;







 public class Controlador_configuration {


    public static Controlador_configuration instancia;
    public static Controlador_configuration Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Controlador_configuration")) { instancia = new Controlador_configuration();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Controlador_configuration(); instancia.Iniciar(); }
            return instancia;

    }




        public bool full_screen;


        public float volume;
        public Tipo_construcao_texto tipo_texto;
        public string music_login;


        public string menu_background;
        public string music_menu;

        public string login_background;

        public Bloco[] save_tela_atual = new Bloco[5];


        public bool[] characters_liberados = new bool[7];

        public enum Characters_liberados{

                maki = 1,
                lily = 2,
                riku = 3, 
                dia = 4,
                takeru = 5,
                jayden = 6,

        }

        // public  bool menu_is_maki_unlock;
        // public  bool menu_is_connor_unlock;
        // public  bool menu_is_eden_unlock;
        // public  bool menu_is_dia_unlock;
        // public  bool menu_is_lily_unlock;
        // public  bool menu_is_jayden_unlock;
        // public  bool menu_is_noah_unlock;


        public  bool save_1_is_active;
        public  bool save_2_is_active;
        public  bool save_3_is_active;
        public  bool save_4_is_active;
   

        public  int  save_1_time;
        public  int  save_2_time;
        public  int  save_3_time;
        public  int  save_4_time;
       

        public  int  save_1_progress;
        public  int  save_2_progress;
        public  int  save_3_progress;
        public  int  save_4_progress;



//                           aumentar quando necessario
        public bool[] galeria_imagens_liberadas = new bool[6]; 
        public enum Galeria_imagens_localizador {
                   


        }



        //public int save_to_load = 0;



        public void Salvar_configurations(){

          string path = Controlador_data.Pegar_instancia().Pegar_path_raiz() + "/configurations.txt";
          string[] lines = System.IO.File.ReadAllLines(path);

         int i = 1;
         

        lines[i] = full_screen.ToString();i += 2;
        lines[i] = volume.ToString(); i += 2;
        lines[i] = tipo_texto.ToString();i += 2;
        lines[i] = login_background.ToString(); i += 2;
        lines[i] = music_login.ToString();i += 2;
        lines[i] = menu_background.ToString();i += 2;
        lines[i] = music_menu.ToString();i += 2;


        i += 2;


        lines[i] = characters_liberados[0].ToString();i += 2;
        lines[i] = characters_liberados[1].ToString();i += 2;
        lines[i] = characters_liberados[2].ToString();i += 2;
        lines[i] = characters_liberados[3].ToString();i += 2;
        lines[i] = characters_liberados[4].ToString();i += 2;
        lines[i] = characters_liberados[5].ToString();i += 2;
        lines[i] = characters_liberados[6].ToString();i += 2;

        i += 2;


        lines[i] = save_1_is_active.ToString();i += 2;
        lines[i] = save_2_is_active.ToString();i += 2;
        lines[i] = save_3_is_active.ToString();i += 2;
        lines[i] = save_4_is_active.ToString();i += 2;

        i += 2;

        lines[i] = save_1_time.ToString();i += 2;
        lines[i] = save_2_time.ToString();i += 2;
        lines[i] = save_3_time.ToString();i += 2;
        lines[i] = save_4_time.ToString();i += 2;
       
        i += 2;

        lines[i] = save_1_progress.ToString();i += 2;
        lines[i] = save_2_progress.ToString();i += 2;
        lines[i] = save_3_progress.ToString();i += 2;
        lines[i] = save_4_progress.ToString();i += 2;
         

         i += 2;


         
        for(   int imagem_galeria = 0; imagem_galeria < galeria_imagens_liberadas.Length - 1 ;  imagem_galeria++){

                        if(  galeria_imagens_liberadas[imagem_galeria]) {lines[i] += "1," ;} else { lines[i] += "0," ;};

        }

        if(  galeria_imagens_liberadas[galeria_imagens_liberadas.Length - 1 ]) {  lines[i] += "1" ;}else{lines[i] += "0" ;};



         File.WriteAllLines(path, lines);








        }




        public void Mudar_tipo_texto( Tipo_construcao_texto _novo_tipo_texto ){

                /*
                *  pode depois ter algo tipo Atualizar_controladores_texto(); dai todo novo controlador texto ficaria em um controlador_texto[];
                */


              //  controlador.controlador_tela.controlador_texto.tipo_texto = _novo_tipo_texto;
                tipo_texto = _novo_tipo_texto;


                return;
        }


        public void Mudar_volume(float _novo_volume){


                //  %
                volume = _novo_volume;


                float volume_convertido = volume / 100f;


                Controlador_audio.Pegar_instancia().Alterar_volume_mixer(   Tipo_audio.master , volume_convertido);

                return;



        }




        public void Iniciar(){

                Controlador_audio.Pegar_instancia(true);


                string path_raiz = Controlador_data.Pegar_instancia().Pegar_path_raiz();
                string path = path_raiz + "/arquivos_mutaveis/configurations.txt" ;

                // Debug.Log(path);
                // Debug.Log(System.IO.File.Exists(path));
                // throw new ArgumentException("a");

                string[] lines = null ;


                lines = Resources.Load<TextAsset>("files/configurations_default").text.Split("\r\n") ; 

                // trocar depois, muito trampo e pode dar erro 





                // if(  !System.IO.File.Exists( path ) ) {

                
                //         lines = Resources.Load<TextAsset>("files/configurations_default").text.Split("\r\n") ; 
                //         System.IO.File.WriteAllLines( path , lines ) ;
                //         Debug.Log( " vai salvar em : " + path  ) ;


                // } else {

                //         lines = System.IO.File.ReadAllLines( path ) ;

                // }



                lines_arr_config = lines;

                int i = 1;
                
                // Debug.Log("i: " + i);
                // Debug.Log("line: " + lines[i]);
                // Debug.Log("line[0]: " + lines[0]);
                  
                full_screen = Convert.ToBoolean(lines[i].Trim());Passar(ref i);

                volume = Convert.ToSingle(lines[i].Trim());Passar(ref i);

                Mudar_volume(volume);

                tipo_texto =   ( Tipo_construcao_texto ) ( Enum.Parse( typeof( Tipo_construcao_texto )   , lines[i].Trim() )  ) ;       Passar(ref i);

                login_background = lines[i].Trim() ;Passar(ref i);
                music_login = lines[i].Trim();Passar(ref i);
                menu_background = lines[i].Trim();Passar(ref i);
                music_menu = lines[i].Trim();Passar(ref i);


                //  localizador: 
                Passar(ref i);

                characters_liberados[0] = Convert.ToBoolean(lines[i].Trim());Passar(ref i);  
                characters_liberados[1] = Convert.ToBoolean(lines[i].Trim());Passar(ref i);
                characters_liberados[2]= Convert.ToBoolean(lines[i].Trim());Passar(ref i);
                characters_liberados[3]= Convert.ToBoolean(lines[i].Trim());Passar(ref i);
                characters_liberados[4]= Convert.ToBoolean(lines[i].Trim());Passar(ref i);
                characters_liberados[5]= Convert.ToBoolean(lines[i].Trim());Passar(ref i);
                characters_liberados[6]= Convert.ToBoolean(lines[i].Trim());Passar(ref i);


                //  localizador: 
                Passar(ref i);



                save_1_is_active= Convert.ToBoolean(lines[i].Trim());Passar(ref i);
                save_2_is_active= Convert.ToBoolean(lines[i].Trim());Passar(ref i);
                save_3_is_active= Convert.ToBoolean(lines[i].Trim());Passar(ref i);
                save_4_is_active= Convert.ToBoolean(lines[i].Trim());Passar(ref i);
               


                //  localizador: 
                Passar(ref i);



                save_1_time = Convert.ToInt32(lines[i].Trim());Passar(ref i);
                save_2_time = Convert.ToInt32(lines[i].Trim());Passar(ref i);
                save_3_time= Convert.ToInt32(lines[i].Trim());Passar(ref i);
                save_4_time= Convert.ToInt32(lines[i].Trim());Passar(ref i);



                 //  localizador: 
                Passar(ref i);



                save_1_progress = Convert.ToInt32(lines[i].Trim());Passar(ref i);
                save_2_progress = Convert.ToInt32(lines[i].Trim());Passar(ref i);
                save_3_progress= Convert.ToInt32(lines[i].Trim());Passar(ref i);
                save_4_progress= Convert.ToInt32(lines[i].Trim());Passar(ref i);
                


                //  localizador: 
                Passar(ref i);

                string[] galeria_imagens = lines[i].Split(",");


                for(   int imagem_galeria = 0; imagem_galeria < galeria_imagens_liberadas.Length ;  imagem_galeria++){

                        if(  galeria_imagens[imagem_galeria].Trim() !=  "0" ) galeria_imagens_liberadas[  imagem_galeria ] = true;

                }


                //  localizador: 
                Passar(ref i);






                //                  ?
                lines_arr_config = null;





        }

        public bool ler_dados = false;
        public string[] lines_arr_config;






        public void Passar(ref int i){

                if(ler_dados) Debug.Log( lines_arr_config[i - 1] + " : " +  lines_arr_config[i]);
                i = i + 2;

                return;
        }


      

}