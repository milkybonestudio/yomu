


using UnityEngine;

public static class Teste_figure_context{

        public static Figure figure;

        private static void U(){


                    // // ** cria sem context -> default visual novel
                    // // ** constroi mas nao define o lugar para instanciar a figure, vai ficar no container generico
                    // figure = Teste_figure.Construct();

                    // // ** cria com context
                    // figure = Teste_figure.Construct( Figure_use_context.conversation );

                    // // // ** constroi e já fala o local
                    // // figure = Teste_figure.Construct( Figure_mode.mad ).Set( GameObject.Find( "Container_teste" ) );

                    // // // ** Seta o lugar
                    // // figure.Set( GameObject.Find( "Container_teste" ) );


                    
                    // // // ** Setar como null vai fazer o gameObject ser instanciado no container generico
                    // // figure.Set( null );



                    // // ** vai começar a carregar os recursor de um modo
                    // figure.Prepare_mode( Figure_mode.mad );

                    // // ** vai voltar os recursos para o minomo e destruir a teture. Tomar cuidado quando usar
                    // figure.Reduce_mode( Figure_mode.mad );


                    // // ** vai preparar de todos os modos
                    // figure.Prepare_all();

                    // // ** libera todos os recursos, tomar muito cuido
                    // figure.Reduce_all();


                    // // // ** coloca ele no jogo, força a instanciar um modo
                    // // // ** seria melhor fazer figure.Prepare() -> figure.Instanciate
                    // // // ** se nao definir um lugar antes ele vai dar um erro
                    // // figure.Instanciate( Figure_mode.mad );

                    // // // ** coloca ele no jogo, força a instanciar um modo
                    // // // ** seria melhor fazer figure.Prepare() -> figure.Instanciate
                    // // figure.Instanciate( Figure_mode.mad, GameObject.Find( "Container_teste" ) );



                    // figure.Activate(new(){
                    //     parent = GameObject.Find( "Container_teste" )
                    // });





                    // // ** troca o modo
                    // // ** sempre preferir figure.Prepare() -> figure.Change()
                    // figure.Change_mode( Figure_mode.mad );


                    // // ** todos os metodos das figures tem argumentos em forma de structs especificos
                    //     // ** depois de 50~ elementos vale mais a pena usar classes
                        
                    // figure.Blick( new Blink_data() );
                    // figure.Speak( new Speak_data() );




                    // //test

                    // // ** pega modo
                    // // ** usado somente para teste, nao tem porque ficar mexendo nele diretamente
                    // figure.figure_modes.Get( Figure_mode.mad );

                    // //test



        }

}