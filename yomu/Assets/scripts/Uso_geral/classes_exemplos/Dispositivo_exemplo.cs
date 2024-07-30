using UnityEngine;



public static class Dispositivo__exemplo {


        // ** independente do tipo as imagens sempre vao ser localizadasdentro desse arr
        public enum DISPOSITIVO__USO_PLAYER__CONECTOR__EXEMPLO__imagem{ bloco_vermelho }''


        public enum Localizador_parte_dispositivo{ parte_1 }
        public enum Localizador_outros_dispositivos{}


        public enum Localizador_parte_dispositivo_imagem_estatica{}
        public enum Localizador_parte_dispositivo_imagem_interativo{} 
        public enum Localizador_parte_dispositivo_botao{}
        public enum Localizador_parte_dispositivo_slider{} 
        public enum Localizador_parte_dispositivo_scrollbar{} 
        public enum Localizador_parte_dispositivo_toggle{} 
        public enum Localizador_parte_dispositivo_toggle_grupo{} 
        public enum Localizador_parte_dispositivo_input_field{} 
        public enum Localizador_parte_dispositivo_drop_down{} 

        public static string nome_dispositivo;


        public static Dispositivo Construir( GameObject _pai  /* args */  ){

                // --- CRIA INTERFACE

                Dispositivo dispositivo = Dispositivo.Construir( nome_dispositivo, _pai );


                // --- COLOCA FUNCOES

                    dispositivo.Update = Update;
                    dispositivo.Enviar_dados = ( Del_void_TO_object ) Enviar_dados;
                    dispositivo.Receber_dados = Receber_dados;
                    dispositivo.Finalizar = Finalizar;

                    // *** imagens
                    dispositivo.Definir_imagens_SELF = Definir_imagens;
                    dispositivo.Definir_audios_SELF = Definir_audios;

                #if UNITY_EDITOR
                    dispositivo.modulo_imagens.tipo = typeof( DISPOSITIVO__USO_PLAYER__CONECTOR__EXEMPLO__imagem );
                #endif
            
                return null;
            
            


        }


        // --- functions 


        public static void Definir_imagens( MODULO__imagens_dispositivo imagens ){

                imagens.Definir_imagem_estatica                  
                ( 
                    _parte_id: ( int ) Localizador_parte_dispositivo.parte_1,
                    _imagem_id: ( int ) DISPOSITIVO__USO_PLAYER__CONECTOR__EXEMPLO__imagem.bloco_vermelho
                );

           
                imagens.Definir_imagem_estatica_com_imagem_geral( 
                                                                    _parte_id: ( int ) Localizador_parte_dispositivo.parte_1,
                                                                    _chaves: new string[]{ "folder_1", "imagem"  }
                                                                );
                

                return;


        }

      

        public static void Definir_audios( MODULO__audios_dispositivo audios ){ return; }
  

        // --- METODOS INTERNOS
        public static void Update(){}
        public static System.Object Enviar_dados(){ return null; }
        public static void Receber_dados( string _dados ){ return; }
        public static void Finalizar(){}


}



