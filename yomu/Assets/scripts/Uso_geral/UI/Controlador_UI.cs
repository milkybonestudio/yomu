using System;
using UnityEngine;




/*


UI =>   

tem um nome no enum Tipo_UI que vai apontar para uma class com o tipo de UI

tem um enum para cada tipo de Ui para cada componente da UI

todo tipo de UI precisa ter 3 funcoes:


Mudar_visibilidade  => pega um bool[] que o index representa se o componente vai ser mostrado. bool[   (int) enum.componente   ] == true  => vai mostrar
Esconder => esconde tudo 
Mostrar => mostra tudo 


se o objeto tem componentes moveis ele não pode mover se estiver escondido



*/





public class Controlador_UI {


        
            public static Controlador_UI instancia;
            public static Controlador_UI Pegar_instancia(){ return instancia; }



        public Dispositivo[] dispositivos_ui;
        public Localizador_UI[] localizadores;





        // --- ANTIGO



            

        //public System.Object UI_objeto;

        public GameObject game_object = null;

        public Tipo_UI tipo_UI_atual = Tipo_UI.nada;
        public UI_info info;


        public void Iniciar() {


        }

        public Action UI_objeto_update;

        public bool foi_ativado = false;

        public bool Update(){

            /*  UI pode corta o fluxo anted de chegar em cada bloco. o jeito que ele vai mudar foi_ativado depende de cada objeto  */
            /*  choice => sempre retona true. o jogo para completamenta para o player fazer a escolha   */
            /*  icones => retorna true se algo for ativado   */

            // Ui nao vai ativar necessariamente algo no bloco_jogo. nesse logica Mapa estaria em Ui e não em jogo.

            foi_ativado = false;

            if( UI_objeto_update != null ) { UI_objeto_update(); } 

            return foi_ativado;



        }


}