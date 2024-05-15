using UnityEngine;
using System;









public class Controlador_utilidades{

      
    public static Controlador_utilidades instancia;
    public static Controlador_utilidades Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Controlador_utilidades")) { instancia = new Controlador_utilidades();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Controlador_utilidades(); instancia.Iniciar(); }
            return instancia;

    }

       public void Iniciar(){

            
            canvas_utilidades = GameObject.Find("Tela/Canvas/Jogo/Outros");

       }


        public GameObject canvas_utilidades;

        public Action Update_utilidades = null;


        public void Update(){

                if(Update_utilidades != null) Update_utilidades();
                return;

        }


        public void Finalizar(){

                // Mono_instancia.DestroyImmediate( canvas_utilidades.transform.GetChild(0).gameObject);
                // Update_utilidades = null;
                // BLOCO_jogo.Pegar_instancia().update_tipo_atual = Jogo_update_tipo.movimento;

        }

        

        public void Iniciar_utilidade(   Interativo_nome _interativo_nome   ){ 

                Construir_utilidade( _interativo_nome );
                //BLOCO_jogo.Pegar_instancia().update_tipo_atual = Jogo_update_tipo.utilidades;

                Debug.Log("veio iniciar utilidades");

        }


        public void Construir_utilidade( Interativo_nome _interativo_nome ){

                switch( _interativo_nome ){

                        case Interativo_nome.CARTA_DIA_mesa_quarto_nara:  Update_utilidades = Utilidades_bloco_1.Bilhete_dia(); break;

                        default: throw new ArgumentException("nao foi criado gameObject em controlador_utilidades. Id: " + _interativo_nome);

                }
            
        }

}




