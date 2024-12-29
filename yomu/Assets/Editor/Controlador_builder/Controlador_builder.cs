using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Build.Content;
using UnityEngine;


// todo processo tem chance de falhar por algum motivo, sempre garantir que se falhar o sistema volta para o modelo padrao
// ** criar arquvivos sempre tem que ser o ultimo dos processos, tentar criar e verificar se eles podem ser criados antes. 

// tem que garantir: 

// --- pre
        // --- VERIFICACOES
                //  - verificar se o modo dos dados esta compilado para build

                //  - criar todos os dados e colocar eles na memoria. personagens dados, pontos, screens plays, etc
                        // -> verifica se os dados fazem sentido: cores, mouses. etc 

                //  - verificar se todas as imagens existem nos folders conforme a logica. personagens, itens, etc. 
                        //ex :  CATEDRAL_DO_SUL__ZONA_LESTE.coisa => "folder_1/CATEDRAL_DO_SUL/ZONA_LESTE/coisa.png"

                
        // --- CONTAINERS

                //  - criar containers com os dados estaticos. imagens, screens plays, etc
                        // ** memoria

        
        // --- ARQUIVOS 
                //  - mover imagens do folder "imagens_prefabs_uso_editor"

                //  - criar lista com os paths de todos os arquivos
                //  - criar arquivos copias com nomes sempre termindando com "_BUILD" e .cs

                // --- TROCAR DADOS

                        //  - trocar "Leitor_dados__"( "nome" ) pelos valores estaticos 
                                // ** todas as classes que vao dar os dados tem que ter esse padrão de "Leitor_dados__" para garantir que ele vai 

                        
                //  - os arquivos originais sejam trocados as extensoes para .cs_ARQUIVO_ORIGINA para que nao sejam compilados


// --- pos 
        //  -  criar folders especiais 
        //  -  mover dlls dinamicas para os folders especifico


public  class Controlador_builder_pre :IPreprocessBuildWithReport {

        public int callbackOrder { get { return 0; } } // nao importa mas precisa pela interface


        public void OnPreprocessBuild( BuildReport _reporta ){



                // SE FALHAR DENTRO ELES VOLTAM AO ESTADO ORIGINAL 
                Builder_verificacoes.Ativar();
                Builder_dados_estaticos.Ativar();
                Builder_arquivos.Ativar();

                return;

        }

}


public  class Controlador_builder_pos :IPostprocessBuildWithReport {

        public int callbackOrder { get { return 0; } } // nao importa mas precisa pela interface


        public void OnPostprocessBuild( BuildReport _report ){



        }


        public  void Buildar_pre(){


                Builder_dados_estaticos.Ativar();
                Builder_arquivos.Ativar();

                


        }

}