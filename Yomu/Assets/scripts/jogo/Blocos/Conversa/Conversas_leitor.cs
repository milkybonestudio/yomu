using System;









public class Conversas_leitor {


    
    public static Conversas_leitor instancia;
    public static Conversas_leitor Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Conversas_leitor")) { instancia = new Conversas_leitor();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Conversas_leitor(); instancia.Iniciar(); }
            return instancia;

    }
    public void Iniciar(){}

    public string[] cenas = null;

    public int cena_atual = 0;

    public void Ler_cena( string _origem ){

            // cena_atual++;
            // string cena = cenas [ cena_atual ];

            // Tipos_conversas_cenas tipo =  ( Tipos_conversas_cenas )  ( ( int ) cena[ 0 ] + 48 );

            // switch( tipo ){

            //     case Tipos_conversas_cenas.player : break;
            //     case Tipos_conversas_cenas.personagem : break;
            //     case Tipos_conversas_cenas.perguntas : break;
            //     case Tipos_conversas_cenas.respostas : break;

            // }


    }


    public void Ler_player( string _cena ){
        
    }
    public void Ler_personagem( string _cena ){}
    public void Ler_perguntas( string _cena ){}
    public void Ler_respostas( string _cena ){}





}