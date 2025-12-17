using System;









public class Conversas_leitor {


    
        public static Conversas_leitor instancia;
        public static Conversas_leitor Pegar_instancia(){ return instancia; }
        public static Conversas_leitor Construir(){ instancia = new Conversas_leitor(); return instancia;}


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