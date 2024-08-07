using System.Collections;

public static class Gerenciador_seguranca_main {


            public static Task_req task_reconstruir;
    

            public static IEnumerator C_reconstruindo_save (){

                

                  // colocar video algo deu errado, um momento

                  while( Controlador.Pegar_instancia().esta_reconstruindo_save ){ yield return null; }
                  yield break;

            }


            public static bool Garantir_arquivo_de_seguranca(){

                  byte[] dados = Verificador_arquivo_de_seguranca.Pegar_dados();
                  bool arquivo_foi_encerrado_corretamente = Verificador_arquivo_de_seguranca.Programa_foi_encerrado_corretamente( dados );

                  if( !( arquivo_foi_encerrado_corretamente ) )
                        {
                              // --- PRECISA ARRUMAR DADOS
                              int save = Verificador_arquivo_de_seguranca.Pegar_save( dados );
                              Controlador controlador = Controlador.Pegar_instancia();


                              task_reconstruir = new Task_req( new Chave_cache() , "reconstruindo_save" );

                              task_reconstruir.fn_iniciar = ( Task_req _req ) => {

                                                                    Reestruturador_save.Reconstruir_save( save );
                                                                    return;

                                                            };

                              task_reconstruir.fn_finalizar =   ( Task_req _req ) => {

                                                                    controlador.esta_reconstruindo_save = false;
                                                                    controlador.login = Login.Construir();
                                                                    return;

                                                                };
                              
                              Controlador_multithread.Pegar_instancia().Adicionar_task( task_reconstruir );
                              controlador.esta_reconstruindo_save = true;
                              Mono_instancia.Start_coroutine( C_reconstruindo_save() );
                              return false;
                              
                        }


                  return true;
            }








}