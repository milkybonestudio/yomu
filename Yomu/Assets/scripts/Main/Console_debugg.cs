using UnityEngine;
    

        public class ConsoleToGUI : MonoBehaviour {




            public bool tela_aparente = false;
            private int trava = 1;
            static string myLog = "";
            private string output;
            private string stack;
    
            void OnEnable(){

               Application.logMessageReceived += Log;

            }
    
            void OnDisable(){

                Application.logMessageReceived -= Log;

            }

            void Start(){

                tela_aparente = false;
                  
            }

            void Update(){

                if(Input.GetKeyDown( KeyCode.F8 )) tela_aparente = !tela_aparente; 

            }
    
            public void Log(string logString, string stackTrace, LogType type){

                output = logString;
                stack = stackTrace;
                myLog = output + "\n" + myLog;
                if (myLog.Length > 5000) {

                    myLog = myLog.Substring(0, 4000);


                }
            }
            void OnGUI(){

               

                if(trava == 1){
                    trava++;
                    myLog = GUI.TextArea(new Rect(0, 0, 0, 0), myLog);
                    return;

                }

                    if(tela_aparente) {

                        

                        GUIStyle configs = new GUIStyle();
                    
                        configs.fontSize = 15;


                        GUI.TextArea(new Rect(0, 0, Screen.width /2, Screen.height /1),"" );
                        GUI.TextArea(new Rect(0, 0, Screen.width /4, Screen.height /1), ("<color=green> " +   myLog + "</color>"   ) , configs);
                        GUI.backgroundColor = Color.blue;
                        return;

                    }

                    myLog = GUI.TextArea(new Rect(0, 0, 0, 0), myLog);

                   

                  


                            
                    
                            
            }
    
        }
