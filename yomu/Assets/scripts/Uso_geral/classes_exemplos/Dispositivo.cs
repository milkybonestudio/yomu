using UnityEngine;



public class Dispositivo {



        public Dispositivo[] dispositivos_filhos;

        
        // --- MODULOS
        

        // --- trocar nome, nao é um modulo, é um gerenciador
        public MODULO__imagens_dispositivo modulo_imagens;
        public MODULO__estados_dispositivo modulo_estados;
        public MODULO__audios_dispositivo modulo_audios;
        public MODULO__dados_dispositivo  dados_dispositivo;



        public System.Action Update ;

        public Del_void_TO_object Enviar_dados ;
        public System.Action<string> Receber_dados ;
        public System.Action Finalizar ;

        // --- IMAGENS

        
        public System.Action<MODULO__imagens_dispositivo> Definir_imagens_SELF ;
        public void Definir_imagens(){ Definir_imagens_SELF( modulo_imagens ); return; }

        public void Carregar_imagens(){ modulo_imagens.Carregar_imagens();}
        public void Colocar_imagens(){ modulo_imagens.Colocar_imagens( dados_dispositivo );}

        // --- AUDIO
        public System.Action<MODULO__audios_dispositivo> Definir_audios_SELF;
        public void Definir_audios(){ Definir_audios_SELF( modulo_audios ); return; }
        public void Carregar_audios(){ modulo_audios.Carregar_audios();}
        public void Colocar_audios(){ modulo_audios.Colocar_audios( dados_dispositivo );}




        // --- DEFAULT

        public static void _default(){ throw new System.Exception( $"Nao colocaou o metodo INTERFACE__dispositivo" ); }
        public static void _default_2( string _ ){ throw new System.Exception( $"Nao colocaou o metodo INTERFACE__dispositivo" ); }
        public static System.Object _default_3( ){ throw new System.Exception( $"Nao colocaou o metodo INTERFACE__dispositivo" ); }



        

    
        public static Dispositivo Construir( string _nome_dispositivo, GameObject _pai  ){



                Dispositivo dispositivo = new Dispositivo();

                // --- GARANTE DEFAULTS
                dispositivo.Update = _default;
                dispositivo.Enviar_dados = ( Del_void_TO_object ) _default_3;
                dispositivo.Receber_dados = _default_2;
                dispositivo.Finalizar = _default;
                dispositivo.Definir_imagens_SELF = ( MODULO__imagens_dispositivo m ) => { throw new System.Exception( $"Nao colocaou o metodo INTERFACE__dispositivo" );  };
                dispositivo.Definir_audios_SELF = ( MODULO__audios_dispositivo m ) => { throw new System.Exception( $"Nao colocaou o metodo INTERFACE__dispositivo" );  };;


                // --- PEGAR PATH
                string path_arquivo = Paths_sistema.path_folder__imagens_gerais + _nome_dispositivo;


                // --- CRIA MODULO IMAGENS 
                dispositivo.modulo_imagens = new MODULO__imagens_dispositivo( 
                                                                            _nome_gerenciador : _nome_dispositivo + "_GERENCIADOR",
                                                                            _path_arquivo : path_arquivo
                                                                        );




                // --- CRIA MODULO AUDIO
                dispositivo.modulo_audios = new MODULO__audios_dispositivo();

                // --- CRIA MODULO DADOS
                dispositivo.dados_dispositivo = new MODULO__dados_dispositivo();


                return dispositivo;
            
        }




}