using System;
using UnityEngine;
using UnityEngine.UI;




public static class Controlador_animacao_visual_novel{



    public static void Iniciar_animacao( Animacao_nome _animacao_nome ){


        Animacao_visual_novel animacao = Pegar_animacao( _animacao_nome );






    }


    public static Animacao_visual_novel Pegar_animacao( Animacao_nome _nome ){

        /*
            depois:
            ao invez de salvar na dll salvar os dados em um .txt 
            (int) _nome => linha ou file 
        */

        switch( _nome ){

            case Animacao_nome.DIA_INTRODUCAO_montando_takeru :    return Pegar_DIA_INTRODUCAO_montando_takeru(); 

            default: throw new ArgumentException("nao foi achado animacao para o nome animacao " + _nome.ToString() );



        }

        

    }


    public static Animacao_visual_novel Pegar_DIA_INTRODUCAO_montando_takeru(){

        return null;

    }



  

    public static void Teste(){

        int numero_quadros = 1;

        Transform pai = Controlador_tela_visual_novel.Pegar_instancia().animacao.transform;
        Image[] images = Controlador_tela_visual_novel.Pegar_instancia().Criar_frames( numero_quadros );
        
    

        Animacao_visual_novel animacao_cenas_principal = new Animacao_visual_novel();


        animacao_cenas_principal.images = images;

        animacao_cenas_principal.numero_quadros = 2;
        animacao_cenas_principal.loop = false;
        animacao_cenas_principal.frame_jogo_Por_frame_animacao = 3;


        animacao_cenas_principal.na_frente = true;
        animacao_cenas_principal.instantaneo = true;
        

        animacao_cenas_principal.proxima_animacao_visual_novel = null;

        animacao_cenas_principal.frame_jogo_Por_frame_animacao = 1;
        animacao_cenas_principal.ciclos_bloqueio = 30;
      
        animacao_cenas_principal.folder_path = "images/teste_animacao/";
        animacao_cenas_principal.numero_quadros = numero_quadros;

    
        /// espera 500ms para nao ter missclick
        animacao_cenas_principal.ciclos_bloqueio = 30;



        int[][] sequencias_principal = new int[  numero_quadros ][];

        sequencias_principal[0] = new int[] {      1,2,3 };
        

        animacao_cenas_principal.sequencias = sequencias_principal;
        animacao_cenas_principal.numero_imagens_totais = sequencias_principal[0].Length;


        Controlador_tela_visual_novel.Pegar_instancia().animacao_visual_novel = animacao_cenas_principal;


    }




    public static void Dia_sentando_takeru(){

        int numero_quadros = 2;

        Transform pai = Controlador_tela_visual_novel.Pegar_instancia().animacao.transform;
        Image[] images = Controlador_tela_visual_novel.Pegar_instancia().Criar_frames( numero_quadros );


        Animacao_visual_novel animacao_cenas_loop = new Animacao_visual_novel();

        animacao_cenas_loop.images = images;

        animacao_cenas_loop.numero_quadros = 1;
        animacao_cenas_loop.loop = true;
        animacao_cenas_loop.frame_jogo_Por_frame_animacao = 3;

        animacao_cenas_loop.na_frente = true;
        animacao_cenas_loop.instantaneo = true;
        

        animacao_cenas_loop.proxima_animacao_visual_novel = null;

        animacao_cenas_loop.frame_jogo_Por_frame_animacao = 1;
        animacao_cenas_loop.ciclos_bloqueio = 30;
      
        animacao_cenas_loop.folder_path = null;
        animacao_cenas_loop.numero_quadros = numero_quadros;

        animacao_cenas_loop.sequencias = null;
      
        /// espera 500ms para nao ter missclick
        animacao_cenas_loop.ciclos_bloqueio = 30;

        int[][] sequencias_loop = new int[ numero_quadros ][];

        sequencias_loop[0] = new int[] {      1    ,     2    ,     3     };
        

        animacao_cenas_loop.sequencias = sequencias_loop;
        animacao_cenas_loop.numero_imagens_totais = sequencias_loop[0].Length;






        Animacao_visual_novel animacao_cenas_principal = new Animacao_visual_novel();

        Controlador_tela_visual_novel.Pegar_instancia().animacao_visual_novel = animacao_cenas_principal;

        animacao_cenas_principal.images = images;

        animacao_cenas_principal.numero_quadros = 2;
        animacao_cenas_principal.loop = false;
        animacao_cenas_principal.frame_jogo_Por_frame_animacao = 3;


        animacao_cenas_principal.na_frente = true;
        animacao_cenas_principal.instantaneo = true;
        

        animacao_cenas_principal.proxima_animacao_visual_novel = animacao_cenas_loop;

        animacao_cenas_principal.frame_jogo_Por_frame_animacao = 1;
        animacao_cenas_principal.ciclos_bloqueio = 30;
      
        animacao_cenas_principal.folder_path = null;
        animacao_cenas_principal.numero_quadros = 1;

    
        /// espera 500ms para nao ter missclick
        animacao_cenas_principal.ciclos_bloqueio = 30;



        int[][] sequencias_principal = new int[2][];

        sequencias_principal[0] = new int[] {      1    ,     1    ,     1     ,     1     };
        sequencias_principal[1] = new int[] {      1    ,     2    ,     3     ,     3     };

        animacao_cenas_principal.sequencias = sequencias_principal;
        animacao_cenas_principal.numero_imagens_totais = sequencias_principal[0].Length;

        

    }






}