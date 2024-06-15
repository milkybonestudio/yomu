using System;



public class Gerenciador_save_dados_sistema {

        
        public Gerenciador_save_dados_sistema( Controlador_sistema _controlador_sistema ){

                controlador_sistema = _controlador_sistema;
        }


        public Controlador_sistema controlador_sistema;


        // ---- plots LIXEIRA
        // ** a lixeira dos dados sistema provavelmente vai ser a mais diferente 



        // --- USO SALVANDO STACK
        // ** colocar conforme for precisando 




        public Dados_para_salvar Pegar_dados_sistema_para_salvar( Modo_save _modo ){


                if( _modo == Modo_save.salvando_stack )
                        {
                                
                                // o foco quando a stack estiver sendo trocada vai ser sempre 

                                // ** loop em coisas para salvar

                                // --- SE ESTA SALVANDO A STACK NAO VAI PARA A LIXEIRA 
                                return null;
                        }

                
                // --- VERIFICAR LIXEIRA 
                return null ;

        }



        public Dados_para_salvar Criar_dados_para_salvar( int _plot_id ) {


                throw new Exception( "nao era para vir aqui" );

        }

        // ** pensar depois 
        public void Colocar_instrucoes_de_seguranca_dados_sistema (  int _coisa_id ,  byte[] _dados_seguranca  ){

                throw new Exception("a");

        }


        public byte[][][][] Pegar_instrucoes_de_seguranca_dados_sistema( Modo_save _modo ){



                // [ stack ][ coisa ][ instrucoes ][ bytes_instucoes ]

                byte[][][][] retorno = new byte[ 2 ][][][]{

                        new byte[ 0 ][][], 
                        new byte[ 0 ][][], 

                };
                

                // --- PEGA PRIMEIRA STACK
                // loop primeira stack


                if( _modo == Modo_save.salvando_stack )
                        {
                                
                                // * loop segunda stack 


                        }


                throw new Exception("a");

                

        }






}

