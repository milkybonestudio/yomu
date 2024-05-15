using UnityEngine;
using System;



public class Controlador_dados_dinamicos{


    public static Controlador_dados_dinamicos instancia;
    public static Controlador_dados_dinamicos Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Controlador_dados_dinamicos")) { instancia = new Controlador_dados_dinamicos();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Controlador_dados_dinamicos(); instancia.Iniciar(); }
            return instancia;

    }




    public Lista_navegacao lista_navegacao;

    public Dados_blocos dados_blocos;

    public void Iniciar(){

        lista_navegacao = Lista_navegacao.Pegar_instancia( true );
        dados_blocos = new Dados_blocos();

    }

    public void Zerar(){

        lista_navegacao.Zerar();

    }



    public static void Mudar_interativos_para_acrescentar(  Ponto_nome _ponto_nome , int[] _slots,  Interativo_nome[] _interativos  ){


            instancia.lista_navegacao.Mudar_interativos_para_acrescentar(_ponto_nome ,_slots, _interativos);
            return;
            

    }



}