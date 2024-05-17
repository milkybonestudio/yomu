using System;
using UnityEngine;




/*


    controlador_UI vai ficar responsavel por verificar se o player esta acionando alguma parte da UI. 
    A logica vai ficar dentro de cada bloco. 

    mesmos e por algum erro por exemplo não for trocado os icones de moviemnto para conversa os icones não terão nenhuma logica em si.



    
    bool o_player_esta_com_o_mouse_em_cima_do_icone_nesse_momento_agora_yes =  Controaldor_movimento.Pegar_instancia().molde_jogo.Verificar_icone( Molde_icone.lala );
    if( o_player_esta_com_o_mouse_em_cima_do_icone_nesse_momento_agora_yes ) { Icone_Lala.Pegar_instancia().Ativar(); }


    ** talvez se o bloco estiver em Bloco.nada no update em jogo ele verifique somente o "esc", oque dá a opçao de sair do jogo para segurança. isso nunca pode acontecer mas vai acontecer 

*/


// instanciar vs esconder 






public class _Controlador_UI {

    public static _Controlador_UI instancia;
    public static _Controlador_UI Pegar_instancia(){ if( instancia == null) { throw new Exception( "Em pegar_instancia de Controlador_UI a instancia estava null" );} return instancia; }
    public static void Construir(){ instancia = new _Controlador_UI();return; }

    public GameObject ui_container_game_object;

    public _Controlador_UI(){

        ui_container_game_object = GameObject.Find( "Tela/UI/UI_container" );

    }

    public Molde_jogo molde_jogo;








}