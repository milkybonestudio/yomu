using  UnityEngine;
using System ;




public class Controlador_UI_compartilhado {

    public static Controlador_UI_compartilhado instancia;
    public static Controlador_UI_compartilhado Pegar_instancia( bool _forcar = false  ){

            if( _forcar ) {if( Verificador_instancias_nulas.Verificar_se_pode_criar_objetos("Controlador_UI_compartilhado")) { instancia = new Controlador_UI_compartilhado();instancia.Iniciar();} return instancia;}
            if(  instancia == null) { instancia = new Controlador_UI_compartilhado(); instancia.Iniciar(); }
            return instancia;

    }

     public void Iniciar(){}





    // controle 
    public int numero_slots_inicias = 10;
    public int numero_para_adicionar = 5;


    public string[] UIs = null;

    public string[][] chaves = null;
    public Action[][] functions = null;

    public Controlador_UI_compartilhado(){

        
        string[] UIs = new string[ numero_slots_inicias ];
        string[][] chaves = new string[ numero_slots_inicias ][];
        Action[][] functions = new Action[ numero_slots_inicias ][];


    }


    public void Colocar_UI( string _nome_UI , string[] _metodos_nomes , Action[] _actions ){

            string nenhuma_UI = null;
            int index_para_acrescentar = Pegar_index_de_UI( nenhuma_UI ) ;

            if( index_para_acrescentar == -1 ) {   index_para_acrescentar = UIs.Length; Aumentar_slots() ; }

            UIs[ index_para_acrescentar ] = _nome_UI ;
            functions[ index_para_acrescentar ] = _actions ;
            chaves[ index_para_acrescentar ] = _metodos_nomes ;

            return;

    }

    public void  Tirar_UI( string _ui_nome ){

            int index_para_tirar = Pegar_index_de_UI( _ui_nome ) ;

            if( index_para_tirar == -1) { Debug.Log("não foi achado UI para tirar: " + _ui_nome) ; return;}

            UIs[ index_para_tirar ] = null ;
            functions[ index_para_tirar ] = null;
            chaves[ index_para_tirar ] = null ;

            return;

    }

    public void Ativar_metodo( string _nome_ui, string _nome_metodo ){

        int index_para_ui = Pegar_index_de_UI( _nome_ui ) ;
        string[] metodos = chaves[ index_para_ui ];
        int index_para_chaves = index_para_ui;
        int index_metodo = Pegar_index_de_chaves(  _nome_metodo , index_para_chaves ) ;
        if( index_metodo == -1 ) { throw new ArgumentException ( "não foi achado o metodo: " + _nome_metodo + " na ui " + _nome_ui ); }
        if( functions[ index_metodo ] == null  )  { throw new ArgumentException( "tentou ativar uma funcao do metodo: " + _nome_metodo + " na ui " + _nome_ui + " mas o valor estava null"); }
        functions[ index_para_ui ][ index_metodo ] ();
        return;

    }


    public int Pegar_index_de_UI ( string _nome  ) { return Pegar_index_generico ( _nome, UIs ) ; }
    public int Pegar_index_de_chaves ( string _nome , int _index_chaves ) { return Pegar_index_generico ( _nome, chaves[ _index_chaves ] ) ; }


    public int Pegar_index_generico( string _nome , string[] _coisa){


        int index = 0 ;

        for( ; index < _coisa.Length ; index++ ){

            if( _coisa[ index ] == _nome ){  return index ; }
            continue;

        }

        return -1;

    }

     public void Aumentar_slots(){

        int numero_atual = UIs.Length;
        int novo_numero = UIs.Length + numero_para_adicionar ;


        string[] novo_UIs = new string[ novo_numero ];
        string[][] novo_chaves = new string[ novo_numero ][];
        Action[][] novo_functions = new Action[ novo_numero ][];

        for( int slot_antigo_index = 0 ;  slot_antigo_index < numero_atual  ; slot_antigo_index++  ){

            novo_UIs[ slot_antigo_index ] = UIs[ slot_antigo_index ] ; 
            novo_chaves [slot_antigo_index ] = chaves[ slot_antigo_index ] ; 
            novo_functions [ slot_antigo_index ] = functions[ slot_antigo_index ] ; 

        }

            UIs = novo_UIs ; 
            chaves = novo_chaves ; 
            functions = novo_functions ; 
            return;





     }

}




