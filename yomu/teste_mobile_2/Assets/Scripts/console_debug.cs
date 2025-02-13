using UnityEngine;

    

public class Console_debug : MonoBehaviour {


        public bool tela_aparente;
        private int trava = 1;
        static string myLog = "";
        private string output;
        private string stack;

        public Color cor_bg;

        void OnEnable(){

            Application.logMessageReceived += Log;
            return;

        }

        void OnDisable(){

            Application.logMessageReceived -= Log;
            return;

        }

        void Start(){
            
            tela_aparente = true;
            texture = new Texture2D(1, 1);
                
        }

        void Update(){

            tela_aparente = true;

            // if( Input.GetKey( KeyCode.LeftControl ) &&  Input.GetKeyDown( KeyCode.D ) ) 
            //     { tela_aparente = !tela_aparente; }

            return;

        }


        public void Log( string logString, string stackTrace, LogType type){


                output = logString;
                stack = stackTrace;

                myLog = myLog + "\n" + output;

                if ( myLog.Length > 5000 )
                    { myLog = myLog.Substring( 0, 4000 ); }

                return;

        }

        public static void Limpar(){

            myLog = "";

        }


        public static Texture2D texture;


        void OnGUI(){

                

                if( trava == 1)
                    {
                        trava++;
                        myLog = GUI.TextArea(new Rect(0, 0, 0, 0), myLog);
                        return;
                    }

                if( tela_aparente) 
                    {

                        GUIStyle configs = new GUIStyle();

                        configs.fontSize = 55;

                        int numero_de_linhas = myLog.Split( "\n" ).Length;

                        if( numero_de_linhas > 25 )
                            { configs.fontSize -= 10; }

                        if( numero_de_linhas > 40 )
                            { configs.fontSize -= 7; }


                        
                        texture.SetPixel(0, 0, cor_bg );
                        texture.Apply();


                        configs.normal.background = texture;


                        //GUI.TextArea( new Rect( (Screen.width * 1 / 16), 0, ( Screen.width * 3 ) / 8 , Screen.height /1),"opcoes: " , configs);
                        GUI.backgroundColor = Color.blue;
                        GUI.TextArea( new Rect( (Screen.width * 5 / 16), 0, ( Screen.width * 3 ) / 8 , Screen.height /1), ("<color=black> " +   myLog + "</color>"   ), configs );

                        //GUI.TextArea(new Rect( 0, 0, Screen.width /4, Screen.height /1), ("<color=green> " +   myLog + "</color>"   )  );
                        
                        
                        return;

                    }


                myLog = GUI.TextArea(new Rect(0, 0, 0, 0), myLog);

                return;
            
                        
        }


        private string Inverter(){

            return null;

        }

}
